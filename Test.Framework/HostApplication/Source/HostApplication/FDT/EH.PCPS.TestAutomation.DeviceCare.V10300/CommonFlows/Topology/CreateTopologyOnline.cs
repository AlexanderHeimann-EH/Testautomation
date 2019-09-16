// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="CreateTopologyOnline.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of CreatetopologyOnline.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 15:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Description of Create topology Online.
    /// </summary>
    public class CreateTopologyOnline : CommonHostApplicationLayerInterfaces.CommonFlows.ICreateTopologyOnline
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            var scan = new Functions.ApplicationArea.Page_Home.Page_Home_Functions();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Create online topology");

            return scan.PerformAutomaticScan();
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="communications">
        /// The communications.
        /// </param>
        /// <param name="devices">
        /// The devices.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(List<string> communications, List<string> devices)
        {
            // instanciate all necessary modules
            var connect = new Functions.Helpers.InterfaceHelpers.OnlineConnectFunctions();
            var protocolPage = new Functions.ApplicationArea.Page_Assistant_ProtocolSelection.Assistant_ProtocolSelection_Function();
            var homeFunctions = new Functions.ApplicationArea.Page_Home.Page_Home_Functions();
            var modemSelectionFunctions = new Functions.ApplicationArea.Page_Assistant_ModemSelection.Assistant_ModemSelection_Functions();
            var commDtmFunctions = new Functions.ApplicationArea.Page_Assistant_ConfigureCommDTM.Assistant_ConfigureCommDTM_Functions();
            var statusbarFunctions = new Functions.StatusArea.Statusbar.Statusbar_Functions();

            var repo = GUI.DeviceCareApplication.Instance;

            homeFunctions.ClickAssistant();

            // click button assistant
            if (connect.WaitForItemVisible(repo.ApplicationArea.ProtocolSelection.Text_Title_ProtocolInfo))
            {
                // click protocol button
                protocolPage.SelectProtocol(communications[0]);

                if (connect.WaitForItemVisible(repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.Text_Title_ModemInfo))
                {
                    // click modem button
                    modemSelectionFunctions.SelectModem(communications[0], communications[2]);

                    if (connect.WaitForItemVisible(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.SelfInfo))
                    {
                        // dtm configuration page
                        commDtmFunctions.OpenAdvancedConfiguration();

                        if (connect.WaitForItemVisible(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.CommDTMHostingGUIInfo))
                        {
                            // configure Comm DTM -> CommLayer function

                            // TODO: CommLayer has to be implemented

                            // scan button
                            commDtmFunctions.ClickScan();

                            if (statusbarFunctions.WaitForScanning(communications[1]))
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Scanning process was started successfully");
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="communications">
        /// The communications.
        /// </param>
        /// <param name="devices">
        /// The devices.
        /// </param>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(List<string> communications, List<string> devices, string projectName)
        {
            /*
             * Function not supported by DC
             * Method reports warning message and returns with false
             */

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare)");

            return false;
        }
    }
}
