﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

using Ranorex;
using Ranorex.Core;

using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.Functions.ApplicationArea.Validation
{
    /// <summary>
    /// Waits until a module is ready
    /// </summary>
    public class WaitUntilModuleIsReady
    {

        /// <summary>
        ///     Validation if module is ready within a specified time
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

            while (new IsModuleReady().Run() == false)
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                result = false;
                break;
            }

            if (new IsModuleConfigurable().Run(true) == false)
            {
                CommonHostApplicationLayerLoader.CommonFlows.DisconnectDevice.Run();
            }

            while (new IsModuleConfigurable().Run(false) == false)
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
                Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is not ready after " + timeOutInMilliseconds + "Milliseconds.");
            }
            return result;
        }
    }
}
