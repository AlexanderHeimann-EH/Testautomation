// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DTTestProjectNode.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class DTTestProjectNode.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using EH.DTMstudioTest.Common.Manager;
    using EH.DTMstudioTest.Common.Tools;
    using EH.DTMstudioTest.Common.Utilities.Logging;

    using EnvDTE;

    using Microsoft.Build.Execution;
    using Microsoft.VisualStudio.Project;
    using Microsoft.VisualStudio.Project.Automation;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.Win32;

    using VSLangProj;

    using ProjectItem = Microsoft.Build.Evaluation.ProjectItem;
    using ToolBox = EH.DTMstudioTest.Common.Tools.ToolBox;

    #endregion

    /// <summary>
    /// Class DTTestProjectNode.
    /// </summary>
    [ComVisible(true)]
    [CLSCompliant(false)]
    public class DTTestProjectNode : ProjectNode
    {
        #region Static Fields

        /// <summary>
        /// The image list
        /// </summary>
        private static readonly ImageList ImageList;

        /// <summary>
        /// The image index
        /// </summary>
        private static int imageIndex;

        #endregion

        #region Fields

        /// <summary>
        /// The package
        /// </summary>
        public DTMstudioTestPackage package;

        /// <summary>
        /// The vs project.
        /// </summary>
        private VSProject vsProject = null;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="DTTestProjectNode"/> class.
        /// </summary>
        static DTTestProjectNode()
        {
            ImageList = Utilities.GetImageList(typeof(DTTestProjectNode).Assembly.GetManifestResourceStream("EH.DTMstudioTest.Plugin.Resources.DTTestProjectNode.png"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DTTestProjectNode"/> class.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        public DTTestProjectNode(DTMstudioTestPackage package)
        {
            this.package = package;

            imageIndex = this.ImageHandler.ImageList.Images.Count;

            foreach (Image img in ImageList.Images)
            {
                this.ImageHandler.AddImage(img);
            }
        }

        #endregion

        #region Enums

        /// <summary>
        /// The vs 2010 before building.
        /// </summary>
        private enum vs2010BeforeBuilding
        {
            /// <summary>
            /// The save all changes
            /// </summary>
            SaveAllChanges, 

            /// <summary>
            /// The prompt save all changes
            /// </summary>
            PromptSaveAllChanges, 

            /// <summary>
            /// The do not save any changes
            /// </summary>
            DoNotSaveAnyChanges, 

            /// <summary>
            /// The prompt save changes open documents only
            /// </summary>
            PromptSaveChangesOpenDocumentsOnly
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the eh data manager.
        /// </summary>
        /// <value>The eh data manager.</value>
        public EhDataManager EHDataManager { get; set; }

        /// <summary>
        /// Return an imageindex
        /// </summary>
        /// <value>The index of the image.</value>
        public override int ImageIndex
        {
            get
            {
                return imageIndex;
            }
        }

        /// <summary>
        /// Gets the project unique identifier.
        /// </summary>
        /// <value>The project unique identifier.</value>
        public override Guid ProjectGuid
        {
            get
            {
                return GuidList.guidDTTestProjectFactory;
            }
        }

        /// <summary>
        /// Gets the type of the project.
        /// </summary>
        /// <value>The type of the project.</value>
        public override string ProjectType
        {
            get
            {
                return "DTTestProjectType";
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the VSProject corresponding to this project
        /// </summary>
        protected internal VSProject VSProject
        {
            get
            {
                if (this.vsProject == null)
                {
                    this.vsProject = new OAVSProject(this);
                }

                return this.vsProject;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The find bytes.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="find">
        /// The find.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int FindBytes(byte[] source, byte[] find)
        {
            var index = -1;
            var matchIndex = 0;

            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] == find[matchIndex])
                {
                    if (matchIndex == (find.Length - 1))
                    {
                        index = i - matchIndex;
                        break;
                    }

                    matchIndex++;
                }
                else
                {
                    matchIndex = 0;
                }
            }

            return index;
        }

        /// <summary>
        /// The replace bytes.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="search">
        /// The search.
        /// </param>
        /// <param name="replace">
        /// The replace.
        /// </param>
        /// <returns>
        /// The <see cref="byte"/>.
        /// </returns>
        public static byte[] ReplaceBytes(byte[] source, byte[] search, byte[] replace)
        {
            byte[] dst = null;
            var index = FindBytes(source, search);
            if (index >= 0)
            {
                dst = new byte[source.Length - search.Length + replace.Length];

                // before found array
                Buffer.BlockCopy(source, 0, dst, 0, index);

                // repl copy
                Buffer.BlockCopy(replace, 0, dst, index, replace.Length);

                // rest of src array
                Buffer.BlockCopy(source, index + search.Length, dst, index + replace.Length, source.Length - (index + search.Length));
            }

            return dst;
        }

        /// <summary>
        /// Adds the file from template.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        public override void AddFileFromTemplate(string source, string target)
        {
            Logger.Enter(this, this.ProjectFile, string.Format("AddFileFromTemplate - Source: {0} Target: {1}", source, target));

            if (!this.IsCodeFile(source))
            {
                this.UntokenBinaryFile(source, target);
            }
            else
            {
                // var nameSpace = this.GetRootNamespace(this.FileTemplateProcessor.GetFileNamespace(target, this));
                // var className = Path.GetFileNameWithoutExtension(target);

                // this.FileTemplateProcessor.AddReplace("$nameSpace$", nameSpace);
                // this.FileTemplateProcessor.AddReplace("$className$", className);
                // this.FileTemplateProcessor.AddReplace("$guid$", Guid.NewGuid().ToString());
                var testFrameworkRegistryKey = (string)Registry.GetValue(ConstStrings.TestFrameworkRegistryPath, ConstStrings.TestFrameworkRegistryKey, null);
                this.FileTemplateProcessor.AddReplace("$pathtoassemblies$", testFrameworkRegistryKey);

                this.FileTemplateProcessor.UntokenFile(source, target);
            }

            this.FileTemplateProcessor.Reset();
        }

        /// <summary>
        /// The build target.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <returns>
        /// The <see cref="MSBuildResult"/>.
        /// </returns>
        public MSBuildResult BuildTarget(IVsOutputWindowPane output, string config, string target)
        {
            Logger.Enter(this, this.ProjectFile, string.Format("BuildTarget - Config: {0} Target: {1}", config, target));

            var failed = MSBuildResult.Failed;
            try
            {
                this.SetOutputLogger(output);
                this.SetBuildConfigurationProperties(config);
                failed = this.InvokeMsBuild(target);
                this.FlushBuildLoggerContent();
            }
            catch (Exception ex)
            {
                Logger.ErrorEx(this, this.ProjectFile, ex, ex.Message);
            }

            return failed;
        }

        /// <summary>
        /// The check if project is saved.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public bool CheckIfProjectIsSaved()
        {
            Logger.Enter(this, this.ProjectFile, "CheckIfProjectIsSaved");

            var flag = true;
            var automationObject = this.GetAutomationObject() as Project;
            if ((automationObject != null) && this.IsProjectFileDirty)
            {
                switch (this.ReadVS2010PropertyBeforeBuildingName())
                {
                    case vs2010BeforeBuilding.SaveAllChanges:
                        automationObject.Save(string.Empty);
                        flag = !automationObject.IsDirty;
                        break;

                    case vs2010BeforeBuilding.PromptSaveAllChanges:
                    case vs2010BeforeBuilding.PromptSaveChangesOpenDocumentsOnly:
                        if (MessageBox.Show(EH.DTMstudioTest.Plugin.Resources.QuestionToSaveUnsavedProject, EH.DTMstudioTest.Plugin.Resources.DTMstudioTestTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                        {
                            flag = false;
                            break;
                        }

                        automationObject.Save(string.Empty);
                        flag = !automationObject.IsDirty;
                        break;

                    case vs2010BeforeBuilding.DoNotSaveAnyChanges:
                        flag = false;
                        break;

                    default:
                        throw new Exception(EH.DTMstudioTest.Plugin.Resources.UnknownValue);
                }
            }

            if (!flag)
            {
                // Logger.OutputErrorTask(base.ProjectFile, Resources.UnsavedProject);
                Logger.Error(this, this.ProjectFile, EH.DTMstudioTest.Plugin.Resources.UnsavedProject);
            }

            return flag;
        }

        /// <summary>
        /// The create folder nodes.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// The <see cref="HierarchyNode"/>.
        /// </returns>
        public override HierarchyNode CreateFolderNodes(string path)
        {
            var directory = Path.Combine(this.ProjectFolder, path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return base.CreateFolderNodes(path);
        }

        /// <summary>
        /// Determines whether [is code file] [the specified file name].
        /// </summary>
        /// <param name="fileName">
        /// Name of the file.
        /// </param>
        /// <returns>
        /// <c>true</c> if [is code file] [the specified file name]; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsCodeFile(string fileName)
        {
            Logger.Enter(this, this.ProjectFile, string.Format("IsCodeFile {0}", fileName));

            if (string.Compare(Path.GetExtension(fileName), ".cs", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(Path.GetExtension(fileName), ".xsl", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(Path.GetExtension(fileName), ".xml", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The load.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="flags">
        /// The flags.
        /// </param>
        /// <param name="iidProject">
        /// The iid project.
        /// </param>
        /// <param name="canceled">
        /// The canceled.
        /// </param>
        public override void Load(string fileName, string location, string name, uint flags, ref Guid iidProject, out int canceled)
        {
            Logger.Enter(this, this.ProjectFile, "Load");

            // if the Project is reloaded the location is empty
            location = string.IsNullOrEmpty(location) ? Path.GetDirectoryName(fileName) : location;

            this.InitializeDataManager(location);
            this.EHDataManager.LoadData(location);
            this.GetDefaultDataIfNotExist();

            var testFrameworkAssemblyPath = (string)Registry.GetValue(ConstStrings.TestFrameworkRegistryPath, ConstStrings.TestFrameworkRegistryKey, null);
            this.SetProjectPropertyByName("AssemblyPathTestFramework", testFrameworkAssemblyPath);
            
            base.Load(fileName, location, name, flags, ref iidProject, out canceled);

            this.EHDataManager.SaveData();
        }

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        public void SaveConfiguration()
        {
            // EHDataManager.TestFrameworkManager.SaveData();
            this.EHDataManager.SaveData();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes the folders.
        /// </summary>
        protected internal override void ProcessFolders()
        {
            Logger.Enter(this, this.ProjectFile, "ProcessFolders");

            base.ProcessFolders();

            IEnumerable<ProjectItem> deviceFunctionsFolder = this.ProjectMgr.BuildProject.GetItems("DeviceFunctionsFolder");

            foreach (ProjectItem deviceFunctionFolder in deviceFunctionsFolder)
            {
                var element = new ProjectElement(this.ProjectMgr, deviceFunctionFolder, false);

                var title = element.GetMetadata("Title");
                var testSuiteNode = new DTTestSuiteNode(this, title);
                this.AddChild(testSuiteNode);

                this.AddDeviceFunctionNode(element, testSuiteNode);

                this.AddPreDefinedNode(element, testSuiteNode);
            }
        }

        /// <summary>
        /// Processes the references.
        /// </summary>
        protected internal override void ProcessReferences()
        {
            Logger.Enter(this, this.ProjectFile, "ProcessReferences");

            base.ProcessReferences();

            // var objectManager = SymbolBrowserPackage.GetGlobalService(typeof(SVsObjectManager)) as IVsObjectManager2;
            // library = new Library();
            // objectManager.RegisterSimpleLibrary(library, out libCookie);

            // IVsObjectSearch search = GetService(typeof(SVsObjectSearch)) as IVsObjectSearch;
            // IVsFindSymbol find = search as IVsFindSymbol;
            // criteria = new VSOBSEARCHCRITERIA2[1];
            // criteria[0].eSrchType = VSOBSEARCHTYPE.SO_ENTIREWORD;
            // criteria[0].grfOptions = (uint)(_VSOBSEARCHOPTIONS.VSOBSO_CASESENSITIVE | _VSOBSEARCHOPTIONS.VSOBSO_LOOKINREFS);
            // criteria[0].szName = strText;
            // Guid g = new Guid("0925166e-a743-49e2-9224-bbe206545104");
            // ObjectLib = new SearchLibrary(g, strText);
            // uint SearchCookie;
            // IVsObjectManager2 objManager = GetService(typeof(SVsObjectManager)) as IVsObjectManager2;
            // objManager.RegisterSimpleLibrary(ObjectLib, out SearchCookie);
            // int returnValue = find.DoSearch(ref g, criteria);
        }

        /// <summary>
        /// The display context menu.
        /// </summary>
        /// <param name="selectedNodes">
        /// The selected nodes.
        /// </param>
        /// <param name="pointerToVariant">
        /// The pointer to variant.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected override int DisplayContextMenu(IList<HierarchyNode> selectedNodes, IntPtr pointerToVariant)
        {
            Logger.Enter(this, this.ProjectFile, string.Format("DisplayContextMenu"));

            int retValue; // return value

            var menuId = 0;
            var menuGuid = VsMenus.guidSHLMainMenu;

            // bool nodeEnabled = false;
            if (selectedNodes == null || selectedNodes.Count == 0 || pointerToVariant == IntPtr.Zero)
            {
                retValue = 0;
            }
            else
            {
                foreach (HierarchyNode node in selectedNodes)
                {
                    // if (node is DTDeviceFunctionNode)
                    // {
                    // var projectNode = node as DTDeviceFunctionNode;

                    // if (EHDataManager.DTMstudioDataManager.DTMstudioTestData.DeviceTypeProject != null)
                    // {
                    // nodeEnabled = EHDataManager.DTMstudioDataManager.DTMstudioTestData.DeviceTypeProject
                    // .DeviceFunctions.Where(deviceFunction => deviceFunction.CompilerVariable == projectNode.CompilerVariable)
                    // .Select(deviceFunction => deviceFunction.Active).FirstOrDefault();
                    // }
                    // }
                    // else if (node is DTPreDefineNode)
                    // {
                    // nodeEnabled = true;
                    // }

                    // We check here whether we have a multiple selection of
                    // nodes of differing type.
                    if (menuId == 0)
                    {
                        // First time through or single node case
                        menuId = node.MenuCommandId;
                    }
                    else if (menuId != node.MenuCommandId)
                    {
                        menuId = VsMenus.IDM_VS_CTXT_NOCOMMANDS;
                    }
                }

                this.package.SelectedNode = selectedNodes[0];

                // if (idmxStoredMenu == PkgCmdIDList.CmdIdPreDefineNodeContextMenu ) // && nodeEnabled)
                // {
                // if (selectedNodes.Count > 1)
                // {
                // // special context menus do not make sense if multiple nodes are selected
                // idmxStoredMenu = VsMenus.IDM_VS_CTXT_XPROJ_MULTIITEM;
                // }
                // else
                // {
                // // one single test case node is selected
                // // CoDIA Studio specific context menus need a special GUID
                // menuGuid = GuidList.guidDTMstudioTestCmdSet;

                // // store selected nod in the package
                // this.package.SelectedNode = selectedNodes[0];
                // }
                // }
                var variant = Marshal.GetObjectForNativeVariant(pointerToVariant);
                var pointsAsUint = Convert.ToUInt32(variant);
                var x = (short)(pointsAsUint & 0x0000ffff);
                var y = (short)((pointsAsUint & 0xffff0000) / 0x10000);

                var points = new POINTS { x = x, y = y };

                retValue = this.ShowContextMenu(menuId, menuGuid, points);
            }

            return retValue;
        }

        /// <summary>
        /// The get configuration independent property pages.
        /// </summary>
        /// <returns>
        /// The <see cref="Guid[]"/>.
        /// </returns>
        protected override Guid[] GetConfigurationIndependentPropertyPages()
        {
            Logger.Enter(this, this.ProjectFile, "GetConfigurationIndependentPropertyPages");

            // this.EHDataManager.DTMstudioTestData = this.EHDataManager.TestFrameworkManager.GetDTMstudioTestData(this.EHDataManager.DTMstudioTestData);
            var result = new Guid[4];
            result[0] = typeof(PropertiesPageDTMstudioTest).GUID;
            result[1] = typeof(PropertiesPageReport).GUID;
            result[2] = typeof(PropertiesPageInfrastructure).GUID;
            result[3] = typeof(PropertiesPageTestEnvironment).GUID;

            return result;
        }

        /// <summary>
        /// The get priority project designer pages.
        /// </summary>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        protected override Guid[] GetPriorityProjectDesignerPages()
        {
            Logger.Enter(this, this.ProjectFile, "GetPriorityProjectDesignerPages");

            var result = new Guid[4];
            result[0] = typeof(PropertiesPageDTMstudioTest).GUID;
            result[1] = typeof(PropertiesPageReport).GUID;
            result[2] = typeof(PropertiesPageInfrastructure).GUID;
            result[3] = typeof(PropertiesPageTestEnvironment).GUID;

            return result;
        }

        /// <summary>
        /// Initializes the project properties.
        /// </summary>
        protected override void InitializeProjectProperties()
        {
            Logger.Enter(this, this.ProjectFile, "InitializeProjectProperties");

            base.InitializeProjectProperties();
        }

        /// <summary>
        /// The query status on node.
        /// </summary>
        /// <param name="cmdGroup">
        /// The cmd group.
        /// </param>
        /// <param name="cmd">
        /// The cmd.
        /// </param>
        /// <param name="pCmdText">
        /// The p cmd text.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected override int QueryStatusOnNode(Guid cmdGroup, uint cmd, IntPtr pCmdText, ref QueryStatusResult result)
        {
            if (!(cmdGroup == GuidList.guidDTMstudioTestCmdSet))
            {
                return base.QueryStatusOnNode(cmdGroup, cmd, pCmdText, ref result);
            }

            return 0;
        }

        /// <summary>
        /// Adds the device function node.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="testSuiteNode">
        /// The test suite node.
        /// </param>
        private void AddDeviceFunctionNode(ProjectElement element, DTTestSuiteNode testSuiteNode)
        {
            Logger.Enter(this, this.ProjectFile, "AddDeviceFunctionNode");

            if (element.Item.EvaluatedInclude == "DeviceFunctions")
            {
                if (this.EHDataManager != null && this.EHDataManager.DTMstudioTestData != null && this.EHDataManager.DTMstudioTestData.DeviceTypeProject != null && this.EHDataManager.DTMstudioTestData.DeviceTypeProject.DeviceFunctions != null && this.EHDataManager.TestFrameworkManager != null && this.EHDataManager.DTMstudioTestData != null && this.EHDataManager.DTMstudioTestData.TestLibrary != null && this.EHDataManager.DTMstudioTestData.TestLibrary.DeviceFunctions != null && this.EHDataManager.TestFrameworkManager.DeviceFunctionMappingList != null)
                {
                    foreach (var dtmStudioDeviceFunction in
                        this.EHDataManager.DTMstudioTestData.DeviceTypeProject.DeviceFunctions.Where(dtmStudioDeviceFunction => dtmStudioDeviceFunction.Active))
                    {
                        var deviceFunctionMapping = this.EHDataManager.GetDeviceFunctionMappingFromTestFramework(dtmStudioDeviceFunction);

                        if (deviceFunctionMapping != null)
                        {
                            var testCaseNode = new DTDeviceFunctionNode(this, deviceFunctionMapping.DisplayName, dtmStudioDeviceFunction.Name, true);

                            testSuiteNode.AddChild(testCaseNode);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds the pre defined node.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="testSuiteNode">
        /// The test suite node.
        /// </param>
        private void AddPreDefinedNode(ProjectElement element, DTTestSuiteNode testSuiteNode)
        {
            Logger.Enter(this, this.ProjectFile, "AddPreDefinedNode");

            IEnumerable<ProjectItem> deviceFunctions = this.ProjectMgr.BuildProject.GetItems("PreDefined");

            foreach (ProjectItem df in deviceFunctions)
            {
                var deviceFunctionElement = new ProjectElement(this.ProjectMgr, df, false);

                var testsuite = deviceFunctionElement.GetMetadata("RootFolder");
                if (testsuite == element.Item.EvaluatedInclude)
                {
                    var testCaseNodetitle = deviceFunctionElement.GetMetadata("Title");
                    var compilerVariable = deviceFunctionElement.GetMetadata("CompilerVariable");

                    var testCaseNode = new DTPreDefineNode(this, testCaseNodetitle, compilerVariable, true);
                    testSuiteNode.AddChild(testCaseNode);
                }
            }
        }

        /// <summary>
        /// The fill eh data manager.
        /// </summary>
        private void GetDefaultDataIfNotExist()
        {
            Logger.Enter(this, this.ProjectFile, "GetDefaultDataIfNotExist");

            // templateVersionDeviceTypeProject
            var templateVersionDeviceTypeProject = ToolBox.GetTemplateVersionByExtension(this.BuildEngine.LoadedProjects, ConstStrings.DeviceTypeProjectExtension);
            if (!string.IsNullOrEmpty(templateVersionDeviceTypeProject))
            {
                this.EHDataManager.DTMstudioTestData.DeviceTypeProject.TemplateVersion = templateVersionDeviceTypeProject;
            }

            // templateVersionDTMstudioTest
            var templateVersionDTMstudioTest = ToolBox.GetTemplateVersionByExtension(this.BuildEngine.LoadedProjects, ConstStrings.DeviceTypeTestProjectExtension);
            if (!string.IsNullOrEmpty(templateVersionDTMstudioTest))
            {
                this.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.TemplateVersion = templateVersionDTMstudioTest;
            }

            // DeviceTypeProjectName
            var deviceTypeProjectName = ToolBox.GetProjProjectNameByExtension(this.BuildEngine.LoadedProjects, ConstStrings.DeviceTypeProjectExtension);
            if (!string.IsNullOrEmpty(deviceTypeProjectName))
            {
                this.EHDataManager.DTMstudioTestData.DeviceTypeProject.Name = deviceTypeProjectName;
            }
            else
            {
                // last edit: EC on 2016-04-20
                this.EHDataManager.DTMstudioTestData.DeviceTypeProject.Name = ConstStrings.NoDeviceTypeProjectAvailable;
            }

            // TestProjectName
            var testProjectName = ToolBox.GetProjProjectNameByExtension(this.BuildEngine.LoadedProjects, ConstStrings.DeviceTypeTestProjectExtension);
            if (!string.IsNullOrEmpty(testProjectName))
            {
                this.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.Name = testProjectName;
            }

            // NameOfTester
            if (string.IsNullOrEmpty(this.EHDataManager.DTMstudioTestData.ReportData.NameOfTester))
            {
                this.EHDataManager.DTMstudioTestData.ReportData.NameOfTester = Environment.UserName;
            }

            // Company
            if (string.IsNullOrEmpty(this.EHDataManager.DTMstudioTestData.ReportData.NameOfTester))
            {
                this.EHDataManager.DTMstudioTestData.ReportData.Company = "EH";
            }

            // ReportOutputDirectory
            if (string.IsNullOrEmpty(this.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ReportOutputPath))
            {
                this.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ReportOutputPath = @"\Report\Output\";
            }

            // ExportDirectory
            if (string.IsNullOrEmpty(this.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ProjectExportPath))
            {
                this.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ProjectExportPath = @"Export\";
            }

            // OperatingSystemBitVersion
            if (string.IsNullOrEmpty(this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemBitVersion))
            {
                this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemBitVersion = OSInfo.BitsString;
            }

            // OperatingSystemLanguageString
            if (string.IsNullOrEmpty(this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemLanguageString))
            {
                this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemLanguageString = CultureInfo.CurrentCulture.Name;
                this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemLanguage = CultureInfo.CurrentCulture;
            }

            // OperatingSystemServicePack
            if (string.IsNullOrEmpty(this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemServicePack))
            {
                this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemServicePack = Environment.OSVersion.ServicePack;
            }

            //if (string.IsNullOrEmpty(this.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationName))
            //{
            //    this.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationType = "FDT";
            //}

            // OperatingSystemName
            if (string.IsNullOrEmpty(this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemName))
            {
                this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemName = OSInfo.Name.Replace(" ", string.Empty);
            }

            // OperatingSystemVersionString
            if (string.IsNullOrEmpty(this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemVersionString))
            {
                this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemVersionString = OSInfo.VersionString;
                this.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemVersion = OSInfo.Version;
            }
        }

        /// <summary>
        /// Initializes the data manager.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        private void InitializeDataManager(string location)
        {
            Logger.Enter(this, this.ProjectFile, string.Format("InitializeDataManager - Location: {0}", location));

            var deviceTypeProjectFile = ToolBox.GetProjectPathByExtension(this.BuildEngine.LoadedProjects, ConstStrings.DeviceTypeProjectExtension);

            var deviceTypeTestProjectOutputLocation = Path.Combine(location, ToolBox.GetProjectOutputDirByExtension(this.BuildEngine.LoadedProjects, ConstStrings.DeviceTypeTestProjectExtension));

            var testFrameworkRegistryKey = (string)Registry.GetValue(ConstStrings.TestFrameworkRegistryPath, ConstStrings.TestFrameworkRegistryKey, null);

            this.EHDataManager = new EhDataManager(deviceTypeProjectFile, testFrameworkRegistryKey);

            this.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ExecutionPath = deviceTypeTestProjectOutputLocation;
        }

        /// <summary>
        /// Reads the name of the v S2010 property before building.
        /// </summary>
        /// <returns>vs2010BeforeBuilding.</returns>
        private vs2010BeforeBuilding ReadVS2010PropertyBeforeBuildingName()
        {
            Logger.Enter(this, this.ProjectFile, "ReadVS2010PropertyBeforeBuildingName");

            var saveAllChanges = vs2010BeforeBuilding.SaveAllChanges;
            try
            {
                var property = this.package.DTE.get_Properties("Environment", "ProjectsAndSolution").Item("OnRunOrPreview");

                if (property != null)
                {
                    saveAllChanges = (vs2010BeforeBuilding)property.Value;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorEx(this, ex, ex.Message);
            }

            return saveAllChanges;
        }

        /// <summary>
        /// The set project property by name.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <param name="propertyValue">
        /// The property value.
        /// </param>
        private void SetProjectPropertyByName(string propertyName, string propertyValue)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName", "Cannot set a null project property");
            }

            string oldValue = null;
            ProjectPropertyInstance oldProp = this.GetMsBuildProperty(propertyName, true);
            if (oldProp != null)
            {
                oldValue = oldProp.EvaluatedValue;
            }

            if (propertyValue == null)
            {
                // if property already null, do nothing
                if (oldValue == null)
                {
                    return;
                }

                // otherwise, set it to empty
                propertyValue = string.Empty;
            }

            // Only do the work if this is different to what we had before
            if (string.Compare(oldValue, propertyValue, StringComparison.Ordinal) != 0)
            {
                this.BuildProject.SetProperty(propertyName, propertyValue);
            }
        }

        /// <summary>
        /// The untoken binary file.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="destination">
        /// The destination.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        private void UntokenBinaryFile(string source, string destination)
        {
            Logger.Enter(this, this.ProjectFile, string.Format("UntokenBinaryFile - Source: {0} destination:{1}", source, destination));

            if (string.IsNullOrEmpty(source))
            {
                var ex = new ArgumentNullException("source");
                Log.ErrorEx(this, new ArgumentNullException("source"), ex.Message);
                throw ex;
            }

            if (string.IsNullOrEmpty(destination))
            {
                var ex = new ArgumentNullException("destination");
                Log.ErrorEx(this, new ArgumentNullException("source"), ex.Message);
                throw ex;
            }

            // Make sure that the destination folder exists.
            var destinationFolder = Path.GetDirectoryName(destination);
            if (destinationFolder != null && !Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            File.Copy(source, destination);
        }

        #endregion
    }
}