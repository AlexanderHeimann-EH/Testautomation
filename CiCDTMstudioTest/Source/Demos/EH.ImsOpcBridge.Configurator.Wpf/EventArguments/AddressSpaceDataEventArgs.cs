// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressSpaceDataEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class AddressSpaceDataEventArgs
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.EventArguments
{
    using System;

    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Class AddressSpaceDataEventArgs
    /// </summary>
    public class AddressSpaceDataEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressSpaceDataEventArgs"/> class.
        /// </summary>
        /// <param name="addressSpace">The address space.</param>
        public AddressSpaceDataEventArgs(OpcItem addressSpace)
        {
            this.AddressSpace = addressSpace;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the address space.
        /// </summary>
        /// <value>The address space.</value>
        public OpcItem AddressSpace { get; set; }

        #endregion
    }
}