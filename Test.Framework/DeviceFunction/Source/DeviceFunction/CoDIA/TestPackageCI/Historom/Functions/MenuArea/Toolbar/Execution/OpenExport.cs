﻿//------------------------------------------------------------------------------
// <copyright file="OpenExport.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadministrator
 * Date: 11/13/2012
 * Time: 1:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageCI.Historom.Functions.MenuArea.Toolbar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Historom.GUI.MenuArea.Toolbar;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Provides methods to open Export
    /// </summary>
    public class OpenExport : MarshalByRefObject, IOpenExport
    {
        #region methods

        /// <summary>
        ///     Open Export via related toolbar-icon
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ViaIcon()
        {
            try
            {
                Button button = (new ToolbarElements()).ButtonExport;
                if (button != null && button.Enabled)
                {
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessible");
                return false;
            }
            catch (Exception excException)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), excException.Message);
                return false;
            }
        }

        #endregion
    }
}