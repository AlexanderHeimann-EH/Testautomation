// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertiesPageInfrastructure.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The DT project properties page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Template
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Project;

    /// <summary>
    /// The DT project properties page.
    /// </summary>
    [ComVisible(true)]
    [Guid(GuidList.guidPropertiesPageInfrastructureString)]
    public class PropertiesPageInfrastructure : SettingsPage
    {
        #region Fields

        /// <summary>
        /// The configuration assembly.
        /// </summary>
        private string firmwareInformationAssembly;

        /// <summary>
        /// The export directory.
        /// </summary>
        private string exportDirectory;

        /// <summary>
        /// The test output assembly.
        /// </summary>
        private string exportTestResultAssembly;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesPageInfrastructure"/> class. 
        /// </summary>
        public PropertiesPageInfrastructure()
        {
            this.Name = "Infrastructure Properties";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the configuration assembly.
        /// </summary>
        [DisplayName(@"Firmware Information Assembly")]
        [Description("Firmware Information Assembly")]
        [Category("Infrastructure")]
        public string FirmwareInformationAssembly
        {
            get
            {
                return this.firmwareInformationAssembly;
            }

            set
            {
                this.firmwareInformationAssembly = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the communication device.
        /// </summary>
        [DisplayName(@"Export Directory")]
        [Description("Export Directory")]
        [Category("Infrastructure")]
        public string ExportDirectory
        {
            get
            {
                return this.exportDirectory;
            }

            set
            {
                this.exportDirectory = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the test output assembly.
        /// </summary>
        [DisplayName(@"Export Test Result Assembly")]
        [Description("Export Test Result Assembly")]
        [Category("Infrastructure")]
        public string ExportTestResultAssembly
        {
            get
            {
                return this.exportTestResultAssembly;
            }

            set
            {
                this.exportTestResultAssembly = value;
                this.IsDirty = true;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The apply changes.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected override int ApplyChanges()
        {
            var result = VSConstants.S_OK;

            var projectMgr = this.ProjectMgr as DTTestProjectNode;
            try
            {
                if (projectMgr != null)
                {
                    var isDirty = false;

                    if (projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ProjectExportPath != this.exportDirectory)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ProjectExportPath = this.exportDirectory;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.FirmwareInformationAssembly != this.firmwareInformationAssembly)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.FirmwareInformationAssembly = this.firmwareInformationAssembly;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ExportTestResultAssembly != this.exportTestResultAssembly)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ExportTestResultAssembly = this.exportTestResultAssembly;
                        isDirty = true;
                    }
                    
                    if (isDirty)
                    {
                        projectMgr.SaveConfiguration();
                    }

                    this.IsDirty = false;
                }
                else
                {
                    result = VSConstants.S_FALSE;
                }
            }
            catch (Exception)
            {
                result = VSConstants.S_FALSE;
            }

            return result;
        }

        /// <summary>
        /// The bind properties.
        /// </summary>
        protected override void BindProperties()
        {
            var projectMgr = this.ProjectMgr as DTTestProjectNode;
            if (projectMgr != null)
            {
                this.exportDirectory = projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ProjectExportPath;
                this.firmwareInformationAssembly = projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.FirmwareInformationAssembly;
                this.exportTestResultAssembly = projectMgr.EHDataManager.DTMstudioTestData.DeviceTypeTestProject.ExportTestResultAssembly;
            }
        }

        #endregion
    }
}