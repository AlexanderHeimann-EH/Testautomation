// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptExplorerWindow.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The script explorer window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.ScriptExplorer
{
    using System.ComponentModel;
    using System.IO;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;

    using EH.DTMstudioTest.Common.Manager;
    using EH.DTMstudioTest.Common.TransportObjects.AssemblyData;
    using EH.DTMstudioTest.Common.Utilities.Logging;

    /// <summary>
    /// The script explorer window.
    /// </summary>
    public partial class ScriptExplorerWindow : INotifyPropertyChanged
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
        /// Initializes a new instance of the <see cref="ScriptExplorerWindow"/> class.
        /// </summary>
        public ScriptExplorerWindow()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            this.assemblyManager = new AssemblyManager();
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
        /// The load assembly.
        /// </summary>
        /// <param name="assemblyPath">
        /// The assembly path.
        /// </param>
        public void LoadAssembly(string assemblyPath) 
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            var extension = Path.GetExtension(assemblyPath); 
            if (extension != null && extension.ToLower() == ".xml")
            {
                this.ControlDocumentPath = assemblyPath;
            }
            
            this.assemblyManager.AddAssemblies(assemblyPath);

            this.scriptExplorerControl.LoadScriptExplorer(this.AssemblyManager.TestConfiguration);
        }

        /// <summary>
        /// The unload control document.
        /// </summary>
        /// <param name="assemblyPath">
        /// The assembly path.
        /// </param>
        public void UnloadAssembly(string assemblyPath)
        {
            this.controlDocumentPath = string.Empty;
            
            this.scriptExplorerControl.UnloadScriptExplorer();

            this.assemblyManager.UnloadAssembly(assemblyPath);

            this.scriptExplorerControl.LoadScriptExplorer(this.AssemblyManager.TestConfiguration);
        }

        /// <summary>
        /// The unload explorer.
        /// </summary>
        public void UnloadExplorer()
        {
            this.controlDocumentPath = string.Empty;

            this.assemblyManager.Unload();

            this.scriptExplorerControl.UnloadScriptExplorer();
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
                this.scriptExplorerControl.Height = si.ActualHeight;
            }
        }

        #endregion
    }
}