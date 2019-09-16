/*
 * Created by Ranorex
 * User: Administrator
 * Date: 04/02/2014
 * Time: 14:50
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
    /// Description of TM_CompareAndClose.
    /// </summary>
    [TestModule("0E041292-0D6C-4819-99D1-BCFF8EC45AFC", ModuleType.UserCode, 1)]
    public class TM_CompareAndClose : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_CompareAndClose()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _accuracy = "";
        [TestVariable("7659230F-6F85-4DDB-AC26-A63BE27E73AC")]
        public string accuracy
        {
        	get { return _accuracy; }
        	set { _accuracy = value; }
        }
        
        string _b3Value = "";
        [TestVariable("19C9C98B-EC14-4464-A878-AACB76C88413")]
        public string b3Value
        {
        	get { return _b3Value; }
        	set { _b3Value = value; }
        }
        
        string _b2Value = "";
        [TestVariable("E01DFED9-27A5-4624-99D4-EC60CA34B777")]
        public string b2Value
        {
        	get { return _b2Value; }
        	set { _b2Value = value; }
        }
        
        string _b1Value = "";
        [TestVariable("9F449CA7-44CB-4533-AFF2-8C85DDF1E93E")]
        public string b1Value
        {
        	get { return _b1Value; }
        	set { _b1Value = value; }
        }
        
       
        
        string _a4Value = "";
        [TestVariable("76B4EBD3-555F-403C-9EFF-BA9BABB09F15")]
        public string a4Value
        {
        	get { return _a4Value; }
        	set { _a4Value = value; }
        }
        
        string _a3Value = "";
        [TestVariable("3C1F8821-C7EB-41A9-9E6F-38F53235DB8B")]
        public string a3Value
        {
        	get { return _a3Value; }
        	set { _a3Value = value; }
        }
        
        string _a2Value = "";
        [TestVariable("AFED0086-D63A-4205-B160-61A8E7C81585")]
        public string a2Value
        {
        	get { return _a2Value; }
        	set { _a2Value = value; }
        }
        
        string _a1Value = "";
        [TestVariable("65D9A1C6-BE29-4DFC-914D-1A536370D2A6")]
        public string a1Value
        {
        	get { return _a1Value; }
        	set { _a1Value = value; }
        }
        
        string _a0Value = "";
        [TestVariable("E43FBE89-B188-44B3-8182-ED32211AF970")]
        public string a0Value
        {
        	get { return _a0Value; }
        	set { _a0Value = value; }
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
            string[] expectedCoefficients = new string[]{a0Value, a1Value, a2Value, a3Value, a4Value, b1Value, b2Value, b3Value};
            bool isPassed = true;
            
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.Calculate.Run();
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.Container.SelectTabCoefficientsOverview();
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.CoefficientsOverview.CompareCoefficients(0.001, expectedCoefficients);
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.CloseModule.Run();
            
            if(isPassed)
			{	Report.Success("TM_ConcentrationRegressionBaseSettings", "Testmodule passed");	}
			else
			{	Report.Failure("TM_ConcentrationRegressionBaseSettings", "Testmodule failed");	}
        }
    }
}
