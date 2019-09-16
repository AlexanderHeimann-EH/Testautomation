/*
 * Created by Ranorex
 * User: Administrator
 * Date: 08/01/2013
 * Time: 07:18
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
    /// Description of TM_CreateNewDiagramWithoutSavingAvailable.
    /// </summary>
    [TestModule("130E9CE2-2A38-47C8-A1A1-2B703B79CB31", ModuleType.UserCode, 1)]
    public class TM_CreateNewDiagramWithoutSavingAvailable : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_CreateNewDiagramWithoutSavingAvailable()
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
            
            Testlibrary.TestModules.DeviceDTM.EnvelopeCurve.TM_NewViaMenuDiscardAvailable.Run();
        }
    }
}
