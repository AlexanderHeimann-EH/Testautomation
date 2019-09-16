// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CompareCoefficientsReadFromDeviceWithExpectedCoefficients.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CompareCoefficientsReadFromDeviceWithExpectedCoefficients.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Concentration
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_CompareCoefficientsReadFromDeviceWithExpectedCoefficients.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CompareCoefficientsReadFromDeviceWithExpectedCoefficients
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Opens the tab Coefficients overview and compares the coefficients read from device against a set of expected coefficients provided by the user.
        /// </summary>
        /// <param name="accuracy">
        /// The maximum allowed difference between two coefficients. E.g. 0.001.
        /// </param>
        /// <param name="expectedCoefficients">
        /// String with the expected coefficients. Use semicolons to separate the values. E.g. -5.0;10.1;8.9
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("B9525D36-5FB9-4D03-82FB-73BA54021CE8", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string accuracy, string expectedCoefficients)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= Execution.CoefficientsOverview.AreReadCoefficientsAvailable();
            isPassed &= Execution.CoefficientsOverview.CompareCoefficientsFromDevice(accuracy, StringToStringArrayConverter.Run(expectedCoefficients));

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareCoefficientsReadFromDeviceWithExpectedCoefficients passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareCoefficientsReadFromDeviceWithExpectedCoefficients failed.");
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