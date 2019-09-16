/*
 * Created by Ranorex
 * User: testadmin
 * Date: 22/01/2015
 * Time: 16:20
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

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Settings.Validation
{
	/// <summary>
	/// Description of CheckLanguagePage.
	/// </summary>
	[TestModule("170DB484-5CE4-4EB8-9FF0-5ACD6E296C90", ModuleType.UserCode, 1)]
	public class CheckLanguagePage : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public CheckLanguagePage()
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
			
			var repo = EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication.Instance;
			EH.PCPS.TestAutomation.Common.CSVConnector connector = new EH.PCPS.TestAutomation.Common.CSVConnector(@"../../../TC_DeviceCare/LanguagesWithIDs.csv");
			string notFoundLanguages = "";
			
			foreach (System.Data.DataRow row in connector.Rows)
			{
				string language = row[1].ToString();
				
				if( !Helpers.NavigateToLanguagePage.navigateToPage(language) )
				{
					notFoundLanguages = notFoundLanguages + language + ", ";
				}
			}
			
			if (notFoundLanguages.Equals(""))
			{
				Report.Success("All language buttons are available!");
			}
			else
			{
				Report.Failure("Following language buttons are not found: " + notFoundLanguages);
			}
		}		
	}
}
