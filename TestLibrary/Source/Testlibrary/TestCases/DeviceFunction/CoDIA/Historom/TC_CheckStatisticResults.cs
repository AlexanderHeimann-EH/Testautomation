﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CheckStatisticResults.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CheckStatisticResults.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Historom
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Historom.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_CheckStatisticResults.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CheckStatisticResults
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Checks that the tab Statistic results contains values.
        /// </summary>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("07a4e48b-cd18-4907-ba3c-2433b64073c8", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.RunSelectTab.Run(2);
            isPassed &= Validation.StatisticResults.HasStatisticTabValues();

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckStatisticResults passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckStatisticResults failed.");
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