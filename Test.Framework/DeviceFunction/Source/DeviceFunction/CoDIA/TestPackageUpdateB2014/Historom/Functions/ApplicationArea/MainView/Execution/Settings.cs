// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides methods for editing in tab "Settings" (combo boxes , text fields)
    /// </summary>
    public class Settings : ISettings
    {
        #region Public Properties

        /// <summary>
        ///     Gets text logging interval
        /// </summary>
        public string SaveIntervall
        {
            get
            {
                string logInterval = new SettingsElements().TextBoxSaveInterval.GetAttributeValueText("controltext");
                return logInterval;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Clears the logging data.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
        public bool ClearLoggingData(string value)
        {
            bool result;

            Element clearLoggingData = new SettingsElements().ComboBoxClearLoggingData;
            Element statusIcon = new SettingsElements().StatusIconClearLoggingData;
            if (clearLoggingData == null || statusIcon == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Combo box clear logging data or its status icon is null.");
            }
            else
            {
                result = this.SetComboBoxValue(clearLoggingData, value, statusIcon);
            }

            return result;
        }

        /// <summary>
        ///     Creates a list with all possible channel assignments from the combo box assign channel 1
        /// </summary>
        /// <returns>
        ///     parameter List: when call worked fine
        ///     null: if an error occurred
        /// </returns>
        public IList<ListItem> GetComboBoxValues()
        {
            Element comboBox = new SettingsElements().ComboBoxAssignmentChannel1;
            if (comboBox == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Combobox Assign Channel 1 is null");
                return null;
            }

            Mouse.MoveTo(comboBox, 500);
            Mouse.Click(comboBox);
            IList<ListItem> parameterList = new CommonElements().ListItemsComboBox;
            Mouse.Click(comboBox);

            return parameterList;
        }

        /// <summary>
        /// Gets a specified list item of a combo box when list is shown.
        /// </summary>
        /// <param name="selectValue">
        /// comboBox item to select
        /// </param>
        /// <returns>
        /// List item to select
        /// </returns>
        public ListItem GetListItem(string selectValue)
        {
            try
            {
                ListItem listItem = null;
                IList<ListItem> comboBoxList = new CommonElements().ListItemsComboBox;
                foreach (ListItem items in comboBoxList)
                {
                    bool isTrue = true;
                    string[] array = selectValue.Split(' ');

                    foreach (string part in array)
                    {
                        isTrue = isTrue && items.Text.Contains(part);
                    }

                    if (isTrue)
                    {
                        listItem = items;
                    }
                }

                if (listItem != null)
                {
                    return listItem;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Listitem " + selectValue + " not found!");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Sets the value for a given combo box
        /// </summary>
        /// <param name="comboBox">
        /// combo box which will be modified
        /// </param>
        /// <param name="inputValue">
        /// value which will be selected within the combo box
        /// </param>
        /// <param name="statusIcon">
        /// element which contains the status icon for the given combo box
        /// </param>
        /// <returns>
        /// true, if value is set; false, if an error occurred
        /// </returns>
        public bool SetComboBoxValue(Element comboBox, string inputValue, Element statusIcon)
        {
            if (comboBox == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Combo box is null");
                return false;
            }

            Mouse.MoveTo(comboBox, 500);
            Mouse.Click(comboBox);
            ListItem listItem = this.GetListItem(inputValue);
            if (listItem == null)
            {
                return false;
            }

            // scroll down or up to find value in combo box if it is not visible
            IList<ListItem> comboBoxList = new CommonElements().ListItemsComboBox;
            int counter = 0;
            while (listItem.Selected == false)
            {
                if (counter >= (comboBoxList.Count - 1))
                {
                    // list end, value not found, scrolling up now
                    Keyboard.Press(Keys.Up);
                    counter++;
                    Mouse.MoveTo(listItem);
                }
                else
                {
                    if (counter > ((comboBoxList.Count - 1) * 2))
                    {
                        // searched entire list, parameter not found
                        break;
                    }

                    // normal case, scrolling down
                    Keyboard.Press(Keys.Down);
                    counter++;
                    Mouse.MoveTo(listItem);
                }
            }

            if (listItem.Selected == false)
            {
                // Parameter not found
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter " + listItem.Text + " not found");
                return false;
            }

            // Parameter is found, click it and confirm with "enter"
            Mouse.Click(listItem, DefaultValues.locDefaultLocation, DefaultValues.durDurationShort);
            Keyboard.Press(Keys.Enter);

            return new ParameterStates().WaitForParameterUpdate(statusIcon);
        }

        /// <summary>
        /// Modifies the "Logging interval" parameter (tab Settings)
        /// </summary>
        /// <param name="inputValue">
        /// new value for logging interval
        /// </param>
        /// <returns>
        /// true, if logging interval is set; false, if an error occurred
        /// </returns>
        public bool SetLoggingInterval(string inputValue)
        {
            try
            {
                string logInterval = this.SaveIntervall;
                Element editField = new SettingsElements().TextBoxSaveInterval;
                Element statusIcon = new SettingsElements().StatusIconLogInterval;

                if (editField != null)
                {
                    Mouse.Click(editField);

                    // Delete available value
                    int count = logInterval.Length;
                    for (int counter = 0; counter < count; counter++)
                    {
                        Keyboard.Press(Keys.Delete);
                    }

                    // Enter new value
                    Keyboard.Press(inputValue);

                    // Confirm changed parameter
                    Keyboard.Press(Keys.Enter);

                    return new ParameterStates().WaitForParameterUpdate(statusIcon);
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Edit field Logging Interval is null");
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