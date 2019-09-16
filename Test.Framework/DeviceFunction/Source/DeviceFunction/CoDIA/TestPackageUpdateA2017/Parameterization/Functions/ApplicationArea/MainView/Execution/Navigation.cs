// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Navigation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 03.02.2011
 * Time: 2:42 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;

    using Button = Ranorex.Button;

    /// <summary>
    ///     Navigation provides functionality to select/open menus, or select a
    ///     parameter within the tree.
    /// </summary>
    public class Navigation : INavigation
    {
        /// <summary>
        /// The invalid parameters.
        /// </summary>
        public List<string> listOfInvalidParameters;

        /// <summary>
        /// The element scroll bar.
        /// </summary>
        private Ranorex.Core.Element elementScrollBar;

        /// <summary>
        /// The scroll bar button initialized.
        /// </summary>
        private bool isButtonScrollBarDownInitialized;
        
        /// <summary>
        /// The button line down.
        /// </summary>
        private Button buttonLineDown;

        /// <summary>
        /// The button page down.
        /// </summary>
        private Button buttonPageDown;

        /// <summary>
        /// The data panel.
        /// </summary>
        private Container dataPanel;

        /// <summary>
        /// The is ongoing.
        /// </summary>
        private bool isOngoing = true;

        /// <summary>
        /// The is updated needed.
        /// </summary>
        private bool isUpdatedNeeded;

        /// <summary>
        /// The counter.
        /// </summary>
        private int counter;

        /// <summary>
        /// The last index.
        /// </summary>
        private int lastIndex;

        /// <summary>
        /// The number of childs.
        /// </summary>
        private int numberOfChilds;

        /// <summary>
        /// The is data panel initialized.
        /// </summary>
        private bool isDataPanelInitialized;

        /// <summary>
        /// The is scrollbar initialized.
        /// </summary>
        private bool isScrollbarInitialized;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Navigation"/> class.
        /// </summary>
        public Navigation()
        {
            this.buttonLineDown = null;
            this.buttonPageDown = null;
            this.isButtonScrollBarDownInitialized = false;
            this.isDataPanelInitialized = false;
            this.isOngoing = true;
            this.isUpdatedNeeded = false;
            this.counter = 0;
            this.lastIndex = 0;
            this.numberOfChilds = 0;
            this.InitializeDataPanel();
            this.InitializeScrollbar();
            this.listOfInvalidParameters = new List<string>();
        }

        /// <summary>
        /// Gets or sets the data panel children.
        /// </summary>
        public IList<TreeItem> DataPanelChildren { get; set; }

        /// <summary>
        /// Gets or sets the data panel.
        /// </summary>
        public Container DataPanel
        {
            get
            {
                return this.dataPanel;
            }

            set
            {
                this.dataPanel = value;
            }
        }

        /// <summary>
        /// The search and select parameter.
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to parameter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SearchAndSelectParameter(string pathToParameter)
        {
            this.DataPanel.Click();
            this.SelectFirstTreeItemAndCollapseTree(this.DataPanelChildren[0]);

            string[] seperator = { "//" };
            string[] pathParts = pathToParameter.Split(seperator, StringSplitOptions.None);

            TreeItem treeItem = null;
            for (int counterPathParts = 0; counterPathParts < pathParts.Length; counterPathParts++)
            {
                int parameterIndex = 0;
                bool isIndexForParameterAvailable = this.IsIndexForParameterAvailable(pathParts[counterPathParts]);
                if (isIndexForParameterAvailable)
                {
                    parameterIndex = this.GetAndRemoveIndexFromPath(ref pathParts[counterPathParts]);
                }

                for (int counterParameterIndex = 0; counterParameterIndex <= parameterIndex - 2; counterParameterIndex++)
                {
                    treeItem = this.GetTreeItemByPathWithoutExpand(pathParts[counterPathParts]);
                    if (treeItem == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occured while searching multiple folders.");
                    }
                }
                
                treeItem = this.GetTreeItemByPath(pathParts[counterPathParts]);
            }

            if (treeItem == null)
            {
                this.counter = 0;
                this.lastIndex = 0;
                this.numberOfChilds = 0;
                return false;
            }

            this.counter = 0;
            this.lastIndex = 0;
            this.numberOfChilds = 0;
            return true;
        }

        /// <summary>
        ///     Check if tab page title is available
        /// </summary>
        /// <param name="tabPageTitle">Tab page title</param>
        /// <returns>
        ///     <br>True: If everything worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool CheckForTabPageTitle(string tabPageTitle)
        {
            Mouse.MoveTo(NavigationElements.NavigationTab);
            return NavigationElements.NavigationTab.Title.Contains(tabPageTitle);
        }
        
        /// <summary>
        /// The select first tree item and collapse tree.
        /// </summary>
        /// <param name="treeItem">
        /// The tree item.
        /// </param>
        public void SelectFirstTreeItemAndCollapseTree(TreeItem treeItem)
        {
            // Make sure first element of tree is visible and selected
            string selected = treeItem.Element.GetAttributeValueText("Selected");
            while (treeItem.Element.Visible == false || selected == null)
            {
                Keyboard.Press(Keys.PageUp);
            }

            this.ExpandMenu(treeItem);
        }
       
        /// <summary>
        ///     Expand a specified menu-entry within the tree.
        /// </summary>
        /// <param name="treeitem">TreeItem to expand</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ExpandMenu(TreeItem treeitem)
        {
            try
            {
                if (!treeitem.Expanded)
                {
                    treeitem.Expand();
                }

                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Collapse a specified menu-entry within the tree.
        /// </summary>
        /// <param name="treeitem">TreeItem to collapse</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool CollapseMenu(TreeItem treeitem)
        {
            try
            {
                if (treeitem.Expanded)
                {
                    treeitem.Collapse();
                }

                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
        
        /// <summary>
        ///     Verify number of columns in Navigation Area
        /// </summary>
        /// <param name="containerPath">Contains column header</param>
        /// <param name="expectedColumns">Number of expected columns</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool NumberOfColums(string containerPath, int expectedColumns)
        {
            try
            {
                Container container;
                if (Host.Local.TryFindSingle(containerPath, out container))
                {
                    if (container.Children.Count == expectedColumns)
                    {
                        Mouse.MoveTo(container);
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Number of columns does not match.");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), containerPath + " not found.");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The are parameter in tree.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AreParameterInTree()
        {
            this.InitializeDataPanel();

            if (this.DataPanelChildren != null)
            {
                IList<TreeItem> treeItems = new List<TreeItem>();
                foreach (var treeItem in this.DataPanelChildren)
                {
                    string accessibleName = treeItem.Element.GetAttributeValueText("AccessibleName");
                    if (accessibleName != null)
                    {
                        if (accessibleName.Contains("Parameter"))
                        {
                            return true;
                        }

                        treeItems.Add(treeItem);
                    }
                }

                if (treeItems.Count > 4)
                {
                    return true;
                }

                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There are no tree items available.");
            return false;
        }

        /// <summary>
        /// The scroll down tree until tree item is visible.
        /// </summary>
        /// <param name="nextTreeItem">
        /// The next tree item.
        /// </param>
        public void ScrollDownTreeUntilTreeItemIsVisibleOrScrollbarBottomReached(TreeItem nextTreeItem)
        {
            // Check if scrollbar buttons are not initialized
            if (!this.isButtonScrollBarDownInitialized)
            {
                this.InitializeScrollbar();
            }

            // Check if scrollbar is visible
            if (this.elementScrollBar.Visible)
            {
                // Check if page down button is available and
                // Check if page down button is not at the bottom
                // Else check if there are any collapsed items left
                if (this.buttonPageDown != null && this.buttonPageDown.ScreenRectangle.Height > 0)
                {
                    // While line down button is available and
                    // While next tree item is not visible and
                    // While page down button is not at the bottom
                    // HINT: Solange der Menueintrag nicht über dem Rahmen der NavArea ist
                    while ((this.buttonLineDown != null && 
                        nextTreeItem.ScreenRectangle.Y > this.buttonLineDown.ScreenRectangle.Y && 
                        this.buttonPageDown.ScreenRectangle.Height > 0) || nextTreeItem.Visible == false)
                    {
                        // Scroll down for some lines
                        Mouse.Click(this.buttonPageDown);
                    }
                }
            }
        }

        /// <summary>
        ///     Search and returns a tree item behind a specified path.
        /// </summary>
        /// <param name="partOfPath">Item (menu / parameter) to search for.</param>
        /// <returns>
        ///     <br>TreeItem: If call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        private TreeItem GetTreeItemByPath(string partOfPath)
        {
            TreeItem treeItemToReturn = null;

            if (this.DataPanelChildren != null && this.DataPanelChildren.Count > 0)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                while (this.isOngoing)
                {
                    if (this.isUpdatedNeeded)
                    {
                        this.UpdateTree();
                    }

                    for (this.counter = this.lastIndex; this.counter < this.DataPanelChildren.Count - 1; this.counter++)
                    {
                        string accessibleName = this.DataPanelChildren[this.counter].Element.GetAttributeValueText("accessiblename");
                        if (accessibleName != null)
                        {

                            // 2017-04-27 - EC: Removed during bugfix.
                            //if (accessibleName.Contains("Navigation_Menu_"))
                            //{
                            //    if (this.isButtonScrollBarDownInitialized)
                            //    {
                            //        if (this.buttonLineDown != null)
                            //        {
                            //            this.buttonLineDown.Click();
                            //        }
                            //    }
                            //}

                            if (accessibleName.Contains("Navigation_"))
                            {
                                var treeItem = this.DataPanelChildren[this.counter];

                                TreeItem nextTreeItem = null;
                                if (this.DataPanelChildren.Count - 1 >= this.counter + 1)
                                {
                                    nextTreeItem = this.DataPanelChildren[this.counter + 1];
                                }

                                // If next tree item is null
                                //   If no scrollbar is available, this means current tree item is in clickable area
                                //     Execute Handle Tree Item
                                //   If scrollbar is availalbe, this means current tree item is not in clickable area
                                //     Scroll to bottom to get current tree item in clickable area
                                //     Execute Handle Tree Item
                                if (nextTreeItem == null)
                                {
                                    if (this.isButtonScrollBarDownInitialized)
                                    {
                                        // scrolle bis zum ende => aktuelles element kommt in den anklickbaren bereich
                                        while (this.buttonLineDown != null && this.buttonPageDown.ScreenRectangle.Height > 0)
                                        {
                                            // Scroll down for some lines
                                            Mouse.Click(this.buttonPageDown);
                                        }
                                    }

                                    treeItem.Click();
                                }

                                // If next tree item is not null
                                //   If next tree item is visible, this means current tree item is in clickable area
                                //     Execute Handle Tree Item
                                //   If next tree item is not visible, this means current tree item is not in clickable area
                                //     Scroll down until next tree item becomes visible 
                                //     Execute Handle Tree Item
                                if (nextTreeItem != null)
                                {
                                    if (!nextTreeItem.Visible)
                                    {
                                        // If current tree item is a menu, expand it
                                        this.ScrollDownTreeUntilTreeItemIsVisibleOrScrollbarBottomReached(nextTreeItem);
                                    }
                                }

                                // If searched tree item is found, reset parameters and finish searching
                                if (!accessibleName.Equals(string.Empty))
                                {
                                    string text = treeItem.Element.GetAttributeValueText("AccessibleName");
                                    if (text.Contains(partOfPath))
                                    {
                                        treeItem.Click();
                                        this.ExpandMenu(treeItem);
                                        treeItemToReturn = treeItem;
                                        this.isOngoing = false;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.lastIndex = this.counter;
                            break;
                        }

                        this.lastIndex = this.counter;
                    }

                    this.isUpdatedNeeded = true;
                }

                stopwatch.Stop();
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There are no tree items available.");
            }

            this.isUpdatedNeeded = false;
            this.isOngoing = true;
            return treeItemToReturn;
        }

        /// <summary>
        ///     Search and returns a tree item behind a specified path.
        /// </summary>
        /// <param name="partOfPath">Item (menu / parameter) to search for.</param>
        /// <returns>
        ///     <br>TreeItem: If call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        private TreeItem GetTreeItemByPathWithoutExpand(string partOfPath)
        {
            TreeItem treeItemToReturn = null;

            if (this.DataPanelChildren != null && this.DataPanelChildren.Count > 0)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                while (this.isOngoing)
                {
                    if (this.isUpdatedNeeded)
                    {
                        this.UpdateTree();
                    }

                    for (this.counter = this.lastIndex; this.counter < this.DataPanelChildren.Count - 1; this.counter++)
                    {
                        string accessibleName = this.DataPanelChildren[this.counter].Element.GetAttributeValueText("accessiblename");
                        if (accessibleName != null)
                        {
                            if (accessibleName.Contains("Navigation_Menu_"))
                            {
                                if (this.isButtonScrollBarDownInitialized)
                                {
                                    if (this.buttonLineDown != null)
                                    {
                                        this.buttonLineDown.Click();
                                    }
                                }
                            }

                            if (accessibleName.Contains("Navigation_"))
                            {
                                var treeItem = this.DataPanelChildren[this.counter];

                                TreeItem nextTreeItem = null;
                                if (this.DataPanelChildren.Count - 1 >= this.counter + 1)
                                {
                                    nextTreeItem = this.DataPanelChildren[this.counter + 1];
                                }

                                // If next tree item is null
                                //   If no scrollbar is available, this means current tree item is in clickable area
                                //     Execute Handle Tree Item
                                //   If scrollbar is availalbe, this means current tree item is not in clickable area
                                //     Scroll to bottom to get current tree item in clickable area
                                //     Execute Handle Tree Item
                                if (nextTreeItem == null)
                                {
                                    if (this.isButtonScrollBarDownInitialized)
                                    {
                                        // scrolle bis zum ende => aktuelles element kommt in den anklickbaren bereich
                                        while (this.buttonLineDown != null && this.buttonPageDown.ScreenRectangle.Height > 0)
                                        {
                                            // Scroll down for some lines
                                            Mouse.Click(this.buttonPageDown);
                                        }
                                    }

                                    treeItem.Click();
                                }

                                // If next tree item is not null
                                //   If next tree item is visible, this means current tree item is in clickable area
                                //     Execute Handle Tree Item
                                //   If next tree item is not visible, this means current tree item is not in clickable area
                                //     Scroll down until net tree item becomes visible 
                                //     Execute Handle Tree Item
                                if (nextTreeItem != null)
                                {
                                    if (!nextTreeItem.Visible)
                                    {
                                        // If current tree item is a menu, expand it
                                        this.ScrollDownTreeUntilTreeItemIsVisibleOrScrollbarBottomReached(nextTreeItem);
                                    }
                                }

                                // If searched tree item is found, reset parameters and finish searching
                                if (!accessibleName.Equals(string.Empty))
                                {
                                    string text = treeItem.Element.GetAttributeValueText("AccessibleName");
                                    if (text.Contains(partOfPath))
                                    {
                                        treeItemToReturn = treeItem;
                                        this.isOngoing = false;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.lastIndex = this.counter;
                            break;
                        }

                        this.lastIndex = this.counter;
                    }

                    this.isUpdatedNeeded = true;
                }

                stopwatch.Stop();
                this.counter += 1;
                this.lastIndex = this.counter;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There are no tree items available.");
            }

            this.isUpdatedNeeded = false;
            this.isOngoing = true;
            return treeItemToReturn;
        }
        
        /// <summary>
        /// The update tree.
        /// </summary>
        private void UpdateTree()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Update List");
            this.numberOfChilds = this.DataPanelChildren.Count;
            this.DataPanelChildren = this.DataPanel.FindChildren<TreeItem>();
            if (this.numberOfChilds == this.DataPanelChildren.Count)
            {
                this.isOngoing = false;
            }
        }

        /// <summary>
        /// The initialize data panel.
        /// </summary>
        private void InitializeDataPanel()
        {
            if (!this.isDataPanelInitialized)
            {
                Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaTreeDataPanel, out this.dataPanel);
                if (this.DataPanel != null)
                {
                    this.DataPanelChildren = this.DataPanel.FindChildren<TreeItem>();
                    this.isDataPanelInitialized = true;
                }
            }

            this.isDataPanelInitialized = false;
        }

        /// <summary>
        /// The initialize scrollbar.
        /// </summary>
        private void InitializeScrollbar()
        {
            if (!this.isScrollbarInitialized)
            {
                Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVerticalScrollBarElement, out this.elementScrollBar);
                if (this.elementScrollBar != null && this.elementScrollBar.Visible)
                {
                    this.isScrollbarInitialized = true;
                    
                    Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVScrollBarLineDown, out this.buttonLineDown);
                    Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVScrollBarPageDown, out this.buttonPageDown);
                    this.isButtonScrollBarDownInitialized = true;
                }
            }
        }

        /// <summary>
        /// The is index for parameter available.
        /// </summary>
        /// <param name="pathPart">
        /// The path part.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsIndexForParameterAvailable(string pathPart)
        {
            if (pathPart.Contains("[") && pathPart.Contains("]"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The get and remove index from path: device//menu//submenu//[index]parameter
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to parameter.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetAndRemoveIndexFromPath(ref string pathToParameter)
        {
            string[] separatorPathParts = { "//" };
            string[] pathParts = pathToParameter.Split(separatorPathParts, StringSplitOptions.None);

            // Parameter name is last part of string, including "[index]"
            string parameterName = pathParts[pathParts.Length - 1];

            // Define seperator
            string[] separatorParameterNameParts = { "[", "]" };

            // Split parameter name to separate index from name
            string[] parameterNameParts = parameterName.Split(separatorParameterNameParts, StringSplitOptions.None);

            // Get parameter index from string
            int parameterIndex = Convert.ToInt32(parameterNameParts[parameterNameParts.Length - 2]);

            // index is removed from parameter name
            parameterName = parameterNameParts[parameterNameParts.Length - 1];

            // Parameter without index is assigned to path to parameter
            pathParts[pathParts.Length - 1] = parameterName;

            // Parts are joined together without index
            const string SeparateWith = "//";
            pathToParameter = string.Join(SeparateWith, pathParts);

            return parameterIndex;
        }
    }
}