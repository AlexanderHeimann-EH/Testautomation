//------------------------------------------------------------------------------
// <copyright file="IWriteDataToDevice.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Provides methods for performing a download
    /// </summary>
    public interface IWriteDataToDevice
    {
        /// <summary>
        /// Writes information to the device (download)
        /// </summary>
        /// <returns>True in case of success, false in case of an error</returns>
        bool Run();

    }
}