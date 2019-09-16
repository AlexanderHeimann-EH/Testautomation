// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_SetCoefficientsFromDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_SetCoefficientsFromDevice.
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
    /// The test case TC_SetCoefficientsFromDevice.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_SetCoefficientsFromDevice
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Set Coefficients From Device
        /// </summary>
        /// <param name="a0">
        /// The a0.
        /// </param>
        /// <param name="a1">
        /// The a1.
        /// </param>
        /// <param name="a2">
        /// The a2.
        /// </param>
        /// <param name="a3">
        /// The a3.
        /// </param>
        /// <param name="a4">
        /// The a4.
        /// </param>
        /// <param name="b1">
        /// The b1.
        /// </param>
        /// <param name="b2">
        /// The b2.
        /// </param>
        /// <param name="b3">
        /// The b3.
        /// </param>
        /// <param name="d1">
        /// The d1.
        /// </param>
        /// <param name="d2">
        /// The d2.
        /// </param>
        /// <param name="d3">
        /// The d3.
        /// </param>
        /// <param name="d4">
        /// The d4.
        /// </param>
        /// <returns>
        /// <c>true</c> if coefficients have been set, <c>false</c> otherwise.
        /// </returns>
        [TestScriptInformation("F6359289-BF85-4B96-9807-653D95A13EF2", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string a0, string a1, string a2, string a3, string a4, string b1, string b2, string b3, string d1, string d2, string d3, string d4)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= Flows.SetCoefficientsFromDevice.Run(a0, a1, a2, a3, a4, b1, b2, b3, d1, d2, d3, d4);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_SetCoefficientsFromDevice passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_SetCoefficientsFromDevice failed.");
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