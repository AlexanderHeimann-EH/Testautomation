// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsDTMDisconnected.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Concentration.Functions.StatusArea.Statusbar.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Concentration.GUI.StatusArea.Statusbar;

    /// <summary>
    ///     Description of IsDTMDisconnected.
    /// </summary>
    public class IsDtmDisconnected : IIsDtmDisconnected
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Determines whether DTM is offline
        /// </summary>
        /// <returns>
        ///     true: if DTM is offline
        ///     false: if DTM is online or an error occurred
        /// </returns>
        public bool Run()
        {
            var watch = new Stopwatch();
            string state = new StatusbarElements().ConnectionState;
            if (state.Equals(string.Empty))
            {
                return false;
            }

            watch.Start();
            while (watch.ElapsedMilliseconds <= DefaultValues.iTimeoutMedium)
            {
                state = new StatusbarElements().ConnectionState;
                if (!state.Equals("Offline"))
                {
                    continue;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is disconnected after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.iTimeoutMedium + " milliseconds)");
                return true;
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is not disconnected after " + DefaultValues.iTimeoutMedium + " milliseconds");
            return false;
        }

        #endregion
    }
}