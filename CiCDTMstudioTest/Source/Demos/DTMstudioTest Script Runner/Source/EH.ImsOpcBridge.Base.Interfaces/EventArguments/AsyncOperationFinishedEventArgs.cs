// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AsyncOperationFinishedEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Event arguments of an event, which signals the end of an asynchronous operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;

    /// <summary>
    /// Event arguments of an event, which signals the end of an asynchronous operation.
    /// </summary>
    public class AsyncOperationFinishedEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncOperationFinishedEventArgs"/> class.
        /// </summary>
        /// <remarks>Sets the status of the asynchronous operation to Unknown.</remarks>
        public AsyncOperationFinishedEventArgs()
        {
            this.Status = AsyncOperationStatus.Unknown;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncOperationFinishedEventArgs"/> class.
        /// </summary>
        /// <param name="status">The status.</param>
        public AsyncOperationFinishedEventArgs(AsyncOperationStatus status)
        {
            this.Status = status;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the status of the asynchronous operation.
        /// </summary>
        public AsyncOperationStatus Status { get; private set; }

        #endregion
    }
}
