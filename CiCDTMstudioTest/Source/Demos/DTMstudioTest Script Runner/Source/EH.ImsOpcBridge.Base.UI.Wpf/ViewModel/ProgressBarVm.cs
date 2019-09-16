// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressBarVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// View model for progress bar
    /// </summary>
    public class ProgressBarVm : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The cancel button visibility property.
        /// </summary>
        public static readonly DependencyProperty CancelButtonVisibilityProperty = DependencyProperty.Register("CancelButtonVisibility", typeof(Visibility), typeof(ProgressBarVm), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The is busy property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register("IsBusy", typeof(bool), typeof(ProgressBarVm), new PropertyMetadata(false));

        /// <summary>
        /// The percentage property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty PercentageProperty = DependencyProperty.Register("Percentage", typeof(int), typeof(ProgressBarVm), new PropertyMetadata(0));

        /// <summary>
        /// The subtitle property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty SubtitleProperty = DependencyProperty.Register("Subtitle", typeof(string), typeof(ProgressBarVm), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The title property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ProgressBarVm), new PropertyMetadata(string.Empty));

        #endregion

        #region Fields

        /// <summary>
        /// The cancel command.
        /// </summary>
        private readonly DelegateCommand cancelCommand;

        /// <summary>
        /// The disable cancel button
        /// </summary>
        private bool disableCancelButton;

        /// <summary>
        /// Progress item to perform cancel.
        /// </summary>
        private IProgressItem progressItem;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBarVm" /> class.
        /// </summary>
        /// <param name="progressItem">The progress item.</param>
        public ProgressBarVm(IProgressItem progressItem)
        {
            this.CancelButtonVisibility = Visibility.Collapsed;
            this.cancelCommand = new DelegateCommand(this.Cancel);

            this.progressItem = null;

            this.UpdateProgressItem(progressItem);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the cancel button visibility.
        /// </summary>
        /// <value>The cancel button visibility.</value>
        public Visibility CancelButtonVisibility
        {
            get
            {
                return (Visibility)this.GetValue(CancelButtonVisibilityProperty);
            }

            set
            {
                this.SetValue(CancelButtonVisibilityProperty, value);
            }
        }

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
        /// Gets or sets a value indicating whether [disable cancel button].
        /// </summary>
        /// <value><c>true</c> if [disable cancel button]; otherwise, <c>false</c>.</value>
        public bool DisableCancelButton
        {
            get
            {
                return this.disableCancelButton;
            }

            set
            {
                this.disableCancelButton = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the there is a progress running.
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

            set
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.SetValue(IsBusyProperty, value);
                }
                else
                {
                    this.Dispatcher.BeginInvoke((Action)delegate { this.IsBusy = value; });
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
        /// Gets or sets the control title text
        /// </summary>
        /// <value>The subtitle.</value>
        public string Subtitle
        {
            get
            {
                if (this.Dispatcher.CheckAccess())
                {
                    return (string)this.GetValue(SubtitleProperty);
                }

                return (string)this.Dispatcher.Invoke((Func<string>)(() => this.Subtitle));
            }

            set
            {
                if (this.Dispatcher.CheckAccess())
                {
                    this.SetValue(SubtitleProperty, value);
                }
                else
                {
                    this.Dispatcher.BeginInvoke((Action)delegate { this.Subtitle = value; });
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

        #region Public Methods and Operators

        /// <summary>
        /// Updates the progress item.
        /// </summary>
        /// <param name="progItem">The progress item.</param>
        public void UpdateProgressItem(IProgressItem progItem)
        {
            if (this.CheckAccess())
            {
                this.ReleaseProgressItem();

                this.progressItem = progItem;

                if (this.progressItem == null)
                {
                    this.Title = string.Empty;
                    this.Subtitle = string.Empty;
                    this.Percentage = 0;
                    this.cancelCommand.IsExecutable = false;
                    this.CancelButtonVisibility = Visibility.Collapsed;

                    this.IsBusy = false;
                }
                else
                {
                    this.Title = this.progressItem.Title;
                    this.Subtitle = this.progressItem.Text;
                    this.Percentage = this.progressItem.Percentage;

                    if (this.disableCancelButton)
                    {
                        this.cancelCommand.IsExecutable = false;
                        this.CancelButtonVisibility = Visibility.Collapsed;
                    }
                    else
                    {
                        this.CancelButtonVisibility = Visibility.Visible;
                        this.cancelCommand.IsExecutable = this.progressItem.CancelEnabled;
                    }

                    this.progressItem.Changed += this.ProgressItemChangedHandler;
                    this.progressItem.Canceled += this.ProgressItemCanceledHandler;
                    this.progressItem.Completed += this.ProgressItemCompletedHandler;

                    this.IsBusy = true;
                }
            }
            else
            {
                // again, but in correct thread
                this.Dispatcher.Invoke(new Action<IProgressItem>(this.UpdateProgressItem), new[] { progItem });
            }
        }

        #endregion

        #region Methods

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
        }

        /// <summary>
        /// The progress item changed handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ProgressItemChangedHandler(object sender, ProgressEventArgs e)
        {
            this.Percentage = this.progressItem.Percentage;
            this.Subtitle = this.progressItem.Text;
            this.Title = this.progressItem.Title;
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
