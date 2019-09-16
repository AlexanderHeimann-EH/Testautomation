// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldTypes.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the monitored item creator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.Enumerations
{
    /// <summary>
    /// Define the type of fields that might have OPC values.
    /// </summary>
    public enum FieldTypes
    {
        /// <summary>
        /// The quality
        /// </summary>
        Quality,

        /// <summary>
        /// The timestamp
        /// </summary>
        Timestamp,

        /// <summary>
        /// The unit
        /// </summary>
        Unit,

        /// <summary>
        /// The value
        /// </summary>
        Value,
    }
}
