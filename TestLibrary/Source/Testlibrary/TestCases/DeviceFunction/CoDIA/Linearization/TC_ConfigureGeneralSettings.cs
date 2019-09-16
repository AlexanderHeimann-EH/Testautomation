// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConfigureGeneralSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ConfigureGeneralSettings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Linearization
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// The test case TC_ConfigureGeneralSettings.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_ConfigureGeneralSettings
// ReSharper restore InconsistentNaming
    {
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Opens the tab Settings and configures the General Settings parameter. Use string.empty if you want to skip a parameter.
        /// </summary>
        /// <param name="linearizationType">The linearization type.</param>
        /// <param name="emptyCalibration">The empty calibration.</param>
        /// <param name="fullCalibration">The full calibration.</param>
        /// <param name="distanceUnit">The distance unit.</param>
        /// <param name="levelUnit">The level unit.</param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("8840bf65-5a42-44a3-a3e2-82a80491a57c", TestDefinition.Predefined, TestScript.TestCase)]        
        public static bool Run(string linearizationType, string emptyCalibration, string fullCalibration, string distanceUnit, string levelUnit)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = DeviceFunctionLoader.CoDIA.Linearization.Flows.ConfigureGeneralSettings.Run(linearizationType, emptyCalibration, fullCalibration, distanceUnit, levelUnit);           
            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureGeneralSettings passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureGeneralSettings failed.");
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