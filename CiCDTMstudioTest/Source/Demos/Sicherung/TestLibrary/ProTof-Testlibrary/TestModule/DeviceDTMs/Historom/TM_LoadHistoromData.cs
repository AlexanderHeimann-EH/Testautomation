/*
 * Created by Ranorex
 * User: testadmin
 * Date: 06.06.2013
 * Time: 7:31 
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
    /// Description of TM_LoadHistoromData.
    /// </summary>
    [TestModule("C34853A2-3C2C-44FE-8F23-8CA7EE6DF626", ModuleType.UserCode, 1)]
    public class TM_LoadHistoromData : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_LoadHistoromData()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _fileNameLoad = "";
        [TestVariable("90CE7865-DDF0-4C5C-BBE7-CB67B2F5C747")]
        public string fileNameLoad
        {
        	get { return _fileNameLoad; }
        	set { _fileNameLoad = value; }
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
            
            DeviceFunctionLoader.CoDIA.Historom.Flows.LoadFile.Run(fileNameLoad);
			DeviceFunctionLoader.CoDIA.Historom.Flows.CheckStatusInfo.Run();
        }
    }
}
