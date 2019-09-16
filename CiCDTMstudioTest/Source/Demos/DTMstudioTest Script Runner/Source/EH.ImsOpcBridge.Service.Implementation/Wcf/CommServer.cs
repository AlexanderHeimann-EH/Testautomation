// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommServer.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the WCF communication server.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Service.Implementation.Wcf
{
    using System;
    using System.Reflection;
    using System.ServiceModel;

    using EH.ImsOpcBridge.Common.Queue;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.Logging;
    using EH.ImsOpcBridge.Wcf.Interfaces;

    /// <summary>
    /// Class CommServer
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public class CommServer : ICommServer
    {
        #region Explicit Interface Methods

        /// <summary>
        /// Diagnostics request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        void ICommServer.DiagnosticsRequest(string callbackEndpointAddress, Guid invokeId)
        {
            this.DiagnosticsRequest(callbackEndpointAddress, invokeId);
        }

        /// <summary>
        /// Exports the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="fileName">Name of the file.</param>
        void ICommServer.ExportConfigurationRequest(string callbackEndpointAddress, Guid invokeId, Configuration configuration, string fileName)
        {
            this.ExportConfigurationRequest(callbackEndpointAddress, invokeId, configuration, fileName);
        }

        /// <summary>
        /// FIS registration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        void ICommServer.FisRegistrationRequest(string callbackEndpointAddress, Guid invokeId)
        {
            this.FisRegistrationRequest(callbackEndpointAddress, invokeId);
        }

        /// <summary>
        /// Imports the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="fileName">Name of the file.</param>
        void ICommServer.ImportConfigurationRequest(string callbackEndpointAddress, Guid invokeId, string fileName)
        {
            this.ImportConfigurationRequest(callbackEndpointAddress, invokeId, fileName);
        }

        /// <summary>
        /// Loads the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        void ICommServer.LoadConfigurationRequest(string callbackEndpointAddress, Guid invokeId)
        {
            this.LoadConfigurationRequest(callbackEndpointAddress, invokeId);
        }

        /// <summary>
        /// Called when [client start indication].
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        void ICommServer.OnClientStartIndication(string callbackEndpointAddress)
        {
            this.OnClientStartIndication(callbackEndpointAddress);
        }

        /// <summary>
        /// Called when [client stop indication].
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        void ICommServer.OnClientStopIndication(string callbackEndpointAddress)
        {
            this.OnClientStopIndication(callbackEndpointAddress);
        }

        /// <summary>
        /// Reads the local opc servers request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        void ICommServer.ReadLocalOpcServersRequest(string callbackEndpointAddress, Guid invokeId)
        {
            this.ReadLocalOpcServersRequest(callbackEndpointAddress, invokeId);
        }

        /// <summary>
        /// Reads the opc address space request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="serverName">Name of the server.</param>
        void ICommServer.ReadOpcAddressSpaceRequest(string callbackEndpointAddress, Guid invokeId, string serverName)
        {
            this.ReadOpcAddressSpaceRequest(callbackEndpointAddress, invokeId, serverName);
        }

        /// <summary>
        /// Saves the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        void ICommServer.SaveConfigurationRequest(string callbackEndpointAddress, Guid invokeId, Configuration configuration)
        {
            this.SaveConfigurationRequest(callbackEndpointAddress, invokeId, configuration);
        }

        /// <summary>
        /// Starts the monitor request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuredMeasurements">The configured measurements.</param>
        void ICommServer.StartMonitorRequest(string callbackEndpointAddress, Guid invokeId, ConfiguredMeasurements configuredMeasurements)
        {
            this.StartMonitorRequest(callbackEndpointAddress, invokeId, configuredMeasurements);
        }

        /// <summary>
        /// Stops the monitor request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        void ICommServer.StopMonitorRequest(string callbackEndpointAddress, Guid invokeId)
        {
            this.StopMonitorRequest(callbackEndpointAddress, invokeId);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Diagnostics request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        protected void DiagnosticsRequest(string callbackEndpointAddress, Guid invokeId)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, invokeId, MessageTypes.DiagnosticsRequest);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        /// <summary>
        /// Exports the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="fileName">Name of the file.</param>
        protected void ExportConfigurationRequest(string callbackEndpointAddress, Guid invokeId, Configuration configuration, string fileName)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, invokeId, MessageTypes.ExportConfigurationRequest);
            message.AddParameter(ParameterTypes.Configuration, configuration);
            message.AddParameter(ParameterTypes.FileName, fileName);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        /// <summary>
        /// FIS registration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        protected void FisRegistrationRequest(string callbackEndpointAddress, Guid invokeId)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, invokeId, MessageTypes.FisRegistrationRequest);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        /// <summary>
        /// Imports the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="fileName">Name of the file.</param>
        protected void ImportConfigurationRequest(string callbackEndpointAddress, Guid invokeId, string fileName)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, invokeId, MessageTypes.ImportConfigurationRequest);
            message.AddParameter(ParameterTypes.FileName, fileName);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        /// <summary>
        /// Loads the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        protected void LoadConfigurationRequest(string callbackEndpointAddress, Guid invokeId)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, invokeId, MessageTypes.LoadConfigurationRequest);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        /// <summary>
        /// Called when [client start indication].
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        protected void OnClientStartIndication(string callbackEndpointAddress)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, Guid.Empty, MessageTypes.ClientStartIndication);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        /// <summary>
        /// Called when [client stop indication].
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        protected void OnClientStopIndication(string callbackEndpointAddress)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, Guid.Empty, MessageTypes.ClientStopIndication);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        /// <summary>
        /// Reads the local opc servers request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        protected void ReadLocalOpcServersRequest(string callbackEndpointAddress, Guid invokeId)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, invokeId, MessageTypes.ReadLocalOpcServersRequest);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        /// <summary>
        /// Reads the opc address space request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="serverName">Name of the server.</param>
        protected void ReadOpcAddressSpaceRequest(string callbackEndpointAddress, Guid invokeId, string serverName)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, invokeId, MessageTypes.ReadOpcAddressSpaceRequest);
            message.AddParameter(ParameterTypes.ServerName, serverName);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        /// <summary>
        /// Saves the configuration request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuration">The configuration.</param>
        protected void SaveConfigurationRequest(string callbackEndpointAddress, Guid invokeId, Configuration configuration)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, invokeId, MessageTypes.SaveConfigurationRequest);
            message.AddParameter(ParameterTypes.Configuration, configuration);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        /// <summary>
        /// Starts the monitor request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="configuredMeasurements">The configured measurements.</param>
        protected void StartMonitorRequest(string callbackEndpointAddress, Guid invokeId, ConfiguredMeasurements configuredMeasurements)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, invokeId, MessageTypes.StartMonitorRequest);
            message.AddParameter(ParameterTypes.ConfiguredMeasurements, configuredMeasurements);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        /// <summary>
        /// Stops the monitor request.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        protected void StopMonitorRequest(string callbackEndpointAddress, Guid invokeId)
        {
            Logger.Debug(this, MethodBase.GetCurrentMethod().Name + " called");

            // Create message.
            var message = new Message(callbackEndpointAddress, invokeId, MessageTypes.StopMonitorRequest);

            // Enqueue message.
            MessageQueue.Instance.Enqueue(message);
        }

        #endregion
    }
}