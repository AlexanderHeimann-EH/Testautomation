// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCaseReportHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test report handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.TestScriptEngine.Reporting
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Reflection;

    using EH.DTMstudioTest.TestScriptEngine.DataTypes;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Reporting;
    using Ranorex.Core.Testing;

    using DateTime = System.DateTime;
    using Log = EH.DTMstudioTest.Common.Utilities.Logging.Log;

    /// <summary>
    /// The test report handler.
    /// </summary>
    public class TestCaseReportHandler
    {
        /// <summary>
        /// The date time length.
        /// </summary>
        private const int DateTimeLength = 16;

        #region Static Fields

        /// <summary>
        /// The current test case.
        /// </summary>
        private static string currentTestCase;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The finish reporting.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        /// <param name="testCaseInfo">
        /// The test Case Info.
        /// </param>
        public static void FinishReporting(ref ExecutionObject executionObject, ref TestCaseInfo testCaseInfo)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);
            
            try
            {
                testCaseInfo.TestCaseName = currentTestCase; // executionObject.TestCaseName;
                testCaseInfo.TestCasePath = executionObject.ReportFolderTestCases;
                testCaseInfo.TestCaseResult = (TestResult)TestReport.CurrentTestModuleActivity.Status;
                executionObject.CurrentTestReportInfo.TestCaseInfos.Add(testCaseInfo);

                // Finish testcase logfile
                TestReport.EndTestModule();
                TestReport.SetCurrentTestResult(testCaseInfo.TestCaseResult);
                TestReport.EndTestCase();
                TestReport.SetCurrentTestResult(testCaseInfo.TestCaseResult);
                TestReport.EndTestCaseSetup();
                TestReport.SetCurrentTestResult(testCaseInfo.TestCaseResult);
                TestReport.SaveReport();
                TestReport.Clear();
            }
            catch (Exception exception)
            {
                Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        /// <summary>
        /// The prepare reporting.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string PrepareReporting(ref ExecutionObject executionObject)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);
            if (!Directory.Exists(executionObject.ReportFolderTestCases))
            {
                Directory.CreateDirectory(executionObject.ReportFolderTestCases);
            }

            var currentDateAndTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            
            // currentTestCase contains the current testcase namen + date-time-stamp
            currentTestCase = currentDateAndTime + "_" + executionObject.TestCaseName;

            // filename contains the whole path
            // it´s number of characters must be less then 255-5 (5 from .data by creating the file)
            var fileName = executionObject.ReportFolderTestCases + @"\" + currentTestCase;
            var testCasePathAndFile = fileName + executionObject.FileExtension; // originFileName;

            // check path length of all parts 
            // Check path length for creating ranorex report
            // if ranorexReportLength > 92
            //   shorten name of ranorex report
            //   log info about shortening ranorexReport
            // if completePathLength > 250
            //   shorten name of ranorex report
            //   log info about shortening ranorexReport
            // if shortenig is not enought
            //   log info about ranorexReport which wont be available due path length issues
            try
            {
                string testSuiteName = executionObject.CurrentTestReportInfo.TestSuiteName;

                // Check currentTestCase length if filename is too long for ranorex setup function.
                // If filename is too long, cut of characters for valid number of characters.
                int currentTestCaseLength = currentTestCase.Length;
                if (currentTestCaseLength > ConstLenghts.MaxFileLengthByRanorex)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("TestCaseName [" + currentTestCase + "] has more than " + ConstLenghts.MaxFileLengthByRanorex + " (" + currentTestCaseLength.ToString(CultureInfo.InvariantCulture) + ") characters and has been reduced to a valid length.");
                    Console.ResetColor();

                    currentTestCase = currentTestCase.Remove(ConstLenghts.MaxFileLengthByRanorex, currentTestCaseLength - ConstLenghts.MaxFileLengthByRanorex);
                    testCasePathAndFile = executionObject.ReportFolderTestCases + @"\" + currentTestCase + executionObject.FileExtension;
                    currentTestCaseLength = currentTestCase.Length;
                }

                // Check reportFileName length if path is too long for file system.
                // If filename is too long and if it is possible to cut of characters from currentTestCase filename
                // cut of characters for valid number of characters.
                int reportFileNameLength = testCasePathAndFile.Length;
                
                if (reportFileNameLength > ConstLenghts.MaxPathLengthForTempararyPostfix)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("ReportFileName [" + testCasePathAndFile + "] has more than " + (ConstLenghts.MaxPathLengthByOperatingSystem - 1) + " (" + testCasePathAndFile.Length + ") characters.");
                    Console.ResetColor();

                    int availableCharacters = ConstLenghts.MaxPathLengthForTempararyPostfix - reportFileNameLength + currentTestCaseLength;

                    // Shorten currentTestCase name to the length of available characters
                    if (availableCharacters - DateTimeLength - executionObject.FileExtension.Length > 0)
                    {
                        currentTestCase = currentTestCase.Remove(availableCharacters, currentTestCaseLength - availableCharacters);
                        testCasePathAndFile = executionObject.ReportFolderTestCases + @"\" + currentTestCase + executionObject.FileExtension;
                        reportFileNameLength = testCasePathAndFile.Length;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("ReportFileName [" + testCasePathAndFile + "] could not be trimmed. There are less characters left for a filename with a length of one character + file extension.");
                        Console.ResetColor();
                    }
                }

                if (reportFileNameLength > ConstLenghts.MaxPathLengthForTempararyPostfix)
                {
                    // Create Report Object
                    executionObject.CurrentTestCaseInfo.TestCaseName = currentTestCase + ": The TestCaseReport [" + currentTestCase + "] is not available due to exceeded path length = " + testCasePathAndFile.Length.ToString(CultureInfo.InvariantCulture) + ".";
                    executionObject.CurrentTestCaseInfo.TestCasePath = string.Empty;
                    executionObject.CurrentTestCaseInfo.TestCaseResult = TestResult.Failed;
                    executionObject.CurrentTestReportInfo.TestCaseInfos.Add(executionObject.CurrentTestCaseInfo);
                }
                else
                {
                    TestReport.Setup(ReportLevel.Debug, testCasePathAndFile, true);
                    TestReport.BeginTestSuite(executionObject.CurrentTestCase.DisplayName, testSuiteName);
                    TestReport.BeginTestCase(executionObject.CurrentTestCase.DisplayName);
                    TestReport.BeginTestModule("Details");

                    string backToOverview = FileNameHandler.GetRelativePathToOverview(executionObject.ReportFolderOverview, executionObject.ReportFolderTestCases);
                    backToOverview = backToOverview + @"\" + executionObject.ReportNameOverview;

                    Report.LogHtml(ReportLevel.Debug, string.Empty, @"<a href='" + backToOverview + "'>" + @"Back to Overview" + "</a>");
                }
            }
            catch (Exception exception)
            {
                Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ": " + exception.Message);
                Console.ResetColor();
            }

            return testCasePathAndFile;
        }

        #endregion
    }
}