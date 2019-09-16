/*
 * Created by Ranorex
 * User: testadmin
 * Date: 22/05/2014
 * Time: 10:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using Ranorex;
using Ranorex.Core.Testing;
namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_ScanResult.Execution
{
    using System.Diagnostics.CodeAnalysis;
    /// <summary>
	/// Description of OpenDevice.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed. Suppression is OK here."),TestModule("F65198F1-F214-4D0A-B0A1-17485BA2588F", ModuleType.UserCode, 1)]
	public class OpenDevice : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public OpenDevice()
		{
			// Do not delete - a parameterless constructor is required!
		}
		
		string _Device_InterfaceText_Buton = "";
		/// <summary>
		/// 
		/// </summary>
		[TestVariable("1C43AC5E-B203-45D2-B74A-D96A348B704B")]
		public string Device_InterfaceText_Buton
		{
			get { return _Device_InterfaceText_Buton; }
			set { _Device_InterfaceText_Buton = value; }
		}
		
		string _Device_Name = "";
		/// <summary>
		/// 
		/// </summary>
		[TestVariable("5340981B-BA3E-43E1-ACE4-8290AC331D0E")]
		public string Device_Name
		{
			get { return _Device_Name; }
			set { _Device_Name = value; }
		}
		
        /// <summary>
		/// Performs the playback of actions in this module.
		/// </summary>
		/// <remarks>You should not call this method directly, instead pass the module
		/// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
		/// that will in turn invoke this method.</remarks>
		[SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed. Suppression is OK here.")]
		void ITestModule.Run()
		{
			Mouse.DefaultMoveTime = 300;
			Keyboard.DefaultKeyPressTime = 100;
			Delay.SpeedFactor = 1.0;
			
			if ( Device_Name != "DEV01" && Device_Name != "DEV05" &&  Device_Name != "DEV06" && Device_Name != "DEV15"&& Device_Name != "DEV07" &&Device_Name != "DEV14" &&Device_Name != "DEV13"&&Device_Name != "DEV12" &&Device_Name != "DEV03" )
			{
				//Error message
				Report.Failure ("The Device Name don't match with the established in program Please Revew this script");
			}
			
			else
			{
				
				
				Ranorex.Report.Info( " Open Device " + Device_Name+ " if the Button is displayed ");
				
				var repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;
				
				if ( Device_InterfaceText_Buton != "")
					
				{
					repo.DeviceName = Device_InterfaceText_Buton;
					
					var deviceButton = repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.Device_Search.DeviceButton;
					try{
						Report.Screenshot();
						deviceButton.Click ();
						
					}
					catch(Exception ex) { Report.Warn("(Optional Action) " + ex.Message); }
				}
				
			}
			
		}
	}
}
