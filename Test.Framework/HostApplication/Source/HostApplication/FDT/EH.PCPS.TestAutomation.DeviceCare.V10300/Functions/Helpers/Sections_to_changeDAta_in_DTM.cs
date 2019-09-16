/*
 * Created by Ranorex
 * User: testadmin
 * Date: 27/06/2014
 * Time: 12:32
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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers
{
    /// <summary>
    /// Description of Sections_to_changeDAta_in_DTM.
    /// </summary>
    [TestModule("0A531FC0-5A4B-445F-9C61-2FA20B7ED3D8", ModuleType.UserCode, 1)]
    public class Sections_to_changeDAta_in_DTM : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Sections_to_changeDAta_in_DTM()
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
