//------------------------------------------------------------------------------
// <copyright file="IOpenAdditionalFunction.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    /// <summary>
    ///     Provides methods for opening a proprietary DTM/DD function
    /// </summary>
    public interface IOpenAdditionalFunction
    {
        /// <summary>
        /// Opens a proprietary DTM/DD function
        /// </summary>
        /// <param name="functionName">Function to open</param>
        /// <returns>true: if Function is opened; false: if an error occurred</returns>
        bool Run(string functionName);
    }
}