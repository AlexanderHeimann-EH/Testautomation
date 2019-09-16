/*
 * Created by Ranorex
 * User: Administrator
 * Date: 18/07/2013
 * Time: 10:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

//using Ranorex;
//using Ranorex.Core;
//using Ranorex.Core.Testing;

namespace ProTof_Testlibrary.TestModule.DeviceFunction.Concentration
{
    /// <summary>
    /// Description of TM_ConcentrationRegression.
    /// </summary>
    public class TM_ConcentrationRegressionBaseSettings 
    {
        #region baseSettings

        public static string CalculationBaseValue = "";
        public static string LiquidTypeValue = "";
        public static string DensityCalibrationValue = "";
        public static string FieldDensityAdjustmentValue = "";
        public static string SensorValue = "";
        public static string TemperatureUnit = "";
        public static string TemperatureMinValue = "";
        public static string TemperatureMaxValue = "";
        public static string ConcentrationUnit = "";
        public static string ConcentrationMinValue = "";
        public static string ConcentrationMaxValue = "";

        #endregion
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        public static bool Run()
        {
            //Mouse.DefaultMoveTime = 300;
            //Keyboard.DefaultKeyPressTime = 100;
            //Delay.SpeedFactor = 1.0;
            
            Boolean isPassed = true;
            			
			isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.Container.SelectTabBaseSettings();
			isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.ConfigureBaseSettings.Run(
				CalculationBaseValue, LiquidTypeValue, DensityCalibrationValue, 
				FieldDensityAdjustmentValue, SensorValue,
                TemperatureUnit, TemperatureMinValue, TemperatureMaxValue, 
				ConcentrationUnit, ConcentrationMinValue, ConcentrationMaxValue);
			
			if(isPassed)
			{	
                // Report.Success("TM_ConcentrationRegressionBaseSettings", "Testmodule passed");	// AHHIER
                return true;
            }
			else
			{	
                //Report.Failure("TM_ConcentrationRegressionBaseSettings", "Testmodule failed");	// AHHIER
                return false;
            }
		}
    }
}
