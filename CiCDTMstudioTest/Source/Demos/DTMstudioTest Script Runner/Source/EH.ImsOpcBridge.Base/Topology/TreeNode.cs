// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeNode.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The implementation of a tree node.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Topology
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Globalization;
    using System.Reflection;

    using EH.ImsOpcBridge.Commands;
    using EH.ImsOpcBridge.Delegates;
    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Exceptions;
    using EH.ImsOpcBridge.Properties;

    using log4net;

    /// <summary>
    /// The implementation of a tree node.
    /// </summary>
    public class TreeNode : ITreeNode
    {
        #region Constants and Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// the command provider.
        /// </summary>
        private readonly ICommandProvider commandProvider;

        /// <summary>
        /// Set to true, when <see cref="Children"/> has been initialized. If set to false,
        /// </summary>
        private bool childrenInitialized;

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The name of the tree node.
        /// </summary>
        private string name;

        /// <summary>
        /// The parent of the tree node.
        /// </summary>
        private ITreeNode parent;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public TreeNode(string name)
        {
            this.commandProvider = new CommandProvider();
            this.commandProvider.CommandAdded += this.HandleCommandAdded;
            this.commandProvider.CommandRemoved += this.HandleCommandRemoved;
            this.commandProvider.CommandChanged += this.HandleCommandChanged;

            this.Name = name;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TreeNode"/> class.
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="TreeNode"/> is reclaimed by garbage collection.
        /// </summary>
        ~TreeNode()
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
        /// Gets the children of the tree node.
        /// </summary>
        public ReadOnlyCollection<ITreeNode> Children
        {
            get
            {
                this.EnsureInitializedChildren();

                if (this.Topology != null)
                {
                    return this.Topology.GetChildren(this);
                }

                return new ReadOnlyCollection<ITreeNode>(new List<ITreeNode>());
            }
        }

        /// <summary>
        /// Gets the commands.
        /// </summary>
        public ReadOnlyCollection<ICommandItem> Commands
        {
            get
            {
                return this.commandProvider.Commands;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has children.
        /// </summary>
        public bool HasChildren
        {
            get
            {
                if (this.Topology == null)
                {
                    return false;
                }

                return this.Children.Count > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has a parent.
        /// </summary>
        public bool HasParent
        {
            get
            {
                return this.Parent != null;
            }
        }

        /// <summary>
        /// Gets the level of the node in the topology.
        /// </summary>
        public int Level
        {
            get
            {
                var level = 0;
                var currentParentNode = this.Parent;

                while (currentParentNode != null)
                {
                    level++;
                    currentParentNode = currentParentNode.Parent;
                }

                return level;
            }
        }

        /// <summary>
        /// Gets or sets the name of the tree node.
        /// </summary>
        /// <value>The name of the tree node.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnNodeChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the parent of the tree node.
        /// </summary>
        /// <value>The parent of the tree node.</value>
        public ITreeNode Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                if (value != null)
                {
                    if (value.IsParentOrAscendantOf(this))
                    {
                        var message = string.Format(CultureInfo.CurrentUICulture, Resources.CannotSetTheParentOfTheTreeNode_To_ThisWouldLeadToACyclicDependency, this.Name, value.Name); 
                        throw new BaseException(message);
                    }
                }

                this.parent = value;
            }
        }

        /// <summary>
        /// Gets the topology, this node is part of.
        /// </summary>
        public ITreeTopology Topology { get; internal set; }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public object Context { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the children are initialized.
        /// </summary>
        /// <value><c>true</c> if children are initialized; otherwise, <c>false</c>.</value>
        protected bool ChildrenInitialized
        {
            get
            {
                return this.childrenInitialized;
            }

            set
            {
                this.childrenInitialized = value;
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
        public ICommandItem AddCommand(string id, int commandSortIndex, ITranslatableString commandText, ITranslatableString commandDescription, CommandProc commandDoProc, Icon commandIcon)
        {
            return this.commandProvider.AddCommand(id, commandSortIndex, commandText, commandDescription, commandDoProc, commandIcon);
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
        public ICommandItem AddCommand(string id, int commandSortIndex, ITranslatableString commandText, ITranslatableString commandDescription, CommandProc commandDoProc)
        {
            return this.commandProvider.AddCommand(id, commandSortIndex, commandText, commandDescription, commandDoProc);
        }

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="commandItem">The command item.</param>
        /// <returns>The new command item.</returns>
        public ICommandItem AddCommand(ICommandItem commandItem)
        {
            return this.commandProvider.AddCommand(commandItem);
        }

        /// <summary>
        /// Adds the node as a child.
        /// </summary>
        /// <param name="node">The node.</param>
        public void AddNodeAsChild(ITreeNode node)
        {
            if (this.Topology == null)
            {
                throw new BaseException(Resources.CannotAddChildNodeNodeIsNotPartOfATopology);
            }

            this.Topology.AddAsChildNode(node, this);
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
        /// Finds the command by the unique command id.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <returns>The command or null if no command with the specified id has been found.</returns>
        public ICommandItem FindCommand(string id)
        {
            return this.commandProvider.FindCommand(id);
        }

        /// <summary>
        /// Finds the command by the unique command id.
        /// </summary>
        /// <param name="id">The unique command id.</param>
        /// <returns>The list of commands with the specified id.</returns>
        public ReadOnlyCollection<ICommandItem> FindCommands(string id)
        {
            return this.commandProvider.FindCommands(id);
        }

        /// <summary>
        /// Determines whether this instance is parent or ascendant of the specified node.
        /// </summary>
        /// <param name="node">The specified node.</param>
        /// <returns><c>true</c> if this instance is parent or ascendant of the specified; otherwise, <c>false</c>.</returns>
        public bool IsParentOrAscendantOf(ITreeNode node)
        {
            var currentParent = node;

            while (currentParent != null)
            {
                if (currentParent == this)
                {
                    return true;
                }

                currentParent = currentParent.Parent;
            }

            return false;
        }

        /// <summary>
        /// Moves this node to a new parent.
        /// </summary>
        /// <param name="newParent">The new parent.</param>
        public void MoveTo(ITreeNode newParent)
        {
            if (this.Topology == null)
            {
                throw new BaseException(Resources.CannotMoveNodeNodeIsNotPartOfATopology);
            }

            this.Topology.MoveNode(this, newParent);
        }

        /// <summary>
        /// Prepares the topology for shutdown.
        /// </summary>
        /// <param name="force">if set to <c>true</c> the preparation is done in a forced way.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public virtual bool PrepareForShutdown(bool force)
        {
            var result = true;
            
            if (this.HasChildren)
            {
                foreach (var node in this.Children)
                {
                    if (!node.PrepareForShutdown(force))
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Removes the command item.
        /// </summary>
        /// <param name="commandItem">The command item to be removed.</param>
        public void RemoveCommand(ICommandItem commandItem)
        {
            this.commandProvider.RemoveCommand(commandItem);
        }

        /// <summary>
        /// Updates the commands of the command provider.
        /// </summary>
        public virtual void UpdateCommandProvider()
        {
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
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                }

                if (this.Topology != null)
                {
                    this.Topology.RemoveNode(this);
                }

                this.commandProvider.CommandAdded -= this.HandleCommandAdded;
                this.commandProvider.CommandRemoved -= this.HandleCommandRemoved;
                this.commandProvider.CommandChanged -= this.HandleCommandChanged;
                this.commandProvider.Dispose();

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Initializes <see cref="Children"/> when accessed for the first time. Override this method when needed to implement lazy initialization.
        /// </summary>
        protected virtual void InitializeChildren()
        {
        }

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
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.CommandItem_HasBeenAddedToNode_, commandItem.Text, this.Name);
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
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.CommandItem_OfNode_HasChanged, commandItem.Text, this.Name);
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
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.CommandItem_OfNode_HasBeen_Removed, commandItem.Text, this.Name);
                Logger.Debug(message);
            }

            var commandChanged = this.CommandRemoved;

            if (commandChanged != null)
            {
                commandChanged(null, new CommandEventArgs(commandItem));
            }
        }

        /// <summary>
        /// Called when tree node has changed.
        /// </summary>
        protected void OnNodeChanged()
        {
            var treeTopology = this.Topology as TreeTopology;

            if (treeTopology != null)
            {
                treeTopology.OnNodeChanged(this);
            }
        }

        /// <summary>
        /// Ensures the children are initialized.
        /// </summary>
        private void EnsureInitializedChildren()
        {
            if (!this.childrenInitialized)
            {
                this.InitializeChildren();
                this.childrenInitialized = true;
            }
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
