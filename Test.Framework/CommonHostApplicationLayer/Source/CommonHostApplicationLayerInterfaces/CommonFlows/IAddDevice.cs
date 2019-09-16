// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAddDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for adding a device
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides methods for adding a device
    /// </summary>
    public interface IAddDevice
    {
        #region Public Methods and Operators

        /// <summary>
        /// Add a device type to network
        /// </summary>
        /// <param name="parent">
        /// node, to add device to
        /// </param>
        /// <param name="device">
        /// unique device name of device to add to parent node
        /// </param>
        /// <returns>
        /// true in case of success, false in case of an error
        /// </returns>
        bool Run(string parent, string device);

        /// <summary>
        /// Add a device type to network
        /// </summary>
        /// <param name="parent">
        /// node, to add device to
        /// </param>
        /// <param name="device">
        /// unique device name of device to add to parent node
        /// </param>
        /// <param name="configurationSettings">
        /// communication settings for comm devices
        /// </param>
        /// <returns>
        /// true in case of success, false in case of an error
        /// </returns>
        bool Run(string parent, string device, List<string> configurationSettings);

        #endregion
    }
}