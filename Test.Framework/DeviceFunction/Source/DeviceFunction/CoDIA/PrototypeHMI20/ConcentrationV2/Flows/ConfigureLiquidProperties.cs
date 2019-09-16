// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureLiquidProperties.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to configure tab base settings
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Flows;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides function to configure tab base settings
    /// </summary>
    public class ConfigureLiquidProperties : IConfigureLiquidProperties
    {
        #region Public Methods and Operators

        /// <summary>
        /// Configures tab Liquid Properties. To skip a parameter, use an empty string.
        /// </summary>
        /// <param name="inputFormat">The input format.</param>
        /// <param name="spreadsheet">The spreadsheet.</param>
        /// <param name="column1Selection">The column1 selection.</param>
        /// <param name="column1Minimum">The column1 minimum.</param>
        /// <param name="column1Max">The column1 maximum.</param>
        /// <param name="column1Unit">The column1 unit.</param>
        /// <param name="column2Selection">The column2 selection.</param>
        /// <param name="column2Minimum">The column2 minimum.</param>
        /// <param name="column2Max">The column2 maximum.</param>
        /// <param name="column2Unit">The column2 unit.</param>
        /// <param name="column3Selection">The column3 selection.</param>
        /// <param name="column3Minimum">The column3 minimum.</param>
        /// <param name="column3Max">The column3 maximum.</param>
        /// <param name="column3Unit">The column3 unit.</param>
        /// <returns><c>true</c> if configured, <c>false</c> otherwise.</returns>
        public bool Run(string inputFormat, string spreadsheet, string column1Selection, string column1Minimum, string column1Max, string column1Unit, string column2Selection, string column2Minimum, string column2Max, string column2Unit, string column3Selection, string column3Minimum, string column3Max, string column3Unit)
        {
            bool result = true;
            var liquidProperties = new LiquidProperties();

            if ((new Container()).SelectTabLiquidProperties() == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open tab [Liquid Properties].");
                result = false;
            }
            else
            {
                if (this.IsValid(inputFormat))
                {
                    liquidProperties.InputFormat = inputFormat;

                    if (liquidProperties.InputFormat != inputFormat)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Input Format] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.InputFormat + " != " + inputFormat);
                        result = false;
                    }
                }

                if (this.IsValid(spreadsheet))
                {
                    liquidProperties.Spreadsheet = spreadsheet;

                    if (liquidProperties.Spreadsheet != spreadsheet)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Spreadsheet] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Spreadsheet + " != " + spreadsheet);
                        result = false;
                    }
                }

                if (this.IsValid(column1Selection))
                {
                    liquidProperties.Value1 = column1Selection;

                    if (liquidProperties.Value1 != column1Selection)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value1 + " != " + column1Selection);
                        result = false;
                    }
                }

                if (this.IsValid(column1Minimum))
                {
                    liquidProperties.Value1Min = column1Minimum;

                    if (liquidProperties.Value1Min != column1Minimum)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value1Min + " != " + column1Minimum);
                        result = false;
                    }
                }

                if (this.IsValid(column1Max))
                {
                    liquidProperties.Value1Max = column1Max;

                    if (liquidProperties.Value1Max != column1Max)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value1Max + " != " + column1Max);
                        result = false;
                    }
                }

                if (this.IsValid(column1Unit))
                {
                    liquidProperties.Value1Unit = column1Unit;

                    if (liquidProperties.Value1Unit != column1Unit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value1Unit + " != " + column1Unit);
                        result = false;
                    }
                }

                if (this.IsValid(column2Selection))
                {
                    liquidProperties.Value2 = column2Selection;

                    if (liquidProperties.Value2 != column2Selection)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value2 + " != " + column2Selection);
                        result = false;
                    }
                }

                if (this.IsValid(column2Minimum))
                {
                    liquidProperties.Value2Min = column2Minimum;

                    if (liquidProperties.Value2Min != column2Minimum)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value2Min + " != " + column2Minimum);
                        result = false;
                    }
                }

                if (this.IsValid(column2Max))
                {
                    liquidProperties.Value2Max = column2Max;

                    if (liquidProperties.Value2Max != column2Max)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value2Max + " != " + column2Max);
                        result = false;
                    }
                }

                if (this.IsValid(column2Unit))
                {
                    liquidProperties.Value2Unit = column2Unit;

                    if (liquidProperties.Value2Unit != column2Unit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value2Unit + " != " + column2Unit);
                        result = false;
                    }
                }

                if (this.IsValid(column3Selection))
                {
                    liquidProperties.Value3 = column3Selection;

                    if (liquidProperties.Value3 != column3Selection)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value3 + " != " + column3Selection);
                        result = false;
                    }
                }

                if (this.IsValid(column3Minimum))
                {
                    liquidProperties.Value3Min = column3Minimum;

                    if (liquidProperties.Value3Min != column3Minimum)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value3Min + " != " + column3Minimum);
                        result = false;
                    }
                }

                if (this.IsValid(column3Max))
                {
                    liquidProperties.Value3Max = column3Max;

                    if (liquidProperties.Value3Max != column3Max)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value3Max + " != " + column3Max);
                        result = false;
                    }
                }

                if (this.IsValid(column3Unit))
                {
                    liquidProperties.Value3Unit = column3Unit;

                    if (liquidProperties.Value3Unit != column3Unit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.Value3Unit + " != " + column3Unit);
                        result = false;
                    }
                }
            }     
       
            return result;
        }


        /// <summary>
        /// Configures tab Liquid Properties when Fine Tuning is activated. To skip a parameter, use an empty string.
        /// </summary>
        /// <param name="fineTuningValue1Unit">The fine tuning value1 unit.</param>
        /// <param name="fineTuningValue2Unit">The fine tuning value2 unit.</param>
        /// <param name="fineTuningValue3Unit">The fine tuning value3 unit.</param>
        /// <returns><c>true</c> if configured, <c>false</c> otherwise.</returns>
        public bool Run(string fineTuningValue1Unit, string fineTuningValue2Unit, string fineTuningValue3Unit)
        {
            bool result = true;
            var liquidProperties = new LiquidProperties();

            if ((new Container()).SelectTabLiquidProperties() == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open tab [Liquid Properties].");
                result = false;
            }
            else
            {
                if (this.IsValid(fineTuningValue1Unit))
                {
                    liquidProperties.FineTuningValue1Unit = fineTuningValue1Unit;

                    if (liquidProperties.FineTuningValue1Unit != fineTuningValue1Unit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Input Format] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.FineTuningValue1Unit + " != " + fineTuningValue1Unit);
                        result = false;
                    }
                }

                if (this.IsValid(fineTuningValue2Unit))
                {
                    liquidProperties.FineTuningValue2Unit = fineTuningValue2Unit;

                    if (liquidProperties.FineTuningValue2Unit != fineTuningValue2Unit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Spreadsheet] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.FineTuningValue2Unit + " != " + fineTuningValue2Unit);
                        result = false;
                    }
                }

                if (this.IsValid(fineTuningValue3Unit))
                {
                    liquidProperties.FineTuningValue3Unit = fineTuningValue3Unit;

                    if (liquidProperties.FineTuningValue3Unit != fineTuningValue3Unit)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring Base settings [Average Process Pressure] failed");
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), liquidProperties.FineTuningValue3Unit + " != " + fineTuningValue3Unit);
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