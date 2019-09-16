// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeleteProject.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    /// <summary>
    /// Provides methods for deleting a project
    /// </summary>
    public interface IDeleteProject
    {
        /// <summary>
        /// Deletes a saved project
        ///  </summary>
        /// <param name="projectName">Name of the project to delete</param>
        /// <returns>true in case of success;false in case of an error</returns>
        bool Run(string projectName);
    }
}
