//------------------------------------------------------------------------------
// <copyright file="IOpenDeviceFunction.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows
{
    /// <summary>
    ///     Provides methods for opening communication configuration GUI
    /// </summary>
    public interface IOpenConfiguration
    {
        /// <summary>
        ///     Opens specified function
        /// </summary>
        /// <returns>true: function is opened; false: if an error occurred</returns>
        bool Run();
    }
}