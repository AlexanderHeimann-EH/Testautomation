// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHSuiteConfiguratorWindow.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The eh script configurator window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System.ComponentModel;
    using System.Reflection;
    using System.Runtime.InteropServices;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.DTMstudioTest.SuiteConfigurator;
    using EH.PCPS.TestAutomation.Common.Enumerations;

    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// The eh script configurator window.
    /// </summary>
    [Guid("AF37238A-E9B7-442C-8964-CFAAD6F2EDFF")]
    public class EHSuiteConfiguratorWindow : ToolWindowPane, INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// The control document path.
        /// </summary>
        private string controlDocumentPath;

        /// <summary>
        /// The project name.
        /// </summary>
        private string projectName;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EHScriptConfiguratorWindow"/> class.
        /// </summary>
        public EHSuiteConfiguratorWindow()
            : base(null)
        {
            // Set the window title reading it from the resources.
            this.Caption = EH.DTMstudioTest.Plugin.Resources.SuiteConfiguratorWindowTitle;

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
            base.Content = new SuiteConfiguratorWindow();
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the control document path.
        /// </summary>
        public string ControlDocumentPath
        {
            get
            {
                return this.controlDocumentPath;
            }

            set
            {
                this.controlDocumentPath = value;

                this.RaisePropertyChanged("ControlDocumentPath");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The load control document.
        /// </summary>
        /// <param name="rootTestObject">
        /// The user defined project name.
        /// </param>
        /// <param name="userDefinedProjectPath">
        /// The user defined project path.
        /// </param>
        public void LoadControlDocument(string rootTestObject, string userDefinedProjectPath)
        {
            var suiteConfiguratorWindow = this.Content as SuiteConfiguratorWindow;
            if (suiteConfiguratorWindow != null)
            {
                this.ControlDocumentPath = userDefinedProjectPath;

                var testSuite = new TestSuite { Name = rootTestObject, TestDefinition = TestDefinition.UserDefined };

                suiteConfiguratorWindow.LoadControlDocument(testSuite, userDefinedProjectPath);
            }
        }

        /// <summary>
        /// The unload control document.
        /// </summary>
        public void UnloadControlDocument()
        {
            var suiteConfiguratorWindow = this.Content as SuiteConfiguratorWindow;
            if (suiteConfiguratorWindow != null)
            {
                suiteConfiguratorWindow.UnloadControlDocument();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property.
        /// </param>
        private void RaisePropertyChanged(string propertyName)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (this.PropertyChanged != null)
            {
                Log.Enter(this, string.Format("{0} {1}", MethodBase.GetCurrentMethod().Name, propertyName));

                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}