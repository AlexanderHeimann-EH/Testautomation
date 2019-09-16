/*
 * Created by Ranorex
 * User: Administrator
 * Date: 18/07/2013
 * Time: 10:57
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

namespace ProTof_Testlibrary.TestModule.DeviceFunction.Concentration
{
    /// <summary>
    /// Description of TM_ConcentrationSetupDelivery.
    /// </summary>
    [TestModule("27FB0013-44AC-47D5-A8D2-27366EFB3AB9", ModuleType.UserCode, 1)]
    public class TM_ConcentrationSetupDelivery : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_ConcentrationSetupDelivery()
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
            
            Testlibrary.TestCases.DeviceDTM.Concentration.TC_SetupDelivery.Run();
        }
    }
}
