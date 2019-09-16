// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsDTMDisconnected.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of IsDtmDisconnected.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.DipTable.Functions.StatusArea.Statusbar.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.DipTable.GUI.StatusArea.Statusbar;

    /// <summary>
    ///     Description of IsDtmDisconnected.
    /// </summary>
    public class IsDtmDisconnected : IIsDtmDisconnected
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Determines whether connection is offline
        /// </summary>
        /// <returns>
        ///     true: if DTM is offline
        ///     false: if DTM is online or an error occurred
        /// </returns>
        public bool Run()
        {
            var watch = new Stopwatch();
            string state = new StatusbarElements().ConnectionState;
            if (state == null || state.Equals(string.Empty))
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
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is not disconnected within " + DefaultValues.iTimeoutMedium + " milliseconds");
            return false;
        }

        #endregion
    }
}