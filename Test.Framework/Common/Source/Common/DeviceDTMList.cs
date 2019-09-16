//------------------------------------------------------------------------------
// <copyright file="DeviceDTMList.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 02.02.2012
 * Time: 07:45 

 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Provides function handle a DeviceDTMList as input for testing
    /// </summary>
    public class DeviceDTMList
    {
        /// <summary>
        /// Gets the device DTM list.
        /// </summary>
        /// <param name="pathToData">The path to data.</param>
        /// <returns>List of Strings</returns>
        public static List<String> GetDeviceDTMList(string pathToData)
        {
            try
            {
                var deviceList = new List<string>();

                // Create a new CSVConnector object  
                var csvConnector = new CSVConnector(pathToData);

                // Read every row from connector and send to AddVIPApplication.  
                foreach (DataRow row in csvConnector.Rows)
                {
                    deviceList.Add(row[0].ToString());
                }

                return deviceList;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}