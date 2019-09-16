// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureBaseSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Flows;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides function to configure tab base settings
    /// </summary>
    public class ConfigureBaseSettings : IConfigureBaseSettings
    {
        #region Public Methods and Operators

        /// <summary>
        /// Averages the pressure.
        /// </summary>
        /// <param name="averageProcessPressure">
        /// The average process pressure.
        /// </param>
        /// <param name="averageProcessPressureUnit">
        /// The average process pressure unit.
        /// </param>
        /// <returns>
        /// <c>true</c> if configured correctly, <c>false</c> otherwise.
        /// </returns>
        public bool AveragePressure(string averageProcessPressure, string averageProcessPressureUnit)
        {
            bool result = true;

            if ((new Container()).SelectTabBaseSettings() == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open tab [Base settings].");
            }
            else
            {
                if (this.IsValid(averageProcessPressure))
                {
                    (new BaseSettings()).AverageProcessPressure = averageProcessPressure;

                    if (new BaseSettings().AverageProcessPressure != averageProcessPressure)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().AverageProcessPressure + " != " + averageProcessPressure);
                        result = false;
                    }
                }

                if (this.IsValid(averageProcessPressureUnit))
                {
                    (new BaseSettings()).AverageProcessPressureUnit = averageProcessPressureUnit;

                    if (new BaseSettings().AverageProcessPressureUnit != averageProcessPressureUnit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure Unit] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().AverageProcessPressureUnit + " != " + averageProcessPressureUnit);
                        result = false;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Bases the configuration.
        /// </summary>
        /// <param name="calculationBase">The calculation base.</param>
        /// <param name="liquidType">Type of the liquid.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="referenceTemperature">The reference temperature.</param>
        /// <param name="mineralContent">Content of the mineral.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool BaseConfiguration(string calculationBase, string liquidType, string userProfile, string referenceTemperature, string mineralContent)
        {
            bool result = true;

            if ((new Container()).SelectTabBaseSettings() == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open tab [Base settings].");
            }
            else
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

                if (this.IsValid(userProfile))
                {
                    (new BaseSettings()).UserProfile = userProfile;

                    if (new BaseSettings().UserProfile != userProfile)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [User Profile] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().UserProfile + " != " + userProfile);
                        result = false;
                    }
                }

                if (this.IsValid(referenceTemperature))
                {
                    (new BaseSettings()).ReferenceTemperature = referenceTemperature;

                    if (new BaseSettings().ReferenceTemperature != referenceTemperature)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Reference Temperature] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().ReferenceTemperature + " != " + referenceTemperature);
                        result = false;
                    }
                }

                if (this.IsValid(mineralContent))
                {
                    (new BaseSettings()).MineralContent = mineralContent;

                    if (new BaseSettings().MineralContent != mineralContent)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Mineral Content] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().MineralContent + " != " + mineralContent);
                        result = false;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Operating the range.
        /// </summary>
        /// <param name="temperatureMinimum">The temperature minimum.</param>
        /// <param name="temperatureMaximum">The temperature maximum.</param>
        /// <param name="temperatureUnit">The temperature unit.</param>
        /// <param name="concentrationMinimum">The concentration minimum.</param>
        /// <param name="concentrationMaximum">The concentration maximum.</param>
        /// <param name="concentrationUnit">The concentration unit.</param>
        /// <returns><c>true</c> if configured, <c>false</c> otherwise.</returns>
        public bool OperatingRange(string temperatureMinimum, string temperatureMaximum, string temperatureUnit, string concentrationMinimum, string concentrationMaximum, string concentrationUnit)
        {
            bool result = true;

            if ((new Container()).SelectTabBaseSettings() == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open tab [Base settings].");
            }
            else
            {
                if (this.IsValid(temperatureMinimum))
                {
                    (new BaseSettings()).TemperatureMin = temperatureMinimum;

                    if (new BaseSettings().TemperatureMin != temperatureMinimum)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Temperature Minimum] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().TemperatureMin + " != " + temperatureMinimum);
                        result = false;
                    }
                }

                if (this.IsValid(temperatureMaximum))
                {
                    (new BaseSettings()).TemperatureMax = temperatureMaximum;

                    if (new BaseSettings().TemperatureMax != temperatureMaximum)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Temperature Minimum] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().TemperatureMax + " != " + temperatureMaximum);
                        result = false;
                    }
                }

                if (this.IsValid(temperatureUnit))
                {
                    (new BaseSettings()).TemperatureUnit = temperatureUnit;

                    if (new BaseSettings().TemperatureUnit != temperatureUnit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Concentration Maximum] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().TemperatureUnit + " != " + temperatureUnit);
                        result = false;
                    }
                }

                if (this.IsValid(concentrationMinimum))
                {
                    (new BaseSettings()).ConcentrationMin = concentrationMinimum;

                    if (new BaseSettings().ConcentrationMin != concentrationMinimum)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Concentration Minimum] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().ConcentrationMin + " != " + concentrationMinimum);
                        result = false;
                    }
                }

                if (this.IsValid(concentrationMaximum))
                {
                    (new BaseSettings()).ConcentrationMax = concentrationMaximum;

                    if (new BaseSettings().ConcentrationMax != concentrationMaximum)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Concentration Maximum] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().ConcentrationMax + " != " + concentrationMaximum);
                        result = false;
                    }
                }

                if (this.IsValid(concentrationUnit))
                {
                    (new BaseSettings()).ConcentrationUnit = concentrationUnit;

                    if (new BaseSettings().ConcentrationUnit != concentrationUnit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Concentration Maximum] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new BaseSettings().ConcentrationUnit + " != " + concentrationUnit);
                        result = false;
                    }
                }
            }

            return result;
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