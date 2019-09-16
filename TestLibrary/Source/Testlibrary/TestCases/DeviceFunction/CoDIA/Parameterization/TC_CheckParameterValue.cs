// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CheckParameterValue.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CheckParameterValue.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Parameterization
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_CheckParameterValue.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CheckParameterValue
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Checks the value of a parameter
        /// </summary>
        /// <param name="pathToParameter">
        /// Name and path of parameter to check. Use this form: Micropilot 5x//Setup//Full calibration (4):
        /// </param>
        /// <param name="expectedValue">
        /// Expected value
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("9F631AAC-E2BE-4B21-8779-0CABAE795C1C", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToParameter, string expectedValue)
        {
            StartUp();

            bool isPassed = Execution.CheckParameterValue.Run(pathToParameter, expectedValue);

            if (isPassed)
            {
                Log.Info(string.Format("Parameter: {0} has expected value: {1}", pathToParameter, expectedValue));
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckParameterValue passed.");
            }
            else
            {
                Log.Info(string.Format("Parameter: {0} has not expected value: {1}", pathToParameter, expectedValue));
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckParameterValue failed.");
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