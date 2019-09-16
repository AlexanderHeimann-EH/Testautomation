// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Zander, Jan 
 * Date: 12.02.2014
 * Time: 16:
 * Last: -
 * Reason: -
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.CommonFlows
{
    using System;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Provides methods for adding a device
    /// </summary>
    public class RemoveDevice : IRemoveDevice
    {
        /// <summary>
        /// Removes a device from the network
        /// </summary>
        /// <param name="parent">node, to add device to</param>
        /// <param name="device">unique device name of device to add to parent node</param>
        /// <returns>true in case of success, false in case of an error</returns>
        public bool Run(string parent, string device)
        {
            throw new NotImplementedException();
        }
    }
}