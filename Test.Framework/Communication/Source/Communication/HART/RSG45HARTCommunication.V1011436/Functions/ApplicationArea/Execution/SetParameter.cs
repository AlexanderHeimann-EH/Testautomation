using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using EH.PCPS.TestAutomation.Common.Tools;
using System.Reflection;
using EH.PCPS.TestAutomation.Common;

namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.Functions.ApplicationArea.Execution
{
    /// <summary>
    /// Provides functionality to set parameter for different control types
    /// </summary>
    public class SetParameter
    {
        /// <summary>
        /// Set a specific control to a specific value
        /// </summary>
        /// <param name="element">The control to set</param>
        /// <param name="elementOpen">The button to open the control</param>
        /// <param name="value">The value to set</param>
        /// <returns>
        ///     <br>True: if value was set</br>
        ///     <br>False: if value could not be set</br>
        /// </returns>
        public bool SetParameterValue(Element element, Element elementOpen, string value)
        {
            if (element == null || value == string.Empty)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is null or value is empty");
                return false;
            }

            return SetComboBoxValue(element, elementOpen, value);   
        }
        /// <summary>
        /// Set a specific control to a specific value
        /// </summary>
        /// <param name="element">The control to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>
        ///     <br>True: if value was set</br>
        ///     <br>False: if value could not be set</br>
        /// </returns>
        public bool SetParameterValue(Element element, string value)
        {
            if (element == null || value == string.Empty)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is null or value is empty");
                return false;
            }

            return SetTextValue(element, value); 
        }

        #region Private

        /// <summary>
        ///     Set a text control to a specified value
        /// </summary>
        /// <param name="element">parameter to set</param>
        /// <param name="value">value to set</param>
        /// <returns>
        ///     <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        private bool SetTextValue(Element element, string value)
        {
            if (element != null && element.Enabled)
            {
                element.Focus();

                // To slow things down
                Mouse.MoveTo(element, 500);
                element.Focus();
                Keyboard.Press(value);
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text is not available.");
            return false;
        }

        /// <summary>
        ///     Set a comboBox control to a specified value
        /// </summary>
        /// <param name="element">parameter to set</param>
        /// <param name="elementOpen">parameter button to open cbox</param>
        /// <param name="value">value to set</param>
        /// <returns>
        ///     <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        private bool SetComboBoxValue(Element element, Element elementOpen, string value)
        {
            if (element == null || element.Enabled == false)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ComboBox is not available.");
                return false;
            }

            // To slow things down
            Mouse.MoveTo(elementOpen, 500);
            Mouse.Click(elementOpen, DefaultValues.locDefaultLocation);
            IList<ListItem> listItems = (new RSG45HARTCommunication.V1011436.GUI.RSG45HARTCommRepoElements()).ComboboxList;

            if (listItems == null || listItems.Count <= 0)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ListItems are not available.");
                return false;
            }

            bool itemFound = this.FindAndSelectValueInComboBox(listItems, value);
            if (itemFound == false)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ListItem is not available.");
                return false;
            }
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
        private bool FindAndSelectValueInComboBox(IList<ListItem> listItems, string value)
        {
            bool isFound = false;
            ListItem listItem = null;
            int counter = 0;

            // Check if a listitem contains search string
            foreach (ListItem item in listItems)
            {
                if (item.Text != value)
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

        #endregion 
    }
}
