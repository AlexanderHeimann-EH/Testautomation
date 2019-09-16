// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventLog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.Dialogs.Validation
{
    using System;
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
        /// The is event log open.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsEventLogOpen()
        {
            try
            {
                Logging.Enter(typeof(EventLog), MethodBase.GetCurrentMethod().Name);

                DeviceCareApplication repo = new DeviceCareApplication();
                repo.Dialog.EventLog.CloseInfo.WaitForExists(Common.DefaultValues.GeneralTimeout);
                if (!repo.Dialog.EventLog.CloseInfo.Exists())
                {
                    Reporting.Error("Event Log Dialog is not available.");
                    return false;
                }

                Reporting.Debug("Event Log Dialog is available.");
                return true;
            }
            catch (Exception exception)
            {
                Reporting.Error("Event Log Dialog is not available.");
                Reporting.Error(exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The create automatically.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsEventLogClosed()
        {
            try
            {
                Logging.Enter(typeof(EventLog), MethodBase.GetCurrentMethod().Name);

                DeviceCareApplication repo = new DeviceCareApplication();
                repo.Dialog.EventLog.CloseInfo.WaitForNotExists(Common.DefaultValues.GeneralTimeout);
                Reporting.Debug("Event Log Dialog is not available.");
                return true;
            }
            catch (Exception exception)
            {
                Reporting.Error("Event Log Dialog is still available.");
                Reporting.Error(exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The is event log table available.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsEventLogTableAvailable()
        {
            try
            {
                Logging.Enter(typeof(EventLog), MethodBase.GetCurrentMethod().Name);

                DeviceCareApplication repo = new DeviceCareApplication();
                if (repo.Dialog.EventLog.TableInfo.Exists())
                {
                    Reporting.Debug("Event Log Table is available.");
                    return true;    
                }

                Reporting.Error("Event Log Table is not available.");
                return false;
            }
            catch (Exception exception)
            {
                Reporting.Error("Event Log Table is not available.");
                Reporting.Error(exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The are messages available.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool AreMessagesAvailable()
        {
            Logging.Enter(typeof(EventLog), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = new DeviceCareApplication();

            if (IsEventLogTableAvailable())
            {
                IList<Ranorex.Row> rows = repo.Dialog.EventLog.Table.Rows;
                if (rows != null)
                {
                    if (rows.Count > 1)
                    {
                        Reporting.Debug("Event Log messages are available");
                        return true;
                    }

                    Reporting.Debug("There are no Event Log messages available");
                    return true;
                }
            }
            
            return false;
        }
    }
}
