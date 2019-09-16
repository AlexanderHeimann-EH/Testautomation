// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CheckThatParameterAreEqual.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_CheckThatParameterAreEqual.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Compare
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Compare;

    /// <summary>
    /// The test case TC_CheckThatParameterAreEqual.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_CheckThatParameterAreEqual
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Checks whether the offline and online parameter are identical.
        /// </summary>
        /// <param name="parameterNames">
        /// String with all the names of the parameter which will be checked. E.g. Full calibration (4);Empty calibration (3);Device tag;
        /// Separate the parameter names with ; .
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("322494f6-a021-4412-a9b4-dfe347cae9ae", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string parameterNames)
        {
            return Run(StringToListConverter.Run(parameterNames));
        }

        /// <summary>
        /// Checks whether the offline and online parameter are identical.
        /// </summary>
        /// <param name="parameterNames">
        /// List with the name(s) of the parameter which will be checked. E.g. Full calibration (4), Empty calibration (3), Device tag.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        public static bool Run(List<string> parameterNames)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.CheckCompareResult.CheckThatOfflineAndOnlineParameterAreEqual(parameterNames);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckThatParameterAreEqual passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CheckThatParameterAreEqual failed.");
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