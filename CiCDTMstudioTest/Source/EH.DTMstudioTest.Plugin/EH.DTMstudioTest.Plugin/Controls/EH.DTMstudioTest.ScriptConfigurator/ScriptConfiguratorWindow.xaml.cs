// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptConfiguratorWindow.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.ScriptConfigurator
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;

    using EH.DTMstudioTest.Common.Manager;
    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.DTMstudioTest.Common.Utilities.Logging;

    /// <summary>
    /// The script explorer window.
    /// </summary>
    public partial class ScriptConfiguratorWindow : INotifyPropertyChanged
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
        /// Initializes a new instance of the <see cref="ScriptConfiguratorWindow"/> class.
        /// </summary>
        public ScriptConfiguratorWindow()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.InitializeComponent();
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

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        public string ProjectName
        {
            get
            {
                return this.projectName;
            }

            set
            {
                this.projectName = value;

                this.RaisePropertyChanged("ProjectName");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The load control document.
        /// </summary>
        /// <param name="rootFolder">
        ///     The root folder.
        /// </param>
        /// <param name="controlDocPath">
        ///     The control doc path.
        /// </param>
        /// <param name="testLibraryPath">
        ///     The test library path.
        /// </param>
        /// <param name="deviceFunctions"></param>
        public void LoadTestConfiguration(TestCollection rootFolder, string controlDocPath, string testLibraryPath, List<DeviceFunction> deviceFunctions)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.ControlDocumentPath = controlDocPath;
            this.assemblyManager = new AssemblyManager();

            this.assemblyManager.AddPredefinedTestSuitesFromAssembly(rootFolder, testLibraryPath, deviceFunctions);
            this.assemblyManager.LoadControlDocument(rootFolder, controlDocPath);

            this.ScriptConfigurator.LoadTestScriptSelectionTreeControl(this.AssemblyManager.TestConfiguration);
        }

        /// <summary>
        /// The unload control document.
        /// </summary>
        public void UnloadControlDocument()
        {
            this.controlDocumentPath = string.Empty;

            this.assemblyManager = null;

            this.ScriptConfigurator.UnloadTestScriptSelectionTreeControl();
        }

        #endregion

        #region Methods

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
        /// The script configurator window_ on size changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ScriptConfiguratorWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var si = sender as UserControl;

            if (si != null)
            {
                this.ScriptConfigurator.Height = si.ActualHeight;
            }
        }

        #endregion
    }
}