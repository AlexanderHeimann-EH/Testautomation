// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureLiquidProperties.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
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
                if (calculationBase.Length > 0)
                {
                    (new LiquidProperties()).InputFormat = calculationBase;
                }

                // if (Sensor.Length > 0)
                // {
                // (new MainView.Areas.BaseSettings()).Sensor = Sensor;
                // }

                // if (DensityCalibration.Length > 0)
                // {
                // (new MainView.Areas.BaseSettings()).DensityCalibration = DensityCalibration;
                // }

                // if (TemperaturMin.Length > 0)
                // {
                // (new MainView.Areas.BaseSettings()).TemperaturMin = TemperaturMin;
                // }

                // if (TemperaturMax.Length > 0)
                // {
                // (new MainView.Areas.BaseSettings()).TemperaturMax = TemperaturMax;
                // }

                // if (TemperaturUnit.Length > 0)
                // {
                // (new MainView.Areas.BaseSettings()).TemperaturUnit = TemperaturUnit;
                // }

                // if (densityMin.Length > 0)
                // {
                // (new MainView.Areas.BaseSettings()).densityMin = densityMin;
                // }

                // if (densityMax.Length > 0)
                // {
                // (new MainView.Areas.BaseSettings()).densityMax = densityMax;
                // }

                // if (densityUnit.Length > 0)
                // {
                // (new MainView.Areas.BaseSettings()).densityUnit = densityUnit;
                // }

                // if (ConcentrationMin.Length > 0)
                // {
                // (new MainView.Areas.BaseSettings()).ConcentrationMin = ConcentrationMin;
                // }

                // if (ConcentrationMax.Length > 0)
                // {
                // (new MainView.Areas.BaseSettings()).ConcentrationMax = ConcentrationMax;
                // }

                // if (ConcentrationUnit.Length > 0)
                // {
                // (new MainView.Areas.BaseSettings()).ConcentrationUnit = ConcentrationUnit;
                // }
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Empty);
            return false;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="inputFormat">
        /// The input format.
        /// </param>
        /// <param name="spreadsheet">
        /// The spreadsheet.
        /// </param>
        /// <param name="column1Selection">
        /// The column 1 selection.
        /// </param>
        /// <param name="column1Minimum">
        /// The column 1 minimum.
        /// </param>
        /// <param name="column1Max">
        /// The column 1 max.
        /// </param>
        /// <param name="column1Unit">
        /// The column 1 unit.
        /// </param>
        /// <param name="column2Selection">
        /// The column 2 selection.
        /// </param>
        /// <param name="column2Minimum">
        /// The column 2 minimum.
        /// </param>
        /// <param name="column2Max">
        /// The column 2 max.
        /// </param>
        /// <param name="column2Unit">
        /// The column 2 unit.
        /// </param>
        /// <param name="column3Selection">
        /// The column 3 selection.
        /// </param>
        /// <param name="column3Minimum">
        /// The column 3 minimum.
        /// </param>
        /// <param name="column3Max">
        /// The column 3 max.
        /// </param>
        /// <param name="column3Unit">
        /// The column 3 unit.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool Run(string inputFormat, string spreadsheet, string column1Selection, string column1Minimum, string column1Max, string column1Unit, string column2Selection, string column2Minimum, string column2Max, string column2Unit, string column3Selection, string column3Minimum, string column3Max, string column3Unit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="fineTuningValue1Unit">
        /// The fine tuning value 1 unit.
        /// </param>
        /// <param name="fineTuningValue2Unit">
        /// The fine tuning value 2 unit.
        /// </param>
        /// <param name="fineTuningValue3Unit">
        /// The fine tuning value 3 unit.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool Run(string fineTuningValue1Unit, string fineTuningValue2Unit, string fineTuningValue3Unit)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}