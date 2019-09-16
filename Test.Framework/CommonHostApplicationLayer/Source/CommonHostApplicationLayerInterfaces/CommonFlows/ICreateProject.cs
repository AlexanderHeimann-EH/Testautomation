//------------------------------------------------------------------------------
// <copyright file="ICreateProject.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    /// <summary>
    /// Provides methods for creating a project
    /// </summary>
    public interface ICreateProject
    {
	/// <summary>
        /// Creates a project and save it by default
	/// </summary>
        /// <param name="projectName">Name of the project to create.</param>
        /// <returns>true in case of success;false in case of an error</returns>
        bool Run(string projectName);
    }
}
