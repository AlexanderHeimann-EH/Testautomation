// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameworkComponent.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   CoDIAFramework
//   CWComponents
//   EHComponents
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// CoDIAFramework
    /// CWComponents
    /// EHComponents
    /// </summary>
    [Serializable]
    public class FrameworkComponent : IDisposable
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

        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameworkComponent"/> class.
        /// </summary>
        public FrameworkComponent()
        {
            this.Version = new Version();
            this.Name = string.Empty;
            this.DisplayName = string.Empty;

            this.disposed = false;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="FrameworkComponent"/> class. 
        /// </summary>
        ~FrameworkComponent()
        {
            this.Dispose(false);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }


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

        /// <summary>
        /// The get demo data.
        /// </summary>
        public void GetDemoData()
        {
            this.Name = "Name";
            this.Version = new Version(9, 9, 9, 9);
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
