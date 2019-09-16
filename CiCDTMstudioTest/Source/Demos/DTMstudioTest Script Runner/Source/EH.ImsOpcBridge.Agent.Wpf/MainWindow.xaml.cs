// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for MainWindow
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Agent.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Threading;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Threading;

    using EH.ImsOpcBridge.Agent.Wpf.DefaultHost;
    using EH.ImsOpcBridge.Agent.Wpf.Properties;
    using EH.ImsOpcBridge.Agent.Wpf.ViewModel;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.Wcf.Interfaces;

    using log4net;

    using Timer = System.Timers.Timer;

    /// <summary>
    /// Class MainWindow
    /// </summary>
    public partial class MainWindow : IDisposable, INotificationBox
    {
        #region Constants

        /// <summary>
        /// The mutex name
        /// </summary>
        private const string MutexName = "EH.ImsOpcBridge.Agent.Wpf.exe";

        #endregion

        #region Static Fields

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        /// <summary>
        /// The balloon text list
        /// </summary>
        private readonly List<string> balloonTextList = new List<string>();

        /// <summary>
        /// The mutex
        /// </summary>
        private readonly Mutex mutex;

        /// <summary>
        /// The t1
        /// </summary>
        private readonly Timer t1 = new Timer();

        /// <summary>
        /// The t1
        /// </summary>
        private readonly Timer diagnosticsTimer = new Timer();

        /// <summary>
        /// The balloon
        /// </summary>
        private Balloon balloon = new Balloon();

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.ServiceHostContainer = new ServiceHostContainer(new Uri(Settings.Default.ClientUri), typeof(ICommServerCallback), typeof(AgentHost));

            this.t1.Elapsed += this.OnTimedEvent;
            this.diagnosticsTimer.Elapsed += this.OnDiagnosticsTimer;

            // The interval for the diagnostics timer is hardcoded 15 seconds.
            this.diagnosticsTimer.Interval = 15000;
            this.diagnosticsTimer.Enabled = true;

            // show balloon at startup
            this.ShowNotification(Properties.Resources.StartingTheImsOpcBridgeAgent, PopupAnimation.Slide, 8000);

            try
            {
                this.mutex = Mutex.OpenExisting(MutexName);

                // since it hasn't thrown an exception, then we already have one copy of the app open.
                MessageBox.Show(Properties.Resources.TheImsOpcBridgeAgentIsAlreadyOpenPleaseCheckYourTaskbar);

                Environment.Exit(0);
            }
            catch (WaitHandleCannotBeOpenedException exception)
            {
                // since we didn't find a mutex with that name, create one
                // ReSharper disable InvocationIsSkipped
                if (Logger.IsDebugEnabled)
                {
                    Logger.Debug(Properties.Resources.CreationOfNewMutexFailed, exception);
                }

                // ReSharper restore InvocationIsSkipped
                this.mutex = new Mutex(true, MutexName);
            }

            var mainWindowModel = new MainWindowViewModel(this);
            this.DataContext = mainWindowModel;
            this.ServerViewControl.DataContext = mainWindowModel.ServerViewViewModel;

            try
            {
                this.ServiceHostContainer.Start();
            }
            catch (Exception exception)
            {
                var message = @"Exception in client call: " + exception.Message;
                ////mainWindowModel.Host.UserInterface.DisplayMessage(message, caption, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
           
                mainWindowModel.ServerViewViewModel.Infos.Add(message);

                mainWindowModel.IconSource = ServerViewControlViewModel.RedIcon;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MainWindow"/> class.
        /// </summary>
        ~MainWindow()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the service host container.
        /// </summary>
        /// <value>The service host container.</value>
        private ServiceHostContainer ServiceHostContainer { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
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
        /// Shows the notification.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="popupAnimation">The popup animation.</param>
        /// <param name="timeout">The timeout.</param>
        public void ShowNotification(string text, PopupAnimation popupAnimation, int timeout)
        {
            this.balloonTextList.Add(text);
            this.balloon = new Balloon();
            foreach (var ballonText in this.balloonTextList)
            {
                // ReSharper disable LocalizableElement
                if (string.IsNullOrEmpty(this.balloon.BalloonText))
                {
                    this.balloon.BalloonText = " - " + ballonText;
                }
                else
                {
                    this.balloon.BalloonText = this.balloon.BalloonText + "\n - " + ballonText;
                }

                // ReSharper restore LocalizableElement
            }

            this.t1.Enabled = false;
            this.tb.ShowCustomBalloon(this.balloon, popupAnimation, timeout);
            this.t1.Interval = timeout;
            this.t1.Enabled = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Closes the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            this.Close();

            this.mutex.ReleaseMutex();
        }

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
                }

                this.t1.Dispose();
                this.diagnosticsTimer.Dispose();
                this.mutex.Dispose();

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Determines whether the specified sender is closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void IsClosing(object sender, CancelEventArgs e)
        {
            if (this.Visibility != Visibility.Hidden)
            {
                this.ShowHideWindow(null, null);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                var mainWindowViewModel = this.DataContext as MainWindowViewModel;
                if (mainWindowViewModel != null)
                {
                    try
                    {
                        this.ServiceHostContainer.Stop();
                    }
                    catch (Exception exception)
                    {
                        var message = @"Exception in client call: " + exception.Message;
                        
                        ////mainWindowViewModel.Host.UserInterface.DisplayMessage(message, caption, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);

                        mainWindowViewModel.ServerViewViewModel.Infos.Add(message);

                        mainWindowViewModel.IconSource = ServerViewControlViewModel.RedIcon;
                    }
                }
            }
        }

        /// <summary>
        /// Called when [timed event].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            this.t1.Enabled = false;
            this.balloonTextList.Clear();
        }

        /// <summary>
        /// Called when [diagnostics timer].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void OnDiagnosticsTimer(object sender, ElapsedEventArgs e)
        {
            // The call must be synchronized with the GUI thread.
            Dispatcher.BeginInvoke(DispatcherPriority.Input, (ThreadStart)(() => this.SynchronizedDiagnosticsTimer(sender, e)));
        }

        /// <summary>
        /// Called when [diagnostics timer].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void SynchronizedDiagnosticsTimer(object sender, ElapsedEventArgs e)
        {
            var model = this.DataContext as MainWindowViewModel;
            if (model != null)
            {
                model.OnDiagnosticsTimer(sender, e);
            }
        }

        /// <summary>
        /// Shows the hide window.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ShowHideWindow(object sender, RoutedEventArgs e)
        {
            if (this.Visibility == Visibility.Hidden)
            {
                this.Visibility = Visibility.Visible;

                ////this.ShowNotification(@"Open the Agent Window.", PopupAnimation.Slide, 8000);
            }
            else
            {
                this.Visibility = Visibility.Hidden;

                ////this.ShowNotification(@"Close the Agent Window.", PopupAnimation.Slide, 8000);
            }

            // this.tb.ShowCustomBalloon(this.balloon, PopupAnimation.Slide, 8000);
        }

        /// <summary>
        /// Trays the mouse double click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            this.ShowHideWindow(sender, e);
        }

        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedParameter.Local

        /// <summary>
        /// Windows the loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "OK here.")]
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
        }

        #endregion

        // ReSharper restore UnusedParameter.Local
        // ReSharper restore UnusedMember.Local
    }
}