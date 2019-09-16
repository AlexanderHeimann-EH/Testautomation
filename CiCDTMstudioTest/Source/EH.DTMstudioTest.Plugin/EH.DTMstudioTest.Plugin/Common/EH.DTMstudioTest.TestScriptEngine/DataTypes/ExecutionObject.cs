// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutionObject.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The execution object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.TestScriptEngine.DataTypes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument;
    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.DTMstudioTest.Common.Utilities.Logging;

    using Ranorex.Core.Testing;

    using TestCase = EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects.TestCase;

    /// <summary>
    /// The execution object.
    /// </summary>
    public class ExecutionObject
    {
        #region Fields

        /// <summary>
        /// The file extension.
        /// </summary>
        private string fileExtension;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionObject"/> class.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="dtmStudioTestData">
        /// The dtm studio test data.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public ExecutionObject(string fileName, DTMstudioTestData dtmStudioTestData)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.TestConfiguration = new TestConfiguration();
            this.TestConfiguration = this.TestConfiguration.GetTestConfiguration(fileName);
            
            this.ExecutionData = new ExecutionData();
            this.TestReportInfos = new List<TestReportInfo>();
            this.DtmStudioTestData = dtmStudioTestData;
            this.CurrentTestCaseInfo = new TestCaseInfo();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionObject"/> class.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        public ExecutionObject(ExecutionObject executionObject)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.ExecutionData = executionObject.ExecutionData;
            this.TestConfiguration = executionObject.TestConfiguration;

            this.DtmStudioTestData = executionObject.DtmStudioTestData;

            this.ReportFolderOverview = executionObject.ReportFolderOverview;
            this.ReportFolderTestCases = executionObject.ReportFolderTestCases;
            this.ReportNameOverview = executionObject.ReportNameOverview;
            this.ReportPathAndFileOverview = executionObject.ReportPathAndFileOverview;
            this.ReportPathAndFileOverviewTemp = executionObject.ReportPathAndFileOverviewTemp;

            this.CurrentTestReportInfo = executionObject.CurrentTestReportInfo;
            this.CurrentTestCase = executionObject.CurrentTestCase;
            this.CurrentTestObject = executionObject.CurrentTestObject;
            this.LatestSummaryResult = executionObject.LatestSummaryResult;
            this.TestReportInfos = executionObject.TestReportInfos;
            this.TestCaseName = executionObject.TestCaseName;
            this.TestConfiguration = executionObject.TestConfiguration;
            this.CurrentTestCaseInfo = new TestCaseInfo();
        }

        #endregion

        #region Public Properties

        /* ------------------- */
        /* File System Related */
        /* ------------------- */
        
        /// <summary>
        /// Gets or sets the report folder for overview.
        /// </summary>
        public string ReportFolderOverview { get; set; }

        /// <summary>
        /// Gets or sets the report folder for test cases.
        /// </summary>
        public string ReportFolderTestCases { get; set; }

        /* ---------------- */
        /* Xml File Related */
        /* ---------------- */

        /// <summary>
        /// Gets or sets the report name overview.
        /// </summary>
        public string ReportNameOverview { get; set; }

        /// <summary>
        /// Gets or sets the report path and file overview.
        /// </summary>
        public string ReportPathAndFileOverview { get; set; }

        /// <summary>
        /// Gets or sets the report path and file overview temp.
        /// </summary>
        public string ReportPathAndFileOverviewTemp { get; set; }

        /// <summary>
        /// Gets or sets the current test case.
        /// </summary>
        public TestCase CurrentTestCase { get; set; }

        /// <summary>
        /// Gets or sets the current test report.
        /// </summary>
        public TestReportInfo CurrentTestReportInfo { get; set; }

        /// <summary>
        /// Gets or sets the current test object.
        /// </summary>
        public TestObject CurrentTestObject { get; set; }

        /// <summary>
        /// Gets or sets the dt mstudio test data.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public DTMstudioTestData DtmStudioTestData { get; set; }

        /// <summary>
        /// Gets or sets the execution data.
        /// </summary>
        public ExecutionData ExecutionData { get; set; }

        /// <summary>
        /// Gets or sets the file extension.
        /// </summary>
        public string FileExtension
        {
            get
            {
                if (string.IsNullOrEmpty(this.fileExtension))
                {
                    return ".rxlog";
                }

                return this.fileExtension;
            }

            set
            {
                this.fileExtension = value;
            }
        }

        /// <summary>
        /// Gets or sets the latest state.
        /// </summary>
        public TestResult LatestSummaryResult { get; set; }

        /// <summary>
        /// Gets or sets the test report information.
        /// </summary>
        public List<TestReportInfo> TestReportInfos { get; set; }

        /// <summary>
        /// Gets or sets the test case name.
        /// </summary>
        public string TestCaseName { get; set; }

        /// <summary>
        /// Gets or sets the test configuration.
        /// </summary>
        public TestConfiguration TestConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the current test case info.
        /// </summary>
        public TestCaseInfo CurrentTestCaseInfo { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        public TimeSpan Duration { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// The get latest path element.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetLatestPathElement(string path)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            string[] parts = path.Split(Convert.ToChar(@"\"));
            return parts[parts.Length - 1];
        }

        #endregion
    }
}