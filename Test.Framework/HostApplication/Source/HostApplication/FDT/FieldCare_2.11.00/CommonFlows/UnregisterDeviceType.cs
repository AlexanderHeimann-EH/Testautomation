//------------------------------------------------------------------------------
// <copyright file="UnregisterDeviceType.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 26.02.2014
 * Time: 10:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.CommonFlows
{
    using System;
    using System.Collections.Generic;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Provides methods to unregister a device type
    /// </summary>
    public class UnregisterDeviceType : IUnregisterDeviceType
    {
        /// <summary>
        /// Removes a device type from the host application device type collection
        /// </summary>
        /// <param name="devices">list of device types to check after they have been removed from the device type collection</param>
        /// <returns>true in case of success;false in case of an error</returns>
        public bool Run(List<string> devices)
        {
            throw new NotImplementedException();
        }
    }
}
