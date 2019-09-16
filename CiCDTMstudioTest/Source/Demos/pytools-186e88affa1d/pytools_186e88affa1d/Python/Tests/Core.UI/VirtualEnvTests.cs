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

extern alias analysis;
extern alias util;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.PythonTools;
using Microsoft.PythonTools.Interpreter;
using Microsoft.PythonTools.Project;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudioTools;
using TestUtilities;
using TestUtilities.Python;
using TestUtilities.UI;
using TestUtilities.UI.Python;
using Path = System.IO.Path;

namespace PythonToolsUITests {
    [TestClass]
    public class VirtualEnvTests {
        [ClassInitialize]
        public static void DoDeployment(TestContext context) {
            AssertListener.Initialize();
            PythonTestData.Deploy();
        }

        public TestContext TestContext { get; set; }

        static DefaultInterpreterSetter Init(PythonVisualStudioApp app) {
            return app.SelectDefaultInterpreter(PythonPaths.Python27 ?? PythonPaths.Python27_x64, "virtualenv");
        }

        static DefaultInterpreterSetter Init(PythonVisualStudioApp app, PythonVersion interp, bool install) {
            return app.SelectDefaultInterpreter(interp, install ? "virtualenv" : null);
        }

        private EnvDTE.Project CreateTemporaryProject(VisualStudioApp app) {
            var project = app.CreateProject(
                PythonVisualStudioApp.TemplateLanguageName,
                PythonVisualStudioApp.PythonApplicationTemplate,
                TestData.GetTempPath(),
                TestContext.TestName
            );

            Assert.IsNotNull(project, "Project was not created");
            return project;
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void InstallUninstallPackage() {
            using (var app = new PythonVisualStudioApp())
            using (var dis = Init(app)) {
                var project = CreateTemporaryProject(app);

                string envName;
                var env = app.CreateVirtualEnvironment(project, out envName);
                env.Select();

                using (var installPackage = AutomationDialog.FromDte(app, "Python.InstallPackage")) {
                    var packageName = new TextBox(installPackage.FindByAutomationId("Name"));
                    packageName.SetValue("azure==0.6.2");
                    installPackage.ClickButtonAndClose("OK", nameIsAutomationId: true);
                }

                var azure = app.SolutionExplorerTreeView.WaitForChildOfProject(
                    project,
                    SR.GetString(SR.Environments),
                    envName,
                    "azure (0.6.2)"
                );

                azure.Select();

                using (var confirmation = AutomationDialog.FromDte(app, "Edit.Delete")) {
                    confirmation.OK();
                }

                app.SolutionExplorerTreeView.WaitForChildOfProjectRemoved(
                    project,
                    SR.GetString(SR.Environments),
                    envName,
                    "azure (0.6.2)"
                );
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void CreateInstallRequirementsTxt() {
            using (var app = new PythonVisualStudioApp())
            using (var dis = Init(app)) {
                var project = CreateTemporaryProject(app);

                var projectHome = project.GetPythonProject().ProjectHome;
                File.WriteAllText(Path.Combine(projectHome, "requirements.txt"), "azure==0.6.2");

                string envName;
                var env = app.CreateVirtualEnvironment(project, out envName);
                env.Select();

                app.SolutionExplorerTreeView.WaitForChildOfProject(
                    project,
                    SR.GetString(SR.Environments),
                    envName,
                    "azure (0.6.2)"
                );
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void InstallGenerateRequirementsTxt() {
            using (var app = new PythonVisualStudioApp())
            using (var dis = Init(app)) {
                var project = CreateTemporaryProject(app);

                string envName;
                var env = app.CreateVirtualEnvironment(project, out envName);
                env.Select();

                try {
                    app.ExecuteCommand("Python.InstallRequirementsTxt", "/y", timeout: 5000);
                    Assert.Fail("Command should not have executed");
                } catch (AggregateException ae) {
                    ae.Handle(ex => ex is COMException);
                } catch (COMException) {
                }

                var requirementsTxt = Path.Combine(Path.GetDirectoryName(project.FullName), "requirements.txt");
                File.WriteAllText(requirementsTxt, "azure==0.6.2");

                app.ExecuteCommand("Python.InstallRequirementsTxt", "/y");

                app.SolutionExplorerTreeView.WaitForChildOfProject(
                    project,
                    SR.GetString(SR.Environments),
                    envName,
                    "azure (0.6.2)"
                );

                File.Delete(requirementsTxt);

                app.ExecuteCommand("Python.GenerateRequirementsTxt", "/e:\"" + envName + "\"");

                app.SolutionExplorerTreeView.WaitForChildOfProject(
                    project,
                    "requirements.txt"
                );
                
                Assert.AreEqual("azure==0.6.2", File.ReadAllText(requirementsTxt).Trim());
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void LoadVirtualEnv() {
            using (var app = new PythonVisualStudioApp())
            using (var dis = Init(app)) {
                var project = CreateTemporaryProject(app);
                var projectName = project.UniqueName;

                string envName;
                var env = app.CreateVirtualEnvironment(project, out envName);

                var solution = app.Dte.Solution.FullName;
                app.Dte.Solution.Close(true);

                app.Dte.Solution.Open(solution);
                project = app.Dte.Solution.Item(projectName);

                app.OpenSolutionExplorer().WaitForChildOfProject(
                    project,
                    SR.GetString(SR.Environments),
                    envName
                );
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void ActivateVirtualEnv() {
            using (var app = new PythonVisualStudioApp())
            using (var dis = Init(app)) {
                var project = CreateTemporaryProject(app);

                Assert.AreNotEqual(null, project.ProjectItems.Item(Path.GetFileNameWithoutExtension(app.Dte.Solution.FullName) + ".py"));

                var id0 = Guid.Parse((string)project.Properties.Item("InterpreterId").Value);

                string envName1, envName2;
                var env1 = app.CreateVirtualEnvironment(project, out envName1);
                var env2 = app.CreateVirtualEnvironment(project, out envName2);

                var id1 = Guid.Parse((string)project.Properties.Item("InterpreterId").Value);
                Assert.AreNotEqual(id0, id1);

                env1.Select();
                try {
                    app.Dte.ExecuteCommand("Python.ActivateEnvironment");
                    Assert.Fail("First env should already be active");
                } catch (COMException) {
                }

                env2.Select();
                app.Dte.ExecuteCommand("Python.ActivateEnvironment");

                var id2 = Guid.Parse((string)project.Properties.Item("InterpreterId").Value);
                Assert.AreNotEqual(id0, id2);
                Assert.AreNotEqual(id1, id2);

                // Change the selected node
                app.SolutionExplorerTreeView.SelectProject(project);
                app.Dte.ExecuteCommand("Python.ActivateEnvironment", "/env:\"" + envName1 + "\"");

                var id1b = Guid.Parse((string)project.Properties.Item("InterpreterId").Value);
                Assert.AreEqual(id1, id1b);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void RemoveVirtualEnv() {
            using (var app = new PythonVisualStudioApp())
            using (var dis = Init(app)) {
                var project = CreateTemporaryProject(app);

                string envName, envPath;
                var env = app.CreateVirtualEnvironment(project, out envName, out envPath);

                env.Select();

                using (var removeDeleteDlg = RemoveItemDialog.FromDte(app)) {
                    removeDeleteDlg.Remove();
                }

                app.OpenSolutionExplorer().WaitForChildOfProjectRemoved(
                    project,
                    SR.GetString(SR.Environments),
                    envName
                );

                var projectHome = (string)project.Properties.Item("ProjectHome").Value;
                envPath = Path.Combine(projectHome, envPath);
                Assert.IsTrue(Directory.Exists(envPath), envPath);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void DeleteVirtualEnv() {
            using (var app = new PythonVisualStudioApp())
            using (var dis = Init(app)) {
                var project = CreateTemporaryProject(app);

                string envName, envPath;
                var env = app.CreateVirtualEnvironment(project, out envName, out envPath);

                // Need to wait for analysis to complete before deleting - otherwise
                // it will always fail.
                for (int retries = 120;
                    Process.GetProcessesByName("Microsoft.PythonTools.Analyzer").Any() && retries > 0;
                    --retries) {
                    Thread.Sleep(1000);
                }

                Assert.IsFalse(Process.GetProcessesByName("Microsoft.PythonTools.Analyzer").Any(), "Analyzer is still running");

                // Need to wait some more for the database to be loaded.
                app.WaitForNoDialog(TimeSpan.FromSeconds(5.0));

                env.Select();
                using (var removeDeleteDlg = RemoveItemDialog.FromDte(app)) {
                    removeDeleteDlg.Delete();
                }

                app.WaitForNoDialog(TimeSpan.FromSeconds(5.0));

                app.OpenSolutionExplorer().WaitForChildOfProjectRemoved(
                    project,
                    SR.GetString(SR.Environments),
                    envName
                );

                var projectHome = (string)project.Properties.Item("ProjectHome").Value;
                envPath = Path.Combine(projectHome, envPath);
                for (int retries = 10;
                    Directory.Exists(envPath) && retries > 0;
                    --retries) {
                    Thread.Sleep(1000);
                }
                Assert.IsFalse(Directory.Exists(envPath), envPath);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void DefaultBaseInterpreterSelection() {
            // The project that will be loaded references these environments.
            PythonPaths.Python27.AssertInstalled();
            PythonPaths.Python33.AssertInstalled();

            using (var app = new PythonVisualStudioApp())
            using (var dis = Init(app)) {
                var project = app.OpenProject(@"TestData\Environments.sln");

                app.OpenSolutionExplorer().SelectProject(project);
                app.Dte.ExecuteCommand("Python.ActivateEnvironment", "/env:\"Python 2.7\"");

                using (var createVenv = AutomationDialog.FromDte(app, "Python.AddVirtualEnvironment")) {
                    var baseInterp = new ComboBox(createVenv.FindByAutomationId("BaseInterpreter")).GetSelectedItemName();

                    Assert.AreEqual("Python 2.7", baseInterp);
                    createVenv.Cancel();
                }

                app.Dte.ExecuteCommand("Python.ActivateEnvironment", "/env:\"Python 3.3\"");

                using (var createVenv = AutomationDialog.FromDte(app, "Python.AddVirtualEnvironment")) {
                    var baseInterp = new ComboBox(createVenv.FindByAutomationId("BaseInterpreter")).GetSelectedItemName();

                    Assert.AreEqual("Python 3.3", baseInterp);
                    createVenv.Cancel();
                }
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void NoGlobalSitePackages() {
            using (var app = new PythonVisualStudioApp())
            using (var dis = Init(app)) {
                var project = CreateTemporaryProject(app);

                string envName, envPath;
                var env = app.CreateVirtualEnvironment(project, out envName, out envPath);

                env.Select();

                // Need to wait for analysis to complete before checking database
                for (int retries = 120;
                    Process.GetProcessesByName("Microsoft.PythonTools.Analyzer").Any() && retries > 0;
                    --retries) {
                    Thread.Sleep(1000);
                }
                // Need to wait some more for the database to be loaded.
                Thread.Sleep(5000);

                // Ensure virtualenv_support is NOT available in the virtual environment.
                var interp = project.GetPythonProject().GetInterpreter();

                Assert.IsNull(interp.ImportModule("virtualenv_support"));
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void CreateVEnv() {
            using (var app = new PythonVisualStudioApp())
            using (var dis = Init(app, PythonPaths.Python33 ?? PythonPaths.Python33_x64, false)) {
                if (analysis::Microsoft.PythonTools.Interpreter.PythonInterpreterFactoryExtensions
                        .FindModules(dis.CurrentDefault, "virtualenv")
                        .Contains("virtualenv")) {
                    Pip.Uninstall(app.ServiceProvider, dis.CurrentDefault, "virtualenv", false).Wait();
                }

                Assert.AreEqual(0, Microsoft.PythonTools.Analysis.ModulePath.GetModulesInLib(dis.CurrentDefault)
                    .Count(mp => mp.FullName == "virtualenv"),
                    string.Format("Failed to uninstall 'virtualenv' from {0}", dis.CurrentDefault.Configuration.PrefixPath)
                );

                var project = CreateTemporaryProject(app);

                string envName, envPath;

                var env = app.CreateVirtualEnvironment(project, out envName, out envPath);
                Assert.IsNotNull(env);
                Assert.IsNotNull(env.Element);
                Assert.AreEqual(string.Format("env (Python {0}3.3)",
                    dis.CurrentDefault.Configuration.Architecture == ProcessorArchitecture.Amd64 ? "64-bit " : ""
                ), envName);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void AddExistingVEnv() {
            PythonPaths.Python33.AssertInstalled();
            if (!analysis::Microsoft.VisualStudioTools.CommonUtils.IsSameDirectory("C:\\Python33", PythonPaths.Python33.PrefixPath)) {
                Assert.Inconclusive("Python 3.3 not configured correctly");
            }

            using (var app = new PythonVisualStudioApp()) {
                var project = CreateTemporaryProject(app);

                string envName;
                var envPath = TestData.GetPath(@"TestData\\Environments\\venv");

                var env = app.AddExistingVirtualEnvironment(project, envPath, out envName);
                Assert.IsNotNull(env);
                Assert.IsNotNull(env.Element);
                Assert.AreEqual("venv (Python 3.3)", envName);
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        public void UnavailableEnvironments() {
            var collection = new Microsoft.Build.Evaluation.ProjectCollection();
            try {
                var service = new MockInterpreterOptionsService();
                var proj = collection.LoadProject(TestData.GetPath(@"TestData\Environments\Unavailable.pyproj"));

                using (var provider = new MSBuildProjectInterpreterFactoryProvider(service, proj)) {
                    try {
                        provider.DiscoverInterpreters();
                        Assert.Fail("Expected InvalidDataException in DiscoverInterpreters");
                    } catch (InvalidDataException ex) {
                        AssertUtil.AreEqual(ex.Message
                            .Replace(TestData.GetPath("TestData\\Environments\\"), "$")
                            .Split('\r', '\n')
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.Trim()),
                            "Some project interpreters failed to load:",
                            @"Interpreter $env\ has invalid value for 'Id': INVALID ID",
                            @"Interpreter $env\ has invalid value for 'Version': INVALID VERSION",
                            @"Base interpreter $env\ has invalid value for 'BaseInterpreter': INVALID BASE",
                            @"Interpreter $env\ has invalid value for 'InterpreterPath': INVALID<>PATH",
                            @"Interpreter $env\ has invalid value for 'WindowsInterpreterPath': INVALID<>PATH",
                            @"Interpreter $env\ has invalid value for 'LibraryPath': INVALID<>PATH",
                            @"Base interpreter $env\ has invalid value for 'BaseInterpreter': {98512745-4ac7-4abb-9f33-120af32edc77}"
                        );
                    }

                    var factories = provider.GetInterpreterFactories().ToList();
                    foreach (var fact in factories) {
                        Console.WriteLine("{0}: {1}", fact.GetType().FullName, fact.Description);
                    }

                    foreach (var fact in factories) {
                        Assert.IsInstanceOfType(
                            fact,
                            typeof(MSBuildProjectInterpreterFactoryProvider.NotFoundInterpreterFactory),
                            string.Format("{0} was not correct type", fact.Description)
                        );
                    }

                    AssertUtil.AreEqual(factories.Select(f => f.Description),
                        "Absent BaseInterpreter (unavailable)",
                        "Invalid BaseInterpreter (unavailable)",
                        "Invalid InterpreterPath (unavailable)",
                        "Invalid LibraryPath (unavailable)",
                        "Invalid WindowsInterpreterPath (unavailable)",
                        "Unknown Python 2.7"
                    );
                }
            } finally {
                collection.UnloadAllProjects();
                collection.Dispose();
            }
        }

        [TestMethod, Priority(0), TestCategory("Core")]
        [HostType("VSTestHost")]
        public void EnvironmentReplWorkingDirectory() {
            using (var app = new PythonVisualStudioApp())
            using (var dis = Init(app)) {
                var project = CreateTemporaryProject(app);

                var path1 = Path.Combine(Path.GetDirectoryName(project.FullName), Guid.NewGuid().ToString("N"));
                var path2 = Path.Combine(Path.GetDirectoryName(project.FullName), Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(path1);
                Directory.CreateDirectory(path2);

                app.ServiceProvider.GetUIThread().Invoke(() => project.GetPythonProject().SetProjectProperty("WorkingDirectory", path1));

                string envName;
                var env = app.CreateVirtualEnvironment(project, out envName);
                env.Select();

                app.Dte.ExecuteCommand("Python.Interactive");

                var window = app.GetInteractiveWindow(string.Format("{0} Interactive", envName));
                try {
                    window.ReplWindow.Evaluator.ExecuteText("import os; os.getcwd()").Wait();
                    window.WaitForTextEnd(
                        string.Format("'{0}'", path1.Replace("\\", "\\\\")),
                        ">>>"
                    );

                    app.ServiceProvider.GetUIThread().Invoke(() => project.GetPythonProject().SetProjectProperty("WorkingDirectory", path2));

                    window.Reset();
                    window.ReplWindow.Evaluator.ExecuteText("import os; os.getcwd()").Wait();
                    window.WaitForTextEnd(
                        string.Format("'{0}'", path2.Replace("\\", "\\\\")),
                        ">>>"
                    );
                } finally {
                    window.Close();
                }
            }
        }
    }
}
