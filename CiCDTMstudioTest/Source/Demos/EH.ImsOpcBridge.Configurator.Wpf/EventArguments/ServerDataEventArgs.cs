// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerDataEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The server data event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.EventArguments
{
    using System;
    using System.Collections.Generic;

    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// The server data event args.
    /// </summary>
    public class ServerDataEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerDataEventArgs"/> class.
        /// </summary>
        /// <param name="opcServerItems">
        /// The opc server items.
        /// </param>
        public ServerDataEventArgs(List<OpcServerItem> opcServerItems)
        {
            this.OpcServerItems = opcServerItems;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the opc server items.
        /// </summary>
        public List<OpcServerItem> OpcServerItems { get; set; }

        #endregion
    }
}