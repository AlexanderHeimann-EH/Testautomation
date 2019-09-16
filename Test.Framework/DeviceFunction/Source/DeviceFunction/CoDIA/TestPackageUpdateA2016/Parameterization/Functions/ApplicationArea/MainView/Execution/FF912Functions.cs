// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FF912Functions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Windows.Forms;

    using Common;
    using Common.Enumerations;
    using Common.Tools;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// FF912 Functionality
    /// </summary>
 // ReSharper disable InconsistentNaming
    public class FF912Functions : IFF912Functions
 // ReSharper restore InconsistentNaming
    {
        #region general

        /// <summary>
        /// The open f f 912 configuration.
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
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1627:DocumentationTextMustNotBeEmpty", Justification = "Reviewed. Suppression is OK here.")]
        public bool OpenFF912Configuration(string pathToConfigurationMenu, int timeoutInMilliseconds)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Selects the tab within the FF912 embedded control
        /// </summary>
        /// <param name="index">
        /// The tab index which will be selected. 0 = Standard Area, 1 = Configurable Area, 2 = Status 1, 3 = Status 2, 4 = Simulation
        /// </param>
        /// <returns>
        /// true: if tab selected successfully; false: if an error occurred
        /// </returns>
        public bool SelectTab(int index)
        {
            bool result = true;
            Element tabControl = (new FF912Elements()).TabControl;
            if ((index >= 0) && (tabControl != null))
            {
                tabControl.SetAttributeValue("selectedtabpageindex", index);
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Selected tab with index " + index);
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Index out of bounds or tabcontrol == null");
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SetSimulationAreaDiagnosticEventCheckBoxStatusOfEventName(string pathToDiagnosticEventComboBox, bool toCheck)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SetSimulationAreaDiagnosticEventCheckBoxStatusOfBitNumber(string pathToDiagnosticEventCheckBox, bool toCheck)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool GetSimulationAreaStandardDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool GetSimulationAreaConfigurableDiagnosticEventCheckBoxStatus(string pathToEventCheckBox)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CompareFF912ConfiguredValueWithTreeParameter(string pathToConfigurableAreaCheckBox, string pathToSimulationAreaCheckBox, string expectedDiagnosticEvent, bool expectedCheckBoxStatusOnStandardArea, string pathToParameterInTree, string expectedParameterValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CompareFF912StandardValueWithNamurStatus(string pathToStandardAreaCheckBox, string pathToSimulationAreaCheckBox, bool expectedCheckBoxStatusOnStandardArea, string expectedNamurStatusOnHeader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CompareFF912ConfiguredValueWithNamurStatus(string pathToConfigurableAreaCheckBox, string pathToSimulationAreaCheckBox, bool expectedCheckBoxStatusOnConfigurationArea, string expectedNamurStatusOnHeader)
        {
            throw new NotImplementedException();
        }

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
            Element button = new FF912Elements().ApplyButton;
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
            Element button = new FF912Elements().CancelButton;
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
        /// The set simulation value.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetSimulationState(string state)
        {
            Element simulationCombobox = new FF912Elements().ComboboxSimulate;
            bool result = this.SetComboBoxValue(simulationCombobox, state);
            return result;
        }

        /// <summary>
        /// The get simulation state.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetSimulationState()
        {
            Element simulationCombobox = new FF912Elements().ComboboxSimulate;
            string value = this.GetComboBoxValue(simulationCombobox);

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SetStandardAreaPriority(int columnNumber, string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetStandardAreaPriority(FF912DiagnosticCategories diagnosticCategory)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SetConfigurableAreaPriority(int columnNumber, string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetConfigurableAreaPriority(int columnNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SetStandardAreaDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox, bool toCheck)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SetConfigurableAreaDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox, bool toCheck)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool GetStatus1AreaDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool GetStatus2AreaDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SetConfigurableAreaDiagnosticEventComboBoxValue(string pathToDiagnosticEventComboBox, string diagnosticEvent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetConfigurableAreaDiagnosticEventComboBoxValue(string bitNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool GetStandardAreaDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool GetConfigurableAreaDiagnosticEventCheckBoxStatus(string pathToEventCheckBox)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks whether the FF912 Module is available or not using the tab control element
        /// </summary>
        /// <returns>
        /// true: if the module is available
        /// false: if module is not available
        /// </returns>
        public bool IsFF912ModuleAvailable()
        {
            bool result = true;
            Element tabcontrol = new FF912Elements().TabControl;
            if (tabcontrol == null)
            {
                result = false;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The Tabcontrol is not found. FF912 Module is not available");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Found Tabcontrol. FF912 Module is available");
            }

            return result;
        }

        ///// <summary>
        ///// Sets a category priority, for example Function Check
        ///// </summary>
        ///// <param name="element">
        ///// The Category for which the priority should be changed. The Element is found in the Repository
        ///// </param>
        ///// <param name="value">
        ///// The value to which the Priority should be changed. Valid range is between 1-15. Other values will be ignored by the DTM.
        ///// </param>
        ///// <returns>
        ///// True: if the priority was changed.
        ///// False: if an error occurred.
        ///// </returns>
        //public bool SetCategoryPriority(Element element, string value)
        //{
        //    bool result = true;
        //    if (element == null || element.Enabled == false)
        //    {
        //        result = false;
        //        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Edit field is null or not enabled");
        //    }
        //    else
        //    {
        //        element.SetAttributeValue("Text", value);
        //        Keyboard.Press(Keys.Enter);
        //    }

        //    return result;
        //}

        /// <summary>
        /// Enables simulation. You have to be in the tab Simulation to execute this.
        /// </summary>
        /// <returns>
        /// true: if simulation is enabled
        /// false: if an error occurred
        /// </returns>
        public bool EnableSimulation()
        {
            Element simulationCombobox = new FF912Elements().ComboboxSimulate;
            bool result = this.SetComboBoxValue(simulationCombobox, "Enabled");
            return result;
        }

        /// <summary>
        /// Disables simulation. You have to be in the tab Simulation to execute this.
        /// </summary>
        /// <returns>
        /// true: if simulation is enabled
        /// false: if an error occurred
        /// </returns>
        public bool DisableSimulation()
        {
            Element simulationCombobox = new FF912Elements().ComboboxSimulate;
            bool result = this.SetComboBoxValue(simulationCombobox, "Disabled");
            return result;
        }

        /// <summary>
        ///     Sets a combo box control to a specified value
        /// </summary>
        /// <param name="element">combo box control found in the repository</param>
        /// <param name="value">value to set</param>
        /// <returns>
        ///     <br>True: if parameter was set</br>
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
            IList<ListItem> listItems = (new FF912Elements()).ListItemsComboBox;
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
                string itemText = item.Text;
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
        /// The get combo box value.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetComboBoxValue(Element element)
        {
            if (element == null || element.Enabled == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ComboBox is not available.");
                return null;
            }

            string comboboxValue = element.GetAttributeValue("text").ToString();
            return comboboxValue;
        }

        #endregion
    }
}
