// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CancelWhgSequence.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_Whg1.
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
    /// The test case TC_CancelWhgSequence.
    /// Steps:                   Expected result:
    /// Select [SIL] via tree    - Start page of [WHG] is displayed
    ///                          - Button [Next] is inactive
    ///                          - Button [Cancel] is inactive
    ///                          - Text field for [WHG] is available
    /// Enter WHG Code 7450 to start [WHG]-sequence    - Button [Next] (or similar) becomes active
    /// Go forward to next page  - Parameter tree becomes hidden
    ///                          - Parameter is available that could be changed
    ///                          - Button [Next] is inactive
    ///                          - Button [Previous] is active
    ///                          - Button [Cancel] is active
    /// Change parameter and confirm    - Button [Next] becomes active
    /// Go forward to another page    - Parameter is available that could be changed
    ///                               - Button [Next] is inactive
    ///                               - Button [Previous] is active
    ///                               - Button [Cancel] is active"
    /// Change a parameter value validly    - Parameter is accepted
    /// Go back to a previous page    - Button [Next] is available and active 
    ///                               - Button [Previous] is available and active
    ///                               - Button [Cancel] is available and active
    /// Press button [Cancel]    - Start page of [WHG] is displayed
    ///                               -Button [Next] is inactive
    ///                               -Button [Cancel] is inactive
    ///                               -Parameter tree is displayed
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TC_CancelWhgSequence
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Starts a SIL/WHG sequence but cancels during the process.
        /// </summary>
        /// <param name="pathToSilWhgParameter">
        /// The path to the SIL/WHG parameter. E.g.: Levelflex FMP5x//Setup//Advanced setup//SIL/WHG confirmation.
        /// </param>
        /// <param name="silWhgCode">
        /// The code for SIL/WHG.
        /// </param>
        /// <param name="timeoutForCanceling">
        /// The timeout in milliseconds for the canceling process. Canceling can take some time. Recommended: 15000 milliseconds.
        /// </param>
        /// <param name="timeoutForNextButton">
        /// The timeout in milliseconds for the next button to become active after a parameter has been set. This can take some time. Recommended: 15000 milliseconds.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("a57b5bc8-0d23-44d5-a421-b08bd73d6460", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToSilWhgParameter, string silWhgCode, int timeoutForCanceling, int timeoutForNextButton)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.SilWhgFunctions.NavigateToSilWhgWizard(pathToSilWhgParameter);
            isPassed &= Validation.SilWhg.WaitUntilSilSequenceStartPageIsShown(timeoutForCanceling);
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsSilSequenceStartPageShown(), "Determining whether SIL/WHG sequence start page is shown.");
            isPassed &= AssertFunctions.AreEqual(false, Validation.SilWhg.IsCancelButtonActive(), "Determining whether Cancel button is inactive.");
            isPassed &= AssertFunctions.AreEqual(false, Validation.SilWhg.IsNextButtonActive(), "Determining whether Next button is inactive.");
            isPassed &= AssertFunctions.AreEqual("Valid", Execution.Application.GetParameter("Set write protection:").ParameterState.ToString(), "Determining whether Set write protection: text field is available.");
            Execution.TakeScreenshotOfModule.OnlineParameterization();

            isPassed &= Execution.SilWhgFunctions.SetSilWhgParameter("Set write protection:", silWhgCode);
            isPassed &= Validation.SilWhg.WaitUntilNextButtonIsActive(timeoutForNextButton);
            isPassed &= Execution.SilWhgFunctions.Next();

            isPassed &= AssertFunctions.AreEqual(false, Validation.SilWhg.IsNavigationTreeShown(), "Determining whether Navigation tree is not visible any longer.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsCancelButtonActive(), "Determining whether Cancel button is active.");
            isPassed &= AssertFunctions.AreEqual(false, Validation.SilWhg.IsNextButtonActive(), "Determining whether Next button is inactive.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsPreviousButtonActive(), "Determining whether Previous button is active.");
            Execution.TakeScreenshotOfModule.OnlineParameterization();

            isPassed &= Execution.SilWhgFunctions.SetSilWhgParameter("Commissioning:", "Expert mode");
            isPassed &= Validation.SilWhg.WaitUntilNextButtonIsActive(timeoutForNextButton);
            isPassed &= Execution.SilWhgFunctions.Next();

            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsCancelButtonActive(), "Determining whether Cancel button is active.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsPreviousButtonActive(), "Determining whether Previous button is active.");

            isPassed &= Execution.SilWhgFunctions.Cancel();
            isPassed &= Validation.SilWhg.WaitUntilCancelingIsFinished(timeoutForCanceling);
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsSilSequenceStartPageShown(), "Determining whether SIL/WHG sequence start page is shown.");
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsNavigationTreeShown(), "Determining whether Navigation tree is visible again.");
            Execution.TakeScreenshotOfModule.OnlineParameterization();

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelWhgSequence passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CancelWhgSequence failed.");
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