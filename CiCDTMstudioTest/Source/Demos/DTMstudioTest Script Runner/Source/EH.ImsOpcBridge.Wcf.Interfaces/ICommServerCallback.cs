// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommServerCallback.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   WCF Callback interface for callbacks from the server to the client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Wcf.Interfaces
{
    using System;
    using System.ServiceModel;

    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Interface ICommServerCallback
    /// </summary>
    [ServiceContract(Namespace = "EH.ImsOpcBridge.Wcf.Interfaces")]
    public interface ICommServerCallback
    {
        #region Public Methods and Operators

        /// <summary>
        /// Called when [export configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        [OperationContract(IsOneWay = true)]
        void OnExportConfigurationResponse(Guid invokeId, uint error, string errorMessage);

        /// <summary>
        /// Called when [import configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        [OperationContract(IsOneWay = true)]
        void OnImportConfigurationResponse(Guid invokeId, Configuration configuration, uint error, string errorMessage);

        /// <summary>
        /// Called when [load configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        [OperationContract(IsOneWay = true)]
        void OnLoadConfigurationResponse(Guid invokeId, Configuration configuration, uint error, string errorMessage);

        /// <summary>
        /// Called when [read local opc servers response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="opcServers">The opc servers.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        [OperationContract(IsOneWay = true)]
        void OnReadLocalOpcServersResponse(Guid invokeId, OpcServerItems opcServers, uint error, string errorMessage);

        /// <summary>
        /// Called when [read opc address space response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="addressSpace">The address space.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        [OperationContract(IsOneWay = true)]
        void OnReadOpcAddressSpaceResponse(Guid invokeId, OpcItem addressSpace, uint error, string errorMessage);

        /// <summary>
        /// Called when [runtime measurements indication].
        /// </summary>
        /// <param name="measurements">The measurements.</param>
        [OperationContract(IsOneWay = true)]
        void OnRuntimeMeasurementsIndication(RuntimeMeasurements measurements);

        /// <summary>
        /// Called when [save configuration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        [OperationContract(IsOneWay = true)]
        void OnSaveConfigurationResponse(Guid invokeId, uint error, string errorMessage);

        /// <summary>
        /// Called when [start monitor response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        [OperationContract(IsOneWay = true)]
        void OnStartMonitorResponse(Guid invokeId, uint error, string errorMessage);

        /// <summary>
        /// Called when [stop monitor response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        [OperationContract(IsOneWay = true)]
        void OnStopMonitorResponse(Guid invokeId, uint error, string errorMessage);

        /// <summary>
        /// Called when [diagnostics response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        [OperationContract(IsOneWay = true)]
        void OnDiagnosticsResponse(Guid invokeId, DiagnosticsMessages diagnosticsMessages, uint error, string errorMessage);

        /// <summary>
        /// Called when [FIS registration response].
        /// </summary>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="error">The error.</param>
        /// <param name="errorMessage">The error message.</param>
        [OperationContract(IsOneWay = true)]
        void OnFisRegistrationResponse(Guid invokeId, uint error, string errorMessage);

        /// <summary>
        /// Called when [diagnostics indication].
        /// </summary>
        /// <param name="diagnosticsMessages">The diagnostics messages.</param>
        [OperationContract(IsOneWay = true)]
        void OnDiagnosticsIndication(DiagnosticsMessages diagnosticsMessages);

        #endregion
    }
}