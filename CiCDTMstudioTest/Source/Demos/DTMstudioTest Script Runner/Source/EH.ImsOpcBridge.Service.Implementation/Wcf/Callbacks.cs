// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Callbacks.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the callbacks.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Service.Implementation.Wcf
{
    using System;
    using System.Reflection;

    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.Logging;

    /// <summary>
    /// Class Callbacks
    /// </summary>
    internal static class Callbacks
    {
        #region Public Methods and Operators

        /// <summary>
        /// Called when [export configuration response].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnExportConfigurationResponse(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");
                
                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var invokeId = (Guid)args[2];
                var error = (uint)args[3];
                var exception = (Exception)args[4];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnExportConfigurationResponse(invokeId, error, exception == null ? string.Empty : exception.Message);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        /// <summary>
        /// Called when [import configuration response].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnImportConfigurationResponse(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");

                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var invokeId = (Guid)args[2];
                var configuration = (Configuration)args[3];
                var error = (uint)args[4];
                var exception = (Exception)args[5];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnImportConfigurationResponse(invokeId, configuration, error, exception == null ? string.Empty : exception.Message);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        /// <summary>
        /// Called when [load configuration response].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnLoadConfigurationResponse(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");

                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var invokeId = (Guid)args[2];
                var configuration = (Configuration)args[3];
                var error = (uint)args[4];
                var exception = (Exception)args[5];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnLoadConfigurationResponse(invokeId, configuration, error, exception == null ? string.Empty : exception.Message);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        /// <summary>
        /// Called when [read local opc servers response].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnReadLocalOpcServersResponse(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");

                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var invokeId = (Guid)args[2];
                var opcServers = (OpcServerItems)args[3];
                var error = (uint)args[4];
                var exception = (Exception)args[5];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnReadLocalOpcServersResponse(invokeId, opcServers, error, exception == null ? string.Empty : exception.Message);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        /// <summary>
        /// Called when [read opc address space response].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnReadOpcAddressSpaceResponse(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");

                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var invokeId = (Guid)args[2];
                var opcItem = (OpcItem)args[3];
                var error = (uint)args[4];
                var exception = (Exception)args[5];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnReadOpcAddressSpaceResponse(invokeId, opcItem, error, exception == null ? string.Empty : exception.Message);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        /// <summary>
        /// Called when [runtime measurements indication].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnRuntimeMeasurementsIndication(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");

                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var runtimeMeasurements = (RuntimeMeasurements)args[2];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnRuntimeMeasurementsIndication(runtimeMeasurements);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        /// <summary>
        /// Called when [save configuration response].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnSaveConfigurationResponse(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");

                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var invokeId = (Guid)args[2];
                var error = (uint)args[3];
                var exception = (Exception)args[4];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnSaveConfigurationResponse(invokeId, error, exception == null ? string.Empty : exception.Message);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        /// <summary>
        /// Called when [start monitor response].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnStartMonitorResponse(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");

                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var invokeId = (Guid)args[2];
                var error = (uint)args[3];
                var exception = (Exception)args[4];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnStartMonitorResponse(invokeId, error, exception == null ? string.Empty : exception.Message);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        /// <summary>
        /// Called when [stop monitor response].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnStopMonitorResponse(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");

                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var invokeId = (Guid)args[2];
                var error = (uint)args[3];
                var exception = (Exception)args[4];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnStopMonitorResponse(invokeId, error, exception == null ? string.Empty : exception.Message);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        /// <summary>
        /// Called when [diagnostics response].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnDiagnosticsResponse(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");

                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var invokeId = (Guid)args[2];
                var diagnosticsMessages = (DiagnosticsMessages)args[3];
                var error = (uint)args[4];
                var exception = (Exception)args[5];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnDiagnosticsResponse(invokeId, diagnosticsMessages, error, exception == null ? string.Empty : exception.Message);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        /// <summary>
        /// Called when [FIS registration response].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnFisRegistrationResponse(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");

                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var invokeId = (Guid)args[2];
                var error = (uint)args[3];
                var exception = (Exception)args[4];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnFisRegistrationResponse(invokeId, error, exception == null ? string.Empty : exception.Message);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        /// <summary>
        /// Called when [diagnostics indication].
        /// </summary>
        /// <param name="state">The state.</param>
        public static void OnDiagnosticsIndication(object state)
        {
            try
            {
                Logger.Debug(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name + " called");

                var args = (object[])state;
                var clientEndPointName = (string)args[0];
                var callbackEndpointAddress = (string)args[1];
                var diagnosticsMessages = (DiagnosticsMessages)args[2];

                var client = new CommServerCallbackClient(clientEndPointName, callbackEndpointAddress);
                client.OnDiagnosticsIndication(diagnosticsMessages);
                client.Close();
            }
            catch (Exception exception)
            {
                // Just log it.
                Logger.FatalException(typeof(Callbacks).Name, MethodBase.GetCurrentMethod().Name, exception);
            }
        }

        #endregion
    }
}