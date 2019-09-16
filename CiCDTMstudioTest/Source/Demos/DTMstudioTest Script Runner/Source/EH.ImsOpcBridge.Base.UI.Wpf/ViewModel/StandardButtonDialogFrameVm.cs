// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StandardButtonDialogFrameVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// View model for the standard dialog frame handling the standard buttons
    /// </summary>
    public class StandardButtonDialogFrameVm : DependencyObject
    {
        #region Constants and Fields

        /// <summary>
        /// The is abort button visible property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsAbortButtonVisibleProperty = DependencyProperty.Register("IsAbortButtonVisible", typeof(bool), typeof(StandardButtonDialogFrameVm), new PropertyMetadata(true));

        /// <summary>
        /// The is cancel button visible property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsCancelButtonVisibleProperty = DependencyProperty.Register("IsCancelButtonVisible", typeof(bool), typeof(StandardButtonDialogFrameVm), new PropertyMetadata(true));

        /// <summary>
        /// The is ignore button visible property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsIgnoreButtonVisibleProperty = DependencyProperty.Register("IsIgnoreButtonVisible", typeof(bool), typeof(StandardButtonDialogFrameVm), new PropertyMetadata(true));

        /// <summary>
        /// The is no button visible property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsNoButtonVisibleProperty = DependencyProperty.Register("IsNoButtonVisible", typeof(bool), typeof(StandardButtonDialogFrameVm), new PropertyMetadata(true));

        /// <summary>
        /// The is ok button visible property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsOkButtonVisibleProperty = DependencyProperty.Register("IsOkButtonVisible", typeof(bool), typeof(StandardButtonDialogFrameVm), new PropertyMetadata(true));

        /// <summary>
        /// The is retry button visible property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsRetryButtonVisibleProperty = DependencyProperty.Register("IsRetryButtonVisible", typeof(bool), typeof(StandardButtonDialogFrameVm), new PropertyMetadata(true));

        /// <summary>
        /// The is yes button visible property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty IsYesButtonVisibleProperty = DependencyProperty.Register("IsYesButtonVisible", typeof(bool), typeof(StandardButtonDialogFrameVm), new PropertyMetadata(true));

        /// <summary>
        /// The title property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(StandardButtonDialogFrameVm), new PropertyMetadata(string.Empty));

        /// <summary>
        /// the default button
        /// </summary>
        private readonly DefaultMessageButton defaultButton = DefaultMessageButton.ButtonNone;

        /// <summary>
        /// the message buttons to be displayed
        /// </summary>
        private readonly MessageButton messageButtons = MessageButton.ButtonsOk;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardButtonDialogFrameVm"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="defaultButton">The default button.</param>
        public StandardButtonDialogFrameVm(string title, MessageButton buttons, DefaultMessageButton defaultButton)
        {
            this.Title = title;
            this.messageButtons = buttons;
            this.defaultButton = defaultButton;

            if (this.defaultButton != DefaultMessageButton.ButtonNone)
            {
                switch (this.messageButtons)
                {
                    case MessageButton.ButtonsOk:
                        this.IsOkButtonVisible = true;
                        this.IsCancelButtonVisible = false;
                        this.IsRetryButtonVisible = false;
                        this.IsAbortButtonVisible = false;
                        this.IsIgnoreButtonVisible = false;
                        this.IsYesButtonVisible = false;
                        this.IsNoButtonVisible = false;
                        this.OkCommand = new DelegateCommand(this.OkCommandHandler);
                        break;
                    case MessageButton.ButtonsOkCancel:
                        this.IsOkButtonVisible = true;
                        this.IsCancelButtonVisible = true;
                        this.IsRetryButtonVisible = false;
                        this.IsAbortButtonVisible = false;
                        this.IsIgnoreButtonVisible = false;
                        this.IsYesButtonVisible = false;
                        this.IsNoButtonVisible = false;
                        this.OkCommand = new DelegateCommand(this.OkCommandHandler);
                        this.CancelCommand = new DelegateCommand(this.CancelCommandHandler);
                        break;
                    case MessageButton.ButtonsRetryCancel:
                        this.IsOkButtonVisible = false;
                        this.IsCancelButtonVisible = true;
                        this.IsRetryButtonVisible = true;
                        this.IsAbortButtonVisible = false;
                        this.IsIgnoreButtonVisible = false;
                        this.IsYesButtonVisible = false;
                        this.IsNoButtonVisible = false;
                        this.RetryCommand = new DelegateCommand(this.RetryCommandHandler);
                        this.CancelCommand = new DelegateCommand(this.CancelCommandHandler);
                        break;
                    case MessageButton.ButtonsAbortRetryIgnore:
                        this.IsOkButtonVisible = false;
                        this.IsCancelButtonVisible = false;
                        this.IsRetryButtonVisible = true;
                        this.IsAbortButtonVisible = true;
                        this.IsIgnoreButtonVisible = true;
                        this.IsYesButtonVisible = false;
                        this.IsNoButtonVisible = false;
                        this.AbortCommand = new DelegateCommand(this.AbortCommandHandler);
                        this.RetryCommand = new DelegateCommand(this.RetryCommandHandler);
                        this.IgnoreCommand = new DelegateCommand(this.IgnoreCommandHandler);
                        break;
                    case MessageButton.ButtonsYesNo:
                        this.IsOkButtonVisible = false;
                        this.IsCancelButtonVisible = false;
                        this.IsRetryButtonVisible = false;
                        this.IsAbortButtonVisible = false;
                        this.IsIgnoreButtonVisible = false;
                        this.IsYesButtonVisible = true;
                        this.IsNoButtonVisible = true;
                        this.YesCommand = new DelegateCommand(this.YesCommandHandler);
                        this.NoCommand = new DelegateCommand(this.NoCommandHandler);
                        break;
                    case MessageButton.ButtonsYesNoCancel:
                        this.IsOkButtonVisible = false;
                        this.IsCancelButtonVisible = true;
                        this.IsRetryButtonVisible = false;
                        this.IsAbortButtonVisible = false;
                        this.IsIgnoreButtonVisible = false;
                        this.IsYesButtonVisible = true;
                        this.IsNoButtonVisible = true;
                        this.YesCommand = new DelegateCommand(this.YesCommandHandler);
                        this.NoCommand = new DelegateCommand(this.NoCommandHandler);
                        this.CancelCommand = new DelegateCommand(this.CancelCommandHandler);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("buttons");
                }
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the abort command.
        /// </summary>
        public ICommand AbortCommand { get; private set; }

        /// <summary>
        /// Gets the cancel command.
        /// </summary>
        public ICommand CancelCommand { get; private set; }

        /// <summary>
        /// Gets the ignore command.
        /// </summary>
        public ICommand IgnoreCommand { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance's abort button is visible.
        /// </summary>
        /// <value><c>true</c> if this instance's abort button is visible; otherwise, <c>false</c>.</value>
        public bool IsAbortButtonVisible
        {
            get
            {
                return (bool)this.GetValue(IsAbortButtonVisibleProperty);
            }

            private set
            {
                this.SetValue(IsAbortButtonVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance's cancel button is visible.
        /// </summary>
        /// <value><c>true</c> if this instance's cancel button visible; otherwise, <c>false</c>.</value>
        public bool IsCancelButtonVisible
        {
            get
            {
                return (bool)this.GetValue(IsCancelButtonVisibleProperty);
            }

            private set
            {
                this.SetValue(IsCancelButtonVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance's ignore button is visible.
        /// </summary>
        /// <value><c>true</c> if this instance's ignore button is visible; otherwise, <c>false</c>.</value>
        public bool IsIgnoreButtonVisible
        {
            get
            {
                return (bool)this.GetValue(IsIgnoreButtonVisibleProperty);
            }

            private set
            {
                this.SetValue(IsIgnoreButtonVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance's no button is visible.
        /// </summary>
        /// <value><c>true</c> if this instance's no button visible; otherwise, <c>false</c>.</value>
        public bool IsNoButtonVisible
        {
            get
            {
                return (bool)this.GetValue(IsNoButtonVisibleProperty);
            }

            private set
            {
                this.SetValue(IsNoButtonVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance's ok button is visible.
        /// </summary>
        /// <value><c>true</c> if this instance's ok button is visible; otherwise, <c>false</c>.</value>
        public bool IsOkButtonVisible
        {
            get
            {
                return (bool)this.GetValue(IsOkButtonVisibleProperty);
            }

            private set
            {
                this.SetValue(IsOkButtonVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance's retry button is visible.
        /// </summary>
        /// <value><c>true</c> if this instance's retry button is visible; otherwise, <c>false</c>.</value>
        public bool IsRetryButtonVisible
        {
            get
            {
                return (bool)this.GetValue(IsRetryButtonVisibleProperty);
            }

            private set
            {
                this.SetValue(IsRetryButtonVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance's yes button is visible.
        /// </summary>
        /// <value><c>true</c> if this instance's yes button visible; otherwise, <c>false</c>.</value>
        public bool IsYesButtonVisible
        {
            get
            {
                return (bool)this.GetValue(IsYesButtonVisibleProperty);
            }

            private set
            {
                this.SetValue(IsYesButtonVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets the no command.
        /// </summary>
        public ICommand NoCommand { get; private set; }

        /// <summary>
        /// Gets the ok command.
        /// </summary>
        public ICommand OkCommand { get; private set; }

        /// <summary>
        /// Gets the result message.
        /// </summary>
        public ResultMessage Result { get; private set; }

        /// <summary>
        /// Gets the retry command.
        /// </summary>
        public ICommand RetryCommand { get; private set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return (string)this.GetValue(TitleProperty);
            }

            set
            {
                this.SetValue(TitleProperty, value);
            }
        }

        /// <summary>
        /// Gets the yes command.
        /// </summary>
        public ICommand YesCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The abort command handler.
        /// </summary>
        private void AbortCommandHandler()
        {
            this.Result = ResultMessage.ButtonAbort;
        }

        /// <summary>
        /// The cancel command handler.
        /// </summary>
        private void CancelCommandHandler()
        {
            this.Result = ResultMessage.ButtonCancel;
        }

        /// <summary>
        /// The ignore command handler.
        /// </summary>
        private void IgnoreCommandHandler()
        {
            this.Result = ResultMessage.ButtonIgnore;
        }

        /// <summary>
        /// The no command handler.
        /// </summary>
        private void NoCommandHandler()
        {
            this.Result = ResultMessage.ButtonNo;
        }

        /// <summary>
        /// The ok command handler.
        /// </summary>
        private void OkCommandHandler()
        {
            this.Result = ResultMessage.ButtonOk;
        }

        /// <summary>
        /// The retry command handler.
        /// </summary>
        private void RetryCommandHandler()
        {
            this.Result = ResultMessage.ButtonRetry;
        }

        /// <summary>
        /// The yes command handler.
        /// </summary>
        private void YesCommandHandler()
        {
            this.Result = ResultMessage.ButtonYes;
        }

        #endregion
    }
}
