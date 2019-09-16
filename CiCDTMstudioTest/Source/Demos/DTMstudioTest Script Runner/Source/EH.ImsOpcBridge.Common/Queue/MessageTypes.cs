// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageTypes.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The message types corresponding to the WCF calls.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Common.Queue
{
    /// <summary>
    /// Enum MessageTypes
    /// </summary>
    public enum MessageTypes : int
    {
        /// <summary>
        /// The load configuration request
        /// </summary>
        LoadConfigurationRequest,

        /// <summary>
        /// The save configuration request
        /// </summary>
        SaveConfigurationRequest,

        /// <summary>
        /// The import configuration request
        /// </summary>
        ImportConfigurationRequest,

        /// <summary>
        /// The export configuration request
        /// </summary>
        ExportConfigurationRequest,

        /// <summary>
        /// The read local opc servers request
        /// </summary>
        ReadLocalOpcServersRequest,

        /// <summary>
        /// The read opc address space request
        /// </summary>
        ReadOpcAddressSpaceRequest,

        /// <summary>
        /// The start monitor request
        /// </summary>
        StartMonitorRequest,

        /// <summary>
        /// The stop monitor request
        /// </summary>
        StopMonitorRequest,

        /// <summary>
        /// The data request from SupplyCare Enterprise
        /// </summary>
        SceDataRequest,

        /// <summary>
        /// The diagnostics request from the agent
        /// </summary>
        DiagnosticsRequest,

        /// <summary>
        /// The FIS registration request
        /// </summary>
        FisRegistrationRequest,

        /// <summary>
        /// The FIS registration response
        /// </summary>
        FisRegistrationResponse,

        /// <summary>
        /// The client start indication
        /// </summary>
        ClientStartIndication,

        /// <summary>
        /// The client stop indication
        /// </summary>
        ClientStopIndication,

        /// <summary>
        /// The diagnostics indication
        /// </summary>
        DiagnosticsIndication,

        /// <summary>
        /// The monitor item changed indication
        /// </summary>
        OnMonitoredItemChangedIndication,
    }
}