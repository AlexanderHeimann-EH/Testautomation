// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CheckParameterStatus.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The test case TC_CheckParameterStatus.
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
    /// The test case TC_CheckParameterStatus.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CheckParameterStatus
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Compares the current state of a parameter to a expected state specified by the user.
        /// </summary>
        /// <param name="pathToParameter">
        /// The parameter name and path. Use this form: Micropilot 5x//Setup//Full calibration (4):
        /// </param>
        /// <param name="expectedState">
        /// The expected State. Possible states are Insecure, Invalid, Valid, Modified, Dynamic1, Dynamic2, ModifiedOutOfRange, ModifiedInvalidFormat, ModifiedWrong, WriteFailed, NotRecognized
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("c8bf5494-07dd-4d5f-81e6-a692e2b594de", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToParameter, string expectedState)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */

            bool isPassed = Execution.CheckParameterState.Run(pathToParameter, expectedState);
            
            if (isPassed)
            {
                Log.Info(string.Format("Parameter: {0} has expected state: {1}", pathToParameter, expectedState));
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckParameterStatus passed.");
            }
            else
            {
                Log.Info(string.Format("Parameter: {0} has not expected state: {1}", pathToParameter, expectedState));
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckParameterStatus failed.");
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