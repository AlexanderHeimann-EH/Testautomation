// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommServerCallback.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the WCF communication server callback.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Wcf.Test.Wcf
{
    using System;
    using System.ServiceModel;

    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Wcf.Interfaces;

    /// <summary>
    /// Class CommServerCallback
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public class CommServerCallback : ICommServerCallback
    {
        #region Explicit Interface Methods

        /// <summary>
        /// Called when [diagnostics indication].
        /// </summary>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        void ICommServerCallback.OnDiagnosticsIndication(DiagnosticsMessages diagnosticsMessages)
        {
            this.OnDiagnosticsIndication(diagnosticsMessages);
        }

        /// <summary>
        /// Called when [diagnostics response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        void ICommServerCallback.OnDiagnosticsResponse(Guid invokeId, DiagnosticsMessages diagnosticsMessages, uint error, string errorMessage)
        {
            this.OnDiagnosticsResponse(invokeId, diagnosticsMessages, error, errorMessage);
        }

        /// <summary>
        /// Called when [export configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        void ICommServerCallback.OnExportConfigurationResponse(Guid invokeId, uint error, string errorMessage)
        {
            this.OnExportConfigurationResponse(invokeId, error, errorMessage);
        }

        /// <summary>
        /// Called when [FIS registration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        void ICommServerCallback.OnFisRegistrationResponse(Guid invokeId, uint error, string errorMessage)
        {
            this.OnFisRegistrationResponse(invokeId, error, errorMessage);
        }

        /// <summary>
        /// Called when [import configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        void ICommServerCallback.OnImportConfigurationResponse(Guid invokeId, Configuration configuration, uint error, string errorMessage)
        {
            this.OnImportConfigurationResponse(invokeId, configuration, error, errorMessage);
        }

        /// <summary>
        /// Called when [load configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        void ICommServerCallback.OnLoadConfigurationResponse(Guid invokeId, Configuration configuration, uint error, string errorMessage)
        {
            this.OnLoadConfigurationResponse(invokeId, configuration, error, errorMessage);
        }

        /// <summary>
        /// Called when [read local opc servers response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="opcServers">The opc servers.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        void ICommServerCallback.OnReadLocalOpcServersResponse(Guid invokeId, OpcServerItems opcServers, uint error, string errorMessage)
        {
            this.OnReadLocalOpcServersResponse(invokeId, opcServers, error, errorMessage);
        }

        /// <summary>
        /// Called when [read opc address space response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="addressSpace">The address space.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        void ICommServerCallback.OnReadOpcAddressSpaceResponse(Guid invokeId, OpcItem addressSpace, uint error, string errorMessage)
        {
            this.OnReadOpcAddressSpaceResponse(invokeId, addressSpace, error, errorMessage);
        }

        /// <summary>
        /// Called when [runtime measurements indication].
        /// </summary>
        /// <param name="measurements">The measurements.</param>
        void ICommServerCallback.OnRuntimeMeasurementsIndication(RuntimeMeasurements measurements)
        {
            this.OnRuntimeMeasurementsIndication(measurements);
        }

        /// <summary>
        /// Called when [save configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        void ICommServerCallback.OnSaveConfigurationResponse(Guid invokeId, uint error, string errorMessage)
        {
            this.OnSaveConfigurationResponse(invokeId, error, errorMessage);
        }

        /// <summary>
        /// Called when [start monitor response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        void ICommServerCallback.OnStartMonitorResponse(Guid invokeId, uint error, string errorMessage)
        {
            this.OnStartMonitorResponse(invokeId, error, errorMessage);
        }

        /// <summary>
        /// Called when [stop monitor response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        void ICommServerCallback.OnStopMonitorResponse(Guid invokeId, uint error, string errorMessage)
        {
            this.OnStopMonitorResponse(invokeId, error, errorMessage);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when [diagnostics indication].
        /// </summary>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        protected void OnDiagnosticsIndication(DiagnosticsMessages diagnosticsMessages)
        {
        }

        /// <summary>
        /// Called when [diagnostics response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        protected void OnDiagnosticsResponse(Guid invokeId, DiagnosticsMessages diagnosticsMessages, uint error, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}, error: {2}, errorMessage: {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, invokeId.ToString(), error, errorMessage == null ? "(null)" : errorMessage));
        }

        /// <summary>
        /// Called when [export configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        protected void OnExportConfigurationResponse(Guid invokeId, uint error, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}, error: {2}, errorMessage: {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, invokeId.ToString(), error, errorMessage == null ? "(null)" : errorMessage));
        }

        /// <summary>
        /// Called when [FIS registration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        protected void OnFisRegistrationResponse(Guid invokeId, uint error, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}, error: {2}, errorMessage: {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, invokeId.ToString(), error, errorMessage == null ? "(null)" : errorMessage));
        }

        /// <summary>
        /// Called when [import configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        protected void OnImportConfigurationResponse(Guid invokeId, Configuration configuration, uint error, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}, error: {2}, errorMessage: {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, invokeId.ToString(), error, errorMessage == null ? "(null)" : errorMessage));
        }

        /// <summary>
        /// Called when [load configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        protected void OnLoadConfigurationResponse(Guid invokeId, Configuration configuration, uint error, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}, error: {2}, errorMessage: {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, invokeId.ToString(), error, errorMessage == null ? "(null)" : errorMessage));
        }

        /// <summary>
        /// Called when [read local opc servers response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="opcServers">The opc servers.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        protected void OnReadLocalOpcServersResponse(Guid invokeId, OpcServerItems opcServers, uint error, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}, error: {2}, errorMessage: {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, invokeId.ToString(), error, errorMessage == null ? "(null)" : errorMessage));
        }

        /// <summary>
        /// Called when [read opc address space response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="addressSpace">The address space.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        protected void OnReadOpcAddressSpaceResponse(Guid invokeId, OpcItem addressSpace, uint error, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}, error: {2}, errorMessage: {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, invokeId.ToString(), error, errorMessage == null ? "(null)" : errorMessage));
        }

        /// <summary>
        /// Called when [runtime measurements indication].
        /// </summary>
        /// <param name="measurements">The measurements.</param>
        protected void OnRuntimeMeasurementsIndication(RuntimeMeasurements measurements)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name));

            foreach (var item in measurements)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Measurement - RequestIndex: {0}, DeviceId: {1}, SensorId: {2}, Unit: {3}, DataType: {4}, Timestamp: {5}, Quality: {6}, Value: {7} ", item.RequestIndex, item.DeviceId, item.SensorId, item.Unit, item.DataType, item.Timestamp, item.Quality, item.Value));
            }
        }

        /// <summary>
        /// Called when [save configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        protected void OnSaveConfigurationResponse(Guid invokeId, uint error, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}, error: {2}, errorMessage: {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, invokeId.ToString(), error, errorMessage == null ? "(null)" : errorMessage));
        }

        /// <summary>
        /// Called when [start monitor response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        protected void OnStartMonitorResponse(Guid invokeId, uint error, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}, error: {2}, errorMessage: {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, invokeId.ToString(), error, errorMessage == null ? "(null)" : errorMessage));
        }

        /// <summary>
        /// Called when [stop monitor response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        protected void OnStopMonitorResponse(Guid invokeId, uint error, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}, error: {2}, errorMessage: {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, invokeId.ToString(), error, errorMessage == null ? "(null)" : errorMessage));
        }

        #endregion
    }
}