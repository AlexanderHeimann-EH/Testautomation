﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_OpenModuleOnline.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_OpenModuleOnline.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.CreateDocumentation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.CreateDocumentation;

    /// <summary>
    /// The test case TC_OpenModuleOnline.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_OpenModuleOnline
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Opens the module Create Documentation when the device is online.
        /// </summary>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("3c5e1c86-a3ce-4fcd-bf76-00766de53ad2", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.OpenModuleOnline.Run();

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_OpenModuleOnline passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_OpenModuleOnline failed.");
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

        /// <summary>
        /// Opens the module Create Documentation when the device is online.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout In Milliseconds for module opening.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("48D62304-358F-4130-89D6-BAD71209B977", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(int timeoutInMilliseconds)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.OpenModuleOnline.Run(timeoutInMilliseconds);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_OpenModuleOnline passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_OpenModuleOnline failed.");
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