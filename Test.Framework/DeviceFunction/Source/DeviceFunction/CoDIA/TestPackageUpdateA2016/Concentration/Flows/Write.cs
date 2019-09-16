// --------------------------------------------------------------------------------------------------------------------
// <copyright file="write.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Concentration.Flows
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Concentration.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Concentration.Functions.MenuArea.Toolbar.Validation;

    /// <summary>
    ///     provides methods for writing coefficients to device
    /// </summary>
    public class Write : IWrite
    {
        #region Public Methods and Operators

        /// <summary>
        ///     writes coefficients to device/offline parameterization, waits until "write finished" user notification message is displayed and write button is enabled again
        /// </summary>
        /// <returns>
        ///     true: if coefficients were written
        ///     false: if an error occurred
        /// </returns>
        public bool Run()
        {
            var watch = new Stopwatch();
            if (new RunWrite().ViaIcon() == false)
            {
                return false;
            }

            watch.Start();
            while (new IsWriteFinished().Run() == false)
            {
                if (watch.ElapsedMilliseconds <= DefaultValues.iTimeoutLong)
                {
                    continue;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing did not finish within " + DefaultValues.iTimeoutLong + " milliseconds");
                return false;
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing coefficients finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.iTimeoutLong + " milliseconds)");
            return true;
        }

        #endregion
    }
}