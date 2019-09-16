// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterTypes.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The parameter types corresponding to the extra messages in the message structure.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Common.Queue
{
    /// <summary>
    /// The parameter types corresponding to the extra messages in the message structure.
    /// </summary>
    public enum ParameterTypes : int
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        Configuration, 

        /// <summary>
        /// The file name.
        /// </summary>
        FileName, 

        /// <summary>
        /// The server name.
        /// </summary>
        ServerName,

        /// <summary>
        /// The configured measurements.
        /// </summary>
        ConfiguredMeasurements,

        /// <summary>
        /// The diagnostics.
        /// </summary>
        Diagnostics,

        /// <summary>
        /// The FIS HTTP response.
        /// </summary>
        FisHttpResponse,

        /// <summary>
        /// The opc da item changed type.
        /// </summary>
        OpcDaItemChangedEventArgs,
    }
}