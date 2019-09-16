// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="GetMessageLog.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of GetMessageLog.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Ranorex;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// Description of GetMessageLog.
    /// </summary>
    public class GetMessageLog : IGetMessageLog
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> Run()
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            List<string> messages = null;
            if (Functions.Dialogs.Execution.EventLog.OpenEventLog())
            {
                messages = Functions.Dialogs.Execution.EventLog.GetAllMessagesFromEventLog();
                if (messages != null)
                {
                    if (messages.Count > 0)
                    {
                        foreach (var message in messages)
                        {
                            Reporting.Debug(message);
                        }
                    }
                    else
                    {
                        Reporting.Debug("There isn´t any message in Event Log available");    
                    }
                }
                else
                {
                    Reporting.Debug("There isn´t any message in Event Log available");        
                }
            }

            return messages;
        }
    }
}
