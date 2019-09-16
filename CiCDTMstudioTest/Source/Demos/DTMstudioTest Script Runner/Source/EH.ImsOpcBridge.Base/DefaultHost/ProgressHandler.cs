// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The default progress handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.DefaultHost
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Reflection;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Progress;
    using EH.ImsOpcBridge.Properties;

    using log4net;

    /// <summary>
    /// The default progress handler.
    /// </summary>
    public class ProgressHandler : IProgressHandler
    {
        #region Constants and Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// List of the active progress items.
        /// </summary>
        private readonly List<IProgressItem> activeItems = new List<IProgressItem>();

        #endregion

        #region Public Events

        /// <summary>
        /// Fired when a progress item is added
        /// </summary>
        public event EventHandler<ProgressEventArgs> ItemAdded;

        /// <summary>
        /// Fired when a progress item changes
        /// </summary>
        public event EventHandler<ProgressEventArgs> ItemChanged;

        /// <summary>
        /// Fired when a progress item is removed
        /// </summary>
        public event EventHandler<ProgressEventArgs> ItemRemoved;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of active progress items.
        /// </summary>
        public ReadOnlyCollection<IProgressItem> ActiveItems
        {
            get
            {
                return new ReadOnlyCollection<IProgressItem>(this.activeItems.ToArray());
            }
        }

        /// <summary>
        /// Gets the current overall progress as a percentage
        /// </summary>
        public int Percentage
        {
            get
            {
                var copiedItems = new List<IProgressItem>(this.activeItems);                

                var count = copiedItems.Count;

                if (count == 0)
                {
                    return 0;
                }

                double sum = 0;

                foreach (ProgressItem item in copiedItems)
                {
                    sum += item.Percentage;
                }

                return (int)Math.Round(sum / count);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add a new progress item to <see cref="ActiveItems"/>.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        public void Add(IProgressItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(@"item");
            }
            
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.AddingProgressItemWithTitle_ToProgressList, item.Title);
                Logger.Debug(message);
            }

            lock (this.activeItems)
            {
                if (!this.activeItems.Contains(item))
                {
                    this.activeItems.Add(item);
                    this.OnItemAdded(item);
                }
            }
        }

        /// <summary>
        /// Determines whether <see cref="ActiveItems"/> contains the progress item.
        /// </summary>
        /// <param name="item">The progress item.</param>
        /// <returns><c>true</c> if <see cref="ActiveItems"/> contains the progress item; otherwise, <c>false</c>.</returns>
        public bool Contains(IProgressItem item)
        {
            lock (this.activeItems)
            {
                return this.activeItems.Contains(item);
            }
        }

        /// <summary>
        /// Called when a progress item has changed.
        /// </summary>
        /// <param name="item">The progress item, which has changed.</param>
        public void OnItemChanged(IProgressItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(@"item");
            }
            
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.ProgressItemWithTitle_HasChanged, item.Title);
                Logger.Debug(message);
            }

            var itemChanged = this.ItemChanged;

            if (itemChanged != null)
            {
                itemChanged(null, new ProgressEventArgs(item));
            }
        }

        /// <summary>
        /// Removes a progress item from <see cref="ActiveItems"/>.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        public void Remove(IProgressItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(@"item");
            }
            
            lock (this.activeItems)
            {
                if (this.activeItems.Contains(item))
                {
                    if (Logger.IsDebugEnabled)
                    {
                        var message = string.Format(CultureInfo.CurrentUICulture, Resources.RemovingProgressItemWithTitle_FromProgressList, item.Title);
                        Logger.Debug(message);
                    }

                    this.activeItems.Remove(item);
                    this.OnItemRemoved(item);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when a progress item is added.
        /// </summary>
        /// <param name="item">The progress item, which has been added.</param>
        private void OnItemAdded(IProgressItem item)
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.ProgressItemWithTitle_HasBeenAddedToProgressList, item.Title);
                Logger.Debug(message);
            }

            var itemAdded = this.ItemAdded;

            if (itemAdded != null)
            {
                itemAdded(null, new ProgressEventArgs(item));
            }
        }

        /// <summary>
        /// Called when a progress item is removed.
        /// </summary>
        /// <param name="item">The progress item, which has been removed.</param>
        private void OnItemRemoved(IProgressItem item)
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.ProgressItemWithTitle_HasBeenRemovedFromProgressList, item.Title);
                Logger.Debug(message);
            }

            var itemRemoved = this.ItemRemoved;

            if (itemRemoved != null)
            {
                itemRemoved(null, new ProgressEventArgs(item));
            }
        }

        #endregion
    }
}
