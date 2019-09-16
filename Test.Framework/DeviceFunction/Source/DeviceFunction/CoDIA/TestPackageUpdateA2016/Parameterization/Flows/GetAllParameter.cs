// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAllParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class GetAllParameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Flows
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    /// Class GetAllParameter.
    /// </summary>
    public class GetAllParameter : IGetAllParameter
    {
        #region Public Methods and Operators

        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Parameter> Run()
        {
            try
            {
                var result = new List<Parameter>();
                bool search = true;
                int lastFoundChildIndex = 0;
                Cell lastClickedCell = null;
                ScrollBar scrollBar = null;                
                string strEleBuffer2 = NavigationPaths.StrNaviAreaTree;
                IList<TreeItem> moduleTreeList = Host.Local.Find<TreeItem>(strEleBuffer2, 20000);

                if (moduleTreeList == null || moduleTreeList.Count == 0)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter tree is null or empty.");
                }
                else
                {
                    // Make sure first element for the tree is visible and collapsed
                    Button pageUp = NavigationElements.PageUpButton;
                    if (pageUp != null)
                    {
                        while (pageUp.Enabled && pageUp.Visible)
                        {
                            pageUp.Press();
                        }
                    }

                    TreeItem treeItem = moduleTreeList[0];
                    treeItem.CollapseAll();

                    while (search)
                    {
                        moduleTreeList = Host.Local.Find<TreeItem>(strEleBuffer2, 20000);

                        if (moduleTreeList.Count == lastFoundChildIndex)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "End of tree - search off");
                            search = false;
                        }

                        for (; lastFoundChildIndex < moduleTreeList.Count; lastFoundChildIndex++)
                        {
                            TreeItem item = moduleTreeList[lastFoundChildIndex];
                            Cell myCell = null;
                            Cell nextCell = null;

                            // Get Cell
                            if (item.Children.Count > 0)
                            {
                                myCell = item.Children[0].Element;
                            }

                            if (myCell != null)
                            {
                                if (!myCell.Text.Contains(":"))
                                {
                                    // 2013-09-18 Bug fix: Birgel, Eric
                                    myCell.DoubleClick(new Location(20, 10));

                                    // this fixes the problem with to small tree view
                                    // ***
                                    Thread.Sleep(500);
                                }
                                else
                                {
                                    // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                                    myCell.Click();
                                    Parameter param = new Application().GetParameter(myCell.Text);                                   
                                    result.Add(param);

                                    // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                                }

                                lastClickedCell = myCell;
                            }

                            // ----------------   Scroll   ------------------------
                            // ----------------------------------------------------
                            if (moduleTreeList.Count > lastFoundChildIndex + 2)
                            {
                                // Scroll if necessary
                                if (moduleTreeList[lastFoundChildIndex + 2].Children.Count > 0)
                                {
                                    nextCell = moduleTreeList[lastFoundChildIndex + 2].Children[0].Element;
                                }

                                if (nextCell == null && lastClickedCell != null && lastClickedCell.Element.ChildIndex < moduleTreeList.Count)
                                {
                                    if (scrollBar == null)
                                    {
                                        scrollBar = NavigationElements.VerticalScrollbar;
                                    }

                                    // ScrollFast
                                    while (scrollBar != null && scrollBar.Children[3].Element.ScreenRectangle.Height != 0)
                                    {
                                        scrollBar.Children[3].DoubleClick(new Location(5, 5));
                                    }
                                }
                            }
                            else
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "End of tree reached");
                            }
                        }
                    }
                }

                return result;
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