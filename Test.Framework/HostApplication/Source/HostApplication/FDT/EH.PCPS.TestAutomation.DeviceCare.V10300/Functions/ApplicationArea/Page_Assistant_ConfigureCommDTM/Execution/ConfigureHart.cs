/*
 * Created by Ranorex
 * User: testadmin
 * Date: 10/06/2014
 * Time: 10:26
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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_Assistant_ConfigureCommDTM.Execution
{
	
	
	
	
	/// <summary>
	/// Description of ConfigureHart.
	/// </summary>
	[TestModule("C164283D-1EFC-4661-911C-7B09DCCCFD86", ModuleType.UserCode, 1)]
	public class ConfigureHart : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		static ConfigureHart instance = new ConfigureHart();

        /// <summary>
        /// 
        /// </summary>
        public ConfigureHart()
		{
			// Do not delete - a parameterless constructor is required!
		}

        /// <summary>
        /// 
        /// </summary>
        public static ConfigureHart Instance
		{
			get { return instance; }
		}


        /// <summary>
        /// 
        /// </summary>
        public string MaxValue="";

        /// <summary>
        /// 
        /// </summary>
        public string MinValue="";

        /// <summary>
        /// 
        /// </summary>
        public static void Start(string MaxVal, string MinVal)
		{
			ConfigureHart.instance.MaxValue = MaxVal ;
			ConfigureHart.instance.MinValue = MinVal;
			TestModuleRunner.Run(instance);
			
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
			
			var repo = GUI.DeviceCareApplication.Instance;
			
			
	
			if (repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ConfigureDeviceSearch.ComboComm.Text=="") 
			{
				Report.Failure( "No Usb compatible Devices are connected ");
			
			}
			
			Report.Log(ReportLevel.Info, "Set Value", "Set Text MinValue =" + MinValue +" and  MaxValue= "+ MaxValue+ ".");
			
			repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ConfigureDeviceSearch.AutomnIdC4DCTextBox2.Element.SetAttributeValue("Text",MaxValue);
			repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ConfigureDeviceSearch.AutomnIdC4DCTextBox1.Element.SetAttributeValue("Text",MinValue);
			
			
			//Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DeviceCare.ConnectionWizard.Button_Scan' at Center.", repo.DeviceCare.ConnectionWizard.Button_ScanInfo);
			//repo.DeviceCare.ConnectionWizard.Button_Scan.Click();
		}

	}
}
