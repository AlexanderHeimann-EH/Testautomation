// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NE107Functions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   NE107 Functions
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// NE107 Functions
    /// </summary>
// ReSharper disable InconsistentNaming
    public class NE107Functions : INE107Functions
// ReSharper restore InconsistentNaming
    {
        #region Public Methods and Operators

        /// <summary>
        /// Clicks apply button.
        /// </summary>
        /// <returns>
        /// True: if button was clicked
        /// False: if an error occurred
        /// </returns>
        public bool ClickApplyButton()
        {
            bool result = true;
            Element button = new NE107Elements().ApplyButton;
            if (button == null || button.Enabled == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The Apply button is null or not enabled");
            }
            else
            {
                Mouse.MoveTo(button, 500);
                Mouse.Click(button);
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicked on Apply");
            }

            return result;
        }

        /// <summary>
        /// Clicks cancel button.
        /// </summary>
        /// <returns>
        /// True: if button was clicked
        /// False: if an error occurred
        /// </returns>
        public bool ClickCancelButton()
        {
            bool result = true;
            Element button = new NE107Elements().CancelButton;
            if (button == null || button.Enabled == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The cancel button is null or not enabled");
            }
            else
            {
                Mouse.MoveTo(button, 500);
                Mouse.Click(button);
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicked on Cancel");
            }

            return result;
        }

        /// <summary>
        /// Checks whether the NE107 Module is available or not using the tab control element
        /// </summary>
        /// <returns>
        /// true: if the module is available
        /// false: if module is not available
        /// </returns>
        public bool IsNE107ModuleAvailable()
        {
            bool result = true;
            Element tabcontrol = new NE107Elements().TabControlNE107;
            if (tabcontrol == null)
            {
                result = false;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The Tabcontrol is not found. NE107 Module is not available");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The Tabcontrol is found. NE107 Module is available");
            }

            return result;
        }

        /// <summary>
        /// The open ne 107 configuration.
        /// </summary>
        /// <param name="pathToConfigurationMenu">
        /// The path to configuration menu.
        /// </param>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool OpenNe107Configuration(string pathToConfigurationMenu, int timeoutInMilliseconds)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The select simulation diagnostic event.
        /// </summary>
        /// <param name="value">
        /// Simulation event which will be selected
        /// </param>
        /// <returns>
        /// True: if call successful, false: if an error occurred
        /// </returns>
        public bool SetSimulationAreaDiagnosticEventSimulation(string value)
        {
            bool result;
            Element element = new NE107Elements().ArrayListSimulationDiagnosticEvents;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Combobox Simulation Diagnostic Event is null");
            }
            else
            {
                result = this.SetComboBoxValue(element, value);
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Selected simulation diagnostic event: " + value);
            }

            return result;
        }

        /// <summary>
        /// Selects the tab within the NE107 embedded control
        /// </summary>
        /// <param name="index">
        /// The tab index which will be selected.CodeWrights started index at 1, so 1 = Electronics, 2 = Process, 3 = Configuration, 4 = Simulation
        /// </param>
        /// <returns>
        /// true: if tab selected successfully; false: if an error occurred
        /// </returns>
        public bool SelectTab(int index)
        {
            bool result = true;
            Element tabControl = (new NE107Elements()).TabControlNE107;
            if ((index >= 1) && (tabControl != null))
            {
                tabControl.SetAttributeValue("selectedtabpageindex", index);
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Selected tab with index: " + index);
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Index out of bounds or tabcontrol == null");
                result = false;
            }

            return result;
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
                string itemText = item.Text;

                // Replacing every non ASCII character from a combo box entry with a space. This is currently needed for the Prowirl 200 HA Rev 3 
                itemText = Regex.Replace(itemText, @"[^\u0000-\u007F]", " ");
                if (itemText == value)
                {
                    isFound = true;
                    listItem = item;
                    break;
                }
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

            // Apply the changes
            Keyboard.Press(Keys.Enter);
            return true;
        }

        /// <summary>
        /// Sets a combo box control to a specified value
        /// </summary>
        /// <param name="element">
        /// combo box
        /// </param>
        /// <param name="value">
        /// value to set
        /// </param>
        /// <returns>
        /// <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        private bool SetComboBoxValue(Element element, string value)
        {
            if (element == null || element.Enabled == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ComboBox is not available.");
                return false;
            }

            Mouse.MoveTo(element, 500);
            Mouse.Click(element, DefaultValues.locDefaultLocation);
            IList<ListItem> listItems = (new NE107Elements()).ListItemsComboBox;
            if (listItems == null || listItems.Count <= 0)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ListItems are not available.");
                return false;
            }

            bool itemFound = this.FindAndSelectValueInComboBox(listItems, value);
            if (itemFound == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ListItem is not available.");
                return false;
            }

            return true;
        }

        #endregion

        /// <summary>
        /// The compare n e 107 simulation with namur status.
        /// </summary>
        /// <param name="tab">
        /// The tab.
        /// </param>
        /// <param name="diagnosticEvent">
        /// The diagnostic event.
        /// </param>
        /// <param name="expectedCategory">
        /// The expected category.
        /// </param>
        /// <param name="expectedSimulatedEvent">
        /// The expected simulated event.
        /// </param>
        /// <param name="expectedNamurState">
        /// The expected namur state.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CompareNE107SimulationWithNamurStatus(int tab, string diagnosticEvent, string expectedCategory, string expectedSimulatedEvent, string expectedNamurState)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The compare n e 107 simulation with tree parameter.
        /// </summary>
        /// <param name="tab">
        /// The tab.
        /// </param>
        /// <param name="diagnosticEvent">
        /// The diagnostic event.
        /// </param>
        /// <param name="expectedCategory">
        /// The expected category.
        /// </param>
        /// <param name="expectedSimulatedEvent">
        /// The expected simulated event.
        /// </param>
        /// <param name="pathToParameterInTree">
        /// The path to parameter in tree.
        /// </param>
        /// <param name="expectedParameterValue">
        /// The expected parameter value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CompareNE107SimulationWithTreeParameter(int tab, string diagnosticEvent, string expectedCategory, string expectedSimulatedEvent, string pathToParameterInTree, string expectedParameterValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get active diagnostic event category.
        /// </summary>
        /// <param name="diagnosticEvent">
        /// The diagnostic event.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string GetActiveDiagnosticEventCategory(string diagnosticEvent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get simulation area diagnostic event simulation.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string GetSimulationAreaDiagnosticEventSimulation()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The set active diagnostic event category.
        /// </summary>
        /// <param name="pathToDiagnosticEventRadioButton">
        /// The path to diagnostic event radio button.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool SetActiveDiagnosticEventCategory(string pathToDiagnosticEventRadioButton)
        {
            throw new NotImplementedException();
        }
    }
}