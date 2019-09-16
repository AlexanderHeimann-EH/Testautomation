// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FirmwareInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright � Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Defines the FirmwareInformation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData
{
    using System;
    using System.Collections.Generic;

    using EH.DTMstudioTest.Common.Interfaces;

    /// <summary>
    /// The firmware information.
    /// </summary>
    [Serializable]
    public class FirmwareInformation : IFirmwareInformation
    {
        #region Fields

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FirmwareInformation"/> class.
        /// </summary>
        public FirmwareInformation()
        {
            this.Name = string.Empty;
            this.Version = string.Empty;
            this.BuildNumber = string.Empty;
            this.AdditionalInformation = new List<IFirmwareAddInformationItem>();

            this.disposed = false;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="FirmwareInformation"/> class. 
        /// </summary>
        ~FirmwareInformation()
        {
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        public List<IFirmwareAddInformationItem> AdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets the firmware build number.
        /// </summary>
        public string BuildNumber { get; set; }

        /// <summary>
        /// Gets or sets the firmware name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the firmware version.
        /// </summary>
        public string Version { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The clone.
        /// </summary>
        /// <param name="firmware">
        /// The firmware.
        /// </param>
        public void Clone(IFirmwareInformation firmware)
        {
            if (firmware != null)
            {
                this.BuildNumber = firmware.BuildNumber;

                this.Name = firmware.Name;
                this.Version = firmware.Version;

                this.AdditionalInformation.Clear();

                foreach (var addInfo in firmware.AdditionalInformation)
                {
                    this.AdditionalInformation.Add(new IFirmwareAddInformationItem { Key = addInfo.Key, Value = addInfo.Value });
                }
            }
            else
            {
                this.BuildNumber = string.Empty;
                this.Name = string.Empty;
                this.Version = string.Empty;
                this.AdditionalInformation.Clear();
            }
        }

        /// <summary>
        /// The get firmware information.
        /// </summary>
        /// <returns>
        /// The <see cref="IFirmwareInformation"/>.
        /// </returns>
        public FirmwareInformation Copy()
        {
            var result = new FirmwareInformation { AdditionalInformation = this.AdditionalInformation, BuildNumber = this.BuildNumber, Name = this.Name, Version = this.Version };

            return result;
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
        /// The get firmware information.
        /// </summary>
        /// <returns>
        /// The <see cref="FirmwareInformation"/>.
        /// </returns>
        public IFirmwareInformation GetFirmwareInformation()
        {
            return this as FirmwareInformation;
        }

        #endregion
    }
}