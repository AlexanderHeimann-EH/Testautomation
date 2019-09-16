//------------------------------------------------------------------------------
// <copyright file="IsCalculationFinished.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Viscosity.Functions.MenuArea.Toolbar.Validation
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.MenuArea.Toolbar.Validation;

    /// <summary>
    /// The is calculation finished.
    /// </summary>
    public class IsCalculationFinished : MarshalByRefObject, IIsCalculationFinished
    {
        /// <summary>
        ///     Checks if calculating is finished
        /// </summary>
        /// <returns>
        ///     true: if progress bar not shown, calculate button not enabled and "calculation successful" user message displayed 
        ///     false: if not
        /// </returns>
        public bool Run()
        {
            if (((new GUI.MenuArea.Toolbar.ToolbarElements()).CalculateButton.Enabled == false) &&
                 (new GUI.MenuArea.Toolbar.ToolbarElements()).WriteButton.Enabled)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculation finished");
                return true;
            }

            // for debugging:           
            if ((new GUI.MenuArea.Toolbar.ToolbarElements()).CalculateButton.Enabled)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculate button is NOT disabled");
                return false;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Write button is NOT enabled");
            return false;
        }
    }
}