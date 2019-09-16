/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 16.09.2015
 * Time: 18:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Assistant_ModemSelection
{
    using Protocol;
    using Ranorex;

    /// <summary>
    /// Description of Assistant_ModemSelection_Functions.
    /// </summary>
    public class Assistant_ModemSelection_Functions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Assistant_ModemSelection_Functions"/> class.
        /// </summary>
        public Assistant_ModemSelection_Functions()
        {}
        
        /// <summary>
        /// Selects a modem in the modem selection page
        /// Modem names and ProtocolNames can be parsed from Common.Protocol.'yourProtocol'
        /// </summary>
        /// <param name="protocolName">The protocolName of the modem</param>
        /// <param name="communicationHardwareName">The modem name to select</param>
        public void SelectModem(string protocolName, string communicationHardwareName)
        {
            var repo = GUI.DeviceCareApplication.Instance;

            if (protocolName == HART.protocolName & communicationHardwareName == HART.commHardwareFXA195)
            {
                // HART FXA195
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.HART.ButtonFXA195.Click();
            }
            else if (protocolName == HART.protocolName & communicationHardwareName == HART.commHardwareMactek)
            {
                // HART Mactek
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.HART.ButtonMacTekViator.Click();
            }
            else if (protocolName == HART.protocolName & communicationHardwareName == HART.commHardwareVector)
            {
                // HART Vector
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.HART.ButtonVectorInfotec.Click();
            }
            else if (protocolName == Profibus.protocolName & communicationHardwareName == Profibus.communicationHardwareNamePcmcia)
            {
                // Profibus PCMCIA
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.PROFIBUS.ButtonProfibusSoftingPCMCIA.Click();
            }
            else if (protocolName == Profibus.protocolName & communicationHardwareName == Profibus.communicationHardwareNameUsb)
            {
                // Profibus USB
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.PROFIBUS.ButtonProfibusSoftingUSB.Click();
            }
            else if (protocolName == FoundationFieldbus.protocolName & communicationHardwareName == FoundationFieldbus.communicationHardwareName)
            {
                // FF NI USB
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.FieldbusFOUNDATION.ButtonNIUSB.Click();
            }
            else if (protocolName == IPC.protocolName & communicationHardwareName == IPC.communicationHardwareName193)
            {
                // IPC FXA193
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.IPC.FXA193.Click();
            }
            else if (protocolName == IPC.protocolName & communicationHardwareName == IPC.communicationHardwareName291)
            {
                // IPC FXA291
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.IPC.FXA291.Click();
            }
            else if (protocolName == ISS.protocolName & communicationHardwareName == ISS.communicationHardwareName193)
            {
                // ISS FXA193
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.ISS.FXA193.Click();
            }
            else if (protocolName == PCP.protocolName & communicationHardwareName == PCP.communicationHardwareName291)
            {
                // PCP FXA291
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.PCP.FXA291.Click();
            }
            else if (protocolName == PCP.protocolName & communicationHardwareName == PCP.communicationHardwareName10)
            {
                // PCP TXU10
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.PCP.TXU10.Click();
            }
            else if (protocolName == CDIFXA291.protocolName & communicationHardwareName == CDIFXA291.communicationHardwareName291)
            {
                // CDI FXA291
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.CDI.ButtonCDIFXA291.Click();
            }
            else if (protocolName == CDIFXA291.protocolName & communicationHardwareName == CDIFXA291.communicationHardwareName10)
            {
                // CDI TXU10
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.CDI.ButtonCDITXU10.Click();
            }
            else if (protocolName == CDIUSB.protocolName)
            {
                // CDI USB
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.CDI.ButtonCDIUSB.Click();
            }
            else if (protocolName == CDITCPIP.protocolName)
            {
                // CDI TCP IP
                repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.CDI.ButtonCDIEthernet.Click();
            }
            else
            {
                Report.Failure(string.Format("Modem: {0} for Protocol: {1} was not found. Either the driver is not installed or it is non-existant", communicationHardwareName, protocolName));
            }
        }
    }
}
