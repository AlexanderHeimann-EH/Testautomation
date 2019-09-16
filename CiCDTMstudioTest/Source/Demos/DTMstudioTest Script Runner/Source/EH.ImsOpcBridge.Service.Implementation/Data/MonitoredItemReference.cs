// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonitoredItemReference.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the monitored item creator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.Data
{
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.Enumerations;

    /// <summary>
    /// Struct MonitoredItemReference
    /// </summary>
    public struct MonitoredItemReference
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MonitoredItemReference"/> struct.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="fieldType">Type of the field.</param>
        /// <param name="mappingType">Type of the mapping.</param>
        public MonitoredItemReference(int index, FieldTypes fieldType, MappingTypes mappingType)
            : this()
        {
            this.Index = index;
            this.FieldType = fieldType;
            this.MappingType = mappingType;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>The index.</value>
        public int Index { get; private set; }

        /// <summary>
        /// Gets the type of the field.
        /// </summary>
        /// <value>The type of the field.</value>
        public FieldTypes FieldType { get; private set; }

        /// <summary>
        /// Gets the type of the mapping.
        /// </summary>
        /// <value>The type of the mapping.</value>
        public MappingTypes MappingType { get; private set; }

        #endregion
    }
}
