/*
 * Created by Ranorex
 * User: testadmin
 * Date: 26.03.2012
 * Time: 8:09 
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
    /// Description of TC_RefreshEventList.
    /// </summary>
    public class TM_RefreshEventList 
    {
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        public static bool Run()
        {
        	return Testlibrary.TestModules.DeviceDTM.EventList.TM_RefreshEventList.Run();
        }
    }
}
