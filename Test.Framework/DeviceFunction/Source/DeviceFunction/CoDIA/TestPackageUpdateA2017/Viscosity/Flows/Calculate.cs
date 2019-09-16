// --------------------------------------------------------------------------------------------------------------------
// <copyright file="calculate.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.Flows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.Functions.MenuArea.Toolbar.Validation;

    /// <summary>
    /// The calculate.
    /// </summary>
    public class Calculate : MarshalByRefObject, ICalculate
    {
        /// <summary>
        /// Starts calculation via icon, waits until calculation is finished
        /// </summary>
        /// <returns>
        ///     true: if calculation worked fine
        ///     false: if an error occurred
        /// </returns>
        public bool Run()
        {
            var watch = new Stopwatch();
            if ((new RunCalculate()).ViaIcon() == false)
            {
                return false;
            }

            watch.Start();
            while ((new IsCalculationFinished()).Run() == false)
            {
                if (watch.ElapsedMilliseconds <= DefaultValues.iTimeoutLong)
                {
                    continue;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculating did not finish within " + DefaultValues.iTimeoutLong + " milliseconds");
                return false;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculating coefficients finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.iTimeoutLong + " milliseconds)");
            return true;
        }
    }    
}
