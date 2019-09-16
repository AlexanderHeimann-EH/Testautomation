// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFirmwareInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The FirmwareInformation interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.Interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The FirmwareInformation interface.
    /// </summary>
    public interface IFirmwareInformation
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        List<IFirmwareAddInformationItem> AdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets the firmware build number.
        /// </summary>
        string BuildNumber { get; set; }

        /// <summary>
        /// Gets or sets the firmware name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the firmware version.
        /// </summary>
        string Version { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get firmware information.
        /// </summary>
        /// <returns>
        /// The <see cref="IFirmwareInformation"/>.
        /// </returns>
        IFirmwareInformation GetFirmwareInformation();

        #endregion
    }

    /// <summary>
    /// The i add information item.
    /// </summary>
    [Serializable]
    public class IFirmwareAddInformationItem
    {
        #region Fields

        /// <summary>
        /// The key.
        /// </summary>
        public string Key;

        /// <summary>
        /// The value.
        /// </summary>
        public string Value;

        #endregion
    }
}