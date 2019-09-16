// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConfigureBaseSettingsProcessConditions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ConfigureBaseSettingsProcessConditions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.ConcentrationV2
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_ConfigureBaseSettingsProcessConditions.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_ConfigureBaseSettingsProcessConditions
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Configure Base Settings Process Conditions
        /// </summary>
        /// <param name="temperatureMinimum">The temperature minimum.</param>
        /// <param name="temperatureMaximum">The temperature maximum.</param>
        /// <param name="concentrationMinimum">The concentration minimum.</param>
        /// <param name="concentrationMaximum">The concentration maximum.</param>
        /// <param name="temperatureUnit">The temperature unit.</param>
        /// <param name="concentrationUnit">The concentration unit.</param>
        /// <returns><c>true</c> if passed, <c>false</c> otherwise.</returns>
        [TestScriptInformation("7DB49914-96DF-4609-A9E3-9B66D58E3C4C", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string temperatureMinimum, string temperatureMaximum, string concentrationMinimum, string concentrationMaximum, string temperatureUnit, string concentrationUnit)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.Container.SelectTabBaseSettings();
            isPassed &= Flows.ConfigureBaseSettings.OperatingRange(temperatureMinimum, temperatureMaximum, concentrationMinimum, concentrationMaximum, temperatureUnit, concentrationUnit);

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