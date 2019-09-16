//------------------------------------------------------------------------------
// <copyright file="ISelectDevice.cs" company="Endress+Hauser Process Solutions AG">
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
    /// <summary>
    /// Provides methods for selecting a device
    /// </summary>
    public interface ISelectDevice
    {
	/// <summary>
	/// Select a specific device
	/// </summary>
	/// <param name="device">Device to select</param>
	/// <returns>true in case of success, false in case of an error</returns>
        bool Run(string device);
    }
}
