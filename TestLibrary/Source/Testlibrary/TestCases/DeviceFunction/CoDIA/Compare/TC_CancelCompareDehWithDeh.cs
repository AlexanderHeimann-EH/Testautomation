// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CancelCompareDehWithDeh.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CancelCompareDehWithDeh.
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
    /// The test case TC_CancelCompareDehWithDeh.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TC_CancelCompareDehWithDeh
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Starts a comparison Online with deh-file and cancels it after a user defined time
        /// </summary>
        /// <returns>
        /// The result of the test case.
        /// </returns>
        [TestScriptInformation("4E32A68E-3C5D-4D82-9006-771D3642291C", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(3);
            isPassed &= Flows.LoadDataset1.Run();
            isPassed &= Flows.LoadDataset2.Run();
            isPassed &= Flows.CancelCompare.Run(2000);

            Execution.TakeScreenshotOfModule.Run();
            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareDehWithDeh passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareDehWithDeh failed.");
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

        /// <summary>
        /// Starts a comparison Online with deh-file and cancels it after a user defined time
        /// </summary>
        /// <param name="pathToDehFile">
        /// The file name and path of a deh file. Use this form: C:\Test\test.deh
        /// </param>
        /// <param name="pathToOtherDehFile">
        /// The file name and path of another deh file. Use this form: C:\Test\test1.deh
        /// </param>
        /// <param name="timeUntilCancelingInMilliseconds">
        /// The time until canceling in milliseconds.
        /// </param>
        /// <returns>
        /// The result of the test case.
        /// </returns>
        [TestScriptInformation("b7efe27e-7688-4f76-a37d-648371e3aca8", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToDehFile, string pathToOtherDehFile, int timeUntilCancelingInMilliseconds)
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(3);
            isPassed &= Flows.LoadDataset1.Run(pathToDehFile);
            isPassed &= Flows.LoadDataset2.Run(pathToOtherDehFile);
            isPassed &= Flows.CancelCompare.Run(timeUntilCancelingInMilliseconds);

            Execution.TakeScreenshotOfModule.Run();
            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareDehWithDeh passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelCompareDehWithDeh failed.");
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