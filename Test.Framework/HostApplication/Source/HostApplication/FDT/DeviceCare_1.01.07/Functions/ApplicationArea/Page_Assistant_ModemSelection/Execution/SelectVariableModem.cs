/*
 * Created by Ranorex
 * User: testadmin
 * Date: 21/05/2014
 * Time: 16:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Ranorex;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Assistant_ModemSelection.Execution
{
    /// <summary>
    /// Description of OpenModem.
    /// </summary>
    [TestModule("39027A51-93FB-4C7A-BA5F-7ED59537142A", ModuleType.UserCode, 1)]
	public class SelectVariableModem : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public SelectVariableModem()
		{
			// Do not delete - a parameterless constructor is required!
		}

		/// <summary>
        /// 
        /// </summary>
		string _Modem = "";
		/// <summary>
		/// 
		/// </summary>
		[TestVariable("0CFEF94E-DC88-4D26-A9CB-FC867E83C042")]
		public string Modem
		{
			get { return _Modem; }
			set { _Modem = value; }
		}
		
		GUI.DeviceCareApplication repo = GUI.DeviceCareApplication.Instance;
		
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
			if (Modem != "FXA195" &&
			    Modem != "MacTekViator" &&
			    Modem != "SimulationHART"&&
			    Modem != "CDIFXA291" &&
			    Modem != "CDITXU10" &&
			    Modem != "CDIUSB" &&
			    Modem != "CDIEthernet" &&
			    Modem != "NIPCMCIA" &&
			    Modem != "NIUSB" &&
			    Modem != "FFSoftingUSB"&&
			    Modem != "ProfibusSoftingPCMCIA" &&
			    Modem != "ProfibusSoftingUSB" &&
			    Modem != "IPCFXA193" &&
			    Modem != "IPCFXA291"  &&
			    Modem != "PCPTXU10" &&
			    Modem != "PCPFXA291"&&
			    Modem != "ISSFXA193" &&
			    Modem != "ISSFXA291" )
				
				//Error message
				Report.Failure ("The Modem name don't match with the established in program please revew the ranorex - Open Modem- Code");
			
			
			else
			{
				
					
			//			 Report.Log(ReportLevel.Info, "Delay", "Waiting for 10s.", new RecordItemIndex(4));
            //Delay.Duration(10000, false); 
					
				repo.modem_name = "automId" +Modem;
				 Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item automId" + Modem, repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonProtocol_GeneralInfo, new RecordItemIndex(1));
				var ModemBTN = repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.ButtonModem_General;
			
				ModemBTN.EnsureVisible() ;
				
				
				Validate.Exists(ModemBTN);
				Validate.Attribute(ModemBTN, "Visible", "True");
				ModemBTN.Click();
			}			
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool WasSuccessful()
		{
			try
			{
				Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.SelfInfo, "Visible", "true");
				return true;
			}
			catch (ValidationException)
			{
				return false;
			}
		}
	}
}
