// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceFunction.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The device function.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The device function.
    /// </summary>
    [Serializable]
    public class DeviceFunction : IDisposable
    {
        #region Fields

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The version.
        /// </summary>
        private Version version;

        /// <summary>
        /// The version string.
        /// </summary>
        private string versionString;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceFunction"/> class.
        /// </summary>
        public DeviceFunction()
        {
            this.Name = string.Empty;
            this.CompilerVariable = string.Empty;
            this.DisplayName = string.Empty;
            this.Active = false;
            this.Version = new Version();
            this.FrameworkMappingName = string.Empty;
            this.disposed = false;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DeviceFunction"/> class. 
        /// </summary>
        ~DeviceFunction()
        {
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the compiler variable.
        /// </summary>
        public string CompilerVariable { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the framework name.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string FrameworkMappingName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [XmlIgnore]
        public Version Version
        {
            get
            {
                return this.version;
            }

            set
            {
                this.version = value;
                this.versionString = this.Version.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the communication device type version string.
        /// </summary>
        public string VersionString
        {
            get
            {
                return this.versionString;
            }

            set
            {
                this.versionString = value;
                this.version = new Version(this.versionString);
            }
        }

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

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}, DisplayName: {1}, Version: {2},  Active: {3}", base.ToString(), this.DisplayName, this.VersionString, this.Active.ToString());
        }

        #endregion
    }
}
