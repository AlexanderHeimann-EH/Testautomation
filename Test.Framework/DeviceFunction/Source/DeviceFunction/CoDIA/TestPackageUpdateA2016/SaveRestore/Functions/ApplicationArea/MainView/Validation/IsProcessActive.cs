//------------------------------------------------------------------------------
// <copyright file="IsProcessActive.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 7/22/2013
 * Time: 1:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.Functions.ApplicationArea.MainView.Validation
{
    using System;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.GUI.StatusArea.Statusbar;

    using Ranorex.Core;

    /// <summary>
    ///     Description of IsProcessActive.
    /// </summary>
    public class IsProcessActive : MarshalByRefObject, IIsProcessActive
    {
        /// <summary>
        ///     Checks if SaveRestore is active
        /// </summary>
        /// <returns>
        ///     <br>True: if process is active</br>
        ///     <br>False: if process is not active</br>
        /// </returns>
        public bool Run()
        {
            Element buttonProgress = new StatusbarElements().BtnProgress;
            // Reading is active
            return buttonProgress != null && buttonProgress.Enabled;
        }
    }
}