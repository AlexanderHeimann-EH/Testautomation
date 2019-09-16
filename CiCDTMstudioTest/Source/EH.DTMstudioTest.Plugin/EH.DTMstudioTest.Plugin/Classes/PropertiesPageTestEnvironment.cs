// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertiesPageTestEnvironment.cs" company="Endress+Hauser Process Solutions AG">
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
    using System.Drawing.Design;
    using System.Runtime.InteropServices;

    using EH.DTMstudioTest.Template.Attributes;
    using EH.DTMstudioTest.Template.Editors;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Project;

    /// <summary>
    /// The propertie page test environment.
    /// </summary>
    [ComVisible(true)]
    [Guid(GuidList.GuidPropertiesPageTestEnvironmentString)]
    //[TypeConverter(typeof(PropertySorter))]
    public class PropertiesPageTestEnvironment : SettingsPage
    {
        /// <summary>
        /// The please select file.
        /// </summary>
        private const string PleaseSelectFile = "<Please select a file>";

        #region Fields

        #region OperatingSystem

        /// <summary>
        /// The operating system folder.
        /// </summary>
        private string operatingSystemFolder;

        /// <summary>
        /// The operating system bit version.
        /// </summary>
        private Enumerations.OperatingSystemBitVersions operatingSystemBitVersion;

        /// <summary>
        /// The operating system name.
        /// </summary>
        private string operatingSystemName;

        #endregion 

        #region HostApplication

        /// <summary>
        /// The host application folder.
        /// </summary>
        private string hostApplicationFolder;

        /// <summary>
        /// The host application type.
        /// </summary>
        private Enumerations.HostApplicationTypes hostApplicationType;

        /// <summary>
        /// The host application name.
        /// </summary>
        private string hostApplicationName;

        #endregion

        #region Communication

        /// <summary>
        /// The communication folder.
        /// </summary>
        private string communicationFolder;

        /// <summary>
        /// The communication protocol.
        /// </summary>
        private Enumerations.CommunicationProtocols communicationProtocol;

        /// <summary>
        /// The communication device type name.
        /// </summary>
        private string communicationDeviceTypeName;

        #endregion

        #region DeviceFunction

        /// <summary>
        /// The device function folder.
        /// </summary>
        private string deviceFunctionFolder;

        /// <summary>
        /// The device function platform.
        /// </summary>
        private Enumerations.DeviceFunctionPlatforms deviceFunctionPlatform;

        /// <summary>
        /// The device functions package.
        /// </summary>
        private string deviceFunctionsPackage;

        #endregion

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesPageTestEnvironment"/> class.
        /// </summary>
        public PropertiesPageTestEnvironment()
        {
            this.Name = "Test Environment";
            this.communicationFolder = EditorConfiguration.CommunicationFolder;
            this.deviceFunctionFolder = EditorConfiguration.DeviceFunctionsFolder;
            this.hostApplicationFolder = EditorConfiguration.HostApplicationFolder;
            this.operatingSystemFolder = EditorConfiguration.OperatingSystemFolder;
        }

        #endregion

        #region Public Properties

        #region OperatingSystem

        /// <summary>
        /// Gets the operating system name.
        /// </summary>
        [Category("1 Operating System")]
        [DisplayName(@"1.1 Folder")]
        [Description("Folder")]
        [ReadOnly(true)]
        public string OperatingSystemFolder
        {
            get
            {
                return this.operatingSystemFolder;
            }
        }

        /// <summary>
        /// Gets or sets the operating system bit version.
        /// </summary>
        [Category("1 Operating System")]
        [DisplayName(@"1.2 Bit Version")]
        [Description("Bit Version")]
        public Enumerations.OperatingSystemBitVersions OperatingSystemBitVersion
        {
            get
            {
                return this.operatingSystemBitVersion;
            }

            set
            {
                EditorConfiguration.OperatingSystemCategory = value.ToString().Replace("_", string.Empty);
                this.operatingSystemBitVersion = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the operating system name.
        /// </summary>
        [Category("1 Operating System")]
        [DisplayName(@"1.3 Name")]
        [Description("Name")]
        [EditorAttribute(typeof(OperatingSystemNameEditor), typeof(UITypeEditor))]
        public string OperatingSystemName
        {
            get
            {
                return this.GetLatestElementAndRemoveFileExtension(this.operatingSystemName);
            }

            set
            {
                this.operatingSystemName = this.GetLatestElementAndRemoveFileExtension(value);
                this.IsDirty = true;
            }
        }

        #endregion

        #region HostApplication

        /// <summary>
        /// Gets sets the host application folder
        /// </summary>
        [Category("2 Host Application")]
        [DisplayName(@"2.1 Folder")]
        [Description("Folder")]
        [ReadOnly(true)]
        public string HostApplicationFolder
        {
            get
            {
                return this.hostApplicationFolder;
            }
        }

        /// <summary>
        /// Gets or sets the host application type.
        /// </summary>
        [Category("2 Host Application")]
        [DisplayName(@"2.2 Type")]
        [Description("Type")]
        public Enumerations.HostApplicationTypes HostApplicationType
        {
            get
            {
                return this.hostApplicationType;
            }

            set
            {
                EditorConfiguration.HostApplicationCategory = value.ToString();
                this.hostApplicationType = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the host application name and version.
        /// </summary>
        [Category("2 Host Application")]
        [DisplayName(@"2.3 Name + Version")]
        [Description("Name + Version")]
        [EditorAttribute(typeof(HostApplicationNameEditor), typeof(UITypeEditor))]
        public string HostApplicationName
        {
            get
            {
                return this.GetLatestElementAndRemoveFileExtension(this.hostApplicationName);
            }

            set
            {
                this.hostApplicationName = this.GetLatestElementAndRemoveFileExtension(value);
                this.IsDirty = true;
            }
        }

        #endregion

        #region Communication

        /// <summary>
        /// Gets the communication folder
        /// </summary>
        [Category("3 Communication")]
        [DisplayName(@"3.1 Folder")]
        [Description("Folder")]
        [ReadOnly(true)]
        public string CommunicationFolder
        {
            get
            {
                return this.communicationFolder;
            }
        }

        /// <summary>
        /// Gets or sets the communication protocol.
        /// </summary>
        [Category("3 Communication")]
        [DisplayName(@"3.2 Protocol")]
        [Description("Protocol")]
        public Enumerations.CommunicationProtocols CommunicationProtocol
        {
            get
            {
                return this.communicationProtocol;
            }

            set
            {
                EditorConfiguration.CommunicationCategory = value.ToString();
                this.communicationProtocol = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the communication device type name.
        /// </summary>
        [Category("3 Communication")]
        [DisplayName(@"3.3 Device Type Name")]
        [Description("Device Type Name")]
        [EditorAttribute(typeof(CommonicationDeviceTypeEditor), typeof(UITypeEditor))]
        public string CommunicationDeviceTypeName
        {
            get
            {
                return this.GetLatestElementAndRemoveFileExtension(this.communicationDeviceTypeName);
            }

            set
            {
                this.communicationDeviceTypeName = this.GetLatestElementAndRemoveFileExtension(value);
                this.IsDirty = true;
            }
        }

        #endregion

        #region DeviceFunctions

        /// <summary>
        /// Gets the device function folder.
        /// </summary>
        [Category("4 Device Function")]
        [DisplayName(@"4.1 Folder")]
        [Description("Folder")]
        public string DeviceFunctionsFolder
        {
            get
            {
                return this.deviceFunctionFolder;
            }
        }

        /// <summary>
        /// Gets or sets the device function platform.
        /// </summary>
        [Category("4 Device Function")]
        [DisplayName(@"4.2 Platform")]
        [Description("Platform")]
        public Enumerations.DeviceFunctionPlatforms DeviceFunctionPlatform
        {
            get
            {
                return this.deviceFunctionPlatform;
            }

            set
            {
                EditorConfiguration.DeviceFunctionsCategory = value.ToString();
                this.deviceFunctionPlatform = value;
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the device function package.
        /// </summary>
        [Category("4 Device Function")]
        [DisplayName(@"4.3 Package")]
        [Description("Package")]
        [EditorAttribute(typeof(DeviceFunctionPackageEditor), typeof(UITypeEditor))]
        public string DeviceFunctionsPackage
        {
            get
            {
                return this.GetLatestElementAndRemoveFileExtension(this.deviceFunctionsPackage);
            }

            set
            {
                this.deviceFunctionsPackage = this.GetLatestElementAndRemoveFileExtension(value);
                this.IsDirty = true;
            }
        }

        #endregion

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

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationDeviceTypeName != this.communicationDeviceTypeName)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationDeviceTypeName = this.communicationDeviceTypeName;
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationProtocol != this.communicationProtocol.ToString())
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationProtocol = this.communicationProtocol.ToString();
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionPlatform != this.deviceFunctionPlatform.ToString())
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionPlatform = this.deviceFunctionPlatform.ToString();
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

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationType != this.hostApplicationType.ToString())
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationType = this.hostApplicationType.ToString();
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemBitVersion != this.operatingSystemBitVersion.ToString())
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemBitVersion = this.operatingSystemBitVersion.ToString().Replace("_", string.Empty);
                        isDirty = true;
                    }

                    if (projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemName != this.operatingSystemName)
                    {
                        projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemName = this.operatingSystemName;
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
                if (string.IsNullOrEmpty(projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationDeviceTypeName))
                {
                    this.communicationDeviceTypeName = PleaseSelectFile;
                }
                else
                {
                    this.communicationDeviceTypeName = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationDeviceTypeName;
                }

                if (string.IsNullOrEmpty(projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionsPackage))
                {
                    this.deviceFunctionsPackage = PleaseSelectFile;
                }
                else
                {
                    this.deviceFunctionsPackage = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionsPackage;
                }

                if (string.IsNullOrEmpty(projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationName))
                {
                    this.hostApplicationName = PleaseSelectFile;
                }
                else
                {
                    this.hostApplicationName = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationName;
                }

                if (string.IsNullOrEmpty(projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemName) ||
                    projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemName.Equals("unknown"))
                {
                    this.operatingSystemName = PleaseSelectFile;
                }
                else
                {
                    this.operatingSystemName = projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemName;
                }

                if (string.IsNullOrEmpty(projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationProtocol))
                {
                    Enum.TryParse(projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.CommunicationProtocol, out this.communicationProtocol);
                }

                if (string.IsNullOrEmpty(projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionPlatform))
                {
                    Enum.TryParse(projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.DeviceFunctionPlatform, out this.deviceFunctionPlatform);
                }

                if (string.IsNullOrEmpty(projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationType))
                {
                    Enum.TryParse(projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.HostApplicationType, out this.hostApplicationType);
                }

                Enum.TryParse("_" + projectMgr.EHDataManager.DTMstudioTestData.TestEnvironment.OperatingSystemBitVersion, out this.operatingSystemBitVersion);
            }
        }

        #endregion

        #region private methods

        /// <summary>
        /// The get latest element.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetLatestElementAndRemoveFileExtension(string value)
        {
            string buffer = value;
            string[] partsOfPath = buffer.Split('\\');
            return partsOfPath[partsOfPath.Length - 1].Replace(".dll", string.Empty);
        }

        #endregion
    }
}