// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConfigureBaseSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ConfigureBaseSettings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Concentration
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Concentration;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_ConfigureBaseSettings.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_ConfigureBaseSettings
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Selects tab Basic settings and configures the parameter
        /// </summary>
        /// <param name="calculationBase">
        /// The calculation Base.
        /// </param>
        /// <param name="liquidType">
        /// The liquid Type.
        /// </param>
        /// <param name="densityCalibration">
        /// The density Calibration.
        /// </param>
        /// <param name="fieldDensityAdjustment">
        /// The field Density Adjustment.
        /// </param>
        /// <param name="sensor">
        /// The sensor.
        /// </param>
        /// <param name="temperatureUnit">
        /// The temperature Unit.
        /// </param>
        /// <param name="temperatureMin">
        /// The temperature Min.
        /// </param>
        /// <param name="temperatureMax">
        /// The temperature Max.
        /// </param>
        /// <param name="concentrationUnit">
        /// The concentration Unit.
        /// </param>
        /// <param name="concentrationMin">
        /// The concentration Min.
        /// </param>
        /// <param name="concentrationMax">
        /// The concentration Max.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("A6A4A4F1-FF87-4F71-9FF8-FA6A1260F586", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string calculationBase, string liquidType, string densityCalibration, string fieldDensityAdjustment, string sensor, string temperatureUnit, string temperatureMin, string temperatureMax, string concentrationUnit, string concentrationMin, string concentrationMax)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.Container.SelectTabBaseSettings();
            isPassed &= Flows.ConfigureBaseSettings.Run(calculationBase, liquidType, densityCalibration, fieldDensityAdjustment, sensor, temperatureUnit, temperatureMin, temperatureMax, concentrationUnit, concentrationMin, concentrationMax);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureBaseSettings passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureBaseSettings failed.");
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The startup.
        /// </summary>
        private static void StartUp()
        {
            /////////////////////////////////////////////////////////////////
            // Add your Start Up calls here
            /////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// The tear down.
        /// </summary>
        private static void TearDown()
        {
            /////////////////////////////////////////////////////////////////
            // Add your Tear Down calls here
            /////////////////////////////////////////////////////////////////
        }

        #endregion
    }
}