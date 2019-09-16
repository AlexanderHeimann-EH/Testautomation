// <copyright file="UIHost.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.UI.Wpf
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Windows;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.UI.Wpf.DataTypes;
    using EH.ImsOpcBridge.UI.Wpf.Services;
    using EH.ImsOpcBridge.UI.Wpf.View;
    using EH.ImsOpcBridge.UI.Wpf.ViewModel;

    /// <summary>
    /// The default WPF implementation of the handler for user interface callbacks to the hosting application.
    /// </summary>
    public class UIHost : DependencyObject, IUIHost
    {
        #region Fields

        /// <summary>
        /// The base host
        /// </summary>
        private readonly IBaseHost baseHost;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UIHost" /> class.
        /// </summary>
        /// <param name="baseHost">The base host.</param>
        public UIHost(IBaseHost baseHost)
        {
            this.baseHost = baseHost;
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The toggle message agent.
        /// </summary>
        public event EventHandler<MessageAgentEventArgs> ToggleMessageAgent;

        /// <summary>
        /// Occurs when the application should fade out or in because of a message box
        /// </summary>
        public event EventHandler<MessageBoxShadowEventArgs> ToggleMessageBoxShadow;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the base host.
        /// </summary>
        /// <value>The base host.</value>
        public IBaseHost BaseHost
        {
            get
            {
                return this.baseHost;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates the busy indicator.
        /// </summary>
        /// <returns>The interface to the busy indicator.</returns>
        public IBusyIndicator CreateBusyIndicator()
        {
            return new BusyIndicator(this);
        }

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="message">The message to display in the message box.</param>
        /// <param name="caption">The caption to display in the title bar of the message box.</param>
        /// <param name="button">One of the <see cref="MessageButton" /> values that specifies which buttons to display in the message box.</param>
        /// <param name="messageType">One of the <see cref="MessageType" /> values that specifies which image to display in the message box.</param>
        /// <returns>One of the <see cref="ResultMessage" /> values.</returns>
        public ResultMessage DisplayMessage(string message, string caption, MessageButton button, MessageType messageType)
        {
            if (this.baseHost.IsService)
            {
                return EnumConverter.MessageButtonToDefaultResultMessage(button);
            }

            if (!this.Dispatcher.CheckAccess())
            {
                return (ResultMessage)this.Dispatcher.Invoke((Func<ResultMessage>)(() => this.DisplayMessage(message, caption, button, messageType)));
            }

            var viewModel = new MessageBoxVm(caption, message, button, messageType, DefaultMessageButton.ButtonNone);
            var view = new MessageBoxVw { DataContext = viewModel };
            var toggleMessageAgent = this.ToggleMessageAgent;
            if ((button == MessageButton.ButtonsOk) && (toggleMessageAgent != null))
            {
                this.OnToggleMessageAgent(true, message, messageType);
            }
            else
            {
                if ((Application.Current != null) && (Application.Current.MainWindow != null))
                {
                    view.Owner = Application.Current.MainWindow;
                    view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                }
                else
                {
                    view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                }

                this.OnToggleMessageBoxShadow(true);
                view.ShowDialog();
                this.OnToggleMessageBoxShadow(false);
            }

            return viewModel.ResultMessage;
        }

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="message">The message to display in the message box.</param>
        /// <param name="caption">The caption to display in the title bar of the message box.</param>
        /// <param name="button">One of the <see cref="MessageButton" /> values that specifies which buttons to display in the message box.</param>
        /// <param name="messageType">One of the <see cref="MessageType" /> values that specifies which image to display in the message box.</param>
        /// <param name="defaultResult">Default result.</param>
        /// <returns>One of the <see cref="ResultMessage" /> values.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = @"OK here.")]
        public ResultMessage DisplayMessage(string message, string caption, MessageButton button, MessageType messageType, DefaultMessageButton defaultResult)
        {
            if (this.baseHost.IsService)
            {
                return EnumConverter.DefaultMessageButtonToResultMessage(defaultResult);
            }

            if (!this.Dispatcher.CheckAccess())
            {
                return (ResultMessage)this.Dispatcher.Invoke((Func<ResultMessage>)(() => this.DisplayMessage(message, caption, button, messageType, defaultResult)));
            }

            var viewModel = new MessageBoxVm(caption, message, button, messageType, defaultResult);
            var view = new MessageBoxVw { DataContext = viewModel };
            var toggleMessageAgent = this.ToggleMessageAgent;
            if ((button == MessageButton.ButtonsOk) && (toggleMessageAgent != null))
            {
                this.OnToggleMessageAgent(true, message, messageType);
            }
            else
            {
                if ((Application.Current != null) && (Application.Current.MainWindow != null))
                {
                    try
                    {
                        view.Owner = Application.Current.MainWindow;
                        view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    }
                    catch (Exception)
                    {
                        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    }
                }
                else
                {
                    view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                }

                this.OnToggleMessageBoxShadow(true);
                view.ShowDialog();
                this.OnToggleMessageBoxShadow(false);

                view.DataContext = null;
            }

            return viewModel.ResultMessage;
        }

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="owner">Owner window</param>
        /// <param name="message">The message to display in the message box.</param>
        /// <param name="caption">The caption to display in the title bar of the message box.</param>
        /// <param name="button">One of the <see cref="MessageButton" /> values that specifies which buttons to display in the message box.</param>
        /// <param name="messageType">One of the <see cref="MessageType" /> values that specifies which image to display in the message box.</param>
        /// <param name="defaultResult">Default result.</param>
        /// <returns>One of the <see cref="ResultMessage" /> values.</returns>
        public ResultMessage DisplayMessage(Window owner, string message, string caption, MessageButton button, MessageType messageType, DefaultMessageButton defaultResult)
        {
            if (this.baseHost.IsService)
            {
                return EnumConverter.DefaultMessageButtonToResultMessage(defaultResult);
            }

            if (!this.Dispatcher.CheckAccess())
            {
                return (ResultMessage)this.Dispatcher.Invoke((Func<ResultMessage>)(() => this.DisplayMessage(owner, message, caption, button, messageType, defaultResult)));
            }

            var viewModel = new MessageBoxVm(caption, message, button, messageType, defaultResult);
            var view = new MessageBoxVw { DataContext = viewModel, Owner = owner };
            var toggleMessageAgent = this.ToggleMessageAgent;
            if ((button == MessageButton.ButtonsOk) && (toggleMessageAgent != null))
            {
                this.OnToggleMessageAgent(true, message, messageType);
            }
            else
            {
                if (view.Owner == null)
                {
                    if ((Application.Current != null) && (Application.Current.MainWindow != null))
                    {
                        view.Owner = Application.Current.MainWindow;
                        view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    }
                    else
                    {
                        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    }
                }
                else
                {
                    view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                }

                this.OnToggleMessageBoxShadow(true);
                view.ShowDialog();
                this.OnToggleMessageBoxShadow(false);
            }

            return viewModel.ResultMessage;
        }

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="owner">Owner window</param>
        /// <param name="message">The message to display in the message box.</param>
        /// <param name="caption">The caption to display in the title bar of the message box.</param>
        /// <param name="button">One of the <see cref="MessageButton" /> values that specifies which buttons to display in the message box.</param>
        /// <param name="messageType">One of the <see cref="MessageType" /> values that specifies which image to display in the message box.</param>
        /// <returns>One of the <see cref="ResultMessage" /> values.</returns>
        public ResultMessage DisplayMessage(Window owner, string message, string caption, MessageButton button, MessageType messageType)
        {
            if (this.baseHost.IsService)
            {
                return EnumConverter.MessageButtonToDefaultResultMessage(button);
            }

            if (!this.Dispatcher.CheckAccess())
            {
                return (ResultMessage)this.Dispatcher.Invoke((Func<ResultMessage>)(() => this.DisplayMessage(owner, message, caption, button, messageType)));
            }

            var viewModel = new MessageBoxVm(caption, message, button, messageType, DefaultMessageButton.ButtonNone);
            var view = new MessageBoxVw { DataContext = viewModel, Owner = owner };
            var toggleMessageAgent = this.ToggleMessageAgent;
            if ((button == MessageButton.ButtonsOk) && (toggleMessageAgent != null))
            {
                this.OnToggleMessageAgent(true, message, messageType);
            }
            else
            {
                if (view.Owner == null)
                {
                    if ((Application.Current != null) && (Application.Current.MainWindow != null))
                    {
                        view.Owner = Application.Current.MainWindow;
                        view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    }
                    else
                    {
                        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    }
                }
                else
                {
                    view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                }

                this.OnToggleMessageBoxShadow(true);
                view.ShowDialog();
                this.OnToggleMessageBoxShadow(false);
            }

            return viewModel.ResultMessage;
        }

        /// <summary>
        /// Process the UI events.
        /// </summary>
        public void DoEvents()
        {
            System.Windows.Forms.Application.DoEvents();
        }

        /// <summary>
        /// Waits for event and performs the UI events.
        /// </summary>
        /// <param name="autoResetEvent">The auto reset event to wait for.</param>
        /// <param name="timeSpan">The time span to wait until timeout occurs.</param>
        /// <returns>True, if event has been set in time. False if timeout occurred.</returns>
        public bool WaitForEventAndDoEvents(AutoResetEvent autoResetEvent, TimeSpan timeSpan)
        {
            if (autoResetEvent == null)
            {
                throw new ArgumentNullException(@"autoResetEvent");
            }

            var startTime = DateTime.Now;
            try
            {
                while (!autoResetEvent.WaitOne(100))
                {
                    this.DoEvents();
                    if (DateTime.Now - startTime > timeSpan)
                    {
                        return false;
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Waits and performs the UI events.
        /// </summary>
        /// <param name="waitWhileTrue">If set to true, the function still waits.</param>
        /// <param name="timeSpan">The time span to wait until timeout occurs.</param>
        /// <returns>True, if event has been set in time. False if timeout occurred.</returns>
        public bool WaitWhileTrueAndDoEvents(Func<bool> waitWhileTrue, TimeSpan timeSpan)
        {
            if (waitWhileTrue == null)
            {
                throw new ArgumentNullException(@"waitWhileTrue");
            }

            var startTime = DateTime.Now;
            while (waitWhileTrue())
            {
                this.DoEvents();
                if (DateTime.Now - startTime > timeSpan)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on toggle message agent.
        /// </summary>
        /// <param name="showAgent">The show agent.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageType">Type of the message.</param>
        private void OnToggleMessageAgent(bool showAgent, string message, MessageType messageType)
        {
            var toggleMessageAgent = this.ToggleMessageAgent;

            if (toggleMessageAgent != null)
            {
                toggleMessageAgent(this, new MessageAgentEventArgs(showAgent, message, messageType));
            }
        }

        /// <summary>
        /// Called when ToggleMessageBoxShadow should be fired.
        /// </summary>
        /// <param name="showShadow">if set to <c>true</c> the application should be faded out else it should be faded in.</param>
        private void OnToggleMessageBoxShadow(bool showShadow)
        {
            var toggleMessageBoxShadow = this.ToggleMessageBoxShadow;

            if (toggleMessageBoxShadow != null)
            {
                toggleMessageBoxShadow(this, new MessageBoxShadowEventArgs(showShadow));
            }
        }

        #endregion
    }
}
