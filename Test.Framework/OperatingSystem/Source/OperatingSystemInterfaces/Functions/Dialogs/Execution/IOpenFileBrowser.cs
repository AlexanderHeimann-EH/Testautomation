//------------------------------------------------------------------------------
// <copyright file="IOpenFileBrowser.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 5/28/2013
 * Time: 4:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.OperatingSystemInterfaces.Functions.Dialogs.Execution
{
    /// <summary>
    ///     Description of IOpenFileBrowser.
    /// </summary>
    public interface IOpenFileBrowser
    {
        #region methods

        /// <summary>
        ///     Load specified file
        /// </summary>
        /// <param name="fileName">Filename</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        bool Load(string fileName);

        /// <summary>
        ///     Closes open dialog
        /// </summary>
        /// <returns>
        ///     true: if call worked fine
        ///     false: if an error occurred
        /// </returns>
        bool Close();

        /// <summary>
        /// The cancel.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Cancel();


        #endregion
    }
}