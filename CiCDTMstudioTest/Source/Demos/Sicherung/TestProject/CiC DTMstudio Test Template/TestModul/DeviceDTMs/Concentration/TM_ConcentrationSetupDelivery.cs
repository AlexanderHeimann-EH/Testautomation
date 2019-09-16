/*
 * Created by Ranorex
 * User: Administrator
 * Date: 18/07/2013
 * Time: 10:57
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
    /// Description of TM_ConcentrationSetupDelivery.
    /// </summary>
    public class TM_ConcentrationSetupDelivery
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
            
            Testlibrary.TestCases.DeviceDTM.Concentration.TC_SetupDelivery.Run();

            return true;
        }
    }
}
