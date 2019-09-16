// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_WriteTable.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_WriteTable.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Linearization
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_WriteTable.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_WriteTable
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Write the Linearization Table, makes a screenshot of the diagram and table and checks that there is no critical error.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("5fc66483-14e1-48c9-885d-4263dd238e03", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(int timeoutInMilliseconds)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.Write.Run(timeoutInMilliseconds);
            Execution.TakeScreenshotOfModule.Run();
            isPassed &= AssertFunctions.AreEqual(string.Empty, CommonFlows.GetCriticalError.Run()[0], "Checking that there is no critical error.");

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_WriteTable passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_WriteTable failed.");
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