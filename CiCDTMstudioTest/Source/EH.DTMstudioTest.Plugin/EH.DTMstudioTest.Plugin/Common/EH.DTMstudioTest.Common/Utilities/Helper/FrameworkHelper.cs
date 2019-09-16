// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameworkHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright � Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.Utilities.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    using EH.DTMstudioTest.Common.DeviceFunctionMapping;
    using EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy;
    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument;
    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Configurator.GUI;
    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    /// The helper.
    /// </summary>
    public class FrameworkHelper : IDisposable
    {
        #region Constants

        /// <summary>
        /// The test framework assembly file.
        /// </summary>
        public const string TestFrameworkAssemblyFile = @"EH.PCPS.TestAutomation.Testlibrary.dll";

        /// <summary>
        /// The device function list file.
        /// </summary>
        private const string DeviceFunctionMappingListFile = "DeviceFunctionMappingListFile.xml";

        #endregion

        #region Static Fields

        /// <summary>
        /// The configurator dialog.
        /// </summary>
        private static ConfiguratorDialog configuratorDialog;

        #endregion

        #region Fields

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get device function mapping list.
        /// </summary>
        /// <param name="testFrameworkAssemblyPath">
        /// The test Framework Assembly Path.
        /// </param>
        /// <returns>
        /// The <see cref="DeviceFunctionMappingList"/>.
        /// </returns>
        public static DeviceFunctionMappingList GetDeviceFunctionMappingList(string testFrameworkAssemblyPath)
        {
            var mappingFile = Path.Combine(testFrameworkAssemblyPath, DeviceFunctionMappingListFile);

            Trace.Assert(File.Exists(mappingFile), string.Format("Datei {0} nicht vorhanden", mappingFile));

            return DeviceFunctionMappingHelper.DeSerializeDeviceFunctionMappingList(mappingFile);
        }

        /// <summary>
        /// The get device functions.
        /// </summary>
        /// <param name="testFrameworkAssemblyFile">
        /// The test framework assembly file.
        /// </param>
        /// <returns>
        /// The <see cref="DeviceFunction"/>.
        /// </returns>
        public static List<DeviceFunction> GetDeviceFunctions(string testFrameworkAssemblyFile)
        {
            return GetSetupDeliveryDeviceFunctionsFromAssembly(testFrameworkAssemblyFile);
        }

        /// <summary>
        /// The set device type project.
        /// </summary>
        /// <param name="deviceTypeProject">
        /// The device Type Project.
        /// </param>
        /// <returns>
        /// The <see cref="DTMstudioTestData.DeviceTypeProject"/>.
        /// </returns>
        public static DeviceTypeProject GetDeviceTypeProject(DeviceTypeProject deviceTypeProject)
        {
            if (ConfiguratorDialog.SelectedConfiguration != null && ConfiguratorDialog.SelectedConfiguration.TestInformation != null)
            {
                deviceTypeProject.FDTDeviceTypeName = ConfiguratorDialog.SelectedConfiguration.TestInformation.DeviceType;
                deviceTypeProject.DeviceTypeProjectPath = ConfiguratorDialog.SelectedConfiguration.TestInformation.DeviceTypeProjectPath;
            }

            return deviceTypeProject;
        }

        /// <summary>
        /// The get report data.
        /// </summary>
        /// <param name="reportData">
        /// The report Data.
        /// </param>
        /// <returns>
        /// The <see cref="ReportData"/>.
        /// </returns>
        public static ReportData GetReportData(ReportData reportData)
        {
            if (ConfiguratorDialog.SelectedConfiguration != null && ConfiguratorDialog.SelectedConfiguration.TestInformation != null)
            {
                reportData.ResultOfTest = "NOT SUPPORTED";
                reportData.DeviceSerialNumber = ConfiguratorDialog.SelectedConfiguration.TestInformation.DeviceSerialNumber;
                reportData.DeviceId = ConfiguratorDialog.SelectedConfiguration.TestInformation.DeviceId;
                reportData.Company = ConfiguratorDialog.SelectedConfiguration.TestInformation.Company;
                reportData.DateOfTest = ConfiguratorDialog.SelectedConfiguration.TestInformation.DateOfTest;
                reportData.NameOfTester = ConfiguratorDialog.SelectedConfiguration.TestInformation.NameOfTester;
            }

            return reportData;
        }

        /// <summary>
        /// The get setup delivery device functions from assembly.
        /// </summary>
        /// <param name="testFrameworkAssemblyPath">
        /// The test framework assembly path.
        /// </param>
        /// <returns>
        /// The <see cref="DeviceFunction"/>.
        /// </returns>
        public static List<DeviceFunction> GetSetupDeliveryDeviceFunctionsFromAssembly(string testFrameworkAssemblyPath)
        {
            var deviceFunctionList = new List<DeviceFunction>();

            var suitesFiles = AssemblyProxy.GetTestSuitesFileFromAssembly(testFrameworkAssemblyPath);
            foreach (var suitesFile in suitesFiles)
            {
                try
                {
                    var testConfig = new TestConfiguration();
                    testConfig = testConfig.GetTestConfiguration(suitesFile.ResourceNameFullPath);

                    foreach (var availableTestObject in testConfig.AvailableTestObjects)
                    {
                        if (availableTestObject is TestSuite)
                        {
                            var testSuite = availableTestObject as TestSuite;
                            if (testSuite.TestCategory == TestCategory.SetupDelivery)
                            {
                                var deviceFunction = new DeviceFunction 
                                { 
                                    DisplayName = testSuite.TestFocus.ToString(), 
                                    Name = testSuite.TestFocus.ToString(), 
                                    Active = true, 
                                    Version = new Version() 
                                };

                                deviceFunctionList.Add(deviceFunction);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorEx(null, ex, string.Format("AddPredefinedTestSuitesFromAssembly: {0} - {1}", suitesFile.ResourceNameFullPath, ex.Message));
                }
            }

            return deviceFunctionList;
        }

        /// <summary>
        /// The get test environment.
        /// </summary>
        /// <param name="testMachineSpecificData">
        /// The test Machine Specific Data.
        /// </param>
        /// <returns>
        /// The <see cref="TestEnvironment"/>.
        /// </returns>
        public static TestEnvironment GetTestEnvironment(TestEnvironment testMachineSpecificData)
        {
            if (ConfiguratorDialog.SelectedConfiguration != null && ConfiguratorDialog.SelectedConfiguration.TestEnvironment != null)
            {
                testMachineSpecificData.DeviceFunctionsPackage = ConfiguratorDialog.SelectedConfiguration.TestEnvironment.DeviceFunction.Assembly;
                testMachineSpecificData.DeviceFunctionPlatform = ConfiguratorDialog.SelectedConfiguration.TestEnvironment.DeviceFunction.Category;
                testMachineSpecificData.OperatingSystemBitVersion = ConfiguratorDialog.SelectedConfiguration.TestEnvironment.OperatingSystem.Category;
                testMachineSpecificData.CommunicationDeviceTypeName = ConfiguratorDialog.SelectedConfiguration.TestEnvironment.Communication.Assembly;
                testMachineSpecificData.CommunicationProtocol = ConfiguratorDialog.SelectedConfiguration.TestEnvironment.Communication.Category;

                testMachineSpecificData.OperatingSystemServicePack = ConfiguratorDialog.SelectedConfiguration.TestEnvironment.OperatingSystem.Assembly; // Environment.OSVersion.ServicePack;
                testMachineSpecificData.OperatingSystemName = ConfiguratorDialog.SelectedConfiguration.TestEnvironment.OperatingSystem.Assembly;
                testMachineSpecificData.HostApplicationName = ConfiguratorDialog.SelectedConfiguration.TestEnvironment.HostApplication.Assembly;
                testMachineSpecificData.HostApplicationType = ConfiguratorDialog.SelectedConfiguration.TestEnvironment.HostApplication.Category;
                testMachineSpecificData.ComputerName = Environment.MachineName;
            }

            return testMachineSpecificData;
        }

        /// <summary>
        /// The initialize configurator dialog.
        /// </summary>
        /// <param name="testFrameworkConfigFile">
        /// The test framework config file.
        /// </param>
        public static void InitializeConfiguratorDialog(string testFrameworkConfigFile)
        {
            configuratorDialog = new ConfiguratorDialog(testFrameworkConfigFile);
            //configuratorDialog.Initialize(testFrameworkConfigFile);
        }

        /// <summary>
        /// The save configuration.
        /// </summary>
        /// <param name="pathToConfigurationXml">
        /// The path To Configuration Xml.
        /// </param>
        public static void SaveConfiguration(string pathToConfigurationXml)
        {
            if (ConfiguratorDialog.SelectedConfiguration != null)
            {
                XmlFileHandler.WriteDataToXml(ConfiguratorDialog.SelectedConfiguration, pathToConfigurationXml);
            }
        }

        /// <summary>
        /// The save new configuration.
        /// </summary>
        /// <param name="testFrameworkConfigFile">
        /// The test framework config file.
        /// </param>
        /// <param name="testFrameworkAssembliesPath">
        /// The test framework assemblies path.
        /// </param>
        public static void SaveNewConfiguration(string testFrameworkConfigFile, string testFrameworkAssembliesPath)
        {
            XmlFileHandler.WriteEmptyXmlFile(testFrameworkConfigFile, testFrameworkAssembliesPath);
        }

        /// <summary>
        /// The set device type project.
        /// </summary>
        /// <param name="deviceTypeProject">
        /// The device type project.
        /// </param>
        public static void SetDeviceTypeProject(DeviceTypeProject deviceTypeProject)
        {
            if (ConfiguratorDialog.SelectedConfiguration != null && ConfiguratorDialog.SelectedConfiguration.TestInformation != null)
            {
                if (!string.IsNullOrEmpty(deviceTypeProject.FDTDeviceTypeName))
                {
                    ConfiguratorDialog.SelectedConfiguration.TestInformation.DeviceType = deviceTypeProject.FDTDeviceTypeName;
                }

                if (!string.IsNullOrEmpty(deviceTypeProject.DeviceTypeProjectPath))
                {
                    ConfiguratorDialog.SelectedConfiguration.TestInformation.DeviceTypeProjectPath = deviceTypeProject.DeviceTypeProjectPath;
                }
            }
        }

        /// <summary>
        /// The set report data.
        /// </summary>
        /// <param name="reportData">
        /// The report data.
        /// </param>
        public static void SetReportData(ReportData reportData)
        {
            if (ConfiguratorDialog.SelectedConfiguration != null && ConfiguratorDialog.SelectedConfiguration.TestInformation != null)
            {
                ConfiguratorDialog.SelectedConfiguration.TestInformation.NameOfTester = reportData.NameOfTester;
                ConfiguratorDialog.SelectedConfiguration.TestInformation.DateOfTest = reportData.DateOfTest;
                ConfiguratorDialog.SelectedConfiguration.TestInformation.DeviceSerialNumber = reportData.DeviceSerialNumber;
                ConfiguratorDialog.SelectedConfiguration.TestInformation.Company = reportData.Company;
                ConfiguratorDialog.SelectedConfiguration.TestInformation.DeviceId = reportData.DeviceId;
            }
        }

        /// <summary>
        /// The set test environment.
        /// </summary>
        /// <param name="testEnvironment">
        /// The test environment.
        /// </param>
        public static void SetTestEnvironment(TestEnvironment testEnvironment)
        {
            if (ConfiguratorDialog.SelectedConfiguration != null && ConfiguratorDialog.SelectedConfiguration.TestEnvironment != null)
            {
                ConfiguratorDialog.SelectedConfiguration.TestEnvironment.HostApplication.Category = testEnvironment.HostApplicationType;
                ConfiguratorDialog.SelectedConfiguration.TestEnvironment.HostApplication.Assembly = testEnvironment.HostApplicationName;
                ConfiguratorDialog.SelectedConfiguration.TestEnvironment.OperatingSystem.Assembly = testEnvironment.OperatingSystemName;
                ConfiguratorDialog.SelectedConfiguration.TestEnvironment.OperatingSystem.Category = testEnvironment.OperatingSystemBitVersion;

                ConfiguratorDialog.SelectedConfiguration.TestEnvironment.Communication.Category = testEnvironment.CommunicationProtocol;
                ConfiguratorDialog.SelectedConfiguration.TestEnvironment.Communication.Assembly = testEnvironment.CommunicationDeviceTypeName;

                ConfiguratorDialog.SelectedConfiguration.TestEnvironment.DeviceFunction.Category = testEnvironment.DeviceFunctionPlatform;
                ConfiguratorDialog.SelectedConfiguration.TestEnvironment.DeviceFunction.Assembly = testEnvironment.DeviceFunctionsPackage;
            }
        }

        /// <summary>
        /// The show configuration dialog.
        /// </summary>
        /// <param name="testFrameworkConfigFile">
        /// The test Framework Config File.
        /// </param>
        public static void ShowConfigurationDialog(string testFrameworkConfigFile)
        {
            InitializeConfiguratorDialog(testFrameworkConfigFile);

            switch (configuratorDialog.ShowDialog())
            {
                case DialogResult.Cancel:
                    throw new Exception("Cancel");
                case DialogResult.Yes:
                    break;
            }
        }

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

        #endregion
    }
}
