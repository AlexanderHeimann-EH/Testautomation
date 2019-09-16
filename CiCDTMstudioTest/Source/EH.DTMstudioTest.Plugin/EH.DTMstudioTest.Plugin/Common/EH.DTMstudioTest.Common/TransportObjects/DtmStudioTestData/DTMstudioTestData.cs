// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DTMstudioTestData.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   DTMstudioTestData ist unser (CiC DTMstudio Test)-Anteil am Production Record
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// DTMstudioTestData ist unser (CiC DTMstudio Test)-Anteil am Production Record
    /// </summary>
    [Serializable]
    [XmlRoot("DTMstudioTestData", Namespace = "PCPS/TestData", IsNullable = false)]
    public class DTMstudioTestData : IDisposable
    {
        #region Fields

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DTMstudioTestData"/> class.
        /// </summary>
        public DTMstudioTestData()
        {
            this.Initialize(string.Empty, string.Empty);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DTMstudioTestData"/> class.
        /// </summary>
        /// <param name="deviceTypeProjectPath">
        /// The device type project path.
        /// </param>
        /// <param name="testFrameworkPath">
        /// The test framework path.
        /// </param>
        public DTMstudioTestData(string deviceTypeProjectPath, string testFrameworkPath)
        {
            this.Initialize(deviceTypeProjectPath, testFrameworkPath);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DTMstudioTestData"/> class. 
        /// </summary>
        ~DTMstudioTestData()
        {
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the device type project.
        /// </summary>
        public DeviceTypeProject DeviceTypeProject { get; set; }

        /// <summary>
        /// Gets or sets the test project.
        /// </summary>
        public DeviceTypeTestProject DeviceTypeTestProject { get; set; }

        /// <summary>
        /// Gets or sets the report data.
        /// </summary>
        public ReportData ReportData { get; set; }

        /// <summary>
        /// Gets or sets the test environment.
        /// </summary>
        public TestEnvironment TestEnvironment { get; set; }

        /// <summary>
        /// Gets or sets the test library.
        /// </summary>
        public TestLibrary TestLibrary { get; set; }

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
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.DeviceTypeProject = null;
                    this.TestEnvironment = null;
                    this.ReportData = null;
                    this.TestLibrary = null;
                    this.DeviceTypeTestProject = null;

                    this.disposed = true;
                }
            }
        }

        #endregion

        #region Methods

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
            this.DeviceTypeProject = new DeviceTypeProject(deviceTypeProjectPath);
            this.TestEnvironment = new TestEnvironment();
            this.ReportData = new ReportData();
            this.TestLibrary = new TestLibrary(testFrameworkPath);
            this.DeviceTypeTestProject = new DeviceTypeTestProject();

            this.disposed = false;
        }

        #endregion
    }
}