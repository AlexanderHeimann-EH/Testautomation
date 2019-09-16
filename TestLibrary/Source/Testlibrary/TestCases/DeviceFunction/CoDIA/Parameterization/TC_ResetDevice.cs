// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ResetDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ResetDevice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Parameterization
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization;

    /// <summary>
    /// The test case TC_ResetDevice.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_ResetDevice
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Reset a device via Online Parameterization.
        /// </summary>
        /// <param name="pathToResetParameter">
        /// The path to the reset parameter. Use this form: Promass 100//Expert//System//Administration//Device reset:
        /// </param>
        /// <param name="value">
        /// Value for the reset. Use this form: To delivery settings
        /// </param>
        /// <param name="waitingTimeForDisconnect">
        /// The waiting period (in milliseconds) until the dtm has to be disconnected after a device restart. This can take some time with slower communication protocols. USE 0 IF THE DEVICE WILL NOT RESTART.
        /// </param>
        /// <param name="waitingTimeForReconnect">
        /// The waiting period (in milliseconds) until the dtm has to be reconnected after a device restart. This can take some time with slower communication protocols.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("271ca70d-5643-4f15-81a4-2b4f331773bb", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToResetParameter, string value, int waitingTimeForDisconnect, int waitingTimeForReconnect)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.ResetDevice.Run(pathToResetParameter, value, waitingTimeForDisconnect, waitingTimeForReconnect);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ResetDevice passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ResetDevice failed.");
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