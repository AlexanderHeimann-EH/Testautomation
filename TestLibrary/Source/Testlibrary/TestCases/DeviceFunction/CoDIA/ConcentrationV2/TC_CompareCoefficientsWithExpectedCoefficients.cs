// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CompareCoefficientsWithExpectedCoefficients.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CheckExpertResults.
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
    /// The test case TC_CompareCoefficientsWithExpectedCoefficients.cs.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CompareCoefficientsWithExpectedCoefficients
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Compare Coefficients With Expected Coefficients
        /// </summary>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("340530E0-AFC8-460B-AE93-B42C83DE8AA3", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */

            string[] expectedCoefficients = { "-6.8590", "13.8082", "-10.1612", "3.7286", "-0.5164", "0.4027", "42.0713", "-46.4358", "-0.0638", "-0.3975", "0.2037", "1.2887" };

            bool isPassed = Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= Execution.CoefficientsOverview.AreCalculatedCoefficientsAvailable();
            isPassed &= Execution.CoefficientsOverview.CompareCoefficients("0.01", expectedCoefficients);
            
            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareCoefficientsWithExpectedCoefficients passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareCoefficientsWithExpectedCoefficients failed.");
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

        /// <summary>
        /// Opens tab Expert results and makes a screenshot of every result diagram available.
        /// </summary>
        /// <param name="expectedCoefficients">
        /// The expected Coefficients given in a string separated by ";"
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("6229E30F-6B4B-402B-B0CC-FDBD44C2ECF4", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string expectedCoefficients)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */

            // Todo: convert string to string[]
            string[] expectedCoefficient = expectedCoefficients.Split(';');

            bool isPassed = Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= Execution.CoefficientsOverview.AreCalculatedCoefficientsAvailable();
            isPassed &= Execution.CoefficientsOverview.CompareCoefficients("0.01", expectedCoefficient);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareCoefficientsWithExpectedCoefficients passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CompareCoefficientsWithExpectedCoefficients failed.");
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