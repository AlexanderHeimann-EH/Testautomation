//------------------------------------------------------------------------------
// <copyright file="IsDTMConnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.Functions.StatusArea.Statusbar.Validation
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.GUI.StatusArea.Statusbar;

    using Ranorex;

    /// <summary>
    ///     Description of IsDtmConnected.
    /// </summary>
    public class IsDtmConnected : MarshalByRefObject, IIsDtmConnected
    {
        /// <summary>
        ///     Determines whether online connection is established
        /// </summary>
        /// <returns>
        ///     true: if DTM is online
        ///     false: if DTM is offline or an error occurred
        /// </returns>
        public bool Run()
        {
            var watch = new Stopwatch();
            string state = new StatusbarElements().ConnectionState;
            if (state == null)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection State is null");
                return false;
            }

            watch.Start();

            // timeout needed, state can be "going online" for several seconds depending on communication and whether historom module or another module is already open 
            while (watch.ElapsedMilliseconds <= DefaultValues.iTimeoutMedium)
            {
                state = new StatusbarElements().ConnectionState;
                if (!state.Equals("Online"))
                {
                    continue;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is connected after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.iTimeoutMedium + " milliseconds)");
                return true;
            }

            watch.Stop();
            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is not connected after " + DefaultValues.iTimeoutMedium + " milliseconds");
            return false;
        }
    }
}