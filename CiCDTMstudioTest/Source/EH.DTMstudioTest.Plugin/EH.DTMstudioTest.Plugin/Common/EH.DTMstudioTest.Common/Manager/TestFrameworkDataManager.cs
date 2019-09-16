// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestFrameworkDataManager.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Defines the TestFrameworkDataManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.Manager
{
    using System;
    using System.Diagnostics;
    using System.IO;

    using EH.DTMstudioTest.Common.DeviceFunctionMapping;
    using EH.DTMstudioTest.Common.Tools;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.DTMstudioTest.Common.Utilities.Helper;

    /// <summary>
    /// The test framework data manager.
    /// </summary>
    public class TestFrameworkDataManager : IDisposable
    {
        #region Fields

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The test framework assembly path.
        /// </summary>
        private string testFrameworkAssemblyPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestFrameworkDataManager"/> class.
        /// </summary>
        /// <param name="dtmStudioTestData">
        /// The DTM Studio Test Data.
        /// </param>
        public TestFrameworkDataManager()
        {
            this.disposed = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the production record test data.
        /// </summary>
        // public DTMstudioTestData DTMstudioTestData { get; set; }
        /// <summary>
        /// Gets or sets the device function mapping list.
        /// </summary>
        public DeviceFunctionMappingList DeviceFunctionMappingList { get; set; }

        /// <summary>
        /// Gets the test framework assembly path.
        /// </summary>
        public string TestFrameworkAssemblyPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.testFrameworkAssemblyPath))
                {
                    this.testFrameworkAssemblyPath = ToolBox.GetTestFrameworkInstallPath();
                }

                return this.testFrameworkAssemblyPath;
            }
        }

        /// <summary>
        /// Gets or sets the test framework config file.
        /// </summary>
        public string TestFrameworkConfigFile { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The get dt mstudio test data.
        /// </summary>
        /// <param name="dtmStudioTestData">
        /// The dtm studio test data.
        /// </param>
        /// <returns>
        /// The <see cref="DTMstudioTestData"/>.
        /// </returns>
        public DTMstudioTestData GetDTMstudioTestData(DTMstudioTestData dtmStudioTestData)
        {
            dtmStudioTestData.TestLibrary.DeviceFunctions = FrameworkHelper.GetDeviceFunctions(Path.Combine(this.TestFrameworkAssemblyPath, FrameworkHelper.TestFrameworkAssemblyFile));
            dtmStudioTestData.TestEnvironment = FrameworkHelper.GetTestEnvironment(dtmStudioTestData.TestEnvironment);
            dtmStudioTestData.ReportData = FrameworkHelper.GetReportData(dtmStudioTestData.ReportData);
            dtmStudioTestData.DeviceTypeProject = FrameworkHelper.GetDeviceTypeProject(dtmStudioTestData.DeviceTypeProject);

            return dtmStudioTestData;
        }


        public DTMstudioTestData GetDTMstudioTestDataTest(DTMstudioTestData dtmStudioTestData)
        {
            //dtmStudioTestData.TestLibrary.DeviceFunctions = FrameworkHelper.GetDeviceFunctions(Path.Combine(this.TestFrameworkAssemblyPath, FrameworkHelper.TestFrameworkAssemblyFile));
            dtmStudioTestData.TestEnvironment = FrameworkHelper.GetTestEnvironment(dtmStudioTestData.TestEnvironment);
            dtmStudioTestData.ReportData = FrameworkHelper.GetReportData(dtmStudioTestData.ReportData);
            dtmStudioTestData.DeviceTypeProject = FrameworkHelper.GetDeviceTypeProject(dtmStudioTestData.DeviceTypeProject);

            return dtmStudioTestData;
        }

        /// <summary>
        /// The get config locations.
        /// </summary>
        /// <param name="executionPath">
        /// The output Path.
        /// </param>
        public void InitializeConfiguration(string executionPath)
        {
            Trace.Assert(this.TestFrameworkAssemblyPath != string.Empty && Directory.Exists(this.TestFrameworkAssemblyPath), "TestFramework nicht vorhanden");

            if (!string.IsNullOrEmpty(this.TestFrameworkAssemblyPath))
            {
                this.DeviceFunctionMappingList = FrameworkHelper.GetDeviceFunctionMappingList(this.TestFrameworkAssemblyPath);
            }

            if (!string.IsNullOrEmpty(executionPath))
            {
                this.TestFrameworkConfigFile = Path.Combine(executionPath, ConstStrings.TestFrameworkConfigFile);
                Trace.WriteLine("TestFramework Config File: " + this.TestFrameworkConfigFile);

                FrameworkHelper.InitializeConfiguratorDialog(this.TestFrameworkConfigFile);
            }
        }

        /// <summary>
        /// The load data.
        /// </summary>
        /// <param name="dtmStudioTestData">
        /// The dtm studio test data.
        /// </param>
        /// <returns>
        /// The <see cref="DTMstudioTestData"/>.
        /// </returns>
        public DTMstudioTestData LoadData(DTMstudioTestData dtmStudioTestData)
        {
            return this.GetDTMstudioTestData(dtmStudioTestData);
        }

        public DTMstudioTestData LoadDataTest(DTMstudioTestData dtmStudioTestData)
        {
            return this.GetDTMstudioTestDataTest(dtmStudioTestData);
        }

        /// <summary>
        /// The save data.
        /// </summary>
        /// <param name="dtmStudioTestData">
        /// The dtm studio test data.
        /// </param>
        public void SaveData(DTMstudioTestData dtmStudioTestData)
        {
            this.SetDTMstudioTestData(dtmStudioTestData);
        }

        /// <summary>
        /// The set dt mstudio test data.
        /// </summary>
        /// <param name="dtmStudioTestData">
        /// The dtm studio test data.
        /// </param>
        public void SetDTMstudioTestData(DTMstudioTestData dtmStudioTestData)
        {
            FrameworkHelper.SetDeviceTypeProject(dtmStudioTestData.DeviceTypeProject);
            FrameworkHelper.SetTestEnvironment(dtmStudioTestData.TestEnvironment);
            FrameworkHelper.SetReportData(dtmStudioTestData.ReportData);

            FrameworkHelper.SaveConfiguration(this.TestFrameworkConfigFile);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.DeviceFunctionMappingList = null;

                    this.disposed = true;
                }
            }
        }

        #endregion
    }
}