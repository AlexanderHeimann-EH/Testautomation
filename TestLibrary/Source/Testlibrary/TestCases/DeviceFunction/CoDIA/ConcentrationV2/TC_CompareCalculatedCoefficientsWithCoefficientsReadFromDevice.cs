// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CompareCalculatedCoefficientsWithCoefficientsReadFromDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CompareCalculatedCoefficientsWithCoefficientsReadFromDevice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.ConcentrationV2
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_CompareCalculatedCoefficientsWithCoefficientsReadFromDevice.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CompareCalculatedCoefficientsWithCoefficientsReadFromDevice
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Opens the tab Coefficients overview and compares the coefficients read from device with the calculated coefficients.
        /// </summary>
        /// <param name="accuracy">
        /// The maximum allowed difference between two coefficients. E.g. 0.001.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("CFBDCFE8-04D9-4931-8D8F-C5A2CCB0D7A6", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string accuracy)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= Execution.CoefficientsOverview.AreCalculatedCoefficientsAvailable();
            isPassed &= Execution.CoefficientsOverview.AreReadCoefficientsAvailable();
            isPassed &= Execution.CoefficientsOverview.CompareCoefficients(accuracy);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareCalculatedCoefficientsWithCoefficientsReadFromDevice passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareCalculatedCoefficientsWithCoefficientsReadFromDevice failed.");
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