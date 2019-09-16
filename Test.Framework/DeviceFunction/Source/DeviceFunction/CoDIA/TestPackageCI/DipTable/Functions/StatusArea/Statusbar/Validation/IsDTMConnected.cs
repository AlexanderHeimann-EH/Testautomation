// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsDTMConnected.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of IsDtmConnected.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.DipTable.Functions.StatusArea.Statusbar.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.DipTable.GUI.StatusArea.Statusbar;

    /// <summary>
    ///     Description of IsDtmConnected.
    /// </summary>
    public class IsDtmConnected : IIsDtmConnected
    {
        #region Public Methods and Operators

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
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection State is null");
                return false;
            }

            watch.Start();

            // timeout needed, state can be "going online" for several seconds depending on communication and whether Dip table module or another module is already open 
            while (watch.ElapsedMilliseconds <= DefaultValues.iTimeoutMedium)
            {
                state = new StatusbarElements().ConnectionState;
                if (!state.Equals("Online"))
                {
                    continue;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is connected after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.iTimeoutMedium + " milliseconds)");
                return true;
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is not connected after " + DefaultValues.iTimeoutMedium + " milliseconds");
            return false;
        }

        #endregion
    }
}