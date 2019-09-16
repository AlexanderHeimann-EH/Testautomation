// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CheckThatAllTabPagesAreActive.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CheckThatAllTabPagesAreActive.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Concentration
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_CheckThatAllTabPagesAreActive.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CheckThatAllTabPagesAreActive
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Checks which tab pages of the concentration module are active. All tab pages except for Liquid properties are active. This is the default case. 
        /// </summary>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("7C68EF45-451B-42AF-AB42-91A319F4FD35", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsLiquidPropertiesTabPageAvailable(), "Verify that Liquid Properties tab is active.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsBaseSettingsTabPageAvailable(), "Verify that Base settings tab is active.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsCoefficientOverviewTabPageAvailable(), "Verify that Coefficient Overview tab is active.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsExpertResultsTabPageAvailable(), "Verify that Expert Results tab is active.");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckThatAllTabPagesAreActive passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckThatAllTabPagesAreActive failed.");
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