// ***********************************************************************
// <copyright file="ClientCollection.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.Implementation.Clients
{
    using System;
    using System.Collections.Generic;

    using EH.ImsOpcBridge.Common.Queue;
    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Class ClientCollection. This class cannot be inherited.
    /// </summary>
    public sealed class ClientCollection
    {
        #region Fields

        /// <summary>
        /// The synchronize root
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// The instance
        /// </summary>
        private static volatile ClientCollection instance;

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="ClientCollection"/> class from being created.
        /// </summary>
        private ClientCollection()
        {
            this.ClientUris = new HashSet<string>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static ClientCollection Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ClientCollection();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets or sets the client uris.
        /// </summary>
        /// <value>The messages.</value>
        private HashSet<string> ClientUris { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a client uri.
        /// </summary>
        /// <param name="clientUri">The client uri to add.</param>
        public void AddClientUri(string clientUri)
        {
            // Do not add at least empty or null string.
            if (!(string.IsNullOrEmpty(clientUri) || string.IsNullOrWhiteSpace(clientUri)))
            {
                this.ClientUris.Add(clientUri);
            }
        }

        /// <summary>
        /// Removes a client uri.
        /// </summary>
        /// <param name="clientUri">The client uri to add.</param>
        public void RemoveClientUri(string clientUri)
        {
            // No need to check parameter consistency.
            this.ClientUris.Remove(clientUri);
        }

        /// <summary>
        /// Notifies the specified text to all connected clients.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Notify(string text)
        {
            // Do not notify at least empty or null string.
            if (!(string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text)))
            {
                foreach (var clientUri in this.ClientUris)
                {
                    // Create message.
                    var message = new Message(clientUri, Guid.Empty, MessageTypes.DiagnosticsIndication);
                    var diagnosticsMessages = new DiagnosticsMessages { text };
                    message.AddParameter(ParameterTypes.Diagnostics, diagnosticsMessages);

                    // Enqueue message.
                    MessageQueue.Instance.Enqueue(message);
                }
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
