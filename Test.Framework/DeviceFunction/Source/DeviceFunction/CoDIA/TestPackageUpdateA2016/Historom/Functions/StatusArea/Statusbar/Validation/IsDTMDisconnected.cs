//------------------------------------------------------------------------------
// <copyright file="IsDTMDisconnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.Functions.StatusArea.Statusbar.Validation
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.StatusArea.Statusbar.Validation;

    using Ranorex;

    using StatusBar = EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.Functions.StatusArea.Statusbar.Execution.StatusBar;

    /// <summary>
    ///     Description of IsDtmDisconnected.
    /// </summary>
    public class IsDTMDisconnected : MarshalByRefObject, IIsDTMDisconnected
    {
        /// <summary>
        ///     Determines whether DTM (HISTOROM module) is offline
        /// </summary>
        /// <returns>
        ///     true: if DTM is offline
        ///     false: if DTM is online or an error occurred
        /// </returns>
        public bool Run()
        {
            var watch = new Stopwatch();
            string state = new StatusBar().ConnectionState;
            if (state == null)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection State is null");
                return false;
            }

            watch.Start();
            while (watch.ElapsedMilliseconds <= DefaultValues.iTimeoutMedium)
            {
                state = new StatusBar().ConnectionState;
                if (!state.Equals("Offline"))
                {
                    continue;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is disconnected after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.iTimeoutMedium + " milliseconds)");
                return true;
            }

            watch.Stop();
            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is not disconnected within " + DefaultValues.iTimeoutMedium + " milliseconds");
            return false;
        }
    }
}