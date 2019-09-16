// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CompareOfflineWithDehFile.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CompareOfflineWithDehFile.
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
    /// The test case TC_CompareOfflineWithDehFile.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TC_CompareOfflineWithDehFile
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Compares the offline data with a .deh file
        /// </summary>
        /// <returns>
        /// True if test case is passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("310D723F-7D4E-4F6C-8142-1F787783D449", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(1); // Offline vs .deh
            isPassed &= Flows.LoadDataset2.Run();
            isPassed &= Flows.Compare.Run(600000);

            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            // TODO: Validate comparison result  
            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareOfflineWithDehFile passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareOfflineWithDehFile failed.");
                Log.Screenshot();
            }

            TearDown();

            return isPassed;
        }

        /// <summary>
        /// Compares the offline data with a .deh file
        /// </summary>
        /// <param name="pathToDehFile">
        /// The file name and path of a deh file. Use this form: C:\Test\test.deh
        /// </param>
        /// <param name="timeoutForComparisonInMilliseconds">
        /// The timeout For the comparison in milliseconds.
        /// </param>
        /// <returns>
        /// True if test case is passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("08e51512-e559-4b1a-ae62-750fd97f1375", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToDehFile, int timeoutForComparisonInMilliseconds)
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(1); // Offline vs .deh
            isPassed &= Flows.LoadDataset2.Run(pathToDehFile);
            isPassed &= Flows.Compare.Run(timeoutForComparisonInMilliseconds);

            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            // TODO: Validate comparison result  
            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareOfflineWithDehFile passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareOfflineWithDehFile failed.");
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