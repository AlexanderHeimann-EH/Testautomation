// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   View model for the message box control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.UI.Wpf.Properties;

    using EnumConverter = EH.ImsOpcBridge.UI.Wpf.DataTypes.EnumConverter;

    /// <summary>
    /// View model for the message box control.
    /// </summary>
    public class MessageBoxVm : DependencyObject
    {
        #region Constants and Fields

        /// <summary>
        /// The MessageButton value.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty MessageButtonProperty = DependencyProperty.Register("MessageButton", typeof(MessageButton), typeof(MessageBoxVm), new PropertyMetadata(default(MessageButton)));

        /// <summary>
        /// The message of the message Box.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(MessageBoxVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The type of the message.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty MessageTypeProperty = DependencyProperty.Register("MessageType", typeof(MessageType), typeof(MessageBoxVm), new PropertyMetadata(default(MessageType)));

        /// <summary>
        /// The title of the message box.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("title", typeof(string), typeof(MessageBoxVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The command for Abort.
        /// </summary>
        private readonly ICommand commandAbort;

        /// <summary>
        /// The command for Cancel.
        /// </summary>
        private readonly ICommand commandCancel;

        /// <summary>
        /// The command for Ignore.
        /// </summary>
        private readonly ICommand commandIgnore;

        /// <summary>
        /// The command for No.
        /// </summary>
        private readonly ICommand commandNo;

        /// <summary>
        /// The command for OK.
        /// </summary>
        private readonly ICommand commandOk;

        /// <summary>
        /// The command for Retry.
        /// </summary>
        private readonly ICommand commandRetry;

        /// <summary>
        /// The command for Yes.
        /// </summary>
        private readonly ICommand commandYes;

        /// <summary>
        /// The default message message button.
        /// </summary>
        private readonly DefaultMessageButton defaultMessageButton;

        /// <summary>
        /// The result of the message box.
        /// </summary>
        private ResultMessage resultMessage;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxVm"/> class. == Just for Designer ===
        /// </summary>
        public MessageBoxVm()
            : this(Resources.SampleTitle, Resources.SampleMessage, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxVm"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageButton">The message button.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="defaultMessageButton">The default message button.</param>
        public MessageBoxVm(string title, string message, MessageButton messageButton, MessageType messageType, DefaultMessageButton defaultMessageButton)
        {
            this.defaultMessageButton = defaultMessageButton;
            this.resultMessage = EnumConverter.DefaultMessageButtonToResultMessage(this.defaultMessageButton);

            this.Title = title;
            this.Message = message;
            this.MessageType = messageType;
            this.MessageButton = messageButton;

            this.commandOk = new DelegateCommand(this.ButtonOkPressed);
            this.commandCancel = new DelegateCommand(this.ButtonCancelPressed);
            this.commandIgnore = new DelegateCommand(this.ButtonIgnorePressed);
            this.commandNo = new DelegateCommand(this.ButtonNoPressed);
            this.commandRetry = new DelegateCommand(this.ButtonRetryPressed);
            this.commandAbort = new DelegateCommand(this.ButtonAbortPressed);
            this.commandYes = new DelegateCommand(this.ButtonYesPressed);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the command for Abort.
        /// </summary>
        public ICommand CommandAbort
        {
            get
            {
                return this.commandAbort;
            }
        }

        /// <summary>
        /// Gets the command for Cancel.
        /// </summary>
        public ICommand CommandCancel
        {
            get
            {
                return this.commandCancel;
            }
        }

        /// <summary>
        /// Gets the command for Ignore.
        /// </summary>
        public ICommand CommandIgnore
        {
            get
            {
                return this.commandIgnore;
            }
        }

        /// <summary>
        /// Gets the command for No.
        /// </summary>
        public ICommand CommandNo
        {
            get
            {
                return this.commandNo;
            }
        }

        /// <summary>
        /// Gets the command for OK.
        /// </summary>
        public ICommand CommandOk
        {
            get
            {
                return this.commandOk;
            }
        }

        /// <summary>
        /// Gets the command for Retry.
        /// </summary>
        public ICommand CommandRetry
        {
            get
            {
                return this.commandRetry;
            }
        }

        /// <summary>
        /// Gets the command for Yes.
        /// </summary>
        public ICommand CommandYes
        {
            get
            {
                return this.commandYes;
            }
        }

        /// <summary>
        /// Gets or sets the message of the message Box.
        /// </summary>
        /// <value>The message of the message Box.</value>
        public string Message
        {
            get
            {
                return (string)this.GetValue(MessageProperty);
            }

            set
            {
                this.SetValue(MessageProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the MessageButton value.
        /// </summary>
        /// <value>The MessageButton value.</value>
        public MessageButton MessageButton
        {
            get
            {
                return (MessageButton)this.GetValue(MessageButtonProperty);
            }

            set
            {
                this.SetValue(MessageButtonProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        public MessageType MessageType
        {
            get
            {
                return (MessageType)this.GetValue(MessageTypeProperty);
            }

            set
            {
                this.SetValue(MessageTypeProperty, value);
            }
        }

        /// <summary>
        /// Gets the result of the message box.
        /// </summary>
        public ResultMessage ResultMessage
        {
            get
            {
                return this.resultMessage;
            }
        }

        /// <summary>
        /// Gets or sets the title of the message box.
        /// </summary>
        /// <value>The title of the message box.</value>
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

        #endregion

        #region Methods

        /// <summary>
        /// Called, when the button Abort is pressed.
        /// </summary>
        protected void ButtonAbortPressed()
        {
            this.resultMessage = ResultMessage.ButtonAbort;
        }

        /// <summary>
        /// Called, when the button Cancel is pressed.
        /// </summary>
        protected void ButtonCancelPressed()
        {
            this.resultMessage = ResultMessage.ButtonCancel;
        }

        /// <summary>
        /// Called, when the button Ignore is pressed.
        /// </summary>
        protected void ButtonIgnorePressed()
        {
            this.resultMessage = ResultMessage.ButtonIgnore;
        }

        /// <summary>
        /// Called, when the button No is pressed.
        /// </summary>
        protected void ButtonNoPressed()
        {
            this.resultMessage = ResultMessage.ButtonNo;
        }

        /// <summary>
        /// Called, when the button OK is pressed.
        /// </summary>
        protected void ButtonOkPressed()
        {
            this.resultMessage = ResultMessage.ButtonOk;
        }

        /// <summary>
        /// Called, when the button Retry is pressed.
        /// </summary>
        protected void ButtonRetryPressed()
        {
            this.resultMessage = ResultMessage.ButtonRetry;
        }

        /// <summary>
        /// Called, when the button Yes is pressed.
        /// </summary>
        protected void ButtonYesPressed()
        {
            this.resultMessage = ResultMessage.ButtonYes;
        }

        #endregion
    }
}
