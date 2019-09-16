//------------------------------------------------------------------------------
// <copyright file="IProjectSaveAs.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 04.07.2011
 * Time: 9:25 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows
{
    /// <summary>
    ///     Interface for flow Project Save As
    /// </summary>
    public interface IProjectSaveAs
    {
        /// <summary>
        ///     Start flow
        /// </summary>
        /// <param name="projectName">Project name</param>
        /// <param name="replaceProject">Bool</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Run(string projectName, bool replaceProject);
    }
}