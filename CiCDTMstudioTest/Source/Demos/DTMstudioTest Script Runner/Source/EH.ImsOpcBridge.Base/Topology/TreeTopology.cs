// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeTopology.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The implementation of a tree topology.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Topology
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    using EH.ImsOpcBridge.EventArguments;
    using EH.ImsOpcBridge.Exceptions;
    using EH.ImsOpcBridge.Properties;

    using log4net;

    /// <summary>
    /// The implementation of a tree topology.
    /// </summary>
    public class TreeTopology : ITreeTopology
    {
        #region Constants and Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// All nodes of the tree topology.
        /// </summary>
        private readonly Collection<ITreeNode> nodes = new Collection<ITreeNode>();

        /// <summary>
        /// Disposed flag
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Set to true, when <see cref="RootNodes"/> has been initialized. If set to false,
        /// </summary>
        private bool rootNodesInitialized;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Finalizes an instance of the <see cref="TreeTopology"/> class.
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="TreeTopology"/> is reclaimed by garbage collection.
        /// </summary>
        ~TreeTopology()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            this.Dispose(false);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Fired when a tree node is added.
        /// </summary>
        public event EventHandler<TreeNodeEventArgs> NodeAdded;

        /// <summary>
        /// Fired when a tree node has changed
        /// </summary>
        public event EventHandler<TreeNodeEventArgs> NodeChanged;

        /// <summary>
        /// Fired when a tree node is moved
        /// </summary>
        public event EventHandler<TreeNodeEventArgs> NodeMoved;

        /// <summary>
        /// Fired when a tree node is removed
        /// </summary>
        public event EventHandler<TreeNodeEventArgs> NodeRemoved;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether this instance has root nodes.
        /// </summary>
        public bool HasRootNodes
        {
            get
            {
                return this.RootNodes.Count > 0;
            }
        }

        /// <summary>
        /// Gets all nodes of the tree topology.
        /// </summary>
        public ReadOnlyCollection<ITreeNode> Nodes
        {
            get
            {
                lock (this.nodes)
                {
                    return new ReadOnlyCollection<ITreeNode>(this.nodes);
                }
            }
        }

        /// <summary>
        /// Gets the root nodes.
        /// </summary>
        public ReadOnlyCollection<ITreeNode> RootNodes
        {
            get
            {
                if (!this.rootNodesInitialized)
                {
                    this.InitializeRootNodes();
                    this.rootNodesInitialized = true;
                }

                lock (this.nodes)
                {
                    var rootNodeQuery = from node in this.nodes where node.Parent == null select node;
                    var rootNodeList = new List<ITreeNode>(rootNodeQuery);
                    return new ReadOnlyCollection<ITreeNode>(rootNodeList.AsReadOnly());
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a tree node as a child node.
        /// </summary>
        /// <param name="node">The node to add.</param>
        /// <param name="parent">The parent node, the node should be added.</param>
        public void AddAsChildNode(ITreeNode node, ITreeNode parent)
        {
            if (node == null)
            {
                throw new ArgumentNullException(@"node");
            }

            if (this.Contains(node))
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.Node_IsAlreadyPartOfTheTopology, node.Name);
                throw new BaseException(message);
            }

            node.Parent = parent;
            lock (this.nodes)
            {
                this.nodes.Add(node);
                this.ConnectNodeToThisTopology(node);
                this.OnNodeAdded(node);
            }
        }

        /// <summary>
        /// Adds a tree node as a root node.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public void AddAsRootNode(ITreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(@"node");
            }

            if (this.Contains(node))
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.Node_IsAlreadyPartOfTheTopology, node.Name);
                throw new BaseException(message);
            }

            node.Parent = null;
            lock (this.nodes)
            {
                this.nodes.Add(node);
                this.ConnectNodeToThisTopology(node);
                this.OnNodeAdded(node);
            }
        }

        /// <summary>
        /// Determines whether this topology contains the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if this topology contains the specified nod; otherwise, <c>false</c>.</returns>
        public bool Contains(ITreeNode node)
        {
            lock (this.nodes)
            {
                return this.nodes.Contains(node);
            }
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
        /// Gets the children of the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The children of the specified Node.</returns>
        public ReadOnlyCollection<ITreeNode> GetChildren(ITreeNode node)
        {
            lock (this.nodes)
            {
                var childrenNodeQuery = from nodeItem in this.nodes where nodeItem.Parent == node select nodeItem;
                var childrenNodeList = new List<ITreeNode>(childrenNodeQuery);
                return new ReadOnlyCollection<ITreeNode>(childrenNodeList.AsReadOnly());
            }
        }

        /// <summary>
        /// Gets a copy of all nodes of the tree topology.
        /// </summary>
        /// <returns>A copy of all nodes of the tree topology.</returns>
        public ITreeNode[] GetNodesCopy()
        {
            lock (this.nodes)
            {
                var nodesCopy = new ITreeNode[this.nodes.Count];
                this.nodes.CopyTo(nodesCopy, 0);
                return nodesCopy;
            }
        }

        /// <summary>
        /// Moves a tree node.
        /// </summary>
        /// <param name="node">The node to move.</param>
        /// <param name="newParent">The parent node, the node should be moved to.</param>
        public void MoveNode(ITreeNode node, ITreeNode newParent)
        {
            if (node == null)
            {
                throw new ArgumentNullException(@"node");
            }

            node.Parent = newParent;
            this.OnNodeMoved(node);
        }

        /// <summary>
        /// Called when a tree node is added.
        /// </summary>
        /// <param name="node">The tree node, which has been added.</param>
        public virtual void OnNodeAdded(ITreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(@"node");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.Node_HasBeenAddedToTheTopology, node.Name);
                Logger.Debug(message);
            }

            var nodeAdded = this.NodeAdded;

            if (nodeAdded != null)
            {
                nodeAdded(null, new TreeNodeEventArgs(node));
            }
        }

        /// <summary>
        /// Called when a tree node has changed.
        /// </summary>
        /// <param name="node">The tree node, which has changed.</param>
        public virtual void OnNodeChanged(ITreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(@"node");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.Node_HasChanged, node.Name);
                Logger.Debug(message);
            }

            var nodeChanged = this.NodeChanged;

            if (nodeChanged != null)
            {
                nodeChanged(null, new TreeNodeEventArgs(node));
            }
        }

        /// <summary>
        /// Called when a tree node has been moved.
        /// </summary>
        /// <param name="node">The tree node, which has been moved.</param>
        public virtual void OnNodeMoved(ITreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(@"node");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.Node_HasBeenMoved, node.Name);
                Logger.Debug(message);
            }

            var nodeMoved = this.NodeMoved;

            if (nodeMoved != null)
            {
                nodeMoved(null, new TreeNodeEventArgs(node));
            }
        }

        /// <summary>
        /// Called when a tree node has been removed.
        /// </summary>
        /// <param name="node">The tree node, which has been removed.</param>
        public virtual void OnNodeRemoved(ITreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(@"node");
            }

            if (Logger.IsDebugEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.Node_HasBeenRemoved, node.Name);
                Logger.Debug(message);
            }

            var nodeRemoved = this.NodeRemoved;

            if (nodeRemoved != null)
            {
                nodeRemoved(null, new TreeNodeEventArgs(node));
            }
        }

        /// <summary>
        /// Removes a tree node from the network topology and disposes it.
        /// </summary>
        /// <param name="node">The node to remove and delete.</param>
        public void RemoveNode(ITreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(@"node");
            }

            if (!this.Contains(node))
            {
                var message = string.Format(CultureInfo.CurrentUICulture, Resources.Node_IsNotPartOfTheTopology, node.Name);
                throw new BaseException(message);
            }

            if (node.HasChildren)
            {
                foreach (var childNode in node.Children)
                {
                    this.RemoveNode(childNode);
                }
            }

            lock (this.nodes)
            {
                try
                {
                    if (this.nodes.Contains(node))
                    {
                        this.nodes.Remove(node);
                        DisconnectNodeFromTopology(node);
                        this.OnNodeRemoved(node);
                    }
                }
                finally
                {
                    node.Dispose();
                }
            }
        }

        /// <summary>
        /// Moves a tree node to the root.
        /// </summary>
        /// <param name="node">The node to move.</param>
        public void SetAsRootNode(ITreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(@"node");
            }

            node.Parent = null;
            this.OnNodeMoved(node);
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

                foreach (var node in this.RootNodes)
                {
                    this.RemoveNode(node);
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Initializes <see cref="RootNodes"/> when accessed for the first time. Override this method when needed to implement lazy initialization.
        /// </summary>
        protected virtual void InitializeRootNodes()
        {
        }

        /// <summary>
        /// Disconnects the node from the topology.
        /// </summary>
        /// <param name="node">The node.</param>
        private static void DisconnectNodeFromTopology(ITreeNode node)
        {
            var treeNode = node as TreeNode;
            if (treeNode != null)
            {
                treeNode.Topology = null;
            }
        }

        /// <summary>
        /// Connects the node to this topology.
        /// </summary>
        /// <param name="node">The node.</param>
        private void ConnectNodeToThisTopology(ITreeNode node)
        {
            var treeNode = node as TreeNode;
            if (treeNode != null)
            {
                treeNode.Topology = this;
            }
        }

        #endregion
    }
}
