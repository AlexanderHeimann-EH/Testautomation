// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITreeTopology.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The interface of a tree topology.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.Collections.ObjectModel;

    using EH.ImsOpcBridge.EventArguments;

    /// <summary>
    /// The interface of a tree topology.
    /// </summary>
    public interface ITreeTopology : IDisposable
    {
        #region Public Events

        /// <summary>
        /// Fired when a tree node is added
        /// </summary>
        event EventHandler<TreeNodeEventArgs> NodeAdded;

        /// <summary>
        /// Fired when a tree node has changed
        /// </summary>
        event EventHandler<TreeNodeEventArgs> NodeChanged;

        /// <summary>
        /// Fired when a tree node is removed
        /// </summary>
        event EventHandler<TreeNodeEventArgs> NodeRemoved;

        /// <summary>
        /// Fired when a tree node is moved
        /// </summary>
        event EventHandler<TreeNodeEventArgs> NodeMoved;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets all nodes of the tree topology.
        /// </summary>
        ReadOnlyCollection<ITreeNode> Nodes { get; }

        /// <summary>
        /// Gets the root nodes.
        /// </summary>
        ReadOnlyCollection<ITreeNode> RootNodes { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a tree node as a child node.
        /// </summary>
        /// <param name="node">The node to add.</param>
        /// <param name="parent">The parent node, the node should be added.</param>
        void AddAsChildNode(ITreeNode node, ITreeNode parent);

        /// <summary>
        /// Adds a tree node as a root node.
        /// </summary>
        /// <param name="node">The node to add.</param>
        void AddAsRootNode(ITreeNode node);

        /// <summary>
        /// Determines whether this topology contains the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if this topology contains the specified nod; otherwise, <c>false</c>.</returns>
        bool Contains(ITreeNode node);

        /// <summary>
        /// Removes a tree node from the network topology and disposes it.
        /// </summary>
        /// <param name="node">The node to remove and delete.</param>
        void RemoveNode(ITreeNode node);

        /// <summary>
        /// Gets the children of the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The children of the specified Node.</returns>
        ReadOnlyCollection<ITreeNode> GetChildren(ITreeNode node);

        /// <summary>
        /// Moves a tree node.
        /// </summary>
        /// <param name="node">The node to move.</param>
        /// <param name="newParent">The parent node, the node should be moved to.</param>
        void MoveNode(ITreeNode node, ITreeNode newParent);

        /// <summary>
        /// Moves a tree node to the root.
        /// </summary>
        /// <param name="node">The node to move.</param>
        void SetAsRootNode(ITreeNode node);

        #endregion
    }
}
