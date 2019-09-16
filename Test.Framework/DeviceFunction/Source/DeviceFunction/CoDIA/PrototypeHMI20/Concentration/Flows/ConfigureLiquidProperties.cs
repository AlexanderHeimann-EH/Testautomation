// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureLiquidProperties.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to configure tab base settings
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Flows;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides function to configure tab base settings
    /// </summary>
    public class ConfigureLiquidProperties : IConfigureLiquidProperties
    {
        #region Public Methods and Operators

        /// <summary>
        /// Configure tab base settings. To ignore a value, it must be an empty string like this -&gt; "".
        /// </summary>
        /// <param name="calculationBase">
        /// Calculation Base
        /// </param>
        /// <param name="sensor">
        /// Sensor parameter
        /// </param>
        /// <param name="densityCalibration">
        /// Density Calibration
        /// </param>
        /// <param name="temperaturMin">
        /// Temperature Minimum
        /// </param>
        /// <param name="temperaturMax">
        /// Temperature Maximum
        /// </param>
        /// <param name="temperaturUnit">
        /// Temperature Unit
        /// </param>
        /// <param name="densityMin">
        /// Density Minimum
        /// </param>
        /// <param name="densityMax">
        /// Density Maximum
        /// </param>
        /// <param name="densityUnit">
        /// Density Unit
        /// </param>
        /// <param name="concentrationMin">
        /// Concentration Minimum
        /// </param>
        /// <param name="concentrationMax">
        /// Concentration Maximum
        /// </param>
        /// <param name="concentrationUnit">
        /// Concentration Unit
        /// </param>
        /// <returns>
        /// <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run(string calculationBase, string sensor, string densityCalibration, string temperaturMin, string temperaturMax, string temperaturUnit, string densityMin, string densityMax, string densityUnit, string concentrationMin, string concentrationMax, string concentrationUnit)
        {
            if ((new Container()).SelectTabLiquidProperties())
            {
                if (this.IsValid(calculationBase))
                {
                    (new LiquidProperties()).InputFormat = calculationBase;
                }

                // if (this.IsValid(Sensor))
                // {
                // (new MainView.Areas.BaseSettings()).Sensor = Sensor;
                // }

                // if (this.IsValid(DensityCalibration))
                // {
                // (new MainView.Areas.BaseSettings()).DensityCalibration = DensityCalibration;
                // }

                // if (this.IsValid(TemperaturMin))
                // {
                // (new MainView.Areas.BaseSettings()).TemperaturMin = TemperaturMin;
                // }

                // if (this.IsValid(TemperaturMax))
                // {
                // (new MainView.Areas.BaseSettings()).TemperaturMax = TemperaturMax;
                // }

                // if (this.IsValid(TemperaturUnit))
                // {
                // (new MainView.Areas.BaseSettings()).TemperaturUnit = TemperaturUnit;
                // }

                // if (this.IsValid(densityMin))
                // {
                // (new MainView.Areas.BaseSettings()).densityMin = densityMin;
                // }

                // if (this.IsValid(densityMax))
                // {
                // (new MainView.Areas.BaseSettings()).densityMax = densityMax;
                // }

                // if (this.IsValid(densityUnit))
                // {
                // (new MainView.Areas.BaseSettings()).densityUnit = densityUnit;
                // }

                // if (this.IsValid(ConcentrationMin))
                // {
                // (new MainView.Areas.BaseSettings()).ConcentrationMin = ConcentrationMin;
                // }

                // if (this.IsValid(ConcentrationMax))
                // {
                // (new MainView.Areas.BaseSettings()).ConcentrationMax = ConcentrationMax;
                // }

                // if (this.IsValid(ConcentrationUnit))
                // {
                // (new MainView.Areas.BaseSettings()).ConcentrationUnit = ConcentrationUnit;
                // }
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Empty);
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