// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ChangeParameterWithoutConfirmingAndCheckValue.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ChangeParameterWithoutConfirmingAndCheckValue.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Parameterization
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_ChangeParameterWithoutConfirmingAndCheckValue.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_ChangeParameterWithoutConfirmingAndCheckValue
// ReSharper restore InconsistentNaming
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Changes the value of a parameter, but does not confirm the change. Verifies that the value has not changed afterwards
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to the parameter. Use this form: Micropilot 5x//Setup//Full calibration (4):
        /// </param>
        /// <param name="value">
        /// The value which will be changed
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here."), TestScriptInformation("605BFCE5-7CEF-4A65-A817-AB75F662CCDB", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToParameter, string value)
        {
            StartUp();

            string checkValue = Execution.GetParameterValue.Run(pathToParameter);
            bool isPassed = Execution.SetParameter.Run(pathToParameter, value, false);
            isPassed &= Execution.CheckParameterValue.Run(pathToParameter, checkValue);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ChangeParameterWithoutConfirmingAndCheckValue passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ChangeParameterWithoutConfirmingAndCheckValue failed.");
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