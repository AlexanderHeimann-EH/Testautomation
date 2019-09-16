// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureBaseSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Concentration.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Concentration.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides function to configure tab base settings
    /// </summary>
    public class ConfigureBaseSettings : IConfigureBaseSettings
    {
        #region Public Methods and Operators

        /// <summary>
        /// The average pressure.
        /// </summary>
        /// <param name="averageProcessPressure">
        /// The average process pressure.
        /// </param>
        /// <param name="averageProcessPressureUnit">
        /// The average process pressure unit.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// NotImplemented Exception
        /// </exception>
        public bool AveragePressure(string averageProcessPressure, string averageProcessPressureUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Bases the configuration.
        /// </summary>
        /// <param name="calculationBase">
        /// The calculation base.
        /// </param>
        /// <param name="liquidType">
        /// Type of the liquid.
        /// </param>
        /// <param name="userProfile">
        /// The user profile.
        /// </param>
        /// <param name="referenceTemperature">
        /// The reference temperature.
        /// </param>
        /// <param name="mineralContent">
        /// Content of the mineral.
        /// </param>
        /// <returns>
        /// <c>true</c> if set correctly, <c>false</c> otherwise.
        /// </returns>
        public bool BaseConfiguration(string calculationBase, string liquidType, string userProfile, string referenceTemperature, string mineralContent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The operating range.
        /// </summary>
        /// <param name="temperatureMinimum">
        /// The temperature minimum.
        /// </param>
        /// <param name="temperatureMaximum">
        /// The temperature maximum.
        /// </param>
        /// <param name="concentrationMinimum">
        /// The concentration minimum.
        /// </param>
        /// <param name="concentrationMaximum">
        /// The concentration maximum.
        /// </param>
        /// <param name="temperatureUnit">
        /// The temperature unit.
        /// </param>
        /// <param name="concentrationUnit">
        /// The concentration unit.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// NotImplemented Exception
        /// </exception>
        public bool OperatingRange(string temperatureMinimum, string temperatureMaximum, string concentrationMinimum, string concentrationMaximum, string temperatureUnit, string concentrationUnit)
        {
            throw new NotImplementedException();
        }

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
                if (calculationBase.Length > 0)
                {
                    (new BaseSettings()).CalculationBase = calculationBase;

                    if (new BaseSettings().CalculationBase != calculationBase)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Calculation Base] failed");
                        result = false;
                    }
                }

                if (liquidType.Length > 0)
                {
                    (new BaseSettings()).LiquidType = liquidType;

                    if (new BaseSettings().LiquidType != liquidType)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Liquid Type] failed");
                        result = false;
                    }
                }

                if (densityCalibration.Length > 0)
                {
                    (new BaseSettings()).DensityCalibration = densityCalibration;

                    if (new BaseSettings().DensityCalibration != densityCalibration)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Density Calibration] failed");
                        result = false;
                    }
                }

                if (fieldDensityAdjustment.Length > 0)
                {
                    (new BaseSettings()).FieldDensityAdjustment = fieldDensityAdjustment;

                    if (new BaseSettings().FieldDensityAdjustment != fieldDensityAdjustment)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Field Density Adjustment] failed");
                        result = false;
                    }
                }

                if (sensor.Length > 0)
                {
                    (new BaseSettings()).Sensor = sensor;

                    if (new BaseSettings().Sensor != sensor)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Sensor] failed");
                        result = false;
                    }
                }

                if (temperaturUnit.Length > 0)
                {
                    (new BaseSettings()).TemperatureUnit = temperaturUnit;

                    if (new BaseSettings().TemperatureUnit != temperaturUnit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Temperature Unit] failed");
                        result = false;
                    }
                }

                if (temperaturMin.Length > 0)
                {
                    (new BaseSettings()).TemperatureMin = temperaturMin;

                    if (new BaseSettings().TemperatureMin != temperaturMin)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Temperature Min] failed");
                        result = false;
                    }
                }

                if (temperaturMax.Length > 0)
                {
                    (new BaseSettings()).TemperatureMax = temperaturMax;

                    if (new BaseSettings().TemperatureMax != temperaturMax)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Temperature Max] failed");
                        result = false;
                    }
                }

                if (concentrationUnit.Length > 0)
                {
                    (new BaseSettings()).ConcentrationUnit = concentrationUnit;

                    if (new BaseSettings().ConcentrationUnit != concentrationUnit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Concentration Unit] failed");
                        result = false;
                    }
                }

                if (concentrationMin.Length > 0)
                {
                    (new BaseSettings()).ConcentrationMin = concentrationMin;

                    if (new BaseSettings().ConcentrationMin != concentrationMin)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Concentration Min] failed");
                        result = false;
                    }
                }

                if (concentrationMax.Length > 0)
                {
                    (new BaseSettings()).ConcentrationMax = concentrationMax;

                    if (new BaseSettings().ConcentrationMax != concentrationMax)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Concetration Max] failed");
                        result = false;
                    }
                }

                return result;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Switching to settings tab failed");
            return false;
        }

        #endregion
    }
}