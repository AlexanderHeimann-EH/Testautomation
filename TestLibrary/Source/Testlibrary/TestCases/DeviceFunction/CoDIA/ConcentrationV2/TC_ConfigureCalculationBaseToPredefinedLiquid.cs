// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConfigureCalculationBaseToPredefinedLiquid.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ConfigureCalculationBaseToPredefinedLiquidAndCheck.
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
    /// The test case TC_ConfigureCalculationBaseToPredefinedLiquid
    /// </summary>
    public class TC_ConfigureCalculationBaseToPredefinedLiquid
    {
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators
        
        /// <summary>
        /// Sets Calculation base to Predefined liquid, checks calculation button and tabs behavior.
        /// </summary>
        /// <returns><c>true</c> if passed, <c>false</c> otherwise.</returns>
        [TestScriptInformation("147D2921-0831-48BD-8692-9C1D0B1A236A", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.Container.SelectTabBaseSettings();
            isPassed &= Flows.ConfigureBaseSettings.BaseConfiguration("Predefined liquid", string.Empty, string.Empty, string.Empty, string.Empty);
            isPassed &= AssertFunctions.AreEqual(true, DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.MenuArea.Toolbar.Validation.IsCalculationButtonEnabled.Run(), "Verifies that calculate button is enabled.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsBaseSettingsTabPageAvailable(), "Verifies that Base settings tab is active.");
            isPassed &= AssertFunctions.AreEqual(false, Validation.CheckAvailabilityOfTabPages.IsReferenceValuesTabPageAvailable(), "Verifies that Reference Values tab is inactive.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsLiquidPropertiesTabPageAvailable(), "Verifies that Liquid properties tab is active.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsCoefficientOverviewTabPageAvailable(), "Verifies that Coefficients overview tab is active.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsExpertResultsTabPageAvailable(), "Verifies that expert results tab is active.");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureCalculationBaseToPredefinedLiquid passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureCalculationBaseToPredefinedLiquid failed.");
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