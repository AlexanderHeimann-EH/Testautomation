//------------------------------------------------------------------------------
// <copyright file="IUnegisterDeviceType.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Zander, Jan 
 * Date: 12.02.2014
 * Time: 16:00
 * Last: -
 * Reason: -
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides methods to unregister a device type
    /// </summary>
    public interface IUnregisterDeviceType
    {
	/// <summary>
	/// Removes a device type from the host application device type collection
	/// </summary>
        /// <param name="devices">list of device types to check after they have been removed from the device type collection</param>
        /// <returns>true in case of success;false in case of an error</returns>
        bool Run(List<string> devices);
    }
}
