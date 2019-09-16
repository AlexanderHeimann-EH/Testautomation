// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CompareDehFileWithDehFile.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CompareDehFileWithDehFile.
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
    /// The test case TC_CompareDehFileWithDehFile.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TC_CompareDehFileWithDehFile
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Compares two .deh files
        /// </summary>
        /// <returns>
        /// True if test case is passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("3ABF8E59-0F66-4C2D-9350-573A702BD975", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(3); // .deh vs .deh
            isPassed &= Flows.LoadDataset1.Run();
            isPassed &= Flows.LoadDataset2.Run();
            isPassed &= Flows.Compare.Run(600000);

            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            // TODO: Validate comparison result            
            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareDehFileWithDehFile passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareDehFileWithDehFile failed.");
                Log.Screenshot();
            }

            TearDown();

            return isPassed;
        }

        /// <summary>
        /// Compares two .deh files
        /// </summary>
        /// <param name="pathToDehFile">
        /// The file name and path of a deh file. Use this form: C:\Test\test.deh
        /// </param>
        /// <param name="pathToOtherDehFile">
        /// The file name and path of another deh file. Use this form: C:\Test\test1.deh
        /// </param>
        /// <param name="timeoutForComparisonInMilliseconds">
        /// The timeout For the comparison in milliseconds.
        /// </param>
        /// <returns>
        /// True if test case is passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("f7bb5a3e-b3a3-40d4-9f2a-c7aaf3f7c97b", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToDehFile, string pathToOtherDehFile, int timeoutForComparisonInMilliseconds)
        {
            StartUp();

            bool isPassed = Flows.SelectMode.Run(3); // .deh vs .deh
            isPassed &= Flows.LoadDataset1.Run(pathToDehFile);
            isPassed &= Flows.LoadDataset2.Run(pathToOtherDehFile);
            isPassed &= Flows.Compare.Run(timeoutForComparisonInMilliseconds);

            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            // TODO: Validate comparison result            
            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareDehFileWithDehFile passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareDehFileWithDehFile failed.");
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