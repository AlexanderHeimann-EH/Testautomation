/*
 * Created by Ranorex
 * User: testadmin
 * Date: 26.03.2012
 * Time: 6:52 
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

namespace ProTof_Testlibrary.TestModule
{
    /// <summary>
    /// Description of TM_CheckParameterForValue.
    /// </summary>
    public class TM_CheckParameterForValue 
    {
        public static string CheckParameter = "";
        public static string CheckValue = "";
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        public static bool Run()
        {
        	return Testlibrary.TestModules.DeviceDTM.Parameterization.TM_CheckParameterForValue.Run(CheckParameter, CheckValue);
        }
    }
}
