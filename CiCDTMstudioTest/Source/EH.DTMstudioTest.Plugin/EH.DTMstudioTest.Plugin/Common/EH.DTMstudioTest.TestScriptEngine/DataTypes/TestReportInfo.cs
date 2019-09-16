// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestReportInfo.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.TestScriptEngine.DataTypes
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.DTMstudioTest.Common.Utilities.Logging;

    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// The test report info.
    /// </summary>
    public class TestReportInfo
    {
        #region Fields

        /// <summary>
        /// The test case result.
        /// </summary>
        private TestResult testSuiteResult;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestReportInfo"/> class. 
        /// </summary>
        /// <param name="testSuiteName">
        /// The test suite name.
        /// </param>
        public TestReportInfo(string testSuiteName)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            this.TestSuiteName = testSuiteName;
            this.testSuiteResult = TestResult.Failed;
            this.TestCaseInfos = new List<TestCaseInfo>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the test case name.
        /// </summary>
        public string TestSuiteName { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the test case information.
        /// </summary>
        public List<TestCaseInfo> TestCaseInfos { get; set; }

        /// <summary>
        /// The get report level.
        /// </summary>
        /// <returns>
        /// The <see cref="ReportLevel"/>.
        /// </returns>
        public ReportLevel GetReportLevel()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            switch (this.testSuiteResult)
            {
                case TestResult.Failed:
                    {
                        Log.Info(this, "GetReportLevel: Failed");
                        return ReportLevel.Failure;
                    }

                case TestResult.Passed:
                    {
                        Log.Info(this, "GetReportLevel: Passed");
                        return ReportLevel.Success;
                    }

                case TestResult.Skipped:
                    {
                        Log.Info(this, "GetReportLevel: Skipped");
                        return ReportLevel.Warn;
                    }

                default:
                    {
                        Log.Error(this, "GetReportLevel: unknown category");
                        Report.Error("Unknown category", string.Empty);
                        return ReportLevel.Failure;
                    }
            }
        }
    }
}
