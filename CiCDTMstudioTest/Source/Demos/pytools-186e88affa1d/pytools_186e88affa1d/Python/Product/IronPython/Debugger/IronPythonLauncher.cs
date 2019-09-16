﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.PythonTools;
using Microsoft.PythonTools.Project;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudioTools.Project;
using Microsoft.Win32;

namespace Microsoft.IronPythonTools.Debugger {
    class IronPythonLauncher : IProjectLauncher {
        private static Process _chironProcess;
        private static string _chironDir;
        private static int _chironPort;
        private static readonly Guid _cpyInterpreterGuid = new Guid("{2AF0F10D-7135-4994-9156-5D01C9C11B7E}");
        private static readonly Guid _cpy64InterpreterGuid = new Guid("{9A7A9026-48C1-4688-9D5D-E5699D47D074}");

        private readonly IPythonProject _project;
        private readonly PythonToolsService _pyService;
        private readonly IServiceProvider _serviceProvider;

        public IronPythonLauncher(IServiceProvider serviceProvider, PythonToolsService pyService, IPythonProject project) {
            _serviceProvider = serviceProvider;
            _pyService = pyService;
            _project = project;
        }

        #region IPythonLauncher Members

        public int LaunchProject(bool debug) {
            string startupFile = ResolveStartupFile();
            return LaunchFile(startupFile, debug);
        }

        private string NoIronPythonHelpPage {
            get {
                try {
                    var path = Path.GetDirectoryName(typeof(IronPythonLauncher).Assembly.Location);
                    return Path.Combine(path, "NoIronPython.mht");
                } catch (ArgumentException) {
                } catch (NotSupportedException) {
                }
                return null;
            }
        }

        public int LaunchFile(string file, bool debug) {
            var factory = _project.GetInterpreterFactory();

            if (factory == null ||
                factory.Configuration == null ||
                !File.Exists(factory.Configuration.InterpreterPath)) {
                throw new NoInterpretersException(null, NoIronPythonHelpPage);
            }

            if (factory.Id == _cpyInterpreterGuid || factory.Id == _cpy64InterpreterGuid) {
                MessageBox.Show(
                    "The project is currently set to use the .NET debugger for IronPython debugging but the project is configured to start with a CPython interpreter.\r\n\r\nTo fix this change the debugger type in project properties->Debug->Launch mode.\r\nIf IronPython is not an available interpreter you may need to download it from http://ironpython.codeplex.com.",
                    "Python Tools for Visual Studio");
                return VSConstants.S_OK;
            }

            string extension = Path.GetExtension(file);
            if (String.Equals(extension, ".html", StringComparison.OrdinalIgnoreCase) ||
                String.Equals(extension, ".htm", StringComparison.OrdinalIgnoreCase)) {
                try {
                    StartSilverlightApp(file, debug);
                } catch (ChironNotFoundException ex) {
                    MessageBox.Show(ex.Message, "Python Tools for Visual Studio");
                }
            } else if (debug) {
                StartWithDebugger(file);
            } else {
                StartWithoutDebugger(file);
            }
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Default implementation of the "Start withput Debugging" command.
        /// </summary>
        private void StartWithoutDebugger(string startupFile) {
            var psi = CreateProcessStartInfoNoDebug(startupFile);
            if (psi == null) {
                MessageBox.Show(
                    "The project cannot be started because its active Python environment does not have the interpreter executable specified.",
                    "Python Tools for Visual Studio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Process.Start(psi);
        }

        /// <summary>
        /// Creates process info used to start the project with no debugging.
        /// </summary>
        private ProcessStartInfo CreateProcessStartInfoNoDebug(string startupFile) {
            string command = CreateCommandLineNoDebug(startupFile);

            bool isWindows;
            string interpreter = GetInterpreterExecutableInternal(out isWindows);
            if (string.IsNullOrEmpty(interpreter)) {
                return null;
            }

            ProcessStartInfo startInfo;
            if (!isWindows && (_pyService.DebuggerOptions.WaitOnNormalExit || _pyService.DebuggerOptions.WaitOnAbnormalExit)) {
                command = "/c \"\"" + interpreter + "\" " + command;
                
                if (_pyService.DebuggerOptions.WaitOnNormalExit &&
                    _pyService.DebuggerOptions.WaitOnAbnormalExit) {
                    command += " & pause";
                } else if (_pyService.DebuggerOptions.WaitOnNormalExit) {
                    command += " & if not errorlevel 1 pause";
                } else if (_pyService.DebuggerOptions.WaitOnAbnormalExit) {
                    command += " & if errorlevel 1 pause";
                }

                command += "\"";
                startInfo = new ProcessStartInfo("cmd.exe", command);
            } else {
                startInfo = new ProcessStartInfo(interpreter, command);
            }

            startInfo.WorkingDirectory = _project.GetWorkingDirectory();

            //In order to update environment variables we have to set UseShellExecute to false
            startInfo.UseShellExecute = false;
            SetupEnvironment(startInfo.EnvironmentVariables);
            return startInfo;
        }

        /// <summary>
        /// Creates language specific command line for starting the project without debigging.
        /// </summary>
        public string CreateCommandLineNoDebug(string startupFile) {
            string cmdLineArgs = _project.GetProperty(PythonConstants.CommandLineArgumentsSetting);
            string interpArgs = _project.GetProperty(PythonConstants.InterpreterArgumentsSetting);

            return String.Format("{0} \"{1}\" {2}", interpArgs, startupFile, cmdLineArgs);
        }

        #endregion

        /// <summary>
        /// Default implementation of the "Start Debugging" command.
        /// </summary>
        private void StartWithDebugger(string startupFile) {
            VsDebugTargetInfo dbgInfo = new VsDebugTargetInfo();
            dbgInfo.cbSize = (uint)Marshal.SizeOf(dbgInfo);
            IntPtr ptr = Marshal.AllocCoTaskMem((int)dbgInfo.cbSize);
            try {
                Marshal.StructureToPtr(dbgInfo, ptr, false);
                SetupDebugInfo(ref dbgInfo, startupFile);

                if (string.IsNullOrEmpty(dbgInfo.bstrExe)) {
                    MessageBox.Show(
                        "The project cannot be debugged because its active Python environment does not have the interpreter executable specified.",
                        "Python Tools for Visual Studio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LaunchDebugger(_serviceProvider, dbgInfo);
            } finally {
                if (ptr != IntPtr.Zero) {
                    Marshal.FreeCoTaskMem(ptr);
                }
            }
        }

        /// <summary>
        /// Sets up debugger information.
        /// </summary>
        private void SetupDebugInfo(ref VsDebugTargetInfo dbgInfo, string startupFile) {
            dbgInfo.dlo = DEBUG_LAUNCH_OPERATION.DLO_CreateProcess;
            bool isWindows;
            dbgInfo.bstrExe = GetInterpreterExecutableInternal(out isWindows);
            dbgInfo.bstrCurDir = _project.GetWorkingDirectory();
            dbgInfo.bstrArg = CreateCommandLineDebug(startupFile);
            dbgInfo.bstrRemoteMachine = null;
            dbgInfo.fSendStdoutToOutputWindow = 0;
            StringDictionary env = new StringDictionary();
            SetupEnvironment(env);

            if (env.Count > 0) {
                // add any inherited env vars
                var variables = Environment.GetEnvironmentVariables();
                foreach (var key in variables.Keys) {
                    string strKey = (string)key;
                    if (!env.ContainsKey(strKey)) {
                        env.Add(strKey, (string)variables[key]);
                    }
                }

                //Environemnt variables should be passed as a
                //null-terminated block of null-terminated strings. 
                //Each string is in the following form:name=value\0
                StringBuilder buf = new StringBuilder();
                foreach (DictionaryEntry entry in env) {
                    buf.AppendFormat("{0}={1}\0", entry.Key, entry.Value);
                }
                buf.Append("\0");
                dbgInfo.bstrEnv = buf.ToString();
            }
            // Set the CLR debugger
            dbgInfo.clsidCustom = VSConstants.CLSID_ComPlusOnlyDebugEngine;
            dbgInfo.grfLaunch = (uint)__VSDBGLAUNCHFLAGS.DBGLAUNCH_StopDebuggingOnEnd;
        }

        /// <summary>
        /// Creates language specific command line for starting the project with debigging.
        /// </summary>
        public string CreateCommandLineDebug(string startupFile) {
            string cmdLineArgs = null;
            if (_project != null) {
                cmdLineArgs = _project.GetProperty(PythonConstants.CommandLineArgumentsSetting);
            }
            return String.Format("-X:Debug {0} \"{1}\" {2}", GetOptions(), startupFile, cmdLineArgs);
        }

        /// <summary>
        /// Returns full path of the language specififc iterpreter executable file.
        /// </summary>
        public string GetInterpreterExecutable(out bool isWindows) {
            isWindows = Convert.ToBoolean(_project.GetProperty(PythonConstants.IsWindowsApplicationSetting));
            return isWindows ? WindowsInterpreterExecutable : InterpreterExecutable;
        }

        private string/*!*/ GetInterpreterExecutableInternal(out bool isWindows) {
            string result;
            result = (_project.GetProperty(PythonConstants.InterpreterPathSetting) ?? "").Trim();
            if (!String.IsNullOrEmpty(result)) {
                if (!Path.IsPathRooted(result)) {
                    result = Path.Combine(_project.GetWorkingDirectory(), result);
                }
                if (!File.Exists(result)) {
                    throw new FileNotFoundException(String.Format("Interpreter specified in the project does not exist: '{0}'", result), result);
                }
                isWindows = false;
                return result;
            }


            result = GetInterpreterExecutable(out isWindows);
            if (result == null) {
                throw new FileNotFoundException(@"The project is currently set to use the .NET debugger for IronPython debugging but IronPython is not installed.

You may need to download it from http://ironpython.codeplex.com.");
            }
            return result;
        }

        private static void LaunchDebugger(IServiceProvider provider, VsDebugTargetInfo dbgInfo) {
            if (!Directory.Exists(UnquotePath(dbgInfo.bstrCurDir))) {
                MessageBox.Show(String.Format("Working directory \"{0}\" does not exist.", dbgInfo.bstrCurDir), "Python Tools for Visual Studio");
            } else if (!File.Exists(UnquotePath(dbgInfo.bstrExe))) {
                MessageBox.Show(String.Format("Interpreter \"{0}\" does not exist.", dbgInfo.bstrExe), "Python Tools for Visual Studio");
            } else {
                VsShellUtilities.LaunchDebugger(provider, dbgInfo);
            }
        }

        private string InterpreterExecutable {
            get {
                return _project.GetInterpreterFactory().Configuration.InterpreterPath;
            }
        }

        private string WindowsInterpreterExecutable {
            get {
                return _project.GetInterpreterFactory().Configuration.WindowsInterpreterPath;
            }
        }

        private static string UnquotePath(string p) {
            if (p.StartsWith("\"") && p.EndsWith("\"")) {
                return p.Substring(1, p.Length - 2);
            }
            return p;
        }

        private static Guid guidSilvelightDebug = new Guid("{032F4B8C-7045-4B24-ACCF-D08C9DA108FE}");

        public void StartSilverlightApp(string/*!*/ file, bool debug) {
            string webSiteRoot;
            webSiteRoot = _project.GetWorkingDirectory();
            file = Path.GetFullPath(Path.Combine(webSiteRoot, file));
            webSiteRoot = webSiteRoot.TrimEnd('\\');

            int port = EnsureChiron(webSiteRoot);

            string url = "http://localhost:" + port;
            if (file.StartsWith(webSiteRoot) && file.Length > webSiteRoot.Length && file[webSiteRoot.Length] == '\\') {
                url += file.Substring(webSiteRoot.Length).Replace('\\', '/');
            } else if (file.StartsWith("\\")) {
                url += file.Replace('\\', '/');
            } else {
                url += '/' + file.Replace('\\', '/');
            }

            StartInBrowser(url, debug ? guidSilvelightDebug : (Guid?)null);
        }

        public void StartInBrowser(string url, Guid? debugEngine) {
            if (debugEngine.HasValue) {
                // launch via VS debugger, it'll take care of figuring out the browsers
                VsDebugTargetInfo dbgInfo = new VsDebugTargetInfo();
                dbgInfo.dlo = (DEBUG_LAUNCH_OPERATION)_DEBUG_LAUNCH_OPERATION3.DLO_LaunchBrowser;
                dbgInfo.bstrExe = url;
                dbgInfo.clsidCustom = debugEngine.Value;
                dbgInfo.grfLaunch = (uint)__VSDBGLAUNCHFLAGS.DBGLAUNCH_StopDebuggingOnEnd | (uint)__VSDBGLAUNCHFLAGS4.DBGLAUNCH_UseDefaultBrowser;
                dbgInfo.cbSize = (uint)Marshal.SizeOf(dbgInfo);

                VsShellUtilities.LaunchDebugger(_serviceProvider, dbgInfo);
            } else {
                // run the users default browser
                var handler = GetBrowserHandlerProgId();
                var browserCmd = (string)Registry.ClassesRoot.OpenSubKey(handler).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue("");

                if (browserCmd.IndexOf("%1") != -1) {
                    browserCmd = browserCmd.Replace("%1", url);
                } else {
                    browserCmd = browserCmd + " " + url;
                }
                bool inQuote = false;
                string cmdLine = null;
                for (int i = 0; i < browserCmd.Length; i++) {
                    if (browserCmd[i] == '"') {
                        inQuote = !inQuote;
                    }

                    if (browserCmd[i] == ' ' && !inQuote) {
                        cmdLine = browserCmd.Substring(0, i);
                        break;
                    }
                }
                if (cmdLine == null) {
                    cmdLine = browserCmd;
                }

                Process.Start(cmdLine, browserCmd.Substring(cmdLine.Length));
            }
        }

        private static string GetBrowserHandlerProgId() {
            try {
                return (string)Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("Explorer").OpenSubKey("FileExts").OpenSubKey(".html").OpenSubKey("UserChoice").GetValue("Progid");
            } catch {
                return (string)Registry.ClassesRoot.OpenSubKey(".html").GetValue("");
            }
        }

        private int EnsureChiron(string/*!*/ webSiteRoot) {
            Debug.Assert(!webSiteRoot.EndsWith("\\"));

            if (_chironDir != webSiteRoot && _chironProcess != null && !_chironProcess.HasExited) {
                try {
                    _chironProcess.Kill();
                } catch {
                    // process already exited
                }
                _chironProcess = null;
            }

            if (_chironProcess == null || _chironProcess.HasExited) {
                // start Chiron
                var chironPath = ChironPath;

                // Get a free port
                _chironPort = GetFreePort();

                // TODO: race condition - the port might be taked by the time Chiron attempts to open it
                // TODO: we should wait for Chiron before launching the browser

                string commandLine = "/w:" + _chironPort + " /notification /d:";

                if (webSiteRoot.IndexOf(' ') != -1) {
                    commandLine += "\"" + webSiteRoot + "\"";
                } else {
                    commandLine += webSiteRoot;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo(chironPath, commandLine);
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                _chironDir = webSiteRoot;
                _chironProcess = Process.Start(startInfo);
            }

            return _chironPort;
        }

        private static int GetFreePort() {
            return Enumerable.Range(new Random().Next(1200, 2000), 60000).Except(
                from connection in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections()
                select connection.LocalEndPoint.Port
            ).First();
        }


        public string ChironPath {
            get {
                string result = GetPythonInstallDir();
                if (result != null) {
                    result = Path.Combine(result, @"Silverlight\bin\Chiron.exe");
                    if (File.Exists(result)) {
                        return result;
                    }
                }

                result = Path.Combine(Path.GetDirectoryName(typeof(IronPythonLauncher).Assembly.Location), "Chiron.exe");
                if (File.Exists(result)) {
                    return result;
                }

                throw new ChironNotFoundException();
            }
        }


        internal static string GetPythonInstallDir() {
            using (var ipy = Registry.LocalMachine.OpenSubKey("SOFTWARE\\IronPython")) {
                if (ipy != null) {
                    using (var twoSeven = ipy.OpenSubKey("2.7")) {
                        if (twoSeven != null) {
                            using (var installPath = twoSeven.OpenSubKey("InstallPath")) {
                                var path = installPath.GetValue("") as string;
                                if (path != null) {
                                    return path;
                                }
                            }
                        }
                    }
                }
            }

            var paths = Environment.GetEnvironmentVariable("PATH");
            if (paths != null) {
                foreach (string dir in paths.Split(Path.PathSeparator)) {
                    try {
                        if (IronPythonExistsIn(dir)) {
                            return dir;
                        }
                    } catch {
                        // ignore
                    }
                }
            }

            return null;
        }


        private static bool IronPythonExistsIn(string/*!*/ dir) {
            return File.Exists(Path.Combine(dir, "ipy.exe"));
        }

        private string ResolveStartupFile() {
            string startupFile = _project.GetStartupFile();
            if (string.IsNullOrEmpty(startupFile)) {
                //TODO: need to start active file then
                throw new ApplicationException("No startup file is defined for the startup project.");
            }
            return startupFile;
        }


        private string GetOptions() {
            if (_project != null) {
                string interpArgs = _project.GetProperty(PythonConstants.InterpreterArgumentsSetting);

                var debugStdLib = _project.GetProperty(IronPythonLauncherOptions.DebugStandardLibrarySetting);
                bool debugStdLibResult;
                if (!bool.TryParse(debugStdLib, out debugStdLibResult) || !debugStdLibResult) {
                    bool isWindows;
                    string interpreter = GetInterpreterExecutableInternal(out isWindows);
                    string interpDir = Path.GetDirectoryName(interpreter);
                    var res = "-X:NoDebug \"" + System.Text.RegularExpressions.Regex.Escape(Path.Combine(interpDir, "Lib\\")) + ".*\"";

                    return interpArgs + " " + res;
                }

                return interpArgs;
            }
            return String.Empty;
        }

        private void SetupEnvironment(StringDictionary environment) {
            if (_project != null) {
                //IronPython passes search path via IRONPYTHONPATH environment variable
                environment["IRONPYTHONPATH"] = string.Join(";", _project.GetSearchPaths());
            }
        }

        [Serializable]
        class ChironNotFoundException : Exception {
            public ChironNotFoundException()
                : this("Chiron.exe was not found. Ensure the Silverlight Tools component of IronPython has been installed.") {
            }

            public ChironNotFoundException(string message) : base(message) { }
            public ChironNotFoundException(string message, Exception inner) : base(message, inner) { }
            protected ChironNotFoundException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }
    }
}
