// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DashboardFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for the Dashboard control
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Provides methods for the Dashboard control
    /// </summary>
    public class DashboardFunctions : IDashboardFunctions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Takes the screenshots within interval.Please make sure that dashboard is visible.
        /// </summary>
        /// <param name="intervalInMilliseconds">The interval in milliseconds.</param>
        /// <param name="numberOfScreenshots">The number of screenshots.</param>
        public void TakeScreenshotsWithinInterval(int intervalInMilliseconds, int numberOfScreenshots)
        {
            var watch = new Stopwatch();
            new TakeScreenshotOfModule().OnlineParameterization();            
            for (int i = 1; i < numberOfScreenshots; i++)
            {
                watch.Start();
                while (watch.IsRunning)
                {
                    if (watch.ElapsedMilliseconds >= intervalInMilliseconds)
                    {
                        new TakeScreenshotOfModule().OnlineParameterization();
                        watch.Stop();
                    }
                }                

                watch.Reset();
            }
        }

        /// <summary>
        /// Compares a dashboard value to header.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="headerParameterName">
        /// The name of header parameter to compare.
        /// </param>
        /// <param name="accuracy">
        /// The maximum allowed difference between the two values.
        /// </param>
        /// <returns>
        /// <c>true</c> if values are equal, <c>false</c> otherwise.
        /// </returns>
        public bool CompareDashboardValueToHeaderParameter(string nameOfDashboardValueToCompare, string headerParameterName, double accuracy)
        {
            try
            {
                bool result = false;

                string dashboardValue = this.GetDashboardValueByName(nameOfDashboardValueToCompare);
                Parameter headerParameter = new Identification().GetHeaderParameter(headerParameterName);
                string headerValue = headerParameter.ParameterValue;

                if (dashboardValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the dashboard value " + nameOfDashboardValueToCompare + ". Is the name correct?");
                }
                else if (headerValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the header parameter" + headerParameterName + ". Is the name correct?");
                }
                else
                {
                    decimal decimal1;
                    decimal decimal2;
                    if (decimal.TryParse(dashboardValue, out decimal1) && decimal.TryParse(headerValue, out decimal2))
                    {
                        var dashboardValueAsDouble = Convert.ToDouble(dashboardValue);
                        var headerValueAsDouble = Convert.ToDouble(headerValue);
                        if (Math.Abs(dashboardValueAsDouble - headerValueAsDouble) > accuracy)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Header parameter value for " + headerParameterName + " = " + headerValueAsDouble);
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Header parameter value for " + headerParameterName + " = " + headerValueAsDouble);
                            result = true;
                        }
                    }
                    else if (dashboardValue == headerValue)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Header parameter value for " + headerParameterName + " = " + headerValue);
                        result = true;
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Header parameter value for " + headerParameterName + " = " + headerValue);
                    }
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
        /// Compares a dashboard value to a parameter from the parameterization.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="pathToParameter">
        /// The name and path of parameter to compare. Like Micropilot 5x//Setup//Device tag:.
        /// </param>
        /// <param name="accuracy">
        /// The maximum allowed difference between the two values.
        /// </param>
        /// <returns>
        /// <c>true</c> if values are equal, <c>false</c> otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool CompareDashboardValueToParameter(string nameOfDashboardValueToCompare, string pathToParameter, double accuracy)
        {
            try
            {
                bool result = false;

                string dashboardValue = this.GetDashboardValueByName(nameOfDashboardValueToCompare);
                string parameterValue = new GetParameterValue().Run(pathToParameter);

                if (dashboardValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the dashboard value " + nameOfDashboardValueToCompare + ". Is the name correct?");
                }
                else if (parameterValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the parameter" + pathToParameter + ". Is the name correct?");
                }
                else
                {
                    decimal decimal1;
                    decimal decimal2;
                    if (decimal.TryParse(dashboardValue, out decimal1) && decimal.TryParse(parameterValue, out decimal2))
                    {
                        var dashboardValueAsDouble = Convert.ToDouble(dashboardValue);
                        var parameterValueAsDouble = Convert.ToDouble(parameterValue);
                        if (Math.Abs(dashboardValueAsDouble - parameterValueAsDouble) > accuracy)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Parameter value for " + pathToParameter + " = " + parameterValueAsDouble);
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Parameter value for " + pathToParameter + " = " + parameterValueAsDouble);
                            result = true;
                        }
                    }
                    else if (dashboardValue == parameterValue)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Parameter value for " + pathToParameter + " = " + parameterValue);
                        result = true;
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Parameter value for " + pathToParameter + " = " + parameterValue);
                    }
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
        /// Compares a extended dashboard extended value to header.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="headerParameterName">
        /// The name of header parameter to compare.
        /// </param>
        /// <param name="accuracy">
        /// The maximum allowed difference between the two values.
        /// </param>
        /// <returns>
        /// <c>true</c> if values are equal, <c>false</c> otherwise.
        /// </returns>
        public bool CompareExtendedDashboardExtendedValueToHeaderParameter(string nameOfDashboardValueToCompare, string headerParameterName, double accuracy)
        {
            try
            {
                bool result = false;

                string dashboardValue = this.GetExtendedDashboardExtendedValueByName(nameOfDashboardValueToCompare);
                Parameter headerParameter = new Identification().GetHeaderParameter(headerParameterName);
                string headerValue = headerParameter.ParameterValue;

                if (dashboardValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the dashboard value " + nameOfDashboardValueToCompare + ". Is the name correct?");
                }
                else if (headerValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the header parameter" + headerParameterName + ". Is the name correct?");
                }
                else
                {
                    decimal decimal1;
                    decimal decimal2;
                    if (decimal.TryParse(dashboardValue, out decimal1) && decimal.TryParse(headerValue, out decimal2))
                    {
                        var dashboardValueAsDouble = Convert.ToDouble(dashboardValue);
                        var headerValueAsDouble = Convert.ToDouble(headerValue);
                        if (Math.Abs(dashboardValueAsDouble - headerValueAsDouble) > accuracy)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Header parameter value for " + headerParameterName + " = " + headerValueAsDouble);
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Header parameter value for " + headerParameterName + " = " + headerValueAsDouble);
                            result = true;
                        }
                    }
                    else if (dashboardValue == headerValue)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Header parameter value for " + headerParameterName + " = " + headerValue);
                        result = true;
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Header parameter value for " + headerParameterName + " = " + headerValue);
                    }
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
        /// Compares a extended dashboard extended value to parameter of parameterization.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="pathToParameter">
        /// The path To Parameter.
        /// </param>
        /// <param name="accuracy">
        /// The maximum allowed difference between the two values.
        /// </param>
        /// <returns>
        /// <c>true</c> if values are equal, <c>false</c> otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool CompareExtendedDashboardExtendedValueToParameter(string nameOfDashboardValueToCompare, string pathToParameter, double accuracy)
        {
            try
            {
                bool result = false;

                string dashboardValue = this.GetExtendedDashboardExtendedValueByName(nameOfDashboardValueToCompare);
                string parameterValue = new GetParameterValue().Run(pathToParameter);

                if (dashboardValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the dashboard value " + nameOfDashboardValueToCompare + ". Is the name correct?");
                }
                else if (parameterValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the parameter" + pathToParameter + ". Is the name correct?");
                }
                else
                {
                    decimal decimal1;
                    decimal decimal2;
                    if (decimal.TryParse(dashboardValue, out decimal1) && decimal.TryParse(parameterValue, out decimal2))
                    {
                        var dashboardValueAsDouble = Convert.ToDouble(dashboardValue);
                        var parameterValueAsDouble = Convert.ToDouble(parameterValue);
                        if (Math.Abs(dashboardValueAsDouble - parameterValueAsDouble) > accuracy)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Parameter value for " + pathToParameter + " = " + parameterValueAsDouble);
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Parameter value for " + pathToParameter + " = " + parameterValueAsDouble);
                            result = true;
                        }
                    }
                    else if (dashboardValue == parameterValue)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Parameter value for " + pathToParameter + " = " + parameterValue);
                        result = true;
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Parameter value for " + pathToParameter + " = " + parameterValue);
                    }
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
        /// Compares the extended dashboard main value to header.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="headerParameterName">
        /// The name of header parameter to compare.
        /// </param>
        /// <param name="accuracy">
        /// The maximum allowed difference between the two values.
        /// </param>
        /// <returns>
        /// <c>true</c> if values are equal, <c>false</c> otherwise.
        /// </returns>
        public bool CompareExtendedDashboardMainValueToHeaderParameter(string nameOfDashboardValueToCompare, string headerParameterName, double accuracy)
        {
            try
            {
                bool result = false;

                string dashboardValue = this.GetExtendedDashboardMainValueByName(nameOfDashboardValueToCompare);
                Parameter headerParameter = new Identification().GetHeaderParameter(headerParameterName);
                string headerValue = headerParameter.ParameterValue;

                if (dashboardValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the dashboard value " + nameOfDashboardValueToCompare + ". Is the name correct?");
                }
                else if (headerValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the header parameter" + headerParameterName + ". Is the name correct?");
                }
                else
                {
                    decimal decimal1;
                    decimal decimal2;
                    if (decimal.TryParse(dashboardValue, out decimal1) && decimal.TryParse(headerValue, out decimal2))
                    {
                        var dashboardValueAsDouble = Convert.ToDouble(dashboardValue);
                        var headerValueAsDouble = Convert.ToDouble(headerValue);
                        if (Math.Abs(dashboardValueAsDouble - headerValueAsDouble) > accuracy)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Header parameter value for " + headerParameterName + " = " + headerValueAsDouble);
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Header parameter value for " + headerParameterName + " = " + headerValueAsDouble);
                            result = true;
                        }
                    }
                    else if (dashboardValue == headerValue)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Header parameter value for " + headerParameterName + " = " + headerValue);
                        result = true;
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Header parameter value for " + headerParameterName + " = " + headerValue);
                    }
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
        /// Compares the extended dashboard main value to a parameter.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="pathToParameter">
        /// The name and path of parameter to compare. Like Micropilot 5x//Setup//Device tag:.
        /// </param>
        /// <param name="accuracy">
        /// The maximum allowed difference between the two values.
        /// </param>
        /// <returns>
        /// <c>true</c> if values are equal, <c>false</c> otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool CompareExtendedDashboardMainValueToParameter(string nameOfDashboardValueToCompare, string pathToParameter, double accuracy)
        {
            try
            {
                bool result = false;

                string dashboardValue = this.GetExtendedDashboardMainValueByName(nameOfDashboardValueToCompare);
                string parameterValue = new GetParameterValue().Run(pathToParameter);

                if (dashboardValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the dashboard value " + nameOfDashboardValueToCompare + ". Is the name correct?");
                }
                else if (parameterValue == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the value for the parameter" + pathToParameter + ". Is the name correct?");
                }
                else
                {
                    decimal decimal1;
                    decimal decimal2;
                    if (decimal.TryParse(dashboardValue, out decimal1) && decimal.TryParse(parameterValue, out decimal2))
                    {
                        var dashboardValueAsDouble = Convert.ToDouble(dashboardValue);
                        var parameterValueAsDouble = Convert.ToDouble(parameterValue);
                        if (Math.Abs(dashboardValueAsDouble - parameterValueAsDouble) > accuracy)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Parameter value for " + pathToParameter + " = " + parameterValueAsDouble);
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValueAsDouble + ". Parameter value for " + pathToParameter + " = " + parameterValueAsDouble);
                            result = true;
                        }
                    }
                    else if (dashboardValue == parameterValue)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Parameter value for " + pathToParameter + " = " + parameterValue);
                        result = true;
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different: Dashboard value for " + nameOfDashboardValueToCompare + " = " + dashboardValue + ". Parameter value for " + pathToParameter + " = " + parameterValue);
                    }
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
        /// Gets the value of a dashboard process variable. Use names displayed in the dashboard.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// Current value of process variable.
        /// </returns>
        public string GetDashboardValueByName(string name)
        {
            string result = string.Empty;
            var list = this.StoreAllDashboardValues();
            foreach (var element in list)
            {
                if (this.ProcessVariableLabel(element) == name)
                {
                    result = this.ProcessVariable(element);
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the value of a dashboard process variable unit. Use names displayed in the dashboard.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// Current value of process variable.
        /// </returns>
        public string GetDashboardValueUnitByName(string name)
        {
            string result = string.Empty;
            var list = this.StoreAllDashboardValues();
            foreach (var element in list)
            {
                if (this.ProcessVariableLabel(element) == name)
                {
                    result = this.ProcessVariableUnit(element);
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the value of the extended dashboard extended process variable. Use names displayed in the dashboard.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// Current value of process variable.
        /// </returns>
        public string GetExtendedDashboardExtendedValueByName(string name)
        {
            string result = string.Empty;
            var list = this.StoreAllExtendedDashboardExtendedValues();
            foreach (var element in list)
            {
                if (this.ProcessVariableLabel(element) == name)
                {
                    result = this.ProcessVariable(element);
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the value of the extended dashboard extended process variable unit. Use names displayed in the dashboard.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// Current value of process variable.
        /// </returns>
        public string GetExtendedDashboardExtendedValueUnitByName(string name)
        {
            string result = string.Empty;
            var list = this.StoreAllExtendedDashboardExtendedValues();
            foreach (var element in list)
            {
                if (this.ProcessVariableLabel(element) == name)
                {
                    result = this.ProcessVariableUnit(element);
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the value of the extended dashboard main process variable. Use names displayed in the dashboard.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// Current value of process variable.
        /// </returns>
        public string GetExtendedDashboardMainValueByName(string name)
        {
            string result = string.Empty;
            var list = this.StoreAllExtendedDashboardMainValues();
            foreach (var element in list)
            {
                if (this.ProcessVariableLabel(element) == name)
                {
                    result = this.ProcessVariable(element);
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the value of the extended dashboard main process variable unit. Use names displayed in the dashboard.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// Current value of process variable.
        /// </returns>
        public string GetExtendedDashboardMainValueUnitByName(string name)
        {
            string result = string.Empty;
            var list = this.StoreAllExtendedDashboardMainValues();
            foreach (var element in list)
            {
                if (this.ProcessVariableLabel(element) == name)
                {
                    result = this.ProcessVariableUnit(element);
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Checks whether the Dashboard is available or not using the the main Dashboard control.
        /// </summary>
        /// <returns>
        /// true: if the module is available
        /// false: if module is not available
        /// </returns>
        public bool IsDashboardAvailable()
        {
            bool result = true;
            Element container = new DashboardElements().MainDashboardContainer;
            if (container == null)
            {
                result = false;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The main Dashboard container is not found. Dashboard Module is not available");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The main Dashboard container is found. Dashboard Module is available");
            }

            return result;
        }

        /// <summary>
        /// Opens the dashboard via home button. Verifies whether dashboard is open.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
        public bool OpenDashboard(int timeoutInMilliseconds)
        {
            try
            {
                bool result = true;

                Button home = new DashboardElements().HomeButton;

                if (home == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The Home Button is null.");
                    result = false;
                }
                else
                {
                    Mouse.MoveTo(home);
                    home.Click();

                    var watch = new Stopwatch();
                    watch.Start();
                    while (this.IsDashboardAvailable() == false)
                    {
                        if (watch.ElapsedMilliseconds > timeoutInMilliseconds)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opening Dashboard timed out after -> " + timeoutInMilliseconds + "ms.");

                            result = false;
                            break;
                        }
                    }

                    watch.Stop();
                }

                if (result)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dashboard open and ready.");
                }

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the process variable of a Dashboard container using its FirstLineText attribute
        /// </summary>
        /// <param name="container">
        /// The container from the Dashboard repository
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ProcessVariable(Element container)
        {
            string result = string.Empty;

            if (container == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element used is null");
            }
            else
            {
                if (container.GetAttributeValueText("FirstLineText") == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The FirstLineText attribute is not available");
                }
                else
                {
                    result = container.GetAttributeValueText("FirstLineText");
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the label of the Process Variable of a Dashboard container using its ThirdLineText attribute
        /// </summary>
        /// <param name="container">
        /// The container from the Dashboard repository
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ProcessVariableLabel(Element container)
        {
            string result = string.Empty;

            if (container == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element used is null");
            }
            else
            {
                if (container.GetAttributeValueText("ThirdLineText") == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The ThirdLineText attribute is not available");
                }
                else
                {
                    result = container.GetAttributeValueText("ThirdLineText");
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the unit of the Process Variable of a Dashboard container using its SecondLineText attribute
        /// </summary>
        /// <param name="container">
        /// The container from the Dashboard repository
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ProcessVariableUnit(Element container)
        {
            string result = string.Empty;

            if (container == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element used is null");
            }
            else
            {
                if (container.GetAttributeValueText("SecondLineText") == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The SecondLineText attribute is not available");
                }
                else
                {
                    result = container.GetAttributeValueText("SecondLineText");
                }
            }

            return result;
        }

        /// <summary>
        /// Selects the tab within the extended Dashboard control
        /// </summary>
        /// <param name="index">
        /// The tab index which will be selected. Main values = 0 , extended values = 1.
        /// </param>
        /// <returns>
        /// true: if tab selected successfully; false: if an error occurred
        /// </returns>
        public bool SelectTab(int index)
        {
            bool result = true;
            Element tabControl = (new DashboardElements()).TabControlDashboard;
            if ((index >= 0) && (tabControl != null))
            {
                tabControl.SetAttributeValue("selectedtabpageindex", index);
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Selected tab with index " + index);
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Index out of bounds or tab control == null");
                result = false;
            }

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Stores all dashboard values(container) in a list
        /// </summary>
        /// <returns>List with value container.</returns>
        private List<Element> StoreAllDashboardValues()
        {
            var result = new List<Element>();

            Element container = new DashboardElements().DashboardAlternateMeasuredValueMainLabel;
            if (container != null)
            {
                result.Add(container);
            }

            Element container1 = new DashboardElements().DashboardAlternateMeasuredValueLabel1;
            if (container1 != null)
            {
                result.Add(container1);
            }

            Element container2 = new DashboardElements().DashboardAlternateMeasuredValueLabel2;
            if (container2 != null)
            {
                result.Add(container2);
            }

            Element container3 = new DashboardElements().DashboardAlternateMeasuredValueLabel3;
            if (container3 != null)
            {
                result.Add(container3);
            }

            Element container4 = new DashboardElements().DashboardAlternateMeasuredValueLabel4;
            if (container4 != null)
            {
                result.Add(container4);
            }

            return result;
        }

        /// <summary>
        /// Stores all extended dashboard values(container) in a list
        /// </summary>
        /// <returns>List with value container.</returns>
        private List<Element> StoreAllExtendedDashboardExtendedValues()
        {
            var result = new List<Element>();

            Element container = new DashboardElements().ExtendedDashboardExtendedMeasuredValueLabel1;
            if (container != null)
            {
                result.Add(container);
            }

            Element container1 = new DashboardElements().ExtendedDashboardExtendedMeasuredValueLabel2;
            if (container1 != null)
            {
                result.Add(container1);
            }

            Element container2 = new DashboardElements().ExtendedDashboardExtendedMeasuredValueLabel3;
            if (container2 != null)
            {
                result.Add(container2);
            }

            Element container3 = new DashboardElements().ExtendedDashboardExtendedMeasuredValueLabel4;
            if (container3 != null)
            {
                result.Add(container3);
            }

            Element container4 = new DashboardElements().ExtendedDashboardExtendedMeasuredValueLabel5;
            if (container4 != null)
            {
                result.Add(container4);
            }

            Element container5 = new DashboardElements().ExtendedDashboardExtendedMeasuredValueLabel6;
            if (container5 != null)
            {
                result.Add(container5);
            }

            Element container6 = new DashboardElements().ExtendedDashboardExtendedMeasuredValueLabel7;
            if (container6 != null)
            {
                result.Add(container6);
            }

            Element container7 = new DashboardElements().ExtendedDashboardExtendedMeasuredValueLabel8;
            if (container7 != null)
            {
                result.Add(container7);
            }

            return result;
        }

        /// <summary>
        /// Stores all extended dashboard values(container) in a list
        /// </summary>
        /// <returns>List with value container.</returns>
        private List<Element> StoreAllExtendedDashboardMainValues()
        {
            var result = new List<Element>();

            Element container = new DashboardElements().ExtendedDashboardAlternateMeasuredValueMainLabel;
            if (container != null)
            {
                result.Add(container);
            }

            Element container1 = new DashboardElements().ExtendedDashboardAlternateMeasuredValueLabel1;
            if (container1 != null)
            {
                result.Add(container1);
            }

            Element container2 = new DashboardElements().ExtendedDashboardAlternateMeasuredValueLabel2;
            if (container2 != null)
            {
                result.Add(container2);
            }

            Element container3 = new DashboardElements().ExtendedDashboardAlternateMeasuredValueLabel3;
            if (container3 != null)
            {
                result.Add(container3);
            }

            Element container4 = new DashboardElements().ExtendedDashboardAlternateMeasuredValueLabel4;
            if (container4 != null)
            {
                result.Add(container4);
            }

            return result;
        }

        #endregion
    }
}