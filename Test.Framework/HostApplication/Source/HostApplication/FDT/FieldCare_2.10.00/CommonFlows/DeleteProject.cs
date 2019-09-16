//------------------------------------------------------------------------------
// <copyright file="DeleteProject.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V21000.CommonFlows
{
    using System;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Provides methods for deleting a project
    /// </summary>
    public class DeleteProject : IDeleteProject
    {
        /// <summary>
        /// Deletes a saved project
        /// </summary>
        /// <param name="projectName">Name of the project to delete</param>
        /// <returns>true in case of success;false in case of an error</returns>
        public bool Run(string projectName)
        {
            throw new NotImplementedException();
        }
    }
}
