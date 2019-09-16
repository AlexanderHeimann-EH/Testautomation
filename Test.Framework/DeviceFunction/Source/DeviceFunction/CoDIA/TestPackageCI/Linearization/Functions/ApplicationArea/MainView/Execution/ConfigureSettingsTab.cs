// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSettingsTab.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ConfigureSettingsTab.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Linearization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Linearization.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Class ConfigureSettingsTab.
    /// </summary>
    public class ConfigureSettingsTab : IConfigureSettingsTab
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the general settings distance unit.
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetGeneralSettingsDistanceUnit()
        {
            string result;
            Element element = new SettingsTabElements().GeneralSettingsComboBoxDistanceUnit;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsComboBoxDistanceUnit is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the general settings empty calibration.
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetGeneralSettingsEmptyCalibration()
        {
            string result;
            Element element = new SettingsTabElements().GeneralSettingsEditFieldEmptyCalibration;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsEditFieldEmptyCalibration is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the general settings full calibration.
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetGeneralSettingsFullCalibration()
        {
            string result;
            Element element = new SettingsTabElements().GeneralSettingsEditFieldFullCalibration;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsEditFieldFullCalibration is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the general settings level unit.
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetGeneralSettingsLevelUnit()
        {
            string result;
            Element element = new SettingsTabElements().GeneralSettingsComboBoxLevelUnit;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsComboBoxLevelUnit is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the type of the general settings linearization.
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetGeneralSettingsLinearizationType()
        {
            string result;
            Element element = new SettingsTabElements().GeneralSettingsComboBoxLinearizationType;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsComboBoxLinearizationType is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the general settings output mode.
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetGeneralSettingsOutputMode()
        {
            string result;
            Element element = new SettingsTabElements().GeneralSettingsComboBoxOutputMode;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsComboBoxOutputMode is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the name of the user settings device.
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetUserSettingsDeviceName()
        {
            string result;
            Element element = new SettingsTabElements().UserSettingsEditFieldDeviceNameInfo;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "UserSettingsEditFieldDeviceNameInfo is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the user settings device tag.
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetUserSettingsDeviceTag()
        {
            string result;
            Element element = new SettingsTabElements().UserSettingsEditFieldDeviceTagInfo;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "UserSettingsEditFieldDeviceTagInfo is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the user settings unit after linearization.
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetUserSettingsUnitAfterLinearization()
        {
            string result;
            Element element = new SettingsTabElements().UserSettingsComboBoxUnitAfterLinearization;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "UserSettingsComboBoxUnitAfterLinearization is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Sets the general settings distance unit.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetGeneralSettingsDistanceUnit(string value)
        {
            bool result;
            Element element = new SettingsTabElements().GeneralSettingsComboBoxDistanceUnit;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsComboBoxDistanceUnit is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsDistanceUnit will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the general settings empty calibration.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetGeneralSettingsEmptyCalibration(string value)
        {
            bool result;
            Element element = new SettingsTabElements().GeneralSettingsEditFieldEmptyCalibration;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsEditFieldEmptyCalibration is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsEmptyCalibration will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the general settings full calibration.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetGeneralSettingsFullCalibration(string value)
        {
            bool result;
            Element element = new SettingsTabElements().GeneralSettingsEditFieldFullCalibration;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsEditFieldFullCalibration is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsFullCalibration will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the general settings level unit.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetGeneralSettingsLevelUnit(string value)
        {
            bool result;
            Element element = new SettingsTabElements().GeneralSettingsComboBoxLevelUnit;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsComboBoxLevelUnit is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsLevelUnit will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the type of the general settings linearization.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetGeneralSettingsLinearizationType(string value)
        {
            bool result;
            Element element = new SettingsTabElements().GeneralSettingsComboBoxLinearizationType;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsComboBoxLinearizationType is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsLinearizationType will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the general settings output mode.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetGeneralSettingsOutputMode(string value)
        {
            bool result;
            Element element = new SettingsTabElements().GeneralSettingsComboBoxOutputMode;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsComboBoxOutputMode is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GeneralSettingsOutputMode will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the user settings unit after linearization.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetUserSettingsUnitAfterLinearization(string value)
        {
            bool result;
            Element element = new SettingsTabElements().UserSettingsComboBoxUnitAfterLinearization;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "UserSettingsComboBoxUnitAfterLinearization is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "UserSettingsUnitAfterLinearization will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        #endregion

        // TODO: Interfaces + Loader
    }
}