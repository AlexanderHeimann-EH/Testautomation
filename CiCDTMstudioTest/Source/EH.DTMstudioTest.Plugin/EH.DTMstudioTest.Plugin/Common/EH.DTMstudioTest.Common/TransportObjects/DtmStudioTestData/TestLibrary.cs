// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestLibrary.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test library.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using EH.DTMstudioTest.Common.DeviceFunctionMapping;
    using EH.DTMstudioTest.Common.Utilities.Helper;

    /// <summary>
    /// The test library.
    /// </summary>
    [Serializable]
    public class TestLibrary : IDisposable
    {
        #region Fields

        /// <summary>
        /// The device function mapping list.
        /// </summary>
        private DeviceFunctionMappingList deviceFunctionMappingList;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestLibrary"/> class.
        /// </summary>
        public TestLibrary()
        {
            this.Initialize(string.Empty);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestLibrary"/> class.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public TestLibrary(string path)
        {
            this.Initialize(path);

            this.TestLibraryVersion = "1.0.4.0";
            this.TestPackageVersion = "1.0.17";
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TestLibrary"/> class. 
        /// </summary>
        ~TestLibrary()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the device function mapping list.
        /// </summary>
        public DeviceFunctionMappingList DeviceFunctionMappingList
        {
            get
            {
                if (this.deviceFunctionMappingList == null && !string.IsNullOrEmpty(this.TestLibrayPath))
                {
                    this.deviceFunctionMappingList = FrameworkHelper.GetDeviceFunctionMappingList(this.TestLibrayPath);
                }

                return this.deviceFunctionMappingList;
            }

            set
            {
                this.deviceFunctionMappingList = value;
            }
        }

        /// <summary>
        /// Gets or sets the device function.
        /// </summary>
        public List<DeviceFunction> DeviceFunctions { get; set; }

        /// <summary>
        /// Gets the file name.
        /// </summary>
        public string FilePath
        {
            get
            {
                return Path.Combine(this.TestLibrayPath, FrameworkHelper.TestFrameworkAssemblyFile);
            }
        }

        /// <summary>
        /// Gets or sets the test library version.
        /// </summary>
        public string TestLibraryVersion { get; set; }

        /// <summary>
        /// Gets or sets the test package version.
        /// </summary>
        public string TestPackageVersion { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        private string TestLibrayPath { get; set; }

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
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        private void Initialize(string path)
        {
            this.TestLibrayPath = path;
            this.disposed = false;
            this.DeviceFunctions = new List<DeviceFunction>();
        }

        #endregion
    }
}