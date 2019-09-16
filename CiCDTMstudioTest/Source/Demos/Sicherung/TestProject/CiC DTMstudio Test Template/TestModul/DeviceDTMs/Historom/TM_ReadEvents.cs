/*
 * Created by Ranorex
 * User: testadmin
 * Date: 06.06.2013
 * Time: 7:24 
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

namespace ProTof_Testlibrary.TestModule.DeviceFunction.Historom
{
    /// <summary>
    /// Description of TM_ReadEvents.
    /// </summary>
    public class TM_ReadEvents 
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
            
            return DeviceFunctionLoader.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution.RunSelectTab.Run(1)
			    && DeviceFunctionLoader.CoDIA.Historom.Flows.ReadWithWaiting.RunViaIcon()
			    && DeviceFunctionLoader.CoDIA.Historom.Flows.CheckGUIAfterReadingOrLoading.Run()
			    && DeviceFunctionLoader.CoDIA.Historom.Flows.CheckStatusInfo.Run();
        }
    }
}
