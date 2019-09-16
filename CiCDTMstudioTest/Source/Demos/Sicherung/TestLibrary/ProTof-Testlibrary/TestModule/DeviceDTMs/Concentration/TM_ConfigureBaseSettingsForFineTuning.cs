/*
 * Created by Ranorex
 * User: Administrator
 * Date: 04/02/2014
 * Time: 14:32
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

namespace ProTof_Testlibrary.TestModule.DeviceDTMs.Concentration
{
    /// <summary>
    /// Description of TM_ConfigureBaseSettingsForFineTuning.
    /// </summary>
    [TestModule("37CA3A64-373D-4630-BC50-3B2A0BA50B08", ModuleType.UserCode, 1)]
    public class TM_ConfigureBaseSettingsForFineTuning : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_ConfigureBaseSettingsForFineTuning()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _concentrationMaxValue = "";
        [TestVariable("90E9929D-BE27-4B24-A57D-2853A07E1BF9")]
        public string concentrationMaxValue
        {
        	get { return _concentrationMaxValue; }
        	set { _concentrationMaxValue = value; }
        }
        
        string _concentrationMinValue = "";
        [TestVariable("6D3F0C28-A4CF-4DD1-AFB4-0B6BCC0840AB")]
        public string concentrationMinValue
        {
        	get { return _concentrationMinValue; }
        	set { _concentrationMinValue = value; }
        }
        
        string _concentrationUnit = "";
        [TestVariable("5F0181B8-C333-4EEB-9B95-FB1E28228E41")]
        public string concentrationUnit
        {
        	get { return _concentrationUnit; }
        	set { _concentrationUnit = value; }
        }
        
        string _temperatureMaxValue = "";
        [TestVariable("2DB14B0F-0F90-48DA-BEB1-FCD89B03DE5A")]
        public string temperatureMaxValue
        {
        	get { return _temperatureMaxValue; }
        	set { _temperatureMaxValue = value; }
        }
        
        string _temperaturMinValue = "";
        [TestVariable("8CAA0EDB-32A7-4EE6-B6A7-A381FFBB8706")]
        public string temperaturMinValue
        {
        	get { return _temperaturMinValue; }
        	set { _temperaturMinValue = value; }
        }
        
        string _temperaturUnit = "";
        [TestVariable("0941056E-0098-4D7D-A78C-4D3229B35825")]
        public string temperaturUnit
        {
        	get { return _temperaturUnit; }
        	set { _temperaturUnit = value; }
        }
        
        string _sensorValue = "";
        [TestVariable("E9029F9E-DC10-409B-8E3A-39F3238E7CEB")]
        public string sensorValue
        {
        	get { return _sensorValue; }
        	set { _sensorValue = value; }
        }
        
        string _fieldDensityAdjustment = "";
        [TestVariable("3383EB22-7541-4271-A2DC-E1283125A72A")]
        public string fieldDensityAdjustment
        {
        	get { return _fieldDensityAdjustment; }
        	set { _fieldDensityAdjustment = value; }
        }
        
        string _densityCalibration = "";
        [TestVariable("93744C4D-6AA1-4C10-BB0D-E0B1D3E14FFB")]
        public string densityCalibration
        {
        	get { return _densityCalibration; }
        	set { _densityCalibration = value; }
        }
        
        string _liquidType = "";
        [TestVariable("C63CB0B8-2AA3-4812-87B1-9D1CD9667BE3")]
        public string liquidType
        {
        	get { return _liquidType; }
        	set { _liquidType = value; }
        }
        
        string _calculationBase = "";
        [TestVariable("5AE23346-55E1-451B-A6F6-17E2DF084331")]
        public string calculationBase
        {
        	get { return _calculationBase; }
        	set { _calculationBase = value; }
        }
        
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
            bool isPassed = true;
                        
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.ConfigureBaseSettings.Run(calculationBase,liquidType,densityCalibration,fieldDensityAdjustment,sensorValue,temperaturUnit,temperaturMinValue,temperatureMaxValue,concentrationUnit,concentrationMinValue,concentrationMaxValue);
            
            if(isPassed)
			{	Report.Success("TM_ConcentrationRegressionBaseSettings", "Testmodule passed");	}
			else
			{	Report.Failure("TM_ConcentrationRegressionBaseSettings", "Testmodule failed");	}
        }	
        
    }
}
