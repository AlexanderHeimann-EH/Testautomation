// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandItem.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The command item.
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
    using EH.ImsOpcBridge.Helpers;
    using EH.ImsOpcBridge.Properties;

    using log4net;

    /// <summary>
    /// The command item.
    /// </summary>
    public class CommandItem : ICommandItem
    {
        #region Static Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        /// <summary>
        /// The child commands.
        /// </summary>
        private readonly Collection<ICommandItem> childCommands = new Collection<ICommandItem>();

        /// <summary>
        /// The command procedure to be called to execute the command.
        /// </summary>
        private readonly CommandProc doProc;

        /// <summary>
        /// Value indicating whether the command supports undo.
        /// </summary>
        private bool canUndo;

        /// <summary>
        /// Value indicating whether this <see cref="ICommandItemBase" /> is checked.
        /// </summary>
        private bool checkedFlag;

        /// <summary>
        /// The description.
        /// </summary>
        private ITranslatableString description;

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Value indicating whether this <see cref="ICommandItemBase" /> is enabled.
        /// </summary>
        private bool enabled = true;

        /// <summary>
        /// Value indicating whether this <see cref="ICommandItemBase" /> is hidden.
        /// </summary>
        private bool hidden;

        /// <summary>
        /// The icon of the command.
        /// </summary>
        private Icon icon;

        /// <summary>
        /// The sort index of the command item.
        /// </summary>
        private int sortIndex;

        /// <summary>
        /// The state object of the command.
        /// </summary>
        private object state;

        /// <summary>
        /// The text.
        /// </summary>
        private ITranslatableString text;

        /// <summary>
        /// The command procedure to be called to undo the command.
        /// </summary>
        private CommandProc undoProc;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandItem" /> class.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <param name="sortIndex">The sort index, defining the sequence of the items to appear.</param>
        /// <param name="text">The text.</param>
        /// <param name="description">The description.</param>
        /// <param name="doProc">The do proc.</param>
        /// <param name="icon">The icon.</param>
        public CommandItem(string id, int sortIndex, ITranslatableString text, ITranslatableString description, CommandProc doProc, Icon icon)
        {
            this.Id = id;
            this.sortIndex = sortIndex;
            this.text = text;
            this.description = description;
            this.doProc = doProc;
            this.icon = icon;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandItem" /> class.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <param name="sortIndex">The sort index, defining the sequence of the items to appear.</param>
        /// <param name="text">The text.</param>
        /// <param name="description">The description.</param>
        /// <param name="doProc">The do proc.</param>
        public CommandItem(string id, int sortIndex, ITranslatableString text, ITranslatableString description, CommandProc doProc)
        {
            this.Id = id;
            this.sortIndex = sortIndex;
            this.text = text;
            this.description = description;
            this.doProc = doProc;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="CommandItem" /> class.
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="CommandItem" /> is reclaimed by garbage collection.
        /// </summary>
        ~CommandItem()
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
        /// Fired when a new command has changed.
        /// </summary>
        public event EventHandler<CommandEventArgs> CommandItemChanged;

        /// <summary>
        /// Fired when a new command is removed.
        /// </summary>
        public event EventHandler<CommandEventArgs> CommandRemoved;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the command supports undo.
        /// </summary>
        /// <value>Value indicating whether the command supports undo.</value>
        public bool CanUndo
        {
            get
            {
                return this.canUndo;
            }

            set
            {
                if (this.canUndo != value)
                {
                    this.canUndo = value;
                    this.OnCommandChanged(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ICommandItemBase" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get
            {
                return this.checkedFlag;
            }

            set
            {
                if (this.checkedFlag != value)
                {
                    this.checkedFlag = value;
                    this.OnCommandChanged(this);
                }
            }
        }

        /// <summary>
        /// Gets the child commands.
        /// </summary>
        /// <value>The child commands.</value>
        public ReadOnlyCollection<ICommandItem> ChildCommands
        {
            get
            {
                var commandQuery = from commandItem in this.childCommands orderby commandItem.SortIndex ascending select commandItem;
                return new ReadOnlyCollection<ICommandItem>(commandQuery.ToArray());
            }
        }

        /// <summary>
        /// Gets the commands.
        /// </summary>
        /// <value>The commands.</value>
        public ReadOnlyCollection<ICommandItem> Commands
        {
            get
            {
                var commandQuery = from commandItem in this.childCommands orderby commandItem.SortIndex ascending select commandItem;
                return new ReadOnlyCollection<ICommandItem>(commandQuery.ToArray());
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return this.description.ToString();
            }

            set
            {
                if (this.description.ToString() != value)
                {
                    this.description = new TranslatableString(value, null, null);
                    this.OnCommandChanged(this);
                }
            }
        }

        /// <summary>
        /// Gets the command procedure to be called to execute the command.
        /// </summary>
        /// <value>The do proc.</value>
        public CommandProc DoProc
        {
            get
            {
                return this.doProc;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ICommandItemBase" /> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled
        {
            get
            {
                return this.enabled;
            }

            set
            {
                if (this.enabled != value)
                {
                    this.enabled = value;
                    this.OnCommandChanged(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether hidden.
        /// </summary>
        /// <value><c>true</c> if hidden otherwise, <c>false</c>.</value>
        public bool Hidden
        {
            get
            {
                return this.hidden;
            }

            set
            {
                if (this.hidden != value)
                {
                    this.hidden = value;
                    this.OnCommandChanged(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the icon of the command.
        /// </summary>
        /// <value>The icon of the command.</value>
        public Icon Icon
        {
            get
            {
                return this.icon;
            }

            set
            {
                if (this.icon != value)
                {
                    this.icon = value;
                    this.OnCommandChanged(this);
                }
            }
        }

        /// <summary>
        /// Gets the unique command id.
        /// </summary>
        /// <value>The id.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets or sets the parent command.
        /// </summary>
        /// <value>The parent command.</value>
        public ICommandItem ParentCommand { get; set; }

        /// <summary>
        /// Gets or sets the sort index of the command item.
        /// </summary>
        /// <value>The sort index of the command item.</value>
        public int SortIndex
        {
            get
            {
                return this.sortIndex;
            }

            set
            {
                if (this.sortIndex != value)
                {
                    this.sortIndex = value;
                    this.OnCommandChanged(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the state object of the command.
        /// </summary>
        /// <value>The state object of the command.</value>
        public object State
        {
            get
            {
                return this.state;
            }

            set
            {
                if (this.state != value)
                {
                    this.state = value;
                    this.OnCommandChanged(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return this.text.ToString();
            }

            set
            {
                if (this.text.ToString() != value)
                {
                    this.text = new TranslatableString(value, null, null);
                    this.OnCommandChanged(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the command procedure to be called to undo the command.
        /// </summary>
        /// <value>The command procedure to be called to undo the command.</value>
        public CommandProc UndoProc
        {
            get
            {
                return this.undoProc;
            }

            set
            {
                if (this.undoProc != value)
                {
                    this.undoProc = value;
                    this.OnCommandChanged(this);
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <param name="commandSortIndex">The sort index, defining the sequence of the items to appear.</param>
        /// <param name="commandText">The text.</param>
        /// <param name="commandDescription">The description.</param>
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
        /// <param name="commandText">The text.</param>
        /// <param name="commandDescription">The description.</param>
        /// <param name="commandDoProc">The command procedure to be called to execute the command.</param>
        /// <returns>The new command item.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "OK here.")]
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

            lock (this.childCommands)
            {
                this.childCommands.Add(commandItem);
                commandItem.ParentCommand = this;
                commandItem.CommandAdded += this.HandleCommandAdded;
                commandItem.CommandRemoved += this.HandleCommandRemoved;
                commandItem.CommandChanged += this.HandleCommandChanged;
                this.OnCommandAdded(commandItem);
            }

            return commandItem;
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
        /// Executes the command.
        /// </summary>
        /// <returns>The result of the command.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK here.")]
        public ICommandResult DoIt()
        {
            try
            {
                return this.DoProc.Invoke(this);
            }
            catch (Exception ex)
            {
                return new CommandResult(null, ex);
            }
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

            if (this.Id == id)
            {
                foundCommands.Add(this);
                return new ReadOnlyCollection<ICommandItem>(foundCommands);
            }

            foreach (var command in this.ChildCommands)
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
        /// Removes the command item.
        /// </summary>
        /// <param name="commandItem">The command item to be removed.</param>
        public void RemoveCommand(ICommandItem commandItem)
        {
            if (commandItem == null)
            {
                throw new ArgumentNullException(@"commandItem");
            }

            lock (this.childCommands)
            {
                if (this.childCommands.Contains(commandItem))
                {
                    commandItem.CommandAdded -= this.HandleCommandAdded;
                    commandItem.CommandRemoved -= this.HandleCommandRemoved;
                    commandItem.CommandChanged -= this.HandleCommandChanged;
                    this.childCommands.Remove(commandItem);
                    this.OnCommandRemoved(commandItem);
                    commandItem.Dispose();
                }
            }
        }

        /// <summary>
        /// Sets the description.
        /// </summary>
        /// <param name="newDescription">The description to set.</param>
        public void SetDescription(ITranslatableString newDescription)
        {
            this.description = newDescription;
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="newText">The text.</param>
        public void SetText(ITranslatableString newText)
        {
            this.text = newText;
        }

        /// <summary>
        /// Undoes the command.
        /// </summary>
        public void UndoIt()
        {
            if (this.CanUndo)
            {
                this.UndoProc.Invoke(this);
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

            var commandItemChanged = this.CommandItemChanged;

            if (commandItemChanged != null)
            {
                commandItemChanged(null, new CommandEventArgs(commandItem));
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

                lock (this.childCommands)
                {
                    var itemsToRemove = new ICommandItem[this.childCommands.Count];
                    this.childCommands.CopyTo(itemsToRemove, 0);

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
        /// <param name="e">The <see cref="EH.ImsOpcBridge.EventArguments.CommandEventArgs" /> instance containing the event data.</param>
        private void HandleCommandAdded(object sender, CommandEventArgs e)
        {
            this.OnCommandAdded(e.Command);
        }

        /// <summary>
        /// Handles the CommandChanged event of child items.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EH.ImsOpcBridge.EventArguments.CommandEventArgs" /> instance containing the event data.</param>
        private void HandleCommandChanged(object sender, CommandEventArgs e)
        {
            this.OnCommandChanged(e.Command);
        }

        /// <summary>
        /// Handles the CommandRemoved event of child items.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EH.ImsOpcBridge.EventArguments.CommandEventArgs" /> instance containing the event data.</param>
        private void HandleCommandRemoved(object sender, CommandEventArgs e)
        {
            this.OnCommandRemoved(e.Command);
        }

        #endregion
    }
}
