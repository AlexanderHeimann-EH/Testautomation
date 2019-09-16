// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CompareOfflineWithOnline.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CompareOfflineWithOnline.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Compare
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Compare;

    /// <summary>
    /// The test case TC_CompareOfflineWithOnline.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CompareOfflineWithOnline
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Compare the online data with the offline data
        /// </summary>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("4693DCF8-1D59-493D-AEF2-F0F2F46458BE", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(0); // Offline vs Online           
            isPassed &= Flows.Compare.Run(600000);

            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            // TODO: Validate comparison result            
            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareOfflineWithOnline passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareOfflineWithOnline failed.");
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

        /// <summary>
        /// Compare the online data with the offline data
        /// </summary>
        /// <param name="timeoutForComparisonInMilliseconds">
        /// The timeout for the comparison in milliseconds.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("744855b1-d79e-4795-a6fd-a4e54b2fb592", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(int timeoutForComparisonInMilliseconds)
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(0); // Offline vs Online           
            isPassed &= Flows.Compare.Run(timeoutForComparisonInMilliseconds);

            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            // TODO: Validate comparison result            
            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareOfflineWithOnline passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareOfflineWithOnline failed.");
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