// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEnvironment.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Dient zur Konfiguration des TestFrameworks und wird im TestProjekt abgefragt.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData
{
    using System;
    using System.Globalization;
    using System.Xml.Serialization;

    /// <summary>
    /// Dient zur Konfiguration des TestFrameworks und wird im TestProjekt abgefragt.
    /// </summary>
    [Serializable]
    public class TestEnvironment : IDisposable
    {
        #region Fields

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The operating system language.
        /// </summary>
        private CultureInfo operatingSystemLanguage;

        /// <summary>
        /// The operating system language name.
        /// </summary>
        private string operatingSystemLanguageString;

        /// <summary>
        /// The communication device type version.
        /// </summary>
        private Version communicationDeviceTypeVersion;

        /// <summary>
        /// The communication device type version string.
        /// </summary>
        private string communicationDeviceTypeVersionString;

        /// <summary>
        /// The host application version.
        /// </summary>
        private Version hostApplicationVersion;

        /// <summary>
        /// The host application version string.
        /// </summary>
        private string hostApplicationVersionString;

        /// <summary>
        /// The operating system version string.
        /// </summary>
        private string operatingSystemVersionString;

        /// <summary>
        /// The operating system version.
        /// </summary>
        private Version operatingSystemVersion;

        #endregion

        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestEnvironment"/> class.
        /// </summary>
        public TestEnvironment()
        {
            this.ComputerName = string.Empty;
            this.CommunicationDeviceTypeName = string.Empty;
            this.CommunicationDeviceTypeVersion = new Version();
            this.CommunicationProtocol = string.Empty;
            this.CommunicationDevice = string.Empty;
            this.DeviceFunctionPlatform = string.Empty;
            this.DeviceFunctionsPackage = string.Empty;
            this.HostApplicationType = string.Empty;
            this.HostApplicationName = string.Empty;
            this.HostApplicationVersion = new Version();
            this.OperatingSystemName = string.Empty;
            this.OperatingSystemBitVersion = string.Empty;
            this.OperatingSystemLanguage = new CultureInfo("de-DE");
            this.OperatingSystemLanguageString = string.Empty;
            this.OperatingSystemServicePack = string.Empty;
            this.OperatingSystemVersion = new Version();
            this.operatingSystemVersionString = string.Empty;

            this.disposed = false;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TestEnvironment"/> class. 
        /// </summary>
        ~TestEnvironment()
        {
            this.Dispose(false);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        public string ComputerName { get; set; }

        /// <summary>
        /// Gets or sets the communication device type name.
        /// </summary>
        public string CommunicationDeviceTypeName { get; set; }

        /// <summary>
        /// Gets or sets the communication device type version.
        /// </summary>
        [XmlIgnore]
        public Version CommunicationDeviceTypeVersion
        {
            get
            {
                return this.communicationDeviceTypeVersion;
            }

            set
            {
                this.communicationDeviceTypeVersion = value;
                this.communicationDeviceTypeVersionString = this.communicationDeviceTypeVersion.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the communication device type version string.
        /// </summary>
        public string CommunicationDeviceTypeVersionString
        {
            get
            {
                return this.communicationDeviceTypeVersionString;
            }

            set
            {
                this.communicationDeviceTypeVersionString = value;
                this.communicationDeviceTypeVersion = new Version(this.communicationDeviceTypeVersionString);
            }
        }

        /// <summary>
        /// Gets or sets the communication protocol.
        /// </summary>
        public string CommunicationProtocol { get; set; }

        /// <summary>
        /// Gets or sets the communication device.
        /// </summary>
        public string CommunicationDevice { get; set; }

        /// <summary>
        /// Gets or sets the device function platform.
        /// </summary>
        public string DeviceFunctionPlatform { get; set; }

        /// <summary>
        /// Gets or sets the device functions package.
        /// </summary>
        public string DeviceFunctionsPackage { get; set; }

        /// <summary>
        /// Gets or sets the host application type.
        /// </summary>
        public string HostApplicationType { get; set; }

        /// <summary>
        /// Gets or sets the host application name.
        /// </summary>
        public string HostApplicationName { get; set; }

        /// <summary>
        /// Gets or sets the host application version.
        /// </summary>
        [XmlIgnore]
        public Version HostApplicationVersion
        {
            get
            {
                return this.hostApplicationVersion;
            }

            set
            {
                this.hostApplicationVersion = value;
                this.hostApplicationVersionString = this.hostApplicationVersion.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the communication device type version string.
        /// </summary>
        public string HostApplicationVersionString
        {
            get
            {
                return this.hostApplicationVersionString;
            }

            set
            {
                this.hostApplicationVersionString = value;
                this.hostApplicationVersion = new Version(this.hostApplicationVersionString);
            }
        }

        /// <summary>
        /// Gets or sets the operating system name.
        /// </summary>
        public string OperatingSystemName { get; set; }

        /// <summary>
        /// Gets or sets the operating system bit version.
        /// </summary>
        public string OperatingSystemBitVersion { get; set; }

        /// <summary>
        /// Gets or sets the operating system language.
        /// </summary>
        [XmlIgnore]
        public CultureInfo OperatingSystemLanguage
        {
            get
            {
                return this.operatingSystemLanguage;
            }

            set
            {
                this.operatingSystemLanguage = value;
                this.operatingSystemLanguageString = value.Name;
            }
        }

        /// <summary>
        /// Gets or sets the operating system language name.
        /// </summary>
        public string OperatingSystemLanguageString
        {
            get
            {
                return this.operatingSystemLanguageString;
            }

            set
            {
                this.operatingSystemLanguageString = value;
                this.OperatingSystemLanguage = new CultureInfo(this.operatingSystemLanguageString);
            }
        }

        /// <summary>
        /// Gets or sets the operating system service pack.
        /// </summary>
        public string OperatingSystemServicePack { get; set; }

        /// <summary>
        /// Gets or sets the operating system version.
        /// </summary>
        [XmlIgnore]
        public Version OperatingSystemVersion
        {
            get
            {
                return this.operatingSystemVersion;
            }

            set
            {
                this.operatingSystemVersion = value;
                this.operatingSystemVersionString = this.operatingSystemVersion.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the communication device type version string.
        /// </summary>
        public string OperatingSystemVersionString
        {
            get
            {
                return this.operatingSystemVersionString;
            }

            set
            {
                this.operatingSystemVersionString = value;
                this.operatingSystemVersion = new Version(this.operatingSystemVersionString);
            }
        }

        #endregion

        #region Public Methods

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

        #region Internal Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        #endregion

        #region Events

        #endregion
    }
}
