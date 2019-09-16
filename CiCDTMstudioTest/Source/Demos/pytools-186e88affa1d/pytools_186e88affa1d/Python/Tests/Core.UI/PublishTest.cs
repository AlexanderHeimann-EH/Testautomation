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

extern alias pythontools;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestUtilities;
using TestUtilities.Python;
using TestUtilities.UI;
using CommonUtils = pythontools::Microsoft.VisualStudioTools.CommonUtils;

namespace PythonToolsUITests {
    [TestClass]
    public class PublishTest {
        private static string TestFtpUrl = "ftp://anonymous:blazzz@" + GetPyToolsIp() + "/testdir";

        private const string FtpValidateDir = "\\\\pytools\\ftproot$\\testdir";
        private const string TestSharePublic = "\\\\pytools\\Test$";
        private const string TestSharePrivate = "\\\\pytools\\PubTest$";
        private const string PrivateShareUser = "pytools\\TestUser";
        private const string PrivateShareUserWithoutMachine = "TestUser";
        private const string PrivateSharePassword = "!10ctopus";
        private const string PrivateSharePasswordIncorrect = "NotThisPassword";

        [ClassInitialize]
        public static void DoDeployment(TestContext context) {
            AssertListener.Initialize();
            PythonTestData.Deploy();
        }

        public TestContext TestContext { get; set; }

        [DllImport("mpr")]
        static extern uint WNetCancelConnection2(string lpName, uint dwFlags, bool fForce);

        private static string GetPyToolsIp() {
            // try ipv4
            foreach (var entry in Dns.GetHostEntry("pytools").AddressList) {
                if (entry.AddressFamily == AddressFamily.InterNetwork) {
                    return entry.ToString();
                }
            }

            // fallback to anything
            foreach (var entry in Dns.GetHostEntry("pytools").AddressList) {
                return entry.ToString();
            }

            throw new InvalidOperationException();
        }

        private static string[] WaitForFiles(string dir) {
            string[] confirmation = null;
            string[] files = null;
            for (int retries = 10; retries > 0; --retries) {
                try {
                    files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
                    break;
                } catch (IOException) {
                }
                Thread.Sleep(1000);
            }

            while (confirmation == null || files.Except(confirmation).Any()) {
                Thread.Sleep(500);
                confirmation = files;
                files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
            }

            return files;
        }

        private static string[] PublishAndWaitForFiles(VisualStudioApp app, string command, string dir) {
            app.Dte.ExecuteCommand(command);

            return WaitForFiles(dir);
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void TestPublishFiles() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\HelloWorld.sln");
                try {
                    string subDir = Guid.NewGuid().ToString();
                    project.Properties.Item("PublishUrl").Value = Path.Combine(TestSharePublic, subDir);
                    app.OnDispose(() => project.Properties.Item("PublishUrl").Value = "");
                    string dir = Path.Combine(TestSharePublic, subDir);

                    app.OpenSolutionExplorer().SelectProject(project);

                    var files = PublishAndWaitForFiles(app, "Build.PublishSelection", dir);

                    Assert.IsNotNull(files, "Timed out waiting for files to publish");
                    Assert.AreEqual(1, files.Length);
                    Assert.AreEqual("Program.py", Path.GetFileName(files[0]));

                    Directory.Delete(dir, true);
                } finally {
                    WNetCancelConnection2(TestSharePublic, 0, true);
                }
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void TestPublishReadOnlyFiles() {
            var sourceFile = TestData.GetPath(@"TestData\HelloWorld\Program.py");
            Assert.IsTrue(File.Exists(sourceFile), sourceFile + " not found");
            var attributes = File.GetAttributes(sourceFile);

            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\HelloWorld.sln");
                try {
                    string subDir = Guid.NewGuid().ToString();
                    project.Properties.Item("PublishUrl").Value = Path.Combine(TestSharePublic, subDir);
                    app.OnDispose(() => project.Properties.Item("PublishUrl").Value = "");
                    string dir = Path.Combine(TestSharePublic, subDir);

                    File.SetAttributes(sourceFile, attributes | FileAttributes.ReadOnly);

                    app.OpenSolutionExplorer().SelectProject(project);

                    var files = PublishAndWaitForFiles(app, "Build.PublishSelection", dir);
                    
                    Assert.IsNotNull(files, "Timed out waiting for files to publish");
                    Assert.AreEqual(1, files.Length);
                    Assert.AreEqual("Program.py", Path.GetFileName(files[0]));
                    Assert.IsTrue(File.GetAttributes(sourceFile).HasFlag(FileAttributes.ReadOnly), "Source file should be read-only");
                    Assert.IsFalse(File.GetAttributes(files[0]).HasFlag(FileAttributes.ReadOnly), "Published file should not be read-only");

                    Directory.Delete(dir, true);
                } finally {
                    WNetCancelConnection2(TestSharePublic, 0, true);
                    File.SetAttributes(sourceFile, attributes);
                }
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void TestPublishFilesControlled() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\PublishTest.sln");
                try {
                    string subDir = Guid.NewGuid().ToString();
                    project.Properties.Item("PublishUrl").Value = Path.Combine(TestSharePublic, subDir);
                    app.OnDispose(() => project.Properties.Item("PublishUrl").Value = "");
                    string dir = Path.Combine(TestSharePublic, subDir);

                    app.OpenSolutionExplorer().SelectProject(project);

                    var files = PublishAndWaitForFiles(app, "Build.PublishSelection", dir);

                    Assert.IsNotNull(files, "Timed out waiting for files to publish");
                    Assert.AreEqual(2, files.Length);
                    AssertUtil.ContainsExactly(
                        files.Select(Path.GetFileName),
                        "Program.py",
                        "TextFile.txt"
                    );

                    Directory.Delete(dir, true);
                } finally {
                    WNetCancelConnection2(TestSharePrivate, 0, true);
                }
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void TestPublishFilesImpersonate() {
            WNetCancelConnection2(TestSharePrivate, 0, true);
            using (var app = new VisualStudioApp()) {
                try {
                    var project = app.OpenProject(@"TestData\HelloWorld.sln");
                    string subDir = Guid.NewGuid().ToString();
                    project.Properties.Item("PublishUrl").Value = Path.Combine(TestSharePrivate, subDir);
                    app.OnDispose(() => project.Properties.Item("PublishUrl").Value = "");

                    app.OpenSolutionExplorer().SelectProject(project);

                    using (var creds = CredentialsDialog.PublishSelection(app)) {
                        creds.UserName = PrivateShareUserWithoutMachine;
                        creds.Password = PrivateSharePassword;
                        creds.OK();
                    }

                    string dir = Path.Combine(TestSharePrivate, subDir);

                    var files = WaitForFiles(dir);

                    Assert.IsNotNull(files, "Timed out waiting for files to publish");
                    Assert.AreEqual(1, files.Length);
                    Assert.AreEqual("Program.py", Path.GetFileName(files[0]));

                    Directory.Delete(dir, true);
                } finally {
                    WNetCancelConnection2(TestSharePrivate, 0, true);
                }
            }
        }

        class NetUseHelper : IDisposable {
            public readonly string Drive;   // drive, with colon, without backslash

            public NetUseHelper() {
                var procInfo = new ProcessStartInfo(
                    Path.Combine(Environment.SystemDirectory, "net.exe"),
                    String.Format("use * {0} /user:{1} {2}",
                        TestSharePrivate,
                        PrivateShareUser,
                        PrivateSharePassword
                    )
                );
                procInfo.RedirectStandardOutput = true;
                procInfo.RedirectStandardError = true;
                procInfo.UseShellExecute = false;
                procInfo.CreateNoWindow = true;
                var process = Process.Start(procInfo);
                var line = process.StandardOutput.ReadToEnd();
                if (!line.StartsWith("Drive ")) {
                    throw new InvalidOperationException("didn't get expected drive output " + line);
                }
                Drive = line.Substring(6, 2);
                process.Close();
            }

            public void Dispose() {
                var procInfo = new ProcessStartInfo(
                    Path.Combine(Environment.SystemDirectory, "net.exe"),
                    "use /delete " + Drive
                );
                procInfo.RedirectStandardOutput = true;
                procInfo.UseShellExecute = false;
                procInfo.CreateNoWindow = true;
                var process = Process.Start(procInfo);
                process.WaitForExit();
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void TestPublishFilesImpersonateNoMachineName() {
            WNetCancelConnection2(TestSharePrivate, 0, true);
            using (var app = new VisualStudioApp()) {
                try {
                    var project = app.OpenProject(@"TestData\HelloWorld.sln");
                    string subDir = Guid.NewGuid().ToString();
                    project.Properties.Item("PublishUrl").Value = Path.Combine(TestSharePrivate, subDir);
                    app.OnDispose(() => project.Properties.Item("PublishUrl").Value = "");

                    app.OpenSolutionExplorer().SelectProject(project);

                    using (var creds = CredentialsDialog.PublishSelection(app)) {
                        creds.UserName = PrivateShareUserWithoutMachine;
                        creds.Password = PrivateSharePassword;
                        creds.OK();
                    }

                    System.Threading.Thread.Sleep(2000);

                    using (var helper = new NetUseHelper()) {
                        string dir = Path.Combine(helper.Drive + "\\", subDir);
                        var files = WaitForFiles(dir);
                        Assert.AreEqual(1, files.Length);
                        Assert.AreEqual("Program.py", Path.GetFileName(files[0]));

                        Directory.Delete(dir, true);
                    }
                } finally {
                    WNetCancelConnection2(TestSharePrivate, 0, true);
                }
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void TestPublishFilesImpersonateWrongCredentials() {
            WNetCancelConnection2(TestSharePrivate, 0, true);
            using (var app = new VisualStudioApp()) {
                try {
                    var project = app.OpenProject(@"TestData\HelloWorld.sln");
                    string subDir = Guid.NewGuid().ToString();
                    project.Properties.Item("PublishUrl").Value = Path.Combine(TestSharePrivate, subDir);
                    app.OnDispose(() => project.Properties.Item("PublishUrl").Value = "");
                    string dir = Path.Combine(TestSharePrivate, subDir);

                    app.OpenSolutionExplorer().SelectProject(project);

                    using (var creds = CredentialsDialog.PublishSelection(app)) {
                        creds.UserName = PrivateShareUser;
                        creds.Password = PrivateSharePasswordIncorrect;
                        creds.OK();
                    }

                    const string expected = "Publish failed: Incorrect user name or password: ";

                    string text = "";
                    for (int i = 0; i < 5; i++) {
                        var statusBar = app.GetService<IVsStatusbar>(typeof(SVsStatusbar));
                        ErrorHandler.ThrowOnFailure(statusBar.GetText(out text));
                        if (text.StartsWith(expected)) {
                            break;
                        }
                        System.Threading.Thread.Sleep(2000);
                    }

                    Assert.IsTrue(text.StartsWith(expected), "Expected '{0}', got '{1}'", expected, text);
                } finally {
                    WNetCancelConnection2(TestSharePrivate, 0, true);
                }
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void TestPublishFilesImpersonateCancelCredentials() {
            WNetCancelConnection2(TestSharePrivate, 0, true);
            using (var app = new VisualStudioApp()) {
                try {
                    var project = app.OpenProject(@"TestData\HelloWorld.sln");
                    string subDir = Guid.NewGuid().ToString();
                    project.Properties.Item("PublishUrl").Value = Path.Combine(TestSharePrivate, subDir);
                    app.OnDispose(() => project.Properties.Item("PublishUrl").Value = "");
                    string dir = Path.Combine(TestSharePrivate, subDir);

                    app.OpenSolutionExplorer().SelectProject(project);

                    using (var creds = CredentialsDialog.PublishSelection(app)) {
                        creds.UserName = PrivateShareUser;
                        creds.Password = PrivateSharePasswordIncorrect;
                        creds.Cancel();
                    }

                    var statusBar = app.GetService<IVsStatusbar>(typeof(SVsStatusbar));
                    string text = null;
                    const string expected = "Publish failed: Access to the path";

                    for (int i = 0; i < 10; i++) {
                        ErrorHandler.ThrowOnFailure(statusBar.GetText(out text));

                        if (text.StartsWith(expected)) {
                            break;
                        }
                        System.Threading.Thread.Sleep(1000);
                    }

                    Assert.IsTrue(text.StartsWith(expected), "Expected '{0}', got '{1}'", expected, text);
                } finally {
                    WNetCancelConnection2(TestSharePrivate, 0, true);
                }
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void TestPublishFtp() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\HelloWorld.sln");
                string subDir = Guid.NewGuid().ToString();
                string url = TestFtpUrl + "/" + subDir;
                project.Properties.Item("PublishUrl").Value = url;
                app.OnDispose(() => project.Properties.Item("PublishUrl").Value = "");
                string dir = Path.Combine(FtpValidateDir, subDir);
                Debug.WriteLine(dir);

                app.OpenSolutionExplorer().SelectProject(project);

                app.ExecuteCommand("Build.PublishSelection");
                System.Threading.Thread.Sleep(2000);
                var files = WaitForFiles(dir);
                Assert.AreEqual(1, files.Length);
                Assert.AreEqual("Program.py", Path.GetFileName(files[0]));

                // do it again w/ the directories already existing
                File.Delete(files[0]);

                app.OpenSolutionExplorer().SelectProject(project);
                app.ExecuteCommand("Build.PublishSelection");
                files = WaitForFiles(dir);
                Assert.AreEqual(1, files.Length);
                Assert.AreEqual("Program.py", Path.GetFileName(files[0]));

                Directory.Delete(dir, true);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void TestPublishVirtualEnvironment() {
            using (var app = new VisualStudioApp()) {
                var project = app.OpenProject(@"TestData\VirtualEnv.sln");
                var dir = TestData.GetTempPath(randomSubPath: true);
                project.Properties.Item("PublishUrl").Value = dir;
                app.OnDispose(() => project.Properties.Item("PublishUrl").Value = "");

                app.OpenSolutionExplorer().SelectProject(project);
                var files = PublishAndWaitForFiles(app, "Build.PublishSelection", dir);

                Assert.IsNotNull(files, "Timed out waiting for files to publish");
                AssertUtil.ContainsAtLeast(
                    files.Select(f => CommonUtils.GetRelativeFilePath(dir, f).ToLowerInvariant()),
                    "env\\include\\pyconfig.h",
                    "env\\lib\\site.py",
                    "env\\scripts\\python.exe",
                    "program.py"
                );

                Directory.Delete(dir, true);
            }
        }
    }
}
