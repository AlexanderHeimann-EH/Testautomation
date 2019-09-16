// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILoadProject.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Provides methods for loading a project
    /// </summary>
    public interface ILoadProject
    {
        /// <summary>
        ///     Load a specified project
        /// </summary>
        /// <param name="projectName">Project to load</param>
        /// <returns>true: if project is loaded; false: if an error occurred</returns>
        bool Run(string projectName);
    }
}