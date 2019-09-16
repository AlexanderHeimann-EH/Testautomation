// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base
// Author           : I02423401
// Created          : 04-16-2013
//
// Last Modified By : I02423401
// Last Modified On : 05-07-2013
// ***********************************************************************
// <copyright file="ProgressItem.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EH.ImsOpcBridge.Progress
{
    using System;
    using System.Globalization;
    using System.Reflection;

    using EH.ImsOpcBridge.Delegates;
    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Exceptions;
    using EH.ImsOpcBridge.Helpers;
    using EH.ImsOpcBridge.Properties;

    using log4net;

    /// <summary>
    /// The progress item, which is used to report a progress.
    /// </summary>
    public class ProgressItem : IProgressItem
    {
        #region Static Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        /// <summary>
        /// Object to lock concurrent access to <see cref="cancelDelegate" />.
        /// </summary>
        private readonly object cancelDelegateLock = new object();

        /// <summary>
        /// Object to lock concurrent access to <see cref="cancelEnabled" />.
        /// </summary>
        private readonly object cancelEnabledLock = new object();

        /// <summary>
        /// Object to lock concurrent access to <see cref="isCanceled" />.
        /// </summary>
        private readonly object canceledLock = new object();

        /// <summary>
        /// Object to lock concurrent access to <see cref="countCurrent" />.
        /// </summary>
        private readonly object countCurrentLock = new object();

        /// <summary>
        /// Object to lock concurrent access to <see cref="translatableText" />.
        /// </summary>
        private readonly object textLock = new object();

        /// <summary>
        /// The delegate to call, when the progress should be canceled.
        /// </summary>
        private CancelProc cancelDelegate;

        /// <summary>
        /// The value indicating whether this item can be canceled.
        /// </summary>
        private bool cancelEnabled;

        /// <summary>
        /// The current count of the progress.
        /// </summary>
        private int countCurrent;

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The value indicating whether this item is canceled
        /// </summary>
        private bool isCanceled;

        /// <summary>
        /// The translatable text.
        /// </summary>
        private TranslatableString translatableText;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressItem" /> class.
        /// Constructor
        /// </summary>
        /// <param name="progressHandler">The progress handler.</param>
        /// <param name="progressProvider">The progress provider.</param>
        /// <param name="translatableText">The translatable text.</param>
        /// <param name="countTotal">The count total.</param>
        public ProgressItem(IProgressHandler progressHandler, IProgressProvider progressProvider, TranslatableString translatableText, int countTotal)
        {
            this.ProgressHandler = progressHandler;
            this.ProgressProvider = progressProvider;
            this.CountTotal = countTotal;
            this.CountCurrent = 0;
            this.translatableText = translatableText;

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.CreatingProgressItemTitle_Text_CountTotal_CountCurrent0, this.Title, translatableText, countTotal);
                Logger.Debug(message);
            }

            this.ProgressHandler.Add(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressItem" /> class.
        /// Constructor
        /// </summary>
        /// <param name="progressHandler">The progress handler.</param>
        /// <param name="progressProvider">The progress provider.</param>
        /// <param name="translatableText">The translatable text.</param>
        /// <param name="countTotal">The count total.</param>
        /// <param name="countCurrent">The count current.</param>
        public ProgressItem(IProgressHandler progressHandler, IProgressProvider progressProvider, TranslatableString translatableText, int countTotal, int countCurrent)
        {
            this.ProgressHandler = progressHandler;
            this.ProgressProvider = progressProvider;
            this.CountTotal = countTotal;
            this.CountCurrent = countCurrent;
            this.translatableText = translatableText;

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.CreatingProgressItemTitle_Text_CountTotal_CountCurrent_, this.Title, translatableText, countTotal, countCurrent);
                Logger.Debug(message);
            }

            this.ProgressHandler.Add(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ProgressItem" /> class.
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="ProgressItem" /> is reclaimed by garbage collection.
        /// </summary>
        ~ProgressItem()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Fired when a progress item has been canceled
        /// </summary>
        public event EventHandler<ProgressEventArgs> Canceled;

        /// <summary>
        /// Fired when a progress item changes
        /// </summary>
        public event EventHandler<ProgressEventArgs> Changed;

        /// <summary>
        /// Fired when a progress item has been completed
        /// </summary>
        public event EventHandler<ProgressEventArgs> Completed;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether this item can be canceled.
        /// </summary>
        /// <value><c>true</c> if this progress item can be canceled; otherwise, <c>false</c>.</value>
        public bool CancelEnabled
        {
            get
            {
                return this.cancelEnabled;
            }

            set
            {
                if (Logger.IsDebugEnabled)
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.SettingCancelEnabledPropertyOfProgressItemWithTitle_To_, this.Title, value);
                    Logger.Debug(message);
                }

                lock (this.cancelEnabledLock)
                {
                    if (this.cancelEnabled != value)
                    {
                        this.cancelEnabled = value;
                        this.OnChanged();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the current count of the progress.
        /// </summary>
        /// <value>The current count of the progress.</value>
        public int CountCurrent
        {
            get
            {
                return this.countCurrent;
            }

            set
            {
                if (!this.IsProgressActive)
                {
                    // progress is not active anymore, don't change it
                    return;
                }

                if (Logger.IsDebugEnabled)
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.SettingCountCurrentPropertyOfProgressItemWithTitle_To_, this.Title, value);
                    Logger.Debug(message);
                }

                lock (this.countCurrentLock)
                {
                    if (this.countCurrent != value)
                    {
                        this.countCurrent = value;

                        if (Logger.IsDebugEnabled)
                        {
                            var message = string.Format(CultureInfo.CurrentUICulture, Resources.SettingProgressOfProgressItemWithTitle_To_PercentText_, this.Title, this.Percentage, this.Text);
                            Logger.Debug(message);
                        }

                        this.OnChanged();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the total count of the progress.
        /// </summary>
        /// <value>The total count of the progress.</value>
        public int CountTotal { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this item is be canceled
        /// </summary>
        /// <value><c>true</c> if canceled; otherwise, <c>false</c>.</value>
        public bool IsCanceled
        {
            get
            {
                return this.isCanceled;
            }

            set
            {
                if (Logger.IsDebugEnabled)
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.SettingCanceledPropertyOfProgressItemWithTitle_To_, this.Title, value);
                    Logger.Debug(message);
                }

                lock (this.canceledLock)
                {
                    if (this.isCanceled != value)
                    {
                        this.isCanceled = value;
                        this.OnChanged();
                    }
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this item is Complete
        /// </summary>
        /// <value><c>true</c> if this instance is complete; otherwise, <c>false</c>.</value>
        public bool IsComplete
        {
            get
            {
                return this.CountCurrent == this.CountTotal;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this progress item is active.
        /// </summary>
        /// <value><c>true</c> if this instance is progress active; otherwise, <c>false</c>.</value>
        public bool IsProgressActive
        {
            get
            {
                if (this.IsCanceled)
                {
                    return false;
                }

                return this.ProgressHandler.Contains(this);
            }
        }

        /// <summary>
        /// Gets or sets the percentage value between 0 and 100 indicating progress.
        /// </summary>
        /// <value>The percentage.</value>
        public int Percentage
        {
            get
            {
                double fraction = 0;

                if (this.CountTotal > 0)
                {
                    fraction = this.CountCurrent;
                    fraction = fraction / this.CountTotal;
                }

                var percentage = (int)Math.Round(100 * fraction);

                if (percentage < 0)
                {
                    percentage = 0;
                }
                else if (percentage > 100)
                {
                    percentage = 100;
                }

                return percentage;
            }

            set
            {
                if (value >= 100)
                {
                    this.CountCurrent = this.CountTotal;
                }
                else if (value >= 0)
                {
                    double fraction = 100;

                    if (this.CountTotal > 0)
                    {
                        fraction = fraction / this.CountTotal;
                        this.CountCurrent = (int)Math.Round(fraction * value);
                    }
                }
                else
                {
                    this.CountTotal = 0;
                }
            }
        }

        /// <summary>
        /// Gets the progress handler.
        /// </summary>
        /// <value>The progress handler.</value>
        public IProgressHandler ProgressHandler { get; private set; }

        /// <summary>
        /// Gets or sets the provider of the progress.
        /// </summary>
        /// <value>The progress provider.</value>
        public IProgressProvider ProgressProvider { get; protected set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The translatable text.</value>
        public string Text
        {
            get
            {
                return this.translatableText.ToString();
            }

            set
            {
                this.SetText(new TranslatableString(value, null, null));
            }
        }

        /// <summary>
        /// Gets the title of the progress.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return this.ProgressProvider.ProgressTitle.ToString();
            }
        }

        /// <summary>
        /// Gets the translatable text.
        /// </summary>
        /// <value>The translatable text.</value>
        public ITranslatableString TranslatableText
        {
            get
            {
                return this.translatableText;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Cancels the progress item by initiating a call to the specified cancel delegate.
        /// </summary>
        public void Cancel()
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.CancelProgressItemWithTitle_, this.Title);
                Logger.Debug(message);
            }

            CancelProc cancelProc;

            lock (this.cancelDelegateLock)
            {
                if (this.IsCanceled)
                {
                    throw new BaseException(Resources.CouldNotCancelProgressProgressHasAlreadyBeenCanceled);
                }

                if (!this.CancelEnabled)
                {
                    throw new BaseException(Resources.CouldNotCancelProgressCancelIsDisabled);
                }

                if (!this.IsProgressActive)
                {
                    throw new BaseException(Resources.CouldNotCancelProgressProgressIsNotActive);
                }

                cancelProc = this.cancelDelegate;
            }

            if (cancelProc != null)
            {
                this.IsCanceled = cancelProc();

                if (Logger.IsDebugEnabled)
                {
                    if (this.IsCanceled)
                    {
                        var message = string.Format(CultureInfo.CurrentUICulture, Resources.ProgressItemWithTitle_HasBeenCanceled, this.Title);
                        Logger.Debug(message);
                    }
                    else
                    {
                        var message = string.Format(CultureInfo.CurrentUICulture, Resources.CancelingProgressItemWithTitle_Failed, this.Title);
                        Logger.Debug(message);
                    }
                }

                if (this.IsCanceled)
                {
                    this.SetCanceled();
                }
            }
            else
            {
                throw new BaseException(Resources.CouldNotCancelProgressNoCancelDelegateAssigned);
            }
        }

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
        /// Sets the cancel delegate.
        /// </summary>
        /// <param name="cancelDelegateToSet">The cancel delegate to be called to cancel the progress.</param>
        public void SetCancelDelegate(CancelProc cancelDelegateToSet)
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.SettingCancelDelegateOfProgressItemWithTitle_, this.Title);
                Logger.Debug(message);
            }

            lock (this.cancelDelegateLock)
            {
                if ((this.cancelDelegate == null) && (cancelDelegateToSet != null))
                {
                    this.cancelDelegate = cancelDelegateToSet;
                    this.CancelEnabled = true;
                }
                else if ((this.cancelDelegate != null) && (cancelDelegateToSet == null))
                {
                    this.cancelDelegate = null;
                    this.CancelEnabled = false;
                }
            }
        }

        /// <summary>
        /// Indicates that this progress item is canceled.
        /// </summary>
        public void SetCanceled()
        {
            if (!this.IsProgressActive)
            {
                // progress is not active anymore, don't change it
                this.ProgressHandler.Remove(this);
                return;
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.ProgressItemWithTitle_HasBeenCanceledAt_Percent, this.Title, this.Percentage);
                Logger.Debug(message);
            }

            this.IsCanceled = true;
            this.OnCanceled();
            this.ProgressHandler.Remove(this);
        }

        /// <summary>
        /// Indicates that this progress item is complete.
        /// </summary>
        public void SetComplete()
        {
            if (!this.IsProgressActive)
            {
                // progress is not active anymore, don't change it
                this.ProgressHandler.Remove(this);
                return;
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.SettingProgressItemWithTitle_ToComplete, this.Title);
                Logger.Debug(message);
            }

            this.CountCurrent = this.CountTotal;
            this.OnCompleted();
            this.ProgressHandler.Remove(this);
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void SetText(ITranslatableString text)
        {
            if (!this.IsProgressActive)
            {
                // progress is not active anymore, don't change it
                return;
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.SettingTextPropertyOfProgressItemWithTitle_To_, this.Title, text);
                Logger.Debug(message);
            }

            lock (this.textLock)
            {
                this.translatableText = new TranslatableString(text);
                this.OnChanged();
            }
        }

        /// <summary>
        /// Moves the progress bar another step and updates the current text
        /// </summary>
        /// <param name="textUpdate">Text to be displayed.</param>
        public void StepUpdate(ITranslatableString textUpdate)
        {
            this.SetText(textUpdate);
            this.StepUpdate();
        }

        /// <summary>
        /// Moves the progress bar another step
        /// </summary>
        public void StepUpdate()
        {
            lock (this.countCurrentLock)
            {
                this.CountCurrent++;
            }
        }

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
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                }

                this.SetCanceled();

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Called when a progress item has been canceled.
        /// </summary>
        private void OnCanceled()
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.ProgressItemWithTitle_HasBeenCanceled, this.Title);
                Logger.Debug(message);
            }

            var canceled = this.Canceled;

            if (canceled != null)
            {
                canceled(null, new ProgressEventArgs(this));
            }
        }

        /// <summary>
        /// Called when a progress item has changed.
        /// </summary>
        private void OnChanged()
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.ProgressItemWithTitle_HasChanged, this.Title);
                Logger.Debug(message);
            }

            var changed = this.Changed;

            if (changed != null)
            {
                changed(null, new ProgressEventArgs(this));
            }

            this.ProgressHandler.OnItemChanged(this);
        }

        /// <summary>
        /// Called when a progress item has been completed.
        /// </summary>
        private void OnCompleted()
        {
            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.ProgressItemWithTitle_IsComplete, this.Title);
                Logger.Debug(message);
            }

            var completed = this.Completed;

            if (completed != null)
            {
                completed(null, new ProgressEventArgs(this));
            }
        }

        #endregion
    }
}
