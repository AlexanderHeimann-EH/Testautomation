// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   NavigationAreaElements provides functions to gain access to several GUI elements
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     NavigationAreaElements provides functions to gain access to several GUI elements
    /// </summary>
    public class NavigationElements
    {
        #region Public Properties

        /// <summary>
        /// Gets the navigation tab.
        /// </summary>
        /// <value>The navigation tab.</value>
        public static TabPage NavigationTab
        {
            get
            {
                try
                {
                    TabPage tabPage;
                    if (Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaPageTab, DefaultValues.iTimeoutDefault, out tabPage))
                    {
                        return tabPage;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the navigation tree.
        /// </summary>
        /// <value>The navigation tree.</value>
        public static Element NavigationTree
        {
            get
            {
                try
                {
                    Element element;
                    Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaNavigationTree, DefaultValues.iTimeoutDefault, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the page down button.
        /// </summary>
        /// <value>The page down button.</value>
        public static Button PageDownButton
        {
            get
            {
                try
                {
                    Button buffer;
                    Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVScrollBarPageDown, DefaultValues.iTimeoutDefault, out buffer);
                    return buffer;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the page up button.
        /// </summary>
        /// <value>The page up button.</value>
        public static Button PageUpButton
        {
            get
            {
                try
                {
                    Button buffer;
                    Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVScrollBarPageUp, DefaultValues.iTimeoutDefault, out buffer);
                    return buffer;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the vertical scrollbar.
        /// </summary>
        /// <value>The vertical scrollbar.</value>
        public static ScrollBar VerticalScrollbar
        {
            get
            {
                try
                {
                    ScrollBar scrollbar;
                    Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVerticalScrollBar, DefaultValues.iTimeoutDefault, out scrollbar);
                    return scrollbar;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Returns a specified tree item within the tree.
        /// </summary>
        /// <param name="strName">
        /// Item (menu / parameter) to select
        /// </param>
        /// <param name="lastFoundTreeItemChildIndex">
        /// Index of tree item which was found at last
        /// </param>
        /// <returns>
        /// <br>TreeItem: If call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        public static TreeItem GetTreeItem(string strName, int lastFoundTreeItemChildIndex)
        {
            try
            {
                string[] seperator = { " " };
                string[] treeItemNameParts = strName.Split(seperator, StringSplitOptions.None);

                // if at least one part is available 
                if (treeItemNameParts.Length > 0)
                {
                    // build attribut string for treeitem search
                    string replaceString = string.Empty;
                    for (int counter = 0; counter < treeItemNameParts.Length; counter++)
                    {
                        // if part is not last
                        if (counter < (treeItemNameParts.Length - 1))
                        {
                            replaceString = replaceString + "@text~'" + treeItemNameParts[counter] + "' and ";
                        }
                        else
                        {
                            replaceString = replaceString + "@text~'" + treeItemNameParts[counter] + "' ";
                        }
                    }

                    // replace special characters
                    replaceString = replaceString.Replace("(", @"\(");
                    replaceString = replaceString.Replace(")", @"\)");
                    replaceString = replaceString.Replace("?", @"\?");

                    // build search string
                    string searchPath = NavigationPaths.StrNaviAreaTreeItemParameter.Replace("TREEITEMPARTS", replaceString);
                    IList<TreeItem> treeItemList = Host.Local.Find<TreeItem>(searchPath, DefaultValues.iTimeoutDefault);
                    if (treeItemList.Count > 0)
                    {
                        return SearchTreeItemInList(treeItemList, lastFoundTreeItemChildIndex);
                    }

                    Log.Info("NavigationElements.GetTreeItem", "Treeitem [" + strName + "] not found");
                    return null;
                }

                Log.Info("NavigationElements.GetTreeItem", "There is no element to search for");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Searches the tree item in list.
        /// </summary>
        /// <param name="treeItemList">
        /// The tree item list.
        /// </param>
        /// <param name="lastFoundTreeItemChildIndex">
        /// Last index of the found tree item child.
        /// </param>
        /// <returns>
        /// The tree item.
        /// </returns>
        private static TreeItem SearchTreeItemInList(IList<TreeItem> treeItemList, int lastFoundTreeItemChildIndex)
        {
            try
            {
                TreeItem searchedTreeItem = null;
                if (treeItemList != null)
                {
                    foreach (TreeItem treeItem in treeItemList)
                    {
                        if (treeItem.Element.ChildIndex <= lastFoundTreeItemChildIndex)
                        {
                            continue;
                        }

                        searchedTreeItem = treeItem;
                        break;
                    }

                    return searchedTreeItem;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Empty list");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        #endregion
    }
}