// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerViewControlViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The view model of the server view control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Agent.Wpf.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using System.ServiceProcess;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Agent.Wpf.Properties;
    using EH.ImsOpcBridge.Configurator.EventArguments;
    using EH.ImsOpcBridge.UI.Wpf;

    using log4net;

    /// <summary>
    /// Class ServerViewControlViewModel
    /// </summary>
    public class ServerViewControlViewModel : DependencyObject, IDisposable, INotificationBox
    {
        #region Constants and Static Fields

        /// <summary>
        /// The green icon
        /// </summary>
        public const string GreenIcon = "/Icons/Green.ico";

        /// <summary>
        /// The red icon
        /// </summary>
        public const string RedIcon = "/Icons/Red.ico";

        /// <summary>
        /// The yellow icon
        /// </summary>
        public const string YellowIcon = "/Icons/Yellow.ico";

        /// <summary>
        /// The infos property
        /// </summary>
        public static readonly DependencyProperty InfosProperty = DependencyProperty.Register("Infos", typeof(ObservableCollection<string>), typeof(ServerViewControlViewModel), new PropertyMetadata(default(ObservableCollection<string>)));

        /// <summary>
        /// The service name
        /// </summary>
        private const string ServiceName = "EH.ImsOpcBridge";
     
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        
        #region Fields

        /// <summary>
        /// The clear
        /// </summary>
        private readonly ICommand clear;

        /// <summary>
        /// The connect
        /// </summary>
        private readonly ICommand connect;

        /// <summary>
        /// The disconnect
        /// </summary>
        private readonly ICommand disconnect;

        /// <summary>
        /// The main window view model
        /// </summary>
        private readonly MainWindowViewModel mainWindowViewModel;

        /// <summary>
        /// The notification box provider
        /// </summary>
        private readonly INotificationBox notificationBoxProvider;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerViewControlViewModel"/> class.
        /// </summary>
        /// <param name="notificationBoxProvider">
        /// The notification box provider.
        /// </param>
        /// <param name="mainWindowViewModel">
        /// The main window view model.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// @ mainWindowViewModel
        /// </exception>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here.")]
        public ServerViewControlViewModel(INotificationBox notificationBoxProvider, MainWindowViewModel mainWindowViewModel)
        {
            if (mainWindowViewModel == null)
            {
                throw new ArgumentNullException(@"mainWindowViewModel");
            }

            this.notificationBoxProvider = notificationBoxProvider;
            this.connect = new DelegateCommand(this.ConnectPressed);
            this.disconnect = new DelegateCommand(this.DisconnectPressed);
            this.clear = new DelegateCommand(this.ClearPressed);

            this.mainWindowViewModel = mainWindowViewModel;

            this.Infos = new ObservableCollection<string>();

            mainWindowViewModel.ServiceDataReceiver.ServiceErrorResponse += this.HandleServiceErrorResponse;
            mainWindowViewModel.ServiceDataReceiver.DiagnosticsResponse += this.HandleDiagnosticsResponse;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ServerViewControlViewModel"/> class.
        /// </summary>
        ~ServerViewControlViewModel()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the clear.
        /// </summary>
        /// <value>The clear.</value>
        public ICommand Clear
        {
            get
            {
                return this.clear;
            }
        }

        /// <summary>
        /// Gets the connect.
        /// </summary>
        /// <value>The connect.</value>
        public ICommand Connect
        {
            get
            {
                return this.connect;
            }
        }

        /// <summary>
        /// Gets the disconnect.
        /// </summary>
        /// <value>The disconnect.</value>
        public ICommand Disconnect
        {
            get
            {
                return this.disconnect;
            }
        }

        /// <summary>
        /// Gets or sets the infos.
        /// </summary>
        /// <value>The infos.</value>
        public ObservableCollection<string> Infos
        {
            get
            {
                return (ObservableCollection<string>)this.GetValue(InfosProperty);
            }

            set
            {
                this.SetValue(InfosProperty, value);
            }
        }

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
        /// Handles the diagnostics response.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="DiagnosticsDataEventArgs"/> instance containing the event data.
        /// </param>
        public void HandleDiagnosticsResponse(object sender, DiagnosticsDataEventArgs e)
        {
            if (e != null)
            {
                if (e.DiagnosticsMessages != null)
                {
                    foreach (var message in e.DiagnosticsMessages)
                    {
                        this.Infos.Add(message);
                    }

                    if (this.Infos.Count == 0)
                    {
                        this.SetIcon(GreenIcon);
                    }
                    else
                    {
                        this.SetIcon(YellowIcon);
                    }
                }
            }
        }

        /// <summary>
        /// Called when [diagnostics timer].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="ElapsedEventArgs"/> instance containing the event data.
        /// </param>
        public void OnDiagnosticsTimer(object sender, ElapsedEventArgs e)
        {
            this.DiagnosticsRequest();
        }

        /// <summary>
        /// Shows the notification.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="popupAnimation">
        /// The popup animation.
        /// </param>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        public void ShowNotification(string text, PopupAnimation popupAnimation, int timeout)
        {
            if (this.CheckAccess())
            {
                this.notificationBoxProvider.ShowNotification(text, popupAnimation, timeout);
            }
            else
            {
                this.Dispatcher.BeginInvoke(new Action<string, PopupAnimation, int>(this.ShowNotification), new object[] { text, popupAnimation, timeout });
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Clears the pressed.
        /// </summary>
        private void ClearPressed()
        {
            if (this.IsServiceRunning())
            {
                this.SetIcon(GreenIcon);
            }
            else
            {
                this.SetIcon(RedIcon);
            }

            this.Infos.Clear();
        }

        /// <summary>
        /// Connects the pressed.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here.")]
        private void ConnectPressed()
        {
            this.DiagnosticsRequest();
        }

        /// <summary>
        /// Diagnostic the request.
        /// </summary>
        private void DiagnosticsRequest()
        {
            try
            {
                if (this.IsServiceRunning())
                {
                    var client = new CommServerClient();
                    client.DiagnosticsRequest(Settings.Default.ClientUri, Guid.NewGuid());
                    client.Close();
                }
                else
                {
                    this.SetIcon(RedIcon);
                }
            }
            catch (Exception exception)
            {
                this.mainWindowViewModel.ServerViewViewModel.Infos.Add(exception.Message);

                ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(exception.Message, Resources.ServiceCommunicationError, MessageButton.ButtonsOk, MessageType.MessageError);
                this.SetIcon(RedIcon);

                ////MessageBox.Show("Exception in client call: " + exception.Message);
            }
        }

        /// <summary>
        /// Disconnects the pressed.
        /// </summary>
        private void DisconnectPressed()
        {
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
        /// </param>
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

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Handles the service error response.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="ServiceErrorDataEventArgs"/> instance containing the event data.
        /// </param>
        private void HandleServiceErrorResponse(object sender, ServiceErrorDataEventArgs e)
        {
            if (e.ServiceErrorData != null)
            {
                var message = e.ServiceErrorData;

                ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.ServiceCommunicationError, MessageButton.ButtonsOk, MessageType.MessageError);
                this.mainWindowViewModel.ServerViewViewModel.Infos.Add(message);
                this.SetIcon(RedIcon);
            }
        }

        /// <summary>
        /// Determines whether [is service running].
        /// </summary>
        /// <returns><c>true</c> if [is service running]; otherwise, <c>false</c>.</returns>
        private bool IsServiceRunning()
        {
            bool running;

            try
            {
                var sc = new ServiceController(ServiceName);
                running = sc.Status == ServiceControllerStatus.Running;
                sc.Close();
            }
            catch (Exception ex)
            {
                if (Logger.IsDebugEnabled)
                {
                    string logMessage = string.Format(CultureInfo.CurrentCulture, @"Exception IsServiceRunning: {0}", ex.Message);
                    Logger.Debug(logMessage);
                }

                // We just return the status.
                running = false;
            }

            return running;
        }

        /// <summary>
        /// Sets the icon.
        /// </summary>
        /// <param name="resourceName">
        /// Name of the resource.
        /// </param>
        private void SetIcon(string resourceName)
        {
            this.mainWindowViewModel.IconSource = resourceName;
        }

        #endregion
    }
}