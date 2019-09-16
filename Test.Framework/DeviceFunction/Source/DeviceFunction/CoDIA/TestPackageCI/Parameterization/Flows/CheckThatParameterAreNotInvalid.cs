// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckThatParameterAreNotInvalid.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class CheckThatParameterAreNotInvalid.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Flows
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Threading;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;

    using Application = EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution.Application;
    using Button = Ranorex.Button;

    /// <summary>
    /// Class CheckThatParameterAreNotInvalid.cs.
    /// </summary>
    public class CheckThatParameterAreNotInvalid : ICheckThatParameterAreNotInvalid
    {
        #region properties

        /// <summary>
        /// The element scroll bar.
        /// </summary>
        private readonly Ranorex.Core.Element elementScrollBar;

        /// <summary>
        /// The application.
        /// </summary>
        private Application application;

        /// <summary>
        /// The is next button initialized.
        /// </summary>
        private bool isButtonNextPageInitialized;

        /// <summary>
        /// The are parameter in tree.
        /// </summary>
        private bool areParameterInTree;

        /// <summary>
        /// The button line down.
        /// </summary>
        private Button buttonLineDown;

        /// <summary>
        /// The button page down.
        /// </summary>
        private Button buttonPageDown;

        /// <summary>
        /// The button next page.
        /// </summary>
        private Button buttonNextPage;

        /// <summary>
        /// The number of menus.
        /// </summary>
        private int numberOfMenus;

        /// <summary>
        /// The number of parameter.
        /// </summary>
        private int numberOfParameter;

        /// <summary>
        /// The number of parameter valid.
        /// </summary>
        private int numberOfParameterValid;

        /// <summary>
        /// The number of parameter Invalid.
        /// </summary>
        private int numberOfParameterInvalid;

        /// <summary>
        /// The number of parameter insecure.
        /// </summary>
        private int numberOfParameterInsecure;

        /// <summary>
        /// The number of parameter modified.
        /// </summary>
        private int numberOfParameterModified;

        /// <summary>
        /// The number of parameter dynamic.
        /// </summary>
        private int numberOfParameterDynamic;

        /// <summary>
        /// The result.
        /// </summary>
        private bool result = true;

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
        private int numberOfChildsBeforeUpdate;

        /// <summary>
        /// The navigation area.
        /// </summary>
        private Navigation navigationArea;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckThatParameterAreNotInvalid"/> class. 
        /// </summary>
        public CheckThatParameterAreNotInvalid()
        {
            Container dataPanelBuffer;
            this.navigationArea = new Navigation();
            Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVerticalScrollBarElement, out this.elementScrollBar);
            Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaTreeDataPanel, out dataPanelBuffer);
            this.navigationArea.DataPanel = dataPanelBuffer;
            
            this.numberOfMenus = 0;
            this.numberOfParameter = 0;
            this.numberOfParameterInvalid = 0;
            this.numberOfParameterValid = 0;
            this.numberOfParameterDynamic = 0;
            this.numberOfParameterInsecure = 0;
            this.numberOfParameterModified = 0;
            this.buttonLineDown = null;
            this.buttonPageDown = null;
            this.result = true;
            this.isOngoing = true;
            this.isUpdatedNeeded = false;
            this.counter = 0;
            this.lastIndex = 0;

            if (this.navigationArea.DataPanel != null)
            {
                this.navigationArea.DataPanelChildren = this.navigationArea.DataPanel.FindChildren<TreeItem>();
                this.numberOfChildsBeforeUpdate = this.navigationArea.DataPanelChildren.Count;
            }
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="parameterList">
        /// The parameter list.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(List<string> parameterList)
        {
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Method is not implemented yet.");
            return false;
        }

        /// <summary>
        /// Examines the status of all parameter the DTM contains. Reports every parameter with the status 'Invalid';
        /// </summary>
        /// <returns>
        /// <c>true</c> if no parameter is found with status 'Invalid', <c>false</c> otherwise.
        /// </returns>
        public bool Run()
        {
            this.areParameterInTree = this.navigationArea.AreParameterInTree();

            if (this.navigationArea.DataPanelChildren != null && this.navigationArea.DataPanelChildren.Count > 0)
            {
                this.navigationArea.SelectFirstTreeItemAndCollapseTree(this.navigationArea.DataPanelChildren[0]);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                while (this.isOngoing)
                {
                    if (this.isUpdatedNeeded)
                    {
                        this.UpdateTree();
                    }

                    for (this.counter = this.lastIndex; this.counter <= this.navigationArea.DataPanelChildren.Count - 1; this.counter++)
                    {
                        string accessibleName = this.navigationArea.DataPanelChildren[this.counter].Element.GetAttributeValueText("accessiblename");
                        if (accessibleName != null)
                        {
                            //// BUG: THIS FUNCTION IS NEVER EXECUTED
                            //// If current tree item is a menu, click button line down a single time to avoid tree item in non clickable area
                            if (accessibleName.Contains("Navigation_Menu_"))
                            {
                                if (this.navigationArea.IsButtonScrollBarDownInitialized)
                                {
                                    this.buttonLineDown.Click();
                                }
                            }

                            // If current tree item is a wanted navigation area tree item
                            if (accessibleName.Contains("Navigation_"))
                            {
                                // Get current tree item from list of tree item
                                var treeItem = this.navigationArea.DataPanelChildren[this.counter];
                                TreeItem nextTreeItem = null;

                                // If next tree item is in range of for-loop, get it
                                if (this.navigationArea.DataPanelChildren.Count - 1 >= this.counter + 1)
                                {
                                    nextTreeItem = this.navigationArea.DataPanelChildren[this.counter + 1];
                                }

                                // If next tree item is null
                                //   If no scrollbar is available, this means current tree item is in clickable area
                                //     Execute Handle Tree Item
                                //   If scrollbar is availalbe, this means current tree item is not in clickable area
                                //     Scroll to bottom to get current tree item in clickable area
                                //     Execute Handle Tree Item
                                if (nextTreeItem == null)
                                {
                                    if (this.navigationArea.IsButtonScrollBarDownInitialized)
                                    {
                                        // scrolle bis zum ende => aktuelles element kommt in den anklickbaren bereich
                                        while (this.buttonLineDown != null && this.buttonPageDown.ScreenRectangle.Height > 0)
                                        {
                                            // Scroll down for some lines
                                            Mouse.Click(this.buttonPageDown);
                                        }
                                    }

                                    treeItem.Click();
                                    this.HandleTreeItem(treeItem);
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
                                        this.ScrollDownTreeUntilTreeItemIsVisibleOrScrollbarBottomReached(nextTreeItem);
                                    }

                                    this.HandleTreeItem(treeItem);
                                }
                            }

                            this.lastIndex = this.counter;
                        }
                    }

                    this.lastIndex = this.lastIndex + 1;
                    this.isUpdatedNeeded = true;
                }

                stopwatch.Stop();
                Log.Info("Time needed: ", stopwatch.Elapsed.ToString());
                this.LogOverviewOfMenuAndParameters();
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There are no tree items available.");
                return false;
            }

            this.LogInvalidParameters();

            return this.result;
        }

        /// <summary>
        /// The log overview of menu and parameters.
        /// </summary>
        private void LogOverviewOfMenuAndParameters()
        {
            Log.Info("Number of Menus: ", this.numberOfMenus.ToString(CultureInfo.InvariantCulture));
            Log.Info("Number of Parameter: ", this.numberOfParameter.ToString(CultureInfo.InvariantCulture));
            Log.Info("Number of valid Parameter: ", this.numberOfParameterValid.ToString(CultureInfo.InvariantCulture));
            Log.Info("Number of invalid Parameter: ", this.numberOfParameterInvalid.ToString(CultureInfo.InvariantCulture));
            Log.Info("Number of dynamic Parameter: ", this.numberOfParameterDynamic.ToString(CultureInfo.InvariantCulture));
            Log.Info("Number of modified Parameter: ", this.numberOfParameterModified.ToString(CultureInfo.InvariantCulture));
            Log.Info("Number of insecure Parameter: ", this.numberOfParameterInsecure.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// The log invalid parameters.
        /// </summary>
        private void LogInvalidParameters()
        {
            if (this.numberOfParameterInvalid > 0)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There is at least one invalid parameter");
                foreach (var item in this.navigationArea.listOfInvalidParameters)
                {
                    Log.Error(string.Empty, item);
                }

                this.result = false;
            }
        }

        /// <summary>
        /// The scroll down tree until tree item is visible.
        /// </summary>
        /// <param name="nextTreeItem">
        /// The next tree item.
        /// </param>
        private void ScrollDownTreeUntilTreeItemIsVisibleOrScrollbarBottomReached(TreeItem nextTreeItem)
        {
            this.navigationArea.ScrollDownTreeUntilTreeItemIsVisibleOrScrollbarBottomReached(nextTreeItem);
        }

        /// <summary>
        /// The handle tree item.
        /// </summary>
        /// <param name="treeItem">
        /// The tree item.
        /// </param>
        private void HandleTreeItem(TreeItem treeItem)
        {
            string parameterName;
            try
            {
                if (treeItem != null)
                {
                    string accessibleName = treeItem.Element.GetAttributeValueText("AccessibleName");
                    if (accessibleName != null)
                    {
                        parameterName = treeItem.Children[0].Element.GetAttributeValueText("Text");
                        if (parameterName != null)
                        {
                            // If tree item is a menu and not a parameter
                            if (accessibleName.Contains("Navigation_Menu_"))
                            {
                                this.numberOfMenus++;
                                Log.Info("Menu Name:", parameterName);
                                Mouse.MoveTo(treeItem.Children[0]);
                                this.navigationArea.ExpandMenu(treeItem);

                                // Mouse.DoubleClick(treeItem.Children[0]);
                                Thread.Sleep(500);
                                if (!this.areParameterInTree)
                                {
                                    Mouse.Click(treeItem);
                                    this.HandleApplicationArea();
                                }
                            }
                            else if (accessibleName.Contains("Navigation_Variable"))
                            {
                                this.numberOfParameter++;
                                
                                string[] accessibleNameParts = accessibleName.Split('_');
                                string parameterStatus = accessibleNameParts[accessibleNameParts.Length - 1];

                                Stopwatch stopwatch = new Stopwatch();
                                stopwatch.Start();

                                while (parameterStatus.Equals("Insecure"))
                                {
                                    if (stopwatch.ElapsedMilliseconds > 30000)
                                    {
                                        treeItem.Click();
                                    }

                                    accessibleName = treeItem.Element.GetAttributeValueText("AccessibleName");
                                    accessibleNameParts = accessibleName.Split('_');
                                    parameterStatus = accessibleNameParts[accessibleNameParts.Length - 1];
                                }

                                stopwatch.Stop();
                                
                                Log.Info(string.Format("Parameter Status: {1} \t\t, Parameter Name: {0}", parameterName, parameterStatus));

                                // "Insecure", "Invalid", "Valid", "Modified", "Dynamic1" or "Dynamic2"
                                switch (parameterStatus)
                                {
                                    case "Insecure":
                                        {   
                                            this.numberOfParameterInsecure++;
                                            break;
                                        }

                                    case "Invalid":
                                        {
                                            this.navigationArea.listOfInvalidParameters.Add(parameterName);
                                            this.numberOfParameterInvalid++;
                                            break;
                                        }

                                    case "Valid":
                                        {
                                            this.numberOfParameterValid++;
                                            break;
                                        }

                                    case "Modified":
                                        {
                                            this.numberOfParameterModified++;
                                            break;
                                        }

                                    case "Dynamic1":
                                        {
                                            this.numberOfParameterDynamic++;
                                            break;
                                        }

                                    case "Dynamic2":
                                        {
                                            this.numberOfParameterDynamic++;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "TreeItem is not Menu or Parameter");
                            }
                        }
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "AccessibleName is null");
                    }
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "TreeItem is null");
                }
            }
            catch (Exception exception)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Counter: " + this.counter.ToString(CultureInfo.InvariantCulture));
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Number of tree items: " + this.numberOfChildsBeforeUpdate.ToString(CultureInfo.InvariantCulture));
                Log.Info(string.Empty, exception.Message);
                throw;
            }
        }

        /// <summary>
        /// The handle application area.
        /// </summary>
        private void HandleApplicationArea()
        {
            this.application = new Application();
            this.application.CheckApplicationAreaForInvalidValues();
            this.AddApplicationCounterToCurrentValues(this.application);
            if (!this.isButtonNextPageInitialized)
            {
                // Get button Next Page from Application Area
                Host.Local.TryFindSingle(ApplicationPaths.strApplAreaNaviNextPage, DefaultValues.iTimeoutShort, out this.buttonNextPage);
                this.isButtonNextPageInitialized = true;
            }

            // Check if button to next page is available
            if (this.buttonNextPage != null)
            {
                // While other pages available
                while (this.buttonNextPage.Enabled)
                {
                    Mouse.Click(this.buttonNextPage);
                    Thread.Sleep(500);

                    // Check Application Area for parameter state
                    this.application = new Application();
                    this.application.CheckApplicationAreaForInvalidValues();
                    this.AddApplicationCounterToCurrentValues(this.application);
                }
            }
        }

        /// <summary>
        /// The add application counter to current values.
        /// </summary>
        /// <param name="applicationArea">
        /// The application.
        /// </param>
        private void AddApplicationCounterToCurrentValues(Application applicationArea)
        {
            this.numberOfParameterDynamic += applicationArea.NumberOfParameterDynamic;
            this.numberOfParameterInsecure += applicationArea.NumberOfParameterInsecure;
            this.numberOfParameterInvalid += applicationArea.NumberOfParameterInvalid;
            this.numberOfParameterModified += applicationArea.NumberOfParameterModified;
            this.numberOfParameterValid += applicationArea.NumberOfParameterValid;
        }

        /// <summary>
        /// The update tree.
        /// </summary>
        private void UpdateTree()
        {
            this.numberOfChildsBeforeUpdate = this.navigationArea.DataPanelChildren.Count;
            this.navigationArea.DataPanelChildren = this.navigationArea.DataPanel.FindChildren<TreeItem>();

            if (this.numberOfChildsBeforeUpdate == this.navigationArea.DataPanelChildren.Count)
            {
                this.isOngoing = false;
            }
        }

        #endregion
    }
}