//------------------------------------------------------------------------------
// <copyright file="ISaveDeviceData.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Zander, Jan 
 * Date: 12.02.2014
 * Time: 16:
 * Last: -
 * Reason: -
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    /// <summary>
    /// Interface for SaveDeviceData
    /// </summary>
    public interface ISaveDeviceData
    {
        /// <summary>
        /// Save device data to hard disk
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <returns>true in case of success, false in case of an error</returns>
        bool Run(string fileName);

        /// <summary>
        /// Save device data to hard disk 
        /// </summary>
        /// <param name="filePath">Path of file</param>
        /// <param name="fileName">Name of file</param>
        /// <returns>true in case of success, false in case of an error</returns>
        bool Run(string filePath, string fileName);

        /// <summary>
        /// Save device data to hard disk 
        /// </summary>
        /// <param name="filePath">Path of file</param>
        /// <param name="fileName">Name of file</param>
        /// <param name="fileFormat">Type of file to be created</param>
        /// <returns>true in case of success, false in case of an error</returns>
        bool Run(string filePath, string fileName, string fileFormat);


    }
}
