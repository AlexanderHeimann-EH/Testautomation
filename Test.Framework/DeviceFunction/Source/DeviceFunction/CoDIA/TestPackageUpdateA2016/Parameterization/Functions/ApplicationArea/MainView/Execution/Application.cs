// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Application.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   ApplicationArea provides functionality to select and change specified parameters.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
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
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    using CheckBox = Ranorex.CheckBox;
    using Control = Ranorex.Control;

    /// <summary>
    ///     ApplicationArea provides functionality to select and change specified parameters.
    /// </summary>
    public class Application : IApplication
    {
        #region Public Methods and Operators

        /// <summary>
        /// Check if a specified parameter has a specific state
        /// </summary>
        /// <param name="controlName">
        /// internal control name
        /// </param>
        /// <param name="expectedState">
        /// State to check parameter for
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool CheckForParameterState(string controlName, string expectedState)
        {
            try
            {
                Container cachedContainer;
                Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaDtmDisplayArea, DefaultValues.iTimeoutDefault, out cachedContainer);

                string parameterState = this.GetParameterState(controlName, cachedContainer).ToString();

                // If parameter has expected state
                if (parameterState.Contains(expectedState))
                {
                    return true;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter has not expected state");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Check if a specified parameter has specific values
        /// </summary>
        /// <param name="pathToParameter">
        /// Name and path of parameter to check. Use this form: Micropilot 5x//Setup//Full calibration (4):
        /// </param>
        /// <param name="expectedValue">
        /// Value to check parameter for
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool CheckForParameterValue(string pathToParameter, string expectedValue)
        {
            try
            {
                string[] separator = { "//" };
                string[] pathParts = pathToParameter.Split(separator, StringSplitOptions.None);
                string parameterName = pathParts[pathParts.Length - 1];
                parameterName = parameterName.Replace("\\", string.Empty); // added seg
                if ((new Navigation()).SearchAndSelectParameter(pathToParameter) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter not found.");
                    return false;
                }

                Container cachedContainer;
                Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaDtmDisplayArea, DefaultValues.iTimeoutDefault, out cachedContainer);
                string controlName = this.GetControlname(parameterName, cachedContainer);
                EditorType tmpEditorType = this.GetEditorType(controlName, cachedContainer);
                string parameterValue = this.GetParameterValue(controlName, tmpEditorType, cachedContainer);
                if (parameterValue != null)
                {
                    // Replace every non word char
                    var pattern = new Regex(@"\W");
                    string actualValue = pattern.Replace(parameterValue, string.Empty);
                    string expected = pattern.Replace(expectedValue, string.Empty);

                    // If parameter has expected value
                    if (actualValue == expected)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal. Parameter has the value: " + parameterValue + " ; Expected value is: " + expectedValue + " ;");
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are not equal. Parameter has the value: " + parameterValue + " ; Expected value is: " + expectedValue + " ;");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not get parameter's values.");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Clicks text field from a parameter and stores all combo box values in an string array
        /// </summary>
        /// <param name="parameterName">
        /// Parameter for which combo box values will be stored
        /// </param>
        /// <returns>
        /// <br>String[]: with combo box values if call worked fine</br>
        ///     <br>NULL: if an error occurred</br>
        /// </returns>
        public string[] GetList(string parameterName)
        {
            try
            {
                Container cachedContainer;
                Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaDtmDisplayArea, DefaultValues.iTimeoutDefault, out cachedContainer);

                string controlName = this.GetControlname(parameterName, cachedContainer);
                controlName = controlName.Replace("Label", "Editor");

                string search = ApplicationPaths.StrApplAreaParameterComboBoxValue.Replace("CONTROLNAME", controlName);
                Text text;
                cachedContainer.TryFindSingle(search, out text);

                if (text != null && text.Enabled)
                {
                    text.Click();
                    IList<ListItem> comboBoxList = Host.Local.Find<ListItem>(ApplicationPaths.StrApplAreaComboBoxList, DefaultValues.iTimeoutDefault);

                    var result = new string[comboBoxList.Count];
                    int index = 0;
                    foreach (ListItem items in comboBoxList)
                    {
                        result[index] = items.Text; // ToString();
                        index++;
                    }

                    text.Click();
                    return result;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text is null or not enabled");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Clicks text field from a parameter and stores all combo box values in an string array
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// <br>String[]: with combo box values if call worked fine</br>
        ///     <br>NULL: if an error occurred</br>
        /// </returns>
        public string[] GetList(Unknown element)
        {
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "This method is not supported. Use [public string[] GetList(Unknown element)] instead.");
            return null;
        }

        /// <summary>
        /// The get page height.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int GetPageHeight()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetParameter returns a information-set of a specified parameter
        /// </summary>
        /// <param name="parameterName">
        /// Name of parameter
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// Parameter-object containing a set of parameter information
        /// </returns>
        public Parameter GetParameter(string parameterName, int index)
        {
            return this.GetParameter(parameterName);
        }

        /// <summary>
        /// GetParameter returns a information-set of a specified parameter
        /// </summary>
        /// <param name="parameterName">
        /// Name of parameter
        /// </param>
        /// <returns>
        /// Parameter-object containing a set of parameter information
        /// </returns>
        public Parameter GetParameter(string parameterName)
        {
            try
            {
                var parameter = new Parameter(parameterName);
                Container cachedContainer;

                // Time Optimization
                var watch = new Stopwatch();
                var watch2 = new Stopwatch();
                watch2.Start();

                Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaDtmDisplayArea, DefaultValues.iTimeoutDefault, out cachedContainer);
                watch.Start();

                // Step 1
                string controlName = this.GetControlname(parameterName, cachedContainer);
                watch.Stop();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetControlname took " + watch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture) + " Milliseconds");
                watch.Reset();

                watch.Start();
                EditorType tmpEditorType = this.GetEditorType(controlName, cachedContainer);
                watch.Stop();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetEditorType took " + watch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture) + " Milliseconds");
                watch.Reset();

                // Step 2
                watch.Start();
                parameter.ParameterState = this.GetParameterState(controlName, cachedContainer);
                watch.Stop();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameterState took " + watch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture) + " Milliseconds");
                watch.Reset();

                // Step 3
                watch.Start();
                parameter.ParameterValue = this.GetParameterValue(controlName, tmpEditorType, cachedContainer);
                watch.Stop();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameterValue took " + watch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture) + " Milliseconds");
                watch.Reset();

                // Step 4
                watch.Start();
                parameter.ParameterUnit = this.GetParameterUnit(controlName, cachedContainer);
                watch.Stop();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameterUnit took " + watch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture) + " Milliseconds");
                watch.Reset();

                // Step 5
                watch.Start();
                parameter.ParameterType = this.GetParameterType(tmpEditorType);
                watch.Stop();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameterType took " + watch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture) + " Milliseconds");
                watch.Reset();

                watch2.Stop();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "--- GetParameter took ---" + watch2.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture) + " Milliseconds");
                watch2.Reset();

                return parameter;
            }
            catch (ArgumentException excArgException)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), excArgException.Message);
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// GetParameterStateFast returns a information-set of a specified parameter
        /// </summary>
        /// <param name="parameterName">
        /// Name of parameter
        /// </param>
        /// <returns>
        /// Parameter-object containing the state of the parameter
        /// </returns>
        public Parameter GetParameterStateFast(string parameterName)
        {
            try
            {
                var parameter = new Parameter(parameterName);
                Container cachedContainer;

                // Time Optimization
                var watch = new Stopwatch();

                Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaDtmDisplayArea, DefaultValues.iTimeoutDefault, out cachedContainer);
                watch.Start();

                // Step 1
                string controlName = this.GetControlname(parameterName, cachedContainer);
                watch.Stop();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetControlname took " + watch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture) + " Milliseconds");
                watch.Reset();

                // Step 2
                watch.Start();
                parameter.ParameterState = this.GetParameterState(controlName, cachedContainer);
                watch.Stop();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameterState took " + watch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture) + " Milliseconds");
                watch.Reset();

                return parameter;
            }
            catch (ArgumentException excArgException)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), excArgException.Message);
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// The get scrollbar height.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int GetScrollbarHeight()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get scrollbar y position.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int GetScrollbarYPosition()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether a parameter is read only.
        /// </summary>
        /// <param name="parameterName">
        /// Name (label) of the parameter.
        /// </param>
        /// <returns>
        /// <c>true</c> if the parameter is read only; otherwise, <c>false</c>.
        /// </returns>
        public bool IsParameterReadOnly(string parameterName)
        {
            try
            {
                bool result;
                Element element;
                Container cachedContainer;

                Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaDtmDisplayArea, DefaultValues.iTimeoutDefault, out cachedContainer);
                string controlName = this.GetControlname(parameterName, cachedContainer);
                controlName = controlName.Replace("Label", "Editor");

                string search = ApplicationPaths.StrApplAreaParameterState.Replace("CONTROLNAME", controlName);

                cachedContainer.TryFindSingle(search, out element);

                if (element == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter + " + parameterName + " is null.");
                    result = false;
                }
                else
                {
                    Mouse.MoveTo(element);
                    result = Convert.ToBoolean(element.GetAttributeValue("ReadOnly"));
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Set parameter's value
        /// </summary>
        /// <param name="parameterName">
        /// Parameter to change
        /// </param>
        /// <param name="inputValue">
        /// Input value
        /// </param>
        /// <param name="confirm">
        /// Determines whether to confirm the changed value.
        /// </param>
        /// <param name="parameterIndex">
        /// The parameter Index.
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SetParameterValue(string parameterName, string inputValue, bool confirm, int parameterIndex)
        {
            return this.SetParameterValue(parameterName, inputValue, confirm);
        }

        /// <summary>
        /// Set parameter's value
        /// </summary>
        /// <param name="parameterName">
        /// Parameter to change
        /// </param>
        /// <param name="inputValue">
        /// Input value
        /// </param>
        /// <param name="confirm">
        /// Determines whether to confirm the changed value.
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SetParameterValue(string parameterName, string inputValue, bool confirm)
        {
            try
            {
                Container cachedContainer;
                Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaDtmDisplayArea, DefaultValues.iTimeoutDefault, out cachedContainer);
                string controlName = this.GetControlname(parameterName, cachedContainer);
                EditorType editor = this.GetEditorType(controlName, cachedContainer);

                switch (editor)
                {
                    case EditorType.ComboBox:
                        {
                            return this.SetComboBoxValue(controlName, inputValue, cachedContainer, confirm);
                        }

                    case EditorType.EditField:
                        {
                            return this.SetEditFieldValue(controlName, inputValue, cachedContainer, confirm);
                        }

                    default:
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Extension of switch()case necessary.");
                            return false;
                        }
                }
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The set parameter value.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="inputValue">
        /// The input value.
        /// </param>
        /// <param name="confirm">
        /// The confirm.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetParameterValue(Unknown element, string inputValue, bool confirm)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "This Method is obsolete and not supported any more");
            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get values of parameter's checkboxes
        /// </summary>
        /// <param name="controlName">
        /// internal control name
        /// </param>
        /// <param name="cachedContainer">
        /// Container for cached GUI-control paths
        /// </param>
        /// <returns>
        /// List of strings
        /// </returns>
        private string GetCheckBoxValue(string controlName, Container cachedContainer)
        {
            try
            {
                string checkBoxValues = string.Empty;
                controlName = controlName.Replace("Label", "Editor");

                string search = ApplicationPaths.StrApplAreaParameterCheckBoxValue.Replace("CONTROLNAME", controlName);

                // checkBoxList = Host.Local.Find<CheckBox>(search, DefaultValues.iTimeoutDefault);
                IList<CheckBox> checkBoxList = cachedContainer.Find<CheckBox>(search, DefaultValues.iTimeoutDefault);
                if (checkBoxList.Count > 0)
                {
                    foreach (CheckBox box in checkBoxList)
                    {
                        Mouse.MoveTo(box);
                        checkBoxValues = checkBoxValues + "\n- " + box.Text + ": " + box.CheckState.ToString() + ";";
                    }
                }

                return checkBoxValues;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Get selected value of a combo box
        /// </summary>
        /// <param name="controlName">
        /// internal control name
        /// </param>
        /// <param name="cachedContainer">
        /// Container for cached GUI-control paths
        /// </param>
        /// <returns>
        /// String: Current Combo Box-Value
        /// </returns>
        private string GetComboBoxValue(string controlName, Container cachedContainer)
        {
            try
            {
                Text text;
                controlName = controlName.Replace("Label", "Editor");

                string search = ApplicationPaths.StrApplAreaParameterComboBoxValue.Replace("CONTROLNAME", controlName);

                // if(Host.Local.TryFindSingle(search, DefaultValues.iTimeoutDefault, out text))
                if (cachedContainer.TryFindSingle(search, out text))
                {
                    Mouse.MoveTo(text);
                    return text.TextValue;
                }

                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Get control name of parameter's label at application area
        /// </summary>
        /// <param name="parameterName">
        /// Searched Parameter
        /// </param>
        /// <param name="cachedContainer">
        /// Container for cached GUI-control paths
        /// </param>
        /// <returns>
        /// String: internal control name
        /// </returns>
        private string GetControlname(string parameterName, Container cachedContainer)
        {
            try
            {
                string controlName = string.Empty;

                // old
                // labelList = Host.Local.Find<Text>(ApplicationAreaPaths.strApplAreaParameterLabel, DefaultValues.GeneralTimeout);

                // New
                IList<Text> labelList = cachedContainer.Find<Text>(ApplicationPaths.StrApplAreaParameterLabel);
                foreach (Text text in labelList)
                {
                    if (string.CompareOrdinal(text.TextValue, parameterName) != 0)
                    {
                        continue;
                    }

                    Element element = text.Element.Parent;
                    if (element != null)
                    {
                        var control = new Control(element);
                        controlName = control.Name;
                        break;
                    }
                }

                return controlName;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Get value of a EditField
        /// </summary>
        /// <param name="controlName">
        /// internal control name
        /// </param>
        /// <param name="cachedContainer">
        /// Container for cached GUI-control paths
        /// </param>
        /// <returns>
        /// String: Current EditField-Value
        /// </returns>
        private string GetEditFieldValue(string controlName, Container cachedContainer)
        {
            try
            {
                Text text;
                controlName = controlName.Replace("Label", "Editor");
                string search = ApplicationPaths.StrApplAreaParameterEditFieldValue.Replace("CONTROLNAME", controlName);

                // if(Host.Local.TryFindSingle(search, DefaultValues.iTimeoutDefault, out text))
                if (cachedContainer.TryFindSingle(search, out text))
                {
                    Mouse.MoveTo(text);
                    return text.TextValue;
                }

                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Get editor type of parameter at application area
        /// </summary>
        /// <param name="controlName">
        /// internal control name
        /// </param>
        /// <param name="cachedContainer">
        /// Container for cached GUI-control paths
        /// </param>
        /// <returns>
        /// String: editor type
        /// </returns>
        private EditorType GetEditorType(string controlName, Container cachedContainer)
        {
            controlName = controlName.Replace("Label", "Editor");
            string identifierCombo = ApplicationPaths.StrApplAreaComboEdit.Replace("CONTROLNAME", controlName);
            string identifierCheck = ApplicationPaths.StrApplAreaCheck.Replace("CONTROLNAME", controlName);

            // old
            // Element element = null;
            // Container container = null;
            // Host.Local.TryFindSingle(identifierCombo, DefaultValues.iTimeoutDefault, out element);
            // Host.Local.TryFindSingle(identifierCheck, DefaultValues.iTimeoutDefault, out container);

            // new
            Element element;
            Container container;

            cachedContainer.TryFindSingle(identifierCombo, out element);
            cachedContainer.TryFindSingle(identifierCheck, out container);

            // if no element or container is found
            if (element == null && container == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Editor did not match to ComboBox, EditField or CheckBox");
                return EditorType.Unknown;
            }

            // if element is found
            if (element != null && container == null)
            {
                // New
                IList<Element> textList = element.Find("text");
                IList<Element> buttonList = element.Find("button");

                // Old
                // IList<Text> textList = null;
                // IList<Button> buttonList = null;
                // textList = Host.Local.Find<Text>(identifierCombo+"/text", DefaultValues.iTimeoutDefault);
                // buttonList = Host.Local.Find<Button>(identifierCombo+"/button", DefaultValues.iTimeoutDefault);

                // if element contains more than one edit fields and no button
                if (textList.Count > 1 && buttonList.Count == 0)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Editor is EditField");
                    return EditorType.EditField;
                }

                // if element contains one edit field and one button 
                if (textList.Count == 1 && buttonList.Count == 1)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Editor is ComboBox");
                    return EditorType.ComboBox;
                }

                if (textList.Count == 1 && buttonList.Count == 0)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Editor is EditField (read only)");
                    return EditorType.EditFieldReadOnly;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Editor is of unknown type");
                return EditorType.Unknown;
            }

            // if container is found
            if (element == null)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Editor is CheckBox");
                return EditorType.CheckBox;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Editor is recognized as ComboBox, EditField and CheckBox");
            return EditorType.Unknown;
        }

        /// <summary>
        /// Get a specified list item of a combo box when list is shown.
        /// </summary>
        /// <param name="selectValue">
        /// comboBox item to select
        /// </param>
        /// <returns>
        /// List item to select
        /// </returns>
        private ListItem GetListItem(string selectValue)
        {
            try
            {
                ListItem listItem = null;
                IList<ListItem> comboBoxList = Host.Local.Find<ListItem>(ApplicationPaths.StrApplAreaComboBoxList, DefaultValues.iTimeoutDefault);
                var pattern = new Regex(@"\W");
                selectValue = pattern.Replace(selectValue, string.Empty);

                foreach (ListItem items in comboBoxList)
                {
                    string comboBoxItemName = pattern.Replace(items.Text, string.Empty);
                    if (comboBoxItemName == selectValue)
                    {
                        listItem = items;
                    }
                }

                if (listItem != null)
                {
                    return listItem;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "List is not accessible.");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Get parameter's state
        /// </summary>
        /// <param name="controlName">
        /// internal control name
        /// </param>
        /// <param name="cachedContainer">
        /// Container for cached GUI-control paths
        /// </param>
        /// <returns>
        /// Enumeration: Parameter State
        /// </returns>
        private ParameterState GetParameterState(string controlName, Container cachedContainer)
        {
            try
            {
                Element element;
                controlName = controlName.Replace("Label", "StatusIcon");

                string search = ApplicationPaths.StrApplAreaParameterState.Replace("CONTROLNAME", controlName);

                cachedContainer.TryFindSingle(search, out element);

                if (element != null)
                {
                    Mouse.MoveTo(element);
                    return this.GetState(element);
                }

                return ParameterState.NotRecognized;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return ParameterState.NotRecognized;
            }
        }

        /// <summary>
        /// Get a parameter's internal type
        /// </summary>
        /// <param name="editorType">
        /// Type of editor
        /// </param>
        /// <returns>
        /// Enumeration.ParameterType: parameter type
        /// </returns>
        private ParameterType GetParameterType(EditorType editorType)
        {
            switch (editorType)
            {
                case EditorType.ComboBox:
                    {
                        return ParameterType.Enumeration;
                    }

                case EditorType.EditField:
                    {
                        return ParameterType.Text;
                    }

                case EditorType.EditFieldReadOnly:
                    {
                        return ParameterType.Text;
                    }

                case EditorType.CheckBox:
                    {
                        return ParameterType.BitEnumeration;
                    }

                default:
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Extension of switch()case necessary.");
                        return ParameterType.Unknown;
                    }
            }
        }

        /// <summary>
        /// Get a parameter's unit at application area
        /// </summary>
        /// <param name="controlName">
        /// Specified Parameter
        /// </param>
        /// <param name="cachedContainer">
        /// Container for cached GUI-control paths
        /// </param>
        /// <returns>
        /// String: parameter unit
        /// </returns>
        private string GetParameterUnit(string controlName, Container cachedContainer)
        {
            try
            {
                Text text;
                controlName = controlName.Replace("Label", "Unit");
                string search = ApplicationPaths.StrApplAreaParameterUnit.Replace("CONTROLNAME", controlName) + "/text";

                // if(Host.Local.TryFindSingle(search, DefaultValues.iTimeoutDefault, out text))
                if (cachedContainer.TryFindSingle(search, out text))
                {
                    Mouse.MoveTo(text);
                    return text.TextValue;
                }

                return "-";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Get a parameter's value at application area
        /// </summary>
        /// <param name="controlName">
        /// Specified Parameter
        /// </param>
        /// <param name="editorType">
        /// Type of editor
        /// </param>
        /// <param name="cachedContainer">
        /// Container for cached GUI-control paths
        /// </param>
        /// <returns>
        /// String: parameter value
        /// </returns>
        private string GetParameterValue(string controlName, EditorType editorType, Container cachedContainer)
        {
            // Enumerations.EditorType editorType = GetEditorType(controlName);
            switch (editorType)
            {
                case EditorType.ComboBox:
                    {
                        return this.GetComboBoxValue(controlName, cachedContainer);
                    }

                case EditorType.EditField:
                    {
                        return this.GetEditFieldValue(controlName, cachedContainer);
                    }

                case EditorType.EditFieldReadOnly:
                    {
                        return this.GetComboBoxValue(controlName, cachedContainer);
                    }

                case EditorType.CheckBox:
                    {
                        return this.GetCheckBoxValue(controlName, cachedContainer);
                    }

                default:
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Extension of switch()case necessary.");
                        return null;
                    }
            }
        }

        /// <summary>
        /// Get state related to a state-icon
        /// </summary>
        /// <param name="element">
        /// Element containing an state-icon.
        /// </param>
        /// <returns>
        /// Enumerations ParameterState [status]
        /// </returns>
        private ParameterState GetState(Element element)
        {
            try
            {
                string state = element.GetAttributeValueText("accessibledescription");

                if (state == "Insecure")
                {
                    return ParameterState.Insecure;
                }

                if (state == "Invalid")
                {
                    return ParameterState.Invalid;
                }

                if (state == "Valid")
                {
                    return ParameterState.Valid;
                }

                if (state == "Modified")
                {
                    return ParameterState.Modified;
                }

                if (state == "Dynamic1")
                {
                    return ParameterState.Dynamic1;
                }

                if (state == "Dynamic2")
                {
                    return ParameterState.Dynamic2;
                }

                if (state == "ModifiedOutOfRange")
                {
                    return ParameterState.ModifiedOutOfRange;
                }

                if (state == "ModifiedInvalidFormat")
                {
                    return ParameterState.ModifiedInvalidFormat;
                }

                if (state == "ModifiedWrong")
                {
                    return ParameterState.ModifiedWrong;
                }

                if (state == "WriteFailed")
                {
                    return ParameterState.WriteFailed;
                }

                return ParameterState.NotRecognized;
            }
            catch (ArgumentException excArgException)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), excArgException.Message);
                return ParameterState.NotRecognized;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return ParameterState.NotRecognized;
            }
        }

        /// <summary>
        /// Set parameter's combo box value
        /// </summary>
        /// <param name="controlName">
        /// internal control name
        /// </param>
        /// <param name="inputValue">
        /// Input value
        /// </param>
        /// <param name="cachedContainer">
        /// Container for cached GUI-control paths
        /// </param>
        /// <param name="confirm">
        /// determines whether to confirm the value or not
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        private bool SetComboBoxValue(string controlName, string inputValue, Container cachedContainer, bool confirm)
        {
            try
            {
                Text text;
                controlName = controlName.Replace("Label", "Editor");
                string search = ApplicationPaths.StrApplAreaParameterComboBoxValue.Replace("CONTROLNAME", controlName);
                cachedContainer.TryFindSingle(search, out text);

                // Host.Local.TryFindSingle(search, DefaultValues.iTimeoutDefault, out text);
                if (text != null && text.Enabled)
                {
                    Mouse.MoveTo(text, 500);
                    text.Click();
                    if (text.HasFocus)
                    {
                        // Return feedback that parameter has focus
                        // Change and confirm selected parameter value
                        ListItem listItem = this.GetListItem(inputValue);

                        IList<ListItem> comboBoxList = Host.Local.Find<ListItem>(ApplicationPaths.StrApplAreaComboBoxList, DefaultValues.iTimeoutDefault);
                        int counter = 0;
                        while (listItem.Selected == false)
                        {
                            if (counter >= comboBoxList.Count - 1)
                            {
                                // list end, value not found, scrolling up now
                                Keyboard.Press(Keys.Up);
                                counter++;
                                Mouse.MoveTo(listItem);
                            }
                            else
                            {
                                if (counter > (comboBoxList.Count - 1) * 2)
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

                        Mouse.Click(listItem, DefaultValues.locDefaultLocation, DefaultValues.durDurationShort);

                        if (confirm)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Confirming changed value.");
                            Keyboard.Press(Keys.Enter);
                            return this.WaitForParameterUpdate(controlName);
                        }

                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Value changed but not confirmed");
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter is not in edit mode.");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter is not available.");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Sets the edit field value.
        /// </summary>
        /// <param name="controlName">
        /// Name of the control.
        /// </param>
        /// <param name="inputValue">
        /// The input value.
        /// </param>
        /// <param name="cachedContainer">
        /// The cached container.
        /// </param>
        /// <param name="confirm">
        /// if set to <c>true</c> [confirm].
        /// </param>
        /// <returns>
        /// <c>true</c> if successful, <c>false</c> otherwise.
        /// </returns>
        private bool SetEditFieldValue(string controlName, string inputValue, Container cachedContainer, bool confirm)
        {
            try
            {
                Text text;
                controlName = controlName.Replace("Label", "Editor");
                string search = ApplicationPaths.StrApplAreaParameterEditFieldValue.Replace("CONTROLNAME", controlName);
                cachedContainer.TryFindSingle(search, out text);

                // Host.Local.TryFindSingle(search, DefaultValues.iTimeoutDefault, out text);
                if (text != null)
                {
                    if (!text.HasFocus)
                    {
                        Mouse.MoveTo(text, 500);
                        text.DoubleClick();
                    }

                    if (text.HasFocus)
                    {
                        // Delete available value
                        int count = text.TextValue.Length;
                        for (int counter = 0; counter < count; counter++)
                        {
                            Keyboard.Press(Keys.Delete);
                        }

                        // Enter new value
                        Keyboard.Press(inputValue);

                        if (confirm)
                        {
                            // Confirm changed parameter
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Confirming changed value.");
                            Keyboard.Press(Keys.Enter);
                            return this.WaitForParameterUpdate(controlName);
                        }

                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Value changed but not confirmed");
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Waits for parameter update after writing
        /// </summary>
        /// <param name="controlName">
        /// internal parameter name
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        private bool WaitForParameterUpdate(string controlName)
        {
            bool result = true;
            var watch = new Stopwatch();
            watch.Start();

            // Wait until updated
            while (this.WaitUntilParameterIsWritten(controlName))
            {
                if (watch.ElapsedMilliseconds <= DefaultValues.GeneralTimeout)
                {
                    continue;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter is not updated after: >" + DefaultValues.GeneralTimeout + "Milliseconds.");
                result = false;
                break;
            }

            watch.Stop();
            return result;
        }

        /// <summary>
        /// Wait until parameter is written into device
        /// </summary>
        /// <param name="controlName">
        /// The control Name.
        /// </param>
        /// <returns>
        /// True, if parameter is not written
        /// </returns>
        private bool WaitUntilParameterIsWritten(string controlName)
        {
            if (this.CheckForParameterState(controlName, ParameterState.Valid.ToString()))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}