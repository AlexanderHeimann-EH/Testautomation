/*
 * Created by Ranorex
 * User: testadmin
 * Date: 11.10.2012
 * Time: 1:58 
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
    /// Description of TM_CreateDocumentation.
    /// </summary>
    [TestModule("AB1682CF-9504-486D-9C51-B0241E655CD2", ModuleType.UserCode, 1)]
    public class TM_CreateDocumentation : ITestModule
    {
    	string _deviceName = "";
    	[TestVariable("762AE5C9-081D-4EAF-8688-CA621A851231")]
    	public string deviceName
    	{
    		get { return _deviceName; }
    		set { _deviceName = value; }
    	}
    	
    	
    	string _projectName = "";
    	[TestVariable("089BDD10-F9B9-4EC6-A480-CEE5043CD7AB")]
    	public string projectName
    	{
    		get { return _projectName; }
    		set { _projectName = value; }
    	}
    	
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_CreateDocumentation()
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
			
			isPassed &= Testlibrary.TestModules.DeviceDTM.TM_OpenDTMModuleViaMenuWithWaiting.Run(Common.ModuleNames.CreateDocumentationEN);
			isPassed &= Testlibrary.TestModules.DeviceDTM.CreateDocumentation.TM_CreateDocumentationAsPDF.Run("PDF " + System.DateTime.Now.ToString().Replace(":", "."));
			isPassed &= Testlibrary.TestModules.DeviceDTM.TM_CloseDTMRelatedModuleViaWindow.Run(Common.ModuleNames.CreateDocumentationEN);

			isPassed &= Testlibrary.TestModules.Frame.TM_ProjectClose.Run("", false);
			isPassed &= Testlibrary.TestModules.Frame.TM_ExitFrame.Run();
			
			if(isPassed){ Report.Success("- TM_CreateDocumentation", "Module is executed successfully."); }
			else { Report.Error("- TM_CreateDocumentation", "Module is not executed successfully."); }
			
			
        }
    }
}
