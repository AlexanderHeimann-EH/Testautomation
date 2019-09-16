// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CancelCompareOfflineWithOnline.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CancelCompareOfflineWithOnline.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Compare
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Compare;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Compare.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_CancelCompareOfflineWithOnline.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CancelCompareOfflineWithOnline
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Starts a comparison Online data with Offline data and cancels it after a user defined time
        /// </summary>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("A694409F-C0AC-4859-B5B4-308E9907DF10", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(0);
            isPassed &= Flows.CancelCompare.Run(2000);

            Execution.TakeScreenshotOfModule.Run();
            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareOfflineWithDehFile passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareOfflineWithDehFile failed.");
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

        /// <summary>
        /// Starts a comparison Online data with Offline data and cancels it after a user defined time
        /// </summary>
        /// <param name="timeUntilCancelingInMilliseconds">
        /// The time until canceling in milliseconds.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("f5abe367-6d33-47e0-9704-da9b9271cecf", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(int timeUntilCancelingInMilliseconds)
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(0);
            isPassed &= Flows.CancelCompare.Run(timeUntilCancelingInMilliseconds);

            Execution.TakeScreenshotOfModule.Run();
            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareOfflineWithDehFile passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareOfflineWithDehFile failed.");
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