using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using SelectionTree.Controls.Tree;

namespace SelectionTree
{
	class TreeModel : ITreeModel
    {
        #region Properties

        private FeatureCollection _features;
        public FeatureCollection Features
        {
            get { return _features; }
            set { _features = value; }
        }

        #endregion Properties

        #region Interface implementation

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

		public bool HasChildren(object parent)
		{
            Feature parentItem = parent as Feature;
			return (parentItem.Children != null && parentItem.Children.Count > 0);
		}

        #endregion Interface implementation
    }
}
