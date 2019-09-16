/*
 * Created by Ranorex
 * User: testadmin
 * Date: 22/01/2015
 * Time: 10:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Ranorex;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Settings.Execution
{
    /// <summary>
    /// Description of ChangeLanguage2.
    /// </summary>
    [TestModule("DF48697B-5B7B-46CC-8C7E-238CE4E6D57A", ModuleType.UserCode, 1)]
	public class ChangeLanguage : ITestModule
	{
        /// <summary>
        /// The culture Info
        /// </summary>
		string _CultureInfo = "";
        
        /// <summary>
        /// The Culture Info Property
        /// </summary>
		[TestVariable("43294280-0F36-4996-A98E-27745EA14BCC")]
		public string CultureInfo
		{
			get { return _CultureInfo; }
			set { _CultureInfo = value; }
		}
		
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public ChangeLanguage()
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
			

			if( Helpers.NavigateToLanguagePage.navigateToPage(_CultureInfo) )
			{
				var repo = EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication.Instance;
				repo.DeviceCare.ApplicationArea.Page_Settings.Page_Settings_Language.Button_LanguageViaCulture.Click();
				Report.Success("The language " + _CultureInfo + " is now selected: "
				               + repo.DeviceCare.ApplicationArea.Page_Settings.Page_Settings_Language.Button_LanguageViaCulture.Pressed.ToString());
			}
			else
			{
				Report.Failure("The language to select could not be found. Please check if the culture info is correct: " + _CultureInfo);
			}
		}
	}
}
