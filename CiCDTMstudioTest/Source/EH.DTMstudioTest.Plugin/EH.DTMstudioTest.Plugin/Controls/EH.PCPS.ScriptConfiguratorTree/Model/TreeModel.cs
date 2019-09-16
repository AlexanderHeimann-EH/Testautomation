// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The tree model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.ScriptConfiguratorTree.Model
{
    using System.Collections;

    using EH.PCPS.SelectionTree.Controls.Model;

    /// <summary>
    /// The tree model.
    /// </summary>
    internal class TreeModel : ITreeModel
    {
        #region Fields

        /// <summary>
        /// The features.
        /// </summary>
        private TestScriptCollection testScriptList;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        public TestScriptCollection TestScriptList
        {
            get
            {
                return this.testScriptList;
            }

            set
            {
                this.testScriptList = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get children.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable GetChildren(object parent)
        {
            var parentItem = parent as TestScriptItem;
            if (parent == null)
            {
                if (this.TestScriptList != null)
                {
                    foreach (var testScript in this.testScriptList)
                    {
                        yield return testScript;
                    }
                }
            }
            else if (parentItem != null)
            {
                if (parentItem.Children != null)
                {
                    foreach (var testScript in parentItem.Children)
                    {
                        yield return testScript;
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
            var parentItem = parent as TestScriptItem;
            if (parent == null)
            {
                if (this.TestScriptList != null)
                {
                    return this.TestScriptList;
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
        /// The has children.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool HasChildren(object parent)
        {
            var parentItem = parent as TestScriptItem;
            return parentItem != null && (parentItem.Children != null && parentItem.Children.Count > 0);
        }

        #endregion
    }
}