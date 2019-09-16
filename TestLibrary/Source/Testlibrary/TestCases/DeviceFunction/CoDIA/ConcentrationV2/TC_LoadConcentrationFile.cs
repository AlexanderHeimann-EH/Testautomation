// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_LoadConcentrationFile.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_Load.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.ConcentrationV2
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_LoadConcentrationFile.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_LoadConcentrationFile
    {
        /// <summary>
        /// The assert message.
        /// </summary>
        private const string AssertMessage = "Verify that coefficients are available after loading.";

        /// <summary>
        /// The passed message.
        /// </summary>
        private const string PassedMessage = "Test case TC_LoadConcentrationFile passed.";

        /// <summary>
        /// The failed message.
        /// </summary>
        private const string FailedMessage = "Test case TC_LoadConcentrationFile failed."; 

        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Load Concentration File
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        [TestScriptInformation("28CD7A51-AAC5-42B0-BDB0-481F96BB0906", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */

            string comparingAccuracy = "0.01";
            string expectedCoefficients = "-6.8590; 13.8082; -10.1612; 3.7286; -0.5164; 0.4027; 42.0713; -46.4358; -0.0638; -0.3975; 0.2037; 1.2887";

            bool isPassed = Flows.Load.Run();
            isPassed &= ExecuteSharedFunctions(comparingAccuracy, expectedCoefficients);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), PassedMessage);
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), FailedMessage);
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

        /// <summary>
        /// Load Concentration File
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        [TestScriptInformation("30388BB5-25C9-4AB3-8314-A1794EE10907", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string fileName)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */

            string comparingAccuracy = "0.01";
            string expectedCoefficients = "-6.8590; 13.8082; -10.1612; 3.7286; -0.5164; 0.4027; 42.0713; -46.4358; -0.0638; -0.3975; 0.2037; 1.2887";

            bool isPassed = Flows.Load.Run(fileName);
            isPassed &= ExecuteSharedFunctions(comparingAccuracy, expectedCoefficients);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), PassedMessage);
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), FailedMessage);
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

        /// <summary>
        /// Runs the specified comparing accuracy.
        /// </summary>
        /// <param name="comparingAccuracy">The comparing accuracy e.g. 0.01</param>
        /// <param name="expectedCoefficients">The expected coefficients e.g. -0.5;0.8;6.11;7.1245 etc.</param>
        /// <returns><c>true</c> if passed, <c>false</c> otherwise.</returns>
        [TestScriptInformation("A26D6386-1EE7-4ECA-A9AC-8FFA8F3B9E77", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string comparingAccuracy, string expectedCoefficients)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.Load.Run();
            isPassed &= ExecuteSharedFunctions(comparingAccuracy, expectedCoefficients);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), PassedMessage);
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), FailedMessage);
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="comparingAccuracy">
        /// The comparing accuracy.
        /// </param>
        /// <param name="expectedCoefficients">
        /// The expected coefficients.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        [TestScriptInformation("BDBCC5BA-4C34-464A-8A07-45FF0EE6BFD8", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string fileName, string comparingAccuracy, string expectedCoefficients)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.Load.Run(fileName);
            isPassed &= ExecuteSharedFunctions(comparingAccuracy, expectedCoefficients);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), PassedMessage);
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), FailedMessage);
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

        /// <summary>
        /// The execute shared functions.
        /// </summary>
        /// <param name="comparingAccuracy">
        /// The comparing accuracy.
        /// </param>
        /// <param name="expectedCoefficients">
        /// The expected coefficients.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool ExecuteSharedFunctions(string comparingAccuracy, string expectedCoefficients)
        {
            bool isPassed;
            isPassed = Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= AssertFunctions.AreEqual(true, Execution.CoefficientsOverview.AreCalculatedCoefficientsAvailable(), AssertMessage);
            isPassed &= AssertFunctions.AreEqual(true, Execution.CoefficientsOverview.CompareCoefficients(comparingAccuracy, StringToStringArrayConverter.Run(expectedCoefficients)), "Verify that coefficients have been loaded correctly.");
            isPassed &= Execution.Container.SelectTabExpertResults();
            Execution.TakeScreenshotOfModule.Run();
            return isPassed;
        }

        #endregion
    }
}