// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfiguratorHost.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The default implementation for callbacks from FDT container to the hosting application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.DefaultHost
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using System.Windows;

    using EH.ImsOpcBridge.Common.Data;
    using EH.ImsOpcBridge.Configurator.Interfaces;
    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.Configurator.ViewModel;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.DefaultHost;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.Wcf.Interfaces;

    using log4net;

    using Microsoft.Win32;

    /// <summary>
    /// Class ConfiguratorHost
    /// </summary>
    [CLSCompliant(false)]
    public class ConfiguratorHost : IConfiguratorHost, ICommServerCallback
    {
        #region Static Fields

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        /// <summary>
        /// The base host
        /// </summary>
        private readonly IBaseHost baseHost;

        /// <summary>
        /// The command line dictionary
        /// </summary>
        private readonly Dictionary<string, string> commandLineDictionary = new Dictionary<string, string>();

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfiguratorHost"/> class.
        /// </summary>
        public ConfiguratorHost()
        {
            this.baseHost = new BaseHost();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ConfiguratorHost"/> class.
        /// </summary>
        ~ConfiguratorHost()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets all command line keys.
        /// </summary>
        /// <value>All command line keys.</value>
        public string[] AllCommandLineKeys
        {
            get
            {
                lock (this.commandLineDictionary)
                {
                    var keys = new string[this.commandLineDictionary.Keys.Count];
                    this.commandLineDictionary.Keys.CopyTo(keys, 0);
                    return keys;
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the application, which is hosting the ImsOpcBridge.
        /// </summary>
        /// <value>The name of the application.</value>
        public string ApplicationName
        {
            get
            {
                return this.baseHost.ApplicationName;
            }

            set
            {
                this.baseHost.ApplicationName = value;
            }
        }

        /// <summary>
        /// Gets or sets the communication retries.
        /// </summary>
        /// <value>The communication retries.</value>
        public int CommunicationRetries { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the host is a service.
        /// </summary>
        /// <value><c>true</c> if this instance is service; otherwise, <c>false</c>.</value>
        public bool IsService
        {
            get
            {
                return this.baseHost.IsService;
            }

            set
            {
                this.baseHost.IsService = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the manufacturer of the application, which is hosting
        /// the ImsOpcBridge FDT module.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer
        {
            get
            {
                return this.baseHost.Manufacturer;
            }

            set
            {
                this.baseHost.Manufacturer = value;
            }
        }

        /// <summary>
        /// Gets or sets the progress handler.
        /// </summary>
        /// <value>The progress handler.</value>
        public IProgressHandler ProgressHandler
        {
            get
            {
                return this.baseHost.ProgressHandler;
            }

            set
            {
                this.baseHost.ProgressHandler = value;
            }
        }

        /// <summary>
        /// Gets or sets the service reference. Set this reference, when the host is a windows service.
        /// </summary>
        /// <value>The service reference.</value>
        public IService Service
        {
            get
            {
                return this.baseHost.Service;
            }

            set
            {
                this.baseHost.Service = value;
            }
        }

        /// <summary>
        /// Gets or sets the task handler.
        /// </summary>
        /// <value>The task handler.</value>
        public ITaskHandler TaskHandler
        {
            get
            {
                return this.baseHost.TaskHandler;
            }

            set
            {
                this.baseHost.TaskHandler = value;
            }
        }

        /// <summary>
        /// Gets or sets the handler for user interface callbacks to the hosting application.
        /// </summary>
        /// <value>The handler for user interface callbacks to the hosting application.</value>
        public IUIHost UserInterface
        {
            get
            {
                return this.baseHost.UserInterface;
            }

            set
            {
                this.baseHost.UserInterface = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public Version Version { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates a registry monitor.
        /// </summary>
        /// <param name="registryHive">The registry Hive.</param>
        /// <param name="subkey">The sub key.</param>
        /// <returns>The registry monitor.</returns>
        public IRegistryMonitor CreateRegistryMonitor(RegistryHive registryHive, string subkey)
        {
            return this.baseHost.CreateRegistryMonitor(registryHive, subkey);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets the command line value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System String.</returns>
        public string GetCommandLineValue(string key)
        {
            lock (this.commandLineDictionary)
            {
                string foundKey = null;

                foreach (var existingKey in this.commandLineDictionary.Keys)
                {
                    if (string.Compare(key, existingKey, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        foundKey = existingKey;
                    }
                }

                if (foundKey != null)
                {
                    return this.commandLineDictionary[foundKey];
                }

                return null;
            }
        }

        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="serviceDataReceiver">The service data receiver.</param>
        /// <param name="currentMethodName">Name of the current method.</param>
        public void HandleError(Guid invokeId, uint error, string errorMessage, ServiceDataReceiver serviceDataReceiver, string currentMethodName)
        {
            if (serviceDataReceiver != null)
            {
                if (error != ResultCodes.Success)
                {
                    var errorNumberMessage = this.GetErrorMessage(error);

                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        // errorMessage = errorNumberMessage + @" " + Resources.SystemError + @": " + errorMessage;
                        errorMessage = errorNumberMessage;
                    }
                    else
                    {
                        errorMessage = errorNumberMessage;
                    }

                    if (Logger.IsDebugEnabled)
                    {
                        string message = string.Format(CultureInfo.CurrentCulture, @"{0}: {1}, Error Number: {2}, Error Message: {3}", currentMethodName, invokeId.ToString(), error, errorMessage);
                        string logMessage = string.Format(CultureInfo.CurrentCulture, @"'{0}'", message);
                        Logger.Debug(logMessage);
                    }

                    // serviceDataReceiver.ServiceErrorResponseCompleted(string.Format("{0}: {1}, Error Number: {2}, Error Message: {3}", currentMethodName, invokeId.ToString(), error, errorMessage));
                    // serviceDataReceiver.ServiceErrorResponseCompleted(string.Format("{0}: Error Number: {1} Error Message: {2}", currentMethodName, error, errorMessage));
                    serviceDataReceiver.ServiceErrorResponseCompleted(string.Format(CultureInfo.CurrentCulture, @"{0}", errorMessage));
                }
            }
        }

        /// <summary>
        /// Called when [diagnostics indication].
        /// </summary>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        public void OnDiagnosticsIndication(DiagnosticsMessages diagnosticsMessages)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                // emilio temp
                // see whether we need here an indication handler.
                serviceDataReceiver.DiagnosticsIndicationResponseCompleted(diagnosticsMessages);
            }
        }

        /// <summary>
        /// Called when [diagnostics response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        public void OnDiagnosticsResponse(Guid invokeId, DiagnosticsMessages diagnosticsMessages, uint error, string errorMessage)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                this.HandleError(invokeId, error, errorMessage, serviceDataReceiver, currentMethodName);

                if (error == ResultCodes.Success)
                {
                    serviceDataReceiver.DiagnosticsResponseCompleted(diagnosticsMessages);
                }
            }
        }

        /// <summary>
        /// Called when [export configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        public void OnExportConfigurationResponse(Guid invokeId, uint error, string errorMessage)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                this.HandleError(invokeId, error, errorMessage, serviceDataReceiver, currentMethodName);
            }
        }

        /// <summary>
        /// Called when [FIS registration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        public void OnFisRegistrationResponse(Guid invokeId, uint error, string errorMessage)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                this.HandleError(invokeId, error, errorMessage, serviceDataReceiver, currentMethodName);

                if (error == ResultCodes.Success)
                {
                    serviceDataReceiver.FisRegistrationResponseCompleted();
                }
            }
        }

        /// <summary>
        /// Called when [import configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        public void OnImportConfigurationResponse(Guid invokeId, Configuration configuration, uint error, string errorMessage)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                this.HandleError(invokeId, error, errorMessage, serviceDataReceiver, currentMethodName);

                if (error == ResultCodes.Success)
                {
                    serviceDataReceiver.LoadConfigurationResponseCompleted(configuration);
                }
            }
        }

        /// <summary>
        /// Called when [load configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        public void OnLoadConfigurationResponse(Guid invokeId, Configuration configuration, uint error, string errorMessage)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                this.HandleError(invokeId, error, errorMessage, serviceDataReceiver, currentMethodName);

                if (error == ResultCodes.Success)
                {
                    serviceDataReceiver.LoadConfigurationResponseCompleted(configuration);
                }
            }
        }

        /// <summary>
        /// Called when [read local opc servers response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="opcServers">The opc servers.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        public void OnReadLocalOpcServersResponse(Guid invokeId, OpcServerItems opcServers, uint error, string errorMessage)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                this.HandleError(invokeId, error, errorMessage, serviceDataReceiver, currentMethodName);

                if (error == ResultCodes.Success)
                {
                    serviceDataReceiver.OpcServersResponseCompleted(opcServers);
                }
            }
        }

        /// <summary>
        /// Called when [read opc address space response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="addressSpace">The address space.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        public void OnReadOpcAddressSpaceResponse(Guid invokeId, OpcItem addressSpace, uint error, string errorMessage)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                this.HandleError(invokeId, error, errorMessage, serviceDataReceiver, currentMethodName);

                if (error == ResultCodes.Success)
                {
                    serviceDataReceiver.ReadOpcAddressSpaceResponseCompleted(addressSpace);
                }
            }
        }

        /// <summary>
        /// Called when [runtime measurements indication].
        /// </summary>
        /// <param name="measurements">The measurements.</param>
        public void OnRuntimeMeasurementsIndication(RuntimeMeasurements measurements)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                serviceDataReceiver.RuntimeMeasurementsCompleted(measurements);
            }
        }

        /// <summary>
        /// Called when [save configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        public void OnSaveConfigurationResponse(Guid invokeId, uint error, string errorMessage)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                this.HandleError(invokeId, error, errorMessage, serviceDataReceiver, currentMethodName);

                if (error == ResultCodes.Success)
                {
                    serviceDataReceiver.SaveConfigurationResponseCompleted();
                }
            }
        }

        /// <summary>
        /// Called when [start monitor response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        public void OnStartMonitorResponse(Guid invokeId, uint error, string errorMessage)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                this.HandleError(invokeId, error, errorMessage, serviceDataReceiver, currentMethodName);
            }
        }

        /// <summary>
        /// Called when [stop monitor response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        public void OnStopMonitorResponse(Guid invokeId, uint error, string errorMessage)
        {
            var serviceDataReceiver = this.GetServiceDataReceiver();
            if (serviceDataReceiver != null)
            {
                var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                this.HandleError(invokeId, error, errorMessage, serviceDataReceiver, currentMethodName);
            }
        }

        /// <summary>
        /// Sets the command line value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetCommandLineValue(string key, string value)
        {
            lock (this.commandLineDictionary)
            {
                string foundKey = null;

                foreach (var existingKey in this.commandLineDictionary.Keys)
                {
                    if (string.Compare(key, existingKey, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        foundKey = existingKey;
                    }
                }

                if (foundKey != null)
                {
                    this.commandLineDictionary[foundKey] = value;
                }
                else
                {
                    this.commandLineDictionary.Add(key, value);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                }

                this.baseHost.Dispose();

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns>System String.</returns>
        private string GetErrorMessage(uint error)
        {
            string errorMessage;

            switch (error)
            {
                case ResultCodes.Success:
                    errorMessage = Resources.Success;
                    break;
                case ResultCodes.CreateAppDataFolderError:
                    errorMessage = Resources.CreateAppDataFolderError;
                    break;
                case ResultCodes.DeserializeError:
                    errorMessage = Resources.DeserializeError;
                    break;
                case ResultCodes.ExportDenied:
                    errorMessage = Resources.ExportDenied;
                    break;
                case ResultCodes.MissingArgument:
                    errorMessage = Resources.MissingArgument;
                    break;
                case ResultCodes.SerializeError:
                    errorMessage = Resources.SerializeError;
                    break;
                case ResultCodes.CannotConnectOpcServer:
                    errorMessage = Resources.CannotConnectOpcServer;
                    break;
                case ResultCodes.MonitorAlreadyRunning:
                    errorMessage = Resources.MonitorAlreadyRunning;
                    break;
                case ResultCodes.MonitorNotRunning:
                    errorMessage = Resources.MonitorNotRunning;
                    break;
                case ResultCodes.CannotBrowseOpcServers:
                    errorMessage = Resources.CannotBrowseOpcServers;
                    break;
                case ResultCodes.BrowseAddressSpaceError:
                    errorMessage = Resources.ErrorWhileBrowsingAddressSpace;
                    break;
                case ResultCodes.CannotRegisterFis:
                    errorMessage = Resources.CannotRegisterFis;
                    break;
                case ResultCodes.InvalidGateway:
                    errorMessage = Resources.CannotStartMonitor;
                    break;
                default:
                    errorMessage = Resources.ErrorMessageNotImplemented;
                    break;
            }

            return errorMessage;
        }

        /// <summary>
        /// Gets the service data receiver.
        /// </summary>
        /// <returns>Returns ServiceDataReceiver.</returns>
        private ServiceDataReceiver GetServiceDataReceiver()
        {
            ServiceDataReceiver serviceDataReceiver = null;

            var mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null)
            {
                var mainViewModel = mainWindow.DataContext as MainWindowVm;

                if (mainViewModel != null)
                {
                    serviceDataReceiver = mainViewModel.ServiceDataReceiver;
                }
            }

            return serviceDataReceiver;
        }

        #endregion
    }
}