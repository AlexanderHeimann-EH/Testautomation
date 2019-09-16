/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 10.08.2015
 * Time: 09:42
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
using System.IO;
using System.Collections;
using System.Diagnostics;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers.InterfaceHelpers
{
    /// <summary>
    /// Description of StartDC_NEW.
    /// </summary>
    [TestModule("60D32ADD-DED3-4F42-AF91-33F3DD587961", ModuleType.UserCode, 1)]
    public class RunDeviceCare : ITestModule
    {
       
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public RunDeviceCare()
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
            
            var module = new EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers.DeviceCareProcessFunctions();
            
            module.Run();
        }
    }
}
