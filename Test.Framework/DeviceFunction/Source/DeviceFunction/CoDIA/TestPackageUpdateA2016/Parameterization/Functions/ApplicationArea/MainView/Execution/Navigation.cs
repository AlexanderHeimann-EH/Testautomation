//------------------------------------------------------------------------------
// <copyright file="Navigation.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 03.02.2011
 * Time: 2:42 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;

    using Button = Ranorex.Button;

    /// <summary>
    ///     Navigation provides functionality to select/open menus, or select a
    ///     parameter within the tree.
    /// </summary>
    public class Navigation : MarshalByRefObject, INavigation
    {
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
        ///     Search specified parameter via parameter page -> navigation area -> tree
        /// </summary>
        /// <param name="path">Tree path to and including parameter</param>
        /// <returns>
        ///     <br>True: If everything worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SearchAndSelectParameter(string path)
        {
            string[] seperator = { "//" };
            string[] pathParts = path.Split(seperator, StringSplitOptions.None);
            string parameterName = pathParts[pathParts.Length - 1];

            // Get parameter in navigation area
            TreeItem treeItem = this.GetTreeItemByPath(path);
            if (treeItem != null)
            {
                // Select TreeItem to enable parameter related page at application area
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter [" + parameterName + "] is found.");
                var location = new Location(treeItem.Element.Size.Width / 3, treeItem.Element.Size.Height - (treeItem.Element.Size.Height - 1));
                treeItem.Click(location);
                return true;
            }

            // Return feedback that parameter is not found
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Path [" + path + "] is not valid.");
            return false;
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
        ///     Search and returns a tree item behind a specified path.
        /// </summary>
        /// <param name="strPath">Item (menu / parameter) to search for.</param>
        /// <returns>
        ///     <br>TreeItem: If call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        private TreeItem GetTreeItemByPath(string strPath)
        {
            string[] seperator = { "//" };
            string[] pathParts = strPath.Split(seperator, StringSplitOptions.None);

            int counter = 0;
            int lastFoundTreeItemChildIndex = -1;
            TreeItem lastFoundTreeItem = null;
            TreeItem treeItem = null;
            try
            {
                for (counter = 0; counter < pathParts.Length; counter++)
                {
                    // Get treeitem if it is visible at current GUI
                    treeItem = NavigationElements.GetTreeItem(pathParts[counter], lastFoundTreeItemChildIndex);

                    if (counter == pathParts.Length - 2 && treeItem != null)
                    {
                        treeItem.Click();
                        Parameter parameter = new Application().GetParameterStateFast(pathParts[pathParts.Length - 1]);
                        if (parameter.ParameterState != ParameterState.NotRecognized)
                        {
                            return treeItem;
                        }
                    }

                    if (treeItem == null)
                    {
                        // If scrollbar active and not null
                        if (NavigationElements.VerticalScrollbar != null && NavigationElements.VerticalScrollbar.Enabled)
                        {
                            if (NavigationElements.PageUpButton.ScreenRectangle.Size.Height == 0)
                            {
                                // If scrollbar is on top
                                // Scroll down
                                treeItem = this.ScrollAndSearchTreeItem(NavigationElements.PageDownButton, pathParts[counter], lastFoundTreeItemChildIndex);
                            } 
                            else if (NavigationElements.PageDownButton.ScreenRectangle.Size.Height == 0)
                            {
                                // If scrollbar is on bottom
                                // Scroll up
                                treeItem = this.ScrollAndSearchTreeItem(NavigationElements.PageUpButton, pathParts[counter], lastFoundTreeItemChildIndex);
                            } 
                            else if (NavigationElements.PageUpButton.ScreenRectangle.Size.Height <=
                                     NavigationElements.PageDownButton.ScreenRectangle.Size.Height)
                            {
                                // If scrollbar is nearly on top
                                // Scroll down first
                                treeItem = this.ScrollAndSearchTreeItem(NavigationElements.PageDownButton, pathParts[counter], lastFoundTreeItemChildIndex);
                                
                                // Scroll up as next if treeItem noch found
                                if (treeItem == null)
                                {
                                    treeItem = this.ScrollAndSearchTreeItem(NavigationElements.PageUpButton, pathParts[counter], lastFoundTreeItemChildIndex);
                                }
                            } 
                            else if (NavigationElements.PageUpButton.ScreenRectangle.Size.Height >
                                     NavigationElements.PageDownButton.ScreenRectangle.Size.Height)
                            {   
                                // If scrollbar is nearly on bottom
                                // Scroll down first
                                treeItem = this.ScrollAndSearchTreeItem(NavigationElements.PageDownButton, pathParts[counter], lastFoundTreeItemChildIndex);

                                // Scroll up as next if treeItem noch found
                                if (treeItem == null)
                                {
                                    treeItem = this.ScrollAndSearchTreeItem(NavigationElements.PageUpButton, pathParts[counter], lastFoundTreeItemChildIndex);
                                }
                            }
                            else
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Impossible path at if-then-else structure.");
                            }
                        } 
                        else
                        {
                            // if Scrollbar not active search for treeitem with index greater than last found
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Treeitem " + "[" + pathParts[counter] + "]" + " not found");
                        }
                    }

                    if (treeItem != null)
                    {
                        treeItem.MoveTo();
                        lastFoundTreeItemChildIndex = treeItem.Element.ChildIndex;
                        lastFoundTreeItem = treeItem;
                    }

                    if (counter >= (pathParts.Length - 1))
                    {
                        continue;
                    }

                    if (treeItem != null)
                    {
                        treeItem.Expand();
                    }
                }

                return lastFoundTreeItem;
            }
            catch (Exception exception)
            {
                Log.Error("Navigation.GetTreeItemByPath@" + pathParts[counter], exception.Message);
                return null;
            }
        }

        /// <summary>
        ///     Scroll to specified direction and search for treeItem
        /// </summary>
        /// <param name="button">Button to use for scrolling</param>
        /// <param name="pathPart">TreeItem to search for</param>
        /// <param name="lastFoundTreeItemChildIndex">Reference to the latest found tree item</param>
        /// <returns>
        ///     <br>TreeItem: If call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        private TreeItem ScrollAndSearchTreeItem(Button button, string pathPart, int lastFoundTreeItemChildIndex)
        {
            try
            {
                bool isSearching = true;
                TreeItem treeItem = null;

                // While no element is found and search is going on
                while (treeItem == null && isSearching)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Scrolling...And...Searching...");
                    button.Click(DefaultValues.locDefaultLocation);
                    treeItem = NavigationElements.GetTreeItem(pathPart, lastFoundTreeItemChildIndex);
                    if (button.ScreenRectangle.Size.Height == 0)
                    {
                        isSearching = false;
                    }
                }

                return treeItem;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}