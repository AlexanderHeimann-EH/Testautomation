// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Message.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements a message to queue.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Common.Queue
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class Message
    /// </summary>
    public class Message
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="callbackEndpointAddress">The callback endpoint address.</param>
        /// <param name="invokeId">The invoke id.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="state">The associated state.</param>
        public Message(string callbackEndpointAddress, Guid invokeId, MessageTypes messageType, object state = null)
        {
            this.CallbackEndpointAddress = callbackEndpointAddress;

            this.InvokeId = invokeId;
            this.MessageType = messageType;
            this.Parameters = new Dictionary<ParameterTypes, object>();
            this.State = state;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the callback endpoint address.
        /// </summary>
        /// <value>The callback endpoint address.</value>
        public string CallbackEndpointAddress { get; private set; }

        /// <summary>
        /// Gets the invoke id.
        /// </summary>
        /// <value>The invoke id.</value>
        public Guid InvokeId { get; private set; }

        /// <summary>
        /// Gets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        public MessageTypes MessageType { get; private set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state is an object that can be assigned and it must be interpreted by the caller. It can contain anything.</value>
        public object State { get; private set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        private Dictionary<ParameterTypes, object> Parameters { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        /// <param name="parameterType">
        /// Type of the parameter.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void AddParameter(ParameterTypes parameterType, object value)
        {
            if (!this.Parameters.ContainsKey(parameterType))
            {
                this.Parameters.Add(parameterType, value);
            }
        }

        /// <summary>
        /// Reads the parameter.
        /// </summary>
        /// <param name="parameterType">
        /// Type of the parameter.
        /// </param>
        /// <returns>
        /// Return System Object.
        /// </returns>
        public object ReadParameter(ParameterTypes parameterType)
        {
            object value;
            if (this.Parameters.TryGetValue(parameterType, out value))
            {
                return value;
            }

            return null;
        }

        #endregion
    }
}