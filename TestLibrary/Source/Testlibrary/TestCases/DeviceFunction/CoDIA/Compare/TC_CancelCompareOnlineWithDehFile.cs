// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CancelCompareOnlineWithDehFile.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CancelCompareOnlineWithDehFile.
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
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Compare.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_CancelCompareOnlineWithDehFile.
    /// </summary>
    // ReSharper disable InconsistentNaming
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class TC_CancelCompareOnlineWithDehFile
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Starts a comparison Online with deh file and cancels it after a user defined time
        /// </summary>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("4AECE0DC-AA77-4C5E-B7FF-E9830207F191", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(2); // Online vs .deh
            isPassed &= Flows.LoadDataset2.Run();
            isPassed &= Flows.CancelCompare.Run(2000);

            Execution.TakeScreenshotOfModule.Run();

            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareOnlineWithDehFile passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareOnlineWithDehFile failed.");
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

        /// <summary>
        /// Starts a comparison Online with deh file and cancels it after a user defined time
        /// </summary>
        /// <param name="pathToDehFile">
        /// The file name and path of a deh file. Use this form: C:\Test\test.deh
        /// </param>
        /// <param name="timeUntilCancelingInMilliseconds">
        /// The time until canceling in milliseconds.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("1ff412a2-7862-4b84-8b0b-928db0144fa9", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToDehFile, int timeUntilCancelingInMilliseconds)
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(2); // Online vs .deh
            isPassed &= Flows.LoadDataset2.Run(pathToDehFile);
            isPassed &= Flows.CancelCompare.Run(timeUntilCancelingInMilliseconds);

            Execution.TakeScreenshotOfModule.Run();

            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareOnlineWithDehFile passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareOnlineWithDehFile failed.");
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