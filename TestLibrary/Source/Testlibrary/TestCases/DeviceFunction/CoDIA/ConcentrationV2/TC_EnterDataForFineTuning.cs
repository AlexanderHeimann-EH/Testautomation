// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_EnterDataForFineTuning.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_EnterDataForLiquidProperties.
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
    /// The test case TC_EnterDataForFineTuning.cs.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_EnterDataForFineTuning
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Enters table values for fine tuning at
        /// </summary>
        /// <returns><c>true</c> if passed, <c>false</c> otherwise.</returns>
        [TestScriptInformation("23900F6A-AAEA-4F49-8695-D687E73D0D86", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            string expectedCoefficients = "";
            string tableValues = "";
            //Referenzwerte kommen von Jochen oder Manuel von PC-F
            
            bool isPassed = Execution.Container.SelectTabBaseSettings();
            isPassed &= Flows.ConfigureBaseSettings.BaseConfiguration("Fine tuning settings", string.Empty, string.Empty, string.Empty, string.Empty);
            isPassed &= Execution.Container.SelectTabLiquidProperties();
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsLiquidPropertiesTabPageAvailable(), "Verify that Liquid properties tab is active.");
            isPassed &= Execution.SetTableValues.SetValues(StringToListConverter.Run(tableValues));
            isPassed &= AssertFunctions.AreEqual(true, DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.MenuArea.Toolbar.Validation.IsCalculationButtonEnabled.Run(), "Verifies that calculate button is enabled.");
            isPassed &= Execution.CoefficientsOverview.CompareCoefficients("0.01", StringToStringArrayConverter.Run(expectedCoefficients));

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_EnterDataForFineTuning passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_EnterDataForFineTuning failed.");
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