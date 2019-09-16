/*
 * Created by Ranorex
 * User: testadmin
 * Date: 06.06.2013
 * Time: 7:24 
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

namespace ProTof_Testlibrary.TestModule.DeviceFunction.Historom
{
    /// <summary>
    /// Description of TM_ReadEvents.
    /// </summary>
    [TestModule("7A1B2463-6751-4F2C-A5FF-940A8716D495", ModuleType.UserCode, 1)]
    public class TM_ReadEvents : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_ReadEvents()
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
            
            DeviceFunctionLoader.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution.RunSelectTab.Run(1);
			DeviceFunctionLoader.CoDIA.Historom.Flows.ReadWithWaiting.RunViaIcon();
			DeviceFunctionLoader.CoDIA.Historom.Flows.CheckGUIAfterReadingOrLoading.Run();
			DeviceFunctionLoader.CoDIA.Historom.Flows.CheckStatusInfo.Run();
        }
    }
}
