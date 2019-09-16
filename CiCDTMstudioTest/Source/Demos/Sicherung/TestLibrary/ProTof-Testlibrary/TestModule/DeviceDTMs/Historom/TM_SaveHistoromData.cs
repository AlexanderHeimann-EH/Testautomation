/*
 * Created by Ranorex
 * User: testadmin
 * Date: 06.06.2013
 * Time: 7:29 
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
    /// Description of TM_SaveHistoromData.
    /// </summary>
    [TestModule("516F6668-D781-48DC-9C46-6680A9CE3368", ModuleType.UserCode, 1)]
    public class TM_SaveHistoromData : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_SaveHistoromData()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _fileNameSave = "";
        [TestVariable("76CC976E-0317-454D-9C1E-7BB4DA6C5F4A")]
        public string fileNameSave
        {
        	get { return _fileNameSave; }
        	set { _fileNameSave = value; }
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
            
            DeviceFunctionLoader.CoDIA.Historom.Flows.SaveFileAs.Run(fileNameSave);
			DeviceFunctionLoader.CoDIA.Historom.Flows.CheckStatusInfo.Run();
        }
    }
}
