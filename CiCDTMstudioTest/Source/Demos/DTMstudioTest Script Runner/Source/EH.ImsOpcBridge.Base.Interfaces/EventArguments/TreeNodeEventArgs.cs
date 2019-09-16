// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeNodeEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The tree node event argument class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;

    /// <summary>
    /// The tree node event argument class.
    /// </summary>
    public class TreeNodeEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNodeEventArgs"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public TreeNodeEventArgs(ITreeNode node)
        {
            this.Node = node;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the tree node, which has changed.
        /// </summary>
        /// <value>The tree node.</value>
        public ITreeNode Node { get; private set; }

        #endregion
    }
}
