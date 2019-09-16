// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Selection.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Compare.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Compare.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    ///     Provides functions for action area at module Compare
    /// </summary>
    public class Selection : ISelection
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Open file browser for dataset 1
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Dataset1()
        {
            try
            {
                Log.Info("DeviceFunction.Modules.Compare.MainView.Areas.Selection.Dataset2", "Get button [ButtonDataset1]");
                return this.Dataset(new SelectionElements().ButtonDataset1);
            }
            catch (Exception exception)
            {
                Log.Error("DeviceFunction.Modules.Compare.MainView.Areas.Selection.Dataset1", exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Open file browser for dataset 2
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Dataset2()
        {
            try
            {
                Log.Info("DeviceFunction.Modules.Compare.MainView.Areas.Selection.Dataset2", "Get button [ButtonDataset2]");
                return this.Dataset(new SelectionElements().ButtonDataset2);
            }
            catch (Exception exception)
            {
                Log.Error("DeviceFunction.Modules.Compare.MainView.Areas.Selection.Dataset2", exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Get list of list items after compare
        /// </summary>
        /// <returns>
        /// List with entries
        /// </returns>
        public IList<ListItem> Entries()
        {
            try
            {
                IList<ListItem> list = (new SelectionElements()).ListItemsMode;
                return list;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        ///     Open mode selection
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool OpenSelectMode()
        {
            try
            {
                Log.Info("DeviceFunction.Modules.Compare.MainView.Areas.Selection.Dataset2", "Get button [ButtonDataset1]");
                return this.Dataset(new SelectionElements().ButtonMode);
            }
            catch (Exception exception)
            {
                Log.Error("DeviceFunction.Modules.Compare.MainView.Areas.Selection.Dataset1", exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Select compare mode
        /// </summary>
        /// <param name="index">
        /// Entry to select, starting with 0
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SelectMode(int index)
        {
            bool success = false;
            try
            {
                Button button = (new SelectionElements()).ButtonMode;
                if (button != null && button.Enabled)
                {
                    Mouse.MoveTo(button, 500);
                    button.Click();
                }

                IList<ListItem> modeListItems = (new SelectionElements()).ListItemsMode;
                if (modeListItems != null && modeListItems.Count > 0)
                {
                    ListItem listItem = modeListItems[index];
                    listItem.Click();
                    success = true;
                }

                return success;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Select Mode via text, returns true when mode is set
        /// </summary>
        /// <param name="mode">
        /// Entry to select
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SelectMode(string mode)
        {
            bool success = false;

            try
            {
                Button button = (new SelectionElements()).ButtonMode;
                if (button != null && button.Enabled)
                {
                    Mouse.MoveTo(button, 500);
                    button.Click();
                }

                IList<ListItem> modeListItems = (new SelectionElements()).ListItemsMode;
                if (modeListItems != null && modeListItems.Count > 0)
                {
                    bool stringFound = false;
                    while (stringFound == false)
                    {
                        foreach (ListItem listItem in modeListItems)
                        {
                            if (!listItem.Text.Equals(mode))
                            {
                                continue;
                            }

                            listItem.Click();
                            stringFound = true;
                            success = true;
                        }
                    }
                }

                return success;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Open file browser for specified dataset
        /// </summary>
        /// <param name="dataset">
        /// Button to be pressed
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        private bool Dataset(Button dataset)
        {
            try
            {
                Button button = dataset;
                if (button != null && button.Enabled)
                {
                    Mouse.MoveTo(button, 500);
                    button.Click();
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not found");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion
    }
}