// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConfigureBaseSettingsBaseConfiguration.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ConfigureBaseSettings.
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
    /// The test case TC_ConfigureBaseSettings.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_ConfigureBaseSettingsBaseConfiguration
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Configure Base Settings Base Configuration
        /// </summary>
        /// <param name="calculationBase">The calculation base.</param>
        /// <param name="liquidType">Type of the liquid.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="referenceTemperature">The reference temperature.</param>
        /// <param name="mineralContent">Content of the mineral.</param>
        /// <returns><c>true</c> if passed, <c>false</c> otherwise.</returns>
        [TestScriptInformation("ABEAFAEB-9611-49AE-9574-424AAD371AD0", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string calculationBase, string liquidType, string userProfile, string referenceTemperature, string mineralContent)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.Container.SelectTabBaseSettings();
            isPassed &= Flows.ConfigureBaseSettings.BaseConfiguration(calculationBase, liquidType, userProfile, referenceTemperature, mineralContent);

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