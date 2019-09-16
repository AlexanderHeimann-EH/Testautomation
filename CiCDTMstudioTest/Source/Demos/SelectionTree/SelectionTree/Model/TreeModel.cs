using System.Collections.Specialized;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using SelectionTree.Controls.Tree;


namespace SelectionTree
{
    /// <summary>
    /// Class TreeModel.
    /// Implementation  of ITreeModel interface
    /// </summary>
    class TreeModel : ITreeModel
    {
        #region Properties

        /// <summary>
        /// The <see cref="FeatureCollection" />FeatureCollection.
        /// </summary>
        private FeatureCollection _features;
        public FeatureCollection Features
        {
            get { return _features; }
            set { _features = value; }
        }

        #endregion Properties

        #region Interface implementation

        /// <summary>
        /// The GetChildren method implementation
        /// </summary>
        /// <param name="parent">The parent feature.</param>
        /// <returns>A collection of child features.</returns>
        public IEnumerable GetChildren(object parent)
		{
            Feature parentItem = parent as Feature;
			if (parent == null)
			{
                if (Features != null)
                {
                    foreach (Feature feature in _features)
                    {
                        yield return feature;
                    }
                }
			}
            else if (parentItem != null)
			{
                if (parentItem.Children != null)
                {
                    foreach (Feature feature in parentItem.Children)
                    {
                        yield return feature;
                    }
                }
			}
		}

        /// <summary>
        /// The get children collection.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable GetChildrenCollection(object parent)
        {
            var parentItem = parent as Feature;
            if (parent == null)
            {
                if (this.Features != null)
                {
                    return this.Features;
                }
            }
            else if (parentItem != null)
            {
                if (parentItem.Children != null)
                {
                    return parentItem.Children;
                }
            }

            return null;
        }

        /// <summary>
        /// The HasChildren method implementation
        /// </summary>
        /// <param name="parent">The parent feature.</param>
        /// <returns>True if the parent has children, otherwise false.</returns>
        public bool HasChildren(object parent)
		{
            bool rc = false;

            Feature parentItem = parent as Feature;
            if (parentItem != null)
                rc = (parentItem.Children != null && parentItem.Children.Count > 0);

            return rc;
		}

        #endregion Interface implementation
    }
}
