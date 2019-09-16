// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TS_ResetDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The test suite TS_ResetDevice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.Testlibrary.TestSuites.DeviceFunction.CoDIA.Parameterization
{
    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    /// The test suite TS_ResetDevice.
    /// </summary>
    public class TS_ResetDevice
    {
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        // Changes are allowed at TestCategory and TestFocus, at your own risk
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        ///// <summary>
        ///// Gets the test case guids.
        ///// </summary>
        //[TestScriptInformation("a4741a01-64c7-4bda-8ca5-12655163c53d", TestDefinition.Predefined, TestScript.TestSuite, TestCategory.NotDefined, TestFocus.NotDefined)]
        //[TestSuideGuids(new[] { "271ca70d-5643-4f15-81a4-2b4f331773bb" })]
        //public static void GetTestCaseGuids()
        //{
        //}

        /// <summary>
        /// The run.
        /// </summary>
        public static void Run()
        {
            // Add your code here
            TestCases.DeviceFunction.CoDIA.Parameterization.TC_ResetDevice.Run("pathToResetParameter", "value", 60000, 120000);
        }

        #endregion
    }
}