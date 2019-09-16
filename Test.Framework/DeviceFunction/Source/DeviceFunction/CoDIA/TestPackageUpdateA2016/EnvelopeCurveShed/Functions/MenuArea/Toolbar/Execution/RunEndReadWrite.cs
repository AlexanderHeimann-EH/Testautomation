// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RunEndReadWrite.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.EnvelopeCurveShed.Functions.MenuArea.Toolbar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurveShed.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.EnvelopeCurveShed.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    ///     Go online with focused device
    /// </summary>
    public class RunEndReadWrite : IRunEndReadWrite
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
                Button button = (new Elements()).BtnEndRead;
                if (button != null && button.Enabled)
                {
                    Mouse.MoveTo(button, 500);
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessable.");
                return false;
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