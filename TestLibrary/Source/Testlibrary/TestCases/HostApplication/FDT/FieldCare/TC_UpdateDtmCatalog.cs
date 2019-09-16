// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_UpdateDtmCatalog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_UpdateDtmCatalog.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare;

    /// <summary>
    /// The test case TC_UpdateDtmCatalog.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TC_UpdateDtmCatalog
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Opens the FieldCare Catalog via Menu, starts an update and adds new devices if necessary.
        /// </summary>
        /// <param name="timeToWaitForUpdateMessage">
        /// The time to wait for the update window to appear in milliseconds. Recommended: 5000.
        /// </param>
        /// <param name="timeoutForUpdateProgress">
        /// The timeout For the Update Progress. This depends on how many dtms are found. Recommended: 120000.
        /// </param>
        /// <param name="shouldFindNewOrChangedDevice">
        /// Set to true if new or changed devices are expected.
        /// </param>
        /// <param name="maxMinutesSinceDtmWasInstalled">
        /// The approximate time in minutes since the dtm has been installed
        /// </param>
        /// <param name="timeToWaitForMoving">
        /// The time To Wait For Moving. This is important if the update is huge.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("d84e0406-dd8a-4e5b-a83e-b43e66b2d7fe", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(int timeToWaitForUpdateMessage, int timeoutForUpdateProgress, bool shouldFindNewOrChangedDevice, int maxMinutesSinceDtmWasInstalled, int timeToWaitForMoving)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = SpecificFlows.UpdateDtmCatalog.Run(timeToWaitForUpdateMessage, timeoutForUpdateProgress, shouldFindNewOrChangedDevice, maxMinutesSinceDtmWasInstalled, timeToWaitForMoving);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_UpdateDtmCatalog passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_UpdateDtmCatalog failed.");
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