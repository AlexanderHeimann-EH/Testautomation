// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateTopologyOffline.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Zander, Jan 
 * Date: 12.02.2014
 * Time: 16:
 * Last: -
 * Reason: -
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.CommonFlows
{
    using System;
    using System.Collections.Generic;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    /// <summary>
    ///     Provides methods for creating a network
    /// </summary>
    public class CreateTopologyOffline : ICreateTopologyOffline
    {
        /// <summary>
        ///  Creates a network within the host application 
        /// </summary>
        /// <returns>True in case of success, false in case of an error</returns>
        public bool Run()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Creates a network within the host application
        /// </summary>
        /// <param name="communication">Contains strings parent, protocol, deviceName, driver name and a string list with the communication settings</param>
        /// <param name="devices">Contains strings parent and deviceName</param>
        /// <returns>True in case of success, false in case of an error</returns>
        public bool Run(List<string/*communications*/> communication, List<string/*device*/> devices)
        {
            throw new NotImplementedException();
        }
    }
}
