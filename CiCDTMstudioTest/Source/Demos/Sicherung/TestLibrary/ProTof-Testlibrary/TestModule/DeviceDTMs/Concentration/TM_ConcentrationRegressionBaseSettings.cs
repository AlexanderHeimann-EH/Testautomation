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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ProTof_Testlibrary.TestModule.DeviceFunction.Concentration
{
    /// <summary>
    /// Description of TM_ConcentrationRegression.
    /// </summary>
    [TestModule("35816200-E0DD-4BA3-B5A7-EBD849F3B56F", ModuleType.UserCode, 1)]
    public class TM_ConcentrationRegressionBaseSettings : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_ConcentrationRegressionBaseSettings()
        {
            // Do not delete - a parameterless constructor is required!
        }

        #region baseSettings
        string _calculationBaseValue = "";
        [TestVariable("54B650A9-20ED-42CA-85C2-D7CEB32D87F3")]
        public string calculationBaseValue
        {
        	get { return _calculationBaseValue; }
        	set { _calculationBaseValue = value; }
        }
        
        string _liquidTypeValue = "";
        [TestVariable("D6BDFAB5-C8CF-444A-963F-7ACD91751050")]
        public string liquidTypeValue
        {
        	get { return _liquidTypeValue; }
        	set { _liquidTypeValue = value; }
        }
        
        string _densityCalibrationValue = "";
        [TestVariable("44884A56-43BA-414B-BFC8-D0AEC116AAAA")]
        public string densityCalibrationValue
        {
        	get { return _densityCalibrationValue; }
        	set { _densityCalibrationValue = value; }
        }
        
        string _fieldDensityAdjustmentValue = "";
        [TestVariable("3D7BF9AA-F952-40F7-B727-8E22334B5C75")]
        public string fieldDensityAdjustmentValue
        {
        	get { return _fieldDensityAdjustmentValue; }
        	set { _fieldDensityAdjustmentValue = value; }
        }
        
        string _sensorValue = "";
        [TestVariable("649D12D2-33C7-44C5-A520-7FB79F2C45D7")]
        public string sensorValue
        {
        	get { return _sensorValue; }
        	set { _sensorValue = value; }
        }
        
        string _temperatureUnit = "";
        [TestVariable("4B3CD2CE-9941-485C-A01A-D8F9F6122C20")]
        public string temperaturUnit
        {
        	get { return _temperatureUnit; }
        	set { _temperatureUnit = value; }
        }
                
        string _temperatureMinValue = "";
        [TestVariable("BB267BF0-08D9-4F49-94A9-9EB58D27F5CA")]
        public string temperaturMinValue
        {
        	get { return _temperatureMinValue; }
        	set { _temperatureMinValue = value; }
        }
        string _temperatureMaxValue = "";
        [TestVariable("B598319F-AC1B-4DB0-989D-54A90DF74F5C")]
        public string temperatureMaxValue
        {
        	get { return _temperatureMaxValue; }
        	set { _temperatureMaxValue = value; }
        }
        
        string _concentrationUnit = "";
        [TestVariable("0A26D72B-8FE9-418E-B6CA-AD55D6D2723B")]
        public string concentrationUnit
        {
        	get { return _concentrationUnit; }
        	set { _concentrationUnit = value; }
        }
        string _concentrationMinValue = "";
        [TestVariable("46F26D92-6991-493D-9F11-C275EC39D261")]
        public string concentrationMinValue
        {
        	get { return _concentrationMinValue; }
        	set { _concentrationMinValue = value; }
        }
        
        string _concentrationMaxValue = "";
        [TestVariable("555037D4-B3DD-4D87-B497-3DDC589E930F")]
        public string concentrationMaxValue
        {
        	get { return _concentrationMaxValue; }
        	set { _concentrationMaxValue = value; }
        }
        #endregion
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Boolean isPassed = true;
            			
			isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.Container.SelectTabBaseSettings();
			isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.ConfigureBaseSettings.Run(
				calculationBaseValue, liquidTypeValue, densityCalibrationValue, 
				fieldDensityAdjustmentValue, sensorValue, 
				temperaturUnit, temperaturMinValue, temperatureMaxValue, 
				concentrationUnit, concentrationMinValue, concentrationMaxValue);
			
			if(isPassed)
			{	Report.Success("TM_ConcentrationRegressionBaseSettings", "Testmodule passed");	}
			else
			{	Report.Failure("TM_ConcentrationRegressionBaseSettings", "Testmodule failed");	}
		}
    }
}
