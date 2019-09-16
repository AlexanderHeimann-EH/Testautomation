// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandProvider.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The command provider, which holds a collection of commands.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Commands
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    using EH.ImsOpcBridge.Delegates;
    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Properties;

    using log4net;

    /// <summary>
    /// The command provider, which holds a collection of commands.
    /// </summary>
    public class CommandProvider : ICommandProvider
    {
        #region Constants and Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The commands.
        /// </summary>
        private readonly Collection<ICommandItem> commands = new Collection<ICommandItem>();

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Finalizes an instance of the <see cref="CommandProvider"/> class.
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="CommandProvider"/> is reclaimed by garbage collection.
        /// </summary>
        ~CommandProvider()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Fired when a new command is added.
        /// </summary>
        public event EventHandler<CommandEventArgs> CommandAdded;

        /// <summary>
        /// Fired when a new command has changed.
        /// </summary>
        public event EventHandler<CommandEventArgs> CommandChanged;

        /// <summary>
        /// Fired when a new command is removed.
        /// </summary>
        public event EventHandler<CommandEventArgs> CommandRemoved;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the commands.
        /// </summary>
        public ReadOnlyCollection<ICommandItem> Commands
        {
            get
            {
                var commandQuery = from commandItem in this.commands orderby commandItem.SortIndex ascending select commandItem;
                return new ReadOnlyCollection<ICommandItem>(commandQuery.ToArray());
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <param name="commandSortIndex">The sort index, defining the sequence of the items to appear.</param>
        /// <param name="commandText">The commandText.</param>
        /// <param name="commandDescription">The commandDescription.</param>
        /// <param name="commandDoProc">The command procedure to be called to execute the command.</param>
        /// <param name="commandIcon">The icon of the command.</param>
        /// <returns>The new command item.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here.")]
        public ICommandItem AddCommand(string id, int commandSortIndex, ITranslatableString commandText, ITranslatableString commandDescription, CommandProc commandDoProc, Icon commandIcon)
        {
            var newItem = new CommandItem(id, commandSortIndex, commandText, commandDescription, commandDoProc, commandIcon);
            return this.AddCommand(newItem);
        }

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <param name="commandSortIndex">The sort index, defining the sequence of the items to appear.</param>
        /// <param name="commandText">The commandText.</param>
        /// <param name="commandDescription">The commandDescription.</param>
        /// <param name="commandDoProc">The command procedure to be called to execute the command.</param>
        /// <returns>The new command item.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here.")]
        public ICommandItem AddCommand(string id, int commandSortIndex, ITranslatableString commandText, ITranslatableString commandDescription, CommandProc commandDoProc)
        {
            var newItem = new CommandItem(id, commandSortIndex, commandText, commandDescription, commandDoProc);
            return this.AddCommand(newItem);
        }

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="commandItem">The command item.</param>
        /// <returns>The new command item.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "OK here.")]
        public ICommandItem AddCommand(ICommandItem commandItem)
        {
            if (commandItem == null)
            {
                throw new ArgumentNullException(@"commandItem");
            }

            lock (this.commands)
            {
                this.commands.Add(commandItem);
                commandItem.CommandAdded += this.HandleCommandAdded;
                commandItem.CommandRemoved += this.HandleCommandRemoved;
                commandItem.CommandChanged += this.HandleCommandChanged;
                this.OnCommandAdded(commandItem);
            }

            return commandItem;
        }
        
        /// <summary>
        /// Finds the command by the unique command id.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <returns>The command with the specified id.</returns>
        public ICommandItem FindCommand(string id)
        {
            var foundCommands = this.FindCommands(id);
            return foundCommands.FirstOrDefault();
        }

        /// <summary>
        /// Finds the command by the unique command id.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <returns>The list of commands with the specified id.</returns>
        public ReadOnlyCollection<ICommandItem> FindCommands(string id)
        {
            var foundCommands = new Collection<ICommandItem>();

            foreach (var command in this.Commands)
            {
                var commandItems = command.FindCommands(id);

                foreach (var commandItem in commandItems)
                {
                    foundCommands.Add(commandItem);
                }
            }

            return new ReadOnlyCollection<ICommandItem>(foundCommands);
        }

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
        /// Removes the command item.
        /// </summary>
        /// <param name="commandItem">The command item to be removed.</param>
        public void RemoveCommand(ICommandItem commandItem)
        {
            if (commandItem == null)
            {
                throw new ArgumentNullException(@"commandItem");
            }

            lock (this.commands)
            {
                if (this.commands.Contains(commandItem))
                {
                    commandItem.CommandAdded -= this.HandleCommandAdded;
                    commandItem.CommandRemoved -= this.HandleCommandRemoved;
                    commandItem.CommandChanged -= this.HandleCommandChanged;
                    this.commands.Remove(commandItem);
                    this.OnCommandRemoved(commandItem);
                    commandItem.Dispose();
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when a command item has been added.
        /// </summary>
        /// <param name="commandItem">The command Item.</param>
        protected void OnCommandAdded(ICommandItem commandItem)
        {
            if (commandItem == null)
            {
                throw new ArgumentNullException(@"commandItem");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.CommandItem_HasBeenAdded, commandItem.Text);
                Logger.Debug(message);
            }

            var commandChanged = this.CommandAdded;

            if (commandChanged != null)
            {
                commandChanged(null, new CommandEventArgs(commandItem));
            }
        }

        /// <summary>
        /// Called when a command item has changed.
        /// </summary>
        /// <param name="commandItem">The command Item.</param>
        protected void OnCommandChanged(ICommandItem commandItem)
        {
            if (commandItem == null)
            {
                throw new ArgumentNullException(@"commandItem");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.CommandItem_HasChanged, commandItem.Text);
                Logger.Debug(message);
            }

            var commandChanged = this.CommandChanged;

            if (commandChanged != null)
            {
                commandChanged(null, new CommandEventArgs(commandItem));
            }
        }

        /// <summary>
        /// Called when a command item has been removed.
        /// </summary>
        /// <param name="commandItem">The command Item.</param>
        protected void OnCommandRemoved(ICommandItem commandItem)
        {
            if (commandItem == null)
            {
                throw new ArgumentNullException(@"commandItem");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.CommandItem_HasBeenRemoved, commandItem.Text);
                Logger.Debug(message);
            }

            var commandChanged = this.CommandRemoved;

            if (commandChanged != null)
            {
                commandChanged(null, new CommandEventArgs(commandItem));
            }
        }

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
                }

                lock (this.commands)
                {
                    var itemsToRemove = new ICommandItem[this.commands.Count];
                    this.commands.CopyTo(itemsToRemove, 0);

                    foreach (var commandItem in itemsToRemove)
                    {
                        this.RemoveCommand(commandItem);
                    }
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Handles the CommandAdded event of child items.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EH.ImsOpcBridge.EventArguments.CommandEventArgs"/> instance containing the event data.</param>
        private void HandleCommandAdded(object sender, CommandEventArgs e)
        {
            this.OnCommandAdded(e.Command);
        }

        /// <summary>
        /// Handles the CommandChanged event of child items.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EH.ImsOpcBridge.EventArguments.CommandEventArgs"/> instance containing the event data.</param>
        private void HandleCommandChanged(object sender, CommandEventArgs e)
        {
            this.OnCommandChanged(e.Command);
        }

        /// <summary>
        /// Handles the CommandRemoved event of child items.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EH.ImsOpcBridge.EventArguments.CommandEventArgs"/> instance containing the event data.</param>
        private void HandleCommandRemoved(object sender, CommandEventArgs e)
        {
            this.OnCommandRemoved(e.Command);
        }

        #endregion
    }
}
