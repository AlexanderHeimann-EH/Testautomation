/*
 * Created by Ranorex
 * User: Tina Bertos
 * Date: 07/10/2015
 * Time: 16:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers.Generics
{
    using System.Diagnostics.CodeAnalysis;

    using ApplicationArea.Page_Assistant_ConfigureCommDTM;
    using ApplicationArea.Page_Assistant_ModemSelection;
    using ApplicationArea.Page_Assistant_ProtocolSelection;
    using ApplicationArea.Page_Home;
    using EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.StatusArea.Statusbar;

    /// <summary>
	/// Connect device via assistant depending on the values passed in
	/// </summary>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed. Suppression is OK here.")]
    public class AssistantConnect: IGoOnline
	{
        /// <summary>
        /// The protocol Name
        /// </summary>
		private string protocolName;
        
        /// <summary>
        /// The protocal Name propertiy
        /// </summary>
		public string ProtocolName
		{
			get {return protocolName;}
			set {protocolName = value;}
		}
		
        /// <summary>
        /// The comm unit
        /// </summary>
		private string commUnit;

        /// <summary>
        /// The comm unit property
        /// </summary>
		public string CommUnit
		{
			get {return commUnit;}
			set {commUnit = value;}
		}

        //TODO: Create summary
        //		Add validation structure
        //		Add comments
        /// <summary>
        /// The Go Online
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed. Suppression is OK here.")]
        public void GoOnline()
		{
			//instance required components
			Page_Home_Functions homeFunctions = new Page_Home_Functions();
			Assistant_ProtocolSelection_Function protocolSeletion = new Assistant_ProtocolSelection_Function();
			Assistant_ModemSelection_Functions modemSelection = new Assistant_ModemSelection_Functions();
			Assistant_ConfigureCommDTM_Functions configureCommDTM = new Assistant_ConfigureCommDTM_Functions();
			var connect = new InterfaceHelpers.OnlineConnectFunctions();
			Statusbar_Functions waitForConnection = new Statusbar_Functions();
			
			var repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;
			
			//Click button assistant on home page
			homeFunctions.ClickAssistant();
			
			if(connect.WaitForItemVisible(repo.ApplicationArea.ProtocolSelection.Text_Title_ProtocolInfo))
			{
				//select desired protocol
				Ranorex.Report.Info("Protocol page is shown. Selecting desired protocol...");
				protocolSeletion.SelectProtocol(this.protocolName);
				
				if(connect.WaitForItemVisible(repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.Text_Title_ModemInfo))
				{
					Ranorex.Report.Info("Modem page is shown. Selecting desired modem...");
					//select desired modem
					modemSelection.SelectModem(this.protocolName, this.commUnit);
					
					if(connect.WaitForItemVisible(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.SelfInfo))
					{
						Ranorex.Report.Info("Configuration page is shown. Opening advanced configuration...");
						//open advanced configuration
						configureCommDTM.OpenAdvancedConfiguration();
						
						if(connect.WaitForItemVisible(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.CommDTMHostingGUIInfo))
						{
							Ranorex.Report.Info("Device Configuration page is shown. Start scanning...");
							System.Threading.Thread.Sleep(5000);
							//scann device
							configureCommDTM.ClickScan();
							
							//check if scanning is in progress
							while(repo.DeviceCare.ApplicationArea.Page_ProgressIndicator.Self.Visible)
							{
								//watch for scan result: No device found.
								if(repo.DeviceCare.ApplicationArea.Page_ScanResult.Message_NoResultFound.Visible)
								{
									Ranorex.Report.Failure("Something somewhere went terribly wrong... No device found.");
									break;
								}
							}
							//check if desired page is displayed
							if(repo.DeviceCare.ApplicationArea.Page_ScanResult.Message_NoResultFound.Visible)
							{
								Ranorex.Report.Failure("Scan device failed.");
							}
							else if(repo.DeviceCare.ApplicationArea.Page_DeviceScreen.DTMHostingGUI.Visible)
							{
								Ranorex.Report.Success("Device has been scanned successfully.");
								Ranorex.Delay.Milliseconds(5000);
							}
						}
					}
				}
			}
		}
		
        /// <summary>
        /// The assistant connect
        /// </summary>
		public AssistantConnect()
		{
			this.ProtocolName = protocolName;
			this.CommUnit = commUnit;
		}
	}
}
