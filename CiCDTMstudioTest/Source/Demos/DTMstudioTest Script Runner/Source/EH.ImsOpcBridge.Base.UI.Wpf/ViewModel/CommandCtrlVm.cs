// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandCtrlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Exceptions;
    using EH.ImsOpcBridge.UI.Wpf.Properties;

    using log4net;

    /// <summary>
    /// View model for the command ctrl
    /// </summary>
    public class CommandCtrlVm : DependencyObject, IDisposable
    {
        #region Constants and Fields

        /// <summary>
        /// The button items property.
        /// </summary>
        public static readonly DependencyProperty ButtonItemsProperty = DependencyProperty.Register("ButtonItems", typeof(ObservableCollection<CommandItemVm>), typeof(CommandCtrlVm), new PropertyMetadata(default(ObservableCollection<CommandItemVm>)));

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The command provider.
        /// </summary>
        private ICommandProvider commandProvider;

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCtrlVm"/> class.
        /// </summary>
        public CommandCtrlVm()
        {
            this.ButtonItems = new ObservableCollection<CommandItemVm>();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="CommandCtrlVm"/> class.
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="CommandCtrlVm"/> is reclaimed by garbage collection.
        /// </summary>
        ~CommandCtrlVm()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets ButtonItems.
        /// </summary>
        public ObservableCollection<CommandItemVm> ButtonItems
        {
            get
            {
                return (ObservableCollection<CommandItemVm>)this.GetValue(ButtonItemsProperty);
            }

            private set
            {
                this.SetValue(ButtonItemsProperty, value);
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
        /// Create the command buttons and set command provider.
        /// </summary>
        /// <param name="cmdProvider">The command provider.</param>
        public void SetCommandProvider(ICommandProvider cmdProvider)
        {
            try
            {
                // Is it another provider one than before?
                if (this.commandProvider != cmdProvider)
                {
                    // If we had already a provider, then unregister from events. 
                    if (this.commandProvider != null)
                    {
                        this.commandProvider.CommandAdded -= this.OnCommandAdded;
                        this.commandProvider.CommandRemoved -= this.OnCommandRemoved;
                    }

                    // No or new provider, so remove all child buttons.
                    foreach (var buttonItem in this.ButtonItems)
                    {
                        buttonItem.Dispose();
                    }

                    this.ButtonItems.Clear();

                    // Set new provider.
                    this.commandProvider = cmdProvider;

                    // New provider?
                    if (this.commandProvider != null)
                    {
                        // Register to events of new provider.
                        this.commandProvider.CommandAdded += this.OnCommandAdded;
                        this.commandProvider.CommandRemoved += this.OnCommandRemoved;

                        // Add new buttons according to commands of new provider.
                        foreach (var commandItem in this.commandProvider.Commands)
                        {
                            this.ButtonItems.Add(new CommandItemVm(commandItem));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Logger.IsErrorEnabled)
                {
                    Logger.Error(Resources.CreationOfCommandButtonListFailed, ex);
                }

                throw;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">If equals true, method is called directly or indirectly
        /// by a user's code. If equals to false, method is called by the runtime from inside
        /// a finalizer.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    if (this.commandProvider != null)
                    {
                        this.commandProvider.CommandAdded -= this.OnCommandAdded;
                        this.commandProvider.CommandRemoved -= this.OnCommandRemoved;
                    }

                    foreach (var buttonItem in this.ButtonItems)
                    {
                        buttonItem.Dispose();
                    }

                    this.ButtonItems.Clear();
                    this.ButtonItems = null;
                }
            }

            this.disposed = true;
        }

        /// <summary>
        /// The handles the CommandAdded event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnCommandAdded(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.Command.ParentCommand == this.commandProvider)
                {
                    if (this.Dispatcher.CheckAccess())
                    {
                        this.ButtonItems.Add(new CommandItemVm(e.Command));
                    }
                    else
                    {
                        this.Dispatcher.BeginInvoke((Action)(() => this.OnCommandAdded(sender, e)));
                    }
                }
            }
            catch (Exception ex)
            {
                var message = Resources.HandlingOfCommandAddedEventFailed;

                if (Logger.IsErrorEnabled)
                {
                    Logger.Error(message, ex);
                }

                throw new BaseException(message, ex);
            }
        }

        /// <summary>
        /// Handles the CommandRemoved event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnCommandRemoved(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.Command.ParentCommand == this.commandProvider)
                {
                    if (this.Dispatcher.CheckAccess())
                    {
                        lock (this.ButtonItems)
                        {
                            var buttons = new CommandItemVm[this.ButtonItems.Count];
                            this.ButtonItems.CopyTo(buttons, 0);
                            foreach (var buttonItem in buttons.Where(buttonItem => buttonItem.CommandItem == e.Command))
                            {
                                this.ButtonItems.Remove(buttonItem);
                                buttonItem.Dispose();
                            }
                        }
                    }
                    else
                    {
                        this.Dispatcher.BeginInvoke((Action)(() => this.OnCommandRemoved(sender, e)));
                    }
                }
            }
            catch (Exception ex)
            {
                var message = Resources.HandlingOfCommandRemovedEventFailed;

                if (Logger.IsErrorEnabled)
                {
                    Logger.Error(message, ex);
                }

                throw new BaseException(message, ex);
            }
        }

        #endregion
    }
}
