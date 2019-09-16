// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.ApplicationArea.MainView.Execution
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides methods for tab liquid properties within module concentration
    /// </summary>
    public class CommonMethods : ICommonMethods
    {
        #region Public Methods and Operators

        /// <summary>
        /// Get value of a specific control
        /// </summary>
        /// <param name="element">
        /// control to get the value from
        /// </param>
        /// <returns>
        /// <br>String: if everything worked fine</br>
        ///     <br>Empty String: if an error occurred</br>
        /// </returns>
        public string GetParameterValue(Element element)
        {
            if (element != null && element.Enabled)
            {
                return element.GetAttributeValue("text").ToString();
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text is not available.");
            return string.Empty;
        }

        /// <summary>
        /// Last edit by EC on 2017-09-29:
        /// Set a comboBox control to a specified value
        /// </summary>
        /// <param name="element">
        /// parameter to set
        /// </param>
        /// <param name="value">
        /// value to set
        /// </param>
        /// <returns>
        /// <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public bool SetComboBoxValue(Element element, string value)
        {
            if (element == null || element.Enabled == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ComboBox is not available.");
                return false;
            }

            Mouse.MoveTo(element, 500);
            Mouse.Click(element, DefaultValues.locDefaultLocation);
            IList<ListItem> listItems = (new CommonElements()).ListItemsComboBox;
            if (listItems == null || listItems.Count <= 0)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ListItems are not available.");
                return false;
            }

            // Last edit by EC on 2017-09-29
            Ranorex.ScrollBar scrollBar = (new CommonElements()).ScrollBar;
            if (scrollBar != null)
            {
                // Todo: Replace Workaround by checking the scrollbar
                Keyboard.Press(Keys.PageUp);
                Keyboard.Press(Keys.PageUp);
                Keyboard.Press(Keys.PageUp);
                Keyboard.Press(Keys.PageUp);
                Keyboard.Press(Keys.PageUp);
                Keyboard.Press(Keys.PageUp);
                Keyboard.Press(Keys.PageUp);
                Keyboard.Press(Keys.PageUp);
                Keyboard.Press(Keys.PageUp);
                Keyboard.Press(Keys.PageUp);
            }
            // Last edit by EC on 2017-09-29

            bool itemFound = this.FindAndSelectValueInComboBox(listItems, value);
            if (itemFound == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ListItem is not available.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Set a specific control to a specific value
        /// </summary>
        /// <param name="element">
        /// control to set
        /// </param>
        /// <param name="value">
        /// value to set
        /// </param>
        /// <returns>
        /// <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public bool SetParameterValue(Element element, string value)
        {
            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element containing parameter to change is null. Check repository.");
                return false;
            }
            else
            {
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

                    case "EH.PCSW.PresentationLayer.WinFormBase.Controls.EditNumberControl":
                        {
                            return this.SetTextValue(element, value);
                        }

                    case "EH.PCSW.PresentationLayer.WinFormBase.Controls.CoeffizientenEditNumberControl":
                        {
                            return this.SetTextValue(element, value);
                        }

                    case "EH.PCSW.PresentationLayer.WinFormBase.Controls.ComboBoxControl":
                        {
                            return this.SetComboBoxValue(element, value);
                        }

                    default:
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unknown ControlType [" + controlType + "].");
                            return false;
                        }
                }   
            }            
        }

        /// <summary>
        /// Set a text control to a specified value
        /// </summary>
        /// <param name="element">
        /// parameter to set
        /// </param>
        /// <param name="value">
        /// value to set
        /// </param>
        /// <returns>
        /// <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public bool SetTextValue(Element element, string value)
        {
            if (element != null && element.Enabled)
            {
                element.Focus();
                Mouse.MoveTo(element, 500);
                element.SetAttributeValue("FloatValue", value);
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text is not available.");
            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Searches and selects item in a combo box, scrolls if necessary
        /// </summary>
        /// <param name="listItems">
        /// list with all combo box values
        /// </param>
        /// <param name="value">
        /// string with value which should be set
        /// </param>
        /// <returns>
        /// true: if value was found and selected
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