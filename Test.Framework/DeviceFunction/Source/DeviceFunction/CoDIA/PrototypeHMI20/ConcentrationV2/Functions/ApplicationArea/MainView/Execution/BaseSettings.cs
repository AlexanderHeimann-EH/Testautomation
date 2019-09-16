// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.ApplicationArea.MainView;

    /// <summary>
    ///     Provides methods for tab base settings within module concentration
    /// </summary>
    public class BaseSettings : IBaseSettings
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the reference temperature.
        /// </summary>
        /// <value>The reference temperature.</value>
        public string ReferenceTemperature
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).EditFieldReferenceTemperature);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).EditFieldReferenceTemperature, value);
            }
        }

        /// <summary>
        /// Gets or sets the average process pressure.
        /// </summary>
        /// <value>The average process pressure.</value>
        public string AverageProcessPressure
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).EditFieldAverageProcessPressure);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).EditFieldAverageProcessPressure, value);
            }
        }

        /// <summary>
        /// Gets or sets the average process pressure unit.
        /// </summary>
        /// <value>The average process pressure unit.</value>
        public string AverageProcessPressureUnit
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).ComboBoxAverageProcessPressureUnit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).ComboBoxAverageProcessPressureUnit, value);
            }
        }

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
        public string DensityCalibration { get; set; }

        /// <summary>
        /// Gets or sets the field density adjustment.
        /// </summary>
        /// <value>The field density adjustment.</value>
        public string FieldDensityAdjustment { get; set; }

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
        /// Gets or sets the content of the mineral.
        /// </summary>
        /// <value>The content of the mineral.</value>
        public string MineralContent
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).EditFieldMineralContent);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).EditFieldMineralContent, value);
            }
        }

        /// <summary>
        /// Gets or sets the sensor.
        /// </summary>
        public string Sensor { get; set; }

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
        /// <value>The user profile.</value>
        public string UserProfile
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new BaseSettingsElements()).ComboBoxUserProfile);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new BaseSettingsElements()).ComboBoxUserProfile, value);
            }
        }      
        #endregion
    }
}