// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_EnterDataForLiquidProperties.cs" company="Endress+Hauser Process Solutions AG">
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
    /// The test case TC_EnterDataForLiquidProperties.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_EnterDataForLiquidProperties
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Enters table values in tap Liquid Properties
        /// </summary>
        /// <returns><c>true</c> if passed, <c>false</c> otherwise.</returns>
        [TestScriptInformation("DAE0995B-5A27-4814-8904-25E5232E4AC3", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */

            // Dummy-Values um Änderungen in der Berechnung festzustellen
            string expectedCoefficients = "-0.0533;-1.3581;3.4876;-2.0645;0.3985;0.0000;0.0000;0.0000;0.0000;0.0000;0.0000;0.0000";
            string tableValues = "5;-10;0.5;10;0;0.6;15;10;0.7;20;20;0.8;25;30;0.9;30;40;1;35;50;1.1;40;60;1.2;45;70;1.3;50;75;1.4;55;80;1.5;60;85;1.6;65;90;1.7;70;95;1.8";
            
            // TODO:
            // Referenzwerte kommen von Jochen oder Manuel von PC-F
            bool isPassed = true; // = Execution.Container.SelectTabBaseSettings();
            isPassed &= Flows.ConfigureBaseSettings.BaseConfiguration("Liquid properties", string.Empty, string.Empty, string.Empty, string.Empty);
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsLiquidPropertiesTabPageAvailable(), "Verify that Liquid properties tab is active.");
            isPassed &= Execution.Container.SelectTabLiquidProperties();
            Execution.LiquidProperties.InputFormat = "List";
            Execution.TakeScreenshotOfModule.Run();
            isPassed &= Execution.SetTableValues.SetValues(StringToListConverter.Run(tableValues));
            isPassed &= Execution.LiquidProperties.Recalculate();
            isPassed &= Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= Execution.CoefficientsOverview.CompareCoefficients("0.01", StringToStringArrayConverter.Run(expectedCoefficients));
            isPassed &= Execution.Container.SelectTabLiquidProperties();

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Please have a look at the screenshot to verify Concentration Table Validity");
            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CalculateCoefficients passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CalculateCoefficients failed.");
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