// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertiesPageDTMstudioTest.cs" company="Endress+Hauser Process Solutions AG">
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
    [Guid(GuidList.guidPropertiesPageDTProjectString)]
    public class PropertiesPageDTMstudioTest : SettingsPage
    {
        #region Fields

        /// <summary>
        /// The communication device.
        /// </summary>
        private string communicationDevice;

        /// <summary>
        /// The communication device type name.
        /// </summary>
        private string communicationDeviceTypeName;

        /// <summary>
        /// The communication protocol.
        /// </summary>
        private string communicationProtocol;

        /// <summary>
        /// The company.
        /// </summary>
        private string company;

        /// <summary>
        /// The computer name.
        /// </summary>
        private string computerName;

        /// <summary>
        /// The device function platform.
        /// </summary>
        private string deviceFunctionPlatform;

        /// <summary>
        /// The device functions package.
        /// </summary>
        private string deviceFunctionsPackage;

        /// <summary>
        /// The device id.
        /// </summary>
        private string deviceId;

        /// <summary>
        /// The device serial number.
        /// </summary>
        private string deviceSerialNumber;

        /// <summary>
        /// The host application name.
        /// </summary>
        private string hostApplicationName;

        /// <summary>
        /// The host application type.
        /// </summary>
        private string hostApplicationType;

        /// <summary>
        /// The name of tester.
        /// </summary>
        private string nameOfTester;

        /// <summary>
        /// The operating system bit version.
        /// </summary>
        private string operatingSystemBitVersion;

        /// <summary>
        /// The operating system language.
        /// </summary>
        private string operatingSystemLanguage;

        /// <summary>
        /// The operating system name.
        /// </summary>
        private string operatingSystemName;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesPageDTMstudioTest"/> class.
        /// </summary>
        public PropertiesPageDTMstudioTest()
        {
            this.Name = "DTM studio Test Properties";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the communication device.
        /// </summary>
        [DisplayName(@"Communication Device")]
        [Description("Communication Device")]
        [Category("Test Environment")]
        public string CommunicationDevice
        {
            get
            {
                return this.communicationDevice;
            }

            set
            {
                this.communicationDevice = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the communication device type name.
        /// </summary>
        [DisplayName(@"Communication Device Type Name")]
        [Description("Communication Device Type Name")]
        [Category("Test Environment")]
        [DefaultValue("Default Value")]
        public string CommunicationDeviceTypeName
        {
            get
            {
                return this.communicationDeviceTypeName;
            }

            set
            {
                this.communicationDeviceTypeName = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Communication Protocol")]
        [Description("Communication Protocol")]
        [Category("Test Environment")]
        public string CommunicationProtocol
        {
            get
            {
                return this.communicationProtocol;
            }

            set
            {
                this.communicationProtocol = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Company")]
        [Description("Company")]
        [Category("Report Data")]
        public string Company
        {
            get
            {
                return this.company;
            }

            set
            {
                this.company = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Computer Name")]
        [Description("Computer Name")]
        [Category("Test Environment")]
        public string ComputerName
        {
            get
            {
                return this.computerName;
            }

            set
            {
                this.computerName = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Device Function Platform")]
        [Description("Device Function Platform")]
        [Category("Test Environment")]
        public string DeviceFunctionPlatform
        {
            get
            {
                return this.deviceFunctionPlatform;
            }

            set
            {
                this.deviceFunctionPlatform = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Device Functions Package")]
        [Description("Device Functions Package")]
        [Category("Test Environment")]
        public string DeviceFunctionsPackage
        {
            get
            {
                return this.deviceFunctionsPackage;
            }

            set
            {
                this.deviceFunctionsPackage = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Device ID")]
        [Description("Device ID")]
        [Category("Report Data")]
        public string DeviceId
        {
            get
            {
                return this.deviceId;
            }

            set
            {
                this.deviceId = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Device Serial Number")]
        [Description("Device Serial Number")]
        [Category("Report Data")]
        public string DeviceSerialNumber
        {
            get
            {
                return this.deviceSerialNumber;
            }

            set
            {
                this.deviceSerialNumber = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Host Application Name")]
        [Description("Host Application Name")]
        [Category("Test Environment")]
        public string HostApplicationName
        {
            get
            {
                return this.hostApplicationName;
            }

            set
            {
                this.hostApplicationName = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Host Application Type")]
        [Description("Host Application Type")]
        [Category("Test Environment")]
        public string HostApplicationType
        {
            get
            {
                return this.hostApplicationType;
            }

            set
            {
                this.hostApplicationType = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Name of Tester")]
        [Description("Name of Tester")]
        [Category("Report Data")]
        public string NameOfTester
        {
            get
            {
                return this.nameOfTester;
            }

            set
            {
                this.nameOfTester = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Operating System Bit Version")]
        [Description("Operating System Bit Version")]
        [Category("Test Environment")]
        public string OperatingSystemBitVersion
        {
            get
            {
                return this.operatingSystemBitVersion;
            }

            set
            {
                this.operatingSystemBitVersion = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Operating System Language")]
        [Description("Operating System Language")]
        [Category("Test Environment")]
        public string OperatingSystemLanguage
        {
            get
            {
                return this.operatingSystemLanguage;
            }

            set
            {
                this.operatingSystemLanguage = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [DisplayName(@"Operating System Name")]
        [Description("Operating System Name")]
        [Category("Test Environment")]
        public string OperatingSystemName
        {
            get
            {
                return this.operatingSystemName;
            }

            set
            {
                this.operatingSystemName = value;
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

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationDevice != this.communicationDevice)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationDevice = this.communicationDevice;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationDeviceTypeName != this.communicationDeviceTypeName)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationDeviceTypeName = this.communicationDeviceTypeName;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationProtocol != this.communicationProtocol)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationProtocol = this.communicationProtocol;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.ComputerName != this.computerName)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.ComputerName = this.computerName;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionPlatform != this.deviceFunctionPlatform)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionPlatform = this.deviceFunctionPlatform;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionsPackage != this.deviceFunctionsPackage)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionsPackage = this.deviceFunctionsPackage;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationName != this.hostApplicationName)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationName = this.hostApplicationName;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationType != this.hostApplicationType)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationType = this.hostApplicationType;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemBitVersion != this.operatingSystemBitVersion)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemBitVersion = this.operatingSystemBitVersion;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemLanguageString != this.operatingSystemLanguage)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemLanguageString = this.operatingSystemLanguage;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemName != this.operatingSystemName)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemName = this.operatingSystemName;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.ReportData.DeviceId != this.DeviceId)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.ReportData.DeviceId = this.DeviceId;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.ReportData.Company != this.company)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.ReportData.Company = this.company;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.ReportData.DeviceSerialNumber != this.deviceSerialNumber)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.ReportData.DeviceSerialNumber = this.deviceSerialNumber;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.ReportData.NameOfTester != this.nameOfTester)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.ReportData.NameOfTester = this.nameOfTester;
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
                this.communicationDevice = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationDevice;
                this.communicationDeviceTypeName = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationDeviceTypeName;
                this.communicationProtocol = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationProtocol;
                this.computerName = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.ComputerName;
                this.deviceFunctionPlatform = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionPlatform;
                this.deviceFunctionsPackage = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionsPackage;
                this.hostApplicationName = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationName;
                this.hostApplicationType = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationType;
                this.operatingSystemBitVersion = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemBitVersion;
                this.operatingSystemLanguage = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemLanguageString;
                this.operatingSystemName = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemName;
                this.company = projectMgr.EHDataManager.DTMstudioTestData.ReportData.Company;
                this.DeviceId = projectMgr.EHDataManager.DTMstudioTestData.ReportData.DeviceId;
                this.company = projectMgr.EHDataManager.DTMstudioTestData.ReportData.Company;
                this.deviceSerialNumber = projectMgr.EHDataManager.DTMstudioTestData.ReportData.DeviceSerialNumber;
                this.nameOfTester = projectMgr.EHDataManager.DTMstudioTestData.ReportData.NameOfTester;
            }
        }

        #endregion
    }
}