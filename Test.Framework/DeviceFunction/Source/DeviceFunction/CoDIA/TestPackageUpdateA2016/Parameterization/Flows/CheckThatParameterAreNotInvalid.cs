// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckThatParameterAreNotInvalid.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class CheckThatParameterAreNotInvalid.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Flows
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using System.Threading;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    /// Class CheckThatParameterAreNotInvalid.
    /// </summary>
    public class CheckThatParameterAreNotInvalid : ICheckThatParameterAreNotInvalid
    {
        #region Public Methods and Operators

        /// <summary>
        /// The element.
        /// </summary>
        private readonly Ranorex.Core.Element navigationVerticalScrollBarElement;

        /// <summary>
        /// The number of parameter valid.
        /// </summary>
        private int numberOfParameterValid;

        /// <summary>
        /// The number of parameter invalid.
        /// </summary>
        private int numberOfParameterInvalid;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckThatParameterAreNotInvalid"/> class.
        /// </summary>
        public CheckThatParameterAreNotInvalid()
        {
            this.numberOfParameterInvalid = 0;
            this.numberOfParameterValid = 0;
            Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVerticalScrollBarElement, DefaultValues.iTimeoutDefault, out this.navigationVerticalScrollBarElement);
        }

        /// <summary>
        /// Examines the status of one or more parameter. Reports every parameter with the status 'Invalid';
        /// </summary>
        /// <param name="parameterToCheck">
        /// List with parameter to check. E.g. 'Micropilot 5x//Setup//Empty Calibration (3):, Micropilot 5x//Setup//Full Calibration (4):'
        /// </param>
        /// <returns>
        /// <c>true</c> if no parameter is found with status 'Invalid', <c>false</c> otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(List<string> parameterToCheck)
        {
            bool result = true;
            foreach (var parameter in parameterToCheck)
            {
                if (Flows.GetParameterStatus.FromParameter(parameter) == "Invalid")
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: '" + parameter + "' is invalid.");
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// Examines the status of all parameter the DTM contains. Reports every parameter with the status 'Invalid';
        /// </summary>
        /// <returns>
        /// <c>true</c> if no parameter is found with status 'Invalid', <c>false</c> otherwise.
        /// </returns>
        public bool Run()
        {
            // 2016-12-27: To delete after Performance Measuring
            var watch = new Stopwatch();
            
            bool result = true;
            bool search = true;
            int lastFoundChildIndex = 0;
            Cell myCell = null;
            Cell lastClickedCell = null;
            string pathToNavigationAreaTreeItems;
            IList<TreeItem> treeListItems = null;
            TreeItem treeItem = null;
            int numberOfParameters = 0;
            int numberOfMenuItems = 0;

            try
            {
                // 2016-12-27: To delete after Performance Measuring
                watch.Start();
                
                // Assign path to navigation area tree items to variable
                pathToNavigationAreaTreeItems = NavigationPaths.StrNaviAreaTree;

                // Get all available tree items 
                treeListItems = Host.Local.Find<TreeItem>(pathToNavigationAreaTreeItems, 20000);
                if (treeListItems == null || treeListItems.Count == 0)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter tree is null or empty.");
                    result = false;
                }
                else
                {
                    // Make sure first element of tree is visible and selected
                    while (treeListItems[0].Visible == false || treeListItems[0].Selected == false)
                    {
                        // Todo: Make sure that navigation tree is in focus
                        Keyboard.Press(System.Windows.Forms.Keys.PageUp);
                    }

                    // Collapse first element of tree
                    treeListItems[0].CollapseAll();

                    // Traverse whole tree
                    while (search)
                    {
                        // Get all available tree items 
                        treeListItems = Host.Local.Find<TreeItem>(pathToNavigationAreaTreeItems, DefaultValues.GeneralTimeout);

                        // Check if end of tree is reached
                        if (lastFoundChildIndex == treeListItems.Count)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "End of tree - search off");
                            search = false;
                        }

                        // For every available tree item
                        for (; lastFoundChildIndex < treeListItems.Count; lastFoundChildIndex++)
                        {
                            string parameterName = "default";
                            try
                            {
                                // Get current tree item
                                treeItem = treeListItems[lastFoundChildIndex];
                                Mouse.MoveTo(treeItem, Location.UpperLeft);

                                // Get tree item´s Accessible Default Action
                                parameterName = treeItem.Children[0].GetAttributeValue<string>("Text");
                                
                                // Check for menu; otherwise it is a parameter
                                // if (accessibleDefaultAction.Equals("Expand"))
                                if (!parameterName.Contains(":"))
                                {
                                    numberOfMenuItems++;

                                    // Expand menu item
                                    myCell = this.ExpandCurrentTreeItem(treeItem);

                                    // Check Application Area for parameter state
                                    result &= this.CheckApplicationAreaForInvalidValues();  

                                    Button button;

                                    // Get button Next Page from Application Area
                                    Host.Local.TryFindSingle(ApplicationPaths.strApplAreaNaviNextPage, DefaultValues.iTimeoutShort, out button);

                                    // Check if button to next page is available
                                    if (button != null)
                                    {
                                        // While other pages available
                                        while (button.Enabled)
                                        {
                                            Mouse.Click(button);
                                            Thread.Sleep(500);

                                            // Check Application Area for parameter state
                                            result &= this.CheckApplicationAreaForInvalidValues();
                                        }
                                    }
                                }
                                else
                                {
                                    numberOfParameters++;
                                }

                                lastClickedCell = myCell;
                            }
                            catch (Exception exception)
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                                Log.Info("1. parameterName:", parameterName);
                                Log.Screenshot();
                                throw;
                            }

                            if (this.navigationVerticalScrollBarElement != null && this.navigationVerticalScrollBarElement.Visible)
                            {
                                search = this.ScrollDown();    
                            }

                            if (search == false)
                            {
                                break;
                            }
                        }
                    }
                }

                // 2016-12-27: To delete after Performance Measuring
                watch.Stop();
                Log.Info("Number of valid Parameter", this.numberOfParameterValid.ToString(CultureInfo.InvariantCulture));
                Log.Info("Number of invalid Parameter", this.numberOfParameterInvalid.ToString(CultureInfo.InvariantCulture));
                Log.Info("Time needed for CheckThatParameterAreNotInvalid:", watch.Elapsed.ToString());
                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                Log.Info("1. result:", result.ToString());
                Log.Info("2. search:", search.ToString());
                Log.Info("3. lastFoundChildIndex", lastFoundChildIndex.ToString(CultureInfo.InvariantCulture));
                if (myCell != null)
                {
                    Log.Info("myCell", myCell.ToString());
                }

                if (lastClickedCell != null)
                {
                    Log.Info("4. lastClickedCell", lastClickedCell.ToString());
                }

                if (treeListItems != null)
                {
                    Log.Info("5. moduleTreeList", treeListItems.Count.ToString(CultureInfo.InvariantCulture));    
                }

                if (treeItem != null)
                {
                    Log.Info("6. treeItem", treeItem.ToString());    
                }
                
                // 2016-12-27: To delete after Performance Measuring
                watch.Stop();
                Log.Info("Time needed for CheckThatParameterAreNotInvalid:", watch.Elapsed.ToString());
                Log.Info("numberOfParameters", numberOfParameters.ToString(CultureInfo.InvariantCulture));
                Log.Info("numberOfMenuItems", numberOfMenuItems.ToString(CultureInfo.InvariantCulture));
                Log.Screenshot();
                return false;
            }
        }

        #endregion

        /// <summary>
        /// The expand current tree item.
        /// </summary>
        /// <param name="treeItem">
        /// The tree item.
        /// </param>
        /// <returns>
        /// The <see cref="Cell"/>.
        /// </returns>
        private Cell ExpandCurrentTreeItem(TreeItem treeItem)
        {
            try
            {
                Cell myCell = null;

                // Check if tree items has cells as childs
                if (treeItem.Children.Count > 0)
                {
                    // Get most left Cell from tree item in Navigation Area
                    myCell = treeItem.Children[0].Element;
                }

                // Check if cell is accessible
                if (myCell != null)
                {
                    // Show where mouse is and what is to double clicked
                    // 2013-09-18 Bug fix: Birgel, Eric
                    myCell.DoubleClick(Location.UpperLeft);

                    // this fixes the problem with to small tree view
                    Thread.Sleep(500);
                }

                return myCell;
            }
            catch (Exception exception)
            {
                Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// The scroll down.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ScrollDown()
        {
            try
            {
                Button buttonPageDown;
                if (Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVScrollBarPageDown, DefaultValues.iTimeoutShort, out buttonPageDown))
                {
                    Button buttonLineDown;
                    if (Host.Local.TryFindSingle(NavigationPaths.StrNaviAreaVScrollBarLineDown, DefaultValues.iTimeoutShort, out buttonLineDown))
                    {
                        while (buttonPageDown.ScreenRectangle.Height != 0)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Scroll Down.");

                            // Scroll down
                            Mouse.Click(buttonLineDown);
                        }
                    }
                }

                IList<TreeItem> treeItems;
                treeItems = Host.Local.Find<TreeItem>(NavigationPaths.StrNaviAreaTreeCollapsed, DefaultValues.iTimeoutDefault);
                if (treeItems == null)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No more Tree Items available.");
                    return false;
                }

                if (treeItems.Count == 0)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No more Tree Items available.");
                    return false;
                }

                return true;
            }
            catch (Exception exception)
            {
                Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The check application area for invalid values.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckApplicationAreaForInvalidValues()
        {
            try
            {
                bool result = false;
                Container container;

                // Get container for parameter in Application Area
                Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaDtmDisplayArea, DefaultValues.iTimeoutDefault, out container);

                // Check if container for parameter in Application Area is accessible
                if (container != null)
                {
                    // Get labels from application area
                    IList<Text> labelList = container.Find<Text>(ApplicationPaths.StrApplAreaParameterLabel);

                    // For all available parameter lables
                    foreach (Text text in labelList)
                    {
                        // Get lables parameter 
                        Parameter param = new Application().GetParameterStateFast(text.TextValue);

                        // Check if parameter state is invalid
                        if (param.ParameterState.ToString() == "Invalid")
                        {
                            this.numberOfParameterInvalid++;
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: '" + param.ParameterName + "' is invalid.");
                            result = false;
                        }
                        else
                        {
                            this.numberOfParameterValid++;
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: '" + param.ParameterName + "' has status: " + param.ParameterState);
                            result = true;
                        }
                    }
                }
                else
                {
                    Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Applicaton Area Container could not be found.");
                }

                return result;
            }
            catch (Exception exception)
            {
                Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}