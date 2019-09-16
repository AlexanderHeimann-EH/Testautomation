// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFirmwareInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Interfaces
{
    /// <summary>
    /// The FirmwareInformation interface.
    /// </summary>
    public interface IFirmwareInformation
    {
        /// <summary>
        /// Gets or sets the firmware name.
        /// </summary>
        string FirmwareName { get; set; }

        /// <summary>
        /// Gets or sets the firmware version.
        /// </summary>
        string FirmwareVersion { get; set; }

        /// <summary>
        /// Gets or sets the firmware build number.
        /// </summary>
        string FirmwareBuildNumber { get; set; }

        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        string[] AdditionalInformation { get; set; }
    }
}
