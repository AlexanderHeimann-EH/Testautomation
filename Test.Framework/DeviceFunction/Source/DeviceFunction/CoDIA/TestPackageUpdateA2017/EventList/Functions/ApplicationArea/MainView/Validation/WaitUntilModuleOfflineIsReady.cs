﻿//------------------------------------------------------------------------------
// <copyright file="WaitUntilModuleOfflineIsReady.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.EventList.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EventList.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.EventList.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    ///     Description of WaitUntilModuleOfflineIsReady.
    /// </summary>
    public class WaitUntilModuleOfflineIsReady : IWaitUntilModuleOfflineIsReady
    {
        /// <summary>
        ///     Validate if module (offline) is ready within a specified time
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time within module should be ready</param>
        /// <returns>
        ///     <br>True: if module is ready in time</br>
        ///     <br>False: if module is not ready in time</br>
        /// </returns>
        public bool Run(int timeOutInMilliseconds)
        {
            bool result = true;

            var watch = new Stopwatch();
            watch.Start();

            while (new IsModuleReady().IsModuleOfflineReady((new ActionElements()).Refresh) == false)
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
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is ready after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            }
            else
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is not ready after " + timeOutInMilliseconds + "Milliseconds.");
            }

            return result;
        }
    }
}