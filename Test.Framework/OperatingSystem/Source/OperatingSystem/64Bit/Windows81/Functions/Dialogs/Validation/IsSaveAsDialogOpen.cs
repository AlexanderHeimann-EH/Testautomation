//------------------------------------------------------------------------------
// <copyright file="IsSaveAsDialogOpen.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 6/5/2013
 * Time: 1:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Windows81.Functions.Dialogs.Validation
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.OperatingSystemInterfaces.Functions.Dialogs.Validation;
    using EH.PCPS.TestAutomation.Windows81.GUI.Dialogs;

    /// <summary>
    /// Class IsSaveAsDialogOpen.
    /// </summary>
    public class IsSaveAsDialogOpen : MarshalByRefObject, IIsSaveAsDialogOpen
    {
        /// <summary>
        ///     Checks whether the Save as dialog is visible or not
        /// </summary>
        /// <returns>
        ///     true: if dialog is visible
        ///     false: if not
        /// </returns>
        public bool Run()
        {
            if (new SaveAsFileBrowserElements().buttonSave == null)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dialog is not open");
                return false;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dialog is open");
            return true;
        }
    }
}