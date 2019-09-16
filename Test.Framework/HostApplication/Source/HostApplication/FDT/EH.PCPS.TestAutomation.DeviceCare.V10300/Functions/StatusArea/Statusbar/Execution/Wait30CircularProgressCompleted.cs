/*
 * Created by Ranorex
 * User: testadmin
 * Date: 23/06/2014
 * Time: 16:29
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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.StatusArea.Statusbar.Execution
{
	/// <summary>
	/// Description of waitCircularProgress.
	/// </summary>
	[TestModule("9D69336C-5C67-46BF-9154-8660EA894FB7", ModuleType.UserCode, 1)]
	public class Wait30CircularProgressCompleted : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public Wait30CircularProgressCompleted()
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
			
			Report.Log(ReportLevel.Info, "Delay", "Waiting for the end of the task");
			
			var startTime= System.DateTime.UtcNow;
			
			var repo = GUI.DeviceCareApplication.Instance;
			var progressIndicator = repo.DeviceCare.ApplicationArea.Page_ProgressIndicator;
			
			
			while ( progressIndicator.Self.Visible == true && startTime.AddMinutes(30) > System.DateTime.UtcNow )
			{
				
			}
			
			//Report.Log ( ReportLevel.Info, "total time =" + (start.AddMinutes(30) - System.DateTime.UtcNow));
			if   (startTime.AddMinutes(30) < System.DateTime.UtcNow)
			{
				Report.Log( ReportLevel.Error, "  is not visible after 30 min ");
				Report.Failure( "The program is taking To long >30min ");
				
			}
		}
	}
}
