// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageAgentVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Change the AgentMode enumeration will change the visibilities of the Controls.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Threading;

    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;
    using EH.ImsOpcBridge.UI.Wpf.ViewModel;

    /// <summary>
    /// Enum AgentMode
    /// </summary>
    public enum AgentMode
    {
        /// <summary>
        /// The list
        /// </summary>
        List,

        /// <summary>
        /// The single
        /// </summary>
        Single,

        /// <summary>
        /// The none
        /// </summary>
        None
    }

    /// <summary>
    /// Class MessageAgentVm
    /// </summary>
    public class MessageAgentVm : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The agent mode property
        /// </summary>
        public static readonly DependencyProperty AgentModeProperty = DependencyProperty.Register("AgentMode", typeof(AgentMode), typeof(MessageAgentVm), new PropertyMetadata(AgentMode.None));

        /// <summary>
        /// The background color property
        /// </summary>
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(string), typeof(MessageAgentVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The current message text property
        /// </summary>
        public static readonly DependencyProperty CurrentMessageTextProperty = DependencyProperty.Register("CurrentMessageText", typeof(string), typeof(MessageAgentVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The current time property
        /// </summary>
        public static readonly DependencyProperty CurrentTimeProperty = DependencyProperty.Register("CurrentTime", typeof(string), typeof(MessageAgentVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The foreground color property
        /// </summary>
        public static readonly DependencyProperty ForegroundColorProperty = DependencyProperty.Register("ForegroundColor", typeof(string), typeof(MessageAgentVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The is portable property
        /// </summary>
        public static readonly DependencyProperty IsPortableProperty = DependencyProperty.Register("IsPortable", typeof(bool), typeof(MessageAgentVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The messages property
        /// </summary>
        public static readonly DependencyProperty MessagesProperty = DependencyProperty.Register("Messages", typeof(ObservableCollection<string>), typeof(MessageAgentVm), new PropertyMetadata(default(ObservableCollection<string>)));

        /// <summary>
        /// The progress text property
        /// </summary>
        public static readonly DependencyProperty ProgressTextProperty = DependencyProperty.Register("ProgressText", typeof(string), typeof(MessageAgentVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The progress value property
        /// </summary>
        public static readonly DependencyProperty ProgressValueProperty = DependencyProperty.Register("ProgressValue", typeof(int), typeof(MessageAgentVm), new PropertyMetadata(default(int)));

        /// <summary>
        /// The progress view model property
        /// </summary>
        public static readonly DependencyProperty ProgressViewModelProperty = DependencyProperty.Register("ProgressViewModel", typeof(ProgressVm), typeof(MessageAgentVm), new PropertyMetadata(default(ProgressVm)));

        /// <summary>
        /// The show list button text property
        /// </summary>
        public static readonly DependencyProperty ShowListButtonTextProperty = DependencyProperty.Register("ShowListButtonText", typeof(string), typeof(MessageAgentVm), new PropertyMetadata(default(string)));

        #endregion

        #region Fields

        /// <summary>
        /// The power
        /// </summary>
        private readonly PowerStatus power = SystemInformation.PowerStatus;

        /// <summary>
        /// The show list command
        /// </summary>
        private readonly DelegateCommand showListCommand;

        /// <summary>
        /// The timer message
        /// </summary>
        private readonly DispatcherTimer timerMessage;

        /// <summary>
        /// The timer time
        /// </summary>
        private readonly DispatcherTimer timerTime;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The main window vm
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Justification = @"OK here.")]
        private MainWindowVm mainWindowVm;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageAgentVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException">@ mainWindowVm</exception>
        public MessageAgentVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.mainWindowVm = mainWindowVm;
            this.ProgressViewModel = mainWindowVm.ProgressViewModel;

            this.AgentMode = AgentMode.None;

            this.timerMessage = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10.0) };
            this.timerMessage.Tick += this.TimerTickEventHandlerMessage;

            this.timerTime = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.0) };
            this.timerTime.Start();
            this.timerTime.Tick += this.TimerTickEventHandlerTime;

            this.showListCommand = new DelegateCommand(this.ShowListCommandPressed);
            this.Messages = new ObservableCollection<string>();
            this.ShowListButtonText = ">";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the agent mode.
        /// </summary>
        /// <value>The agent mode.</value>
        public AgentMode AgentMode
        {
            get
            {
                return (AgentMode)this.GetValue(AgentModeProperty);
            }

            set
            {
                // ReSharper disable LocalizableElement
                if (value == AgentMode.None)
                {
                    this.BackgroundColor = @"#8fa2ac";
                    this.ForegroundColor = @"#ffffff";
                }

                // ReSharper restore LocalizableElement
                this.SetValue(AgentModeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public string BackgroundColor
        {
            get
            {
                return (string)this.GetValue(BackgroundColorProperty);
            }

            set
            {
                this.SetValue(BackgroundColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current message text.
        /// </summary>
        /// <value>The current message text.</value>
        public string CurrentMessageText
        {
            get
            {
                return (string)this.GetValue(CurrentMessageTextProperty);
            }

            set
            {
                this.SetValue(CurrentMessageTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current time.
        /// </summary>
        /// <value>The current time.</value>
        public string CurrentTime
        {
            get
            {
                return (string)this.GetValue(CurrentTimeProperty);
            }

            set
            {
                this.SetValue(CurrentTimeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the foreground.
        /// </summary>
        /// <value>The color of the foreground.</value>
        public string ForegroundColor
        {
            get
            {
                return (string)this.GetValue(ForegroundColorProperty);
            }

            set
            {
                this.SetValue(ForegroundColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is portable.
        /// </summary>
        /// <value><c>true</c> if this instance is portable; otherwise, <c>false</c>.</value>
        public bool IsPortable
        {
            get
            {
                return (bool)this.GetValue(IsPortableProperty);
            }

            set
            {
                this.SetValue(IsPortableProperty, value);
            }
        }

        /// <summary>
        /// Gets the messages.
        /// </summary>
        /// <value>The messages.</value>
        public ObservableCollection<string> Messages
        {
            get
            {
                return (ObservableCollection<string>)this.GetValue(MessagesProperty);
            }

            private set
            {
                this.SetValue(MessagesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the progress text.
        /// </summary>
        /// <value>The progress text.</value>
        public string ProgressText
        {
            get
            {
                return (string)this.GetValue(ProgressTextProperty);
            }

            set
            {
                this.SetValue(ProgressTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the progress value.
        /// </summary>
        /// <value>The progress value.</value>
        public int ProgressValue
        {
            get
            {
                return (int)this.GetValue(ProgressValueProperty);
            }

            set
            {
                this.SetValue(ProgressValueProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the progress view model.
        /// </summary>
        /// <value>The progress view model.</value>
        public ProgressVm ProgressViewModel
        {
            get
            {
                return (ProgressVm)this.GetValue(ProgressViewModelProperty);
            }

            set
            {
                this.SetValue(ProgressViewModelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the show list button text.
        /// </summary>
        /// <value>The show list button text.</value>
        public string ShowListButtonText
        {
            get
            {
                return (string)this.GetValue(ShowListButtonTextProperty);
            }

            set
            {
                this.SetValue(ShowListButtonTextProperty, value);
            }
        }

        /// <summary>
        /// Gets the show list command.
        /// </summary>
        /// <value>The show list command.</value>
        public ICommand ShowListCommand
        {
            get
            {
                return this.showListCommand;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Users the interface on toggle message agent.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="messageAgentEventArgs">The <see cref="MessageAgentEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.ArgumentNullException">@ messageAgentEventArgs</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">@ messageAgentEventArgs</exception>
        public void UserInterfaceOnToggleMessageAgent(object sender, MessageAgentEventArgs messageAgentEventArgs)
        {
            if (messageAgentEventArgs == null)
            {
                throw new ArgumentNullException(@"messageAgentEventArgs");
            }

            this.timerMessage.Stop();

            var messageLines = messageAgentEventArgs.Message.Split(new[] { Environment.NewLine }, 0);
            string message;

            if (messageLines.Length > 1)
            {
                // ReSharper disable LocalizableElement
                message = messageLines[0] + @"...";

                // ReSharper restore LocalizableElement
            }
            else
            {
                message = messageAgentEventArgs.Message;
            }

            this.CurrentMessageText = Resources.MESSAGE + message;
            this.Messages.Insert(0, DateTime.Now + " - " + message);

            switch (messageAgentEventArgs.MessageType)
            {
                case MessageType.MessageExclamation:
                    this.BackgroundColor = @"#007CAA";
                    this.ForegroundColor = @"#ffffff";

                    ////this.BackgroundColor = @"#e94c0a";
                    ////this.ForegroundColor = @"#ffffff";
                    break;
                case MessageType.MessageInformation:
                    this.BackgroundColor = @"#007CAA";
                    this.ForegroundColor = @"#ffffff";

                    ////this.BackgroundColor = @"#0099ff";
                    ////this.ForegroundColor = @"#ffffff";
                    break;
                case MessageType.MessageQuestion:
                    this.BackgroundColor = @"#007CAA";
                    this.ForegroundColor = @"#ffffff";

                    ////this.BackgroundColor = @"#0099ff";
                    ////this.ForegroundColor = @"#ffffff";
                    break;
                case MessageType.MessageStop:
                    this.BackgroundColor = @"#007CAA";
                    this.ForegroundColor = @"#ffffff";
                    break;
                case MessageType.MessageAsterix:
                    this.BackgroundColor = @"#007CAA";
                    this.ForegroundColor = @"#ffffff";

                    ////this.BackgroundColor = @"#0099ff";
                    ////this.ForegroundColor = @"#ffffff";
                    break;
                case MessageType.MessageError:
                    this.BackgroundColor = @"#007CAA";
                    this.ForegroundColor = @"#ffffff";

                    ////this.BackgroundColor = @"#e94c0a";
                    ////this.ForegroundColor = @"#ffffff";
                    break;
                case MessageType.MessageHand:
                    this.BackgroundColor = @"#007CAA";
                    this.ForegroundColor = @"#ffffff";

                    ////this.BackgroundColor = @"#0099ff";
                    ////this.ForegroundColor = @"#ffffff";
                    break;
                case MessageType.MessageNone:
                    this.BackgroundColor = @"#007CAA";
                    this.ForegroundColor = @"#ffffff";

                    ////this.BackgroundColor = @"#506771";
                    ////this.ForegroundColor = @"#ffffff";
                    break;
                case MessageType.MessageWarning:
                    this.BackgroundColor = @"#007CAA";
                    this.ForegroundColor = @"#ffffff";

                    ////this.BackgroundColor = @"#ffe596";
                    ////this.ForegroundColor = @"#ffffff";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(@"messageAgentEventArgs");
            }

            if (this.AgentMode != AgentMode.List)
            {
                this.AgentMode = AgentMode.Single;

                this.timerMessage.Start();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    this.timerTime.Stop();
                    this.timerTime.Tick -= this.TimerTickEventHandler;
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Shows the list command pressed.
        /// </summary>
        private void ShowListCommandPressed()
        {
            if (this.AgentMode == AgentMode.None || this.AgentMode == AgentMode.Single)
            {
                this.AgentMode = AgentMode.List;
                this.ShowListButtonText = "v";
            }
            else
            {
                this.AgentMode = AgentMode.None;
                this.ShowListButtonText = ">";
            }
        }

        /// <summary>
        /// Timers the tick event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TimerTickEventHandler(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Timers the tick event handler message.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TimerTickEventHandlerMessage(object sender, EventArgs e)
        {
            if (this.AgentMode == AgentMode.Single)
            {
                this.AgentMode = AgentMode.None;
            }

            this.timerMessage.Stop();
        }

        /// <summary>
        /// Timers the tick event handler time.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TimerTickEventHandlerTime(object sender, EventArgs e)
        {
            var hoursMinutes = DateTime.Now;
            this.CurrentTime = hoursMinutes.ToString(@"g", CultureInfo.CurrentCulture);

            //// this.CurrentTime = DateTime.Now.ToShortTimeString();
        }

        #endregion
    }
}