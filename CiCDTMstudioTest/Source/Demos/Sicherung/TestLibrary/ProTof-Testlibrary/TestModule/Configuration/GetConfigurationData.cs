/*
 * Created by Ranorex
 * User: testadmin
 * Date: 24.09.2012
 * Time: 6:34 
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

namespace ProTof_Testlibrary.TestModule.Configuration
{
    /// <summary>
    /// Description of GetConfigurationData.
    /// </summary>
    [TestModule("0A15D0C5-2A2B-4175-AC2A-9912FE6491A0", ModuleType.UserCode, 1)]
    public class GetConfigurationData : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public GetConfigurationData()
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
       		//Loader.SystemConfiguration.GetConfig(@"C:\Users\testadmin\Desktop\TestLibrary\ConfigData\SystemConfig.xml");
       		Common.Configuration.SystemConfiguration.GetConfig(@"D:\Users\i02401156\Desktop\TestLibrary\ConfigData\SystemConfig.xml");
        }
    }
}
