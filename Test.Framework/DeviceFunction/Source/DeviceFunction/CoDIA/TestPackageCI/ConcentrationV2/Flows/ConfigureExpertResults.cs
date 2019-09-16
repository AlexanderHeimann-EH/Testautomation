// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureExpertResults.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ConfigureExpertResults.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Flows;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class ConfigureExpertResults.
    /// </summary>
    public class ConfigureExpertResults : IConfigureExpertResults
    {
        ///// <summary>
        ///// Configures the tab expert results
        ///// </summary>
        ///// <param name="parameter">A string containing all parameter. Use ; to separate an individual parameter param1;param2;param3... </param>
        ///// <returns><c>true</c> if configured, <c>false</c> otherwise.</returns>
        //public bool Run(string parameter)
        //{
        //    var parameterArray = Common.Tools.StringToStringArrayConverter.Run(parameter);
        //}

        /// <summary>
        /// Runs the specified density calibration.
        /// </summary>
        /// <param name="densityCalibration">The density calibration.</param>
        /// <param name="sensor">The sensor.</param>
        /// <param name="fieldDensityAdjustment">The field density adjustment.</param>
        /// <param name="diagramSelection">The diagram selection.</param>
        /// <returns><c>true</c> if configured, <c>false</c> otherwise.</returns>
        public bool Run(string densityCalibration, string sensor, string fieldDensityAdjustment, string diagramSelection)
        {
            bool result = true;

            if ((new Container()).SelectTabExpertResults() == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open tab [Base settings].");
            }
            else
            {
                if (this.IsValid(densityCalibration))
                {
                    (new ExpertResults()).DensityCalibration = densityCalibration;

                    if (new ExpertResults().DensityCalibration != densityCalibration)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Density Calibration] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new ExpertResults().DensityCalibration + " != " + densityCalibration);
                        result = false;
                    }
                }

                if (this.IsValid(sensor))
                {
                    (new ExpertResults()).Sensor = sensor;

                    if (new ExpertResults().Sensor != sensor)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Sensor] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new ExpertResults().Sensor + " != " + sensor);
                        result = false;
                    }
                }

                if (this.IsValid(fieldDensityAdjustment))
                {
                    (new ExpertResults()).FieldDensityAdjustment = fieldDensityAdjustment;

                    if (new ExpertResults().FieldDensityAdjustment != fieldDensityAdjustment)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Field Density Adjustment] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new ExpertResults().FieldDensityAdjustment + " != " + fieldDensityAdjustment);
                        result = false;
                    }
                }

                if (this.IsValid(diagramSelection))
                {
                    (new ExpertResults()).Diagram = diagramSelection;

                    if (new ExpertResults().Diagram != diagramSelection)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Diagram] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), new ExpertResults().Diagram + " != " + diagramSelection);
                        result = false;
                    }
                }
            }

            return result;
        }

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
    }
}