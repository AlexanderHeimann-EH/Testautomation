// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Runner.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The runner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.TestScriptEngine
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    using EH.DTMstudioTest.Common.Manager;
    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.DTMstudioTest.TestScriptEngine.DataTypes;
    using EH.DTMstudioTest.TestScriptEngine.Execution;
    using EH.DTMstudioTest.TestScriptEngine.Reporting;

    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Loads an control document and uses it´s information to run all listed test scripts
    /// </summary>
    public class Runner
    {
        #region Static Fields

        /// <summary>
        /// The data manager.
        /// </summary>
        private static EhDataManager dataManager;

        #endregion

        #region Fields

        /// <summary>
        /// The execution object.
        /// </summary> 
        private ExecutionObject executionObject;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Runner"/> class.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        public Runner(string fileName)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            dataManager = new EhDataManager();
            this.executionObject = new ExecutionObject(fileName, dataManager.DTMstudioTestData);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Starts the execution of the current test script
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int StartExecution()
        {
            int result; 
            var duration = new Stopwatch();
            duration.Start();

            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            dataManager.LoadDataForExecution(Environment.CurrentDirectory);

            dataManager.DTMstudioTestData.ReportData.FirmwareInformation.Clone(InfrastructureHandler.GetFimwareInformation(dataManager.DTMstudioTestData.DeviceTypeTestProject.FirmwareInformationAssembly));

            // Configurationsdaten speichern
            dataManager.SaveDeviceTypeProjectData();

            var initialization = false;

            try
            {
                this.executionObject.DtmStudioTestData = dataManager.DTMstudioTestData;
                initialization = TestReportHandler.InitializeExecutionObject(this.executionObject);
                if (initialization)
                {
                    this.executionObject = (new ControlDocumentHandler()).Execute(this.executionObject);
                }
            }
            catch (ImageNotFoundException e)
            {
                Log.Error(this, e.Message);
                this.executionObject.LatestSummaryResult = TestResult.Failed;
                result = -1;
                return result;
            }
            catch (RanorexException e)
            {
                Log.Error(this, e.Message);
                this.executionObject.LatestSummaryResult = TestResult.Failed;
                result = -1;
                return result;
            }
            catch (ThreadAbortException e)
            {
                Log.Error(this, e.Message);
                this.executionObject.LatestSummaryResult = TestResult.Failed;
                Thread.ResetAbort();
                result = -1;
                return result;
            }
            catch (PathTooLongException e)
            {
                Log.Error(this, e.Message);
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.executionObject.LatestSummaryResult = TestResult.Failed;
                result = -1;
                return result;
            }
            catch (Exception e)
            {
                Log.Error(this, e.Message);
                this.executionObject.LatestSummaryResult = TestResult.Failed;
                result = -1;
                return result;
            }

            duration.Stop();
            this.executionObject.Duration = duration.Elapsed;

            if (initialization)
            {
                // Get Result Data For Report Data
                dataManager.DTMstudioTestData.ReportData.TotalFailedCount = TestReportHandler.GetTestCaseInfoErrorCount(this.executionObject);
                dataManager.DTMstudioTestData.ReportData.TotalSuccessCount = TestReportHandler.GetTestCaseInfoSuccessCount(this.executionObject);

                // Write Result Into Report Data
                if (dataManager.DTMstudioTestData.ReportData.TotalFailedCount > 0)
                {
                    this.executionObject.LatestSummaryResult = TestResult.Failed;
                    dataManager.DTMstudioTestData.ReportData.ResultOfTest = TestResult.Failed.ToString();
                }

                if (TestReportHandler.PrepareReporting(this.executionObject, dataManager.DTMstudioTestData.DeviceTypeProject.FDTDeviceTypeName))
                {
                    TestReportHandler.CreateReporting(this.executionObject);
                    TestReportHandler.FinishReporting(this.executionObject.LatestSummaryResult);

                    if (File.Exists(this.executionObject.ReportPathAndFileOverviewTemp))
                    {
                        InfrastructureHandler.InsertReportData(this.executionObject.ReportPathAndFileOverviewTemp, dataManager.DTMstudioTestData);
                        InfrastructureHandler.InsertDuration(this.executionObject.ReportPathAndFileOverviewTemp, this.executionObject.Duration);
                        InfrastructureHandler.ReplaceReportStyleSheet(this.executionObject.ReportPathAndFileOverviewTemp, "EHReportOverview");
                        InfrastructureHandler.CopyCustomizedReportDefaultStyle(Path.Combine(this.executionObject.DtmStudioTestData.DeviceTypeTestProject.ExecutionPath, "Report"), this.executionObject.ReportFolderOverview + @"\Temp", "EHReportOverview");
                        InfrastructureHandler.DeleteRanorexStyle(this.executionObject.ReportFolderOverview + @"\Temp");
                        InfrastructureHandler.ManipulateOverviewReportLayout(this.executionObject);
                        InfrastructureHandler.InsertHTMLCodeToReport(Path.Combine(this.executionObject.ReportPathAndFileOverviewTemp, "EHReportOverview.xsl"), dataManager.DTMstudioTestData.DeviceTypeProject.DeviceFunctions, dataManager.DTMstudioTestData.ReportData.FirmwareInformation.AdditionalInformation);
                    }

                    InfrastructureHandler.CopyReportAndDeleteTempFolder(this.executionObject.ReportFolderOverview + @"\Temp");
                    InfrastructureHandler.ExportTestResult(this.executionObject.ReportFolderOverview, this.executionObject.ReportPathAndFileOverview, dataManager.DTMstudioTestData);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Error: Test project path [" + this.executionObject.ReportPathAndFileOverview + "] is too long, [" + this.executionObject.ReportPathAndFileOverview.Length + "] characters.");
                }

                this.OpenExplorer(this.executionObject.ReportFolderOverview);

                // return test result as integer
                if (this.executionObject.LatestSummaryResult.Equals(TestResult.Passed))
                {
                    result = 0;
                }
                else
                {
                    result = -1;
                }

                return result;
            }

            return -1;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The open explorer.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        private void OpenExplorer(string path)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            if (Directory.Exists(path))
            {
                Process.Start("explorer.exe", path);
            }
        }

        #endregion
    }
}