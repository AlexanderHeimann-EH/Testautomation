/*
 * Created by Ranorex
 * User: testadmin
 * Date: 09/02/2015
 * Time: 09:01
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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers
{
	/// <summary>
	/// Description of SetInstallationPathVariable.
	/// </summary>
	[TestModule("BD0A5529-3FC8-48D5-8E0C-495BE0644FEE", ModuleType.UserCode, 1)]
	public class SetInstallationPathVariable : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public SetInstallationPathVariable()
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
			
			//get random number via Modulo operator
			
//			int randomNumber = System.DateTime.Now.Day % DataSources.Get("pathOfInstallation").Rows.Count;
//			
//			string actualInstallPath = DataSources.Get("pathOfInstallation").Rows[randomNumber].Values[0];
//			Report.Info("actual install path: " + actualInstallPath);
			
			TestSuite.Current.Parameters["InstallationPath"] = @"C:\Program Files (x86)\Endress+Hauser\DeviceCare"/*actualInstallPath*/;
		}
	}
}
