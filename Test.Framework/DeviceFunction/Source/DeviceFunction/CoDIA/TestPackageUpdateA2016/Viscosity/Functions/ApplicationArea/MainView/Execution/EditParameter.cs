//------------------------------------------------------------------------------
// <copyright file="EditParameter.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides methods for editing different parameter types
    /// </summary>
    public class EditParameter : MarshalByRefObject, IEditParameter
    {
        #region public

        /// <summary>
        ///     Set a specific control to a specific value
        /// </summary>
        /// <param name="element">control to set</param>
        /// <param name="value">value to set</param>
        /// <returns>
        ///     <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public bool SetParameterValue(Element element, string value)
        {
            if (element == null || value == string.Empty)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is null or value is empty");
                return false;
            }

            string controlType = element.GetAttributeValue("controltype").ToString();

            // TODO: 2012-11-01: ControlType an zentraler Stelle als Enum verwalten.
            switch (controlType)
            {
                case "EH.PCSW.PresentationLayer.WinFormBase.Controls.EditControl":
                    {
                        return this.SetTextValue(element, value);
                    }

                case "EH.PCSW.PresentationLayer.WinFormBase.Controls.ValidatedEditNumberControl":
                    {
                        return this.SetTextValue(element, value);
                    }

                case "EH.PCSW.PresentationLayer.WinFormBase.Controls.ComboBoxControl":
                    {
                        return this.SetComboBoxValue(element, value);
                    }

                case "EH.PCSW.PresentationLayer.WinFormBase.Controls.NumericTextBox":
                    {
                        return this.SetTextValue(element, value);
                    }

                default:
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "Unknown ControlType [" + controlType + "].");
                        return false;
                    }
            }
        }

        /// <summary>
        /// Get value of a specific control
        /// </summary>
        /// <param name="element">control to get the value from</param>
        /// <returns>
        ///     <br>String: if everything worked fine</br>
        ///     <br>Empty String: if an error occurred</br>
        /// </returns>
        public string GetParameterValue(Element element)
        {
            if (element != null && element.Enabled)
            {
                return element.GetAttributeValue("text").ToString();
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text is not available.");
            return string.Empty;
        }

        #endregion

        #region private

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
                Mouse.MoveTo(element, 500);
                element.SetAttributeValue("Text", value);
                //element.SetAttributeValue("FloatValue", value);
                
                // Try to set the focus on the connected status icon in the down left corner, this is needed since problems occurred after focusing textboxes
                Element tabcontrol = (new TabControlElements()).TabControlViscosity;
                if (tabcontrol == null)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Unable to set focus on the tabcontrol because the element is null");
                }
                else
                {
                    tabcontrol.Focus();
                }

                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text is not available.");
            return false;
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
        private bool SetComboBoxValue(Element element, string value)
        {
            if (element == null || element.Enabled == false)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ComboBox is not available.");
                return false;
            }

            Mouse.MoveTo(element, 500);
            Mouse.Click(element, DefaultValues.locDefaultLocation);
            IList<ListItem> listItems = (new FluidPropertiesElements()).ListItemsComboBox;
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

            // check if a listitem matches search string
            foreach (ListItem item in listItems)
            {
                if (!item.Text.Equals(value))
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
                    if (counter > listItems.Count * 2)
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