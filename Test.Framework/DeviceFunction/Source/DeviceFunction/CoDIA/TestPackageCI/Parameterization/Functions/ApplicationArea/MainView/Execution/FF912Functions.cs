// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FF912Functions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   FF912 Functionality
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
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// FF912 Functionality
    /// </summary>
// ReSharper disable InconsistentNaming
    public class FF912Functions : IFF912Functions
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
            Ranorex.Button button = new FF912Elements().ApplyButton;
            if (button == null || button.Enabled == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The Apply button is null or not enabled");
            }
            else
            {
                button.MoveTo(500);
                button.Click();
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
            Ranorex.Button button = new FF912Elements().CancelButton;
            if (button == null || button.Enabled == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The cancel button is null or not enabled");
            }
            else
            {
                button.MoveTo(500);
                button.Click();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicked on Cancel");
            }

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
        /// Enables simulation. You have to be in the tab Simulation to execute this.
        /// </summary>
        /// <returns>
        /// true: if simulation is enabled
        /// false: if an error occurred
        /// </returns>
        public bool EnableSimulation()
        {
            Element simulationCombobox = new FF912Elements().ComboboxSimulate;
            bool result = this.SetComboBoxValue(simulationCombobox, "Active");
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
            if (value != null)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Simulation status is " + value);
                return value;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not get Simulation status: simulation status is null.");
            return null;
        }

        /// <summary>
        /// The set standard area priority.
        /// </summary>
        /// <param name="columnNumber">
        /// The column number.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetStandardAreaPriority(int columnNumber, string value)
        {
            bool result;
            switch (columnNumber)
            {
                case 1:
                    {
                        result = this.SetStandardAreaPriorityTextFieldValue((new FF912Elements()).StandardAreaFailurePriority, value);
                        break;
                    }

                case 2:
                    {
                        result = this.SetStandardAreaPriorityTextFieldValue((new FF912Elements()).StandardAreaFunctionCheckPriority, value);
                        break;
                    }
                    
                case 3:
                    {
                        result = this.SetStandardAreaPriorityTextFieldValue((new FF912Elements()).StandardAreaOutOfSpecPriority, value);
                        break;
                    }

                case 4:
                    {
                        result = this.SetStandardAreaPriorityTextFieldValue((new FF912Elements()).StandardAreaMaintenanceRequiredPriority, value);
                        break;
                    }

                default:
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Column " + columnNumber + " in FF912 Standard Area could not be found.");
                        result = false;
                        break;
                    }
            }

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Priority of column " + columnNumber + " is set to " + value);
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Priority of column " + columnNumber + " could not be set to " + value);
            return false;
        }

        /// <summary>
        /// The get standard area priority.
        /// </summary>
        /// <param name="diagnosticCategory">
        /// The diagnostic Categories.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetStandardAreaPriority(FF912DiagnosticCategories diagnosticCategory)
        {
            string result;

            switch (diagnosticCategory)
            {
                case FF912DiagnosticCategories.Failure:
                    {
                        result = this.GetStandardAreaPriorityTextFieldValue((new FF912Elements()).StandardAreaFailurePriority);
                        break;
                    }

                case FF912DiagnosticCategories.FunctionCheck:
                    {
                        result = this.GetStandardAreaPriorityTextFieldValue((new FF912Elements()).StandardAreaFunctionCheckPriority);
                        break;
                    }

                case FF912DiagnosticCategories.OutOfSpecification:
                    {
                        result = this.GetStandardAreaPriorityTextFieldValue((new FF912Elements()).StandardAreaOutOfSpecPriority);
                        break;
                    }

                case FF912DiagnosticCategories.MaintenanceRequired:
                    {
                        result = this.GetStandardAreaPriorityTextFieldValue((new FF912Elements()).StandardAreaMaintenanceRequiredPriority);
                        break;
                    }

                default:
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Column " + diagnosticCategory + " in FF912 Standard Area could not be found.");
                        result = null;
                        break;
                    }
            }

            return result;
        }

        /// <summary>
        /// The set configurable area priority.
        /// </summary>
        /// <param name="columnNumber">
        /// The column number.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetConfigurableAreaPriority(int columnNumber, string value)
        {
            bool result;
            switch (columnNumber)
            {
                case 1:
                    {
                        result = this.SetConfigurableAreaPriorityTextFieldValue((new FF912Elements()).ConfigurableAreaFailurePriority, value);
                        break;
                    }

                case 2:
                    {
                        result = this.SetStandardAreaPriorityTextFieldValue((new FF912Elements()).ConfigurableAreaFunctionCheckPriority, value);
                        break;
                    }

                case 3:
                    {
                        result = this.SetStandardAreaPriorityTextFieldValue((new FF912Elements()).ConfigurableAreaOutOfSpecPriority, value);
                        break;
                    }

                case 4:
                    {
                        result = this.SetStandardAreaPriorityTextFieldValue((new FF912Elements()).ConfigurableAreaMaintenanceRequiredPriority, value);
                        break;
                    }

                default:
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Column " + columnNumber + " in FF912 Standard Area could not be found.");
                        result = false;
                        break;
                    }
            }

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Priority of column " + columnNumber + " is set to " + value);
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Priority of column " + columnNumber + " could not be set to " + value);
            return false;
        }

        /// <summary>
        /// The get configurable area priority.
        /// </summary>
        /// <param name="columnNumber">
        /// The column number.
        /// <para>- columnNumber: 0-4</para>
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetConfigurableAreaPriority(int columnNumber)
        {
            string result;

            switch (columnNumber)
            {
                case 1:
                    {
                        result = this.GetConfigurableAreaPriorityTextFieldValue((new FF912Elements()).ConfigurableAreaFailurePriority);
                        break;
                    }

                case 2:
                    {
                        result = this.GetConfigurableAreaPriorityTextFieldValue((new FF912Elements()).ConfigurableAreaFunctionCheckPriority);
                        break;
                    }

                case 3:
                    {
                        result = this.GetConfigurableAreaPriorityTextFieldValue((new FF912Elements()).ConfigurableAreaOutOfSpecPriority);
                        break;
                    }

                case 4:
                    {
                        result = this.GetConfigurableAreaPriorityTextFieldValue((new FF912Elements()).ConfigurableAreaMaintenanceRequiredPriority);
                        break;
                    }

                default:
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Column " + columnNumber + " in FF912 Confiburable Area could not be found.");
                        result = null;
                        break;
                    }
            }

            return result;
        }

        /// <summary>
        /// The set standard area event.
        /// </summary>
        /// <param name="pathToDiagnosticEventCheckBox">
        /// The path To Diagnostic Event Check Box. Use this form diagnosticEvent//diagnosticCategory//diagnostic
        /// <para>- diagnosticEvent: Highest or High or Low or Lowest Severity Sensor or Electronic or Configuration or Process (example:  Highest Severity Sensor)</para>
        /// <para>- diagnosticCategory: Failure, Function Check, Out Of Specification, Maintenance Required</para>
        /// <para>- diagnostic: Enable or Mask</para>
        /// </param>
        /// <param name="toCheck">
        /// Target status: true = checked; false = unchecked
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetStandardAreaDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox, bool toCheck)
        {
            Ranorex.CheckBox checkBox = (new FF912Elements()).StandardAreaCheckBox(this.RemoveWhiteSpaces(pathToDiagnosticEventCheckBox));
            return this.SetCheckBoxStatus(checkBox, pathToDiagnosticEventCheckBox, toCheck);
        }

        /// <summary>
        /// The set configurable area event.
        /// </summary>
        /// <param name="pathToDiagnosticEventCheckBox">
        /// The path To Diagnostic Event Check Box. Use this form bitNumber//diagnosticCategory//diagnostic
        /// <para>- bitNumber: 1-15</para>
        /// <para>- diagnosticCategory: Failure, Function Check, Out Of Specification, Maintenance Required</para>
        /// <para>- diagnostic: Enable or Mask</para>
        /// </param>
        /// <param name="toCheck">
        /// Target status: true = checked; false = unchecked
        /// </param>
        /// <returns>
        /// The<see cref="bool"/>.
        /// </returns>
        public bool SetConfigurableAreaDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox, bool toCheck)
        {
            Ranorex.CheckBox checkBox = (new FF912Elements()).ConfigurableAreaCheckBox(this.RemoveWhiteSpaces(pathToDiagnosticEventCheckBox));
            return this.SetCheckBoxStatus(checkBox, pathToDiagnosticEventCheckBox, toCheck);
        }

        /// <summary>
        /// The get status 1 area diagnostic event check box status.
        /// </summary>
        /// <param name="pathToDiagnosticEventCheckBox">
        /// The path To Diagnostic Event Check Box. Use this form diagnosticEvent//diagnosticCategory
        /// <para>- diagnosticEvent: Highest or High or Low or Lowest Severity Sensor or Electronic or Configuration or Process (example:  Highest Severity Sensor)</para>
        /// <para>- diagnosticCategory: Failure, Function Check, Out Of Specification, Maintenance Required</para>
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GetStatus1AreaDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox)
        {
            Ranorex.CheckBox checkBox = (new FF912Elements()).Status1AreaCheckBox(this.RemoveWhiteSpaces(pathToDiagnosticEventCheckBox));
            return checkBox.Checked;
        }

        /// <summary>
        /// The get status 2 area diagnostic event check box status.
        /// </summary>
        /// <param name="pathToDiagnosticEventCheckBox">
        /// The path to event check box. Use this form bitNumber//diagnosticCategory
        /// <para>- bitNumber: 1-15</para>
        /// <para>- diagnosticCategory: Failure, Function Check, Out Of Specification, Maintenance Required</para>
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GetStatus2AreaDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox)
        {
            Ranorex.CheckBox checkBox = (new FF912Elements()).Status2AreaCheckBox(this.RemoveWhiteSpaces(pathToDiagnosticEventCheckBox));
            return checkBox.Checked;
        }

        /// <summary>
        /// The set configurable area diagnostic event combo box.
        /// </summary>
        /// <param name="pathToDiagnosticEventComboBox">
        /// The path To Diagnostic Event Combo Box consists of bitNumber event. Use this form bitNumber
        /// </param>
        /// <param name="diagnosticEvent">
        /// The diagnostic Event.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetConfigurableAreaDiagnosticEventComboBoxValue(string pathToDiagnosticEventComboBox, string diagnosticEvent)
        {
            Text text = new FF912Elements().ConfigurableAreaComboBox(this.RemoveWhiteSpaces(pathToDiagnosticEventComboBox));
            if (this.SetComboBoxValue(text, diagnosticEvent))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Diagnostic Event # " + pathToDiagnosticEventComboBox + "  is set to " + diagnosticEvent);
                
                // Apply the changes
                this.ClickApplyButton();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Diagnostic Event # " + pathToDiagnosticEventComboBox + "  is not set to " + diagnosticEvent);
            return false;
        }

        /// <summary>
        /// The get configurable area diagnostic event combo box value.
        /// </summary>
        /// <param name="bitNumber">
        /// The bit number.
        /// <para>- bitNumber: 1-15</para>
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetConfigurableAreaDiagnosticEventComboBoxValue(string bitNumber)
        {
            Text text = new FF912Elements().ConfigurableAreaComboBox(this.RemoveWhiteSpaces(bitNumber));
            return text.TextValue;
        }

        /// <summary>
        /// The get standard area diagnostic event check box status.
        /// </summary>
        /// <param name="pathToDiagnosticEventCheckBox">
        /// The path to diagnostic event Check Box. Use this form diagnosticEvent//diagnosticCategory//diagnostic.
        /// <para>- diagnosticEvent: Highest or High or Low or Lowest Severity Sensor or Electronic or Configuration or Process (example:  Highest Severity Sensor)</para>
        /// <para>- diagnosticCategory: Failure, Function Check, Out Of Specification, Maintenance Required</para>
        /// <para>- diagnostic: Enable or Mask</para>
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GetStandardAreaDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox)
        {
            Ranorex.CheckBox checkBox = (new FF912Elements()).StandardAreaCheckBox(this.RemoveWhiteSpaces(pathToDiagnosticEventCheckBox));
            checkBox.MoveTo(500);
            return checkBox.Checked;
        }

        /// <summary>
        /// The get configurable area event.
        /// </summary>
        /// <param name="pathToEventCheckBox">
        /// The path To Event Check Box. Use this form: bitNumber//diagnosticCategory//diagnostic.
        /// <para>- bitNumber: 1-15</para>
        /// <para>- diagnosticCategory: Failure, Function Check, Out Of Specification, Maintenance Required</para>
        /// <para>- diagnostic: Enable or Mask</para>
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GetConfigurableAreaDiagnosticEventCheckBoxStatus(string pathToEventCheckBox)
        {
            Ranorex.CheckBox checkBox = (new FF912Elements()).ConfigurableAreaCheckBox(this.RemoveWhiteSpaces(pathToEventCheckBox));
            checkBox.MoveTo(500);
            return checkBox.Checked;
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

        /// <summary>
        /// Opens the ff912 configuration.
        /// </summary>
        /// <param name="pathToConfigurationMenu">
        /// The path to ff912 configuration menu. E.g. Levelflex//Expert//Communication//Field device diagnostic//Configuration
        /// </param>
        /// <param name="timeoutInMilliseconds">
        /// The timeout In Milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if menu is opened, <c>false</c> otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
// ReSharper disable InconsistentNaming
        public bool OpenFF912Configuration(string pathToConfigurationMenu, int timeoutInMilliseconds)
// ReSharper restore InconsistentNaming
        {
            bool result = true;

            if (new SelectParameter().Run(pathToConfigurationMenu) == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Navigating to FF912 configuration menu failed.");
                result = false;
            }
            else
            {
                var watch = new Stopwatch();
                watch.Start();
                while (this.IsFF912ModuleAvailable() == false)
                {
                    if (watch.ElapsedMilliseconds > timeoutInMilliseconds)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FF912 configuration menu did not open within " + timeoutInMilliseconds + " ms.");
                        break;
                    }
                }
            }

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FF912 configuration menu opened and ready.");
            }

            return result;
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
        /// The set simulation area diagnostic event check box status of event name.
        /// </summary>
        /// <param name="pathToDiagnosticEventComboBox">
        /// The path to event check box. Use this form diagnosticEvent//diagnostic
        /// <para>- diagnosticEvent: Highest or High or Low or Lowest Severity Sensor or Electronic or Configuration or Process (example:  Highest Severity Sensor)</para>
        /// <para>- diagnostic: Simulation</para>
        /// </param>
        /// <param name="toCheck">
        /// The to check.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetSimulationAreaDiagnosticEventCheckBoxStatusOfEventName(string pathToDiagnosticEventComboBox, bool toCheck)
        {
            Ranorex.CheckBox checkBox = (new FF912Elements()).SimulationAreaCheckBoxEventName(this.RemoveWhiteSpaces(pathToDiagnosticEventComboBox));
            return this.SetCheckBoxStatus(checkBox, pathToDiagnosticEventComboBox, toCheck);
        }

        /// <summary>
        /// The set simulation area diagnostic event check box status of bit number.
        /// </summary>
        /// <param name="pathToDiagnosticEventCheckBox">
        /// The path to diagnostic event check box. Use this form bitNumber//diagnostic
        /// <para>- bitNumber: 1-15</para>
        /// <para>- diagnostic: Simulation</para>
        /// </param>
        /// <param name="toCheck">
        /// The to check.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetSimulationAreaDiagnosticEventCheckBoxStatusOfBitNumber(string pathToDiagnosticEventCheckBox, bool toCheck)
        {
            Ranorex.CheckBox checkBox = (new FF912Elements()).SimulationAreaCheckBoxBitNumber(this.RemoveWhiteSpaces(pathToDiagnosticEventCheckBox));
            return this.SetCheckBoxStatus(checkBox, pathToDiagnosticEventCheckBox, toCheck);
        }

        /// <summary>
        /// The get simulation area standard diagnostic event check box status.
        /// </summary>
        /// <param name="pathToDiagnosticEventCheckBox">
        /// The path To Diagnostic Event Check Box consists of diagnosticEvent and diagnostic. Use this form: diagnosticEvent//diagnostic.
        /// <para>- diagnosticEvent: Highest or High or Low or Lowest Severity Sensor or Electronic or Configuration or Process (example:  Highest Severity Sensor)</para>
        /// <para>- diagnostic: Simulation or Active</para>
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GetSimulationAreaStandardDiagnosticEventCheckBoxStatus(string pathToDiagnosticEventCheckBox)
        {
            Ranorex.CheckBox checkBox = (new FF912Elements()).SimulationAreaCheckBoxEventName(this.RemoveWhiteSpaces(pathToDiagnosticEventCheckBox));
            checkBox.MoveTo(500);
            return checkBox.Checked;
        }

        /// <summary>
        /// The get simulation area configurable diagnostic event check box status.
        /// </summary>
        /// <param name="pathToEventCheckBox">
        /// The path To Event Check Box. Use this form: bitNumber//diagnostic.
        /// <para>- bitNumber: 1-15</para>
        /// <para>- diagnostic: Simulation or Active</para>
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GetSimulationAreaConfigurableDiagnosticEventCheckBoxStatus(string pathToEventCheckBox)
        {
            Ranorex.CheckBox checkBox = (new FF912Elements()).SimulationAreaCheckBoxBitNumber(this.RemoveWhiteSpaces(pathToEventCheckBox));
            checkBox.MoveTo(500);
            return checkBox.Checked;
        }

        /// <summary>
        /// The compare ff 912 configured value with tree parameter.
        /// </summary>
        /// <param name="pathToConfigurableAreaCheckBox">
        /// The path to configurable area check box. Use this form bitNumber//diagnosticCategory//diagnostic
        /// <para>- bitNumber: 1-15</para>
        /// <para>- diagnosticCategory: Failure, Function Check, Out Of Specification or Maintenance Required</para>
        /// <para>- diagnostic: Enable or Mask</para>
        /// </param>
        /// <param name="pathToSimulationAreaCheckBox">
        /// The path to simulation area check box. Use this form bitNumber//diagnostic
        /// <para>- bitNumber: 1-15</para>
        /// <para>- diagnostic: Active</para>
        /// </param>
        /// <param name="expectedDiagnosticEvent">
        /// The expected diagnostic event.
        /// </param>
        /// <param name="expectedCheckBoxStatusOnStandardArea">
        /// The expected check box status on standard area.
        /// <para>- checked: true</para>
        /// <para>- unchecked: false</para>
        /// </param>
        /// <param name="pathToParameterInTree">
        /// The path to parameter in tree. Use this form, a.e. Micropilot//Diagnostics 1:
        /// </param>
        /// <param name="expectedParameterValue">
        /// The expected parameter value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
// ReSharper disable InconsistentNaming
        public bool CompareFF912ConfiguredValueWithTreeParameter(string pathToConfigurableAreaCheckBox, string pathToSimulationAreaCheckBox, string expectedDiagnosticEvent, bool expectedCheckBoxStatusOnStandardArea, string pathToParameterInTree, string expectedParameterValue)
// ReSharper restore InconsistentNaming
        {
            // check configuration on configuration area
            // check activeness on status 2 area
            // check activeness on simulation area
            // check diagnostic at parameterization
            string[] seperator = { "//" };
            string[] pathParts = pathToConfigurableAreaCheckBox.Split(seperator, StringSplitOptions.None);
            
            this.SelectTab(1);
            bool currentStatusConfigurationArea = this.GetConfigurableAreaDiagnosticEventCheckBoxStatus(pathToConfigurableAreaCheckBox);
            string currentDefinedDiagnosticEvent = this.GetConfigurableAreaDiagnosticEventComboBoxValue(pathParts[0]);
            if (this.RemoveWhiteSpaces(currentDefinedDiagnosticEvent).Equals(this.RemoveWhiteSpaces(expectedDiagnosticEvent)))
            {
                if (currentStatusConfigurationArea.Equals(expectedCheckBoxStatusOnStandardArea))
                {
                    this.SelectTab(4);
                    bool currentStatusSimulationArea = this.GetSimulationAreaConfigurableDiagnosticEventCheckBoxStatus(pathToSimulationAreaCheckBox);
                    if (currentStatusSimulationArea.Equals(expectedCheckBoxStatusOnStandardArea))
                    {
                        string parameterValue = new GetParameterValue().Run(pathToParameterInTree);
                        if (this.RemoveWhiteSpaces(parameterValue.ToLower()).Contains(this.RemoveWhiteSpaces(expectedParameterValue.ToLower())))
                        {
                            Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Diagnostic Event with [{0}] has expected status [{1}]. \nParameter value of parameter [{2}] is as expected [{3}]", pathToConfigurableAreaCheckBox, expectedCheckBoxStatusOnStandardArea, pathToParameterInTree, expectedParameterValue));
                            return true;
                        }

                        Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Parameter value of parameter [{0}] is not as expected [{1}].", pathToParameterInTree, parameterValue));
                        return false;
                    }

                    Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Check box status [{0}] in simulation area is not as expected [{1}].", currentStatusSimulationArea, expectedCheckBoxStatusOnStandardArea));
                    return false;
                }

                Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Check box status [{0}] in configuration area is not as expected [{1}].", currentStatusConfigurationArea, expectedCheckBoxStatusOnStandardArea));
                return false;
            }

            Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Event [{0}] in configuration area is not configured as expected [{1}].", currentDefinedDiagnosticEvent, expectedDiagnosticEvent));
            return false;
        }

        /// <summary>
        /// The compare ff912 standard value with header.
        /// </summary>
        /// <param name="pathToStandardAreaCheckBox">
        /// The path to Standard Area check box. Use this form diagnosticEvent//diagnosticCategory//diagnostic.
        /// <para>- diagnosticEvent: Highest or High or Low or Lowest Severity Sensor or Electronic or Configuration or Process (example:  Highest Severity Sensor)</para>
        /// <para>- diagnosticCategory: Failure, Function Check, Out Of Specification or Maintenance Required</para>
        /// <para>- diagnostic: Enable or Mask</para>
        /// </param>
        /// <param name="pathToSimulationAreaCheckBox">
        /// The path To Simulation Area Check Box. Use this form diagnosticEvent//diagnostic.
        /// <para>- diagnosticEvent: Highest or High or Low or Lowest Severity Sensor or Electronic or Configuration or Process (example:  Highest Severity Sensor)</para>
        /// <para>- diagnostic: Enable or Mask</para>
        /// </param>
        /// <param name="expectedCheckBoxStatusOnStandardArea">
        /// The expected status of checkboxes on standard area. 
        /// <para>- checked: true</para>
        /// <para>- unchecked: false</para>
        /// </param>
        /// <param name="expectedNamurStatusOnHeader">
        /// The expected namur status on header. Use this form diagnosticCategory
        /// <para>- diagnosticCategory: Failure, Function Check, Out Of Specification, Maintenance Required</para>
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
// ReSharper disable InconsistentNaming
        public bool CompareFF912StandardValueWithNamurStatus(string pathToStandardAreaCheckBox, string pathToSimulationAreaCheckBox, bool expectedCheckBoxStatusOnStandardArea, string expectedNamurStatusOnHeader)
// ReSharper restore InconsistentNaming
        {
            // check configuration on standard area
            // check activeness on status 1 area
            // check activeness on simulation area
            // check namur status at header
            this.SelectTab(0);
            bool currentStatusStandardArea = this.GetStandardAreaDiagnosticEventCheckBoxStatus(pathToStandardAreaCheckBox);
            if (currentStatusStandardArea.Equals(expectedCheckBoxStatusOnStandardArea))
            {
                this.SelectTab(4);
                bool currentStatusSimulationArea = this.GetSimulationAreaStandardDiagnosticEventCheckBoxStatus(pathToSimulationAreaCheckBox);
                if (currentStatusSimulationArea.Equals(expectedCheckBoxStatusOnStandardArea))
                {
                    string namurStatus = new GetNamurStatusFromHeader().Run();
                    if (namurStatus.ToLower().Contains(expectedNamurStatusOnHeader.ToLower()))
                    {
                        Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Diagnostic Event [{0}] has expected status [{1}]. \nDiagnostic Event [{0}] on Simulation Area is active. \nNamur status [{1}] is as expected [{2}]", pathToStandardAreaCheckBox, expectedCheckBoxStatusOnStandardArea, expectedNamurStatusOnHeader));
                        return true;
                    }

                    Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Namur status [{0}] is not as expected [{1}].", namurStatus, expectedNamurStatusOnHeader));
                    return false;
                }

                Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Check box status [{0}] in simulation area is not as expected [{1}].", currentStatusSimulationArea, expectedCheckBoxStatusOnStandardArea));
                return false;
            }

            Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Check box status [{0}] in standard area is not as expected [{1}].", currentStatusStandardArea, expectedCheckBoxStatusOnStandardArea));
            return false;
        }

        /// <summary>
        /// The compare ff 912 configured value with header.
        /// </summary>
        /// <param name="pathToConfigurableAreaCheckBox">
        /// The path to Standard Area check box. Use this form bitNumber//diagnosticCategory//diagnostic.
        /// <para>- bitNumber: 1-15</para>
        /// <para>- diagnosticCategory: Failure, Function Check, Out Of Specification or Maintenance Required</para>
        /// <para>- diagnostic: Enable or Mask</para>
        /// </param>
        /// <param name="pathToSimulationAreaCheckBox">
        /// The path To Simulation Area Check Box. Use this form bitNumber//diagnostic.
        /// <para>- bitNumber: 1-15</para>
        /// <para>- diagnostic: Enable or Mask</para>
        /// </param>
        /// <param name="expectedCheckBoxStatusOnConfigurationArea">
        /// The expected status of checkboxes on standard area. 
        /// <para>- checked: true</para>
        /// <para>- unchecked: false</para>
        /// </param>
        /// <param name="expectedNamurStatusOnHeader">
        /// The expected namur status on header. Use this form diagnosticCategory
        /// <para>- diagnosticCategory: Failure, Function Check, Out Of Specification, Maintenance Required</para>
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
// ReSharper disable InconsistentNaming
        public bool CompareFF912ConfiguredValueWithNamurStatus(string pathToConfigurableAreaCheckBox, string pathToSimulationAreaCheckBox, bool expectedCheckBoxStatusOnConfigurationArea, string expectedNamurStatusOnHeader)
// ReSharper restore InconsistentNaming
        {
            // check configuration on configuration area
            // check activeness on status 2 area
            // check activeness on simulation area
            // check namur status at header
            this.SelectTab(1);
            bool currentStatusConfigurableArea = this.GetConfigurableAreaDiagnosticEventCheckBoxStatus(pathToConfigurableAreaCheckBox);
            if (currentStatusConfigurableArea.Equals(expectedCheckBoxStatusOnConfigurationArea))
            {
                this.SelectTab(4);
                bool currentStatusSimulationArea = this.GetSimulationAreaConfigurableDiagnosticEventCheckBoxStatus(pathToSimulationAreaCheckBox);
                if (currentStatusSimulationArea.Equals(expectedCheckBoxStatusOnConfigurationArea))
                {
                    string namurStatus = new GetNamurStatusFromHeader().Run();
                    if (namurStatus.ToLower().Contains(expectedNamurStatusOnHeader.ToLower()))
                    {
                        Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Diagnostic Event [{0}] has expected status [{1}]. \nNamur status [{1}] is as expected [{2}].", pathToConfigurableAreaCheckBox, expectedCheckBoxStatusOnConfigurationArea, expectedNamurStatusOnHeader));
                        return true;
                    }

                    Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Namur status [{0}] is not as expected [{1}].", namurStatus, expectedNamurStatusOnHeader));
                    return false;
                }

                Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Check box status [{0}] in simulation area is not as expected [{1}].", currentStatusSimulationArea, expectedCheckBoxStatusOnConfigurationArea));
                return false;
            }

            Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Check box status [{0}] in standard area is not as expected [{1}].", currentStatusConfigurableArea, expectedCheckBoxStatusOnConfigurationArea));
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
            ListItem listItem = null;
            int counter = 0;

            // check if a list item matches search string
            foreach (ListItem item in listItems)
            {
                string itemText = item.Text;

                // Remove different kind of whitespaces (160 & 32) and convert to lower case to avoid missmatching
                string searched = value.Replace(((char)32).ToString(CultureInfo.InvariantCulture), string.Empty).Replace(((char)160).ToString(CultureInfo.InvariantCulture), string.Empty).ToLower();
                string compared = itemText.Replace(((char)32).ToString(CultureInfo.InvariantCulture), string.Empty).Replace(((char)160).ToString(CultureInfo.InvariantCulture), string.Empty).ToLower();
                
                if (searched.Equals(compared))
                {
                    listItem = item;
                    break;
                }
            }

            if (listItem == null)
            {
                return false;
            }

            listItem.MoveTo(DefaultValues.locDefaultLocation);
            while (listItem.Selected == false)
            {
                // scrolling part                
                if (counter > listItems.Count)
                {
                    // list end, value not found, srolling up now
                    Keyboard.Press(Keys.Up);
                    Mouse.MoveTo(listItem, DefaultValues.locDefaultLocation);
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
                    Mouse.MoveTo(listItem, DefaultValues.locDefaultLocation);
                    counter++;
                }
            }

            listItem.Click(DefaultValues.locDefaultLocation);
            return true;
        }

        /// <summary>
        /// Sets a combo box control to a specified value
        /// </summary>
        /// <param name="element">
        /// combo box control found in the repository
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

            Mouse.MoveTo(element, DefaultValues.locDefaultLocation, 500);
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

        /// <summary>
        /// The set standard area priority text field.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool SetStandardAreaPriorityTextFieldValue(Text text, string value)
        {
            try
            {
                text.MoveTo();
                text.Click();
                int length = text.TextValue.Length;
                Keyboard.Press(value);
                for (int i = 0; i < length; i++)
                {
                    Keyboard.Press(Keys.Delete);
                }

                if (new FF912Functions().ClickApplyButton())
                {
                    string valueToCheck = this.GetStandardAreaPriorityTextFieldValue(text);
                    if (valueToCheck.Equals(value))
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Value [{0}] has been written. Apply was successful.", value));
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Value [{0}] has not been written. Apply was not successful.", value));
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("An error occured by applying changed value [{0}].", value));
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The set configurable area priority text field value.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool SetConfigurableAreaPriorityTextFieldValue(Text text, string value)
        {
            try
            {
                text.MoveTo();
                text.Click();
                int length = text.TextValue.Length;
                Keyboard.Press(value);
                for (int i = 0; i < length; i++)
                {
                    Keyboard.Press(Keys.Delete);
                }

                if (new FF912Functions().ClickApplyButton())
                {
                    string valueToCheck = this.GetConfigurableAreaPriorityTextFieldValue(text);
                    if (valueToCheck.Equals(value))
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Value [{0}] has been written. Apply was successful.", value));
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Value [{0}] has not been written. Apply was not successful.", value));
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("An error occured by applying changed value [{0}].", value));
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
        
        /// <summary>
        /// The get standard area priority text field value.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetStandardAreaPriorityTextFieldValue(Text text)
        {
            try
            {
                text.MoveTo();
                return text.TextValue;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// The get configurable area priority text field value.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetConfigurableAreaPriorityTextFieldValue(Text text)
        {
            try
            {
                text.MoveTo();
                return text.TextValue;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// The remove white spaces.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string RemoveWhiteSpaces(string path)
        {
            if (path != null)
            {
                string modifiedPath = path.Replace(((char)32).ToString(CultureInfo.InvariantCulture), string.Empty).Replace(((char)160).ToString(CultureInfo.InvariantCulture), string.Empty);
                return modifiedPath;    
            }

            return null;
        }

        /// <summary>
        /// The set check box status.
        /// </summary>
        /// <param name="checkBox">
        /// The check box.
        /// </param>
        /// <param name="pathToEventCheckBox">
        /// The path to event check box.
        /// </param>
        /// <param name="toCheck">
        /// The to check.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool SetCheckBoxStatus(Ranorex.CheckBox checkBox, string pathToEventCheckBox, bool toCheck)
        {
            checkBox.MoveTo(500);
            bool checkBoxStatus = checkBox.Checked;
            if (!checkBoxStatus.Equals(toCheck))
            {
                checkBox.Click();
                this.ClickApplyButton();
            }

            checkBoxStatus = checkBox.Checked;
            if (checkBoxStatus.Equals(toCheck))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), pathToEventCheckBox + " is set to " + toCheck);
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), pathToEventCheckBox + " is not set to " + toCheck);
            return true;
        }

        #endregion
    }
}
