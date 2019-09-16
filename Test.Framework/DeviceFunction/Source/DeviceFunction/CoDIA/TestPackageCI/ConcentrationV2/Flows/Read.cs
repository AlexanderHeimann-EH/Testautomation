// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Read.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Flows
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Flows;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.MenuArea.Toolbar.Validation;

    /// <summary>
    ///     Provides methods for reading coefficients from device
    /// </summary>
    public class Read : IRead
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Reads coefficients from device/offline parameterization, waits until "read finished" user notification message is displayed and read icon is enabled again
        /// </summary>
        /// <returns>
        ///     true: if coefficients were read
        ///     false: if an error occurred
        /// </returns>
        public bool Run()
        {
            var watch = new Stopwatch();
            if (new RunRead().ViaIcon() == false)
            {
                return false;
            }

            watch.Start();
            while (new IsReadFinished().Run() == false)
            {
                if (watch.ElapsedMilliseconds <= DefaultValues.iTimeoutLong)
                {
                    continue;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading did not finish within " + DefaultValues.iTimeoutLong + " milliseconds");
                return false;
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading coefficients finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.iTimeoutLong + " milliseconds)");
            return true;
        }

        #endregion
    }
}