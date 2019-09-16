// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ImportConcentrationFile.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_Import.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.ConcentrationV2
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_ImportConcentrationFile.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_ImportConcentrationFile
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Imports a default Concentration file from the report folder.Makes a screenshot of tab Expert results to check if the diagram is not shown any longer and verifies that there is no critical error afterwards.
        /// </summary>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("85664B52-C01F-4279-9A67-F603640EA5C4", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.Import.Run();

            isPassed &= Execution.Container.SelectTabExpertResults();
            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");
            Execution.TakeScreenshotOfModule.Run();

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ImportConcentrationFile passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ImportConcentrationFile failed.");
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

        /// <summary>
        /// Imports a Concentration file.Makes a screenshot of tab Expert results to check if the diagram is not shown any longer and verifies that there is no critical error afterwards.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("B40BE22E-3623-47DF-80A0-E57C05E8B24F", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string fileName)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.Import.Run(fileName);

            isPassed &= Execution.Container.SelectTabExpertResults();
            Execution.TakeScreenshotOfModule.Run();
            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ImportConcentrationFile passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ImpTC_ImportConcentrationFileort failed.");
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