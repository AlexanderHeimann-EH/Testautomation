﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenSave.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.MenuArea.Toolbar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    ///     Provides methods to start save
    /// </summary>
    public class OpenSave : IOpenSave
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Start save via related toolbar-icon
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ViaIcon()
        {
            try
            {
                Button button = (new ToolbarElements()).ButtonSave;
                if (button != null && button.Enabled)
                {
                    Mouse.MoveTo(button, 500);
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessible");
                return false;
            }
            catch (Exception excException)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), excException.Message);
                return false;
            }
        }

        #endregion
    }
}