/*
 * Created by Ranorex
 * User: testadmin
 * Date: 23/01/2015
 * Time: 08:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Ranorex;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_Settings.Validation
{
    /// <summary>
    /// Description of UserCodeModule1.
    /// </summary>
    [TestModule("7AB36E80-A504-4854-8E09-6B08B7ABC17A", ModuleType.UserCode, 1)]
	public class CheckSelectedLanguage : ITestModule
	{
		string _Culture = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("37A03683-AEEA-4E13-AE8C-7F679529506E")]
		public string Culture
		{
			get { return _Culture; }
			set { _Culture = value; }
		}
		
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public CheckSelectedLanguage()
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
			
			var repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;
			repo.Culture = _Culture;
			
			if (Helpers.NavigateToLanguagePage.navigateToPage(_Culture))
			{
				if (repo.DeviceCare.ApplicationArea.Page_Settings.Page_Settings_Language.Button_LanguageViaCulture.Pressed)
				{
					Report.Success("The language " + _Culture + " is selected!");
				}
				else
				{
					Report.Failure("The language " + _Culture + " is not selected!");
				}
			}
			else
			{
				Report.Failure("Language " + _Culture + " could not be found.");
			}
			
		}
	}
}
