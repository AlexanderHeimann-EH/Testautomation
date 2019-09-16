// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NE107Functions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   NE107 Functions
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView;

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
        /// Opens the ne107 configuration.
        /// </summary>
        /// <param name="pathToConfigurationMenu">
        /// The path to Ne107 configuration menu. E.g. Prowirl 200//Expert//Communication//Diagnostic configuration
        /// </param>
        /// <param name="timeoutInMilliseconds">
        /// The timeout In Milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if menu is opened, <c>false</c> otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool OpenNe107Configuration(string pathToConfigurationMenu, int timeoutInMilliseconds)
        {
            bool result = true;

            if (new SelectParameter().Run(pathToConfigurationMenu) == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Navigating to Ne107 configuration menu failed.");
                result = false;
            }
            else
            {
                var watch = new Stopwatch();
                watch.Start();
                while (this.IsNE107ModuleAvailable() == false)
                {
                    if (watch.ElapsedMilliseconds > timeoutInMilliseconds)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Ne107 configuration menu did not open within " + timeoutInMilliseconds + " ms.");
                        break;
                    }
                }
            }

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Ne107 configuration menu opened and ready.");
            }

            return result;
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
            Element tabControl = new NE107Elements().TabControlNE107;
            if (tabControl == null)
            {
                result = false;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The Tab control is not found. NE107 Module is not available");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The Tab control is found. NE107 Module is available");
            }

            return result;
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
        /// The get simulation area diagnostic event simulation.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetSimulationAreaDiagnosticEventSimulation()
        {
            Text text = new NE107Elements().SimulationComboBox;
            if (text != null)
            {
                text.MoveTo(500);
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Active diagnostic event simulation is [{0}]", text.TextValue));
                return text.TextValue;
            }

            return null;
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
            if ((index >= 0) && (tabControl != null))
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

        /// <summary>
        /// The set diagnostic event category. Use this form diagnosticEvent//diagnosticCategory
        /// </summary>
        /// <param name="pathToDiagnosticEventRadioButton">
        /// The path to diagnostic event radio button.
        /// <para>diagnosticEvent: could be any of the events listed on selected tab; must be written as displayed</para>
        /// <para>diagnosticCategory: Failure or Function check or Out of specification or Maintenance required or No effect</para>
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetActiveDiagnosticEventCategory(string pathToDiagnosticEventRadioButton)
        {
            Ranorex.RadioButton radioButton = new NE107Elements().EventRadioButton(pathToDiagnosticEventRadioButton);
            if (radioButton != null)
            {
                radioButton.MoveTo(500);
                if (!radioButton.Checked)
                {
                    radioButton.Click();
                    this.ClickApplyButton();
                }

                return true;
            }

            return false;
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
        public string GetActiveDiagnosticEventCategory(string diagnosticEvent)
        {
            Element element = (new NE107Elements()).ActiveEventRadioButton(diagnosticEvent);
            if (element != null)
            {
                string controlName = element.GetAttributeValueText("ControlName");
                string[] seperator = { "." };
                string[] pathParts = controlName.Split(seperator, StringSplitOptions.None);
                string category = pathParts[pathParts.Length - 1];
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Active diagnostic event category is [{0}]", category));
                return category;
            }

            return null;
        }

        /// <summary>
        /// The compare ne 107 simulation with namur status.
        /// </summary>
        /// <param name="tab">
        /// The tab index which will be selected. CodeWrights started index at 1, so 1 = Electronics, 2 = Process, 3 = Configuration, 4 = Simulation
        /// </param>
        /// <param name="diagnosticEvent">
        /// The diagnostic event, must be written as shown on GUI
        /// </param>
        /// <param name="expectedCategory">
        /// The expected category: Failure, Function Check, Out Of Specification or Maintenance Required
        /// </param>
        /// <param name="expectedSimulatedEvent">
        /// The expected Simulated Event, must be written as shown on GUI
        /// </param>
        /// <param name="expectedNamurState">
        /// The expected namur state: : Failure, Function Check, Out Of Specification or Maintenance Required
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
// ReSharper disable InconsistentNaming
        public bool CompareNE107SimulationWithNamurStatus(int tab, string diagnosticEvent, string expectedCategory, string expectedSimulatedEvent, string expectedNamurState)
// ReSharper restore InconsistentNaming
        {
            if (this.SelectTab(tab))
            {
                string currentCategory = new NE107Functions().GetActiveDiagnosticEventCategory(diagnosticEvent);
                if (expectedCategory.Contains(currentCategory))
                {
                    string eventLabel = new NE107Elements().EventLabel(diagnosticEvent).GetAttributeValueText("Text");
                    if (this.SelectTab(4))
                    {
                        string currentSimulatedEvent = new NE107Functions().GetSimulationAreaDiagnosticEventSimulation();
                        if (this.RemoveWhiteSpaces(currentSimulatedEvent).ToLower().Contains(this.RemoveWhiteSpaces(expectedSimulatedEvent).ToLower()))
                        {
                            string[] currentEventParts = this.NormalizeWhiteSpaces(currentSimulatedEvent).Split(' ');
                            string[] expectedEventParts = this.NormalizeWhiteSpaces(eventLabel).Split(' ');
                            string currentEventNumber = currentEventParts[0];
                            string expectedEventNumber = expectedEventParts[expectedEventParts.Length - 1];

                            if (currentEventNumber.Equals(expectedEventNumber))
                            {
                                string currentNamurState = new GetNamurStatusFromHeader().Run();
                                if (this.RemoveWhiteSpaces(currentNamurState).ToLower().Contains(this.RemoveWhiteSpaces(expectedNamurState).ToLower()))
                                {
                                    Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Diagnostic Event [{0}] has expected category [{1}]. \nNamur status [{1}] is as expected [{2}].", diagnosticEvent, expectedCategory, currentNamurState));
                                    return true;
                                }

                                Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("NAMUR state [{0}] is not as expected [{1}]", currentNamurState, expectedNamurState));
                                return false;
                            }

                            Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Diagnostic event number [{0}] is not as expected [{1}]", currentEventNumber, expectedEventNumber));
                            return false;
                        }

                        Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Simulated diagnostic event [{0}] is not as expected [{1}]", currentSimulatedEvent, expectedSimulatedEvent));
                        return false;
                    }

                    Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Error while switching to expceted tab [{0}]", tab));
                    return false;
                }

                Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Diagnostic event category [{0}] is not as expected [{1}]", currentCategory, expectedCategory));
                return false;
            }

            Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Error while switching to expceted tab [{0}]", tab));
            return false;
        }

        /// <summary>
        /// The compare ne 107 simulation with tree parameter.
        /// </summary>
        /// <param name="tab">
        /// The tab index which will be selected. CodeWrights started index at 1, so 1 = Electronics, 2 = Process, 3 = Configuration, 4 = Simulation
        /// </param>
        /// <param name="diagnosticEvent">
        /// The diagnostic event, must be written as shown on GUI
        /// </param>
        /// <param name="expectedCategory">
        /// The expected category: Failure, Function Check, Out Of Specification or Maintenance Required
        /// </param>
        /// <param name="expectedSimulatedEvent">
        /// The expected simulated event, must be written as shown on GUI
        /// </param>
        /// <param name="pathToParameterInTree">
        /// The path to parameter in tree, must be written as shown on GUI
        /// </param>
        /// <param name="expectedParameterValue">
        /// The expected parameter value, must be written as shown on GUI. Leading letter F, C, S, M could be ignored
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
// ReSharper disable InconsistentNaming
        public bool CompareNE107SimulationWithTreeParameter(int tab, string diagnosticEvent, string expectedCategory, string expectedSimulatedEvent, string pathToParameterInTree, string expectedParameterValue)
// ReSharper restore InconsistentNaming
        {
            if (this.SelectTab(tab))
            {
                string currentCategory = new NE107Functions().GetActiveDiagnosticEventCategory(diagnosticEvent);
                if (this.RemoveWhiteSpaces(currentCategory).ToLower().Contains(this.RemoveWhiteSpaces(expectedCategory).ToLower()))
                {
                    string eventLabel = new NE107Elements().EventLabel(diagnosticEvent).GetAttributeValueText("Text");
                    if (this.SelectTab(4))
                    {
                        string currentSimulatedEvent = new NE107Functions().GetSimulationAreaDiagnosticEventSimulation();
                        if (this.RemoveWhiteSpaces(currentSimulatedEvent).ToLower().Contains(this.RemoveWhiteSpaces(expectedSimulatedEvent).ToLower()))
                        {
                            string[] currentEventParts = this.NormalizeWhiteSpaces(currentSimulatedEvent).Split(' ');
                            string[] expectedEventParts = this.NormalizeWhiteSpaces(eventLabel).Split(' ');
                            string currentEventNumber = currentEventParts[0];
                            string expectedEventNumber = expectedEventParts[expectedEventParts.Length - 1];

                            if (currentEventNumber.Equals(expectedEventNumber))
                            {
                                string parameterValue = new GetParameterValue().Run(pathToParameterInTree);
                                if (this.RemoveWhiteSpaces(parameterValue.ToLower()).Contains(this.RemoveWhiteSpaces(expectedParameterValue.ToLower())))
                                {
                                    Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Diagnostic Event with [{0}] has expected category [{1}]. \nParameter value of parameter [{2}] is as expected [{3}]", diagnosticEvent, expectedCategory, pathToParameterInTree, expectedParameterValue));
                                    return true;
                                }

                                Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Parameter value of parameter [{0}] is not as expected [{1}].", pathToParameterInTree, parameterValue));
                                return false;
                            }

                            Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Diagnostic event number [{0}] is not as expected [{1}]", currentEventNumber, expectedEventNumber));
                            return false;
                        }

                        Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Simulated diagnostic event [{0}] is not as expected [{1}]", currentSimulatedEvent, expectedSimulatedEvent));
                        return false;
                    }

                    Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Error while switching to expceted tab [{0}]", tab));
                    return false;
                }

                Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Diagnostic event category [{0}] is not as expected [{1}]", currentCategory, expectedCategory));
                return false;
            }

            Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Error while switching to expceted tab [{0}]", tab));
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

        /// <summary>
        /// The remove white spaces.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string RemoveWhiteSpaces(string value)
        {
            if (value != null)
            {
                string modifiedPath = value.Replace(((char)32).ToString(CultureInfo.InvariantCulture), string.Empty).Replace(((char)160).ToString(CultureInfo.InvariantCulture), string.Empty);
                return modifiedPath;
            }

            return null;
        }

        /// <summary>
        /// The normalize white spaces.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string NormalizeWhiteSpaces(string value)
        {
            if (value != null)
            {
                string modifiedPath = value.Replace(((char)160).ToString(CultureInfo.InvariantCulture), ((char)32).ToString(CultureInfo.InvariantCulture));
                return modifiedPath;
            }

            return null;
        }

        #endregion
    }
}