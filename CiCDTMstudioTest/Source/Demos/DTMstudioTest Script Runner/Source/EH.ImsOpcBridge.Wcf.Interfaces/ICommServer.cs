// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommServer.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   WCF interface of the SFG500 Comm Server.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Wcf.Interfaces
{
    using System;
    using System.ServiceModel;

    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Interface ICommServer
    /// </summary>
    [ServiceContract(Namespace = "EH.ImsOpcBridge.Wcf.Interfaces")]
    public interface ICommServer
    {
        #region Public Methods and Operators

        /// <summary>
        /// Exports the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="fileName">Name of the file.</param>
        [OperationContract(IsOneWay = true)]
        void ExportConfigurationRequest(string callbackEndpointAddress, Guid invokeId, Configuration configuration, string fileName);

        /// <summary>
        /// Imports the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="fileName">Name of the file.</param>
        [OperationContract(IsOneWay = true)]
        void ImportConfigurationRequest(string callbackEndpointAddress, Guid invokeId, string fileName);

        /// <summary>
        /// Loads the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        [OperationContract(IsOneWay = true)]
        void LoadConfigurationRequest(string callbackEndpointAddress, Guid invokeId);

        /// <summary>
        /// Reads the local opc servers request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        [OperationContract(IsOneWay = true)]
        void ReadLocalOpcServersRequest(string callbackEndpointAddress, Guid invokeId);

        /// <summary>
        /// Reads the opc address space request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="serverName">Name of the server.</param>
        [OperationContract(IsOneWay = true)]
        void ReadOpcAddressSpaceRequest(string callbackEndpointAddress, Guid invokeId, string serverName);

        /// <summary>
        /// Saves the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        [OperationContract(IsOneWay = true)]
        void SaveConfigurationRequest(string callbackEndpointAddress, Guid invokeId, Configuration configuration);

        /// <summary>
        /// Starts the monitor request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuredMeasurements">The configured measurements.</param>
        [OperationContract(IsOneWay = true)]
        void StartMonitorRequest(string callbackEndpointAddress, Guid invokeId, ConfiguredMeasurements configuredMeasurements);

        /// <summary>
        /// Stops the monitor request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        [OperationContract(IsOneWay = true)]
        void StopMonitorRequest(string callbackEndpointAddress, Guid invokeId);

        /// <summary>
        /// Diagnostics request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        [OperationContract(IsOneWay = true)]
        void DiagnosticsRequest(string callbackEndpointAddress, Guid invokeId);

        /// <summary>
        /// FIS registration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        [OperationContract(IsOneWay = true)]
        void FisRegistrationRequest(string callbackEndpointAddress, Guid invokeId);

        /// <summary>
        /// Called when [client start indication].
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        [OperationContract(IsOneWay = true)]
        void OnClientStartIndication(string callbackEndpointAddress);

        /// <summary>
        /// Called when [client stop indication].
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        [OperationContract(IsOneWay = true)]
        void OnClientStopIndication(string callbackEndpointAddress);

        #endregion
    }
}