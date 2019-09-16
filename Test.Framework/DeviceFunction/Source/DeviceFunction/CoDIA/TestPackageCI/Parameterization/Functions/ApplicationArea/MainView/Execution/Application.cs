// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Application.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   ApplicationArea provides functionality to select and change specified parameters.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    using Control = Ranorex.Control;
    using Text = Ranorex.Text;

    /// <summary>
    ///     ApplicationArea provides functionality to select and change specified parameters.
    /// </summary>
    public class Application : IApplication
    {
        #region fields

        /// <summary>
        /// The DTM display area.
        /// </summary>
        private Container dtmDisplayArea;

        /// <summary>
        /// The all elements from page.
        /// </summary>
        private IList<Unknown> allElementsFromPage;

        /// <summary>
        /// The scroll container.
        /// </summary>
        private Unknown scrollBarContainer;

        /// <summary>
        /// The is scroll bar initialized.
        /// </summary>
        private bool isScrollBarInitialized;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        public Application()
        {
            this.ButtonPageDown = null;
            this.ButtonPageUp = null;
            this.ButtonLineDown = null;
            this.ButtonLineUp = null;
            this.ButtonPosition = null;
            this.Scrollbar = null;

            this.NumberOfParameterInvalid = 0;
            this.NumberOfParameterDynamic = 0;
            this.NumberOfParameterInsecure = 0;
            this.NumberOfParameterModified = 0;
            this.NumberOfParameterValid = 0;

            this.isScrollBarInitialized = false;

            Host.Local.TryFindSingle(ApplicationPaths.StrApplAreaDtmDisplayArea, out this.dtmDisplayArea);

            this.GetScrollBar();

            if (this.scrollBarContainer != null)
            {
                IList<Unknown> scrollbars = this.scrollBarContainer.Children;

                if (scrollbars.Count == 1)
                {
                    this.Scrollbar = scrollbars[0];
                }

                if (scrollbars.Count == 2)
                {
                    if (scrollbars[0].Element.ScreenRectangle.Height > scrollbars[0].Element.ScreenRectangle.Width)
                    {
                        this.Scrollbar = scrollbars[0];
                    }
                    else
                    {
                        this.Scrollbar = scrollbars[1];
                    }
                }

                if (this.Scrollbar != null)
                {
                    foreach (var child in this.Scrollbar.Children)
                    {
                        string accessibleNameOfChild = child.Element.GetAttributeValueText("accessiblename");
                        if (accessibleNameOfChild != null)
                        {
                            switch (accessibleNameOfChild)
                            {
                                case "Page Down":
                                    {
                                        this.ButtonPageDown = child;
                                        break;
                                    }

                                case "Page Up":
                                    {
                                        this.ButtonPageUp = child;
                                        break;
                                    }

                                case "Line Down":
                                    {
                                        this.ButtonLineDown = child;
                                        break;
                                    }

                                case "Line Up":
                                    {
                                        this.ButtonLineUp = child;
                                        break;
                                    }

                                case "Position":
                                    {
                                        this.ButtonPosition = child;
                                        break;
                                    }
                            }
                        }
                    }
                }

                this.isScrollBarInitialized = true;
            }
        }

        #region properties

        /// <summary>
        /// Gets or sets the number of parameter valid.
        /// </summary>
        public int NumberOfParameterValid { get; set; }

        /// <summary>
        /// Gets or sets the number of parameter invalid.
        /// </summary>
        public int NumberOfParameterInvalid { get; set; }

        /// <summary>
        /// Gets or sets the number of parameter insecure.
        /// </summary>
        public int NumberOfParameterInsecure { get; set; }

        /// <summary>
        /// Gets or sets the number of parameter modified.
        /// </summary>
        public int NumberOfParameterModified { get; set; }

        /// <summary>
        /// Gets or sets the number of parameter dynamic.
        /// </summary>
        public int NumberOfParameterDynamic { get; set; }

        /// <summary>
        /// Gets or sets the button page down.
        /// </summary>
        private Unknown ButtonPageDown { get; set; }

        /// <summary>
        /// Gets or sets the button page up.
        /// </summary>
        private Unknown ButtonPageUp { get; set; }

        /// <summary>
        /// Gets or sets the button line down.
        /// </summary>
        // ReSharper disable UnusedAutoPropertyAccessor.Local
        private Unknown ButtonLineDown { get; set; }

        // ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets the button line up.
        /// </summary>
        private Unknown ButtonLineUp { get; set; }

        /// <summary>
        /// Gets or sets the button position.
        /// </summary>
        // ReSharper disable UnusedAutoPropertyAccessor.Local
        private Unknown ButtonPosition { get; set; }

        // ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets the scrollbar.
        /// </summary>
        private Unknown Scrollbar { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The search and select image.
        /// </summary>
        /// <param name="imageName">
        /// The image name.
        /// </param>
        /// <returns>
        /// The <see cref="Unknown"/>.
        /// </returns>
        public Unknown SearchAndSelectImage(string imageName)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                int parameterIndex = 1;
                string[] separator = { "//" };
                string[] pathParts = imageName.Split(separator, StringSplitOptions.None);

                // TODO: Performance optimization possible, by not using find method. use child of parent item instead
                this.allElementsFromPage = this.dtmDisplayArea.Find<Unknown>("descendant::element");
                IList<Unknown> allContainerFromPage = this.dtmDisplayArea.Find<Unknown>("descendant::container");

                IList<string> targetControlNames = new List<string>();

                // Handle all elements from page; suitable for text boxes and combo boxes
                foreach (var element in this.allElementsFromPage)
                {
                    string controlNameElement = element.Element.GetAttributeValueText("controlname");
                    if (controlNameElement != null)
                    {
                        if (controlNameElement.Contains("Image_Image_") && controlNameElement.Contains(pathParts[pathParts.Length - 1]))
                        {
                            targetControlNames.Add(controlNameElement);
                        }
                    }
                }

                if (targetControlNames.Count == 0)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: " + pathParts[pathParts.Length - 1] + " is not available");
                    return null;
                }

                string targetControlName = targetControlNames[parameterIndex - 1];

                Unknown target = null;
                foreach (var element in this.allElementsFromPage)
                {
                    string controlName = element.Element.GetAttributeValueText("controlname");
                    if (controlName != null)
                    {
                        if (controlName.Equals(targetControlName))
                        {
                            if (this.isScrollBarInitialized)
                            {
                                // 2017-08-04: EC - Bugfix Defect 40840
                                if (this.ButtonLineDown != null)
                                {
                                    while (element.ScreenRectangle.Y > this.ButtonLineDown.ScreenRectangle.Y)
                                    {
                                        this.ButtonPageDown.Click();
                                    }
                                }
                            }

                            Mouse.MoveTo(element);
                            target = element;
                            break;
                        }
                    }
                }

                return target;
            }

            return null;
        }
        
        /// <remarks>last edit: EC - 2017-02-10 - performance optimization</remarks>
        /// <summary>
        /// The search and select parameter.
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to parameter.
        /// </param>
        /// <returns>
        /// The <see cref="Unknown"/>.
        /// </returns>
        public Unknown SearchAndSelectParameter(string pathToParameter)
        {
            if (!string.IsNullOrEmpty(pathToParameter))
            {
                int parameterIndex = 1;
                bool isIndexForParameterAvailable = this.IsIndexForParameterAvailable(pathToParameter);
                if (isIndexForParameterAvailable)
                {
                    parameterIndex = this.GetAndRemoveIndexFromPath(ref pathToParameter);
                }

                string[] separator = { "//" };
                string[] pathParts = pathToParameter.Split(separator, StringSplitOptions.None);

                // TODO: Performance optimization possible, by not using find method. use child of parent item instead
                this.allElementsFromPage = this.dtmDisplayArea.Find<Unknown>("descendant::element");
                IList<Unknown> allContainerFromPage = this.dtmDisplayArea.Find<Unknown>("descendant::container");

                IList<string> targetControlNames = new List<string>();

                // Handle all elements from page; suitable for text boxes and combo boxes
                foreach (var element in this.allElementsFromPage)
                {
                    string controlNameElement = element.Element.GetAttributeValueText("controlname");
                    if (controlNameElement != null)
                    {
                        if (controlNameElement.Contains("Editor_Variable_") && controlNameElement.Contains(pathParts[pathParts.Length - 1]))
                        {
                            targetControlNames.Add(controlNameElement);
                        }
                    }
                }

                if (targetControlNames.Count == 0)
                {
                    // Handle all container from page; suitable for check boxes etc.
                    foreach (var element in allContainerFromPage)
                    {
                        string controlNameElement = element.Element.GetAttributeValueText("controlname");
                        if (controlNameElement != null)
                        {
                            if (controlNameElement.Contains("Editor_Variable_") && controlNameElement.Contains(pathParts[pathParts.Length - 1]))
                            {
                                targetControlNames.Add(controlNameElement);
                            }
                        }
                    }
                }

                if (targetControlNames.Count == 0)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: " + pathParts[pathParts.Length - 1] + " is not available");
                    return null;
                }

                if (parameterIndex > targetControlNames.Count)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: " + pathParts[pathParts.Length - 1] + " with Index: " + parameterIndex + " is not available");
                    return null;
                }

                if (parameterIndex == 0)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter index must not be 0. Index starts with 1.");
                    return null;
                }

                string targetControlName = targetControlNames[parameterIndex - 1];

                Unknown target = null;
                foreach (var element in this.allElementsFromPage)
                {
                    string controlName = element.Element.GetAttributeValueText("controlname");
                    if (controlName != null)
                    {
                        if (controlName.Equals(targetControlName))
                        {
                            if (this.isScrollBarInitialized)
                            {
                                // 2017-08-04: EC - Bugfix Defect 40840
                                if (this.ButtonLineDown != null)
                                {
                                    while (element.ScreenRectangle.Y > this.ButtonLineDown.ScreenRectangle.Y)
                                    {
                                        this.ButtonPageDown.Click();
                                    }    
                                }
                            }

                            Mouse.MoveTo(element);
                            target = element;
                            break;
                        }
                    }
                }

                if (target == null)
                {
                    foreach (var container in allContainerFromPage)
                    {
                        string controlName = container.Element.GetAttributeValueText("controlname");
                        if (controlName != null)
                        {
                            if (controlName.Equals(targetControlName))
                            {
                                if (this.isScrollBarInitialized)
                                {
                                    while (container.ScreenRectangle.Y > this.ButtonLineDown.ScreenRectangle.Y)
                                    {
                                        this.ButtonPageDown.Click();
                                    }
                                }

                                target = container;
                                break;
                            }
                        }
                    }
                }

                return target;
            }

            return null;
        }

        /// <summary>
        /// The set parameter value.
        /// </summary>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <param name="inputValue">
        /// The input value.
        /// </param>
        /// <param name="confirm">
        /// The confirm.
        /// </param>
        /// <param name="parameterIndex">
        /// The parameter index.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetParameterValue(string parameterName, string inputValue, bool confirm, int parameterIndex)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "This Method is obsolete and not supported any more");
            return false;
        }

        /// <remarks>last edit: EC - 2017-02-10 - performance optimization</remarks>
        /// <summary>
        /// The edit parameter value.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="inputValue">
        /// The input Value.
        /// </param>
        /// <param name="confirm">
        /// The confirm.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetParameterValue(Unknown element, string inputValue, bool confirm)
        {
            bool result = false;

            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Set Parameter Value failed. Element is null.");
            }
            else
            {
                string controlName = element.Element.GetAttributeValueText("controltype");
                switch (controlName)
                {
                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddComboBox":
                        {
                            // Set Parameter
                            if (this.IsInputValueAnIndex(inputValue))
                            {
                                int index = this.GetIndexFromInputValue(inputValue);
                                result = this.SetComboBoxIndex(element, index, confirm);
                            }
                            else
                            {
                                result = this.SetComboBoxValue(element, inputValue, confirm);
                            }

                            break;
                        }

                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddTextBox":
                        {
                            // Set Parameter
                            result = this.SetEditFieldValue(element, inputValue, confirm);
                            break;
                        }

                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddCheckListBox":
                        {
                            // Set Parameter is not used for checkboxes
                            result = this.SetCheckBoxValue(element, inputValue, confirm);

                            break;
                        }

                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMemoBox":
                        {
                            // Set Parameter
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMemoBox: Is not implemented yet");
                            break;
                        }

                    default:
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Control Type is unknown and non of these: EddCombobox, EddTextBox, EddCheckListBox or EddMemobox ");
                            break;
                        }
                }
            }

            return result;
        }

        /// <summary>
        /// The reset number of parameter counter.
        /// </summary>
        public void ResetNumberOfParameterCounter()
        {
            this.NumberOfParameterDynamic = 0;
            this.NumberOfParameterInsecure = 0;
            this.NumberOfParameterInvalid = 0;
            this.NumberOfParameterModified = 0;
            this.NumberOfParameterValid = 0;
        }

        /// <summary>
        /// The check application area for invalid values.
        /// </summary>
        public void CheckApplicationAreaForInvalidValues()
        {
            try
            {
                // Check if container for parameter in Application Area is accessible
                if (this.dtmDisplayArea != null)
                {
                    this.allElementsFromPage = this.dtmDisplayArea.Find<Unknown>("descendant::element");
                    IList<Unknown> allLabelElements = new List<Unknown>();
                    IList<Unknown> allStatusElements = new List<Unknown>();
                    foreach (var elementFromPage in this.allElementsFromPage)
                    {
                        string controlNameLabel = elementFromPage.Element.GetAttributeValueText("ControlName");
                        if (controlNameLabel != null)
                        {
                            if (controlNameLabel.Contains("Label_") && elementFromPage.Element.Visible)
                            {
                                allLabelElements.Add(elementFromPage);
                            }

                            if (controlNameLabel.Contains("StatusIcon_"))
                            {
                                allStatusElements.Add(elementFromPage);
                            }
                        }
                    }

                    if (this.Scrollbar != null)
                    {
                        for (int labelCounter = 0; labelCounter < allLabelElements.Count; labelCounter++)
                        {
                            // Scrolling at Application Area if neccessary
                            if (this.Scrollbar.ScreenRectangle.Height != 0)
                            {
                                Text text = allLabelElements[labelCounter].FindChild<Text>();
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Internal Parameter: " + text);
                                this.ScrollApplicationArea(text);
                            }

                            this.CheckApplicationAreaParameter(allStatusElements[labelCounter]);
                        }
                    }
                    else
                    {
                        // For all available parameter lables
                        for (int labelCounter = 0; labelCounter < allLabelElements.Count; labelCounter++)
                        {
                            Text text = allLabelElements[labelCounter].FindChild<Text>();
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter Name: " + text);
                            this.CheckApplicationAreaParameter(allStatusElements[labelCounter]);
                        }
                    }
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Applicaton Area Container could not be found.");
                }
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        /// <summary>
        /// Check if a specified parameter has a specific state
        /// </summary>
        /// <param name="parameterName">
        /// The parameter Name.
        /// </param>
        /// <param name="expectedState">
        /// State to check parameter for
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool CheckForParameterState(string parameterName, string expectedState)
        {
            try
            {
                Unknown element = this.SearchAndSelectParameter(parameterName);
                string parameterState = this.GetParameterState(element);

                // If parameter has expected state
                if (parameterState.Equals(expectedState))
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
        /// Check if a specified parameter has a specific state
        /// </summary>
        /// <param name="parameterName">
        /// The parameter Name.
        /// </param>
        /// <param name="expectedValue">
        /// The expected Value.
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool CheckForParameterValue(string parameterName, string expectedValue)
        {
            try
            {
                Unknown element = this.SearchAndSelectParameter(parameterName);
                
                string parameterValue = this.GetParameterValue(element);

                // If parameter has expected state
                if (parameterValue.Contains(expectedValue))
                {
                    return true;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Parameter: {0} has not expected value: {1}", parameterName, expectedValue));
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
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "This method is obsolete. Use [public string[] GetList(Unknown element)] instead.");
            return null;
        }

        /// <summary>
        /// The get list.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>string[]</cref>
        ///     </see>
        ///     .
        /// </returns>
        /// /// <remarks>Last update by EC: 2017-03-28</remarks>
        public string[] GetList(Unknown element)
        {
            try
            {
                if (element != null)
                {
                    element.Click();
                    IList<ListItem> comboBoxList = Host.Local.Find<ListItem>(ApplicationPaths.StrApplAreaComboBoxList, DefaultValues.iTimeoutDefault);

                    string[] comboBoxListItems = new string[comboBoxList.Count];
                    int index = 0;
                    foreach (ListItem item in comboBoxList)
                    {
                        comboBoxListItems[index] = item.Text;
                        index++;
                    }

                    if (comboBoxListItems.Length > 0)
                    {
                        return comboBoxListItems;
                    }
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No list items found.");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets the height of the page.
        /// </summary>
        /// <returns>Height of the page.</returns>
        public int GetPageHeight()
        {
            return this.GetScrollbarHeight() + this.GetScrollbarYPosition();
        }

        /// <summary>
        /// GetParameter returns a information-set of a specified parameter
        /// </summary>
        /// <param name="pathToParameter">
        /// The path To Parameter.
        /// </param>
        /// <returns>
        /// Parameter-object containing a set of parameter information
        /// </returns>
        public Parameter GetParameter(string pathToParameter)
        {
            try
            {
                Unknown element = this.SearchAndSelectParameter(pathToParameter);
                Parameter parameter = null;
                if (element == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameter failed. Element to search and select is null.");
                }
                else
                {
                    string parameterState = this.GetParameterState(element);
                    string parameterLabel = this.GetParameterLabel(element);
                    if (parameterLabel != null)
                    {
                        parameter = new Parameter(parameterLabel);
                        switch (parameterState)
                        {
                            case "Dynamic1":
                                {
                                    parameter.ParameterState = ParameterState.Dynamic1;
                                    break;
                                }

                            case "Dynamic2":
                                {
                                    parameter.ParameterState = ParameterState.Dynamic2;
                                    break;
                                }

                            case "Valid":
                                {
                                    parameter.ParameterState = ParameterState.Valid;
                                    break;
                                }

                            case "Insecure":
                                {
                                    parameter.ParameterState = ParameterState.Insecure;
                                    break;
                                }

                            case "Invalid":
                                {
                                    parameter.ParameterState = ParameterState.Invalid;
                                    break;
                                }

                            default:
                                {
                                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Status is unknown");
                                    break;
                                }
                        }

                        parameter.ParameterValue = this.GetParameterValue(element);
                        parameter.ParameterUnit = this.GetParameterUnit(element);
                    }
                }

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
        /// The get parameter fast.
        /// </summary>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <returns>
        /// The <see cref="Parameter"/>.
        /// </returns>
        public Parameter GetParameterStateFast(string parameterName)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "This Method is obsolete and not supported any more");
            return null;
        }

        /// <summary>
        /// Gets the height of the scrollbar.
        /// </summary>
        /// <returns>Height of the scrollbar.</returns>
        public int GetScrollbarHeight()
        {
            var scrollbarForHeight = new ApplicationElements().VerticalScrollbar;
            var result = 0;
            if (scrollbarForHeight != null)
            {
                result = scrollbarForHeight.ScreenRectangle.Height;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Scrollbar is null.");
            }

            return result;
        }

        /// <summary>
        /// Gets the y position of the scrollbar.
        /// </summary>
        /// <returns>Height of the scrollbar.</returns>
        public int GetScrollbarYPosition()
        {
            var scrollbarForYPosition = new ApplicationElements().VerticalScrollbar;
            var result = 0;
            if (scrollbarForYPosition != null)
            {
                result = scrollbarForYPosition.ScreenRectangle.Y;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Scrollbar is null.");
            }

            return result;
        }
        
        /// <summary>
        /// Obsolete function. Use EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Validation.IsParameterReadOnly
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
        /// Determines whether a parameter is read only.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// <c>true</c> if the parameter is read only; otherwise, <c>false</c>.
        /// </returns>
        public bool IsParameterReadOnly(Unknown element)
        {
            bool result = false;
            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unknown element is null.");
            }
            else
            {
                string controlName = element.Element.GetAttributeValueText("controltype");
                switch (controlName)
                {
                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddComboBox":
                        {
                            // Set Parameter
                            result = this.IsComboBoxReadOnly(element);
                            break;
                        }

                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddTextBox":
                        {
                            // Set Parameter
                            result = this.IsEditFieldReadOnly(element);
                            break;
                        }

                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddCheckListBox":
                        {
                            // Set Parameter
                            result = this.IsCheckBoxReadOnly(element);
                            break;
                        }

                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMemoBox":
                        {
                            // Set Parameter
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Get method for CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMemoBox: Is not implemented yet");
                            break;
                        }

                    default:
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Control Type is unknown and non of these: EddCombobox, EddTextBox, EddCheckListBox or EddMemobox ");
                            return false;
                        }
                }
            }

            return result;
        }

        /// <summary>
        /// Scrolls down via page down button.
        /// </summary>
        /// <returns><c>true</c> if button clicked, <c>false</c> otherwise.</returns>
        public bool PageDown()
        {
            var result = true;
            if (this.ButtonPageDown != null)
            {
                this.ButtonPageDown.Click();
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Page down button from scrollbar is null.");
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Scrolls up via page up button.
        /// </summary>
        /// <returns><c>true</c> if button clicked, <c>false</c> otherwise.</returns>
        public bool PageUp()
        {
            var result = true;
            if (this.ButtonPageUp != null)
            {
                this.ButtonPageUp.Click();
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Page up button from scrollbar is null.");
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Get a parameter's value at application area
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// String: parameter value
        /// </returns>
        /// <remarks>last edit: EC - 2017-02-13 - performance optimization</remarks>
        public string GetParameterValue(Unknown element)
        {
            string result = string.Empty;
            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unknown element is null.");
            }
            else
            {
                string controlName = element.Element.GetAttributeValueText("controltype");
                switch (controlName)
                {
                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddComboBox":
                        {
                            // Set Parameter
                            result = this.GetComboBoxValue(element);
                            break;
                        }

                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddTextBox":
                        {
                            // Set Parameter
                            result = this.GetEditFieldValue(element);
                            break;
                        }

                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddCheckListBox":
                        {
                            // Set Parameter
                            result = this.GetCheckBoxValue(element);
                            break;
                        }

                    case "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMemoBox":
                        {
                            // Set Parameter
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Get method for CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMemoBox: Is not implemented yet");
                            break;
                        }

                    default:
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Control Type is unknown and non of these: EddCombobox, EddTextBox, EddCheckListBox or EddMemobox ");
                            return string.Empty;
                        }
                }   
            }                        

            return result;
        }

        /// <summary>
        /// The get parameter enums.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> GetParameterEnums(Unknown element)
        {
            if (element != null)
            {
                string controlName = element.Element.GetAttributeValueText("controltype");
                if (controlName.Equals("CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddComboBox"))
                {
                    return this.GetComboBoxEnums(element);
                }
            }    

            return null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The is check box read only.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsCheckBoxReadOnly(Unknown element)
        {
            return this.IsReadOnly(element);
        }

        /// <summary>
        /// The is edit field read only.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsEditFieldReadOnly(Unknown element)
        {
            return this.IsReadOnly(element);
        }

        /// <summary>
        /// The is combo box read only.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsComboBoxReadOnly(Unknown element)
        {
            return this.IsReadOnly(element);
        }

        /// <summary>
        /// The is read only.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsReadOnly(Unknown element)
        {
            try
            {
                string isReadOnly = element.Element.GetAttributeValueText("readonly");
                bool returnValue = Convert.ToBoolean(isReadOnly);
                return returnValue;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Get selected value of a combo box
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// String: Current Combo Box-Value
        /// </returns>
        /// <remarks>last edit: EC - 2017-02-13 - performance optimization</remarks>
        private string GetComboBoxValue(Unknown element)
        {
            try
            {
                IList<Unknown> text = element.Children;
                if (text.Count > 0)
                {
                    Mouse.MoveTo(element);
                    string textValue = text[0].Element.GetAttributeValueText("text");
                    return textValue;
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
        /// The get combo box enums.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private List<string> GetComboBoxEnums(Unknown element)
        {
            // click on combobox
            // => list openes
            // get list items
            try
            {
                List<string> enums;
                element.Click();

                IList<ListItem> listItems = new ApplicationElements().ComboBoxListItems;

                if (listItems != null)
                {
                    if (listItems.Count > 0)
                    {
                        enums = new List<string>();
                        for (int counter = 0; counter < listItems.Count; counter++)
                        {
                            string textValue = listItems[counter].Element.GetAttributeValueText("text");
                            enums.Add(textValue);
                        }

                        return enums;
                    }    
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
        /// Get selected value of a check box
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// String: Current check Box-Value
        /// </returns>
        /// <remarks>last edit: EC - 2017-07-19 - changed format</remarks>
        private string GetCheckBoxValue(Unknown element)
        {
            try
            {
                string checkBoxValues = string.Empty;
                IList<Unknown> checkboxes = element.Children[0].Children;
                if (checkboxes.Count > 0)
                {
                    foreach (var checkbox in checkboxes)
                    {
                        Mouse.MoveTo(checkbox, Location.CenterLeft);
                        string text = checkbox.Element.GetAttributeValueText("text");
                        string checkState = checkbox.Element.GetAttributeValueText("checkstate");
                        checkBoxValues = checkBoxValues + "[Checkbox]: " + text + " --- " + "[State]: " + checkState + "\n";    
                    }

                    return checkBoxValues;
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
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// String: Current EditField-Value
        /// </returns>
        /// <remarks>last edit: EC - 2017-02-13 - performance optimization</remarks>
        private string GetEditFieldValue(Unknown element)
        {
            try
            {
                IList<Text> textFields = element.FindChildren<Text>();
                if (textFields.Count > 0)
                {
                    Mouse.MoveTo(element);

                    foreach (var text in textFields)
                    {
                        string textValue = text.Element.GetAttributeValueText("text");
                        if (textValue != null)
                        {
                            if (!textValue.Equals("TextBoxMaskBox"))
                            {
                                return textValue;
                            }
                        }
                    }

                    return null;
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
        /// Get a specified list item of a combo box when list is shown.
        /// </summary>
        /// <param name="selectValue">
        /// comboBox item to select
        /// </param>
        /// <returns>
        /// List item to select
        /// </returns>
        private ListItem GetListItem(int selectValue)
        {
            try
            {
                // TODO:
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Method GetListItem is not implemented yet");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// The get parameter label.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <remarks>
        /// last edit: EC - 2017-04-13 - anpassung wegen interner parameterpfade
        /// </remarks>
        private string GetParameterLabel(Unknown element)
        {
            string label = string.Empty;
            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameterState failed. Element is null.");
            }
            else
            {
                string labelElementControlName = element.Element.GetAttributeValueText("ControlName");
                if (labelElementControlName != null)
                {
                    labelElementControlName = labelElementControlName.Replace("Editor", "Label");
                    Unknown labelElement = this.GetLabelElement(labelElementControlName);
                    if (labelElement != null)
                    {
                        label = labelElement.Children[0].Element.GetAttributeValueText("Text");
                        if (string.IsNullOrEmpty(label))
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No status found");
                            label = string.Empty;
                        }
                    }
                }
            }

            return label;
        }

        /// <summary>
        /// Get a parameter's unit at application area
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// String: parameter unit
        /// </returns>
        /// <remarks>last edit: EC - 2017-02-13 - performance optimization</remarks>
        private string GetParameterUnit(Unknown element)
        {
            try
            {
                string searchedControlName = element.Element.GetAttributeValueText("controlname");

                if (searchedControlName != null)
                {
                    searchedControlName = searchedControlName.Replace("Editor", "Unit");
                    foreach (var elementFromPage in this.allElementsFromPage)
                    {
                        string currentControlName = elementFromPage.Element.GetAttributeValueText("controlname");
                        if (currentControlName != null)
                        {
                            if (currentControlName.Equals(searchedControlName))
                            {
                                if (elementFromPage.Children != null && elementFromPage.Children.Count > 0)
                                {
                                    string unit = elementFromPage.Children[0].Element.GetAttributeValueText("text");
                                    if (unit != null)
                                    {
                                        return unit;
                                    }
                                }
                            }
                        }
                    }
                }

                return string.Empty;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Set parameter's combo box value
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="inputValue">
        /// Input value
        /// </param>
        /// <param name="confirm">
        /// determines whether to confirm the value or not
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        private bool SetComboBoxValue(Unknown element, string inputValue, bool confirm)
        {
            try
            {
                Mouse.Click(element, Location.Center);
                Keyboard.Press(Keys.Delete);
                Keyboard.Press(inputValue);

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

                if (confirm)
                {
                    string statusElementControlName = this.GetParameterState(element);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter is in state: " + statusElementControlName);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Confirming changed value.");
                    Keyboard.Press(Keys.Enter);
                    string controlName = element.Element.GetAttributeValueText("ControlName");
                    if (controlName == null)
                    {
                        return false;
                    }
                }
                else
                {
                    Keyboard.Press(Keys.Escape);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Value changed but not confirmed. Changing aborted by pressing Escape.");
                }

                return this.WaitForParameterStatusUpdate(element);
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The set combo box index.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="indexToSelect">
        /// The index To Select.
        /// </param>
        /// <param name="confirm">
        /// The confirm.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool SetComboBoxIndex(Unknown element, int indexToSelect, bool confirm)
        {
            try
            {
                Mouse.Click(element, Location.Center);
                
                // index is 1-based
                // Return feedback that parameter has focus
                // Change and confirm selected parameter value
                IList<ListItem> comboBoxList = Host.Local.Find<ListItem>(ApplicationPaths.StrApplAreaComboBoxList, DefaultValues.iTimeoutDefault);
                int indexOfSelectedItem = 0;
                foreach (var item in comboBoxList)
                {
                    if (item.Selected)
                    {
                        indexOfSelectedItem = item.Index + 1;
                        break;
                    }
                }

                if (indexToSelect < indexOfSelectedItem)
                {
                    int difference = indexOfSelectedItem - indexToSelect;
                    for (int counter = 1; counter <= difference; counter++)
                    {
                        Keyboard.Press(Keys.Up);
                    }
                }
                else if (indexToSelect > indexOfSelectedItem)
                {
                    int difference = indexToSelect - indexOfSelectedItem;
                    for (int counter = 1; counter <= difference; counter++)
                    {
                        Keyboard.Press(Keys.Down);
                    }
                }

                if (confirm)
                {
                    string statusElementControlName = this.GetParameterState(element);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter is in state: " + statusElementControlName);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Confirming changed value.");
                    Keyboard.Press(Keys.Enter);
                    string controlName = element.Element.GetAttributeValueText("ControlName");
                    if (controlName == null)
                    {
                        return false;
                    }
                }
                else
                {
                    Keyboard.Press(Keys.Escape);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Value changed but not confirmed. Changing aborted by pressing Escape.");
                }

                return this.WaitForParameterStatusUpdate(element);
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
        
        /// <summary>
        /// The get parameter state.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <remarks>
        /// last edit: EC - 2017-02-13 - performance optimization
        /// </remarks>
        private string GetParameterState(Unknown element)
        {            
            string status = string.Empty;
            
            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameterState failed. Element is null.");
            }
            else
            {
                string statusElementControlName = element.Element.GetAttributeValueText("ControlName");
                if (statusElementControlName != null)
                {
                    statusElementControlName = statusElementControlName.Replace("Editor", "StatusIcon");
                    Unknown statusElement = this.GetStatusElement(statusElementControlName);
                    if (statusElement != null)
                    {
                        status = statusElement.Element.GetAttributeValueText("AccessibleDescription");
                        if (status == null)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No status found");
                            status = string.Empty;
                        }
                    }
                }    
            }
            
            return status;
        }

        /// <summary>
        /// The wait for parameter status update.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <remarks>
        /// last edit: EC - 2017-02-13 - performance optimization
        /// </remarks>
        private bool WaitForParameterStatusUpdate(Unknown element)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            bool waitForUpdate = true;

            while (waitForUpdate)
            {
                string parameterState = this.GetParameterState(element);
                if (parameterState.Equals(ParameterState.Valid.ToString()))
                {
                    waitForUpdate = false;
                }

                if (parameterState.Equals(ParameterState.ModifiedWrong.ToString()))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter is invalid modified.");
                    return true;
                }

                if (parameterState.Equals(ParameterState.ModifiedInvalidFormat.ToString()))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter has an invalid format.");
                    return true;
                }

                if (parameterState.Equals(ParameterState.ModifiedOutOfRange.ToString()))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter is modified out of range.");
                    return true;
                }

                if (watch.ElapsedMilliseconds > DefaultValues.GeneralTimeout)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter is not updated after: >" + DefaultValues.GeneralTimeout + "Milliseconds.");
                    return false;
                }
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter is updated in time:"  + watch.ElapsedMilliseconds + "/" + DefaultValues.GeneralTimeout + "Milliseconds.");
            return true;
        }

        /// <summary>
        /// The set check box value.
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
        private bool SetCheckBoxValue(Unknown element, string inputValue, bool confirm)
        {
            if (inputValue.ToLower().Contains("true") || inputValue.ToLower().Contains("false"))
            {
                bool input = Convert.ToBoolean(inputValue.ToLower());
                bool doConfirmation = true;

                Unknown child = element.Children[0].Children[0].Children[0];
                Ranorex.CheckBox checkBox = child.Element;
                Mouse.Click(this.dtmDisplayArea, Location.Center);
                
                bool valueBefore = checkBox.Checked;
                if (input == valueBefore)
                {
                    doConfirmation = false;
                }

                if (checkBox.Checked == false)
                {
                    if (input)
                    {
                        checkBox.Check();
                    }
                }
                else
                {
                    if (input == false)
                    {
                        checkBox.Uncheck();
                    }
                }

                if (confirm)
                {
                    if (doConfirmation)
                    {
                        string statusElementControlName = this.GetParameterState(element);
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter is in state: " + statusElementControlName);
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Confirming changed value.");
                        Keyboard.Press(Keys.Enter);
                        string controlName = element.Element.GetAttributeValueText("ControlName");
                        if (controlName == null)
                        {
                            return false;
                        }    
                    }
                    else
                    {
                        Log.Warn(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Old and new value are equal. Old value: " + valueBefore.ToString().ToLower() + " New value: " + inputValue);
                    }
                }
                else
                {
                    Keyboard.Press(Keys.Escape);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Value changed but not confirmed. Changing aborted by pressing Escape.");
                }

                bool resultUpdate = this.WaitForParameterStatusUpdate(element);

                if (!resultUpdate)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occured while writing");
                }

                return resultUpdate;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Input value is not [true] of [false].");
            return false;
        }

        /// <summary>
        /// The set edit field value.
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
        private bool SetEditFieldValue(Unknown element, string inputValue, bool confirm)
        {
            try
            {
                string valueBefore = this.GetParameterValue(element);

                if (valueBefore == null)
                {
                    Log.Warn(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cannot read old Value. Only MaskedTextBox is visible.");
                }
                else
                {
                    if (valueBefore.Equals(inputValue))
                    {
                        Log.Warn(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Old and new value are equal. Old value: " + valueBefore + " New value: " + inputValue);
                    }    
                }

                // Mouse.DoubleClick(element, Location.CenterLeft);
                Mouse.DoubleClick(element, new Location(10, 10));
                Keyboard.Press(Keys.Delete, 0, 100);
                Keyboard.Press(inputValue);

                if (confirm)
                {
                    string statusElementControlName = this.GetParameterState(element);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter is in state: " + statusElementControlName);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Confirming changed value.");
                    Keyboard.Press(Keys.Enter);
                    string controlName = element.Element.GetAttributeValueText("ControlName");
                    if (controlName == null)
                    {
                        return false;
                    }
                }
                else
                {
                    Keyboard.Press(Keys.Escape);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Value changed but not confirmed. Changing aborted by pressing Escape.");
                }

                bool resultUpdate = this.WaitForParameterStatusUpdate(element);

                if (!resultUpdate)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occured while writing");
                }
                
                return resultUpdate;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The get status element.
        /// </summary>
        /// <param name="targetControlName">
        /// The target control name.
        /// </param>
        /// <returns>
        /// The <see cref="Unknown"/>.
        /// </returns>
        private Unknown GetStatusElement(string targetControlName)
        {
            Unknown target = null;
            foreach (var element in this.allElementsFromPage)
            {
                string controlName = element.Element.GetAttributeValueText("controlname");
                if (controlName != null)
                {
                    if (controlName.Equals(targetControlName))
                    {
                        Mouse.MoveTo(element);
                        target = element;
                        break;
                    }
                }
            }

            return target;
        }

        /// <summary>
        /// The get label element.
        /// </summary>
        /// <param name="targetControlName">
        /// The target control name.
        /// </param>
        /// <returns>
        /// The <see cref="Unknown"/>.
        /// </returns>
        private Unknown GetLabelElement(string targetControlName)
        {
            Unknown target = null;
            foreach (var element in this.allElementsFromPage)
            {
                string controlName = element.Element.GetAttributeValueText("controlname");
                if (controlName != null)
                {
                    if (controlName.Contains(targetControlName))
                    {
                        Mouse.MoveTo(element);
                        target = element;
                        break;
                    }
                }
            }

            return target;
        }

        #endregion

        /// <summary>
        /// The scroll application area.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        private void ScrollApplicationArea(Text text)
        {
            int textYPosition = text.ScreenRectangle.Y;
            int pageHeight = this.GetPageHeight();
            int scrollbarYPosition = this.Scrollbar.ScreenRectangle.Y;

            var watch = new Stopwatch();
            if (textYPosition > pageHeight && this.ButtonPageDown.ScreenRectangle.Height > 0)
            {
                watch.Start();
                while (textYPosition > pageHeight)
                {
                    if (watch.ElapsedMilliseconds > DefaultValues.iTimeoutModules)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Scrolling to parameter " + text + " not finished within 120000 ms. Ending search.");
                        break;
                    }

                    this.ButtonPageDown.Click();
                    textYPosition = text.ScreenRectangle.Y;
                }

                watch.Stop();
            }
            else if (textYPosition < scrollbarYPosition && this.ButtonLineUp.ScreenRectangle.Height > 0)
            {
                // Scroll up if necessary
                watch.Reset();
                watch.Start();
                while (textYPosition < scrollbarYPosition)
                {
                    if (watch.ElapsedMilliseconds > DefaultValues.iTimeoutModules)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Scrolling to parameter " + text + " not finished within 120000 ms. Ending search.");
                        break;
                    }

                    this.ButtonPageUp.Click();
                    textYPosition = text.ScreenRectangle.Y;
                }

                watch.Stop();
            }
        }

        /// <summary>
        /// The check application area parameter.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        private void CheckApplicationAreaParameter(Element element)
        {
            string controlName = element.GetAttributeValueText("ControlName");
            if (controlName != null)
            {
                if (controlName.Contains("StatusIcon_Variable_"))
                {
                    string accessibleDescription = element.GetAttributeValueText("AccessibleDescription");
                    if (accessibleDescription != null)
                    {
                        Mouse.MoveTo(element, Location.UpperLeft);

                        // "Insecure", "Invalid", "Valid", "Modified", "Dynamic1" or "Dynamic2"
                        switch (accessibleDescription)
                        {
                            case "Insecure":
                                {
                                    this.NumberOfParameterInsecure++;
                                    break;
                                }

                            case "Invalid":
                                {
                                    this.NumberOfParameterInvalid++;
                                    break;
                                }

                            case "Valid":
                                {
                                    this.NumberOfParameterValid++;
                                    break;
                                }

                            case "Modified":
                                {
                                    this.NumberOfParameterModified++;
                                    break;
                                }

                            case "Dynamic1":
                                {
                                    this.NumberOfParameterDynamic++;
                                    break;
                                }

                            case "Dynamic2":
                                {
                                    this.NumberOfParameterDynamic++;
                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The get scroll bar.
        /// </summary>
        private void GetScrollBar()
        {
            string controlType;
            string accessibleName;

            string eddMenuTabControl = "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMenuTabControl";
            string eddMenuTabPage = "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMenuTabPage";
            string eddMenuPanel = "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMenuPanel";
            string guiScrollableControl = "CodeWrights.Frameworks.GenericUI.Presentation.DxControls.Controls.GuiScrollableControl";
            string eddMenuPanel_ScrollContainer = "EddMenuPanel_ScrollContainer";
            string controlTypeAttribute = "controltype";
            string accessibleNameAttribute = "accessiblename";

            // get childs
            // check for CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMenuPanel (controltype)
            // get childs
            // check for CodeWrights.Frameworks.GenericUI.Presentation.DxControls.Controls.GuiScrollableControl (controltype)
            // get childs
            // check for EddMenuPanel_ScrollContainer    (accessiblename)
            IList<Unknown> eddMenuPanelCandidates = this.dtmDisplayArea.Children;
            for (int firstCounter = 0; firstCounter < eddMenuPanelCandidates.Count; firstCounter++)
            {
                controlType = eddMenuPanelCandidates[firstCounter].Element.GetAttributeValueText(controlTypeAttribute);
                if (controlType != null)
                {
                    if (controlType.Equals(eddMenuPanel))
                    {
                        IList<Unknown> guiScrollableControlCandidates = eddMenuPanelCandidates[firstCounter].Children;
                        for (int fourthCounter = 0; fourthCounter < guiScrollableControlCandidates.Count; fourthCounter++)
                        {
                            controlType = guiScrollableControlCandidates[fourthCounter].Element.GetAttributeValueText(controlTypeAttribute);
                            if (controlType != null)
                            {
                                if (controlType.Equals(guiScrollableControl))
                                {
                                    IList<Unknown> scrollContainerCandidate = guiScrollableControlCandidates[fourthCounter].Children;
                                    for (int fifthCounter = 0; fifthCounter < scrollContainerCandidate.Count; fifthCounter++)
                                    {
                                        accessibleName = scrollContainerCandidate[fifthCounter].Element.GetAttributeValueText(accessibleNameAttribute);
                                        if (accessibleName != null)
                                        {
                                            if (accessibleName.Equals(eddMenuPanel_ScrollContainer))
                                            {
                                                this.scrollBarContainer = scrollContainerCandidate[fifthCounter];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // get childs
            // check for CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMenuTabControl (controltype)
            // get childs
            // check for CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMenuTabPage (controltype)
            // get childs
            // check for CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddMenuPanel (controltype)
            // get childs
            // check for CodeWrights.Frameworks.GenericUI.Presentation.DxControls.Controls.GuiScrollableControl (controltype)
            // get childs
            // check for EddMenuPanel_ScrollContainer    (accessiblename)
            IList<Unknown> eddMenuTabControlCandidate = this.dtmDisplayArea.Children;
            for (int firstCounter = 0; firstCounter < eddMenuTabControlCandidate.Count; firstCounter++)
            {
                controlType = eddMenuTabControlCandidate[firstCounter].Element.GetAttributeValueText(controlTypeAttribute);
                if (controlType != null)
                {
                    if (controlType.Equals(eddMenuTabControl))
                    {
                        IList<Unknown> eddMenuTabPageCandidates = eddMenuTabControlCandidate[firstCounter].Children;
                        for (int secondCounter = 0; secondCounter < eddMenuTabPageCandidates.Count; secondCounter++)
                        {
                            controlType = eddMenuTabPageCandidates[secondCounter].Element.GetAttributeValueText(controlTypeAttribute);
                            if (controlType != null)
                            {
                                if (controlType.Equals(eddMenuTabPage))
                                {
                                    eddMenuPanelCandidates = eddMenuTabPageCandidates[secondCounter].Children;
                                    for (int thirdCounter = 0; thirdCounter < eddMenuPanelCandidates.Count; thirdCounter++)
                                    {
                                        controlType = eddMenuPanelCandidates[thirdCounter].Element.GetAttributeValueText(controlTypeAttribute);
                                        if (controlType != null)
                                        {
                                            if (controlType.Equals(eddMenuPanel))
                                            {
                                                IList<Unknown> guiScrollableControlCandidates = eddMenuPanelCandidates[thirdCounter].Children;
                                                for (int fourthCounter = 0; fourthCounter < guiScrollableControlCandidates.Count; fourthCounter++)
                                                {
                                                    controlType = guiScrollableControlCandidates[fourthCounter].Element.GetAttributeValueText(controlTypeAttribute);
                                                    if (controlType != null)
                                                    {
                                                        if (controlType.Equals(guiScrollableControl))
                                                        {
                                                            IList<Unknown> scrollContainerCandidate = guiScrollableControlCandidates[fourthCounter].Children;
                                                            for (int fifthCounter = 0; fifthCounter < scrollContainerCandidate.Count; fifthCounter++)
                                                            {
                                                                accessibleName = scrollContainerCandidate[fifthCounter].Element.GetAttributeValueText(accessibleNameAttribute);
                                                                if (accessibleName != null)
                                                                {
                                                                    if (accessibleName.Equals(eddMenuPanel_ScrollContainer))
                                                                    {
                                                                        this.scrollBarContainer = scrollContainerCandidate[fifthCounter];
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The is index for parameter available.
        /// </summary>
        /// <param name="pathPart">
        /// The path part.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsIndexForParameterAvailable(string pathPart)
        {
            if (pathPart.Contains("[") && pathPart.Contains("]"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The get and remove index from path: device//menu//submenu//[index]parameter
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to parameter.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetAndRemoveIndexFromPath(ref string pathToParameter)
        {
            string[] separatorPathParts = { "//" };
            string[] pathParts = pathToParameter.Split(separatorPathParts, StringSplitOptions.None);

            // Parameter name is last part of string, including "[index]"
            string parameterName = pathParts[pathParts.Length - 1];

            // Define seperator
            string[] separatorParameterNameParts = { "[", "]" };

            // Split parameter name to separate index from name
            string[] parameterNameParts = parameterName.Split(separatorParameterNameParts, StringSplitOptions.None);

            // Get parameter index from string
            int parameterIndex = Convert.ToInt32(parameterNameParts[parameterNameParts.Length - 2]);

            // index is removed from parameter name
            parameterName = parameterNameParts[parameterNameParts.Length - 1];

            // Parameter without index is assigned to path to parameter
            pathParts[pathParts.Length - 1] = parameterName;

            // Parts are joined together without index
            const string SeparateWith = "//";
            pathToParameter = string.Join(SeparateWith, pathParts);

            return parameterIndex;
        }

        /// <summary>
        /// The is input value an index.
        /// </summary>
        /// <param name="inputValue">
        /// The input value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsInputValueAnIndex(string inputValue)
        {
            if (inputValue.Contains("[") && inputValue.Contains("]"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The get index from input value.
        /// </summary>
        /// <param name="inputValue">
        /// The input value.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetIndexFromInputValue(string inputValue)
        {
            try
            {
                string valueAsString = inputValue.Replace("[", string.Empty);
                valueAsString = valueAsString.Replace("]", string.Empty);

                int valueAsInteger = Convert.ToInt32(valueAsString);
                return valueAsInteger;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return -1;
            } 
        }
    }
}