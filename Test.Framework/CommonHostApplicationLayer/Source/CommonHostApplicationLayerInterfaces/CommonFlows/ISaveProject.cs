//------------------------------------------------------------------------------
// <copyright file="ISaveProject.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Provides methods for saving a project
    /// </summary>
    public interface ISaveProject
    {
        /// <summary>
        ///     Saves the actually opened project; Per default available projects will be overwritten
        /// </summary>
        /// <returns>
        ///     <br>true: if project is saved</br>
        ///     <br>false: if an error occurred</br>
        /// </returns>
        bool Run();

        /// <summary>
        ///     Saves the actually opened project; Per default available projects will be overwritten
        /// </summary>
        /// <param name="projectName">Filename for the project</param>
        /// <returns>
        ///     <br>true: if project is saved</br>
        ///     <br>false: if an error occurred</br>
        /// </returns>
        bool Run(string projectName);
    }
}