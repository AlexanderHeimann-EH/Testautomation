// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHDataManager.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The eh data manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.Manager
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Xml.Serialization;

    using EH.DTMstudioTest.Common.DeviceFunctionMapping;
    using EH.DTMstudioTest.Common.Interfaces;
    using EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.DTMstudioTest.Common.Utilities.Helper;
    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.DTMstudioTest.Common.Utilities.Serialization;

    /// <summary>
    /// The eh data manager.
    /// </summary>
    public class EhDataManager : IDisposable
    {
        #region Constants

        /// <summary>
        /// The temp DTM studio test data path.
        /// </summary>
        private const string DeviceTypeProjectDataFile = @"DeviceTypeProjectData.xml";

        /// <summary>
        /// The production record test temp schema path.
        /// </summary>
        private const string DeviceTypeProjectTempDataSchema = @"DeviceTypeProjectTempSchema.xsd";

        #endregion

        #region Fields

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The dt mstudio test data.
        /// </summary>
        private DTMstudioTestData dtMstudioTestData;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EhDataManager"/> class.
        /// </summary>
        public EhDataManager()
        {
            this.Initialize(string.Empty, string.Empty);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EhDataManager"/> class.
        /// </summary>
        /// <param name="deviceTypeProjectPath">
        /// The device type project path.
        /// </param>
        /// <param name="testFrameworkPath">
        /// The test framework path.
        /// </param>
        public EhDataManager(string deviceTypeProjectPath, string testFrameworkPath)
        {
            this.Initialize(deviceTypeProjectPath, testFrameworkPath);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the CoDIA data manager.
        /// </summary>
        /// <value>The DTM studio data manager.</value>
        public DtmStudioDataManager DTMstudioDataManager { get; set; }

        /// <summary>
        /// Gets or sets the DTM studio test data.
        /// </summary>
        /// <value>The DTM studio test data.</value>
        public DTMstudioTestData DTMstudioTestData
        {
            get
            {
                return this.dtMstudioTestData;
            }

            set
            {
                this.dtMstudioTestData = value;
            }
        }

        /// <summary>
        /// Gets or sets the test framework.
        /// </summary>
        /// <value>The test framework manager.</value>
        public TestFrameworkDataManager TestFrameworkManager { get; set; }

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
        /// The get production record test temp data.
        /// </summary>
        /// <param name="tempFile">
        /// The temp File.
        /// </param>
        public void GetDTMstudioTestData(string tempFile)
        {
            if (File.Exists(tempFile))
            {
                Exception exception;

                this.DTMstudioTestData = (DTMstudioTestData)XmlSerialization.XmlDeserializeObject(tempFile, typeof(DTMstudioTestData), out exception, false);

                if (exception != null)
                {
                    File.Copy(tempFile, string.Format("{0}_{1}", tempFile, DateTime.Now.ToString("ddMMyyyy hhmmss mm", CultureInfo.InvariantCulture)));
                    File.Delete(tempFile);
                    this.DTMstudioTestData = new DTMstudioTestData();

                    Log.ErrorEx(this, exception, exception.Message);
                }
            }
        }

        /// <summary>
        /// The get device function from test framework.
        /// </summary>
        /// <param name="dtmStudioDeviceFunction">
        /// The DTM studio device function.
        /// </param>
        /// <returns>
        /// The <see cref="DeviceFunctionMapping"/>.
        /// </returns>
        public DeviceFunctionMapping GetDeviceFunctionMappingFromTestFramework(DeviceFunction dtmStudioDeviceFunction)
        {
            foreach (var testFrameworkDeviceFunction in this.DTMstudioTestData.TestLibrary.DeviceFunctions)
            {
                foreach (var deviceFunction in this.TestFrameworkManager.DeviceFunctionMappingList.DeviceFunctionList)
                {
                    if (deviceFunction.TestFrameworkDeviceFunctionName == testFrameworkDeviceFunction.Name)
                    {
                        if (deviceFunction.CoDIADeviceFunctionName == dtmStudioDeviceFunction.Name)
                        {
                            return deviceFunction;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// The load data.
        /// </summary>
        /// <param name="currentDirectory">
        /// The current Directory.
        /// </param>
        public void LoadData(string currentDirectory)
        {
            this.TestFrameworkManager.InitializeConfiguration(currentDirectory);
            FrameworkHelper.SetDeviceTypeProject(this.DTMstudioTestData.DeviceTypeProject);

            var deviceTypeProjectTempDataPath = Path.Combine(this.DTMstudioTestData.DeviceTypeTestProject.ExecutionPath, DeviceTypeProjectDataFile);
            this.GetDTMstudioTestData(deviceTypeProjectTempDataPath);

            this.DTMstudioTestData.DeviceTypeTestProject.ExecutionPath = currentDirectory;

            this.dtMstudioTestData = this.TestFrameworkManager.LoadData(this.dtMstudioTestData);
            this.dtMstudioTestData = this.DTMstudioDataManager.LoadData(this.dtMstudioTestData);
        }

        /// <summary>
        /// The load data for execution.
        /// </summary>
        /// <param name="currentDirectory">
        /// The current directory.
        /// </param>
        public void LoadDataForExecution(string currentDirectory)
        {
            this.TestFrameworkManager.InitializeConfiguration(Environment.CurrentDirectory);
            FrameworkHelper.SetDeviceTypeProject(this.DTMstudioTestData.DeviceTypeProject);

            var deviceTypeProjectTempDataPath = Path.Combine(this.DTMstudioTestData.DeviceTypeTestProject.ExecutionPath, DeviceTypeProjectDataFile);
            this.GetDTMstudioTestData(deviceTypeProjectTempDataPath);

            this.DTMstudioTestData.DeviceTypeTestProject.ExecutionPath = Environment.CurrentDirectory;

            this.dtMstudioTestData = this.TestFrameworkManager.LoadDataTest(this.dtMstudioTestData);
            this.dtMstudioTestData = this.DTMstudioDataManager.LoadData(this.dtMstudioTestData);
        }

        /// <summary>
        /// The load temp data.
        /// </summary>
        public void LoadTestData()
        {
            var deviceTypeProjectTempDataPath = Path.Combine(Environment.CurrentDirectory, DeviceTypeProjectDataFile);
            this.GetDTMstudioTestData(deviceTypeProjectTempDataPath);

            this.dtMstudioTestData = this.TestFrameworkManager.LoadData(this.dtMstudioTestData);
            this.dtMstudioTestData = this.DTMstudioDataManager.LoadData(this.dtMstudioTestData);
        }

        /// <summary>
        /// The save data.
        /// </summary>
        public void SaveData()
        {
            this.DTMstudioDataManager.SaveData(this.dtMstudioTestData);
            this.TestFrameworkManager.SaveData(this.dtMstudioTestData);

            this.SaveDeviceTypeProjectData();
        }

        /// <summary>
        /// The set device type project temp data.
        /// </summary>
        public void SaveDeviceTypeProjectData()
        {
            var xmlns = new XmlSerializerNamespaces();
            xmlns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xmlns.Add("xsd", "http://www.w3.org/2001/XMLSchema");
            xmlns.Add("schemaLocation", "PCPS/TestData DeviceTypeProjectTempSchema.xsd");
            var file = Path.Combine(this.DTMstudioTestData.DeviceTypeTestProject.ExecutionPath, DeviceTypeProjectDataFile);
            XmlSerialization.XmlSerializeObject(file, this.DTMstudioTestData, xmlns);
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
                    this.TestFrameworkManager = null;
                    this.DTMstudioDataManager = null;
                    this.DTMstudioTestData = null;
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="deviceTypeProjectPath">
        /// The device type project path.
        /// </param>
        /// <param name="testFrameworkPath">
        /// The test framework path.
        /// </param>
        private void Initialize(string deviceTypeProjectPath, string testFrameworkPath)
        {
            this.DTMstudioTestData = new DTMstudioTestData(deviceTypeProjectPath, testFrameworkPath);

            this.DTMstudioDataManager = new DtmStudioDataManager();
            this.TestFrameworkManager = new TestFrameworkDataManager();

            this.disposed = false;
        }

        #endregion
    }
}