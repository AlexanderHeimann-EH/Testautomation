// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosticsDataEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The server data event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.EventArguments
{
    using System;

    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// The diagnostics data event args.
    /// </summary>
    public class DiagnosticsDataEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticsDataEventArgs"/> class.
        /// </summary>
        /// <param name="diagnosticsMessages">
        /// The diagnostics messages.
        /// </param>
        public DiagnosticsDataEventArgs(DiagnosticsMessages diagnosticsMessages)
        {
            this.DiagnosticsMessages = diagnosticsMessages;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the diagnostics data.
        /// </summary>
        public DiagnosticsMessages DiagnosticsMessages { get; set; }

        #endregion
    }
}