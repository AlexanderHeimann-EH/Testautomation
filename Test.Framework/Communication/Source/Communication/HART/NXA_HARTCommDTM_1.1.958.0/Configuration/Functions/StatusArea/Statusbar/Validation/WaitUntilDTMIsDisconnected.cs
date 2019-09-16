﻿//------------------------------------------------------------------------------
// <copyright file="WaitUntilDTMIsDisconnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.Configuration.Functions.StatusArea.Statusbar.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.Configuration.Functions.StatusArea.Statusbar.Validation;

    using Ranorex;

    /// <summary>
    /// The wait until connection is disconnected.
    /// </summary>
    public class WaitUntilDtmIsDisconnected : IWaitUntilDtmIsDisconnected
    {
        /// <summary>
        ///     Wait until DTM connection is established and shown by GUI
        /// </summary>
        /// ///
        /// <param name="timeOutInMilliseconds">Time until action must be performed</param>
        /// <returns>
        ///     <br>True: if module is disconnected</br>
        ///     <br>False: if module is not disconnected</br>
        /// </returns>
        public bool Run(int timeOutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();
            watch.Start();
            while ((new global::EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.ChangeDeviceAddress.Functions.StatusArea.Statusbar.Validation.IsDtmDisconnected()).Run() == false)
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Connection is not disconnected after: >" + timeOutInMilliseconds + "Milliseconds.");
                result = false;
                break;
            }

            watch.Stop();

            if (result)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection disconnected after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            }

            return result;
        }
    }
}