// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The view model of the main window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Agent.Wpf
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls.Primitives;

    using EH.ImsOpcBridge.Agent.Wpf.DefaultHost;
    using EH.ImsOpcBridge.Agent.Wpf.Properties;
    using EH.ImsOpcBridge.Agent.Wpf.ViewModel;
    using EH.ImsOpcBridge.Configurator.Interfaces;
    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.DefaultHost;
    using EH.ImsOpcBridge.Logging;

    // using EH.ImsOpcBridge.Fdt.Remote.Client.Wpf.ViewModel;

    /// <summary>
    /// Class MainWindowViewModel
    /// </summary>
    public class MainWindowViewModel : DependencyObject, IDisposable, INotificationBox
    {
        #region Static Fields

        /// <summary>
        /// The icon source property
        /// </summary>
        private static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register("IconSource", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The title property
        /// </summary>
        [Localizable(false)]
        private static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(default(string)));

        #endregion

        #region Fields

        /// <summary>
        /// The notification box provider
        /// </summary>
        private readonly INotificationBox notificationBoxProvider;

        /// <summary>
        /// The server view view model
        /// </summary>
        private readonly ServerViewControlViewModel serverViewViewModel;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The host
        /// </summary>
        private IConfiguratorHost host;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="notificationBoxProvider">The notification box provider.</param>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "OK here.")]
        public MainWindowViewModel(INotificationBox notificationBoxProvider)
        {
            var baseHost = new BaseHost();

            // ReSharper disable LocalizableElement
            baseHost.ApplicationName = @"Agent";

            this.IconSource = ServerViewControlViewModel.GreenIcon;
            this.host = new AgentHost();
            this.ServiceDataReceiver = new ServiceDataReceiver();

            // ReSharper restore LocalizableElement
            LogManager.ConfigureLogging(baseHost);
            this.notificationBoxProvider = notificationBoxProvider;
            this.Title = Resources.AgentApplicationTitle;

            this.serverViewViewModel = new ServerViewControlViewModel(notificationBoxProvider, this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        ~MainWindowViewModel()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>The host.</value>
        public IConfiguratorHost Host
        {
            get
            {
                return this.host;
            }
        }

        /// <summary>
        /// Gets or sets the icon source.
        /// </summary>
        /// <value>The icon source.</value>
        public string IconSource
        {
            get
            {
                return (string)this.GetValue(IconSourceProperty);
            }

            set
            {
                this.SetValue(IconSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets the server view view model.
        /// </summary>
        /// <value>The server view view model.</value>
        public ServerViewControlViewModel ServerViewViewModel
        {
            get
            {
                return this.serverViewViewModel;
            }
        }

        /// <summary>
        /// Gets or sets the service data receiver.
        /// </summary>
        /// <value>The service data receiver.</value>
        public ServiceDataReceiver ServiceDataReceiver { get; set; }

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
            if (this.CheckAccess())
            {
                this.notificationBoxProvider.ShowNotification(text, popupAnimation, timeout);
            }
            else
            {
                this.Dispatcher.BeginInvoke(new Action<string, PopupAnimation, int>(this.ShowNotification), new object[] { text, popupAnimation, timeout });
            }
        }

        /// <summary>
        /// Called when [diagnostics timer].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        public void OnDiagnosticsTimer(object sender, ElapsedEventArgs e)
        {
            if (this.serverViewViewModel != null)
            {
                this.serverViewViewModel.OnDiagnosticsTimer(sender, e);
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
                    this.host.Dispose();
                    this.host = null;
                }

                this.serverViewViewModel.Dispose();

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        #endregion
    }
}