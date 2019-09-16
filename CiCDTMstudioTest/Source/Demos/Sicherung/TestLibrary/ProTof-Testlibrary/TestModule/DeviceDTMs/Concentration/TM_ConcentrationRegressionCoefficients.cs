/*
 * Created by Ranorex
 * User: Administrator
 * Date: 18/07/2013
 * Time: 12:40
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
    /// Description of TM_ConcentrationRegressionCoefficients.
    /// </summary>
    [TestModule("ADD14C6B-65FB-44F4-ABE5-462F2EE5AAA4", ModuleType.UserCode, 1)]
    public class TM_ConcentrationRegressionCoefficients : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_ConcentrationRegressionCoefficients()
        {
            // Do not delete - a parameterless constructor is required!
        }

        #region coefficients
        string _a0Value = "";
        [TestVariable("125365DC-575F-467A-BD36-C438D5C8D16E")]
        public string a0Value
        {
        	get { return _a0Value; }
        	set { _a0Value = value; }
        }
        
        string _a1Value = "";
        [TestVariable("6578D1E1-D331-48D9-B4FE-D0DB6F6D5A85")]
        public string a1Value
        {
        	get { return _a1Value; }
        	set { _a1Value = value; }
        }
        string _a2Value = "";
        [TestVariable("71FDF9CA-770A-48A4-985D-F0D40533BD54")]
        public string a2Value
        {
        	get { return _a2Value; }
        	set { _a2Value = value; }
        }
        
        string _a3Value = "";
        [TestVariable("E4113041-553E-47F9-A6A5-5BF9120D62DC")]
        public string a3Value
        {
        	get { return _a3Value; }
        	set { _a3Value = value; }
        }
        string _a4Value = "";
        [TestVariable("A0F4DD81-136B-424A-8465-1FC72783653C")]
        public string a4Value
        {
        	get { return _a4Value; }
        	set { _a4Value = value; }
        }
        
        string _b1Value = "";
        [TestVariable("5FD8F664-597D-40F3-8B62-90FC463424B5")]
        public string b1Value
        {
        	get { return _b1Value; }
        	set { _b1Value = value; }
        }
        
        string _b2Value = "";
        [TestVariable("74947DFC-8C7D-482C-BB29-41EE1BA44FD7")]
        public string b2Value
        {
        	get { return _b2Value; }
        	set { _b2Value = value; }
        }
        
        string _b3Value = "";
        [TestVariable("558C577C-DA51-4B4E-9C0C-76D3D9119056")]
        public string b3Value
        {
        	get { return _b3Value; }
        	set { _b3Value = value; }
        }
        
        string _coefficientsAccuracyValue = "";
        [TestVariable("276BD8DA-CCB2-41DE-A806-02D92E698DD2")]
        public string coefficientsAccuracyValue
        {
        	get { return _coefficientsAccuracyValue; }
        	set { _coefficientsAccuracyValue = value; }
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
            
            string[] expectedCoefficients = new string[]{a0Value, a1Value, a2Value, a3Value, a4Value, b1Value, b2Value, b3Value};
            
            Boolean isPassed = true;
            
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.Container.SelectTabCoefficientsOverview();
			isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.Calculate.Run();
//			isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.CoefficientsOverview.CompareCoefficients(Convert.ToDouble(coefficientsAccuracyValue), expectedCoefficients);
			isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.CoefficientsOverview.CompareCoefficients(0.001, expectedCoefficients);
			
			if(isPassed)
			{	Report.Success("TM_ConcentrationRegressionCoefficients", "Testmodule passed");	}
			else
			{	Report.Failure("TM_ConcentrationRegressionCoefficients", "Testmodule failed");	}
        }
    }
}
