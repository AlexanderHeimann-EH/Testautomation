// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CheckReferenceValueTabBehaviour.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class TC_ActivateSoftwareOption.
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
    /// Class TC_CheckReferenceValueTabBehaviour.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_CheckReferenceValueTabBehaviour
// ReSharper restore InconsistentNaming
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Check Reference Tab Behaviour by selected and not selected %mass/%volume
        /// </summary>
        /// <returns>
        /// True if passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("7822D6A2-58E2-4302-95C4-F3E4FEB58110", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            // TC_CheckReferenceValueTabBehaviour
            // Select Tab Base settings
            //  Check Tab Reference Values for enabled state = false
            // Set Liquid Type to %mass%volume
            //  Check Tab Reference Values for enabled state = true
            // Select Tab Reference Values
            //  Check controls for read only state = true
            //  Check controls for enabled state = true
            // Select Tab Base settings
            // Set Liquid Type to non %mass%volume
            //  Check Tab Reference Values for enabled state = false
            const string Description = "Description of TC_CheckReferenceValueTabBehaviour: \r\n " +
                "-------------------------------------------------- \r\n " +
                "- Select Tab Base settings \r\n " +
                "-> Check Tab Reference Values for enabled state = false \r\n " +
                "- Set Liquid Type to %mass%volume \r\n " +
                "-> Check Tab Reference Values for enabled state = true \r\n " +
                "- Select Tab Reference Values \r\n " +
                "-> Check controls for read only state = true \r\n " +
                "-> Check controls for enabled state = true \r\n " +
                "- Select Tab Base settings \r\n " +
                "- Set Liquid Type to non %mass%volume \r\n " +
                "-> Check Tab Reference Values for enabled state = false";
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), Description);

            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */

            bool isPassed = false;
            isPassed = Execution.Container.SelectTabBaseSettings();
            isPassed &= AssertFunctions.AreEqual(false, Validation.CheckAvailabilityOfTabPages.IsReferenceValuesTabPageAvailable(), "Verify that Reference Values tab is inactive.");
            isPassed &= Flows.ConfigureBaseSettings.BaseConfiguration("Predefined liquid", "%mass / %volume", string.Empty, string.Empty, string.Empty);
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsReferenceValuesTabPageAvailable(), "Verify that Reference Values tab is active.");
            isPassed &= Execution.Container.SelectTabReferenceValues();
            
            // Todo:
            // isPassed &= Check controls for read only state = true
            // isPassed &= Check controls for enabled state = true
            isPassed &= Execution.Container.SelectTabBaseSettings();
            isPassed &= AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsBaseSettingsTabPageAvailable(), "Verify that Base Settings tab is active.");
            isPassed &= Flows.ConfigureBaseSettings.BaseConfiguration(string.Empty, "Glucose in water", string.Empty, string.Empty, string.Empty);
            isPassed &= AssertFunctions.AreEqual(false, Validation.CheckAvailabilityOfTabPages.IsReferenceValuesTabPageAvailable(), "Verify that Reference Values tab is inactive.");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckReferenceValueTabBehaviour passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckReferenceValueTabBehaviour failed.");
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