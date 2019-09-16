// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageAgentEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The message agent event arguments.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;

    using EH.ImsOpcBridge.UI;

    /// <summary>
    /// The Message Agent for the
    /// </summary>
    public class MessageAgentEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageAgentEventArgs" /> class.
        /// </summary>
        /// <param name="showAgent">The show Agent.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageType">Type of the message.</param>
        public MessageAgentEventArgs(bool showAgent, string message, MessageType messageType)
        {
            this.ShowAgent = showAgent;
            this.Message = message;
            this.MessageType = messageType;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets Message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        public MessageType MessageType { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [show shadow].
        /// </summary>
        /// <value><c>true</c> if [show shadow]; otherwise, <c>false</c> .</value>
        public bool ShowAgent { get; private set; }

        #endregion
    }
}
