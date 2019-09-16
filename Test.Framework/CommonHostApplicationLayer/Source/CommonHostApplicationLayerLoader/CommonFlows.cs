// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFlows.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The common flows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.BO;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// The common flows.
    /// </summary>
    public class CommonFlows
    {
        #region Static Fields

        /// <summary>
        /// The execution directory.
        /// </summary>
        private static readonly string ExecutionDirectory;

        /// <summary>
        /// The namespace h.
        /// </summary>
        private static readonly string NamespaceHostApplication;

        #endregion

        // Add here more interfaces definitions
        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="CommonFlows"/> class.
        /// </summary>
        static CommonFlows()
        {
            try
            {
                ExecutionDirectory = Configuration.HostApplication;
                NamespaceHostApplication = Configuration.HostApplicationNamespace + ".CommonFlows";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the add device.
        /// </summary>
        public static IAddDevice AddDevice
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".AddDevice") as IAddDevice;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the close function.
        /// </summary>
        public static ICloseFunction CloseFunction
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".CloseFunction") as ICloseFunction;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the close host application.
        /// </summary>
        public static ICloseHostApplication CloseHostApplication
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".CloseHostApplication") as ICloseHostApplication;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the close project.
        /// </summary>
        /// <value>The close project.</value>
        public static ICloseProject CloseProject
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".CloseProject") as ICloseProject;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the connect device.
        /// </summary>
        /// <value>The connect device.</value>
        public static IConnectDevice ConnectDevice
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".ConnectDevice") as IConnectDevice;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the create project.
        /// </summary>
        /// <value>The create project.</value>
        public static ICreateProject CreateProject
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".CreateProject") as ICreateProject;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the create topology offline.
        /// </summary>
        /// <value>The create topology offline.</value>
        public static ICreateTopologyOffline CreateTopologyOffline
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".CreateTopologyOffline") as ICreateTopologyOffline;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the create topology online.
        /// </summary>
        /// <value>The create topology online.</value>
        public static ICreateTopologyOnline CreateTopologyOnline
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".CreateTopologyOnline") as ICreateTopologyOnline;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the delete project.
        /// </summary>
        /// <value>The delete project.</value>
        public static IDeleteProject DeleteProject
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".DeleteProject") as IDeleteProject;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the disconnect device.
        /// </summary>
        /// <value>The disconnect device.</value>
        public static IDisconnectDevice DisconnectDevice
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".DisconnectDevice") as IDisconnectDevice;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the get COMM DTM container path.
        /// </summary>
        /// <value>The get COMM DTM container path.</value>
        public static IGetCommDtmContainerPath GetCommDtmContainerPath
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".GetCommDtmContainerPath") as IGetCommDtmContainerPath;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the get critical error.
        /// </summary>
        /// <value>The get critical error.</value>
        public static IGetCriticalError GetCriticalError
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".GetCriticalError") as IGetCriticalError;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the get device list.
        /// </summary>
        /// <value>The get device list.</value>
        public static IGetDeviceList GetDeviceList
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".GetDeviceList") as IGetDeviceList;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the get DTM container path.
        /// </summary>
        /// <value>The get DTM container path.</value>
        public static IGetDtmContainerPath GetDtmContainerPath
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".GetDtmContainerPath") as IGetDtmContainerPath;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the get message log.
        /// </summary>
        /// <value>The get message log.</value>
        public static IGetMessageLog GetMessageLog
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".GetMessageLog") as IGetMessageLog;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the language of the host application.
        /// </summary>
        /// <value>The get message log.</value>
        public static IGetHostApplicationLanguage GetHostApplicationLanguage
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".GetHostApplicationLanguage") as IGetHostApplicationLanguage;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the get selected device.
        /// </summary>
        /// <value>The get selected device.</value>
        public static IGetSelectedDevice GetSelectedDevice
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".GetSelectedDevice") as IGetSelectedDevice;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the load project.
        /// </summary>
        /// <value>The load project.</value>
        public static ILoadProject LoadProject
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".LoadProject") as ILoadProject;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the open additional function.
        /// </summary>
        /// <value>The open additional function.</value>
        public static IOpenAdditionalFunction OpenAdditionalFunction
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".OpenAdditionalFunction") as IOpenAdditionalFunction;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the open function.
        /// </summary>
        /// <value>The open function.</value>
        public static IOpenFunction OpenFunction
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".OpenFunction") as IOpenFunction;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the open host application.
        /// </summary>
        /// <value>The open host application.</value>
        public static IOpenHostApplication OpenHostApplication
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".OpenHostApplication") as IOpenHostApplication;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the print device information.
        /// </summary>
        /// <value>The print device information.</value>
        public static IPrintDeviceInformation PrintDeviceInformation
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".PrintDeviceInformation") as IPrintDeviceInformation;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the read data from device.
        /// </summary>
        /// <value>The read data from device.</value>
        public static IReadDataFromDevice ReadDataFromDevice
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".ReadDataFromDevice") as IReadDataFromDevice;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the type of the register device.
        /// </summary>
        /// <value>The type of the register device.</value>
        public static IRegisterDeviceType RegisterDeviceType
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".RegisterDeviceType") as IRegisterDeviceType;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the remove device.
        /// </summary>
        /// <value>The remove device.</value>
        public static IRemoveDevice RemoveDevice
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".RemoveDevice") as IRemoveDevice;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the restore device data.
        /// </summary>
        /// <value>The restore device data.</value>
        public static IRestoreDeviceData RestoreDeviceData
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".RestoreDeviceData") as IRestoreDeviceData;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the save device data.
        /// </summary>
        /// <value>The save device data.</value>
        public static ISaveDeviceData SaveDeviceData
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".SaveDeviceData") as ISaveDeviceData;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the save project.
        /// </summary>
        /// <value>The save project.</value>
        public static ISaveProject SaveProject
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".SaveProject") as ISaveProject;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the select device.
        /// </summary>
        /// <value>The select device.</value>
        public static ISelectDevice SelectDevice
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".SelectDevice") as ISelectDevice;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the add device.
        /// </summary>
        public static ISwitchToFunction SwitchToFunction
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".SwitchToFunction") as ISwitchToFunction;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the type of the unregister device.
        /// </summary>
        /// <value>The type of the unregister device.</value>
        public static IUnregisterDeviceType UnregisterDeviceType
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".UnregisterDeviceType") as IUnregisterDeviceType;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the write data to device.
        /// </summary>
        /// <value>The write data to device.</value>
        public static IWriteDataToDevice WriteDataToDevice
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".WriteDataToDevice") as IWriteDataToDevice;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the get device function in focus.
        /// </summary>
        public static IGetDeviceFunctionInFocus GetDeviceFunctionInFocus
        {
            get
            {
                var instance = LoaderHelper.CreateInstance(ExecutionDirectory, NamespaceHostApplication + ".GetDeviceFunctionInFocus") as IGetDeviceFunctionInFocus;
                if (instance == null)
                {
                    throw new Exception(LogInfo.Namespace(MethodBase.GetCurrentMethod()) + ". The interface implementation for the current method is invalid");
                }

                return instance;
            }
        }

        #endregion
    }
}