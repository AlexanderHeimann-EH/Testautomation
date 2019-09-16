// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CheckCoefficientCalculation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of TC_CheckCoefficientCalculation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Concentration
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Concentration;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Concentration.Functions.MenuArea.Toolbar;

    /// <summary>
    /// Description of TC_CheckCoefficientCalculation.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_CheckCoefficientCalculation
// ReSharper restore InconsistentNaming
    {
        #region Public Methods and Operators

        /// <summary>
        /// Start execution
        /// </summary>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        public static bool Run()
        {
            // The following coefficients were calculated at 10.07.2013 03.31PM with Promass 100MB CDI and Setup 01.02.37.7450
            // Configuration of base settings: defined liquid, aqueous sugar, standard calibration, Promass a(Sensor not relevant)
            // temperature unit = °C, temperature min = 10, temperature max = 50
            // concentration unit= %, concentration min = 33, concentration max = 88
            var expectedCoefficients = new[] { "-8.8044", "19.5445", "-16.4714", "6.76874", "-1.05918", "0.87672", "3.07597", "NaN" };
            bool isPassed = true;

            isPassed &= Flows.OpenModuleOnline.Run();
            isPassed &= Execution.OpenNew.ViaIcon();
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.Container.SelectTabBaseSettings();
            isPassed &= Flows.ConfigureBaseSettings.Run("Defined liquid", "Aqueous sugar", "Standard calibration", string.Empty, string.Empty, "°C", "10", "50", "%", "33", "88");
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= Flows.Calculate.Run();
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.CoefficientsOverview.CompareCoefficients(0.001, expectedCoefficients);
            isPassed &= Flows.CloseModule.Run();

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case failed.");
                Log.Screenshot();
            }

            return isPassed;
        }

        #endregion
    }
}