// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The handler, which manages all tasks running in the ImsOpcBridge component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.DefaultHost
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Reflection;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Properties;

    using log4net;

    /// <summary>
    /// The handler, which manages all tasks running in the ImsOpcBridge component.
    /// </summary>
    public class TaskHandler : ITaskHandler
    {
        #region Constants and Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The active Items
        /// </summary>
        private readonly Collection<ITaskItem> activeItems = new Collection<ITaskItem>();

        /// <summary>
        /// The reference to the progress handler.
        /// </summary>
        private readonly IProgressHandler progressHandler;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskHandler"/> class.
        /// </summary>
        /// <param name="progressHandler">The progress handler.</param>
        public TaskHandler(IProgressHandler progressHandler)
        {
            this.progressHandler = progressHandler;
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Fired when a task item is added
        /// </summary>
        public event EventHandler<TaskEventArgs> ItemAdded;

        /// <summary>
        /// Fired when a task item changes
        /// </summary>
        public event EventHandler<TaskEventArgs> ItemChanged;

        /// <summary>
        /// Fired when a task item is removed
        /// </summary>
        public event EventHandler<TaskEventArgs> ItemRemoved;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of active task items.
        /// </summary>
        public ReadOnlyCollection<ITaskItem> ActiveItems
        {
            get
            {
                return new ReadOnlyCollection<ITaskItem>(this.activeItems);
            }
        }

        /// <summary>
        /// Gets the reference to the progress handler.
        /// </summary>
        public IProgressHandler ProgressHandler
        {
            get
            {
                return this.progressHandler;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add a new task item to <see cref="ActiveItems"/>.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        public void Add(ITaskItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(@"item");
            }
            
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.AddingTaskItemWithTitle_ToTaskList, item.ProgressTitle);
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
        /// Determines whether <see cref="ActiveItems"/> contains the task item.
        /// </summary>
        /// <param name="item">The task item.</param>
        /// <returns><c>true</c> if <see cref="ActiveItems"/> contains the task item; otherwise, <c>false</c>.</returns>
        public bool Contains(ITaskItem item)
        {
            lock (this.activeItems)
            {
                return this.activeItems.Contains(item);
            }
        }

        /// <summary>
        /// Called when a task item has changed.
        /// </summary>
        /// <param name="item">The task item, which has changed.</param>
        public void OnItemChanged(ITaskItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(@"item");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.TaskItemWithTitle_HasChanged, item.ProgressTitle);
                Logger.Debug(message);
            }

            var itemChanged = this.ItemChanged;

            if (itemChanged != null)
            {
                itemChanged(null, new TaskEventArgs(item));
            }
        }

        /// <summary>
        /// Removes a task item from <see cref="ActiveItems"/>.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        public void Remove(ITaskItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(@"item");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.RemovingTaskItemWithTitle_FromTaskList, item.ProgressTitle);
                Logger.Debug(message);
            }

            lock (this.activeItems)
            {
                if (this.activeItems.Contains(item))
                {
                    this.activeItems.Remove(item);
                    this.OnItemRemoved(item);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when a task item is added.
        /// </summary>
        /// <param name="item">The task item, which has been added.</param>
        private void OnItemAdded(ITaskItem item)
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.TaskItemWithTitle_HasBeenAddedToTaskList, item.ProgressTitle);
                Logger.Debug(message);
            }

            var itemAdded = this.ItemAdded;

            if (itemAdded != null)
            {
                itemAdded(null, new TaskEventArgs(item));
            }
        }

        /// <summary>
        /// Called when a task item is removed.
        /// </summary>
        /// <param name="item">The task item, which has been removed.</param>
        private void OnItemRemoved(ITaskItem item)
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.TaskItemWithTitle_HasBeenRemovedFromTaskList, item.ProgressTitle);
                Logger.Debug(message);
            }

            var itemRemoved = this.ItemRemoved;

            if (itemRemoved != null)
            {
                itemRemoved(null, new TaskEventArgs(item));
            }
        }

        #endregion
    }
}
