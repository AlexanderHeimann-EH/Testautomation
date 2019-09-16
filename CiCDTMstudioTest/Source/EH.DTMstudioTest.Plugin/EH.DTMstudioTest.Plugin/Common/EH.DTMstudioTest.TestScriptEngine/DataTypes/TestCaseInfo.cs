// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCaseInfo.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of TestCaseInfo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.TestScriptEngine.DataTypes
{
    using System.Reflection;

    using EH.DTMstudioTest.Common.Utilities.Logging;

    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Description of TestCaseInfo.
    /// </summary>
    public class TestCaseInfo
    {
        #region Constants

        /// <summary>
        /// The file extension.
        /// </summary>
        private const string FileExtension = ".rxlog";

        #endregion

        #region Fields

        /// <summary>
        /// The test case result.
        /// </summary>
        private TestResult testCaseResult;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseInfo"/> class.
        /// </summary>
        public TestCaseInfo()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            this.TestCaseName = string.Empty;
            this.TestCasePath = string.Empty;
            this.testCaseResult = TestResult.Failed;
            this.ErrorMessage = string.Empty;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the test case file name.
        /// </summary>
        public string TestCaseFileName
        {
            get
            {
                return this.TestCaseName + FileExtension;
            }
        }

        /// <summary>
        /// Gets or sets the test case name.
        /// </summary>
        public string TestCaseName { get; set; }

        /// <summary>
        /// Gets or sets the test case path.
        /// </summary>
        public string TestCasePath { get; set; }

        /// <summary>
        /// Gets the test case path and name.
        /// </summary>
        public string TestCasePathAndName
        {
            get
            {
                return this.TestCasePath + @"\" + this.TestCaseName + FileExtension;
            }
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the test case result.
        /// </summary>
        public TestResult TestCaseResult
        {
            get
            {
                Log.Info(this, "GetTestCaseResult");
                return this.testCaseResult;
            }

            set
            {
                Log.Info(this, "SetTestCaseResult");
                this.testCaseResult = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get report level.
        /// </summary>
        /// <returns>
        /// The <see cref="ReportLevel"/>.
        /// </returns>
        public ReportLevel GetReportLevel()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            switch (this.testCaseResult)
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

        #endregion
    }
}