//------------------------------------------------------------------------------
// <copyright file="FileBrowser.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 18.04.2012
 * Time: 6:44 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.FileBrowser.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs;

    using Ranorex;

    /// <summary>
    ///     Description of FileBrowser.
    /// </summary>
    public static class FileBrowser
    {
        /// <summary>
        ///     Save / Replace file with specified filename
        /// </summary>
        /// <param name="fileName">Filename of file to save</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static bool Save(string fileName)
        {
            try
            {
                (new FileBrowserElements()).Filename.Click(DefaultValues.locDefaultLocation);
                (new FileBrowserElements()).Filename.TextValue = fileName;
                (new FileBrowserElements()).Save.Click(DefaultValues.locDefaultLocation);
                
                // Replace if file is already available
                if ((new SaveAsMessageElements()).Yes != null)
                {
                    (new SaveAsMessageElements()).Yes.Click(DefaultValues.locDefaultLocation);
                }

                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Close dialog via cancel
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static bool Cancel()
        {
            try
            {
                (new FileBrowserElements()).Cancel.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}