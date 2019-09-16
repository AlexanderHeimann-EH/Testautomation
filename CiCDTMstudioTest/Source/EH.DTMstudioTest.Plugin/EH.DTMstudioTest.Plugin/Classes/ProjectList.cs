// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectList.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The eh project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;

    using EH.DTMstudioTest.Common.Tools;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.DTMstudioTest.Common.Utilities.Helper;
    using EH.DTMstudioTest.Common.Utilities.Logging;

    using EnvDTE;

    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.Win32;

    /// <summary>
    /// The eh project.
    /// </summary>
    public class EHProject : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// The assembly path.
        /// </summary>
        private string assemblyPath;

        /// <summary>
        /// The date modified.
        /// </summary>
        private DateTime dateModified;

        /// <summary>
        /// The device functions.
        /// </summary>
        private List<DeviceFunction> deviceFunctions;

        /// <summary>
        /// The project.
        /// </summary>
        private Project project;

        /// <summary>
        /// The project file.
        /// </summary>
        private string projectFile;

        /// <summary>
        /// The project guid.
        /// </summary>
        private string projectTypeGuid;

        /// <summary>
        /// The project guid.
        /// </summary>
        private string projectUniqueName;

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
        public string ControlDocumentPath { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime DateModified
        {
            get
            {
                return this.dateModified;
            }

            set
            {
                this.dateModified = value;
                this.RaisePropertyChanged("DateModified");
            }
        }

        /// <summary>
        /// Gets or sets the device functions.
        /// </summary>
        public List<DeviceFunction> DeviceFunctions
        {
            get
            {
                return this.deviceFunctions;
            }

            set
            {
                this.deviceFunctions = value;
                this.RaisePropertyChanged("DeviceFunctions");
            }
        }

        /// <summary>
        /// Gets or sets the assembly path.
        /// </summary>
        public string FullAssemblyPath
        {
            get
            {
                return this.assemblyPath;
            }

            set
            {
                this.assemblyPath = value;
                this.RaisePropertyChanged("FullAssemblyPath");
            }
        }

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        public Project Project
        {
            get
            {
                return this.project;
            }

            set
            {
                this.project = value;
                this.RaisePropertyChanged("Project");
            }
        }

        /// <summary>
        /// Gets or sets the project file.
        /// </summary>
        public string ProjectFile
        {
            get
            {
                return this.projectFile;
            }

            set
            {
                this.projectFile = value;
                this.RaisePropertyChanged("ProjectFile");
            }
        }

        /// <summary>
        /// Gets or sets the project guid.
        /// </summary>
        public string ProjectTypeGuid
        {
            get
            {
                return this.projectTypeGuid;
            }

            set
            {
                this.projectTypeGuid = value;
                this.RaisePropertyChanged("ProjectTypeGuid");
            }
        }

        /// <summary>
        /// Gets or sets the project guid.
        /// </summary>
        public string ProjectUniqueName
        {
            get
            {
                return this.projectUniqueName;
            }

            set
            {
                this.projectUniqueName = value;
                this.RaisePropertyChanged("ProjectUniqueName");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The has property changed.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool HasPropertyChanged()
        {
            if (this.PropertyChanged != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The is project type.
        /// </summary>
        /// <param name="projectGuid">
        /// The project guid.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsProjectType(string projectGuid)
        {
            if (this.ProjectTypeGuid.ToUpper().IndexOf(projectGuid.ToUpper(), StringComparison.Ordinal) > -1)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property.
        /// </param>
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.HasPropertyChanged())
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

    /// <summary>
    /// The property changed event args.
    /// </summary>
    public class ProjectChangedEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectChangedEventArgs"/> class. 
        /// Initializes a new instance of the <see cref="PropertyChangedEventArgs"/> class.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <param name="propertyName">
        /// The property Name.
        /// </param>
        public ProjectChangedEventArgs(EHProject project, string propertyName)
        {
            this.Project = project;
            this.PropertyName = propertyName;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        public EHProject Project { get; set; }

        /// <summary>
        /// Gets or sets the property name.
        /// </summary>
        public string PropertyName { get; set; }

        #endregion
    }

    /// <summary>
    /// The project list.
    /// </summary>
    public class EHProjectList : ObservableCollection<EHProject>
    {
        #region Public Events

        /// <summary>
        /// The project changed.
        /// </summary>
        public event EventHandler<ProjectChangedEventArgs> ProjectChanged;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add project.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddProject(Project project)
        {
            try
            {
                var ehProject = this.CreateEHProject(project);

                if (ehProject != null)
                {
                    if (!this.ProjectExist(ehProject))
                    {
                        this.Add(ehProject);
                        return true;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.ErrorEx(this, exception, exception.Message);
                return false;
            }

            return false;
        }

        /// <summary>
        /// The add project.
        /// </summary>
        /// <param name="ehProject">
        /// The eh project.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddProject(EHProject ehProject)
        {
            if (ehProject != null)
            {
                if (!this.ProjectExist(ehProject) && File.Exists(ehProject.FullAssemblyPath))
                {
                    this.Add(ehProject);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The get eh project.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="EHProject"/>.
        /// </returns>
        public EHProject CreateEHProject(Project project)
        {
            var ehProject = new EHProject();

            ehProject.Project = project;
            ehProject.ProjectTypeGuid = project.Kind;
            ehProject.ProjectUniqueName = project.UniqueName;
            ehProject.ProjectFile = project.FullName;

            if (!ehProject.IsProjectType(ProjectTypeGuids.CSharp) && !ehProject.IsProjectType(ProjectTypeGuids.DTTestProject) && !ehProject.IsProjectType(ProjectTypeGuids.DTProject))
            {
                return null;
            }

            if (ehProject.IsProjectType(ProjectTypeGuids.DTTestProject))
            {
                var controlDocumentPath = Path.Combine(new[] { Path.GetDirectoryName(project.FullName), "ControlDocument.xml" });
                if (File.Exists(controlDocumentPath))
                {
                    ehProject.ControlDocumentPath = controlDocumentPath;
                }
                else
                {
                    return null;
                }
            }
            else if (ehProject.IsProjectType(ProjectTypeGuids.CSharp))
            {
                ehProject.FullAssemblyPath = GetFullAssemblyPath(project);
            }

            if (File.Exists(ehProject.FullAssemblyPath))
            {
                ehProject.DateModified = File.GetLastWriteTime(ehProject.FullAssemblyPath);
            }

            ehProject.PropertyChanged += this.OnProjectPropertyChanged;

            return ehProject;
        }

        /// <summary>
        /// The get eh project from list.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="EHProject"/>.
        /// </returns>
        private EHProject GetEHProjectFromList(Project project)
        {
            foreach (var ehProject in this.Items)
            {
                if (ehProject.ProjectUniqueName == project.UniqueName)
                {
                    return ehProject;
                }
            }

            return null;
        }

        /// <summary>
        /// The get eh projects.
        /// </summary>
        /// <param name="projectTypeGuid">
        /// The project type guid.
        /// </param>
        /// <returns>
        /// The <see cref="EHProject"/>.
        /// </returns>
        public List<EHProject> GetEHProjects(string projectTypeGuid)
        {
            return this.Items.Where(item => item.IsProjectType(projectTypeGuid)).ToList();
        }

        /// <summary>
        /// The get projects in solution.
        /// </summary>
        /// <returns>
        /// The <see cref="IVsHierarchy"/>.
        /// </returns>
        /// <summary>
        /// The find out binary name by extension.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetOutputPathByProject(Project project)
        {
            try
            {
                if (project != null && project.ConfigurationManager != null && project.ConfigurationManager.ActiveConfiguration != null)
                {
                    var ac = project.ConfigurationManager.ActiveConfiguration;

                    return ac.Properties.Item("OutputPath").Value.ToString();
                }
            }
            catch (InvalidOperationException)
            {
                // Can't figure out the active configuration.  Perhaps during solution load, or in a unit test.
            }
            catch (COMException)
            {
                // We may be in solution load and don't have an active config yet.
            }

            return string.Empty;
        }

        /// <summary>
        /// The has property changed.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool HasPropertyChanged()
        {
            if (this.ProjectChanged != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The project exist.
        /// </summary>
        /// <param name="ehProject">
        /// The eh project.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ProjectExist(EHProject ehProject)
        {
            foreach (var project in this.Items)
            {
                if (project.ProjectUniqueName == ehProject.ProjectUniqueName)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The remove project.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool RemoveProject(Project project)
        {
            var ehProject = this.GetEHProjectFromList(project);

            if (ehProject != null)
            {
                this.Remove(ehProject);
                return true;
            }

            return false;
        }

        /// <summary>
        /// The has project changes.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="bool?"/>.
        /// </returns>
        public bool? UpdateProject(Project project)
        {
            if (project == null)
            {
                return null;
            }

            var ehProject = this.CreateEHProject(project);

            if (ehProject == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(ehProject.FullAssemblyPath) && File.Exists(ehProject.FullAssemblyPath))
            {
                foreach (var item in this.Items)
                {
                    if (item.ProjectUniqueName == ehProject.ProjectUniqueName)
                    {
                        if (item.DateModified == ehProject.DateModified && item.FullAssemblyPath == ehProject.FullAssemblyPath && item.ControlDocumentPath == ehProject.ControlDocumentPath && item.ProjectTypeGuid == ehProject.ProjectTypeGuid)
                        {
                            return false;
                        }

                        item.DateModified = ehProject.DateModified;
                        item.FullAssemblyPath = ehProject.FullAssemblyPath;
                        item.ControlDocumentPath = ehProject.ControlDocumentPath;
                        item.ProjectTypeGuid = ehProject.ProjectTypeGuid;
                        item.Project = ehProject.Project;

                        return true;
                    }
                }
            }

            return null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get full assembly path.
        /// </summary>
        /// <param name="vsProject">
        /// The vs project.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetFullAssemblyPath(Project vsProject)
        {
            string fullPath = vsProject.Properties.Item("FullPath").Value.ToString();

            string outputPath = vsProject.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value.ToString();

            string outputDir = Path.Combine(fullPath, outputPath);

            foreach (var i in vsProject.Properties)
            {
                Console.WriteLine(i.ToString());
            }

            string outputFileName = vsProject.Properties.Item("OutputFileName").Value.ToString();

            string assemblyPath = Path.Combine(outputDir, outputFileName);

            return assemblyPath;
        }

        /// <summary>
        /// The get test framework install path.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetTestFrameworkInstallPath()
        {
            Log.Enter(this, "GetTestFrameworkInstallPath");

            var installPath = (string)Registry.GetValue(ConstStrings.TestFrameworkRegistryPath, ConstStrings.TestFrameworkRegistryKey, null);

            Log.Info(this, string.Format("TestFramework installation path: {0}", installPath));
            return installPath;
        }

        /// <summary>
        /// The project property changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnProjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.HasPropertyChanged())
            {
                this.ProjectChanged(this, new ProjectChangedEventArgs(sender as EHProject, e.PropertyName));
            }
        }

        #endregion
    }
}