// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskItem.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Represents a task running in the ImsOpcBridge component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Tasks
{
    using System;
    using System.Globalization;
    using System.Reflection;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Helpers;
    using EH.ImsOpcBridge.Progress;
    using EH.ImsOpcBridge.Properties;

    using log4net;

    /// <summary>
    /// Represents a task running in the ImsOpcBridge component.
    /// </summary>
    public abstract class TaskItem : ITaskItem, IProgressProvider
    {
        #region Constants and Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The status of the task.
        /// </summary>
        private AsyncOperationStatus status;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskItem" /> class.
        /// </summary>
        /// <param name="taskHandler">The task handler.</param>
        /// <param name="title">The title.</param>
        /// <param name="text">The translatable text.</param>
        /// <param name="countTotal">The count total.</param>
        protected TaskItem(ITaskHandler taskHandler, TranslatableString title, TranslatableString text, int countTotal)
        {
            if (taskHandler == null)
            {
                throw new ArgumentNullException(@"taskHandler");
            }

            this.Status = AsyncOperationStatus.Idle;
            this.TaskHandler = taskHandler;
            this.ProgressTitle = title;
            this.ProgressItem = new ProgressItem(taskHandler.ProgressHandler, this, text, countTotal);
            this.ProgressItem.SetCancelDelegate(this.Cancel);
            this.ProgressItem.Canceled += this.HandleProgressItemCanceled;
            this.ProgressItem.Completed += this.HandleProgressItemCompleted;
            this.TaskHandler.Add(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskItem" /> class.
        /// </summary>
        /// <param name="taskHandler">The task handler.</param>
        /// <param name="title">The title.</param>
        /// <param name="text">The translatable text.</param>
        /// <param name="countTotal">The count total.</param>
        /// <param name="countCurrent">The count current.</param>
        protected TaskItem(ITaskHandler taskHandler, TranslatableString title, TranslatableString text, int countTotal, int countCurrent)
        {
            if (taskHandler == null)
            {
                throw new ArgumentNullException(@"taskHandler");
            }

            this.Status = AsyncOperationStatus.Idle;
            this.TaskHandler = taskHandler;
            this.ProgressTitle = title;
            this.ProgressItem = new ProgressItem(taskHandler.ProgressHandler, this, text, countTotal, countCurrent);
            this.ProgressItem.SetCancelDelegate(this.Cancel);
            this.ProgressItem.Canceled += this.HandleProgressItemCanceled;
            this.ProgressItem.Completed += this.HandleProgressItemCompleted;
            this.TaskHandler.Add(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TaskItem"/> class.
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="TaskItem"/> is reclaimed by garbage collection.
        /// </summary>
        ~TaskItem()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Fired when a task item has been canceled
        /// </summary>
        public event EventHandler<TaskEventArgs> Canceled;

        /// <summary>
        /// Fired when a task item changes
        /// </summary>
        public event EventHandler<TaskEventArgs> Changed;

        /// <summary>
        /// Fired when a task item has been completed
        /// </summary>
        public event EventHandler<TaskEventArgs> Completed;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        public Exception ErrorInformation { get; protected set; }

        /// <summary>
        /// Gets the progress item of the task item.
        /// </summary>
        public IProgressItem ProgressItem { get; private set; }

        /// <summary>
        /// Gets or sets the status of the task.
        /// </summary>
        /// <value>The status.</value>
        public AsyncOperationStatus Status
        {
            get
            {
                return this.status;
            }

            protected set
            {
                if (this.status != value)
                {
                    this.status = value;
                    this.OnChanged();
                }
            }
        }

        /// <summary>
        /// Gets the task handler.
        /// </summary>
        public ITaskHandler TaskHandler { get; private set; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        public object ProgressContext
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets Title.
        /// </summary>
        public ITranslatableString ProgressTitle { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Cancels a running task.
        /// </summary>
        /// <returns>True, if cancel was successful. Otherwise false.</returns>
        public abstract bool Cancel();

        /// <summary>
        /// Implements IDisposable
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Starts the task.
        /// </summary>
        public abstract void Start();

        #endregion

        #region Methods

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">If equals true, method is called directly or indirectly
        /// by a user's code. If equals to false, method is called by the runtime from inside
        /// a finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                }

                this.TaskHandler.Remove(this);

                if (this.ProgressItem != null)
                {
                    this.ProgressItem.Dispose();
                    this.ProgressItem.Canceled -= this.HandleProgressItemCanceled;
                    this.ProgressItem.Completed -= this.HandleProgressItemCompleted;

                    this.ProgressItem = null;
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Handles the progress item Canceled event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EH.ImsOpcBridge.EventArguments.ProgressEventArgs"/> instance containing the event data.</param>
        private void HandleProgressItemCanceled(object sender, ProgressEventArgs e)
        {
            if (this.Status != AsyncOperationStatus.Error)
            {
                this.Status = AsyncOperationStatus.Canceled;
            }

            this.OnCanceled();
        }

        /// <summary>
        /// Handles the progress item Completed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EH.ImsOpcBridge.EventArguments.ProgressEventArgs"/> instance containing the event data.</param>
        private void HandleProgressItemCompleted(object sender, ProgressEventArgs e)
        {
            this.Status = AsyncOperationStatus.Completed;
            this.OnCompleted();
        }

        /// <summary>
        /// Called when a task item has been canceled.
        /// </summary>
        private void OnCanceled()
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.TaskItemWithTitle_HasBeenCanceled, this.ProgressTitle);
                Logger.Debug(message);
            }

            var canceled = this.Canceled;
            this.TaskHandler.Remove(this);

            if (canceled != null)
            {
                canceled(this, new TaskEventArgs(this));
            }
        }

        /// <summary>
        /// Called when a task item has changed.
        /// </summary>
        private void OnChanged()
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.TaskItemWithTitle_HasChanged, this.ProgressTitle);
                Logger.Debug(message);
            }

            var changed = this.Changed;

            if (changed != null)
            {
                changed(this, new TaskEventArgs(this));
            }

            this.TaskHandler.OnItemChanged(this);
        }

        /// <summary>
        /// Called when a task item has been completed.
        /// </summary>
        private void OnCompleted()
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.TaskItemWithTitle_IsComplete, this.ProgressTitle);
                Logger.Debug(message);
            }

            var completed = this.Completed;
            this.TaskHandler.Remove(this);

            if (completed != null)
            {
                completed(this, new TaskEventArgs(this));
            }
        }

        #endregion
    }
}
