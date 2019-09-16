// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DashboardFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Endress + Hauser Process Solutions AG
// </copyright>
// <summary>
//   Provides methods for the Dashboard control
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Provides methods for the Dashboard control
    /// </summary>
    public class DashboardFunctions : IDashboardFunctions
    {
        #region Public Methods and Operators

        /// <summary>
        /// The compare dashboard value to header parameter.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="headerParameterName">
        /// The header parameter name.
        /// </param>
        /// <param name="accuracy">
        /// The accuracy.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CompareDashboardValueToHeaderParameter(string nameOfDashboardValueToCompare, string headerParameterName, double accuracy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The compare dashboard value to parameter.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="pathToParameter">
        /// The path to parameter.
        /// </param>
        /// <param name="accuracy">
        /// The accuracy.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CompareDashboardValueToParameter(string nameOfDashboardValueToCompare, string pathToParameter, double accuracy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The compare extended dashboard extended value to header parameter.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="headerParameterName">
        /// The header parameter name.
        /// </param>
        /// <param name="accuracy">
        /// The accuracy.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CompareExtendedDashboardExtendedValueToHeaderParameter(string nameOfDashboardValueToCompare, string headerParameterName, double accuracy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The compare extended dashboard extended value to parameter.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="pathToParameter">
        /// The path to parameter.
        /// </param>
        /// <param name="accuracy">
        /// The accuracy.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CompareExtendedDashboardExtendedValueToParameter(string nameOfDashboardValueToCompare, string pathToParameter, double accuracy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The compare extended dashboard main value to header parameter.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="headerParameterName">
        /// The header parameter name.
        /// </param>
        /// <param name="accuracy">
        /// The accuracy.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CompareExtendedDashboardMainValueToHeaderParameter(string nameOfDashboardValueToCompare, string headerParameterName, double accuracy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The compare extended dashboard main value to parameter.
        /// </summary>
        /// <param name="nameOfDashboardValueToCompare">
        /// The name of dashboard value to compare.
        /// </param>
        /// <param name="pathToParameter">
        /// The path to parameter.
        /// </param>
        /// <param name="accuracy">
        /// The accuracy.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CompareExtendedDashboardMainValueToParameter(string nameOfDashboardValueToCompare, string pathToParameter, double accuracy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get dashboard value by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string GetDashboardValueByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get dashboard value unit by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string GetDashboardValueUnitByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get extended dashboard extended value by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string GetExtendedDashboardExtendedValueByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get extended dashboard extended value unit by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string GetExtendedDashboardExtendedValueUnitByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get extended dashboard main value by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string GetExtendedDashboardMainValueByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get extended dashboard main value unit by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string GetExtendedDashboardMainValueUnitByName(string name)
        {
            throw new NotImplementedException();
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
        /// The open dashboard.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool OpenDashboard(int timeoutInMilliseconds)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The process variable.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string ProcessVariable(Element container)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The process variable label.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string ProcessVariableLabel(Element container)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The process variable unit.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string ProcessVariableUnit(Element container)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Selects the tab within the Dashboard control
        /// </summary>
        /// <param name="index">
        /// The tab index which will be selected. Dashboard = 0 , extended Dashboard = 1.
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
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Index out of bounds or tabcontrol == null");
                result = false;
            }

            return result;
        }

        /// <summary>
        /// The take screenshots within interval.
        /// </summary>
        /// <param name="intervalInMilliseconds">
        /// The interval in milliseconds.
        /// </param>
        /// <param name="numberOfScreenshots">
        /// The number of screenshots.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void TakeScreenshotsWithinInterval(int intervalInMilliseconds, int numberOfScreenshots)
        {
            throw new NotImplementedException();
        }

        #endregion

        ///// <summary>
        ///// Returns the Process Variable of a Dashboard container using its FirstLineText attribute
        ///// </summary>
        ///// <param name="container">
        ///// The container from the Dashboard repository
        ///// </param>
        ///// <returns>
        ///// The <see cref="string"/>.
        ///// </returns>
        // public string ProcessVariable(Element container)
        // {
        // string result = string.Empty;

        // if (container == null)
        // {
        // EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element used is null");
        // }
        // else
        // {
        // if (container.GetAttributeValueText("FirstLineText") == null)
        // {
        // EH.PCPS.TestAutomation.Common.Tools.Log.Error(
        // LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The FirstLineText attribute is not available");
        // }
        // else
        // {
        // result = container.GetAttributeValueText("FirstLineText");
        // }
        // }

        // return result;
        // }

        ///// <summary>
        ///// Returns the unit of the Process Variable of a Dashboard container using its SecondLineText attribute
        ///// </summary>
        ///// <param name="container">
        ///// The container from the Dashboard repository
        ///// </param>
        ///// <returns>
        ///// The <see cref="string"/>.
        ///// </returns>
        // public string ProcessVariableUnit(Element container)
        // {
        // string result = string.Empty;

        // if (container == null)
        // {
        // EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element used is null");
        // }
        // else
        // {
        // if (container.GetAttributeValueText("SecondLineText") == null)
        // {
        // EH.PCPS.TestAutomation.Common.Tools.Log.Error(
        // LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The SecondLineText attribute is not available");
        // }
        // else
        // {
        // result = container.GetAttributeValueText("SecondLineText");
        // }
        // }

        // return result;
        // }

        ///// <summary>
        ///// Returns the label of the Process Variable of a Dashboard container using its ThirdLineText attribute
        ///// </summary>
        ///// <param name="container">
        ///// The container from the Dashboard repository
        ///// </param>
        ///// <returns>
        ///// The <see cref="string"/>.
        ///// </returns>
        // public string ProcessVariableLabel(Element container)
        // {
        // string result = string.Empty;

        // if (container == null)
        // {
        // EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element used is null");
        // }
        // else
        // {
        // if (container.GetAttributeValueText("ThirdLineText") == null)
        // {
        // EH.PCPS.TestAutomation.Common.Tools.Log.Error(
        // LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The ThirdLineText attribute is not available");
        // }
        // else
        // {
        // result = container.GetAttributeValueText("ThirdLineText");
        // }
        // }

        // return result;
        // }
    }
}