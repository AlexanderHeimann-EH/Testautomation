/*
 * Created by Ranorex
 * User: testadmin
 * Date: 27.09.2012
 * Time: 10:06 
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

namespace ProTof_Testlibrary.TestModule.DeviceFunction.Compare
{
    /// <summary>
    /// Description of TM_CompareOnlineVsOffline.
    /// </summary>
    public class TM_CompareOnlineVsOffline 
    {
    	public static string Timeout = "100";
        public static string SelectionMode = "\"\"";
    
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
            
            isPassed &= DeviceFunctionLoader.CoDIA.Compare.Flows.SelectMode.Run(SelectionMode);
            if(isPassed)
            { 
                //Report.Success("- TM_CompareOnlineVsOffline", "Mode [" + "Compare offline with online" + "] is selected successfully."); // AHHIER
            }
			else 
            { 
                //Report.Error("- TM_CompareOnlineVsOffline", "Mode [" + "Compare offline with online" + "] is not selected."); // AHHIER
            }
        	
			isPassed &= DeviceFunctionLoader.CoDIA.Compare.Flows.Compare.Run(System.Convert.ToInt32(Timeout));
			if(isPassed)
            { 
                //Report.Success("- TM_CompareOnlineVsOffline", "Compare finished successfully."); // AHHIER
            }
			else 
            { 
                //Report.Error("- TM_CompareOnlineVsOffline", "Compare not successfull."); // AHHIER 
            }

            return true;
        }
    }
}
