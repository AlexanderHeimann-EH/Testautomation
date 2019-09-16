/*
 * Created by Ranorex
 * User: testadmin
 * Date: 23.03.2012
 * Time: 2:51 
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

namespace ProTof_Testlibrary.TestModule
{
    /// <summary>
    /// Description of TM_FindDevice.
    /// </summary>
    [TestModule("700223A8-007C-4E11-84F9-20D8F3F79AD2", ModuleType.UserCode, 1)]
    public class TM_FindDevice : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_FindDevice()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        string _deviceName = "";
        [TestVariable("40A6A698-F8F1-4AB6-824D-7DCF91F16909")]
        public string deviceName
        {
        	get { return _deviceName; }
        	set { _deviceName = value; }
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
        	Testlibrary.TestModules.Frame.TM_FindDevice.Run(deviceName);
        }
    }
}
