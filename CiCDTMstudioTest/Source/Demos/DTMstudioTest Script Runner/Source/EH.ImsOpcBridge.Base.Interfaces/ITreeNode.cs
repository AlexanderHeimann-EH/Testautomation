// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITreeNode.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The interface of a tree node.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// The interface of a tree node.
    /// </summary>
    public interface ITreeNode : ICommandProvider
    {
        #region Public Properties

        /// <summary>
        /// Gets the children of the tree node.
        /// </summary>
        ReadOnlyCollection<ITreeNode> Children { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has children.
        /// </summary>
        bool HasChildren { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has a parent.
        /// </summary>
        bool HasParent { get; }

        /// <summary>
        /// Gets the level of the node in the topology.
        /// </summary>
        int Level { get; }

        /// <summary>
        /// Gets or sets the name of the tree node.
        /// </summary>
        /// <value>The name of the tree node.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent of the tree node.
        /// </summary>
        /// <value>The parent of the tree node.</value>
        ITreeNode Parent { get; set; }

        /// <summary>
        /// Gets the topology, this node is part of.
        /// </summary>
        ITreeTopology Topology { get; }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        object Context { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the node as a child.
        /// </summary>
        /// <param name="node">The node.</param>
        void AddNodeAsChild(ITreeNode node);

        /// <summary>
        /// Determines whether this instance is parent or ascendant of the specified node.
        /// </summary>
        /// <param name="node">The specified node.</param>
        /// <returns><c>true</c> if this instance is parent or ascendant of the specified; otherwise, <c>false</c>.</returns>
        bool IsParentOrAscendantOf(ITreeNode node);

        /// <summary>
        /// Moves this node to a new parent.
        /// </summary>
        /// <param name="newParent">The new parent.</param>
        void MoveTo(ITreeNode newParent);

        /// <summary>
        /// Prepares the topology for shutdown.
        /// </summary>
        /// <param name="force">if set to <c>true</c> the preparation is done in a forced way.</param>
        /// <returns>True if successful, otherwise false.</returns>
        bool PrepareForShutdown(bool force);

        /// <summary>
        /// Updates the commands of the command provider.
        /// </summary>
        void UpdateCommandProvider();

        #endregion
    }
}
