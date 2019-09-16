// ***********************************************************************
// Assembly         : EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Concentration
// Author           : i02497601
// Created          : 7/17/2015 10:14:35 AM
//
// Last Modified By : i02497601
// Last Modified On : 7/17/2015 10:14:35 AM
// ***********************************************************************
// <copyright file="TC_SetCoefficientsFromDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Concentration
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Concentration;

    /// <summary>
    /// The test case TC_SetCoefficientsFromDevice.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_SetCoefficientsFromDevice
// ReSharper restore InconsistentNaming
    {
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// Opens the tab 'Coefficients Overview and sets the coefficients from device.
        /// </summary>
        /// <param name="a0">The a0 coefficient.</param>
        /// <param name="a1">The a1 coefficient.</param>
        /// <param name="a2">The a2 coefficient.</param>
        /// <param name="a3">The a3 coefficient.</param>
        /// <param name="a4">The a4 coefficient.</param>
        /// <param name="b1">The b1 coefficient.</param>
        /// <param name="b2">The b2 coefficient.</param>
        /// <param name="b3">The b3 coefficient.</param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("589694A6-7EEF-408A-9090-3833D1118C65", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string a0, string a1, string a2, string a3, string a4, string b1, string b2, string b3)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */

            bool isPassed = DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= Flows.SetCoefficientsFromDevice.Run(a0, a1, a2, a3, a4, b1, b2, b3);

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
