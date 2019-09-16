/*
 * Created by Ranorex
 * User: testadmin
 * Date: 30/04/2014
 * Time: 08:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Drawing;

using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_DeviceScreen.Execution
{
	/// <summary>
	/// Description of UserCodeModule1.
	/// </summary>
	[TestModule("7765DB42-1368-4C6B-B5D1-CAE00EE0A56B", ModuleType.UserCode, 1)]
	public class OpenOnlineFunction : ITestModule
	{
        /// <summary>
        /// 
        /// </summary>
		public static GUI.DeviceCareApplication repo = GUI.DeviceCareApplication.Instance;
		
        /// <summary>
		/// Constructs a new instance.
		/// </summary>
		public OpenOnlineFunction( )
		{
			// Do not delete - a parameterless constructor is required!
		}
		
        /// <summary>
        /// 
        /// </summary>
		string _ID_Function = "";

        /// <summary>
        /// 
        /// </summary>
		[TestVariable("C4FF54CF-FA06-4254-A3DE-1CE8B44902FC")]
		public string ID_Function
		{
			get { return _ID_Function; }
			set { _ID_Function = value; }
		}
		
        /// <summary>
        /// 
        /// </summary>
		string _Tip_Functions = "";

        /// <summary>
        /// 
        /// </summary>
		[TestVariable("C6345FB4-E033-413D-A786-492B6E813E55")]
		public string Tip_Functions
		{
			get { return _Tip_Functions; }
			set { _Tip_Functions = value; }
		}
		
        /// <summary>
        /// 
        /// </summary>
		string _Function = "";

        /// <summary>
        /// 
        /// </summary>
		[TestVariable("BE3FB2C9-3805-4C3D-8373-3F4B10D7E255")]
		public string Function
		{
			get { return _Function; }
			set { _Function = value; }
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
			
			string IDButtonSeparator="";
			string IDButtonFunction="";

			if (Tip_Functions == "A")
			{
				IDButtonSeparator="automId_AdditionalFunctions_28934B57-B7A9-4495-A44C-9225118A431C";
			}
			else if (Tip_Functions == "F")
			{
				IDButtonSeparator="automId_DtmFunctionsSeparator_3B0BFA3D-D193-4537-9C1F-709D2654ABD0";
			}
			else
			{
				Report.Failure ("Error in Input File");

			}
			IDButtonFunction ="automId_"+ ID_Function;

			int x,y;

			Report.Log(ReportLevel.Info, Function ,  " Open "+ Function , new RecordItemIndex(7));
			repo.DTM_MenuSeparator= IDButtonSeparator;
			
			//menu item
			
			
			var automIdMenuSeparator = repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.AutomIdMenuSeparator;
			Validate.Attribute(automIdMenuSeparator, "Visible", "True");
			automIdMenuSeparator.Click ();
			
			
			x=Mouse.Position.X;
			y=Mouse.Position.Y;
			Point point = new Point (x,(y+40));
			
			Mouse.MoveTo (point);
			//sub menuitem
			repo.Function  = IDButtonFunction;
			var functionBtn = repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.acess.SubMenu.FunctionBtn;
			
			Validate.Attribute(functionBtn, "Visible", "True");
			
			
			functionBtn.Click();

		}
	}
}
