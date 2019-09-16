//------------------------------------------------------------------------------
// <copyright file="DTMstudioTestPackage.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Template
{
    #region

    using System;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Globalization;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    using EH.DTMstudioTest.Common.Manager;
    using EH.DTMstudioTest.Common.Tools;
    using EH.DTMstudioTest.Common.Utilities.Logging;

    using EnvDTE;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Project;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    using ToolBox = EnvDTE.ToolBox;

    #endregion

    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(EHScriptExplorerWindow))]
    [ProvideToolWindow(typeof(EHScriptConfiguratorWindow))]
    [ProvideToolWindow(typeof(EHSuiteConfiguratorWindow))]
    [ProvideEditorExtension(typeof(EditorFactory), ".dtmstudiotest", 50, ProjectGuid = "{A2FE74E1-B743-11d0-AE1A-00A0C90FFFC3}", TemplateDir = "Templates", NameResourceID = 105, DefaultName = "DTMstudio Test")]
    [ProvideKeyBindingTable(GuidList.guidDTMstudioTestEditorFactoryString, 102)]
    [ProvideEditorLogicalView(typeof(EditorFactory), "{7651a703-06e5-11d1-8ebd-00a0c90f26ea}")]
    [ProvideProjectFactory(typeof(DTTestProjectFactory), "DTMstudio Test", "E+H DeviceType Test Project Files (*.testproj);*.testproj", "testproj", "testproj", @"Templates\Projects\DTTestProject", DisableOnlineTemplates = false, LanguageVsTemplate = "DTTestProject", ProjectSubTypeVsTemplate = "CSharp", ShowOnlySpecifiedTemplatesVsTemplate = false)]
    [Guid(DTMstudioTestPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideObject(typeof(PropertiesPageDTMstudioTest))]
    [ProvideObject(typeof(PropertiesPageReport))]
    [ProvideObject(typeof(PropertiesPageInfrastructure))]
    [ProvideObject(typeof(PropertiesPageTestEnvironment))]
    public sealed class DTMstudioTestPackage : ProjectPackage
    {
        /// <summary>
        /// DTMstudioTestPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "eabf7f9b-7970-4a5d-929a-186597546a83";

        #region Constants

        /// <summary>
        /// The logger configuration path.
        /// </summary>
        private const string LoggerConfigurationPath = "c:\\tmp\\";

        #endregion
        
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DTMstudioTestPackage"/> class. 
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public DTMstudioTestPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this));
            Logger.Initialize(LoggerConfigurationPath);
        }

        #endregion
                
        #region Fields

        /// <summary>
        /// Reference to the selected node (needed for its context menu entries)
        /// </summary>
        private HierarchyNode selectedNode;

        #endregion

        #region Public Properties
        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        /// <summary>
        /// Gets the product user context.
        /// </summary>
        public override string ProductUserContext
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Sets the selected node.
        /// </summary>
        public HierarchyNode SelectedNode
        {
            set
            {
                this.selectedNode = value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the dte.
        /// </summary>
        internal DTE DTE
        {
            get
            {
                return (DTE)this.GetService(typeof(DTE));
            }
        }

        /// <summary>
        /// Gets the status bar.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        internal IVsStatusbar StatusBar
        {
            get
            {
                var service = (IVsStatusbar)this.GetService(typeof(SVsStatusbar));
                if (service == null)
                {
                    throw new Exception("Cannot access to the StatusBar object");
                }

                return service;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this));

            this.SolutionListeners.Add(new SolutionListenerForDTTestProject(this));

            base.Initialize();
            this.RegisterProjectFactory(new DTTestProjectFactory(this));

            // Create Editor Factory. Note that the base Package class will call Dispose on it.
            this.RegisterEditorFactory(new EditorFactory(this));

            // Add our command handlers for menu (commands must exist in the .vsct file)
            var mcs = this.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null != mcs)
            {
                // Create the command for the menu item.
                var menuCommandID = new CommandID(GuidList.guidDTMstudioTestCmdSet, (int)PkgCmdIDList.cmdidMyCommand);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                mcs.AddCommand(menuItem);

                // Create the command for the EHScriptExplorer Window
                var ehScriptExplorerwndCommandID = new CommandID(GuidList.guidDTMstudioTestCmdSet, (int)PkgCmdIDList.cmdidEHDTMstudioTestScriptExplorer);
                var menuEHScriptExplorerWin = new MenuCommand(this.ShowEHScriptExplorerWindow, ehScriptExplorerwndCommandID);
                mcs.AddCommand(menuEHScriptExplorerWin);

                // Create the command for the EHScriptConfigurator Window
                var ehScriptConfiguratorwndCommandID = new CommandID(GuidList.guidDTMstudioTestCmdSet, (int)PkgCmdIDList.cmdidEHDTMstudioTestScriptConfigurator);
                var menuEHScriptConfiguratorWin = new MenuCommand(this.ShowEHScriptConfiguratorWindow, ehScriptConfiguratorwndCommandID);
                mcs.AddCommand(menuEHScriptConfiguratorWin);

                var ehSuiteConfiguratorwndCommandID = new CommandID(GuidList.guidDTMstudioTestCmdSet, (int)PkgCmdIDList.cmdidEHDTMstudioTestSuiteConfigurator);
                var menuEHSuiteConfiguratorWin = new MenuCommand(this.ShowEHSuiteConfiguratorWindow, ehSuiteConfiguratorwndCommandID);
                mcs.AddCommand(menuEHSuiteConfiguratorWin);

                //// Create the command for enabling test case
                // var enableCommandID = new CommandID(GuidList.guidDTMstudioTestCmdSet, (int)PkgCmdIDList.CmdIdEnablePreDefineNode);
                // var enableCommand = new MenuCommand(this.EnableCommandIdCallback, enableCommandID);
                // mcs.AddCommand(enableCommand);

                //// Create the command for enabling test case
                // var desableCommandID = new CommandID(GuidList.guidDTMstudioTestCmdSet, (int)PkgCmdIDList.CmdIdDisablePreDefineNode);
                // var desableCommand = new MenuCommand(this.DesableCommandIdCallback, desableCommandID);
                // mcs.AddCommand(desableCommand);
                var exportCommandId = new CommandID(GuidList.guidDTMstudioTestCmdSet, PkgCmdIDList.CmdIdExportTestProject);
                var exportCommand = new MenuCommand(this.ExportDTProjectCallback, exportCommandId);
                mcs.AddCommand(exportCommand);

                var exportMultiCommandId = new CommandID(GuidList.guidDTMstudioTestCmdSet, PkgCmdIDList.cmdidExportTestProjectMulti);

                // var exportMultiCommand = new OleMenuCommand(this.ExportDTProjectMultiCallback, exportMultiCommandId);
                var exportMultiCommand = new MenuCommand(this.ExportDTProjectMultiCallback, exportMultiCommandId);
                mcs.AddCommand(exportMultiCommand);
            }
        }

        /// <summary>
        /// The desable command id callback.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DesableCommandIdCallback(object sender, EventArgs e)
        {
            var deviceFunctionNode = this.selectedNode as DTDeviceFunctionNode;
            if (deviceFunctionNode != null)
            {
                deviceFunctionNode.NodeEnabled = false;
            }
        }

        /// <summary>
        /// The enable command id callback.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void EnableCommandIdCallback(object sender, EventArgs e)
        {
            var deviceFunctionNode = this.selectedNode as DTDeviceFunctionNode;
            if (deviceFunctionNode != null)
            {
                deviceFunctionNode.NodeEnabled = true;
            }
        }

        /// <summary>
        /// The export dt project callback.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ExportDTProjectCallback(object sender, EventArgs e)
        {
            var node = this.selectedNode as DTTestProjectNode;
            if ((node != null) && node.CheckIfProjectIsSaved())
            {
                this.StatusBar.SetText("Exporting : " + this.selectedNode.ProjectMgr.ProjectFile);
                var zipFileName = string.Format(CultureInfo.CurrentCulture, "{0}{1}", node.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.Name, ".zip");

                if (!Directory.Exists(node.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ProjectExportPath))
                {
                    Directory.CreateDirectory(node.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ProjectExportPath);
                }

                var exportFile = Path.Combine(node.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ProjectExportPath, zipFileName);

                var outputPane = Logger.GetOutputPane("Export", GuidList.GuidOutputExportWindowPane);
                outputPane.Clear();
                outputPane.OutputString(DateTime.Now.ToString(CultureInfo.InvariantCulture) + Environment.NewLine);

                this.StatusBar.SetText("Exporting : " + this.selectedNode.ProjectMgr.ProjectFile);
                outputPane.OutputString("Exporting : " + this.selectedNode.ProjectMgr.ProjectFile + Environment.NewLine);


                //var testProjectDirectory = ToolBox.GetProjProjectDirectoryByExtension(this.BuildEngine.LoadedProjects, ConstStrings.DeviceTypeTestProjectExtension);

                // DeviceTypeTestProjectPath -> muss zum aktuellen Verzeichnis geändert werden 
                //if (EHExportManager.Export(node.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.DeviceTypeTestProjectPath, exportFile))
                //{
                //    this.StatusBar.SetText("Exporting successful");

                //    outputPane.OutputString("Exporting successful" + Environment.NewLine);
                //    outputPane.OutputString("Export Folder: " + exportFile + Environment.NewLine);
                //}
                //else
                //{
                //    this.StatusBar.SetText("Exporting failed");
                //    outputPane.OutputString("Exporting failed" + Environment.NewLine);
                //}
                // Änderung geht bis hier !!!!!


                // string propertyValue = node.BuildProject.GetPropertyValue(GlobalProperty.Configuration.ToString());
                // this.StatusBar.SetText("Exporting : " + this.selectedNode.ProjectMgr.ProjectFile);
                // switch (node.BuildTarget(outputPane, propertyValue, "ExportDeviceType"))
                // {
                // case MSBuildResult.Successful:
                // this.StatusBar.SetText("Exporting successful");
                // return;

                // case MSBuildResult.Failed:
                // this.StatusBar.SetText("Exporting failed");
                // return;
                // }

                // this.StatusBar.SetText("Ready");
            }
        }

        /// <summary>
        /// The export dt project multi callback.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ExportDTProjectMultiCallback(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            MessageBox.Show("ExportDTProjectMultiCallback");
        }

        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            // Show a Message Box to prove we were here
            var uiShell = (IVsUIShell)this.GetService(typeof(SVsUIShell));
            var clsid = Guid.Empty;
            int result;
            ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(0, ref clsid, "DTMstudioTest", string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this), string.Empty, 0, OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST, OLEMSGICON.OLEMSGICON_INFO, 0, // false
                out result));
        }

        /// <summary>
        /// This function is called when the user clicks the menu item that shows the 
        /// tool window. See the Initialize method to see how the menu item is associated to 
        /// this function using the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ShowEHScriptConfiguratorWindow(object sender, EventArgs e)
        {
            // Get the instance number 0 of this tool window. This window is single instance so this instance
            // is actually the only one.
            // The last flag is set to true so that if the tool window does not exists it will be created.
            var window = this.FindToolWindow(typeof(EHScriptConfiguratorWindow), 0, true);
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("CanNotCreateWindow"); // Resources.CanNotCreateWindow
            }

            var windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        /// <summary>
        /// This function is called when the user clicks the menu item that shows the 
        /// tool window. See the Initialize method to see how the menu item is associated to 
        /// this function using the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ShowEHScriptExplorerWindow(object sender, EventArgs e)
        {
            Log.Enter(null, MethodBase.GetCurrentMethod().Name);

            // Get the instance number 0 of this tool window. This window is single instance so this instance
            // is actually the only one.
            // The last flag is set to true so that if the tool window does not exists it will be created.
            var window = this.FindToolWindow(typeof(EHScriptExplorerWindow), 0, true);
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("CanNotCreateWindow"); // Resources.CanNotCreateWindow
            }

            var windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        /// <summary>
        /// The show eh suite configurator window.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        /// <exception cref="NotSupportedException">
        /// </exception>
        private void ShowEHSuiteConfiguratorWindow(object sender, EventArgs e)
        {
            Log.Enter(null, MethodBase.GetCurrentMethod().Name);

            // Get the instance number 0 of this tool window. This window is single instance so this instance
            // is actually the only one.
            // The last flag is set to true so that if the tool window does not exists it will be created.
            var window = this.FindToolWindow(typeof(EHSuiteConfiguratorWindow), 0, true);
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("CanNotCreateWindow"); // Resources.CanNotCreateWindow
            }

            var windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        /// <summary>
        /// The get assembly local path from.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetAssemblyLocalPathFrom()
        {
            Log.Enter(null, MethodBase.GetCurrentMethod().Name);
            try
            {
                Type type = typeof(DTMstudioTestPackage);

                string codebase = type.Assembly.CodeBase;
                var uri = new Uri(codebase, UriKind.Absolute);
                string path = uri.LocalPath;
                path = RemoveFileFromPath(path);
                return path;
            }
            catch (Exception exception)
            {
                Log.ErrorEx(string.Empty, exception, exception.Message);
                return null;
            }
        }

        /// <summary>
        /// The remove file from path.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string RemoveFileFromPath(string path)
        {
            Log.Enter(null, MethodBase.GetCurrentMethod().Name);
            try
            {
                string[] pathParts = path.Split('\\');
                pathParts[pathParts.Length - 1] = string.Empty;

                path = string.Empty;
                for (int index = 0; index < pathParts.Length - 1; index++)
                {
                    path = path + pathParts[index] + "\\";
                }

                return path;
            }
            catch (Exception exception)
            {
                Log.ErrorEx(string.Empty, exception, exception.Message);
                return null;
            }
        }

        #endregion
    }
}
