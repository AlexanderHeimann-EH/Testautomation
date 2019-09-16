// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Concentration.Functions.ApplicationArea.MainView.Execution
{
    using System;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Concentration.GUI.ApplicationArea.MainView;

    /// <summary>
    ///     Provides methods for tab base settings within module concentration
    /// </summary>
    public class BaseSettings : IBaseSettings
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the average process pressure.
        /// </summary>
        public string AverageProcessPressure { get; set; }

        /// <summary>
        /// Gets or sets the average process pressure unit.
        /// </summary>
        public string AverageProcessPressureUnit { get; set; }

        /// <summary>
        /// Gets or sets the calculation base.
        /// </summary>
        public string CalculationBase
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).ComboBoxCalculationBase);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).ComboBoxCalculationBase, value);
            }
        }

        /// <summary>
        /// Gets or sets the concentration max.
        /// </summary>
        public string ConcentrationMax
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).TextConcentrationMax);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).TextConcentrationMax, value);
            }
        }

        /// <summary>
        /// Gets or sets the concentration min.
        /// </summary>
        public string ConcentrationMin
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).TextConcentrationMin);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).TextConcentrationMin, value);
            }
        }

        /// <summary>
        /// Gets or sets the concentration unit.
        /// </summary>
        public string ConcentrationUnit
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).ComboBoxConcentrationUnit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).ComboBoxConcentrationUnit, value);
            }
        }

        /// <summary>
        /// Gets or sets the density calibration.
        /// </summary>
        public string DensityCalibration
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).ComboBoxDensityCalibration);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).ComboBoxDensityCalibration, value);
            }
        }

        /// <summary>
        /// Gets or sets the field density adjustment.
        /// </summary>
        public string FieldDensityAdjustment
        {
            get
            {
                string selectedIndex = new BaseSettingsElements().RadioButtonFieldDensityAdjustment.GetAttributeValue("SelectedIndex").ToString();
                int index = Convert.ToInt32(selectedIndex);
                switch (index)
                {
                    case 0:
                        return "No";
                    case 1:
                        return "Yes";
                    default:
                        return "Invalid";
                }
            }

            set
            {
                switch (value)
                {
                    case "No":
                        new BaseSettingsElements().RadioButtonFieldDensityAdjustment.SetAttributeValue("SelectedIndex", 0);
                        break;
                    case "Yes":
                        new BaseSettingsElements().RadioButtonFieldDensityAdjustment.SetAttributeValue("SelectedIndex", 1);
                        break;
                    default:
                        new BaseSettingsElements().RadioButtonFieldDensityAdjustment.SetAttributeValue("SelectedIndex", 0);
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets the liquid type.
        /// </summary>
        public string LiquidType
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).ComboBoxLiquidType);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).ComboBoxLiquidType, value);
            }
        }

        /// <summary>
        /// Gets or sets the mineral content.
        /// </summary>
        public string MineralContent { get; set; }

        /// <summary>
        /// Gets or sets the reference temperature.
        /// </summary>
        public string ReferenceTemperature { get; set; }

        /// <summary>
        /// Gets or sets the sensor.
        /// </summary>
        public string Sensor
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).ComboBoxSensor);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).ComboBoxSensor, value);
            }
        }

        /// <summary>
        /// Gets or sets the temperature max.
        /// </summary>
        public string TemperatureMax
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).TextTemperatureMax);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).TextTemperatureMax, value);
            }
        }

        /// <summary>
        /// Gets or sets the temperature min.
        /// </summary>
        public string TemperatureMin
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).TextTemperatureMin);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).TextTemperatureMin, value);
            }
        }

        /// <summary>
        /// Gets or sets the temperature unit.
        /// </summary>
        public string TemperatureUnit
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).ComboBoxTemperatureUnit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).ComboBoxTemperatureUnit, value);
            }
        }

        /// <summary>
        /// Gets or sets the user profile.
        /// </summary>
        public string UserProfile { get; set; }

        /// <summary>
        /// Gets or sets the water based.
        /// </summary>
        public string WaterBased { get; set; }

        #endregion
    }
}