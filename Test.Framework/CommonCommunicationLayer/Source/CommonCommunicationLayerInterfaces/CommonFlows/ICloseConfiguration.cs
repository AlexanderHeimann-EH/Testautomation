// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICloseConfiguration.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows
{
    /// <summary>
    /// Provides methods for closing communication configuration GUI
    /// </summary>
    public interface ICloseConfiguration
    {
        /// <summary>
        /// Closes a function
        /// </summary>
        /// <returns>true: if function is closed; false: if an error occurred</returns>
        bool Run();
    }
}