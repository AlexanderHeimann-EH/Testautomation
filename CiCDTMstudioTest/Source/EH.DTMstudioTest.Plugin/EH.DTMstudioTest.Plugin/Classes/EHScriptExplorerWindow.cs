// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHScriptExplorerWindow.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   This class implements the tool window exposed by this package and hosts a user control.
//   In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
//   usually implemented by the package implementer.
//   This class derives from the ToolWindowPane class provided from the MPF in order to use its
//   implementation of the IVsUIElementPane interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System.Reflection;
    using System.Runtime.InteropServices;

    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.DTMstudioTest.ScriptExplorer;

    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
    /// usually implemented by the package implementer.
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its 
    /// implementation of the IVsUIElementPane interface.
    /// </summary>
    [Guid("8abfb1c2-bdee-4fec-b6fb-86b84303b398")]
    public class EHScriptExplorerWindow : ToolWindowPane
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EHScriptExplorerWindow"/> class. 
        /// Standard constructor for the tool window.
        /// </summary>
        public EHScriptExplorerWindow() : base(null)
        {
            // Set the window title reading it from the resources.
            this.Caption = EH.DTMstudioTest.Plugin.Resources.ScriptExplorerWindowTitle;

            // Set the image that will appear on the tab of the window frame
            // when docked with an other window
            // The resource ID correspond to the one defined in the resx file
            // while the Index is the offset in the bitmap strip. Each image in
            // the strip being 16x16.
            this.BitmapResourceID = 301;
            this.BitmapIndex = 1;

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
            // the object returned by the Content property.
            base.Content = new ScriptExplorerWindow();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The load assembly.
        /// </summary>
        /// <param name="defaultRootFolder">
        /// The default root folder.
        /// </param>
        /// <param name="assemblyPath">
        /// The assembly path.
        /// </param>
        /// <param name="isTempFile">
        /// The is temp file.
        /// </param>
        public void LoadAssembly(string assemblyPath)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var scriptConfiguratorWindow = this.Content as ScriptExplorerWindow;

            if (scriptConfiguratorWindow != null)
            {
                scriptConfiguratorWindow.LoadAssembly(assemblyPath);
            }
        }

        /// <summary>
        /// The remove assembly path.
        /// </summary>
        /// <param name="assemblyPath">
        /// The assembly path.
        /// </param>
        public void UnloadAssembly(string assemblyPath)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var scriptConfiguratorWindow = this.Content as ScriptExplorerWindow;

            if (scriptConfiguratorWindow != null)
            {
                scriptConfiguratorWindow.UnloadAssembly(assemblyPath);
            }
        }

        /// <summary>
        /// The unload explorer.
        /// </summary>
        public void UnloadExplorer()
        {
        }

        #endregion
    }
}