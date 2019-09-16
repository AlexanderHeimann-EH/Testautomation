/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Collections.Generic;
using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;
using Ranorex;
using Ranorex.Core;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    /// <summary>
    /// Description of GetMessageLog.
    /// </summary>
    public class GetMessageLog : EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.IGetMessageLog
    {
        /// <summary>
        /// 
        /// </summary>
        public GetMessageLog()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public List<string> Run()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Get event log messages");
            var eventLog = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Settings.Page_Settings_Functions();
            var statusFunction = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.StatusArea.Statusbar.Statusbar_Functions();
            
            statusFunction.OpenEventLog();
            Delay.Milliseconds(3000);
            
            //check if event log has entries
            List<Element> children = eventLog.GetChildrenList();
            if (children.Count >= 1)
            {
               if (children.Count == 1)
               {
                   eventLog.LogContainsExactlyOneEvent = true;
               }
               eventLog.PopulateListsWithEventLogMessages();
               eventLog.ConstructEventLog();
            }
            else
            {
               Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Eventlog is empty. No messages to provide");
               eventLog.EventLogMessages = null;
            }    
            return eventLog.EventLogMessages;
        }
    }
}
