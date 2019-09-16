/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 16.09.2015
 * Time: 15:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using Ranorex;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Assistant_ConfigureCommDTM
{
	/// <summary>
	/// Description of Assistant_ConfigureCommDTM_Functions.
	/// </summary>
	public class Assistant_ConfigureCommDTM_Functions
	{
        /// <summary>
        /// The constructor
        /// </summary>
		public Assistant_ConfigureCommDTM_Functions()
		{
		}
		
		/// <summary>
		/// Clicks the scan button
		/// </summary>
		public void ClickScan()
		{
			var repo = GUI.DeviceCareApplication.Instance;
			
			repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.Button_Scan.Click();
		}
		
		/// <summary>
		/// Opens the advanced configuration page of a communication DTM
		/// </summary>
		public void OpenAdvancedConfiguration()
		{
			var repo = GUI.DeviceCareApplication.Instance;
			
			repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.MenuArea_CommDTM.ButtonAdvanced.Click();
		}
		
		
		/// <summary>
		/// Validates and waits for the advanced configuration page to exist
		/// </summary>
		/// <returns>True if the page exists</returns>
		public bool IsAdvancedConfigShown()
		{
			//This is a wrapper method which calls the generic function 'IsPageShown(RepoItemInfo item)'
			var repo = GUI.DeviceCareApplication.Instance;
			var ocf = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers.InterfaceHelpers.OnlineConnectFunctions();
			
			return ocf.WaitForItemVisible(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.CommDTMHostingGUIInfo);
		}
	}
}
