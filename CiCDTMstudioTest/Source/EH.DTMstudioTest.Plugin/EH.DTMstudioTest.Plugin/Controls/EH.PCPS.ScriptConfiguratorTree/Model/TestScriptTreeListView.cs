// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScriptTreeListView.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The selection tree list view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.ScriptConfiguratorTree.Model
{
    using System.Collections.Specialized;
    using System.Linq;

    using EH.PCPS.SelectionTree.Controls.Model;

    /// <summary>
    /// The test script tree list view.
    /// </summary>
    public class TestScriptTreeListView : TreeListView
    {
        ///// <summary>
        ///// The create children nodes.
        ///// </summary>
        ///// <param name="treeNode">
        ///// The node.
        ///// </param>
        #region Public Methods and Operators

        /// <summary>
        /// The create children nodes.
        /// </summary>
        /// <param name="treeNode">
        /// The tree node.
        /// </param>
        public override void CreateChildrenNodes(TreeNode treeNode)
        {
            var children = this.GetChildren(treeNode);

            if (children != null)
            {
                var rowIndex = this.GetRowIndexOfTreeNode(treeNode);
                if ((rowIndex > -1 && this.Rows.Count > 0) || (rowIndex == -1 && this.Rows.Count == 0))
                {
                    treeNode.ChildrenSource = this.GetChildrenCollection(treeNode) as INotifyCollectionChanged;

                    foreach (TestScriptItem child in children)
                    {
                        var childTreeNode = new TestScriptTreeNode(this, child);
                        childTreeNode.PropertyChanged += this.OnTreeNodePropertyChanged;

                        treeNode.Children.Add(childTreeNode);
                        childTreeNode.HasChildren = this.HasChildren(childTreeNode);
                    }

                    this.Rows.InsertRange(rowIndex + 1, treeNode.Children.ToArray());
                }
            }
        }

        #endregion
    }
}