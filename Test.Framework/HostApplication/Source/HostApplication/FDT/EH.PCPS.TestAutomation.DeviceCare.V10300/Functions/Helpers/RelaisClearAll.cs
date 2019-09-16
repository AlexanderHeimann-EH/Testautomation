/*
 * Created by Ranorex
 * User: testadmin
 * Date: 25/06/2014
 * Time: 13:30
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
    /// Description of resetallrelais.
    /// </summary>
    [TestModule("AE6F1A0D-60A4-404D-AB91-B28BA46E93F7", ModuleType.UserCode, 1)]
    public class RelaisClearAll : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public RelaisClearAll()
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
            
            bool result = false;
            EH.PCPS.TestAutomation.Common.Relay.RelayAccessMethodsDeditec.SetAll(0,0, out result);

        
        }
    }
}
