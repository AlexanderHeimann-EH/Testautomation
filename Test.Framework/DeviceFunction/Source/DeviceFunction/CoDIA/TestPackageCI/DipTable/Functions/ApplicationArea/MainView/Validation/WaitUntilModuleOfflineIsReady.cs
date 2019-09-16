// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WaitUntilModuleOfflineIsReady.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of WaitUntilModuleOfflineIsReady.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.DipTable.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.DipTable.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.DipTable.GUI.ApplicationArea.MainView;

    using Ranorex;

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
            Button read = new MainViewElements().ReadButton;
            Button write = new MainViewElements().WriteButton;
            var watch = new Stopwatch();
            watch.Start();

            // Wait until read and write buttons are enabled
            while (new IsModuleReady().IsModuleOnlineReady(read) == false || new IsModuleReady().IsModuleOnlineReady(write) == false || new ReadingAndWriting().IsReading())
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
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is ready after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
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