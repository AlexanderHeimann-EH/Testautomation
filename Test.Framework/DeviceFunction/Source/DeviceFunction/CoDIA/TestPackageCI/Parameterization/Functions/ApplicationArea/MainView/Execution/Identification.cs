// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Identification.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 23.03.2011
 * Time: 13:15 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Identification provides functionality to get information about displayed parameters.
    /// </summary>
    public class Identification : MarshalByRefObject, IIdentification
    {
        /// <summary>
        /// GetParameter returns a information-set of a specified parameter
        /// </summary>
        /// <param name="parameterName">Name of parameter</param>
        /// <returns>Parameter-object containing a set of parameter information</returns>
        public Parameter GetHeaderParameter(string parameterName)
        {
            try
            {
                var parameter = new Parameter(parameterName);
                string controlName = this.GetControlName(parameterName);
                parameter.ParameterType = ParameterType.Text;
                parameter.ParameterState = this.GetParameterState(controlName);
                parameter.ParameterValue = this.GetParameterValue(controlName);
                parameter.ParameterUnit = this.GetParameterUnit(controlName);
                return parameter;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Get list of header parameters
        /// </summary>
        /// <returns><br>List of parameter: if call worked fine</br>
        /// <br>Null: if an error occurred</br></returns>
        public List<Parameter> GetHeaderParameters()
        {
            try
            {
                List<string> controlNameList = IdentificationElements.GetHeaderParameterControlNames();
                if (controlNameList.Count > 0)
                {
                    var parameterList = new List<Parameter>();
                    foreach (string controlName in controlNameList)
                    {
                        var parameter = new Parameter(string.Empty)
                            {
                                ParameterName = this.GetParameterName(controlName),
                                ParameterType = ParameterType.Text,
                                ParameterState = this.GetParameterState(controlName),
                                ParameterValue = this.GetParameterValue(controlName),
                                ParameterUnit = this.GetParameterUnit(controlName)
                            };

                        // System.Diagnostics.Debug.Print("ControlName: " + controlName.ToString());
                        parameterList.Add(parameter);
                    }

                    return parameterList;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No parameter in Header found.");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Check if a specified parameter has a specific state
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <param name="expectedState">Expected state</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool CheckParameterForState(string parameterName, string expectedState)
        {
            try
            {
                string parameterState = this.GetHeaderParameter(parameterName).ParameterState.ToString();

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
        /// Get a parameter's name at identification area
        /// </summary>
        /// <param name="controlName">Specified Parameter</param>
        /// <returns>String: parameter unit</returns>
        private string GetParameterName(string controlName)
        {
            try
            {
                Text text;
                string search = IdentificationPaths.StrIdenAreaParameterLabel.Replace("CONTROLNAME", controlName);
                if (Host.Local.TryFindSingle(search, DefaultValues.iTimeoutDefault, out text))
                {
                    Mouse.MoveTo(text);
                    return text.TextValue;
                }

                return "-";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return "-";
            }
        }

        /// <summary>
        /// Get a parameter's value at identification area
        /// </summary>
        /// <param name="controlName">Specified Parameter</param>
        /// <returns>String: parameter unit</returns>
        private string GetParameterValue(string controlName)
        {
            try
            {
                Text text;
                controlName = controlName.Replace("Label", "Editor");
                string search = IdentificationPaths.StrIdenAreaParameterValue.Replace("CONTROLNAME", controlName);
                if (Host.Local.TryFindSingle(search, DefaultValues.iTimeoutDefault, out text))
                {
                    Mouse.MoveTo(text);
                    return text.TextValue;
                }

                return "-";
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return "-";
            }
        }

        /// <summary>
        /// Get a parameter's unit at identification area
        /// </summary>
        /// <param name="controlName">Specified Parameter</param>
        /// <returns>String: parameter unit</returns>
        private string GetParameterUnit(string controlName)
        {
            try
            {
                Text text;
                controlName = controlName.Replace("Label", "Unit");
                string search = IdentificationPaths.StrIdenAreaParameterUnit.Replace("CONTROLNAME", controlName);
                if (Host.Local.TryFindSingle(search, DefaultValues.iTimeoutDefault, out text))
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
        ///     Get parameter's state
        /// </summary>
        /// <param name="controlName">internal control name</param>
        /// <returns>Enumeration: Parameter State</returns>
        private ParameterState GetParameterState(string controlName)
        {
            try
            {
                Element element;
                controlName = controlName.Replace("Label", "StatusIcon");
                string search = IdentificationPaths.StrIdenAreaParameterState.Replace("CONTROLNAME", controlName);
                if (Host.Local.TryFindSingle(search, DefaultValues.iTimeoutDefault, out element))
                {
                    Mouse.MoveTo(element);
                    return this.GetIconState(element);
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
        /// Gets the state of the icon.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>Parameter State</returns>
        private ParameterState GetIconState(Element element)
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
            catch (RanorexException)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to capture image");
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
        /// Get control name of parameter's label at application area
        /// </summary>
        /// <param name="parameterName">Searched Parameter</param>
        /// <returns>String: internal control name</returns>
        private string GetControlName(string parameterName)
        {
            try
            {
                string controlName = string.Empty;
                string buffer = IdentificationPaths.StrIdenAreaParameterLabel.Replace("CONTROLNAME", parameterName);
                IList<Text> labelList = Host.Local.Find<Text>(buffer, DefaultValues.GeneralTimeout);

                foreach (Text text in labelList)
                {
                    if (string.CompareOrdinal(text.TextValue, parameterName) != 0)
                    {
                        continue;
                    }

                    string newPath = text.GetPath() + "/../";
                    Element element;
                    Host.Local.TryFindSingle(newPath, DefaultValues.iTimeoutDefault, out element);
                    if (element != null)
                    {
                        Mouse.MoveTo(element);
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
    }
}