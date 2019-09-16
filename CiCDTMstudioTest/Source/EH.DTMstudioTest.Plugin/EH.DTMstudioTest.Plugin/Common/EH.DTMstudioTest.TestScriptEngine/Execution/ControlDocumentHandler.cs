// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlDocumentHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The control document handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.TestScriptEngine.Execution
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.TestScriptEngine.DataTypes;
    using EH.DTMstudioTest.TestScriptEngine.Reporting;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex.Core.Reporting;
    using Ranorex.Core.Testing;

    using Log = EH.DTMstudioTest.Common.Utilities.Logging.Log;
    using TestCase = EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects.TestCase;
    using TestSuite = EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects.TestSuite;

    /// <summary>
    /// The control document handler.
    /// </summary>
    public class ControlDocumentHandler
    {
        /// <summary>
        /// The report file name.
        /// </summary>
        private string reportFileName; 

        #region Public Methods and Operators

        /// <summary>
        /// The execute new.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        /// <returns>
        /// The <see cref="ExecutionObject"/>.
        /// </returns>
        public ExecutionObject Execute(ExecutionObject executionObject)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            if (executionObject != null)
            {
                // Create a copy from origin
                var currentExecutionObject = new ExecutionObject(executionObject);

                // Get all available testobjects from testconfiguration (= control document)
                TestObjectCollection testObjectCollection = currentExecutionObject.TestConfiguration.AvailableTestObjects;
                
                // More than one testObjectCollection is possible. In fact there´s only one. It´s the top layer in control document.
                foreach (var testObject in testObjectCollection)
                {
                    if (testObject is TestCollection)
                    {
                        // Add new TestReportInfos without related TestSuites
                        var testReportInfo = new TestReportInfo(string.Empty);
                        currentExecutionObject.TestReportInfos.Add(testReportInfo);
                        currentExecutionObject.CurrentTestReportInfo = testReportInfo;

                        // Recursvive call
                        currentExecutionObject.CurrentTestObject = testObject;
                        currentExecutionObject.ExecutionData.TestMethods = ((TestCollection)testObject).TestObjects;
                        currentExecutionObject = this.ReadByObject(currentExecutionObject);
                    }
                }

                return currentExecutionObject;
            }

            Log.Error(this, "ExecutionObject is Null before execution");
            PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ExecutionObject is Null before execution");
            Console.WriteLine("ExecutionObject is Null before execution");
            return null;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Recursive method to read by object.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        /// <returns>
        /// The <see cref="ExecutionObject"/>.
        /// </returns>
        private ExecutionObject ReadByObject(ExecutionObject executionObject)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            if (executionObject != null)
            {
                var currentExecutionObject = new ExecutionObject(executionObject);
                
                foreach (var testObject in currentExecutionObject.ExecutionData.TestMethods)
                {
                    if (testObject.GetType() == typeof(TestSuite))
                    {
                        // Add new TestReportInfos with related TestSuiteName
                        var testReportInfo = new TestReportInfo(testObject.DisplayName);
                        currentExecutionObject.TestReportInfos.Add(testReportInfo);
                        currentExecutionObject.CurrentTestReportInfo = testReportInfo;
                        
                        // Recursvive call
                        currentExecutionObject.CurrentTestObject = testObject;
                        currentExecutionObject.ExecutionData.TestMethods = ((TestCollection)testObject).TestObjects;
                        currentExecutionObject = this.ReadByObject(currentExecutionObject);
                    }
                    else if (testObject.GetType() == typeof(TestFolder) && testObject.Parent.GetType() == typeof(TestSuite))
                    {
                        // Recursvive call
                        currentExecutionObject.CurrentTestObject = testObject;
                        currentExecutionObject.ExecutionData.TestMethods = ((TestCollection)testObject).TestObjects;
                        currentExecutionObject = this.ReadByObject(currentExecutionObject);
                    }
                    else if (testObject.GetType() == typeof(TestFolder) && testObject.Parent.GetType() != typeof(TestSuite) && testObject.Parent != null)
                    {
                        string targetFolder = currentExecutionObject.ReportFolderTestCases;

                        if (!Directory.Exists(targetFolder))
                        {
                            Directory.CreateDirectory(targetFolder);
                        }

                        // Add new TestReportInfos without related TestSuites
                        var testReportInfo = new TestReportInfo(string.Empty);
                        currentExecutionObject.TestReportInfos.Add(testReportInfo);
                        currentExecutionObject.CurrentTestReportInfo = testReportInfo;
                        
                        // Recursvive call
                        currentExecutionObject.CurrentTestObject = testObject;
                        currentExecutionObject.ExecutionData.TestMethods = ((TestCollection)testObject).TestObjects;
                        currentExecutionObject = this.ReadByObject(currentExecutionObject);
                    }
                    else if (testObject.GetType() == typeof(TestCase))
                    {
                        this.reportFileName = string.Empty;
                        try
                        {
                            currentExecutionObject.TestCaseName = testObject.DisplayName;
                            currentExecutionObject.CurrentTestCase = (TestCase)testObject;

                            /* Manipulation der Ausgabe bevor der Bericht abgeschlossen ist, weil die Ausführung 
                               abgebrochen werden können soll, ohne dass dabei die neue Formatierung "vergessen" wird. 
                               Neue Styles ersetzen die Ranorex Styles */
                            this.reportFileName = TestCaseReportHandler.PrepareReporting(ref currentExecutionObject);
                            InfrastructureHandler.ManipulateDetailReportLayout(this.reportFileName);
                            InfrastructureHandler.ReplaceReportStyleSheet(this.reportFileName, "EHReportDetails");
                            string source = Path.Combine(currentExecutionObject.DtmStudioTestData.DeviceTypeTestProject.ExecutionPath, "Report");
                            string target = currentExecutionObject.ReportFolderTestCases;
                            const string FileName = "EHReportDetails";
                            InfrastructureHandler.CopyCustomizedReportDefaultStyle(source, target, FileName);
                            InfrastructureHandler.DeleteRanorexStyle(currentExecutionObject.ReportFolderTestCases);
                            InfrastructureHandler.InsertHTMLCodeToReport(Path.Combine(currentExecutionObject.ReportFolderTestCases, "EHReportDetails.xsl"), currentExecutionObject.DtmStudioTestData.DeviceTypeProject.DeviceFunctions, currentExecutionObject.DtmStudioTestData.ReportData.FirmwareInformation.AdditionalInformation);

                            // Ende des Kommentars
                            if (testObject.IsActive)
                            {
                                Log.Info(this, "Execute active Testobject -> TestCase");
                                TestObjectHandler.Execute(currentExecutionObject, testObject.Guid);
                            }
                            else
                            {
                                Log.Info(this, "Log inactive Testobject -> TestCase");
                                TestReport.SetCurrentTestResult(TestResult.Skipped);
                            }
                        }
                        catch (Exception exception)
                        {
                            Log.ErrorEx(this, exception, "A Critical Error Occured");
                            Console.WriteLine("A Critical Error Occured: " + exception.Message);
                            TestReport.SetCurrentTestResult(TestResult.Failed);
                        }
                        finally
                        {
                            var testCaseInfo = new TestCaseInfo();
                            TestCaseReportHandler.FinishReporting(ref currentExecutionObject, ref testCaseInfo);
                            currentExecutionObject.DtmStudioTestData.ReportData.ResultOfTest = testCaseInfo.TestCaseResult.ToString();

                            // Nachbearbeitung notwendig, da Ranorex mit jedem Schritt die Styledaten neu hineinkopiert
                            InfrastructureHandler.InsertReportData(testCaseInfo.TestCasePathAndName, currentExecutionObject.DtmStudioTestData);
                            InfrastructureHandler.ManipulateDetailReportLayout(this.reportFileName);
                            InfrastructureHandler.ReplaceReportStyleSheet(this.reportFileName, "EHReportDetails");
                            InfrastructureHandler.DeleteRanorexStyle(currentExecutionObject.ReportFolderTestCases);
                            InfrastructureHandler.InsertHTMLCodeToReport(Path.Combine(currentExecutionObject.ReportFolderTestCases, "EHReportDetails.xsl"), currentExecutionObject.DtmStudioTestData.DeviceTypeProject.DeviceFunctions, currentExecutionObject.DtmStudioTestData.ReportData.FirmwareInformation.AdditionalInformation);

                            // Ende des Kommentars

                            // Datenbank Aufruf 
                            InfrastructureHandler.ExportTestResult(testCaseInfo.TestCasePathAndName, currentExecutionObject.TestCaseName, currentExecutionObject.DtmStudioTestData);
                        }
                    }
                    else
                    {
                        Log.Info(this, "Unhandled Type: " + typeof(TestObject));
                        Console.WriteLine("Unhandled Type:" + typeof(TestObject));
                    }
                }

                return currentExecutionObject;
            }

            Log.Error(this, "ExecutionObject is Null before execution");
            Console.WriteLine("ExecutionObject is Null before execution");
            return null;
        }

        #endregion
    }
}