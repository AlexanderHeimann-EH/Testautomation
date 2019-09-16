// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetSettingsParameterStateFast.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class GetSettingsParameterStateFast.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
 
    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Class GetSettingsParameterStateFast.
    /// </summary>
    public class GetSettingsParameterStateFast
    {
        #region Public Methods and Operators

        /// <summary>
        /// GetParameterStateFast returns a information-set of a specified parameter
        /// </summary>
        /// <param name="parameterName">
        /// Name of parameter
        /// </param>
        /// <returns>
        /// Parameter-object containing the state of the parameter
        /// </returns>
        public Parameter Run(string parameterName)
        {
            try
            {
                var parameter = new Parameter(parameterName);
                Element cachedContainer;
                string guiHelpString = CommonFlows.GetDtmContainerPath.Run();
                const string ContainerPath = @"/container[@controlname='DtmFormBase']/container[@controlname='linearizationFormSplitter']/container[@controlname='panel2']/?/?/container[@controlname='tabPageSettingsRef']/container[@controlname='SettingsPageGeneralContainerViewModel|GeneralGroupSettingsPageViewModel']/element[@controlname='ControlContainer']";
                string completePath = guiHelpString + ContainerPath;

                // Time Optimization
                var watch = new Stopwatch();

                Host.Local.TryFindSingle(completePath, DefaultValues.iTimeoutDefault, out cachedContainer);
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
        private string GetControlname(string parameterName, Element cachedContainer)
        {
            try
            {
                string controlName = string.Empty;
                const string ParameterLabel = "descendant::element[@controlname~'Label']/text";

                IList<Element> parameterLabelList = cachedContainer.Find(ParameterLabel);
                foreach (Element label in parameterLabelList)
                {
                    if (string.CompareOrdinal(label.GetAttributeValueText("Text"), parameterName) != 0)
                    {
                        continue;
                    }

                    var control = new Control(label);
                    controlName = control.Name;
                    break;
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
        private ParameterState GetParameterState(string controlName, Element cachedContainer)
        {
            try
            {
                Element element;
                const string ParameterStatePath = "descendant::element[@controlname='CONTROLNAME']";
                controlName = controlName.Replace("Label", "StatusIcon");

                string search = ParameterStatePath.Replace("CONTROLNAME", controlName);

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

        #endregion
    }
}