// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SolutionListenerForDTTestProject.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The solution listener for dt test project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml;

    using EH.DTMstudioTest.Common.Manager;
    using EH.DTMstudioTest.Common.Tools;
    using EH.DTMstudioTest.Common.TransportObjects.AssemblyData;
    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.DTMstudioTest.Common.Utilities.Helper;
    using EH.DTMstudioTest.Common.Utilities.Logging;

    using EnvDTE;

    using EnvDTE80;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Project;
    using Microsoft.VisualStudio.Shell.Design.Serialization;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.Win32;

    using VSLangProj;

    using interop = System.Runtime.InteropServices;

    /// <summary>
    /// The solution listener for dt test project.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class SolutionListenerForDTTestProject : SolutionListener
// ReSharper restore InconsistentNaming
    {
        #region Fields

        /// <summary>
        /// The dte.
        /// </summary>
        private readonly DTE dte;
        
        /// <summary>
        /// The eh project list.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        private readonly EHProjectList ehProjectList;

        /// <summary>
        /// The test framework registry key.
        /// </summary>
        private readonly string testFrameworkRegistryKey;

        /// <summary>
        /// The build events.
        /// </summary>
        private BuildEvents buildEvents;

        /// <summary>
        /// The document events.
        /// </summary>
        private DocumentEvents documentEvents;

        /// <summary>
        /// The solution items events.
        /// </summary>
        private ProjectItemsEvents solutionItemsEvents;

        /// <summary>
        /// The solution events.
        /// </summary>
        private SolutionEvents solutionEvents;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionListenerForDTTestProject"/> class.
        /// </summary>
        /// <param name="serviceProviderParameter">
        /// The service provider parameter.
        /// </param>
        public SolutionListenerForDTTestProject(IServiceProvider serviceProviderParameter)
            : base(serviceProviderParameter)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.ehProjectList = new EHProjectList();

            this.ehProjectList.CollectionChanged += this.OnProjectListCollectionChanged;

            this.ehProjectList.ProjectChanged += this.OnProjectPropertyChanged;

            this.dte = (DTE)serviceProviderParameter.GetService(typeof(DTE));

            this.testFrameworkRegistryKey = (string)Registry.GetValue(ConstStrings.TestFrameworkRegistryPath, ConstStrings.TestFrameworkRegistryKey, null);

            this.solutionEvents = ((Events2)this.dte.Events).SolutionEvents;
            this.solutionEvents.ProjectAdded += this.SolutionEvents_ProjectAdded;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Last Edit by EC on 2017-10-03
        /// The on after open project.
        /// </summary>
        /// <param name="hierarchy">
        /// The hierarchy.
        /// </param>
        /// <param name="added">
        /// The added.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        public override int OnAfterOpenProject(IVsHierarchy hierarchy, int added)
        {
            base.OnAfterOpenProject(hierarchy, added);

            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (hierarchy == null)
            {
                return VSConstants.E_INVALIDARG;
            }

            var objProj = GetDteProject(hierarchy);

            if (objProj.Object == null)
            {
                return VSConstants.S_OK;
            }

            var project = this.ehProjectList.CreateEHProject(objProj);

            // Userdefined Test Projekt als reference zum DTTP hinzufügen
            if (project.IsProjectType(ProjectTypeGuids.CSharp))
            {
                var testProjectList = this.ehProjectList.GetEHProjects(ProjectTypeGuids.DTTestProject);

                foreach (var testProject in testProjectList)
                {
                    // Userdefined Project als Referenz zum DTMStudioTestProject hinzufügen
                    this.AddProjectReference(testProject.Project, project.Project);

                    // EH.PCPS.TestAutomation.Common Assembly zum User defined Project hinzufügen
                    this.AddTestFrameworkAssemblyReferenceToUserDefinedProject(project);
                }
            }

            if (project.IsProjectType(ProjectTypeGuids.DTTestProject))
            {
                // 2017-09-27 - EC: Update Project File for compatibility isues
                this.UpdateProject(project);    

                // DTMStudioTestProject als StartupProject setzen 
                this.SetStatupProject(this.dte, project.Project.Name);

                var dtProjectList = this.ehProjectList.GetEHProjects(ProjectTypeGuids.DTProject);

                if (dtProjectList.Count == 1)
                {
                    dtProjectList[0].DeviceFunctions = this.GetDeviceFunctionsFromDeviceTypeProject(dtProjectList[0].ProjectFile);
                    project.DeviceFunctions = dtProjectList[0].DeviceFunctions;
                }
                
                var filePath = Path.Combine(this.testFrameworkRegistryKey, FrameworkHelper.TestFrameworkAssemblyFile);
                project.FullAssemblyPath = filePath;
            }

            if (!this.ehProjectList.ProjectExist(project))
            {
                this.ehProjectList.Add(project);
            }

            // Save und Build Events hinzufügen
            this.AddSolutionEvents(this.dte);

            // Solution builden
            // this.BuildSolution(dte);
            return VSConstants.S_OK;
        }

        /// <summary>
        /// The on before close project.
        /// </summary>
        /// <param name="hierarchy">
        /// The hierarchy.
        /// </param>
        /// <param name="removed">
        /// The removed.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int OnBeforeCloseProject(IVsHierarchy hierarchy, int removed)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (hierarchy == null)
            {
                return VSConstants.E_INVALIDARG;
            }

            var objProj = GetDteProject(hierarchy);

            if (objProj.Object == null)
            {
                return VSConstants.S_OK;
            }

            this.ehProjectList.RemoveProject(objProj);

            return VSConstants.S_OK;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get DTE project.
        /// </summary>
        /// <param name="hierarchy">
        /// The hierarchy.
        /// </param>
        /// <returns>
        /// The <see cref="Project"/>.
        /// </returns>
        private static Project GetDteProject(IVsHierarchy hierarchy)
        {
            Log.Enter(MethodBase.GetCurrentMethod().Name);

            if (hierarchy == null)
            {
                throw new ArgumentNullException("hierarchy");
            }

            object obj;
            hierarchy.GetProperty(VSConstants.VSITEMID_ROOT, (int)__VSHPROPID.VSHPROPID_ExtObject, out obj);
            return obj as Project;
        }

        /// <summary>
        /// The add assembly reference.
        /// </summary>
        /// <param name="userDefinedProject">
        /// The user defined project.
        /// </param>
        private void AddTestFrameworkAssemblyReferenceToUserDefinedProject(EHProject userDefinedProject)
        {
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.Common", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.Common.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.CommonCommunicationLayerLoader", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.CommonCommunicationLayerLoader.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.CommunicationInterfaces", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.CommunicationInterfaces.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.CommunicationLoader", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.CommunicationLoader.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.DeviceFunctionInterfaces", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.DeviceFunctionInterfaces.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.DeviceFunctionLoader", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.DeviceFunctionLoader.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.HostApplicationInterfaces", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.HostApplicationInterfaces.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.HostApplicationLoader", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.HostApplicationLoader.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.OperatingSystemInterfaces", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.OperatingSystemInterfaces.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.OperatingSystemLoader", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.OperatingSystemLoader.dll"));
            this.AddAssemblyReference(userDefinedProject.Project, "EH.PCPS.TestAutomation.Testlibrary", Path.Combine(this.testFrameworkRegistryKey, "EH.PCPS.TestAutomation.Testlibrary.dll"));
        }

        /// <summary>
        /// The add assembly reference.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <param name="assemblyName">
        /// The name.
        /// </param>
        /// <param name="assemblyPath">
        /// The hint path.
        /// </param>
        private void AddAssemblyReference(Project project, string assemblyName, string assemblyPath)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var userProject = project.Object as VSProject;

            if (userProject != null && assemblyName != string.Empty && File.Exists(assemblyPath))
            {
                var testProject = userProject;

                var projectRef = testProject.References.Find(assemblyName);

                if (projectRef != null)
                {
                    if (projectRef.Path != assemblyPath)
                    {
                        projectRef.Remove();
                        testProject.References.Add(assemblyPath);
                    }
                }
                else
                {
                    testProject.References.Add(assemblyPath);
                }
            }
        }

        /// <summary>
        /// The add project reference.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <param name="refProject">
        /// The ref project.
        /// </param>
        private void AddProjectReference(Project project, Project refProject)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (project != null && refProject != null)
            {
                // wenn DeviceTypeTestProject
                if (project.Object is DTTestProjectNode)
                {
                    var testProject = ((DTTestProjectNode)project.Object).VSProject;

                    if (testProject.References.Find(refProject.Name) == null)
                    {
                        testProject.References.AddProject(refProject);
                    }
                }
                else if (project.Object is VSProject)
                {
                    // wenn CS Project (Userdefined Project)
                    //// bei einem CS Project 
                    var testProject = (VSProject)project.Object;

                    if (testProject.References.Find(refProject.UniqueName) == null)
                    {
                        testProject.References.AddProject(refProject);
                    }
                }
            }
        }

        /// <summary>
        /// The add solution events.
        /// </summary>
        /// <param name="developerEnvironment">
        /// The dte.
        /// </param>
        private void AddSolutionEvents(DTE developerEnvironment)
        {
            // Document open event
            this.documentEvents = developerEnvironment.Events.DocumentEvents;
            this.buildEvents = developerEnvironment.Events.BuildEvents;

            this.solutionItemsEvents = developerEnvironment.Events.SolutionItemsEvents;

            // add event to field so that GC does not remove it
            this.documentEvents.DocumentSaved += this.OnDocumentSaved;

            // Build done event
            this.buildEvents.OnBuildDone += this.OnBuildDone;
        }

        /// <summary>
        /// The build solution.
        /// </summary>
        /// <param name="developerEnvironment">
        /// The dte.
        /// </param>
        private void BuildSolution(DTE developerEnvironment)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            // Get an instance of the SolutionBuild
            var build = developerEnvironment.Solution.SolutionBuild as SolutionBuild2;

            if (build != null)
            {
                build.Build(true);
            }
        }

        /// <summary>
        /// The get device functions.
        /// </summary>
        /// <param name="projectFile">
        /// The project file.
        /// </param>
        /// <returns>
        /// The <see cref="DeviceFunction"/>.
        /// </returns>
        private List<DeviceFunction> GetDeviceFunctionsFromDeviceTypeProject(string projectFile)
        {
            var dtmStudioTestData = new DTMstudioTestData(projectFile, this.testFrameworkRegistryKey);

            var dtmStudioDataManager = new EH.DTMstudioTest.Common.Manager.DtmStudioDataManager();
            dtmStudioTestData = dtmStudioDataManager.GetDeviceTypeProjectData(projectFile, dtmStudioTestData);

            return dtmStudioTestData.DeviceTypeProject.DeviceFunctions;
        }

        /// <summary>
        /// The load assembly in script explorer.
        /// </summary>
        /// <param name="assemblyPath">
        /// The assembly path.
        /// </param>
        private void LoadAssemblyInScriptExplorer(string assemblyPath)
        {
            var window = ((DTMstudioTestPackage)this.ServiceProvider).FindToolWindow(typeof(EHScriptExplorerWindow), 0, true) as EHScriptExplorerWindow;

            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("CanNotCreateWindow"); // Resources.CanNotCreateWindow
            }

            window.LoadAssembly(assemblyPath);

            var windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        /// <summary>
        /// The load control document in script configurator.
        /// </summary>
        /// <param name="rootFolder">
        /// The root folder.
        /// </param>
        /// <param name="deviceTypeTestProjectPath">
        /// The device type test project path.
        /// </param>
        /// <param name="testLibraryPath">
        /// The test library path.
        /// </param>
        /// <param name="deviceFunctions">
        /// The device Functions.
        /// </param>
        private void LoadControlDocumentInScriptConfigurator(string rootFolder, string deviceTypeTestProjectPath, string testLibraryPath, List<DeviceFunction> deviceFunctions)
        {
            var window = ((DTMstudioTestPackage)this.ServiceProvider).FindToolWindow(typeof(EHScriptConfiguratorWindow), 0, true) as EHScriptConfiguratorWindow;

            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("CanNotCreateWindow"); // Resources.CanNotCreateWindow
            }

            window.LoadControlDocument(rootFolder, deviceTypeTestProjectPath, testLibraryPath, deviceFunctions);

            var windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        /// <summary>
        /// The load control document in suite configurator.
        /// </summary>
        /// <param name="defaultRootTestSuite">
        /// The root folder.
        /// </param>
        /// <param name="userDefinedProjectPath">
        /// The user defined project path.
        /// </param>
        private void LoadControlDocumentInSuiteConfigurator(string defaultRootTestSuite, string userDefinedProjectPath)
        {
            var window = ((DTMstudioTestPackage)this.ServiceProvider).FindToolWindow(typeof(EHSuiteConfiguratorWindow), 0, true) as EHSuiteConfiguratorWindow;

            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("CanNotCreateWindow"); // Resources.CanNotCreateWindow
            }

            window.LoadControlDocument(defaultRootTestSuite, userDefinedProjectPath);

            var windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        /// <summary>
        /// The load eh user controls.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        private void LoadEhUserControls(EHProject project)
        {
            if (project.IsProjectType(ProjectTypeGuids.DTTestProject))
            {
                var controlDocumentPath = project.ControlDocumentPath;

                if (!string.IsNullOrEmpty(controlDocumentPath))
                {
                    this.LoadControlDocumentInScriptConfigurator(project.Project.Name, controlDocumentPath, project.FullAssemblyPath, project.DeviceFunctions);
                }

                if (File.Exists(project.FullAssemblyPath))
                {
                    this.LoadAssemblyInScriptExplorer(project.FullAssemblyPath);
                }
            }
            else if (project.IsProjectType(ProjectTypeGuids.CSharp))
            {
                if (File.Exists(project.FullAssemblyPath))
                {
                    this.LoadAssemblyInScriptExplorer(project.FullAssemblyPath);
                }

                if (!string.IsNullOrEmpty(project.FullAssemblyPath))
                {
                    this.LoadControlDocumentInSuiteConfigurator(project.Project.Name, project.FullAssemblyPath);
                }
            }
        }

        /// <summary>
        /// The get vsix installation folder.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetVsixInstallationFolder()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            string path = DTMstudioTestPackage.GetAssemblyLocalPathFrom();
            Log.Info(this, string.Format("VSIX installation folder: {0}", path));
            return path;
        }
        
        /// <summary>
        /// The build events on on build done.
        /// </summary>
        /// <param name="scope">
        /// The scope.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        private void OnBuildDone(vsBuildScope scope, vsBuildAction action)
        {
            try
            {
                if (this.dte != null)
                {
                    if (this.dte.Solution == null)
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
                
                // if ((null == this.dte) && (null == this.dte.Solution))
                // {
                //    return;
                // }
            }
            catch (Exception)
            {
                return;
            }

            foreach (var project in this.dte.Solution.Projects)
            {
                this.ehProjectList.UpdateProject(project as Project);
            }
        }

        /// <summary>
        /// The doc event on document saved.
        /// </summary>
        /// <param name="document">
        /// The document.
        /// </param>
        private void OnDocumentSaved(Document document)
        {
            var refAssemblies = new List<string>();

            if ((document.ProjectItem != null) && (document.ProjectItem.ContainingProject != null) && (document.ProjectItem.ContainingProject.Object != null))
            {
                var project = document.ProjectItem.ContainingProject.Object as VSProject;

                if (project != null)
                {
                    foreach (Reference reference in project.References)
                    {
                        refAssemblies.Add(Path.GetFileName(reference.Path));
                    }
                }

                var combineAssemblyName = new string[3];

                combineAssemblyName[0] = document.ProjectItem.ContainingProject.Properties.Item("FullPath").Value.ToString();
                combineAssemblyName[1] = document.ProjectItem.ContainingProject.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value.ToString();
                combineAssemblyName[2] = document.ProjectItem.ContainingProject.Properties.Item("OutputFileName").Value.ToString();

                var assemblyName = Path.Combine(combineAssemblyName);
                var tempAssemblyName = AssemblyManager.GetAssemblyTempFile(assemblyName, document.Name);

                AssemblyHelper.CompileAssembly(new[] { document.FullName }, refAssemblies, tempAssemblyName);

                this.LoadAssemblyInScriptExplorer(tempAssemblyName);
            }
        }

        /// <summary>
        /// The on project list collection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnProjectListCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (e.NewItems != null)
                {
                    foreach (var item in e.NewItems)
                    {
                        this.LoadEhUserControls(item as EHProject);
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                if (e.OldItems != null)
                {
                    foreach (var item in e.OldItems)
                    {
                        this.UnloadEhUserControls(item as EHProject);
                    }
                }
            }
        }

        /// <summary>
        /// The on project property changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnProjectPropertyChanged(object sender, ProjectChangedEventArgs e)
        {
            if (e.PropertyName == "Project")
            {
                this.LoadEhUserControls(e.Project);
            }
        }

        /// <summary>
        /// The set Stat Up project.
        /// </summary>
        /// <param name="developmentEnvironment">
        /// The development environment .
        /// </param>
        /// <param name="startupProject">
        /// The Startup project.
        /// </param>
        private void SetStatupProject(_DTE developmentEnvironment, string startupProject)
        {
            developmentEnvironment.Solution.Properties.Item("StartupProject").Value = startupProject;
        }

        /// <summary>
        /// The load control document in script explorer.
        /// </summary>
        /// <param name="assemblyPath">
        /// The assembly path.
        /// </param>
        private void UnloadAssemblyInScriptExplorer(string assemblyPath)
        {
            var window = ((DTMstudioTestPackage)this.ServiceProvider).FindToolWindow(typeof(EHScriptExplorerWindow), 0, true) as EHScriptExplorerWindow;

            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("CanNotCreateWindow"); // Resources.CanNotCreateWindow
            }

            window.UnloadAssembly(assemblyPath);

            var windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        /// <summary>
        /// The unload control document in script configurator.
        /// </summary>
        private void UnloadControlDocumentInScriptConfigurator()
        {
            var window = ((DTMstudioTestPackage)this.ServiceProvider).FindToolWindow(typeof(EHScriptConfiguratorWindow), 0, true) as EHScriptConfiguratorWindow;

            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("CanNotCreateWindow"); // Resources.CanNotCreateWindow
            }

            window.UnloadControlDocument();

            var windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        /// <summary>
        /// The unload control document in suite configurator.
        /// </summary>
        private void UnloadControlDocumentInSuiteConfigurator()
        {
            var window = ((DTMstudioTestPackage)this.ServiceProvider).FindToolWindow(typeof(EHSuiteConfiguratorWindow), 0, true) as EHSuiteConfiguratorWindow;

            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("CanNotCreateWindow"); // Resources.CanNotCreateWindow
            }

            window.UnloadControlDocument();

            var windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        /// <summary>
        /// The unload eh user controls.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        private void UnloadEhUserControls(EHProject project)
        {
            if (project.IsProjectType(ProjectTypeGuids.DTTestProject))
            {
                this.UnloadControlDocumentInScriptConfigurator();
                this.UnloadAssemblyInScriptExplorer(project.FullAssemblyPath);
            }
            else if (project.IsProjectType(ProjectTypeGuids.CSharp))
            {
                this.UnloadControlDocumentInSuiteConfigurator();
                this.UnloadAssemblyInScriptExplorer(project.FullAssemblyPath);
            }
        }

        /// <summary>
        /// The solution events_ project added.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        private void SolutionEvents_ProjectAdded(Project project)
        {
            // Log.Enter(MethodBase.GetCurrentMethod().Name);

            // //EnvDTE.Project project;

            // //project = _applicationObject.Solution.Projects.Item(1);

            // ShowPlatforms(project);

            // AddProjectPlatform(project, "x86", "Any CPU", false);

            // ShowPlatforms(project);

            // DeleteProjectPlatform(project, "x86");

            // AddProjectPlatform(project, "x64", "Any CPU", true);

            // ShowPlatforms(project);
        }

        /// <summary>
        /// The add project platform.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <param name="newPlatformName">
        /// The new platform name.
        /// </param>
        /// <param name="existingPlatformName">
        /// The existing platform name.
        /// </param>
        /// <param name="propagateToSolution">
        /// The propagate to solution.
        /// </param>
        private void AddProjectPlatform(EnvDTE.Project project, string newPlatformName, string existingPlatformName, bool propagateToSolution)
        {
            project.ConfigurationManager.AddPlatform(newPlatformName, existingPlatformName, propagateToSolution);
        }

        /// <summary>
        /// The delete project platform.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <param name="platformName">
        /// The platform name.
        /// </param>
        private void DeleteProjectPlatform(Project project, string platformName)
        {
            project.ConfigurationManager.DeletePlatform(platformName);
        }

        /// <summary>
        /// The show platforms.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        private void ShowPlatforms(Project project)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            SolutionBuild2 solutionBuild2;
            List<string> usedNames = new List<string>();
            string solutionPlatformName;

            solutionBuild2 = (SolutionBuild2)this.dte.Solution.SolutionBuild;

            // Solution platform names
            sb.AppendLine();
            sb.AppendLine("-----------------------------------------------");
            sb.AppendLine("Solution platform names:");
            sb.AppendLine();
            usedNames.Clear();

            foreach (SolutionConfiguration2 solutionConfiguration2 in solutionBuild2.SolutionConfigurations)
            {
                solutionPlatformName = solutionConfiguration2.PlatformName;

                if (!usedNames.Contains(solutionPlatformName))
                {
                    usedNames.Add(solutionPlatformName);
                    sb.AppendLine("   - " + solutionPlatformName);
                }
            }

            // Project platform names
            sb.AppendLine();
            sb.AppendLine("-----------------------------------------------");
            sb.AppendLine("Project platform names:");
            sb.AppendLine();

            foreach (object projectPlatformName in (object[])project.ConfigurationManager.PlatformNames)
            {
                sb.AppendLine("   - " + projectPlatformName);
            }

            MessageBox.Show(sb.ToString());
        }

        /// <summary>
        /// Last Edit by EC on 2017-09-29
        /// The update project file: 
        /// - get the path to the current project 
        /// - get the path to the template files
        /// - unzips the template file into c:\temp
        /// - update Project File
        /// - update Control Document
        /// - update Program.cs
        /// - update Report Template Files
        /// - removes template file from c:\temp
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        private void UpdateProject(EHProject project)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (project == null)
            {
                Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + "One of the parameters is either null or empty");
                return;
            }

            string pathToPluginTemplate = this.GetVsixInstallationFolder() + DTMstudioTest.Plugin.Resources.PathToPluginTemplate;

            string tempPath = Path.GetTempPath();
            string directoryPath = tempPath + "cic_template";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            try
            {
                ZipHandler.Unzip(pathToPluginTemplate, directoryPath);
            }
            catch (Exception exception)
            {
                System.Windows.Forms.MessageBox.Show(exception.Message);
                throw;
            }
            
            string projectFolder = project.ControlDocumentPath.Replace("\\ControlDocument.xml", string.Empty);
            string projectTemplateFolder = directoryPath;

            string projectFile = project.ProjectFile;
            string projectTemplateFile = projectTemplateFolder + "\\ProjectTemplate.testproj";

            Log.Info(this, string.Format(MethodBase.GetCurrentMethod().Name + " - " + "pathToPluginTemplate: {0}", pathToPluginTemplate));
            Log.Info(this, string.Format(MethodBase.GetCurrentMethod().Name + " - " + "tempPath: {0}", tempPath));
            Log.Info(this, string.Format(MethodBase.GetCurrentMethod().Name + " - " + "directoryPath: {0}", directoryPath));
            Log.Info(this, string.Format(MethodBase.GetCurrentMethod().Name + " - " + "projectFolder: {0}", projectFolder));
            Log.Info(this, string.Format(MethodBase.GetCurrentMethod().Name + " - " + "projectTemplateFolder: {0}", projectTemplateFolder));
            Log.Info(this, string.Format(MethodBase.GetCurrentMethod().Name + " - " + "projectFile: {0}", projectFile));
            Log.Info(this, string.Format(MethodBase.GetCurrentMethod().Name + " - " + "projectTemplateFile: {0}", projectTemplateFile));

            // 2017-10-03 - EC: Check if update is neccessary by different project-version
            if (this.IsUpdateNeccessary(projectFile, projectTemplateFile))
            {
                this.UpdateControlDocument(projectFolder, project);
                this.UpdateProgramCs(projectFolder, projectTemplateFolder, project);
                this.UpdateReportTemplateFiles(projectFolder + "\\Report", projectTemplateFolder);
                this.UpdateDllTemplateFiles(projectFolder + "\\Dlls", projectTemplateFolder);
                this.UpdateRanorexAndTemplateVersion(projectFile, projectTemplateFile);
            }

            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
            else
            {
                MessageBox.Show(string.Format("Could not delete Directory {0}", directoryPath));
            }
        }

        /// <summary>
        /// Last Edit by EC on 2017-10-03
        /// The update ranorex version.
        /// </summary>
        /// <param name="projectFile">
        /// The project file.
        /// </param>
        /// <param name="projectTemplateFile">
        /// The project template file.
        /// </param>
        private void UpdateRanorexAndTemplateVersion(string projectFile, string projectTemplateFile)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (string.IsNullOrEmpty(projectFile) || string.IsNullOrEmpty(projectTemplateFile))
            {
                Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + "One of the parameters is either null or empty");
                return;
            }

            const string Namespace = "http://schemas.microsoft.com/developer/msbuild/2003";
            const string NamespaceName = "x";
            const string ReferenceToRanorex = "//x:Reference[starts-with(@Include, 'Ranorex')]";
            const string TemplateVersion = "//x:TemplateVersion";

            XmlDocument xmlProjectFile = new XmlDocument();
            xmlProjectFile.Load(projectFile);
            XmlNode rootOrigin = xmlProjectFile.DocumentElement;
            
            XmlDocument xmlProjectTemplateFile = new XmlDocument();
            xmlProjectTemplateFile.Load(projectTemplateFile);
            XmlNode rootTemplate = xmlProjectTemplateFile.DocumentElement;

            XmlNamespaceManager mgrTemplate = new XmlNamespaceManager(xmlProjectTemplateFile.NameTable);
            mgrTemplate.AddNamespace(NamespaceName, Namespace);

            XmlNamespaceManager mgrOrigin = new XmlNamespaceManager(xmlProjectFile.NameTable);
            mgrOrigin.AddNamespace(NamespaceName, Namespace);

            XmlNode node;

            if (rootTemplate != null && rootOrigin != null)
            {
                try
                {
                    node = rootTemplate.SelectSingleNode(ReferenceToRanorex, mgrTemplate);
                    if (node != null)
                    {
                        if (node.Attributes != null)
                        {
                            string includeValue = node.Attributes[0].InnerText;

                            node = rootOrigin.SelectSingleNode(ReferenceToRanorex, mgrOrigin);
                            if (node != null)
                            {
                                if (node.Attributes != null)
                                {
                                    if (!node.Attributes[0].Value.Equals(includeValue))
                                    {
                                        node.Attributes[0].Value = includeValue;
                                        xmlProjectFile.Save(projectFile);
                                    }
                                }
                            }
                        }
                    }

                    // Template version update
                    node = rootTemplate.SelectSingleNode(TemplateVersion, mgrTemplate);
                    if (node != null)
                    {
                        if (node.InnerText != string.Empty)
                        {
                            string templateValue = node.InnerText;

                            node = rootOrigin.SelectSingleNode(TemplateVersion, mgrOrigin);
                            if (node != null)
                            {
                                if (node.InnerText != string.Empty)
                                {
                                    if (!node.InnerText.Equals(templateValue))
                                    {
                                        node.InnerText = templateValue;
                                        xmlProjectFile.Save(projectFile);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + exception.Message);
                }
            }
        }

        /// <summary>
        /// Last Edit by EC on 2017-09-29
        /// The update control document.
        /// </summary>
        /// <param name="projectFolder">
        /// The project Folder.
        /// </param>
        /// <param name="project">
        /// The project.
        /// </param>
        private void UpdateControlDocument(string projectFolder, EHProject project)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            
            if (string.IsNullOrEmpty(projectFolder) || project == null)
            {
                Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + "One of the parameters is either null or empty");
                return;
            }

            // Get path from project
            // Open ControlDocument.xml
            // Search element <ConfigurationFile>
            // Replace value of element <ConfigurationFile> by path from project
            const string ControlDocumentFile = "\\ControlDocument.xml";
            const string ConfigurationFile = "//ConfigurationFile";
            
            XmlDocument controlDocumentXml = new XmlDocument();
            string controlDocumentPathAndFile = projectFolder + ControlDocumentFile;
            try
            {
                controlDocumentXml.Load(controlDocumentPathAndFile);
                XmlNode root = controlDocumentXml.DocumentElement;
                if (root != null)
                {
                    XmlNode node = root.SelectSingleNode(ConfigurationFile);
                    if (node != null)
                    {
                        node.InnerText = controlDocumentPathAndFile;
                        
                        controlDocumentXml.Save(controlDocumentPathAndFile);
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + exception.Message);
                throw;
            }
        }

        /// <summary>
        /// Last Edit by EC on 2017-09-29
        /// The update program file.
        /// </summary>
        /// <param name="projectFolder">
        /// The project Folder.
        /// </param>
        /// <param name="projectTemplateFolder">
        /// The project Template Folder.
        /// </param>
        /// <param name="project">
        /// The project.
        /// </param>
        private void UpdateProgramCs(string projectFolder, string projectTemplateFolder, EHProject project)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (string.IsNullOrEmpty(projectFolder) || string.IsNullOrEmpty(projectTemplateFolder) || project == null)
            {
                Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + "One of the parameters is either null or empty");
                return;
            }

            // Get template file content
            // Replace placeholder $safeprojectname$ by project name
            // Replace placeholder $safeitemname$ by class file name
            // Write content into project program.cs
            const string FileName = "Program.cs";
            const string SafeProjectName = "$safeprojectname$";
            const string SafeItemName = "$safeitemname$";

            string sourceFile = projectTemplateFolder + "\\" + FileName;
            string destinationFile = projectFolder + "\\" + FileName;

            if (Directory.Exists(projectTemplateFolder))
            {
                string sourceContent = File.ReadAllText(sourceFile);
                string projectName = project.Project.Name;
                sourceContent = sourceContent.Replace(SafeProjectName, projectName);
                sourceContent = sourceContent.Replace(SafeItemName, FileName.Replace(".cs", string.Empty));

                if (Directory.Exists(projectFolder))
                {
                    File.WriteAllText(destinationFile, sourceContent);    
                }
            }
        }

        /// <summary>
        /// Last Edit by EC on 2017-09-29
        /// The update report template files.
        /// </summary>
        /// <param name="projectFolder">
        /// The project Folder.
        /// </param>
        /// <param name="projectTemplateFolder">
        /// The project Template Folder.
        /// </param>
        private void UpdateReportTemplateFiles(string projectFolder, string projectTemplateFolder)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (string.IsNullOrEmpty(projectFolder) || string.IsNullOrEmpty(projectTemplateFolder))
            {
                Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + "One of the parameters is either null or empty");
                return;
            }

            // Replace files in Report Folder by files from template
            // EHReportDetails.css
            // EHReportDetails.png
            // EHReportDetails.xsl
            // EHReportOverview.css
            // EHReportOverview.png
            // EHReportOverview.xsl
            const string File1 = "\\EHReportDetails.css";
            const string File2 = "\\EHReportDetails.png";
            const string File3 = "\\EHReportDetails.xsl";
            const string File4 = "\\EHReportOverview.css";
            const string File5 = "\\EHReportOverview.png";
            const string File6 = "\\EHReportOverview.xsl";

            this.ReplaceFile(projectFolder, projectTemplateFolder, File1);
            this.ReplaceFile(projectFolder, projectTemplateFolder, File2);
            this.ReplaceFile(projectFolder, projectTemplateFolder, File3);
            this.ReplaceFile(projectFolder, projectTemplateFolder, File4);
            this.ReplaceFile(projectFolder, projectTemplateFolder, File5);
            this.ReplaceFile(projectFolder, projectTemplateFolder, File6);
        }

        /// <summary>
        /// Last Edit by EC on 2017-09-29
        /// The update dll template files.
        /// </summary>
        /// <param name="projectFolder">
        /// The project folder.
        /// </param>
        /// <param name="projectTemplateFolder">
        /// The project template folder.
        /// </param>
        private void UpdateDllTemplateFiles(string projectFolder, string projectTemplateFolder)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (string.IsNullOrEmpty(projectFolder) || string.IsNullOrEmpty(projectTemplateFolder))
            {
                Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + "One of the parameters is either null or empty");
                return;
            }

            // Replace files in Report Folder by files from template
            // DeviceTypeProjectTempSchema.xsd
            // DtmStudioCoDIACommonTaskInfrastructure.dll
            // DtmStudioCoDIACommonTaskInfrastructure.xml
            // DTMstudioInfrastructure.dll
            // EH.DTMstudioTest.Common.dll
            // EH.DTMstudioTest.TestScriptEngine.dll
            // Log4net.dll
            const string File1 = "\\DeviceTypeProjectTempSchema.xsd";
            const string File2 = "\\DtmStudioCoDIACommonTaskInfrastructure.dll";
            const string File3 = "\\DtmStudioCoDIACommonTaskInfrastructure.xml";
            const string File4 = "\\DTMstudioInfrastructure.dll";
            const string File5 = "\\EH.DTMstudioTest.Common.dll";
            const string File6 = "\\EH.DTMstudioTest.TestScriptEngine.dll";
            const string File7 = "\\Log4net.dll";

            this.ReplaceFile(projectFolder, projectTemplateFolder, File1);
            this.ReplaceFile(projectFolder, projectTemplateFolder, File2);
            this.ReplaceFile(projectFolder, projectTemplateFolder, File3);
            this.ReplaceFile(projectFolder, projectTemplateFolder, File4);
            this.ReplaceFile(projectFolder, projectTemplateFolder, File5);
            this.ReplaceFile(projectFolder, projectTemplateFolder, File6);
            this.ReplaceFile(projectFolder, projectTemplateFolder, File7);
        }

        /// <summary>
        /// Last Edit by EC on 2017-09-29
        /// The replace file.
        /// </summary>
        /// <param name="destination">
        /// The destination.
        /// </param>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        private void ReplaceFile(string destination, string source, string fileName)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (string.IsNullOrEmpty(destination) || string.IsNullOrEmpty(source) || string.IsNullOrEmpty(fileName))
            {
                Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + "One of the parameters is either null or empty");
                return;
            }

            string sourceFile = source + fileName;
            string destinationFile = destination + fileName;

            if (File.Exists(sourceFile) && Directory.Exists(destination))
            {
                try
                {
                    File.Copy(sourceFile, destinationFile, true);
                }
                catch (Exception exception)
                {
                    Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + exception.Message);
                }
            }
        }

        /// <summary>
        /// Last Edit by EC on 2017-10-03
        /// The is update neccessary.
        /// </summary>
        /// <param name="projectFile">
        /// The project File.
        /// </param>
        /// <param name="projectTemplateFile">
        /// The project Template File.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsUpdateNeccessary(string projectFile, string projectTemplateFile)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (string.IsNullOrEmpty(projectFile) || string.IsNullOrEmpty(projectTemplateFile))
            {
                Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + "One of the parameters is either null or empty");
                return false;
            }

            const string Namespace = "http://schemas.microsoft.com/developer/msbuild/2003";
            const string NamespaceName = "x";
            const string TemplateVersion = "//x:TemplateVersion";

            XmlDocument xmlProjectFile;
            XmlDocument xmlProjectTemplateFile;

            xmlProjectFile = new XmlDocument();
            xmlProjectFile.Load(projectFile);
            XmlNode rootNew = xmlProjectFile.DocumentElement;

            xmlProjectTemplateFile = new XmlDocument();
            xmlProjectTemplateFile.Load(projectTemplateFile);
            XmlNode rootTemplate = xmlProjectTemplateFile.DocumentElement;

            XmlNamespaceManager mgrTemplate = new XmlNamespaceManager(xmlProjectTemplateFile.NameTable);
            mgrTemplate.AddNamespace(NamespaceName, Namespace);

            XmlNamespaceManager mgrOrigin = new XmlNamespaceManager(xmlProjectFile.NameTable);
            mgrOrigin.AddNamespace(NamespaceName, Namespace);

            XmlNode node;

            if (rootTemplate != null && rootNew != null)
            {
                try
                {
                    node = rootTemplate.SelectSingleNode(TemplateVersion, mgrTemplate);
                    if (node != null)
                    {
                        if (node.InnerText != string.Empty)
                        {
                            string templateVersion = node.InnerText;

                            node = rootNew.SelectSingleNode(TemplateVersion, mgrOrigin);
                            if (node != null)
                            {
                                if (node.InnerText != string.Empty)
                                {
                                    string currentlyCreatedVersion = node.InnerText;
                                    if (currentlyCreatedVersion.Equals(templateVersion))
                                    {
                                        return false;
                                    }
                                }    
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Log.Error(this, MethodBase.GetCurrentMethod().Name + " - " + exception.Message);
                }
            }

            return true;
        }

        #endregion
    }
}