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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using DeviceDTMs.Modules.Concentration.Flows;

namespace ProTof_Testlibrary.TestModule.DeviceDTMs.Concentration
{
    /// <summary>
    /// Description of TM_ConfigureBaseSettings.
    /// </summary>
    [TestModule("5F749D24-7AC2-4B2A-8486-FED5534A2BF5", ModuleType.UserCode, 1)]
    public class TM_ConfigureBaseSettings : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_ConfigureBaseSettings()
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
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            (new ConfigureBaseSettings()).Run("Fluid", "Cubemass", "", "", "", "", "", "", "", "", "", "");
        }
    }
}
