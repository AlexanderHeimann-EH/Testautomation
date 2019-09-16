//------------------------------------------------------------------------------
// <copyright file="ICloseDeviceFunction.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Provides methods for closing a device function
    /// </summary>
    public interface ICloseFunction
    {
        /// <summary>
        ///     Closes a function
        /// </summary>
        /// <param name="functionName">Function which will be closed</param>
        /// <returns>true: if function is closed; false: if an error occurred</returns>
        bool Run(string functionName);
    }
}