// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceTypeTestProject.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData
{
    using System;

    /// <summary>
    /// The test project.
    /// </summary>
    [Serializable]
    public class DeviceTypeTestProject : IDisposable
    {
        #region Fields

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        private string executionPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceTypeTestProject"/> class.
        /// </summary>
        public DeviceTypeTestProject()
        {
            this.ExecutionPath = string.Empty;
            this.FirmwareInformationAssembly = string.Empty;
            //this.DeviceTypeTestProjectPath = string.Empty;
            //this.DeviceTypeTestProjectOutputPath = string.Empty;
            this.ProjectExportPath = string.Empty;
            this.Name = string.Empty;
            this.ExportTestResultAssembly = string.Empty;
            this.ReportOutputPath = string.Empty;
            //this.TemplatePath = string.Empty;
            this.TemplateVersion = string.Empty;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the assembly directory.
        /// </summary>
        public string ExecutionPath
        {
            get
            {
                return this.executionPath;
            }
            set
            {
                this.executionPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the firmware information assembly.
        /// PC spezifische Implementierung der DeviceTypeTestProject Configuration
        /// </summary>
        public string FirmwareInformationAssembly { get; set; }

        

        /// <summary>
        /// Gets or sets the device type test project output location.
        /// </summary>
        //public string DeviceTypeTestProjectOutputPath { get; set; }

        /// <summary>
        /// Gets or sets the project report export directory.
        /// </summary>
        public string ProjectExportPath { get; set; }

        /// <summary>
        /// Gets or sets the project output directory.
        /// </summary>
        public string ExportTestResultAssembly { get; set; }

        /// <summary>
        /// Gets or sets the name of tester.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the report output path.
        /// </summary>
        public string ReportOutputPath { get; set; }

        /// <summary>
        /// Gets or sets the project template directory.
        /// </summary>
        /// Kann raus ist nur noch zu Kompatibilität Zwecke drin 
        public string TemplatePath { get; set; }

        ///// <summary>
        ///// Gets or sets the device type test project directory.
        ///// </summary>
        /// Kann raus ist nur noch zu Kompatibilität Zwecke drin 
        public string DeviceTypeTestProjectPath { get; set; }

        /// <summary>
        /// Gets or sets the template version.
        /// </summary>
        public string TemplateVersion { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.disposed = true;
                }
            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}