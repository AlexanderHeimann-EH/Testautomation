/*
 * Created by Ranorex
 * User: testadmin
 * Date: 12.10.2012
 * Time: 6:56 
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
    /// Description of TM_EventList.
    /// </summary>
    [TestModule("0E720080-F4C1-4A45-B9D4-B2A0E7E09398", ModuleType.UserCode, 1)]
    public class TM_EventList : ITestModule
    {
    	string _deviceName = "";
    	[TestVariable("60249A78-6BE7-4CFD-ABC4-3AE3293550FA")]
    	public string deviceName
    	{
    		get { return _deviceName; }
    		set { _deviceName = value; }
    	}
    	
    	string _projectName = "";
    	[TestVariable("930A9E84-8947-483B-8DB7-D6D51D31D5F2")]
    	public string projectName
    	{
    		get { return _projectName; }
    		set { _projectName = value; }
    	}
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_EventList()
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
			
			isPassed &= Testlibrary.TestModules.DeviceDTM.TM_OpenDTMModuleViaMenuWithWaiting.Run(Common.ModuleNames.EventListEN);
			isPassed &= Testlibrary.TestModules.DeviceDTM.EventList.TM_RefreshEventList.Run();
			isPassed &= Testlibrary.TestModules.DeviceDTM.TM_CloseDTMRelatedModuleViaWindow.Run(Common.ModuleNames.EventListEN);
			
			isPassed &= Testlibrary.TestModules.Frame.TM_ProjectClose.Run("", false);
			isPassed &= Testlibrary.TestModules.Frame.TM_ExitFrame.Run();
			
			if(isPassed){ Report.Success("- TM_EventList", "Module is executed successfully."); }
			else { Report.Error("- TM_EventList", "Module is not executed successfully."); }
        }
    }
}
