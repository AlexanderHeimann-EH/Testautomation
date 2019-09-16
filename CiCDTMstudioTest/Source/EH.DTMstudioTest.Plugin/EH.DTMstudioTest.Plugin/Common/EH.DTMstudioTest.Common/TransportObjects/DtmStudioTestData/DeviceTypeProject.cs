// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceTypeProject.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The device type project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The device type project.
    /// </summary>
    [Serializable]
    public class DeviceTypeProject : IDisposable
    {
        #region Fields

        /// <summary>
        /// The device type project path.
        /// </summary>
        private string deviceTypeProjectPath;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceTypeProject"/> class.
        /// </summary>
        public DeviceTypeProject()
        {
            this.Initialize(string.Empty);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceTypeProject"/> class.
        /// </summary>
        /// <param name="deviceTypeProjectFilePath">
        /// The device Type Project File Path.
        /// </param>
        public DeviceTypeProject(string deviceTypeProjectFilePath)
        {
            this.Initialize(deviceTypeProjectFilePath);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DeviceTypeProject"/> class. 
        /// </summary>
        ~DeviceTypeProject()
        {
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the device functions.
        /// </summary>
        public List<DeviceFunction> DeviceFunctions { get; set; }

        /// <summary>
        /// Gets or sets the device type framework.
        /// </summary>
        public DeviceTypeFramework DeviceTypeFramework { get; set; }

        /// <summary>
        /// Gets the device type project path.
        /// </summary>
        public string DeviceTypeProjectPath
        {
            get
            {
                return this.deviceTypeProjectPath;
            }

            set
            {
                this.deviceTypeProjectPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the FDT device type name.
        /// </summary>
        public string FDTDeviceTypeName { get; set; }

        /// <summary>
        /// Gets or sets the GUID.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

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
                    this.DeviceFunctions = null;
                    this.DeviceTypeFramework = null;

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

        #region Methods

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="deviceTypeProjectFilePath">
        /// The device type project file path.
        /// </param>
        private void Initialize(string deviceTypeProjectFilePath)
        {
            this.deviceTypeProjectPath = deviceTypeProjectFilePath;
            this.DeviceFunctions = new List<DeviceFunction>();
            this.DeviceTypeFramework = new DeviceTypeFramework();
            this.FDTDeviceTypeName = string.Empty;

            this.disposed = false;
        }

        #endregion
    }
}