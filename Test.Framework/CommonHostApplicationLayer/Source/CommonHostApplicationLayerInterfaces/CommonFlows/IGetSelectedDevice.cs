//------------------------------------------------------------------------------
// <copyright file="IGetSelectedDevice.cs" company="Endress+Hauser Process Solutions AG">
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
    /// Provides methods to determine the currently selected device
    /// </summary>
    public interface IGetSelectedDevice
    {
	/// <summary>
	/// Get currently selected device
	/// </summary>
	/// <returns>String with devicname or tag</returns>
        string Run();
    }
}
