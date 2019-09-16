/*
 * Created by Ranorex
 * User: testadmin
 * Date: 19.11.2012
 * Time: 6:39 
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

using Modules = DeviceFunction.CoDIA.Modules;

namespace ProTof_Testlibrary.TestModule.DeviceFunction.EventList
{
    /// <summary>
    /// Description of TM_CloseEventListViaWindow.
    /// </summary>
    [TestModule("0DA49D30-6976-4317-95F6-10B3B3F80F50", ModuleType.UserCode, 1)]
    public class TM_CloseEventListViaWindow : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_CloseEventListViaWindow()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
//            (new Modules.EventList.Flows.CloseModule()).Run();
			DeviceFunctionLoader.CoDIA.EventList.Flows.CloseModule.Run();
        }
    }
}
