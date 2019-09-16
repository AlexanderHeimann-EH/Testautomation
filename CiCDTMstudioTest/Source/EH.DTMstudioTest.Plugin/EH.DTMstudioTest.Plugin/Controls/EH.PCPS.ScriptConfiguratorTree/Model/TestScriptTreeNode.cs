// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScriptTreeNode.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The selection tree node.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.ScriptConfiguratorTree.Model
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    using EH.PCPS.SelectionTree.Controls.Model;

    /// <summary>
    /// Class TestScriptTreeNode.
    /// </summary>
    public class TestScriptTreeNode : TreeNode
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the TestScriptTreeNode class.
        /// </summary>
        /// <param name="tree">
        /// The tree.
        /// </param>
        /// <param name="tag">
        /// The tag.
        /// </param>
        public TestScriptTreeNode(TreeListView tree, TestScriptItem tag)
        {
            if (tree == null)
            {
                throw new ArgumentNullException("tree");
            }

            tag.PropertyChanged += this.TestScriptPropertyChanged;

            this.tree = tree;
            this.children = new TreeNodeCollection(this);
            this.nodes = new ReadOnlyCollection<TreeNode>(this.children);
            this.tag = tag;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The test script property changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TestScriptPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var testScript = sender as TestScriptItem;
            if (testScript != null)
            {
                if (e.PropertyName == "IsExpanded")
                {
                    if (testScript.IsExpanded != null)
                    {
                        this.IsExpanded = (bool)testScript.IsExpanded;
                    }
                    else
                    {
                        this.IsExpanded = false;
                    }
                }
            }
        }

        #endregion
    }
}