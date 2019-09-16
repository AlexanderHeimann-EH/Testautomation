//------------------------------------------------------------------------------
// <copyright file="IsOpenDialogOpen.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 6/5/2013
 * Time: 1:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.WindowsXP.Functions.Dialogs.Validation
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.OperatingSystemInterfaces.Functions.Dialogs.Validation;
    using EH.PCPS.TestAutomation.WindowsXP.GUI.Dialogs;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Checks if OpenDialog is open
    /// </summary>
    public class IsOpenDialogOpen : MarshalByRefObject, IIsOpenDialogOpen
    {
        /// <summary>
        ///     Checks whether the Open File dialog is visible or not
        /// </summary>
        /// <returns>
        ///     true: if dialog is visible
        ///     false: if not
        /// </returns>
        public bool Run()
        {
            if (new OpenFileBrowserElements().buttonOpen == null)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dialog is not open");
                return false;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dialog is open");
            return true;
        }
    }
}