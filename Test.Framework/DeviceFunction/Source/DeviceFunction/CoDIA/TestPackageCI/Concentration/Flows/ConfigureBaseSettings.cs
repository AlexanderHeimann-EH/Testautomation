// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureBaseSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Concentration.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Flows;
    using EH.PCPS.TestAutomation.TestPackageCI.Concentration.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides function to configure tab base settings
    /// </summary>
    public class ConfigureBaseSettings : IConfigureBaseSettings
    {
        #region Public Methods and Operators

        /// <summary>
        /// Configure tab base settings. To ignore a value, it must be an empty string like this -&gt; "".
        /// </summary>
        /// <param name="calculationBase">
        /// Calculation base
        /// </param>
        /// <param name="liquidType">
        /// Liquid type
        /// </param>
        /// <param name="densityCalibration">
        /// Density Calibration
        /// </param>
        /// <param name="fieldDensityAdjustment">
        /// Field Density Adjustment
        /// </param>
        /// <param name="sensor">
        /// Sensor parameter
        /// </param>
        /// <param name="temperaturUnit">
        /// Temperature Unit
        /// </param>
        /// <param name="temperaturMin">
        /// Temperature Min.
        /// </param>
        /// <param name="temperaturMax">
        /// Temperature Max.
        /// </param>
        /// <param name="concentrationUnit">
        /// Concentration Unit
        /// </param>
        /// <param name="concentrationMin">
        /// Concentration Min.
        /// </param>
        /// <param name="concentrationMax">
        /// Concentration Max.
        /// </param>
        /// <returns>
        /// <br>true: if all worked fine</br>
        ///     <br>false: if an error occurred</br>
        /// </returns>
        public bool Run(string calculationBase, string liquidType, string densityCalibration, string fieldDensityAdjustment, string sensor, string temperaturUnit, string temperaturMin, string temperaturMax, string concentrationUnit, string concentrationMin, string concentrationMax)
        {
            bool result = true;

            if ((new Container()).SelectTabBaseSettings())
            {
                if (this.IsValid(calculationBase))
                {
                    (new BaseSettings()).CalculationBase = calculationBase;

                    if (new BaseSettings().CalculationBase != calculationBase)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Calculation Base] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().CalculationBase + " != " + calculationBase);
                        result = false;
                    }
                }

                if (this.IsValid(liquidType))
                {
                    (new BaseSettings()).LiquidType = liquidType;

                    if (new BaseSettings().LiquidType != liquidType)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Liquid Type] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().LiquidType + " != " + liquidType);
                        result = false;
                    }
                }

                if (this.IsValid(densityCalibration))
                {
                    (new BaseSettings()).DensityCalibration = densityCalibration;

                    if (new BaseSettings().DensityCalibration != densityCalibration)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Density Calibration] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().DensityCalibration + " != " + densityCalibration);
                        result = false;
                    }
                }

                if (this.IsValid(fieldDensityAdjustment))
                {
                    (new BaseSettings()).FieldDensityAdjustment = fieldDensityAdjustment;

                    if (new BaseSettings().FieldDensityAdjustment != fieldDensityAdjustment)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Field Density Adjustment] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().FieldDensityAdjustment + " != " + fieldDensityAdjustment);
                        result = false;
                    }
                }

                if (this.IsValid(sensor))
                {
                    (new BaseSettings()).Sensor = sensor;

                    if (new BaseSettings().Sensor != sensor)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Sensor] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().Sensor + " != " + sensor);
                        result = false;
                    }
                }

                if (this.IsValid(temperaturUnit))
                {
                    (new BaseSettings()).TemperatureUnit = temperaturUnit;

                    if (new BaseSettings().TemperatureUnit != temperaturUnit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Temperature Unit] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().TemperatureUnit + " != " + temperaturUnit);
                        result = false;
                    }
                }

                if (this.IsValid(temperaturMin))
                {
                    (new BaseSettings()).TemperatureMin = temperaturMin;

                    if (new BaseSettings().TemperatureMin != temperaturMin)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Temperature Min] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().TemperatureMin + " != " + temperaturMin);
                        result = false;
                    }
                }

                if (this.IsValid(temperaturMax))
                {
                    (new BaseSettings()).TemperatureMax = temperaturMax;

                    if (new BaseSettings().TemperatureMax != temperaturMax)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Temperature Max] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().TemperatureMax + " != " + temperaturMax);
                        result = false;
                    }
                }

                if (this.IsValid(concentrationUnit))
                {
                    (new BaseSettings()).ConcentrationUnit = concentrationUnit;

                    if (new BaseSettings().ConcentrationUnit != concentrationUnit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Concentration Unit] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().ConcentrationUnit + " != " + concentrationUnit);
                        result = false;
                    }
                }

                if (this.IsValid(concentrationMin))
                {
                    (new BaseSettings()).ConcentrationMin = concentrationMin;

                    if (new BaseSettings().ConcentrationMin != concentrationMin)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Concentration Min] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().ConcentrationMin + " != " + concentrationMin);
                        result = false;
                    }
                }

                if (this.IsValid(concentrationMax))
                {
                    (new BaseSettings()).ConcentrationMax = concentrationMax;

                    if (new BaseSettings().ConcentrationMax != concentrationMax)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Concetration Max] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().ConcentrationMax + " != " + concentrationMax);
                        result = false;
                    }
                }

                return result;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Switching to settings tab failed");
            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsValid(string value)
        {
            if (value.Length > 0 && !value.Equals(" "))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}