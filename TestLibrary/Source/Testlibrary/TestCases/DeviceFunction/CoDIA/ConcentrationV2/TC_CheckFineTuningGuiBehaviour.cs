// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CheckFineTuningGuiBehaviour.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class TC_CheckFineTuningGuiBehaviour.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.ConcentrationV2
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class TC_CheckFineTuningGuiBehaviour.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_CheckFineTuningGuiBehaviour
// ReSharper restore InconsistentNaming
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Check Gui Control Behaviour of Fine Tuning
        /// </summary>
        /// <returns>
        /// True if passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("8543CAA8-8F26-43B8-A600-50E6AE355982", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            // TC_CheckFineTuningGuiBehaviour
            // Set Calculation Base to Fine Tuning
            // Read Coefficients from Device
            //  Check user notification for success
            // Select Tab Coefficients Overview
            //  Check Coefficients from Device for != nan
            // Select Tab Liquid Properties
            //  Check control Recalculate for enabled state = false
            // Enter values into table
            //  Check control Recalculate for enabled state = true
            // Recalculate Coefficients
            //  Check user notification for success
            // Select Tab Coefficients Overview
            //  Check calculated Coefficients for != nan
            const string Description = "Description of TC_CheckFineTuningGuiBehaviour: \r\n " + 
                "-------------------------------------------------- \r\n " + 
                "- Set Calculation Base to Fine Tuning \r\n " + 
                "- Read Coefficients from Device \r\n " + 
                "-> Check user notification for success \r\n " + 
                "- Select Tab Coefficients Overview \r\n " + 
                "-> Check Coefficients from Device for != nan \r\n " + 
                "- Select Tab Liquid Properties \r\n " + 
                "->  Check control Recalculate for enabled state = false \r\n " + 
                "- Enter values into table \r\n " + 
                "->  Check control Recalculate for enabled state = true \r\n " + 
                "- Recalculate Coefficients \r\n " + 
                "->  Check user notification for success \r\n " +
                "- Select Tab Coefficients Overview \r\n " + 
                "->  Check calculated Coefficients for != nan \r\n ";
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), Description);

            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */

            // TC_CheckFineTuningGuiBehaviour
            // Set Calculation Base to Fine Tuning
            // Read Coefficients from Device
            //  Check user notification for success
            // Select Tab Coefficients Overview
            //  Check Coefficients from Device for != nan
            // Select Tab Liquid Properties
            //  Check control Recalculate for enabled state = false
            // Enter values into table
            //  Check control Recalculate for enabled state = true
            // Recalculate Coefficients
            //  Check user notification for success
            // Select Tab Coefficients Overview
            //  Check calculated Coefficients for != nan
            const string TableValues = "1;1;1;2;2;2;3;3;3;4;4;4;5;5;5;6;6;6;7;7;7;8;8;8;9;9;9;10;10;10;11;11;11;12;12;12";
            
            bool isPassed = false;
            isPassed = AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsBaseSettingsTabPageAvailable(), "Verify that Base Settings tab is active.");
            isPassed &= Execution.Container.SelectTabBaseSettings();
            isPassed &= Flows.ConfigureBaseSettings.BaseConfiguration("Fine tuning settings", string.Empty, string.Empty, string.Empty, string.Empty);
            isPassed &= Flows.Read.Run();
            
            // Todo:
            // isPassed &= Check user notification for success
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsCoefficientOverviewTabPageAvailable(), "Verify that Coefficients Overview tab is active.");
            isPassed &= Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= Execution.CoefficientsOverview.AreReadCoefficientsAvailable();
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsLiquidPropertiesTabPageAvailable(), "Verify that Liquid Properties tab is active.");
            isPassed &= Execution.Container.SelectTabLiquidProperties();

            // Todo:
            // Check control Recalculate for enabled state = false
            isPassed &= Execution.SetTableValues.SetValues(StringToListConverter.Run(TableValues));

            // Todo:
            // Check control Recalculate for enabled state = true
            isPassed &= Execution.LiquidProperties.Recalculate();

            // Todo:
            // Check user notification for success 
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsCoefficientOverviewTabPageAvailable(), "Verify that Coefficients Overview tab is active.");
            isPassed &= Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= Execution.CoefficientsOverview.AreCalculatedCoefficientsAvailable();

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckFineTuningGuiBehaviour passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckFineTuningGuiBehaviour failed.");
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