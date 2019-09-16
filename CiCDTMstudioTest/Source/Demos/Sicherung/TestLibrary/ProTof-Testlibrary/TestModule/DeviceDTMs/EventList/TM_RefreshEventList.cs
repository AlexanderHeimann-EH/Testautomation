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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ProTof_Testlibrary.TestModule
{
    /// <summary>
    /// Description of TC_RefreshEventList.
    /// </summary>
    [TestModule("F92C7272-89AD-4899-BF00-D2CF6173D0D6", ModuleType.UserCode, 1)]
    public class TM_RefreshEventList : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_RefreshEventList()
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
        	Testlibrary.TestModules.DeviceDTM.EventList.TM_RefreshEventList.Run();
        }
    }
}
