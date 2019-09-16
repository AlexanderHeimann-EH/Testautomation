//------------------------------------------------------------------------------
// <copyright file="RestoreDeviceData.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.CI.CommonFlows
{
    using System;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Restore Device Data
    /// </summary>
    public class RestoreDeviceData : IRestoreDeviceData
    {
        /// <summary>
        /// Read device data from hard disk
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <returns>true in case of success, false in case of an error</returns>
        public bool Run(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read device data from hard disk 
        /// </summary>
        /// <param name="filePath">Path of file</param>
        /// <param name="fileName">Name of file</param>
        /// <returns>true in case of success, false in case of an error</returns>
        public bool Run(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}