// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CreateDocumentationHistorom.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CreateDocumentationHistorom.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Historom
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.CreateDocumentation;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Historom.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_CreateDocumentationHistorom.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TC_CreateDocumentationHistorom
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Runs this instance.
        /// </summary>
        /// <param name="fileName">
        /// Filename and path under which file is saved. Use this form: C:\Test\testPrintout
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("76999008-3ebc-4fd1-8d56-2c08ea62fd7f", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string fileName)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.OpenModuleOnline.Run();

            /* TODO: Check whether HistoROM is selected. */
            isPassed &= Flows.SaveAsPdf.Run(fileName);
            isPassed &= Flows.CloseModule.Run();
            isPassed &= Execution.RunSelectTab.Run(1);
            Execution.TakeScreenshotOfModule.Run();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Please compare the HistoROM diagram screenshot shown in the test report with the 'Create Documentation' printout: \"" + fileName + "\"." + "The printout must contain: - Scaling and zooming like in [HistoROM] - Curves like in [HistoROM] - Cursors like in [HistoROM] - Event markers like in [HistoROM] - Measurement values are available  - Events are available");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CreateDocumentationHistorom passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CreateDocumentationHistorom failed.");
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