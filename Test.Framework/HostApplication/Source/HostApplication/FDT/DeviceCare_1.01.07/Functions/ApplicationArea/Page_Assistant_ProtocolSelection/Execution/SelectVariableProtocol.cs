/*
 * Created by Ranorex
 * User: testadmin
 * Date: 21/05/2014
 * Time: 14:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Ranorex;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Assistant_ProtocolSelection.Execution
{
    /// <summary>
    /// Description of OpenProtocol.
    /// </summary>
    [TestModule("511CF5B5-0A13-41E8-87F3-79EB49CFF499", ModuleType.UserCode, 1)]
    public class SelectVariableProtocol : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectVariableProtocol()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _Protocol = "Hart";
        /// <summary>
        /// 
        /// </summary>
        [TestVariable("8B61BE1B-3851-4CD7-AD9C-ADD3A323F96C")]
        public string Protocol
        {
            get { return _Protocol; }
            set { _Protocol = value; }
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
            
            if ( Protocol != "Hart" && Protocol != "Profibus" && Protocol != "CDI" && Protocol != "FF" && Protocol != "SI-IPC" && Protocol != "SI-ISS"&& Protocol != "SI-PCP" && Protocol != "SI-CDI" )
            {
                
                //Error message
                Report.Failure ("The protocol don't match with the established in program");
            }
            
            else
            {
                
                repo.protocolselection = "automId" +Protocol ;
                
                
                if (Protocol == "SI-IPC" || Protocol == "SI-ISS"|| Protocol == "SI-PCP" || Protocol == "SI-CDI" )
                {
                    repo.protocolselection = "automId" + "StepServiceInterface";
                }
                var protocolButton = repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonProtocol_General;
                Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DeviceCare.ConnectionWizard.ProtocolButton' at Center."+ Protocol, repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonProtocol_GeneralInfo, new RecordItemIndex(1));
                repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonProtocol_General.Click();
                
                if (Protocol== "FF")
                {
                    Helpers.Run_Ni_FBUS_MANAGER.Start();
                }
                
                Delay.Milliseconds(200);
                
            }
            if (Protocol == "SI-IPC" || Protocol == "SI-ISS" || Protocol == "SI-PCP" || Protocol == "SI-CDI" )
            {
                
                string SubProtocol= "";
                
                
                if (Protocol == "SI-IPC" )
                {
                    SubProtocol = "IPC";
                }
                if (Protocol == "SI-ISS" )
                {
                    SubProtocol = "ISS";
                }
                if (Protocol == "SI-PCP" )
                {
                    SubProtocol = "PCP";
                }
                if (Protocol == "SI-CDI" )
                {
                    SubProtocol = "CDI2";
                }
                var repo = GUI.DeviceCareApplication.Instance;
                repo.protocolselection = "automId" +SubProtocol ;
                var protocolButton = repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonProtocol_General;
                Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DeviceCare.ConnectionWizard.ProtocolButton' at Center.", repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonProtocol_GeneralInfo, new RecordItemIndex(1));
                repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonProtocol_General.Click();
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
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.Text_Title_ModemInfo, "Visible", "True");
                return true;
            } 
            catch (ValidationException)
            {
                return false;
            }
            
        }
    }
}

