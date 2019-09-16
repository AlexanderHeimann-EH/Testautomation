// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CheckThatReferenceValuesIsActive.cs" company="Endress+Hauser Process Solutions AG">
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
    /// Class TC_CheckThatReferenceValuesIsActive.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CheckThatReferenceValuesIsActive
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Verifies that Reference Values tab is active
        /// </summary>
        /// <returns><c>true</c> if passed, <c>false</c> otherwise.</returns>
        [TestScriptInformation("6B1E5478-A12B-4764-A277-C6B67BCC274B", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = AssertFunctions.AreEqual(true, Validation.CheckAvailabilityOfTabPages.IsReferenceValuesTabPageAvailable(), "Verify that Reference Values tab is active.");       

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