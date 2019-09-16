/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 16.09.2015
 * Time: 17:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using EH.PCPS.TestAutomation.DeviceCare.V10300.Protocol;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Ranorex.Core.Repository;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_Assistant_ProtocolSelection
{
	/// <summary>
	/// Description of Assistant_ProtocolSelection_Function.
	/// </summary>
	public class Assistant_ProtocolSelection_Function
	{
        /// <summary>
        /// The constructor
        /// </summary>
		public Assistant_ProtocolSelection_Function()
		{
		}
		
		/// <summary>
		/// Selects a protocol from the protocol view page
		/// The protocol names can be parsed from Common.Protocol.'yourProtocol'
		/// </summary>
		/// <param name="protocolName">The protocol name to select</param>
		public void SelectProtocol(string protocolName)
		{
			var repo = GUI.DeviceCareApplication.Instance;

			switch (protocolName)
			{
				case HART.protocolName: //HART
					repo.ApplicationArea.ProtocolSelection.ButtonHART.Click();
					break;
				case Profibus.protocolName: //PROFIBUS
					repo.ApplicationArea.ProtocolSelection.ButtonPROFIBUS.Click();
					break;
				case FoundationFieldbus.protocolName: //FOUNDATION FIELDBUS
					repo.ApplicationArea.ProtocolSelection.ButtonFOUNDATIONFieldbus.Click();
					break;
				case CDITCPIP.protocolName: //CDI TCPIP
					repo.ApplicationArea.ProtocolSelection.ButtonServiceInterface.Click();
					repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonCDI.Click();
					break;
				case CDIFXA291.protocolName: //CDI FXA291
					repo.ApplicationArea.ProtocolSelection.ButtonServiceInterface.Click();
					repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonCDI.Click();
					break;
				case CDIUSB.protocolName: //CDI USB
					repo.ApplicationArea.ProtocolSelection.ButtonServiceInterface.Click();
					repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonCDI.Click();
					break;
				case IPC.protocolName: //IPC
					repo.ApplicationArea.ProtocolSelection.ButtonServiceInterface.Click();
					repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonIPC.Click();
					break;
				case ISS.protocolName: //ISS
					repo.ApplicationArea.ProtocolSelection.ButtonServiceInterface.Click();
					repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonISS.Click();
					break;
				case PCP.protocolName: //PCP
					repo.ApplicationArea.ProtocolSelection.ButtonServiceInterface.Click();
					repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonPCP.Click();
					break;
				default:
					Report.Failure(string.Format("Protocol: {0} was not found. Either it is not installed or non-existant",protocolName));
					break;
					
			}
		}
		
	}
}
