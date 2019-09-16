// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHScriptConfiguratorWindow.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The eh script configurator window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.DTMstudioTest.ScriptConfigurator;

    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// The eh script configurator window.
    /// </summary>
    [Guid("1873BF77-8223-4762-9508-DB98E90F7BBF")]
    public class EHScriptConfiguratorWindow : ToolWindowPane, INotifyPropertyChanged
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EHScriptConfiguratorWindow"/> class.
        /// </summary>
        public EHScriptConfiguratorWindow()
            : base(null)
        {
            // Set the window title reading it from the resources.
            this.Caption = EH.DTMstudioTest.Plugin.Resources.ScriptConfiguratorWindowTitle;

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
            base.Content = new ScriptConfiguratorWindow();
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The load control document.
        /// </summary>
        /// <param name="rootTestObject">
        ///     The root folder.
        /// </param>
        /// <param name="userDefinedProjectPath">
        ///     The user defined project path.
        /// </param>
        /// <param name="testLibraryPath">
        ///     The test library path.
        /// </param>
        /// <param name="deviceFunctions"></param>
        public void LoadControlDocument(string rootTestObject, string userDefinedProjectPath, string testLibraryPath, List<DeviceFunction> deviceFunctions)
        {
            var scriptConfiguratorWindow = this.Content as ScriptConfiguratorWindow;
            if (scriptConfiguratorWindow != null)
            {
                var testFolder = new TestFolder { Name = rootTestObject };

                scriptConfiguratorWindow.LoadTestConfiguration(testFolder, userDefinedProjectPath, testLibraryPath, deviceFunctions);
            }
        }

        /// <summary>
        /// The unload control document.
        /// </summary>
        public void UnloadControlDocument()
        {
            var scriptConfiguratorWindow = this.Content as ScriptConfiguratorWindow;
            if (scriptConfiguratorWindow != null)
            {
                scriptConfiguratorWindow.UnloadControlDocument();
            }
        }

        #endregion
    }
}