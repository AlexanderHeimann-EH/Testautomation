// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CheckMaximumNumberOfEvents.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CheckMaximumNumberOfEvents.
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
    /// The test case TC_CheckMaximumNumberOfEvents.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CheckMaximumNumberOfEvents
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Checks whether the number of events is less than or equal to a number provided by the user.
        /// </summary>
        /// <param name="expectedMaximumNumberOfEvents">
        /// The expected maximum number of events.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("4fd89c5b-cbf6-4848-931a-fc3fc6ca08aa", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(int expectedMaximumNumberOfEvents)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.RunSelectTab.Run(0);
            isPassed &= AssertFunctions.LessOrEqual(expectedMaximumNumberOfEvents, Execution.Table.GetNumberOfEvents(), "Checking whether the number of events is less than or equal to: " + expectedMaximumNumberOfEvents);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckMaximumNumberOfEvents passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckMaximumNumberOfEvents failed.");
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