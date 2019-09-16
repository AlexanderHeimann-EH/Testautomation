// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SuiteConfiguratorWindow.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The script explorer window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.SuiteConfigurator
{
    using System.ComponentModel;
    using System.IO;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;

    using EH.DTMstudioTest.Common.Manager;
    using EH.DTMstudioTest.Common.TransportObjects.AssemblyData;
    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    /// The script explorer window.
    /// </summary>
    public partial class SuiteConfiguratorWindow : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// The assembly manager.
        /// </summary>
        private AssemblyManager assemblyManager;

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
        /// Initializes a new instance of the <see cref="SuiteConfiguratorWindow"/> class.
        /// </summary>
        public SuiteConfiguratorWindow()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.InitializeComponent();

            this.assemblyManager = new AssemblyManager();
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
        /// Gets or sets the assembly manager.
        /// </summary>
        public AssemblyManager AssemblyManager
        {
            get
            {
                return this.assemblyManager;
            }

            set
            {
                this.assemblyManager = value;

                this.RaisePropertyChanged("AssemblyManager");
            }
        }

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
        /// The root folder.
        /// </param>
        /// <param name="controlDocPath">
        /// The control doc path.
        /// </param>
        public void LoadControlDocument(TestObject rootTestObject, string controlDocPath)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (this.IsTestSuiteFile(controlDocPath))
            {
                this.ControlDocumentPath = controlDocPath;
                this.assemblyManager = new AssemblyManager();

                this.assemblyManager.LoadControlDocument(rootTestObject, controlDocPath);

                this.SuiteConfiguratorControl.LoadTestSuiteSelectionTreeControl(this.AssemblyManager.TestConfiguration);
            }
        }

        /// <summary>
        /// The unload control document.
        /// </summary>
        public void UnloadControlDocument()
        {
            this.controlDocumentPath = string.Empty;

            this.assemblyManager = null;

            this.SuiteConfiguratorControl.UnloadTestSuiteSelectionTreeControl();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The is test suite file.
        /// </summary>
        /// <param name="testSuiteFile">
        /// The test suite file.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsTestSuiteFile(string testSuiteFile)
        {
            var fileExtension = Path.GetExtension(testSuiteFile);
            if (".xml" == fileExtension)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The raise property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
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

        /// <summary>
        /// The suite configurator window_ on drag over.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnSuiteConfiguratorWindowDragOver(object sender, DragEventArgs e)
        {
            var dataFormats = e.Data.GetFormats();
            foreach (var dataFormat in dataFormats)
            {
                if ("System.String" == dataFormat)
                {
                    var dragData = e.Data.GetData("System.String");
                    if (this.IsTestSuiteFile(dragData as string))
                    {
                        e.Effects = DragDropEffects.Move;
                        e.Handled = true;
                    }
                }
            }
        }

        /// <summary>
        /// The suite configurator window_ on drop.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnSuiteConfiguratorWindowDrop(object sender, DragEventArgs e)
        {
            var dataFormats = e.Data.GetFormats();
            foreach (var dataFormat in dataFormats)
            {
                if ("System.String" == dataFormat)
                {
                    var dragData = e.Data.GetData("System.String");
                    if (this.IsTestSuiteFile(dragData as string))
                    {
                        this.UnloadControlDocument();

                        var defaultRootTestSuite = Path.GetFileNameWithoutExtension(dragData as string);

                        var testSuite = new TestSuite { Name = defaultRootTestSuite, TestDefinition = TestDefinition.UserDefined };

                        this.LoadControlDocument(testSuite, dragData as string);
                        e.Handled = true;
                    }
                }
            }
        }

        /// <summary>
        /// The suite configurator window_ on size changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnSuiteConfiguratorWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var si = sender as UserControl;

            if (si != null)
            {
                this.SuiteConfiguratorControl.Height = si.ActualHeight;
            }
        }

        #endregion
    }
}