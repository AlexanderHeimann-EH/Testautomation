// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestReportHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test report handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.TestScriptEngine.Reporting
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.DTMstudioTest.TestScriptEngine.DataTypes;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Reporting;
    using Ranorex.Core.Testing;

    using DateTime = System.DateTime;
    using Log = EH.DTMstudioTest.Common.Utilities.Logging.Log;

    /// <summary>
    /// The test report handler.
    /// </summary>
    public class TestReportHandler
    {
        #region Public Methods and Operators

        /// <summary>
        /// The create reporting.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        public static void CreateReporting(ExecutionObject executionObject)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);

            if (executionObject.TestReportInfos != null)
            {
                foreach (TestReportInfo testReportInfo in executionObject.TestReportInfos)
                {
                    if (testReportInfo.TestSuiteName.Equals(string.Empty))
                    {
                        foreach (TestCaseInfo testCaseInfo in testReportInfo.TestCaseInfos)
                        {
                                string relativePathToTestCase = FileNameHandler.RelativePathToTestCase(executionObject.ReportFolderOverview, testCaseInfo.TestCasePathAndName);
                                Report.LogHtml(testCaseInfo.GetReportLevel(), testCaseInfo.TestCaseResult.ToString(), @"<a href='" + relativePathToTestCase + "'>" + GetTestCaseNameWithoutTimeStamp(testCaseInfo.TestCaseName) + "</a>");    
                        }
                    }
                    else
                    {
                        Report.Info("Begin of Testsuite: ", testReportInfo.TestSuiteName);
                        foreach (TestCaseInfo testCaseInfo in testReportInfo.TestCaseInfos)
                        {
                            string relativePathToTestCase = FileNameHandler.RelativePathToTestCase(executionObject.ReportFolderOverview, testCaseInfo.TestCasePathAndName);
                            Report.LogHtml(testCaseInfo.GetReportLevel(), testCaseInfo.TestCaseResult.ToString(), @"<a href='" + relativePathToTestCase + "'>" + GetTestCaseNameWithoutTimeStamp(testCaseInfo.TestCaseName) + "</a>");
                        }

                        Report.Info("End of Testsuite: ", testReportInfo.TestSuiteName);
                    }
                }
            }
        }

        /// <summary>
        /// The finish execution.
        /// </summary>
        /// <param name="testResult">
        /// The test Result.
        /// </param>
        public static void FinishReporting(TestResult testResult)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);

            // Finish testcase logfile
            TestReport.EndTestModule();
            TestReport.SetCurrentTestResult(testResult);
            TestReport.EndTestCase();
            TestReport.SetCurrentTestResult(testResult);
            TestReport.EndTestCaseSetup();
            TestReport.SetCurrentTestResult(testResult);
            TestReport.SaveReport();
            TestReport.Clear();
        }

        /// <summary>
        /// The get test case info error count.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int GetTestCaseInfoErrorCount(ExecutionObject executionObject)
        {
            int result = 0;

            foreach (TestReportInfo testSuiteInfo in executionObject.TestReportInfos)
            {
                foreach (TestCaseInfo testCaseInfo in testSuiteInfo.TestCaseInfos)
                {
                    if (testCaseInfo.TestCaseResult == TestResult.Failed)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// The get test case info success count.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int GetTestCaseInfoSuccessCount(ExecutionObject executionObject)
        {
            int result = 0;

            foreach (TestReportInfo testSuiteInfo in executionObject.TestReportInfos)
            {
                foreach (TestCaseInfo testCaseInfo in testSuiteInfo.TestCaseInfos)
                {
                    if (testCaseInfo.TestCaseResult == TestResult.Passed)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// The initialize execution object.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool InitializeExecutionObject(ExecutionObject executionObject)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);

            string currentDateAndTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            
            // Prüfung 1: läuft das Projekt im usprünglichen Verzeichnis.
            // => Dann werden die Projektspezifischen Daten verwendet.
            // => Unter dem Ordner Report\Output\ werden alle Verzeichnisse und Dateien abgelegt
            // Alternative: 
            // => Aktuelles Ausführungsverzeichnis wird ermittelt
            // => Unter dem Ordner Report\Output\ werden alle Verzeichnisse und Dateien abgelegt

            // DONE
            // Prüfung 2: ist der Pfad für die Ausgabe absolut?
            // => Dann geschieht die komplette Ausgabe in diesem Verzeichnis.
            // => Verzeichnisse müssen vorbereitend angepasst werden.
            // Alternative:
            // => Unter dem Ordner Report\Output\ werden alle Verzeichnisse und Dateien abgelegt

            // DONE
            // Prüfung 3: hat der Pfad eine gültige Länge und lässt er noch x Zeichen übrig?
            // => Es geht normal weiter
            // Alternative:
            // Die Programausführung wird mit einem Hinweis auf die Pfadlänge abgebrochen.
            ReportHelper.ReportPath = executionObject.DtmStudioTestData.DeviceTypeTestProject.ReportOutputPath;

            if (!ReportHelper.ReportPath.Contains(":"))
            {
                if (executionObject.DtmStudioTestData.DeviceTypeTestProject.ExecutionPath != null)
                {
                    // Normierung des ReportOutputPath => Entfernen von führenden und nachfolgenden "\"
                    executionObject.DtmStudioTestData.DeviceTypeTestProject.ReportOutputPath = RemoveFromFirstAndLastPosition(executionObject.DtmStudioTestData.DeviceTypeTestProject.ReportOutputPath, @"\");

                    executionObject.ReportFolderOverview = executionObject.DtmStudioTestData.DeviceTypeTestProject.ExecutionPath + @"\" + executionObject.DtmStudioTestData.DeviceTypeTestProject.ReportOutputPath + @"\" + currentDateAndTime;
                    executionObject.ReportFolderTestCases = executionObject.ReportFolderOverview + @"\" + executionObject.DtmStudioTestData.DeviceTypeTestProject.Name;
                    executionObject.ReportNameOverview = currentDateAndTime + @"_" + executionObject.DtmStudioTestData.DeviceTypeTestProject.Name + executionObject.FileExtension;
                    executionObject.ReportPathAndFileOverview = executionObject.ReportFolderOverview + @"\" + executionObject.ReportNameOverview;
                    executionObject.ReportPathAndFileOverviewTemp = executionObject.ReportFolderOverview + @"\Temp\" + executionObject.ReportNameOverview;
                    ReportHelper.ReportPath = executionObject.ReportFolderOverview;

                    // Main Report folder consists of path to reports and current target sub folder 
                    if (Directory.Exists(executionObject.ReportFolderOverview) == false)
                    {
                        Directory.CreateDirectory(executionObject.ReportFolderOverview);
                    }
                }
            }
            else
            {
                executionObject.ReportFolderOverview = executionObject.DtmStudioTestData.DeviceTypeTestProject.ReportOutputPath + currentDateAndTime;
                executionObject.ReportFolderTestCases = executionObject.ReportFolderOverview + @"\" + executionObject.DtmStudioTestData.DeviceTypeTestProject.Name;
                executionObject.ReportNameOverview = currentDateAndTime + @"_" + executionObject.DtmStudioTestData.DeviceTypeTestProject.Name + executionObject.FileExtension;
                executionObject.ReportPathAndFileOverview = executionObject.ReportFolderOverview + @"\" + executionObject.ReportNameOverview;
                executionObject.ReportPathAndFileOverviewTemp = executionObject.ReportFolderOverview + @"\Temp\" + executionObject.ReportNameOverview;
            }

            // Check for reportFileName length
            if (executionObject.ReportPathAndFileOverview.Length > ConstLenghts.MaxPathLengthByOperatingSystem)
            {
                string caption = "Error: Project path is too long.";
                string message = "Problem:\t Project path is to long. ReportFileName [" + executionObject.ReportPathAndFileOverview + "] has more than " + ConstLenghts.MaxPathLengthByOperatingSystem + " charakters (" + executionObject.ReportPathAndFileOverview.Length + "). \n\nSolution: \tPlease copy ControlDocument from this project into a new project with a shorter project path.\n\nTest will be aborted!";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(message);
                Console.ResetColor();
                System.Windows.Forms.MessageBox.Show(message, caption);

                return false;
            }

            return true;
        }

        /// <summary>
        /// The prepare reporting.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        /// <param name="testSuite">
        /// The test suite.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool PrepareReporting(ExecutionObject executionObject, string testSuite)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);
            
            if (!Directory.Exists(executionObject.ReportFolderOverview + @"\Temp"))
            {
                Directory.CreateDirectory(executionObject.ReportFolderOverview + @"\Temp");
            }

            TestReport.Setup(ReportLevel.Debug, executionObject.ReportPathAndFileOverviewTemp, true);
            TestReport.BeginTestSuite(testSuite, executionObject.DtmStudioTestData.DeviceTypeProject.FDTDeviceTypeName);
            TestReport.BeginTestCase(testSuite, string.Empty);
            TestReport.BeginTestModule("Details");

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get test case name without time stamp.
        /// </summary>
        /// <param name="testCaseName">
        /// The test case name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetTestCaseNameWithoutTimeStamp(string testCaseName)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);
            return testCaseName.Remove(0, 16);
        }

        /// <summary>
        /// The remove character from first and last position.
        /// </summary>
        /// <param name="containerString">
        /// The container string.
        /// </param>
        /// <param name="stringToBeDeleted">
        /// The string to be deleted.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string RemoveFromFirstAndLastPosition(string containerString, string stringToBeDeleted)
        {
            containerString = RemoveFromFirstPosition(containerString, stringToBeDeleted);
            containerString = RemoveFromLastPosition(containerString, stringToBeDeleted);
            return containerString;
        }

        /// <summary>
        /// The remove from first position.
        /// </summary>
        /// <param name="containerString">
        /// The container string.
        /// </param>
        /// <param name="stringToBeDeleted">
        /// The string to be deleted.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string RemoveFromFirstPosition(string containerString, string stringToBeDeleted)
        {
            if (string.IsNullOrEmpty(containerString))
            {
                return containerString;
            }
            
            if (containerString.StartsWith(stringToBeDeleted))
            {
                containerString = containerString.Substring(1);
            }    
            
            return containerString;
        }

        /// <summary>
        /// The remove from last position.
        /// </summary>
        /// <param name="containerString">
        /// The container string.
        /// </param>
        /// <param name="stringToBeDeleted">
        /// The string to be deleted.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string RemoveFromLastPosition(string containerString, string stringToBeDeleted)
        {
            if (string.IsNullOrEmpty(containerString))
            {
                return containerString;
            }

            if (containerString.EndsWith(stringToBeDeleted))
            {
                containerString = containerString.Substring(0, containerString.Length - 1);
            }

            return containerString;
        }

        #endregion
    }
}