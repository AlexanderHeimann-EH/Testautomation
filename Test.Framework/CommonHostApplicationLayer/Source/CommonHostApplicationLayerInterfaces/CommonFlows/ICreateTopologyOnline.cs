// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateTopologyOnline.cs" company="Endress+Hauser Process Solutions AG">
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
 * Time: 16:00
 * Last: -
 * Reason: -
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    using System.Collections.Generic;

    /// <summary>
    ///     Provides methods for creating a network
    /// </summary>
    public interface ICreateTopologyOnline
    {
        /// <summary>
        /// Creates a network within the host application 
        /// </summary>
        /// <returns>True in case of success, false in case of an error</returns>
        bool Run();

        /// <summary>
        ///  Creates a network within the host application
        /// </summary>
        /// <param name="communication">List of comm devices and configurations</param>
        /// <param name="devices">List of devices</param>
        /// <returns>True in case of success, false in case of an error</returns>
        bool Run(List<string/*communications*/> communication, List<string/*device*/> devices);
    }
}
