

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Viscosity
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// The test case TC_CompareCoefficients.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_CompareCoefficients
// ReSharper restore InconsistentNaming
    {
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////

        /// <summary>
        /// Compares the compensation coefficients from the Results tab with values provided by the user.
        /// </summary>
        /// <param name="accuracy">Maximum allowed difference between two coefficients.</param>
        /// <param name="expectedValueForX1">Value to compare the coefficient x1 with.</param>
        /// <param name="expectedValueForX2">Value to compare the coefficient x2 with.</param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("d058c26c-ec1e-4d5a-bcbc-662294839b03", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string accuracy, string expectedValueForX1, string expectedValueForX2)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            var expectedCoefficients = new[] { expectedValueForX1, expectedValueForX2 };
            bool isPassed = DeviceFunctionLoader.CoDIA.Viscosity.Functions.ApplicationArea.MainView.Execution.SelectTab.Run(1);
            isPassed &= DeviceFunctionLoader.CoDIA.Viscosity.Functions.ApplicationArea.MainView.Execution.TabResults.CompareCoefficients(accuracy, expectedCoefficients);
            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareCoefficients passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareCoefficients failed.");
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

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
    }
}
