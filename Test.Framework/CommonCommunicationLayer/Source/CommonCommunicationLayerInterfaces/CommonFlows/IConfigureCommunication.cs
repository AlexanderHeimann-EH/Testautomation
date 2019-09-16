// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigureCommunication.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows
{
    using EH.PCPS.TestAutomation.Common.DataTypes;

    /// <summary>
    /// Provides methods for configuration of communication
    /// </summary>
    public interface IConfigureCommunication
    {
        /// <summary>
        /// Configures the Communication DTM via Communication Object
        /// </summary>
        /// <param name="communication">Communication Information</param>
        /// <returns> true: if function is closed; false: if an error occurred </returns>
        bool Run(Communication communication);

        /// <summary>
        /// Configures the Communication DTM via string
        /// </summary>
        /// <param name="communication">Communication Information</param>
        /// <returns>true: if function is closed; false: if an error occurred</returns>
        bool Run(string communication);
    }
}