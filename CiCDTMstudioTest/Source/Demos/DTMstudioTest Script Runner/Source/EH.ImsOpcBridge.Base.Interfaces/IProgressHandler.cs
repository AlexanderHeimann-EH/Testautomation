// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProgressHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface of the progress handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.Collections.ObjectModel;

    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// Interface of the progress handler.
    /// </summary>
    public interface IProgressHandler
    {
        #region Public Events

        #endregion

        #region Public Properties

        #endregion

        #region Public Methods

        #endregion

        /// <summary>
        /// Fired when a progress item is added
        /// </summary>
        event EventHandler<ProgressEventArgs> ItemAdded;

        /// <summary>
        /// Fired when a progress item changes
        /// </summary>
        event EventHandler<ProgressEventArgs> ItemChanged;

        /// <summary>
        /// Fired when a progress item is removed
        /// </summary>
        event EventHandler<ProgressEventArgs> ItemRemoved;

        /// <summary>
        /// Gets the list of active progress items.
        /// </summary>
        ReadOnlyCollection<IProgressItem> ActiveItems { get; }

        /// <summary>
        /// Gets the current overall progress as a percentage
        /// </summary>
        int Percentage { get; }

        /// <summary>
        /// Add a new progress item to <see cref="ActiveItems"/>.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        void Add(IProgressItem item);

        /// <summary>
        /// Determines whether <see cref="ActiveItems"/> contains the progress item.
        /// </summary>
        /// <param name="item">The progress item.</param>
        /// <returns><c>true</c> if <see cref="ActiveItems"/> contains the progress item; otherwise, <c>false</c>.</returns>
        bool Contains(IProgressItem item);

        /// <summary>
        /// Called when a progress item has changed.
        /// </summary>
        /// <param name="item">The progress item, which has changed.</param>
        void OnItemChanged(IProgressItem item);

        /// <summary>
        /// Removes a progress item from <see cref="ActiveItems"/>.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        void Remove(IProgressItem item);
    }
}
