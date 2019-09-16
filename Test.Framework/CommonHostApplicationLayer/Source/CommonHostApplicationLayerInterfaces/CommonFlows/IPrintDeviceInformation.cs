// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPrintInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
    ///     Provides methods for printing device information
    /// </summary>
    public interface IPrintDeviceInformation
    {
        /// <summary>
        /// Prints a device report; This function only supports printing to a file
        /// </summary>
        /// <param name="filePathAndName">Path and file name</param>
        /// <param name="timeoutInMilliseconds">The timeout in milliseconds. Be aware that printing can take several minutes.</param>
        /// <returns>true in case of success, false in case of an error</returns>
        bool Run(string filePathAndName, int timeoutInMilliseconds);
    }
}