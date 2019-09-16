// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RunReadCurve.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurveShed.Functions.MenuArea.Toolbar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurveShed.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurveShed.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    ///     Go online with focused device
    /// </summary>
    public class RunReadCurve : IRunReadCurve
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Start via related toolbar-icon
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ViaIcon()
        {
            try
            {
                Button button = (new Elements()).BtnReadCurve;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Single reading started");
                if (button == null || button.Enabled == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read button is null or not enabled");
                    return false;
                }

                Mouse.MoveTo(button, 500);
                button.Click();
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion
    }
}