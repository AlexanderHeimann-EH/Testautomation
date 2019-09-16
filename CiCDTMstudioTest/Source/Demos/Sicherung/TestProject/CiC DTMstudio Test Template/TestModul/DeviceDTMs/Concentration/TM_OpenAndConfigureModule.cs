/*
 * Created by Ranorex
 * User: Administrator
 * Date: 04/02/2014
 * Time: 14:28
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


namespace ProTof_Testlibrary.TestModule.DeviceDTMs.Concentration
{
    /// <summary>
    /// Description of TM_OpenAndConfigureModule.
    /// </summary>
    public class TM_OpenAndConfigureModule 
    {
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
            bool isPassed = true;
            
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.OpenModuleOnline.Run();
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Functions.MenuArea.Toolbar.Execution.OpenNew.ViaIcon();
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.Calculate.Run();
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.Write.Run();
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.Read.Run();
            
            if(isPassed)
			{
                //Report.Success("TM_ConcentrationRegressionBaseSettings", "Testmodule passed");	// AHHIER 
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
