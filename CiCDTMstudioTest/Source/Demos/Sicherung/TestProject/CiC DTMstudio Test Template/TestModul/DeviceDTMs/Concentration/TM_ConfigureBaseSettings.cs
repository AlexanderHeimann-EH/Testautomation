/*
 * Created by Ranorex
 * User: testadmin
 * Date: 12.11.2012
 * Time: 7:20 
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

//using DeviceDTMs.Modules.Concentration.Flows;

namespace ProTof_Testlibrary.TestModule.DeviceDTMs.Concentration
{
    /// <summary>
    /// Description of TM_ConfigureBaseSettings.
    /// </summary>
    public class TM_ConfigureBaseSettings 
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
            
            //(new ConfigureBaseSettings()).Run("Fluid", "Cubemass", "", "", "", "", "", "", "", "", "", "");  // AHHIER

            return true;
        }
    }
}
