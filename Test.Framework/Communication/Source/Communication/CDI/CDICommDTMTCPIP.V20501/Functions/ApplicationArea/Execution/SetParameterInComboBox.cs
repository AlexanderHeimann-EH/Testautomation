// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetParameterComboBox.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides functionality to set parameter for different control types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.Functions.ApplicationArea.Execution
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.GUI;
    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Provides functionality to set parameter for different control types
    /// </summary>
    public class SetParameterInComboBox
    {
        /// <summary>
        /// Set a specific control to a specific value
        /// </summary>
        /// <param name="element">The control to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>
        ///     <br>True: if value was set</br>
        ///     <br>False: if value could not be set</br>
        /// </returns>
        public static bool SetParameterValue(Element element, string value)
        {
            if (element == null || value == string.Empty)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is null or value is empty");
                return false;
            }

            return SetComboBoxValue(element, value);
        }

        /// <summary>
        ///     Set a comboBox control to a specified value
        /// </summary>
        /// <param name="element">parameter to set</param>
        /// <param name="value">value to set</param>
        /// <returns>
        ///     <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        private static bool SetComboBoxValue(Element element, string value)
        {
            if (element == null || element.Enabled == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ComboBox is not available.");
                return false;
            }

            // To slow things down
            Mouse.MoveTo(element, 500);
            Mouse.Click(element, DefaultValues.locDefaultLocation);
            IList<ListItem> listItems = (new CDICommDTMRepoElements()).ComboboxList;
         
            if (listItems == null || listItems.Count <= 0)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ListItems are not available.");
                return false;
            }

            bool itemFound = FindAndSelectValueInComboBox(listItems, value);
            if (itemFound == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ListItem is not available.");
                return false;
            }

            Keyboard.Press(Keys.Enter);
            return true;
        }

        /// <summary>
        ///     Searches and selects item in a combo box, scrolls if necessary
        /// </summary>
        /// <param name="listItems">list with all combo box values</param>
        /// <param name="value">string with value which should be set</param>
        /// <returns>
        ///     true: if value was found and selected
        ///     false: if an error occurred
        /// </returns>
        private static bool FindAndSelectValueInComboBox(IList<ListItem> listItems, string value)
        {
            bool isFound = false;
            ListItem listItem = null;
            int counter = 0;

            // Check if a listitem contains search string
            foreach (ListItem item in listItems)
            {
                if (!item.Text.Contains(value))
                {
                    continue;
                }

                listItem = item;
                isFound = true;
                break;
            }

            if (isFound == false)
            {
                return false;
            }

            Mouse.MoveTo(listItem);
            while (listItem.Selected == false)
            {
                // scrolling part                
                if (counter > listItems.Count)
                {
                    // list end, value not found, srolling up now
                    Keyboard.Press(Keys.Up);
                    Mouse.MoveTo(listItem);
                    counter++;
                }
                else
                {
                    if (counter > (listItems.Count * 2))
                    {
                        // searched entire list, parameter not found
                        break;
                    }

                    // scrolling down
                    Keyboard.Press(Keys.Down);
                    Mouse.MoveTo(listItem);
                    counter++;
                }
            }

            listItem.Click(DefaultValues.locDefaultLocation);
            return true;
        }
    }
}
