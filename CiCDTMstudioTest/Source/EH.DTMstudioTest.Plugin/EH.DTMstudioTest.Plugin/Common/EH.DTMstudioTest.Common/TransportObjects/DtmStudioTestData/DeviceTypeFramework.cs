// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceTypeFramework.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Defines the DeviceTypeFramework type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// The device type framework.
    /// </summary>
    [Serializable]
    public class DeviceTypeFramework : IDisposable
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
        /// Initializes a new instance of the <see cref="DeviceTypeFramework"/> class.
        /// </summary>
        public DeviceTypeFramework()
        {
            this.FrameworkComponents = new List<FrameworkComponent>();
            this.Name = string.Empty;
            this.Version = new Version();

            this.disposed = false;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DeviceTypeFramework"/> class. 
        /// </summary>
        ~DeviceTypeFramework()
        {
            this.Dispose(false);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the framework components.
        /// </summary>
        public List<FrameworkComponent> FrameworkComponents { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// The Framework components name
        /// </summary>
        public string Name { get; set; }

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
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

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
                    this.FrameworkComponents = null;

                    this.disposed = true;
                }
            }
        }

        /// <summary>
        /// The get demo data.
        /// </summary>
        public void GetDemoData()
        {
            this.FrameworkComponents = new List<FrameworkComponent>
                                           {
                                               new FrameworkComponent
                                                   {
                                                       Name = "Name",
                                                       Version =
                                                           new Version(
                                                           9, 9, 9, 9)
                                                   },
                                               new FrameworkComponent
                                                   {
                                                       Name = "Name1",
                                                       Version =
                                                           new Version(
                                                           9, 9, 9, 9)
                                                   },
                                               new FrameworkComponent
                                                   {
                                                       Name = "Name2",
                                                       Version =
                                                           new Version(
                                                           9, 9, 9, 9)
                                                   },
                                               new FrameworkComponent
                                                   {
                                                       Name = "Name3",
                                                       Version =
                                                           new Version(
                                                           9, 9, 9, 9)
                                                   },
                                               new FrameworkComponent
                                                   {
                                                       Name = "Name4",
                                                       Version =
                                                           new Version(
                                                           9, 9, 9, 9)
                                                   }
                                           };
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
