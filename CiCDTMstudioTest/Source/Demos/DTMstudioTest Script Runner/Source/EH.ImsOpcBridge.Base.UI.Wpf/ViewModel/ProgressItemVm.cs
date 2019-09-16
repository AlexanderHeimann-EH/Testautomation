// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base.UI.Wpf
// Author           : I02423401
// Created          : 08-27-2012
//
// Last Modified By : I02423401
// Last Modified On : 08-27-2012
// ***********************************************************************
// <copyright file="ProgressItemVm.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.UI.Wpf.EventArguments;

    /// <summary>
    /// View model for progress bar
    /// </summary>
    public class ProgressItemVm : DependencyObject
    {
        #region Constants and Fields

        /// <summary>
        /// The is busy property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register("IsBusy", typeof(bool), typeof(ProgressItemVm), new PropertyMetadata(false));

        /// <summary>
        /// The percentage property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty PercentageProperty = DependencyProperty.Register("Percentage", typeof(int), typeof(ProgressItemVm), new PropertyMetadata(0));

        /// <summary>
        /// The subtitle property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty SubtitleProperty = DependencyProperty.Register("Text", typeof(string), typeof(ProgressItemVm), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The title property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ProgressItemVm), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The cancel command.
        /// </summary>
        private readonly DelegateCommand cancelCommand;

        /// <summary>
        /// Progress item to perform cancel.
        /// </summary>
        private IProgressItem progressItem;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressItemVm" /> class.
        /// </summary>
        /// <param name="progressItem">The progress item.</param>
        public ProgressItemVm(IProgressItem progressItem)
        {
            this.cancelCommand = new DelegateCommand(this.Cancel);

            this.progressItem = null;

            this.Initialize(progressItem);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The completed event. Called if the progress item stopped working (either completed or canceled)
        /// </summary>
        public event EventHandler<ProgressItemEventArgs> Completed;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the command interface for the cancel command.
        /// </summary>
        /// <value>The cancel command.</value>
        public ICommand CancelCommand
        {
            get
            {
                return this.cancelCommand;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the there is a progress running.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get
            {
                if (this.Dispatcher.CheckAccess())
                {
                    return (bool)this.GetValue(IsBusyProperty);
                }

                return (bool)this.Dispatcher.Invoke((Func<bool>)(() => this.IsBusy));
            }

            private set
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.SetValue(IsBusyProperty, value);
                }
                else
                {
                    this.Dispatcher.Invoke((Action)delegate { this.IsBusy = value; });
                }
            }
        }

        /// <summary>
        /// Gets or sets the percentage of reached progress
        /// </summary>
        /// <value>The percentage.</value>
        public int Percentage
        {
            get
            {
                if (this.Dispatcher.CheckAccess())
                {
                    return (int)this.GetValue(PercentageProperty);
                }

                return (int)this.Dispatcher.Invoke((Func<int>)(() => this.Percentage));
            }

            set
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.SetValue(PercentageProperty, value);
                }
                else
                {
                    this.Dispatcher.BeginInvoke((Action)delegate { this.Percentage = value; });
                }
            }
        }

        /// <summary>
        /// Gets the progress item.
        /// </summary>
        /// <value>The progress item.</value>
        public IProgressItem ProgressItem
        {
            get
            {
                return this.progressItem;
            }
        }

        /// <summary>
        /// Gets or sets the control title text
        /// </summary>
        /// <value>The subtitle.</value>
        public string Text
        {
            get
            {
                if (this.Dispatcher.CheckAccess())
                {
                    return (string)this.GetValue(SubtitleProperty);
                }

                return (string)this.Dispatcher.Invoke((Func<string>)(() => this.Text));
            }

            set
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.SetValue(SubtitleProperty, value);
                }
                else
                {
                    this.Dispatcher.BeginInvoke((Action)delegate { this.Text = value; });
                }
            }
        }

        /// <summary>
        /// Gets or sets the control title text
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                if (this.Dispatcher.CheckAccess())
                {
                    return (string)this.GetValue(TitleProperty);
                }

                return (string)this.Dispatcher.Invoke((Func<string>)(() => this.Title));
            }

            set
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.SetValue(TitleProperty, value);
                }
                else
                {
                    this.Dispatcher.BeginInvoke((Action)delegate { this.Title = value; });
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the progress item view model.
        /// </summary>
        /// <param name="progItem">The progress item.</param>
        protected void Initialize(IProgressItem progItem)
        {
            this.ReleaseProgressItem();

            this.progressItem = progItem;

            if (this.progressItem == null)
            {
                this.Title = string.Empty;
                this.Text = string.Empty;
                this.Percentage = 0;
                this.cancelCommand.IsExecutable = false;

                this.IsBusy = false;
            }
            else
            {
                this.Title = this.progressItem.Title;
                this.Text = this.progressItem.Text;
                this.Percentage = this.progressItem.Percentage;
                this.cancelCommand.IsExecutable = this.progressItem.CancelEnabled;

                this.progressItem.Changed += this.ProgressItemChangedHandler;
                this.progressItem.Canceled += this.ProgressItemCanceledHandler;
                this.progressItem.Completed += this.ProgressItemCompletedHandler;

                this.IsBusy = true;
            }
        }

        /// <summary>
        /// Cancels this instance.
        /// </summary>
        private void Cancel()
        {
            this.cancelCommand.IsExecutable = false;

            // do the canceling
            if (this.progressItem != null)
            {
                this.progressItem.Cancel();
            }
        }

        /// <summary>
        /// The progress item canceled handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ProgressItemCanceledHandler(object sender, ProgressEventArgs e)
        {
            this.IsBusy = false;
            this.ReleaseProgressItem();

            if (this.Completed != null)
            {
                this.Completed(this, new ProgressItemEventArgs() { CompletedItem = this });
            }
        }

        /// <summary>
        /// The progress item changed handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ProgressItemChangedHandler(object sender, ProgressEventArgs e)
        {
            if (this.progressItem != null)
            {
                this.Percentage = this.progressItem.Percentage;
                this.Text = this.progressItem.Text;
                this.Title = this.progressItem.Title;
            }
        }

        /// <summary>
        /// The progress item completed handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ProgressItemCompletedHandler(object sender, ProgressEventArgs e)
        {
            this.IsBusy = false;
            this.ReleaseProgressItem();

            if (this.Completed != null)
            {
                this.Completed(this, new ProgressItemEventArgs() { CompletedItem = this });
            }
        }

        /// <summary>
        /// Releases the progress item.
        /// </summary>
        private void ReleaseProgressItem()
        {
            if (this.progressItem != null)
            {
                this.progressItem.Changed -= this.ProgressItemChangedHandler;
                this.progressItem.Canceled -= this.ProgressItemCanceledHandler;
                this.progressItem.Completed -= this.ProgressItemCompletedHandler;

                this.progressItem = null;
            }
        }

        #endregion
    }
}
