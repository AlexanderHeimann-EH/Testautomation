// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITreeModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Interface ITreeModel
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace SelectionTree.Controls.Tree
{
    using System.Collections;
    using System.Collections.Specialized;

    /// <summary>
    /// Interface ITreeModel
    /// </summary>
    public interface ITreeModel
    {
        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <returns>
        /// IEnumerable.
        /// </returns>
        IEnumerable GetChildren(object parent);

        /// <summary>
        /// Gets the children collection changed.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <returns>
        /// INotifyCollectionChanged.
        /// </returns>
        IEnumerable GetChildrenCollection(object parent);

        /// <summary>
        /// Determines whether the specified parent has children.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified parent has children; otherwise, <c>false</c>.
        /// </returns>
        bool HasChildren(object parent);
    }
}