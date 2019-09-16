// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Agent.Wpf
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls.Primitives;

    using EH.ImsOpcBridge.Agent.Wpf.Properties;

    using EH.ImsOpcBridge.DefaultHost;
    //using EH.ImsOpcBridge.Fdt.Remote.Client.Wpf.ViewModel;
    using EH.ImsOpcBridge.Logging;

    /// <summary>
    /// The view model of the main window.
    /// </summary> 
    public class MainWindowViewModel : DependencyObject, IDisposable, INotificationBox
    {
        #region Constants and Fields

        /// <summary>
        /// The title property.
        /// </summary>
        [Localizable(false)]
        private static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The provider to open notification box.
        /// </summary>
        private readonly INotificationBox notificationBoxProvider;

        /// <summary>
        /// The view model for the server view control.
        /// </summary>
       // private readonly ServerViewControlViewModel serverViewViewModel;

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

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

            // ReSharper restore LocalizableElement
            LogManager.ConfigureLogging(baseHost);
            this.notificationBoxProvider = notificationBoxProvider;
            this.Title = "AgentApplicationTitle";

            ///Resources.AgentApplicationTitle;
            // this.serverViewViewModel = new ServerViewControlViewModel(notificationBoxProvider);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MainWindowViewModel"/> class. Releases unmanaged resources and performs other cleanup operations before the <see cref="MainWindowViewModel"/> is reclaimed by garbage collection.
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

        /////// <summary>
        /////// Gets the view model for the server view control.
        /////// </summary>
        ////public ServerViewControlViewModel ServerViewViewModel
        ////{
        ////    get
        ////    {
        ////        return this.serverViewViewModel;
        ////    }
        ////}

        /// <summary>
        /// Gets or sets Title.
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
        /// Shuts this instance down.
        /// </summary>
        public void Shutdown()
        {
           // this.serverViewViewModel.Shutdown();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios. If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed. If disposing equals false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">If equals true, method is called directly or indirectly by a user's code. If equals to false, method is called by the runtime from inside a finalizer.</param>
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

             //   this.serverViewViewModel.Dispose();

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