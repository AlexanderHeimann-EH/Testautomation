/*
 * Created by Ranorex
 * User: Tina Bertos
 * Date: 11/09/2015
 * Time: 14:06
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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.StatusArea.Statusbar.Validation
{
    /// <summary>
    /// Description of DummyStausbarTryout.
    /// </summary>
    [TestModule("5261F0A7-8C05-4473-A928-692C47A968BE", ModuleType.UserCode, 1)]
    public class DummyStausbarTryout : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public DummyStausbarTryout()
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
            
            
            Statusbar_Functions getUSBCommunicationUnit = new Statusbar_Functions();
            getUSBCommunicationUnit.CommunicationUnit = Protocol.HART.commHardwareFXA195;
            if(!getUSBCommunicationUnit.IsCommunicationUnitRecognized())
            {
               Report.Failure("No suitable unit has been found.");
            }
            else
            {
               Report.Success("Device is connected.");
            }
            
            
        }
    }
}
