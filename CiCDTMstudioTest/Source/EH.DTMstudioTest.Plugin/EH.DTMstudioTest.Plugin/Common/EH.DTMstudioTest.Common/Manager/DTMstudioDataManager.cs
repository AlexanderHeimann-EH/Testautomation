// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DTMstudioDataManager.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   The CoDIADataManager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    using CodeWrights.DtmStudioCoDIA.Common.TaskInfrastructure.Implementation;
    using CodeWrights.DtmStudioCoDIA.Common.TaskInfrastructure.Interface.Data;
    using CodeWrights.DTMstudioInfrastructure.Logging;

    using EH.DTMstudioTest.Common.DeviceFunctionMapping;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.DTMstudioTest.Common.Utilities.Logging;

    /// <summary>
    /// The CoDIA data manager.
    /// </summary>
    public class DtmStudioDataManager : IDisposable
    {
        #region Fields

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DtmStudioDataManager"/> class.
        /// </summary>
        public DtmStudioDataManager()
        {
            this.disposed = false;
        }

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
        /// The get device type project data.
        /// </summary>
        /// <param name="projectFile">
        /// The project file.
        /// </param>
        /// <param name="dtmStudioTestData">
        /// The dtm studio test data.
        /// </param>
        public DTMstudioTestData GetDeviceTypeProjectData(string projectFile, DTMstudioTestData dtmStudioTestData)
        {
            if (File.Exists(projectFile))
            {
                var commonTaskInfrastructure = new CommonTaskInfrastructure(projectFile, new NoLoggingLogger());

                try
                {
                    var fdtDeviceTypeName = commonTaskInfrastructure.Information.GetDeviceTypeName();
                    Trace.Assert(fdtDeviceTypeName != string.Empty, "FDTDeviceTypeName == null");
                    dtmStudioTestData.DeviceTypeProject.FDTDeviceTypeName = fdtDeviceTypeName;
                }
                catch (Exception ex)
                {
                    Log.ErrorEx(this, ex, "GetDeviceTypeProjectData GetDeviceTypeProjectGuid " + ex.Message);
                }

                try
                {
                    var guid = commonTaskInfrastructure.Information.GetDeviceTypeProjectGuid();
                    Trace.Assert(guid.ToString() != string.Empty, "FDTDeviceType guid == null");
                    dtmStudioTestData.DeviceTypeProject.Guid = guid;
                }
                catch (Exception ex)
                {
                    Log.ErrorEx(this, ex, "GetDeviceTypeProjectData GetDeviceTypeProjectGuid " + ex.Message);
                }

                var version = new Version();

                try
                {
                    var versionString = commonTaskInfrastructure.Information.GetDeviceTypeVersion();
                    Trace.Assert(versionString != string.Empty, "Device Type Version == string.Empty");

                    if (versionString != string.Empty)
                    {
                        version = new Version(versionString);
                    }

                    var deviceTypeFramework = new DeviceTypeFramework { VersionString = versionString, Version = version };
                    Trace.Assert(deviceTypeFramework != null, "deviceTypeFramework == null");

                    dtmStudioTestData.DeviceTypeProject.DeviceTypeFramework = deviceTypeFramework;
                }
                catch (Exception ex)
                {
                    Log.ErrorEx(this, ex, "GetDeviceTypeProjectData GetDeviceTypeVersion " + ex.Message);
                }

                try
                {
                    dtmStudioTestData.DeviceTypeProject.DeviceTypeFramework.FrameworkComponents = new List<FrameworkComponent>();
                    foreach (var projectPackage in commonTaskInfrastructure.Information.GetProjectPackages())
                    {
                        var frameworkComponent = new FrameworkComponent { Name = projectPackage.Value.Name, DisplayName = projectPackage.Value.Title, VersionString = projectPackage.Value.Version, Version = new Version(projectPackage.Value.Version) };

                        dtmStudioTestData.DeviceTypeProject.DeviceTypeFramework.FrameworkComponents.Add(frameworkComponent);
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorEx(this, ex, "GetDeviceTypeProjectData GetProjectPackages " + ex.Message);
                }

                try
                {
                    dtmStudioTestData.DeviceTypeProject.DeviceFunctions.Clear();

                    Dictionary<string, IModuleInfo> moduleInfos = commonTaskInfrastructure.Information.GetCodiaModuleInfos(0);

                    foreach (var modulInfo in moduleInfos)
                    {
                        if (modulInfo.Value.Version.Split('.').Length == 4)
                        {
                            var deviceFunctionMapping = this.GetdeviceFunctionMapping(modulInfo.Value.Name, dtmStudioTestData);

                            var deviceFunction = new DeviceFunction
                                                     {
                                                         Active = ((modulInfo.Value.Flags & ModuleState.Enabled) == ModuleState.Enabled),
                                                         DisplayName = deviceFunctionMapping.DisplayName != string.Empty ? deviceFunctionMapping.DisplayName : modulInfo.Value.Name, 
                                                         Name = modulInfo.Value.Name, 
                                                         FrameworkMappingName = deviceFunctionMapping.TestFrameworkDeviceFunctionName, 
                                                         CompilerVariable = modulInfo.Value.Name.ToUpper().Replace(".", string.Empty), VersionString = modulInfo.Value.Version, Version = new Version(modulInfo.Value.Version)
                                                     };

                            dtmStudioTestData.DeviceTypeProject.DeviceFunctions.Add(deviceFunction);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorEx(this, ex, "GetDeviceTypeProjectData GetCodiaModuleInfos " + ex.Message);
                }
            }

            return dtmStudioTestData;
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
            return this.GetDeviceTypeProjectData(dtmStudioTestData.DeviceTypeProject.DeviceTypeProjectPath, dtmStudioTestData);
        }

        /// <summary>
        /// The save data.
        /// </summary>
        /// <param name="dtmStudioTestData">
        /// The dtm studio test data.
        /// </param>
        public void SaveData(DTMstudioTestData dtmStudioTestData)
        {
            this.SetTestResult(dtmStudioTestData.DeviceTypeProject.DeviceTypeProjectPath);
        }

        /// <summary>
        /// The set device type project data.
        /// </summary>
        /// <param name="projectFile">
        /// The device Type Project Path.
        /// </param>
        public void SetTestResult(string projectFile)
        {
            if (File.Exists(projectFile))
            {
                // #if !DEBUG // ist von seiten CodeWrights noch nicht implementiert !!!!!! AHHIER
                // var deviceTypeProjectTempDataPath = Path.Combine(this.projectOutputPath, DeviceTypeProjectTempDataFile); 
                // var deviceTypeProjectStream = new StreamReader(deviceTypeProjectTempDataPath);
                // string deviceTypeProjectText = deviceTypeProjectStream.ReadToEnd();
                // deviceTypeProjectStream.Close();

                // var deviceTypeProjectTempDataSchemaPath = Path.Combine(this.projectOutputPath, DeviceTypeProjectTempDataSchema);
                // var deviceTypeProjectSchemaStream = new StreamReader(deviceTypeProjectTempDataSchemaPath);
                // string deviceTypeProjectSchemaText = deviceTypeProjectSchemaStream.ReadToEnd();
                // deviceTypeProjectSchemaStream.Close();

                // var commonTaskInfrastructure = new CommonTaskInfrastructure(projectFile, new NoLoggingLogger());

                // commonTaskInfrastructure.TestResult.SetTestResult(deviceTypeProjectText, deviceTypeProjectSchemaText);
                // #endif
            }
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
        /// The getdevice function mapping.
        /// </summary>
        /// <param name="coDIADeviceFunctionName">
        /// The co dia device function name.
        /// </param>
        /// <param name="dtmStudioTestData">
        /// The dtm studio test data.
        /// </param>
        /// <returns>
        /// The <see cref="DeviceFunctionMapping"/>.
        /// </returns>
        private DeviceFunctionMapping GetdeviceFunctionMapping(string coDIADeviceFunctionName, DTMstudioTestData dtmStudioTestData)
        {
            foreach (var deviceFunctionMapping in dtmStudioTestData.TestLibrary.DeviceFunctionMappingList.DeviceFunctionList)
            {
                if (deviceFunctionMapping.CoDIADeviceFunctionName == coDIADeviceFunctionName)
                {
                    return deviceFunctionMapping;
                }
            }

            return new DeviceFunctionMapping();
        }

        #endregion
    }
}
