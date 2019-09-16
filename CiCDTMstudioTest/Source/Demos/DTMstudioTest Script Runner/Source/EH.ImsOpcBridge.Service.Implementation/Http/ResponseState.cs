// ***********************************************************************
// <copyright file="ResponseState.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
// Implements the state object for an expected HTTP response.
// </summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.Implementation.Http
{
    using System.Threading;

    /// <summary>
    /// Implements the state object for an expected HTTP response.
    /// </summary>
    internal class ResponseState
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseState" /> class.
        /// </summary>
        /// <param name="resetEvent">The reset event.</param>
        public ResponseState(AutoResetEvent resetEvent)
        {
            this.ResetEvent = resetEvent;
        }

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets the reset event.
        /// </summary>
        /// <value>The reset event.</value>
        public AutoResetEvent ResetEvent { get; private set; }

        /// <summary>
        /// Gets the response string.
        /// </summary>
        /// <value>The response string.</value>
        public string ResponseString { get; private set; }

        #region Public Methods

        /// <summary>
        /// Sets the response. This method sets the response and sets the event too, to communicate the waiting object that the asynchronous operation has completed.
        /// </summary>
        /// <param name="response">The response.</param>
        public void SetResponse(string response)
        {
            this.ResponseString = response;
            this.ResetEvent.Set();
        }

        #endregion

        #endregion
    }
}
