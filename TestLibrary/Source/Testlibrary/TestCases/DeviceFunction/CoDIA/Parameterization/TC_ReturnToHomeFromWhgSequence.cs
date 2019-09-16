﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ReturnToHomeFromWhgSequence.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ReturnToHomeFromWhgSequence.
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
    /// The test case TC_ReturnToHomeFromWhgSequence.
    /// The test case TC_ReturnToHomeFromSilSequence.
    /// Steps:                   Expected result:
    /// Select [WHG] via tree    - Start page of [WHG] is displayed
    ///                          - Button [Next] is inactive
    ///                          - Button [Cancel] is inactive
    ///                          - Text field for WHG is available
    /// Select home-button       - Diagnostic page is displayed
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TC_ReturnToHomeFromWhgSequence
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Opens SIL/WHG start page, then goes back to the diagnostic page via home button
        /// </summary>
        /// <param name="pathToSilWhgParameter">
        /// The path to the SIL/WHG parameter. E.g.: Levelflex FMP5x//Setup//Advanced setup//SIL/WHG confirmation.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("d653cc05-67c7-4d70-9f40-2a98544ae2ed", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToSilWhgParameter)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.SilWhgFunctions.NavigateToSilWhgWizard(pathToSilWhgParameter);
            isPassed &= Validation.SilWhg.WaitUntilSilSequenceStartPageIsShown(15000);
            isPassed &= AssertFunctions.AreEqual(true, Validation.SilWhg.IsSilSequenceStartPageShown(), "Determining whether SIL/WHG sequence start page is shown.");
            isPassed &= AssertFunctions.AreEqual(false, Validation.SilWhg.IsCancelButtonActive(), "Determining whether Cancel button is inactive.");
            isPassed &= AssertFunctions.AreEqual(false, Validation.SilWhg.IsNextButtonActive(), "Determining whether Next button is inactive.");
            isPassed &= AssertFunctions.AreEqual("Valid", Execution.Application.GetParameter("Set write protection:").ParameterState.ToString(), "Determining whether Set write protection: text field is available.");
            Execution.TakeScreenshotOfModule.OnlineParameterization();
            isPassed &= DeviceFunctionLoader.CoDIA.Parameterization.Functions.MenuArea.Toolbar.Execution.GoToHomeLocation.Run();
            isPassed &= Validation.SilWhg.WaitUntilSilSequenceStartPageIsDisappeared(15000);
            Execution.TakeScreenshotOfModule.OnlineParameterization();

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ReturnToHomeFromWhgSequence passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ReturnToHomeFromWhgSequence failed.");
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