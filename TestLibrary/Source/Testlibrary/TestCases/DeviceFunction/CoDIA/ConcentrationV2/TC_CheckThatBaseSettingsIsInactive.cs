// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CheckThatBaseSettingsIsInactive.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CheckThatAllFieldsInBaseSettingsAreGrayed.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.ConcentrationV2
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class TC_CheckThatBaseSettingsIsInactive.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CheckThatBaseSettingsIsInactive
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Verifies that Base Settings tab is inactive
        /// </summary>
        /// <returns><c>true</c> if passed, <c>false</c> otherwise.</returns>
        [TestScriptInformation("94A3F912-2E5A-4528-8FE0-81A2351C23C1", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = AssertFunctions.AreEqual(false, Validation.CheckAvailabilityOfTabPages.IsBaseSettingsTabPageAvailable(), "Verify that Base settings tab is inactive.");       

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckThatAllFieldsInBaseSettingsAreGrayed passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckThatAllFieldsInBaseSettingsAreGrayed failed.");
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