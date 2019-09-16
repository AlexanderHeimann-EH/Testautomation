//------------------------------------------------------------------------------
// <copyright file="SaveDeviceData.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V20901.CommonFlows
{
    using System;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Save Device Data
    /// </summary>
    public class SaveDeviceData : ISaveDeviceData
    {
        /// <summary>
        /// Save device data to hard disk
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <returns>true in case of success, false in case of an error</returns>
        public bool Run(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save device data to hard disk 
        /// </summary>
        /// <param name="filePath">Path of file</param>
        /// <param name="fileName">Name of file</param>
        /// <returns>true in case of success, false in case of an error</returns>
        public bool Run(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save device data to hard disk 
        /// </summary>
        /// <param name="filePath">Path of file</param>
        /// <param name="fileName">Name of file</param>
        /// <param name="fileFormat">Type of file to be created</param>
        /// <returns>true in case of success, false in case of an error</returns>
        public bool Run(string filePath, string fileName, string fileFormat)
        {
            throw new NotImplementedException();
        }
    }
}
