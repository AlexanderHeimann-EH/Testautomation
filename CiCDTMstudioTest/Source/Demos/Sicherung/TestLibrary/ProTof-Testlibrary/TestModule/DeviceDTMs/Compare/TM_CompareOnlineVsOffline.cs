/*
 * Created by Ranorex
 * User: testadmin
 * Date: 27.09.2012
 * Time: 10:06 
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

namespace ProTof_Testlibrary.TestModule.DeviceFunction.Compare
{
    /// <summary>
    /// Description of TM_CompareOnlineVsOffline.
    /// </summary>
    [TestModule("D2BD0DEB-E5A7-416A-8925-EDAA78FF6B19", ModuleType.UserCode, 1)]
    public class TM_CompareOnlineVsOffline : ITestModule
    {
    	string _timeout = "100";
    	[TestVariable("CE90712A-3DAF-4090-8F30-8A4655070986")]
    	public string timeout
    	{
    		get { return _timeout; }
    		set { _timeout = value; }
    	}
    	
    	string _selectionMode = "\"\"";
    	[TestVariable("E4866181-BCEF-4FBE-975E-A43803862E62")]
    	public string selectionMode
    	{
    		get { return _selectionMode; }
    		set { _selectionMode = value; }
    	}
    	
    	
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_CompareOnlineVsOffline()
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
            bool isPassed = true;
            
            isPassed &= DeviceFunctionLoader.CoDIA.Compare.Flows.SelectMode.Run(selectionMode);
            if(isPassed){ Report.Success("- TM_CompareOnlineVsOffline", "Mode [" + "Compare offline with online" + "] is selected successfully."); }
			else { Report.Error("- TM_CompareOnlineVsOffline", "Mode [" + "Compare offline with online" + "] is not selected."); }
        	
			isPassed &= DeviceFunctionLoader.CoDIA.Compare.Flows.Compare.Run(System.Convert.ToInt32(timeout));
			if(isPassed){ Report.Success("- TM_CompareOnlineVsOffline", "Compare finished successfully."); }
			else { Report.Error("- TM_CompareOnlineVsOffline", "Compare not successfull."); }
			
  
        }
    }
}
