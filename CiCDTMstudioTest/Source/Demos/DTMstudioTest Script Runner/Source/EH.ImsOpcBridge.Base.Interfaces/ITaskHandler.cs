// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaskHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The interface of the handler, which manages all tasks running in the ImsOpcBridge component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.Collections.ObjectModel;

    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// The interface of the handler, which manages all tasks running in the ImsOpcBridge component.
    /// </summary>
    public interface ITaskHandler
    {
        #region Public Events

        /// <summary>
        /// Fired when a task item is added
        /// </summary>
        event EventHandler<TaskEventArgs> ItemAdded;

        /// <summary>
        /// Fired when a task item changes
        /// </summary>
        event EventHandler<TaskEventArgs> ItemChanged;

        /// <summary>
        /// Fired when a task item is removed
        /// </summary>
        event EventHandler<TaskEventArgs> ItemRemoved;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of active task items.
        /// </summary>
        ReadOnlyCollection<ITaskItem> ActiveItems { get; }

        /// <summary>
        /// Gets the reference to the progress handler.
        /// </summary>
        IProgressHandler ProgressHandler { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add a new task item to <see cref="ActiveItems"/>.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        void Add(ITaskItem item);

        /// <summary>
        /// Determines whether <see cref="ActiveItems"/> contains the task item.
        /// </summary>
        /// <param name="item">The task item.</param>
        /// <returns><c>true</c> if <see cref="ActiveItems"/> contains the task item; otherwise, <c>false</c>.</returns>
        bool Contains(ITaskItem item);

        /// <summary>
        /// Called when a task item has changed.
        /// </summary>
        /// <param name="item">The task item, which has changed.</param>
        void OnItemChanged(ITaskItem item);

        /// <summary>
        /// Removes a task item from <see cref="ActiveItems"/>.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        void Remove(ITaskItem item);

        #endregion
    }
}
