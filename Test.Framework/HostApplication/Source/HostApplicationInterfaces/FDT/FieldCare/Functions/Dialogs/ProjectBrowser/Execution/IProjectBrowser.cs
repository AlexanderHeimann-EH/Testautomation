//------------------------------------------------------------------------------
// <copyright file="IProjectBrowser.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 08.03.2012
 * Time: 9:25 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.ProjectBrowser.Execution
{
    /// <summary>
    ///     Interface for dialog Project Browser
    /// </summary>
    public interface IProjectBrowser
    {
        /// <summary>
        ///     Create new project
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool CreateNew();

        /// <summary>
        ///     Cancel dialog
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Cancel();

        /// <summary>
        ///     Load project via entering project name in text field
        /// </summary>
        /// <param name="projectName">Name of project to load</param>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool LoadProjectViaTextField(string projectName);
    }
}