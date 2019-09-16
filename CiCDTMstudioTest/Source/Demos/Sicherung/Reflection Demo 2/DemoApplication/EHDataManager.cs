// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EHDataManager.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   The EH data manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Infrastructure.Manager
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using EH.DTMstudioTest.Interface.DTMstudioCoDIA.Interfaces;
    using EH.DTMstudioTest.Interface.TestFramework.Interfaces;

    /// <summary>
    /// The eh data manager.
    /// </summary>
    public class EHDataManager
    {
        #region Fiels

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion 

        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="EHDataManager"/> class.
        /// </summary>
        public EHDataManager() 
        {
            this.disposed = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the DTM studio CoDIA assembly path.
        /// </summary>
        public string AssemblyPathDTMstudioCoDIA { get; set; }

        /// <summary>
        /// Gets or sets the assembly file DTM studio CoDIA.
        /// </summary>
        public string AssemblyFileDTMstudioCoDIA { get; set; }

        /// <summary>
        /// Gets or sets the test framework references path.
        /// </summary>
        public string AssemblyPathTestFramework { get; set; }

        /// <summary>
        /// Gets or sets the assembly file test framework.
        /// </summary>
        public string AssemblyFileTestFramework { get; set; }

        /// <summary>
        /// Gets or sets the test framework.
        /// </summary>
        public ITestFramework TestFrameworkManager { get; set; }

        /// <summary>
        /// Gets or sets the CoDIA data manager.
        /// </summary>
        public IDataManager DTMstudioDataManager { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The load data.
        /// </summary>
        public void LoadData()
        {
            this.TestFrameworkManager.LoadDTMstudioData();
            this.DTMstudioDataManager.LoadDTMstudioCoDIAData();
        }

        /// <summary>
        /// The get assembly path.
        /// </summary>
        public void GetAssemblyInfo()
        {
            this.AssemblyPathTestFramework = this.GetAssemblyPathTestFramework();
            this.AssemblyFileTestFramework = this.GetAssemblyFileTestFramework();

            this.AssemblyPathDTMstudioCoDIA = this.GetAssemblyPathDTMstudioCoDIA();
            this.AssemblyFileDTMstudioCoDIA = this.GetAssemblyFileDTMstudioCoDIA();
        }

        /// <summary>
        /// The get DTM studio CoDIA assembly path.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetAssemblyPathDTMstudioCoDIA()
        {
            return @"D:\Temp\CodeWrights.DTMstudioCoDIA\";
        }

        /// <summary>
        /// The get assembly file DTM studio CoDIA.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetAssemblyFileDTMstudioCoDIA()
        {
            return @"DTMstudioCoDIA.TestApp.dll";
        }

        /// <summary>
        /// The get test framework references path.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetAssemblyPathTestFramework()
        {
            return @"D:\Temp\EH.PCSW.Testautomation.TestFramework\";
        }

        /// <summary>
        /// The get assembly file test framework.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetAssemblyFileTestFramework()
        {
            return @"EH.TestFramework.TestApp.dll";
        }

        /// <summary>
        /// The get configuration.
        /// </summary>
        public void GetConfiguration()
        {
            this.TestFrameworkManager.GetDTMstudioTestData();
            this.DTMstudioDataManager.GetDTMstudioData();
        }

        /// <summary>
        /// The activate tests for available device functions.
        /// </summary>
        public void ActivateTestsForAvailableDeviceFunctions()
        {
        }

        /// <summary>
        /// The run test.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool RunTest()
        {
            return false;
        }

        /// <summary>
        /// The check compatibility.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CheckCompatibility()
        {
            return this.CompareDTMstudioTestData() && this.VerifyDeviceTypeProject();
        }

        /// <summary>
        /// The load assemblies.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool LoadAssemblies()
        {
            return this.LoadTestFrameworkAssembly(Path.Combine(this.AssemblyPathTestFramework, this.AssemblyFileTestFramework)) &&
            this.LoadDTMstudioCoDIAAssembly(Path.Combine(this.AssemblyPathDTMstudioCoDIA, this.AssemblyFileDTMstudioCoDIA));
        }

        /// <summary>
        /// The save data.
        /// </summary>
        public void SaveConfiguration()
        {
            this.TestFrameworkManager.SaveDTMstudioData();
            this.DTMstudioDataManager.SaveDTMstudioData();
        }

        #endregion 

        #region protected Methods

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
                }

                this.disposed = true;
            }
        }

        #endregion 

        #region Private Methods

        /// <summary>
        /// The compare production record data.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CompareDTMstudioTestData()
        {
            return (this.TestFrameworkManager.DTMstudioTestData.DeviceTypeProject == this.DTMstudioDataManager.DTMstudioTestData.DeviceTypeProject) &&
            (this.TestFrameworkManager.DTMstudioTestData.ReportData == this.DTMstudioDataManager.DTMstudioTestData.ReportData) &&
            (this.TestFrameworkManager.DTMstudioTestData.TestEnvironment == this.DTMstudioDataManager.DTMstudioTestData.TestEnvironment);
        }

        /// <summary>
        /// The verify frame.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool VerifyDeviceTypeProject()
        {
            return true;
        }

        /// <summary>
        /// The load DTM studio CoDIA assembly.
        /// </summary>
        /// <param name="dtmStudioCoDIAAssemblyPath">
        /// The DTM studio CoDIA assembly path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool LoadDTMstudioCoDIAAssembly(string dtmStudioCoDIAAssemblyPath) 
        {
#if DEBUG
            dtmStudioCoDIAAssemblyPath = @"P:\EH.PCSW.Testautomation.CiCDTMstudioTest\Source\EH.DTMstudioTest.Solution\CodeWrights.DTMstudioCoDIA.TestApp\bin\Debug\DTMstudioCoDIA.TestApp.dll";
#endif 

            if (File.Exists(dtmStudioCoDIAAssemblyPath))
            {
                var myDll = Assembly.LoadFrom(dtmStudioCoDIAAssemblyPath);
                var types = myDll.GetExportedTypes();

                foreach (var type in types.Where(type => type.GetInterface("IDataManager") != null))
                {
                    if (type != null)
                    {
                        this.DTMstudioDataManager = myDll.CreateInstance(type.FullName) as IDataManager;
                        return true;
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// The load test framework assembly.
        /// </summary>
        /// <param name="testFrameworkAssemblyPath">
        /// The test framework assembly path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool LoadTestFrameworkAssembly(string testFrameworkAssemblyPath)
        {
#if DEBUG
            testFrameworkAssemblyPath =
                @"P:\EH.PCSW.Testautomation.CiCDTMstudioTest\Source\EH.DTMstudioTest.Solution\EH.TestFramework.TestApp\bin\Debug\EH.TestFramework.TestApp.dll";
#endif

            if (File.Exists(testFrameworkAssemblyPath))
            {
                var myDll = Assembly.LoadFrom(testFrameworkAssemblyPath);
                var types = myDll.GetExportedTypes();

                foreach (var type in types.Where(type => type.GetInterface("ITestFramework") != null))
                {
                    if (type != null)
                    {
                        this.TestFrameworkManager = myDll.CreateInstance(type.FullName) as ITestFramework;
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion
    }
}