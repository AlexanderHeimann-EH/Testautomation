/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 05.05.2015
 * Time: 16:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Settings.Execution
{
    using System.Collections.Generic;
    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Description of GetEventLogMessages.
    /// </summary>
    [TestModule("C4C3DD6B-52F3-45CF-9B59-9616DADD5D18", ModuleType.UserCode, 1)]
    public class GetEventLogMessages : ITestModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetEventLogMessages"/> class. 
        /// </summary>
        public GetEventLogMessages()
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
            
            var eventLog = new Page_Settings_Functions();

            // TODO: Rename instance to something useful
            var statusFunction = new StatusArea.Statusbar.Statusbar_Functions();
            
            statusFunction.OpenEventLog();

            // check if event log has entries
            List<Element> children = eventLog.GetChildrenList();
            if (children.Count >= 1)
            {
                if (children.Count == 1)
                {
                    eventLog.LogContainsExactlyOneEvent = true;
                }

                eventLog.PopulateListsWithEventLogMessages();
                eventLog.ConstructEventLog();

                for (int i = 0; i <= eventLog.EventLogMessages.Count - 1; i++)
                {
                    Report.Info(eventLog.EventLogMessages[i]);
                }
            }
            else
            {
                Report.Info("Eventlog is empty. No messages to provide");
                eventLog.EventLogMessages = null;
            }

            statusFunction.CloseEventLog();
        }
    }
}
