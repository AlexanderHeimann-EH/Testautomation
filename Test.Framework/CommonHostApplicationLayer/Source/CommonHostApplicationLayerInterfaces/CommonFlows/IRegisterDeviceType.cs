//------------------------------------------------------------------------------
// <copyright file="IRegisterDeviceType.cs" company="Endress+Hauser Process Solutions AG">
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
    /// Provides methods for registering a device type
    /// </summary>
    public interface IRegisterDeviceType
    {
	/// <summary>
	/// Adds a device type to the host application device type collection
	/// </summary>
        /// <param name="devices">list of device types to check after they have been added to the device type collection</param>
        /// <returns>true in case of success;false in case of an error</returns>
        bool Run(List<string> devices);
    }
}
