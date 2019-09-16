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
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Microsoft.PythonTools.Debugger.DebugEngine;
using Microsoft.PythonTools.Interpreter;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Debugger;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudioTools;
using Microsoft.VisualStudioTools.Project;

namespace Microsoft.PythonTools.Project {
    /// <summary>
    /// Implements functionality of starting a project or a file with or without debugging.
    /// </summary>
    sealed class DefaultPythonLauncher : IProjectLauncher {
        private readonly IPythonProject/*!*/ _project;
        private readonly PythonToolsService _pyService;
        private readonly IServiceProvider _serviceProvider;

        public DefaultPythonLauncher(IServiceProvider serviceProvider, PythonToolsService pyService, IPythonProject/*!*/ project) {
            Utilities.ArgumentNotNull("project", project);

            _serviceProvider = serviceProvider;
            _pyService = pyService;
            _project = project;
        }

        #region IPythonLauncher Members

        public int LaunchProject(bool debug) {
            string startupFile = ResolveStartupFile();
            return LaunchFile(startupFile, debug);
        }

        public int LaunchFile(string/*!*/ file, bool debug) {
            if (debug) {
                _pyService.Logger.LogEvent(Logging.PythonLogEvent.Launch, 1);
                StartWithDebugger(file);
            } else {
                _pyService.Logger.LogEvent(Logging.PythonLogEvent.Launch, 0);
                StartWithoutDebugger(file);
            }

            return VSConstants.S_OK;
        }

        #endregion

        private string GetInterpreterExecutableInternal(out bool isWindows) {
            if (!Boolean.TryParse(_project.GetProperty(CommonConstants.IsWindowsApplication) ?? Boolean.FalseString, out isWindows)) {
                isWindows = false;
            }

            string result;
            result = (_project.GetProperty(PythonConstants.InterpreterPathSetting) ?? string.Empty).Trim();
            if (!String.IsNullOrEmpty(result)) {
                result = CommonUtils.GetAbsoluteFilePath(_project.ProjectDirectory, result);

                if (!File.Exists(result)) {
                    throw new FileNotFoundException(String.Format("Interpreter specified in the project does not exist: '{0}'", result), result);
                }

                return result;
            }

            var interpreter = _project.GetInterpreterFactory();
            var interpreterService = _serviceProvider.GetComponentModel().GetService<IInterpreterOptionsService>();
            if (interpreterService == null || interpreterService.NoInterpretersValue == interpreter) {
                throw new NoInterpretersException();
            }

            return !isWindows ?
                interpreter.Configuration.InterpreterPath :
                interpreter.Configuration.WindowsInterpreterPath;
        }

        /// <summary>
        /// Creates language specific command line for starting the project without debigging.
        /// </summary>
        public string CreateCommandLineNoDebug(string startupFile) {
            string cmdLineArgs = _project.GetProperty(CommonConstants.CommandLineArguments) ?? string.Empty;
            string interpArgs = _project.GetProperty(PythonConstants.InterpreterArgumentsSetting) ?? string.Empty;

            return string.Join(" ", new[] {
                interpArgs,
                ProcessOutput.QuoteSingleArgument(startupFile),
                cmdLineArgs
            }.Where(s => !string.IsNullOrEmpty(s)));
        }

        /// <summary>
        /// Creates language specific command line for starting the project with debigging.
        /// </summary>
        public string CreateCommandLineDebug(string startupFile, bool includeInterpreterArgs) {
            string interpArgs = includeInterpreterArgs ? _project.GetProperty(PythonConstants.InterpreterArgumentsSetting) : null;
            string cmdLineArgs = _project.GetProperty(CommonConstants.CommandLineArguments) ?? string.Empty;

            return string.Join(" ", new[] {
                interpArgs,
                ProcessOutput.QuoteSingleArgument(startupFile),
                cmdLineArgs
            }.Where(s => !string.IsNullOrEmpty(s)));
        }

        /// <summary>
        /// Default implementation of the "Start without Debugging" command.
        /// </summary>
        private Process StartWithoutDebugger(string startupFile) {
            var psi = CreateProcessStartInfoNoDebug(startupFile);
            if (psi == null) {
                MessageBox.Show(
                    "The project cannot be started because its active Python environment does not have the interpreter executable specified.",
                    "Python Tools for Visual Studio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return Process.Start(psi);
        }

        /// <summary>
        /// Default implementation of the "Start Debugging" command.
        /// </summary>
        private void StartWithDebugger(string startupFile) {
            VsDebugTargetInfo dbgInfo = new VsDebugTargetInfo();
            try {
                dbgInfo.cbSize = (uint)Marshal.SizeOf(dbgInfo);
                SetupDebugInfo(ref dbgInfo, startupFile);

                if (string.IsNullOrEmpty(dbgInfo.bstrExe)) {
                    MessageBox.Show(
                        "The project cannot be debugged because its active Python environment does not have the interpreter executable specified.",
                        "Python Tools for Visual Studio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LaunchDebugger(_serviceProvider, dbgInfo);
            } finally {
                if (dbgInfo.pClsidList != IntPtr.Zero) {
                    Marshal.FreeCoTaskMem(dbgInfo.pClsidList);
                }
            }
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

        private static string UnquotePath(string p) {
            if (p.StartsWith("\"") && p.EndsWith("\"")) {
                return p.Substring(1, p.Length - 2);
            }
            return p;
        }

        /// <summary>
        /// Sets up debugger information.
        /// </summary>
        private unsafe void SetupDebugInfo(ref VsDebugTargetInfo dbgInfo, string startupFile) {
            bool enableNativeCodeDebugging = false;
#if DEV11_OR_LATER
            bool.TryParse(_project.GetProperty(PythonConstants.EnableNativeCodeDebugging), out enableNativeCodeDebugging);
#endif

            dbgInfo.dlo = DEBUG_LAUNCH_OPERATION.DLO_CreateProcess;
            bool isWindows;
            var interpreterPath = GetInterpreterExecutableInternal(out isWindows);
            if (string.IsNullOrEmpty(interpreterPath)) {
                return;
            }

            dbgInfo.bstrExe = interpreterPath;
            dbgInfo.bstrCurDir = _project.GetWorkingDirectory();
            dbgInfo.bstrArg = CreateCommandLineDebug(startupFile, enableNativeCodeDebugging);
            dbgInfo.bstrRemoteMachine = null;
            dbgInfo.fSendStdoutToOutputWindow = 0;

            if (!enableNativeCodeDebugging) {
                string interpArgs = _project.GetProperty(PythonConstants.InterpreterArgumentsSetting);
                dbgInfo.bstrOptions = AD7Engine.VersionSetting + "=" + _project.GetInterpreterFactory().GetLanguageVersion().ToString();
                if (!isWindows) {
                    if (_pyService.DebuggerOptions.WaitOnAbnormalExit) {
                        dbgInfo.bstrOptions += ";" + AD7Engine.WaitOnAbnormalExitSetting + "=True";
                    }
                    if (_pyService.DebuggerOptions.WaitOnNormalExit) {
                        dbgInfo.bstrOptions += ";" + AD7Engine.WaitOnNormalExitSetting + "=True";
                    }
                }
                if (_pyService.DebuggerOptions.TeeStandardOutput) {
                    dbgInfo.bstrOptions += ";" + AD7Engine.RedirectOutputSetting + "=True";
                }
                if (_pyService.DebuggerOptions.BreakOnSystemExitZero) {
                    dbgInfo.bstrOptions += ";" + AD7Engine.BreakSystemExitZero + "=True";
                }
                if (_pyService.DebuggerOptions.DebugStdLib) {
                    dbgInfo.bstrOptions += ";" + AD7Engine.DebugStdLib + "=True";
                }
                if (!String.IsNullOrWhiteSpace(interpArgs)) {
                    dbgInfo.bstrOptions += ";" + AD7Engine.InterpreterOptions + "=" + interpArgs.Replace(";", ";;");
                }

                var djangoDebugging = _project.GetProperty("DjangoDebugging");
                bool enableDjango;
                if (!String.IsNullOrWhiteSpace(djangoDebugging) && Boolean.TryParse(djangoDebugging, out enableDjango)) {
                    dbgInfo.bstrOptions += ";" + AD7Engine.EnableDjangoDebugging + "=True";
                }
            }

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

            if (enableNativeCodeDebugging) {
#if DEV11_OR_LATER
                dbgInfo.dwClsidCount = 2;
                dbgInfo.pClsidList = Marshal.AllocCoTaskMem(sizeof(Guid) * 2);
                var engineGuids = (Guid*)dbgInfo.pClsidList;
                engineGuids[0] = dbgInfo.clsidCustom = DkmEngineId.NativeEng;
                engineGuids[1] = AD7Engine.DebugEngineGuid;
#endif
            } else {
                // Set the Python debugger
                dbgInfo.clsidCustom = new Guid(AD7Engine.DebugEngineId);
                dbgInfo.grfLaunch = (uint)__VSDBGLAUNCHFLAGS.DBGLAUNCH_StopDebuggingOnEnd;
            }
        }

        /// <summary>
        /// Sets up environment variables before starting the project.
        /// </summary>
        private void SetupEnvironment(StringDictionary environment) {
            string pathEnvVar = _project.GetInterpreterFactory().Configuration.PathEnvironmentVariable;
            if (!string.IsNullOrWhiteSpace(pathEnvVar)) {
                var pythonPath = string.Join(";", _project.GetSearchPaths());
                if (!_pyService.GeneralOptions.ClearGlobalPythonPath) {
                    pythonPath += ";" + Environment.GetEnvironmentVariable(pathEnvVar);
                }
                environment[pathEnvVar] = pythonPath;
            }

            string userEnv = _project.GetProperty(PythonConstants.EnvironmentSetting);
            if (userEnv != null) {
                foreach (var envVar in userEnv.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)) {
                    var nameValue = envVar.Split(new[] { '=' }, 2);
                    if (nameValue.Length == 2) {
                        environment[nameValue[0]] = nameValue[1];
                    }
                }
            }
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
            if (!isWindows && (_pyService.DebuggerOptions.WaitOnAbnormalExit || _pyService.DebuggerOptions.WaitOnNormalExit)) {
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
                startInfo = new ProcessStartInfo(Path.Combine(Environment.SystemDirectory, "cmd.exe"), command);
            } else {
                startInfo = new ProcessStartInfo(interpreter, command);
            }

            startInfo.WorkingDirectory = _project.GetWorkingDirectory();

            //In order to update environment variables we have to set UseShellExecute to false
            startInfo.UseShellExecute = false;
            SetupEnvironment(startInfo.EnvironmentVariables);
            return startInfo;
        }

        private string ResolveStartupFile() {
            string startupFile = _project.GetStartupFile();
            if (string.IsNullOrEmpty(startupFile)) {
                //TODO: need to start active file then
                throw new InvalidOperationException(SR.GetString(SR.NoStartupFileAvailable));
            }
            return startupFile;
        }
    }
}
