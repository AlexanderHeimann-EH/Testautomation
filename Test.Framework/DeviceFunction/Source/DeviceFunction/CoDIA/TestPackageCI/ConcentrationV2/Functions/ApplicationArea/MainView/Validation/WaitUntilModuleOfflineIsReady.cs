// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WaitUntilModuleOfflineIsReady.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.GUI.ApplicationArea.MainView;

    /// <summary>
    ///     Description of WaitUntilModuleOfflineIsReady.
    /// </summary>
    public class WaitUntilModuleOfflineIsReady : IWaitUntilModuleOfflineIsReady
    {
        #region Public Methods and Operators

        /// <summary>
        /// Validation if module (offline) is ready within a specified time
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// Time within module should be ready
        /// </param>
        /// <returns>
        /// <br>True: if module is ready in time</br>
        ///     <br>False: if module is not ready in time</br>
        /// </returns>
        public bool Run(int timeOutInMilliseconds)
        {
            bool result = true;

            var watch = new Stopwatch();
            watch.Start();

            while (new IsModuleReady().IsModuleOfflineReady((new BaseSettingsElements()).ComboBoxCalculationBase) == false)
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                result = false;
                break;
            }

            watch.Stop();

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module ready after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is not ready after " + timeOutInMilliseconds + "Milliseconds.");
            }

            return result;
        }

        #endregion
    }
}