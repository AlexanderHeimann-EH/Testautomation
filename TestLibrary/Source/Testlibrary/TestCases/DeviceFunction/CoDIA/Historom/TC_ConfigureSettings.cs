// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConfigureSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The test case TC_ConfigureSettings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Historom
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Historom;

    /// <summary>
    /// The test case TC_ConfigureSettings.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_ConfigureSettings
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Configures the HistoRom settings found in the tab Settings.
        /// </summary>
        /// <param name="assignChannel1">
        /// Assignment for channel1. Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <param name="assignChannel2">
        /// Assignment for channel2.Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <param name="assignChannel3">
        /// Assignment for channel3.Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <param name="assignChannel4">
        /// Assignment for channel4.Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <param name="loggingInterval">
        /// The logging interval.Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <param name="clearLoggingData">
        /// Clear logging data.Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("374efc0b-bb8b-4c7f-b9ba-53ca99990b42", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string assignChannel1, string assignChannel2, string assignChannel3, string assignChannel4, string loggingInterval, string clearLoggingData)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.ConfigureSettingsTab.Run(assignChannel1, assignChannel2, assignChannel3, assignChannel4, loggingInterval, clearLoggingData);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureSettings passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureSettings failed.");
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