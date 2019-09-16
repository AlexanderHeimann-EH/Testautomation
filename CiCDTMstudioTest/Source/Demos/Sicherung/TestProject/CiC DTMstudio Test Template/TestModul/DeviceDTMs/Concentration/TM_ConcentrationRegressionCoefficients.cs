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

namespace ProTof_Testlibrary.TestModule.DeviceFunction.Concentration
{
    /// <summary>
    /// Description of TM_ConcentrationRegressionCoefficients.
    /// </summary>
    public class TM_ConcentrationRegressionCoefficients 
    {
        #region coefficients
        public static string A0Value = "";
        public static string A1Value = "";
        public static string A2Value = "";
        public static string A3Value = "";
        public static string A4Value = "";
        public static string B1Value = "";
        public static string B2Value = "";
        public static string B3Value = "";
        public static string CoefficientsAccuracyValue = "";
        
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
            
            string[] expectedCoefficients = new string[]{A0Value, A1Value, A2Value, A3Value, A4Value, B1Value, B2Value, B3Value};
            
            Boolean isPassed = true;
            
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.Container.SelectTabCoefficientsOverview();
			isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.Calculate.Run();
//			isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.CoefficientsOverview.CompareCoefficients(Convert.ToDouble(coefficientsAccuracyValue), expectedCoefficients);
			isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.CoefficientsOverview.CompareCoefficients(0.001, expectedCoefficients);
			
			if(isPassed)
			{	
                //Report.Success("TM_ConcentrationRegressionCoefficients", "Testmodule passed");	// AHHIER
                return true;
            }
			else
			{	
                //Report.Failure("TM_ConcentrationRegressionCoefficients", "Testmodule failed");	// AHHIER
                return false;
            }
        }
    }
}
