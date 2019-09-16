// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetInvalidParametersInTreeView.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 15.02.2013
 * Time: 7:44 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Flows
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.Dialogs.DtmMessages;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    /// The get invalid parameters in tree view.
    /// </summary>
    public class GetInvalidParametersInTreeView : MarshalByRefObject, IGetInvalidParametersInTreeView
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Checks an element for accessibility and moves mouse to it's position
        /// </summary>
        /// <returns>
        ///     <br>List[string]: List of invalid parameters</br>
        ///     <br>Null: If no invalid parameters are available</br>
        /// </returns>
        public List<string> Run()
        {
            try
            {
                bool search = true;
                bool searchParameter = false;

                // bool result = true;
                int lastFoundChildIndex = 0;
                Cell lastClickedCell = null;
                ScrollBar scrollBar = null;
                var invalidParameters = new List<string>();

                string strEleBuffer2 = NavigationPaths.StrNaviAreaTree;

                while (search)
                {
                    IList<TreeItem> moduleTreeList = Host.Local.Find<TreeItem>(strEleBuffer2, 20000);
                    if (moduleTreeList.Count == lastFoundChildIndex)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "End of tree - search off");

                        // 2013-09-18 Bug fix: Birgel, Eric
                        // Get possible Error message
                        string errorMessage = Execution.DtmMessages.strGetNewestUserMessage;
                        if (errorMessage != null)
                        {
                            if (errorMessage != string.Empty)
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM Error appeared");
                                invalidParameters.Add("DTM Error:" + errorMessage);
                            }
                        }

                        // ***
                        break;
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
                            if (myCell.Text == string.Empty)
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "found empty cell");
                                invalidParameters.Add("found empty cell");
                                search = false;
                                break;
                            }

                            if (!myCell.Text.Contains(":") || searchParameter)
                            {
                                if (lastFoundChildIndex != 0 && !myCell.Text.Contains(":"))
                                {
                                    // 2013-09-18 Bug fix: Birgel, Eric
                                    myCell.DoubleClick(new Location(20, 10));

                                    // this fixes the problem with to small tree view
                                    // ***
                                    Thread.Sleep(500);
                                    searchParameter = false;
                                }

                                lastClickedCell = myCell;

                                try
                                {
                                    // If item is visible
                                    if (item.Element.Visible)
                                    {
                                        if (Imaging.Contains(item, StatusIcons.StatusIcon_Insecure, Imaging.FindOptions.Default) || Imaging.Contains(item, StatusIcons.StatusIcon_Invalid, Imaging.FindOptions.Default))
                                        {
                                            int retry = 0;
                                            while (Imaging.Contains(item, StatusIcons.StatusIcon_Insecure, Imaging.FindOptions.Default) || Imaging.Contains(item, StatusIcons.StatusIcon_Invalid, Imaging.FindOptions.Default))
                                            {
                                                retry++;
                                                Thread.Sleep(500);
                                                if (retry == 15)
                                                {
                                                    break;
                                                }
                                            }

                                            if (Imaging.Contains(item, StatusIcons.StatusIcon_Insecure, Imaging.FindOptions.Default))
                                            {
                                                // result = false;
                                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "found QuestionMark " + myCell.Text);
                                                invalidParameters.Add("found QuestionMark " + myCell.Text);
                                            }
                                            else if (Imaging.Contains(item, StatusIcons.StatusIcon_Invalid, Imaging.FindOptions.Default))
                                            {
                                                // result = false;
                                                searchParameter = true;
                                                if (myCell.Text.Contains(":"))
                                                {
                                                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Found ExclamationMark on Parameter '" + myCell.Text + "'");
                                                    invalidParameters.Add("Found ExclamationMark on Parameter '" + myCell.Text + "'");
                                                }
                                                else
                                                {
                                                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Found ExclamationMark on Folder '" + myCell.Text + "'");
                                                }

                                                invalidParameters.Add("Found ExclamationMark on Folder '" + myCell.Text + "'");
                                            }
                                            else
                                            {
                                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "This part should be possible.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element Hidden");
                                    }
                                }
                                catch (Exception exception)
                                {
                                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);

                                    // result = false;
                                    return null;
                                }
                            }
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

                                if (!searchParameter)
                                {
                                    // ScrollFast
                                    while (scrollBar != null && scrollBar.Children[3].Element.ScreenRectangle.Height != 0)
                                    {
                                        scrollBar.Children[3].DoubleClick(new Location(5, 5));
                                    }
                                }
                                else
                                {
                                    // Detail Searching is need
                                    while (scrollBar != null && scrollBar.Children[3].Element.ScreenRectangle.Height != 0 && lastClickedCell.Element.Visible)
                                    {
                                        scrollBar.Children[4].Click();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "End of tree reached");
                        }
                    }
                }

                return invalidParameters;
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