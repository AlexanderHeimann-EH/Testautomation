// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckThatAllFieldsInBaseSettingsAreGrayed.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class CheckThatAllFieldsInBaseSettingsAreGrayed.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Concentration.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.ApplicationArea.MainView.Validation;

    using Ranorex.Core;

    /// <summary>
    /// Class CheckThatAllFieldsInBaseSettingsAreGrayed.
    /// </summary>
    public class CheckThatAllFieldsInBaseSettingsAreGrayed : ICheckThatAllFieldsInBaseSettingsAreGrayed
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks whether all elements in the tab 'Base settings' ( combo boxes, edit fields etc...) except 'Calculation base' are grayed and inactive. 
        /// This is the case then selecting 'Fine tuning' as 'Calculation base'.
        /// </summary>
        /// <returns><c>true</c> if all elements are grayed, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            bool result = true;

            Element calculationBase = new GUI.ApplicationArea.MainView.BaseSettingsElements().ComboBoxCalculationBase;
            Element liquidType = new GUI.ApplicationArea.MainView.BaseSettingsElements().ComboBoxLiquidType;
            Element densityCalibration = new GUI.ApplicationArea.MainView.BaseSettingsElements().ComboBoxDensityCalibration;
            Element sensor = new GUI.ApplicationArea.MainView.BaseSettingsElements().ComboBoxSensor;
            Element fieldDensityAdjustment = new GUI.ApplicationArea.MainView.BaseSettingsElements().RadioButtonFieldDensityAdjustment;
            Element concentrationMax = new GUI.ApplicationArea.MainView.BaseSettingsElements().TextConcentrationMax;
            Element concentrationMin = new GUI.ApplicationArea.MainView.BaseSettingsElements().TextConcentrationMin;
            Element temperatureMax = new GUI.ApplicationArea.MainView.BaseSettingsElements().TextTemperatureMax;
            Element temperatureMin = new GUI.ApplicationArea.MainView.BaseSettingsElements().TextTemperatureMin;
            Element concentrationUnit = new GUI.ApplicationArea.MainView.BaseSettingsElements().ComboBoxConcentrationUnit;
            Element temperatureUnit = new GUI.ApplicationArea.MainView.BaseSettingsElements().ComboBoxTemperatureUnit;
            Element averageProcessPressure = new GUI.ApplicationArea.MainView.BaseSettingsElements().EditFieldAverageProcessPressure;
            Element averageProcessPressureUnit = new GUI.ApplicationArea.MainView.BaseSettingsElements().ComboBoxAverageProcessPressureUnit;
            Element[] elements = { liquidType, densityCalibration, sensor, fieldDensityAdjustment, concentrationMax, concentrationMin, temperatureMax, temperatureMin, concentrationUnit, temperatureUnit, averageProcessPressure, averageProcessPressureUnit };
            
            if (calculationBase == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculation Base is null.");
            }
            else if (calculationBase.Enabled == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculation Base is grayed out and not enabled.");
            }
            else
            {
                foreach (var element in elements)
                {
                    if (element == null)
                    {
                        result = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "One element in tab 'Base Settings' is null.");
                        break;
                    }

                    if (element.Enabled)
                    {
                        result = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element: \" " + element.GetAttributeValueText("controlname") + " \" is enabled but should be grayed and inactive.");
                        new Execution.TakeScreenshotOfModule().Run();
                        break;
                    }
                }
            }

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "All elements (except 'Calculation Base' are grayed and inactive as expected.");
            }

            return result;
        }

        #endregion
    }
}