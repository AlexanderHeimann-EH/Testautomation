// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaskItem.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The interface of a task item, representing a task running in the ImsOpcBridge component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;

    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// The interface of a task item, representing a task running in the ImsOpcBridge component.
    /// </summary>
    public interface ITaskItem : IDisposable
    {
        #region Public Events

        /// <summary>
        /// Fired when a task item has been canceled
        /// </summary>
        event EventHandler<TaskEventArgs> Canceled;

        /// <summary>
        /// Fired when a task item changes
        /// </summary>
        event EventHandler<TaskEventArgs> Changed;

        /// <summary>
        /// Fired when a task item has been completed
        /// </summary>
        event EventHandler<TaskEventArgs> Completed;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the progress item of the task item.
        /// </summary>
        IProgressItem ProgressItem { get; }

        /// <summary>
        /// Gets the status of the task.
        /// </summary>
        AsyncOperationStatus Status { get; }

        /// <summary>
        /// Gets the error.
        /// </summary>
        Exception ErrorInformation { get; }

        /// <summary>
        /// Gets Title.
        /// </summary>
        ITranslatableString ProgressTitle { get; }

        /// <summary>
        /// Gets the progress context.
        /// </summary>
        /// <value>The progress context.</value>
        object ProgressContext { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Cancels a running task.
        /// </summary>
        /// <returns>True, if cancel was successful. Otherwise false.</returns>
        bool Cancel();

        /// <summary>
        /// Starts the task.
        /// </summary>
        void Start();

        #endregion
    }
}
