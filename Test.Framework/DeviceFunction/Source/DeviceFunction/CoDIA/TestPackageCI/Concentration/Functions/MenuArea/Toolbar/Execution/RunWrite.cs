// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RunWrite.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Concentration.Functions.MenuArea.Toolbar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Concentration.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    ///     Provides methods to start write
    /// </summary>
    public class RunWrite : IRunWrite
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Start write via related toolbar-icon
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ViaIcon()
        {
            try
            {
                Button button = (new ToolbarElements()).ButtonWrite;
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