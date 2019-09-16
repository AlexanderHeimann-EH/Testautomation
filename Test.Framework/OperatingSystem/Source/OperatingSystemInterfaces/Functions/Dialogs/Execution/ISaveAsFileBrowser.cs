//------------------------------------------------------------------------------
// <copyright file="ISaveAsFileBrowser.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Description of ISaveAsFileBrowser.
    /// </summary>
    public interface ISaveAsFileBrowser
    {
        #region methods

        /// <summary>
        ///     Returns proposed filename or an empty string
        /// </summary>
        string ProposedFileName { get; set; }

        /// <summary>
        ///     save a file with given filename
        /// </summary>
        /// <param name="fileName">filename under which file will be saved</param>
        /// <returns>
        ///     true: if saving was successful
        ///     false: if an error occurred
        /// </returns>
        bool SaveAs(string fileName);

        /// <summary>
        ///     save a file with proposed filename
        /// </summary>
        /// <returns>
        ///     true: if saving was successful
        ///     false: if an error occurred
        /// </returns>
        bool Save();

        /// <summary>
        ///     Closes save as dialog
        /// </summary>
        /// <returns>
        ///     true: if call worked fine
        ///     false: if an error occurred
        /// </returns>
        bool Close();

        #endregion
    }
}