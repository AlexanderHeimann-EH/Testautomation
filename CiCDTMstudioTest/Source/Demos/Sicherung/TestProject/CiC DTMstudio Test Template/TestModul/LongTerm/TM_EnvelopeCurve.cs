/*
 * Created by Ranorex
 * User: testadmin
 * Date: 12.10.2012
 * Time: 7:01 
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

namespace ProTof_Testlibrary.TestModule.LongTerm
{
    /// <summary>
    /// Description of TM_EnvelopeCurve.
    /// </summary>
    [TestModule("16E61F36-D821-41F0-A741-1F41684F3B9A", ModuleType.UserCode, 1)]
    public class TM_EnvelopeCurve : ITestModule
    {
    	
    	string _deviceName = "";
    	[TestVariable("72EAB50F-70BA-4DFA-9FB4-78A0BE5DFD1A")]
    	public string deviceName
    	{
    		get { return _deviceName; }
    		set { _deviceName = value; }
    	}
    	
    	
    	string _projectName = "";
    	[TestVariable("393A7411-4439-4002-9BDA-D444D662FEB2")]
    	public string projectName
    	{
    		get { return _projectName; }
    		set { _projectName = value; }
    	}
    	
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_EnvelopeCurve()
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
            bool isPassed = true;
        	
            isPassed &= Testlibrary.TestModules.Frame.TM_StartFrameFieldCareWithDefault.Run();
			isPassed &= Testlibrary.TestModules.Frame.TM_ProjectLoadViaTextField.Run(projectName);
			isPassed &= Testlibrary.TestModules.Frame.TM_FindDevice.Run(deviceName);
			isPassed &= Testlibrary.TestModules.Frame.TM_ConnectCurrentDeviceViaIcon.Run();
			
			isPassed &= Testlibrary.TestModules.DeviceDTM.TM_OpenDTMModuleViaMenuWithWaiting.Run(Common.ModuleNames.EnvelopeCurveEN);
			isPassed &= Testlibrary.TestModules.DeviceDTM.EnvelopeCurve.TM_CloseEnvelopeCurveWithoutSaving.Run();
			
			isPassed &= Testlibrary.TestModules.Frame.TM_ProjectClose.Run("", false);
			isPassed &= Testlibrary.TestModules.Frame.TM_ExitFrame.Run();
			
			if(isPassed){ Report.Success("- TM_EnvelopeCurve", "Module is executed successfully."); }
			else { Report.Error("- TM_EnvelopeCurve", "Module is not executed successfully."); }
        }
    }
}
