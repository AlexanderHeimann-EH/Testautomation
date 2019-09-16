/*
 * Created by Ranorex
 * User: testadmin
 * Date: 12.10.2012
 * Time: 7:02 
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
    /// Description of TM_OnlineParameterisation.
    /// </summary>
    [TestModule("9F601935-4E44-47C2-A051-1D1700C41A71", ModuleType.UserCode, 1)]
    public class TM_OnlineParameterisation : ITestModule
    {
    	
    	string _deviceName = "";
    	[TestVariable("F1CE93D7-5CC9-4BFE-8B0C-F2B572E41645")]
    	public string deviceName
    	{
    		get { return _deviceName; }
    		set { _deviceName = value; }
    	}
    	
    	
    	string _projectName = "";
    	[TestVariable("5C851C6A-B697-483A-A30D-F1653D3C6D8E")]
    	public string projectName
    	{
    		get { return _projectName; }
    		set { _projectName = value; }
    	}
    	
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_OnlineParameterisation()
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
			
			isPassed &= Testlibrary.TestModules.DeviceDTM.TM_OpenOnlineParameterisationWithWaiting.Run();
			isPassed &= Testlibrary.TestModules.DeviceDTM.Parameterization.TM_CheckHeaderParameterForState.Run("Status:", Common.Enumerations.ParameterState.Dynamic.ToString());
			isPassed &= Testlibrary.TestModules.DeviceDTM.TM_CloseDTMRelatedModuleViaWindow.Run(Common.ModuleNames.ParameterizeOnlineEN);

			isPassed &= Testlibrary.TestModules.Frame.TM_ProjectClose.Run("", false);
			isPassed &= Testlibrary.TestModules.Frame.TM_ExitFrame.Run();
			
			if(isPassed){ Report.Success("- TM_OnlineParameterisation", "Module is executed successfully."); }
			else { Report.Error("- TM_OnlineParameterisation", "Module is not executed successfully."); }
        }
    }
}
