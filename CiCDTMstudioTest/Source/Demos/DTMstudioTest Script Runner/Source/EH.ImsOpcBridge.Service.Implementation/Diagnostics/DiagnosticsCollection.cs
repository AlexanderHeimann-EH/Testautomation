// ***********************************************************************
// <copyright file="DiagnosticsCollection.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.Implementation.Diagnostics
{
    using System;

    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Class DiagnosticsCollection. This class cannot be inherited.
    /// </summary>
    public sealed class DiagnosticsCollection
    {
        #region Fields

        /// <summary>
        /// The synchronize root
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// The instance
        /// </summary>
        private static volatile DiagnosticsCollection instance;

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="DiagnosticsCollection"/> class from being created.
        /// </summary>
        private DiagnosticsCollection()
        {
            this.Messages = new DiagnosticsMessages();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static DiagnosticsCollection Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DiagnosticsCollection();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        private DiagnosticsMessages Messages { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a message.
        /// </summary>
        /// <param name="exception">The exception to add.</param>
        public void AddMessage(Exception exception)
        {
            if (exception != null)
            {
                this.InternalAddMessage(exception.Message);
                this.InternalAddMessage(exception.StackTrace);
            }
        }

        /// <summary>
        /// Adds a message.
        /// </summary>
        /// <param name="message">The message to add.</param>
        public void AddMessage(string message)
        {
            this.InternalAddMessage(message);
        }

        /// <summary>
        /// Reads the messages and removes them from the internal collection.
        /// </summary>
        /// <returns>A collection of messages.</returns>
        public DiagnosticsMessages ReadMessages()
        {
            var messages = this.Messages;
            this.Messages = new DiagnosticsMessages();
            return messages;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds a message.
        /// </summary>
        /// <param name="text">The text to add.</param>
        private void InternalAddMessage(string text)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
            {
                this.Messages.Add(string.Format("{0}, {1}", DateTime.Now, text));
            }
        }

        #endregion
    }
}
