/*
 * Created by Ranorex
 * User: testadmin
 * Date: 18.04.2012
 * Time: 2:35 
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

namespace ProTof_Testlibrary.TestModule.DeviceFunction.EnvelopeCurve
{
    /// <summary>
    /// Description of LZT.
    /// </summary>
    [TestModule("873C4735-E5EC-42C1-8A99-C0995D7F7F05", ModuleType.UserCode, 1)]
    public class LZT : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public LZT()
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
        }
    }
}
