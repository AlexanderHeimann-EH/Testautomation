// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventLog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.Dialogs.Execution
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The project.
    /// </summary>
    public class EventLog
    {
        /// <summary>
        /// The create automatically.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenEventLog()
        {
            Logging.Enter(typeof(EventLog), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = new DeviceCareApplication();
            if (!repo.StatusArea.StatusBarInfo.Exists())
            {
                Reporting.Error("Element Status Bar is not available. Event Log cannot be opened.");
                return false;
            }

            Reporting.Debug("Status Bar is available.");
            Reporting.Debug("Open Event Log Dialog");
            repo.StatusArea.StatusBar.Click();
            return true;
        }

        /// <summary>
        /// The create by assistant.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool CloseEventLog()
        {
            Logging.Enter(typeof(EventLog), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            if (!repo.Dialog.EventLog.CloseInfo.Exists())
            {
                Reporting.Error("Button Close is not available. Event Log cannot be closed.");
                return false;
            }

            Reporting.Debug("Button Close is available.");
            Reporting.Debug("Close Event Log Dialog");
            repo.Dialog.EventLog.Close.Click();
            return true;
        }

        /// <summary>
        /// The get all critical error from event log.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public static List<string> GetAllCriticalErrorFromEventLog()
        {
            Logging.Enter(typeof(EventLog), MethodBase.GetCurrentMethod().Name);

            List<string> messages = new List<string>(); 
            DeviceCareApplication repo = new DeviceCareApplication();
            
            if (Validation.EventLog.IsEventLogTableAvailable())
            {
                IList<Ranorex.Row> rows = repo.Dialog.EventLog.Table.Rows;
                Reporting.Debug("Scan Event Log Table for critical errors.");
                foreach (var row in rows)
                {
                    if (row.Cells[1].Text.Contains("Critical Error."))
                    {
                        Reporting.Debug("Critical Error found.");
                        messages.Add(row.Cells[2].Text);
                    }
                }
            }
            
            return messages;
        }

        /// <summary>
        /// The get all messages from event log.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public static List<string> GetAllMessagesFromEventLog()
        {
            Logging.Enter(typeof(EventLog), MethodBase.GetCurrentMethod().Name);

            List<string> messages = new List<string>();
            DeviceCareApplication repo = new DeviceCareApplication();

            if (Validation.EventLog.IsEventLogTableAvailable())
            {
                IList<Ranorex.Row> rows = repo.Dialog.EventLog.Table.Rows;
                Reporting.Debug("Scan Event Log Table for messages");
                foreach (var row in rows)
                {
                    messages.Add(row.Cells[2].Text);
                }
            }

            return messages;
        }

        /// <summary>
        /// The get last message from event log.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetLastMessageFromEventLog()
        {
            Logging.Enter(typeof(EventLog), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = new DeviceCareApplication();

            string lastMessage = string.Empty;
            if (Validation.EventLog.IsEventLogTableAvailable())
            {
                IList<Ranorex.Row> rows = repo.Dialog.EventLog.Table.Rows;
                Reporting.Debug("Get latest Event Log message");
                
                if (rows != null)
                {
                    if (rows.Count > 0)
                    {
                        lastMessage = rows[1].Cells[2].Text;
                    }
                }
            }

            return lastMessage;
        }
    }
}
