// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_LockWhgAndCheckParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_LockWhgAndCheckParameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Parameterization
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_LockWhgAndCheckParameter.
    /// Steps:                   Expected result:
    /// Select [WHG] via tree    - Start page of [WHG] is displayed
    ///                          - Button [Next] is inactive
    ///                          - Button [Cancel] is inactive
    ///                          - Text field for [WHG] is available
    /// Enter SIL Code 7450 to start [SIL]-sequence    - Button [Next] (or similar) becomes active
    /// Go through [WHG]-sequence, modify parameters and document them    - Parameters changed
    /// Enter SIL-Code 7450 to activate [SIL]-sequence    - SIL sequence is left, parameter are locked
    /// Check several menus    - All parameters are read only
    /// Select [Deactivate SIL/WHG] via tree    - Start page of [WHG] is displayed
    ///                          - Button [Next] is inactive
    ///                          - Button [Cancel] is inactive
    ///                          - Text field for WHG is available
    /// Enter WHG-Code 7450 to WHG unlock Device    - WHG sequence is left, parameter are unlocked
    /// Check several menus    - Parameters could be accessed
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TC_LockWhgAndCheckParameter
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Goes through a SIL/WHG sequence and locks the device. Unlocks it afterwards. The user can specify parameter for which the locking state will be checked during the test.
        /// </summary>
        /// <param name="pathToSilWhgParameter">
        /// The path to the SIL/WHG parameter. E.g.: Levelflex FMP5x//Setup//Advanced setup//SIL/WHG confirmation.
        /// </param>
        /// <param name="silWhgCode">
        /// The code for SIL/WHG.
        /// </param>
        /// <param name="pathToDeactivateSilWhg">
        /// The path To Deactivate Sil Whg. E.g.: Levelflex FMP5x//Setup//Advanced setup//Deactivate SIL/WHG.
        /// </param>
        /// <param name="pathToParameter">
        /// A list with paths to parameter for which the locking state during the SIL WHG test will be checked. A path looks like this: Levelflex FMP5x//Setup//Full calibration (4).
        /// </param>
        /// <param name="timeoutForSilWhgPageToDisappear">
        /// The timeout for SIL/WHG page to disappear after the SIL/WHG sequence is left or finished.
        /// </param>
        /// <param name="timeoutForNextButton">
        /// The timeout in milliseconds for the next button to become active after a parameter has been set. This can take some time. Recommended: 15000 milliseconds.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("70241c7e-717f-47c3-be36-1fc4630e3d93", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToSilWhgParameter, string silWhgCode, string pathToDeactivateSilWhg, string pathToParameter, int timeoutForSilWhgPageToDisappear, int timeoutForNextButton)
        {
           return Run(pathToSilWhgParameter, silWhgCode, pathToDeactivateSilWhg, StringToListConverter.Run(pathToParameter), timeoutForSilWhgPageToDisappear, timeoutForNextButton);
        }

        /// <summary>
        /// Goes through a SIL/WHG sequence and locks the device. Unlocks it afterwards. The user can specify parameter for which the locking state will be checked during the test.
        /// </summary>
        /// <param name="pathToSilWhgParameter">
        /// The path to the SIL/WHG parameter. E.g.: Levelflex FMP5x//Setup//Advanced setup//SIL/WHG confirmation.
        /// </param>
        /// <param name="silWhgCode">
        /// The code for SIL/WHG.
        /// </param>
        /// <param name="pathToDeactivateSilWhg">
        /// The path To Deactivate Sil Whg. E.g.: Levelflex FMP5x//Setup//Advanced setup//Deactivate SIL/WHG.
        /// </param>
        /// <param name="pathToParameter">
        /// A list with paths to parameter for which the locking state during the SIL WHG test will be checked. A path looks like this: Levelflex FMP5x//Setup//Full calibration (4).
        /// </param>
        /// <param name="timeoutForSilWhgPageToDisappear">
        /// The timeout for SIL/WHG page to disappear after the SIL/WHG sequence is left or finished.
        /// </param>
        /// <param name="timeoutForNextButton">
        /// The timeout in milliseconds for the next button to become active after a parameter has been set. This can take some time. Recommended: 15000 milliseconds.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        public static bool Run(string pathToSilWhgParameter, string silWhgCode, string pathToDeactivateSilWhg, List<string> pathToParameter, int timeoutForSilWhgPageToDisappear, int timeoutForNextButton)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.SilWhgFunctions.NavigateToSilWhgWizard(pathToSilWhgParameter);
            isPassed &= Validation.SilWhg.WaitUntilSilSequenceStartPageIsShown(timeoutForSilWhgPageToDisappear);
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsSilSequenceStartPageShown(), "Determining whether SIL/WHG sequence start page is shown.");
            isPassed &= AssertFunctions.AreEqual(false, Validation.SilWhg.IsCancelButtonActive(), "Determining whether Cancel button is inactive.");
            isPassed &= AssertFunctions.AreEqual(false, Validation.SilWhg.IsNextButtonActive(), "Determining whether Next button is inactive.");
            isPassed &= AssertFunctions.AreEqual("Valid", Execution.Application.GetParameter("Set write protection:").ParameterState.ToString(), "Determining whether Set write protection: text field is available.");
            Execution.TakeScreenshotOfModule.OnlineParameterization();

            isPassed &= Execution.SilWhgFunctions.SetSilWhgParameter("Set write protection:", silWhgCode);
            isPassed &= Validation.SilWhg.WaitUntilNextButtonIsActive(15000);
            isPassed &= Execution.SilWhgFunctions.Next();

            Execution.TakeScreenshotOfModule.OnlineParameterization();
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsCancelButtonActive(), "Determining whether Cancel button is active.");
            isPassed &= AssertFunctions.AreEqual(false, Validation.SilWhg.IsNextButtonActive(), "Determining whether Next button is inactive.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsPreviousButtonActive(), "Determining whether Previous button is active.");

            isPassed &= Execution.SilWhgFunctions.SetSilWhgParameter("Commissioning:", "Expert mode");
            isPassed &= Validation.SilWhg.WaitUntilNextButtonIsActive(15000);
            isPassed &= Execution.SilWhgFunctions.Next();

            isPassed &= Validation.SilWhg.WaitUntilNextButtonIsActive(15000);
            isPassed &= Execution.SilWhgFunctions.Next();
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsCancelButtonActive(), "Determining whether Cancel button is active.");
            isPassed &= AssertFunctions.AreEqual(false, Validation.SilWhg.IsNextButtonActive(), "Determining whether Next button is inactive.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsPreviousButtonActive(), "Determining whether Previous button is active.");

            isPassed &= Execution.SilWhgFunctions.SetSilWhgParameter("Confirm function test:", "Yes");
            isPassed &= Validation.SilWhg.WaitUntilNextButtonIsActive(15000);
            isPassed &= Execution.SilWhgFunctions.Next();

            isPassed &= Execution.SilWhgFunctions.SetSilWhgParameter("Set write protection:", silWhgCode);
            Execution.TakeScreenshotOfModule.OnlineParameterization();
            isPassed &= Validation.SilWhg.WaitUntilSilSequenceStartPageIsDisappeared(timeoutForSilWhgPageToDisappear);
            isPassed &= Flows.CheckParameterLockingState.Run(pathToParameter, true);

            isPassed &= Execution.SilWhgFunctions.NavigateToSilWhgWizard(pathToDeactivateSilWhg);
            isPassed &= Validation.SilWhg.WaitUntilResetSilSequenceStartPageIsShown(timeoutForSilWhgPageToDisappear);
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsResetSilSequenceStartPageShown(), "Determining whether SIL/WHG sequence start page is shown.");
            isPassed &= AssertFunctions.AreEqual("Valid", Execution.Application.GetParameter("Reset write protection:").ParameterState.ToString(), "Determining whether reset write protection: text field is available.");
            Execution.TakeScreenshotOfModule.OnlineParameterization();
            isPassed &= AssertFunctions.AreEqual(false, Validation.SilWhg.IsCancelButtonActive(), "Determining whether Cancel button is inactive.");
            isPassed &= Execution.SilWhgFunctions.SetSilWhgParameter("Reset write protection:", silWhgCode);
            isPassed &= Validation.SilWhg.WaitUntilResetSilSequenceStartPageIsDisappeared(timeoutForSilWhgPageToDisappear);
            Execution.TakeScreenshotOfModule.OnlineParameterization();

            Flows.CheckParameterLockingState.Run(pathToParameter, false);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_LockWhgAndCheckParameter passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_LockWhgAndCheckParameter failed.");
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