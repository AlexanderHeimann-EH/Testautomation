//------------------------------------------------------------------------------
// <copyright file="RunCalculate.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.Functions.MenuArea.Toolbar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    ///     Provides methods to start calculate
    /// </summary>
    public class RunCalculate : MarshalByRefObject, IRunCalculate
    {
        /// <summary>
        ///     Start calculate via related toolbar-icon
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ViaIcon()
        {
            try
            {
                Button button = (new ToolbarElements()).CalculateButton;
                if (button != null && button.Enabled)
                {
                    // button.Focus();
                    Mouse.MoveTo(button);
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
    }
}