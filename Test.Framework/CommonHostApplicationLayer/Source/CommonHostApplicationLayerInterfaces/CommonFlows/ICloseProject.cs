//------------------------------------------------------------------------------
// <copyright file="ICloseProject.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Provides methods for closing the project
    /// </summary>
    public interface ICloseProject
    {
        /// <summary>
        ///     Closes the project without saving it
        /// </summary>
        /// <returns>true: if project is closed; false: if an error occurred</returns>
        bool Run();
    }
}