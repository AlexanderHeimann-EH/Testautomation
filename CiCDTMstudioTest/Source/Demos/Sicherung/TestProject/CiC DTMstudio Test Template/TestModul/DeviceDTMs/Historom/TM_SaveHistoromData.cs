/*
 * Created by Ranorex
 * User: testadmin
 * Date: 06.06.2013
 * Time: 7:29 
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
    /// Description of TM_SaveHistoromData.
    /// </summary>
    public class TM_SaveHistoromData 
    {
        public static string FileNameSave = "";
     
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
            
            return DeviceFunctionLoader.CoDIA.Historom.Flows.SaveFileAs.Run(FileNameSave)
			    && DeviceFunctionLoader.CoDIA.Historom.Flows.CheckStatusInfo.Run();
        }
    }
}
