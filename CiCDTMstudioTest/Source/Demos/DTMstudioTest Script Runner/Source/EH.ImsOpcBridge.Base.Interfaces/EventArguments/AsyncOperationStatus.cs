// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AsyncOperationStatus.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The status of an asynchronous operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    /// <summary>
    /// The status of an asynchronous operation.
    /// </summary>
    public enum AsyncOperationStatus
    {
        /// <summary>
        /// The asynchronous operation is idle.
        /// </summary>
        Idle, 

        /// <summary>
        /// The asynchronous operation is running.
        /// </summary>
        Running, 

        /// <summary>
        /// The asynchronous operation has been successfully completed.
        /// </summary>
        Completed, 

        /// <summary>
        /// The asynchronous operation has been canceled.
        /// </summary>
        Canceled, 

        /// <summary>
        /// The asynchronous operation has stopped with errors.
        /// </summary>
        Error, 

        /// <summary>
        /// The status of the asynchronous operation is unknown.
        /// </summary>
        Unknown
    }
}
