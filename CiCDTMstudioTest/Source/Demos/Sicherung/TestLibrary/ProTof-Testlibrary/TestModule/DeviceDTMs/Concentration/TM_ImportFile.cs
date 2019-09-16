/*
 * Created by Ranorex
 * User: Administrator
 * Date: 04/02/2014
 * Time: 14:44
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

namespace ProTof_Testlibrary.TestModule.DeviceDTMs.Concentration
{
    /// <summary>
    /// Description of TM_ImportFile.
    /// </summary>
    [TestModule("50E4A03A-CEB4-4568-A6F2-590331AF9EB9", ModuleType.UserCode, 1)]
    public class TM_ImportFile : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_ImportFile()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _filename = "";
        [TestVariable("AD8DD75D-4B46-4692-8231-B49FD6D81017")]
        public string filename
        {
        	get { return _filename; }
        	set { _filename = value; }
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
            bool isPassed = true;
            
            isPassed &= DeviceFunctionLoader.CoDIA.Concentration.Flows.Import.Run(filename);
            
            if(isPassed)
			{	Report.Success("TM_ConcentrationRegressionBaseSettings", "Testmodule passed");	}
			else
			{	Report.Failure("TM_ConcentrationRegressionBaseSettings", "Testmodule failed");	}
        }
    }
}
