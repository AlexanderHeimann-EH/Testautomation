//------------------------------------------------------------------------------
// <copyright file="ParameterStates.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Historom.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.Historom.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Description of ParameterStates.
    /// </summary>
    public class ParameterStates : IParameterStates
    {
        /// <summary>
        ///     Waits for parameter update after writing
        /// </summary>
        /// <param name="control">control which contains the status icon for the parameter which has been modified</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool WaitForParameterUpdate(Element control)
        {
            bool result = true;
            var watch = new Stopwatch();
            watch.Start();

            // Wait until updated
            while (this.WaitUntilParameterIsWritten(control))
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
        /// <param name="control">
        /// The control.
        /// </param>
        /// <returns>
        /// True, if parameter is not written
        /// </returns>
        private bool WaitUntilParameterIsWritten(Element control)
        {
            return this.CheckForParameterState(control, ParameterState.Valid.ToString());
        }

        /// <summary>
        ///     Check if a specified parameter has a specific state
        /// </summary>
        /// <param name="control">internal control name</param>
        /// <param name="expectedState">State to check parameter for</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        private bool CheckForParameterState(Element control, string expectedState)
        {
            try
            {
                string parameterState = this.GetParameterState(control).ToString();

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
        ///     Get parameter's state
        /// </summary>
        /// <param name="control">internal control name</param>
        /// <returns>Enumeration: Parameter State</returns>
        private ParameterState GetParameterState(Element control)
        {
            try
            {
                Element element = control;

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
        /// Gets the state.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>Parameter State</returns>
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
    }
}