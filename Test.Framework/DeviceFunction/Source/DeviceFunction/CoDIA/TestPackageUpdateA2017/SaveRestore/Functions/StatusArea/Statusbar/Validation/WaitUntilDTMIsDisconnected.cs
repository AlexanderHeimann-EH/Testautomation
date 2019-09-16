//------------------------------------------------------------------------------
// <copyright file="WaitUntilDTMIsDisconnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
/*
 * Created by Ranorex
 * User: testadmin
 * Date: 11/06/2013
 * Time: 2:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.StatusArea.Statusbar.Validation
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.StatusArea.Statusbar.Validation;

    using Ranorex;

    /// <summary>
    /// The wait until DTM is disconnected.
    /// </summary>
    public class WaitUntilDTMIsDisconnected : MarshalByRefObject, IWaitUntilDTMIsDisconnected
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
            while ((new IsDTMDisconnected()).Run() == false)
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