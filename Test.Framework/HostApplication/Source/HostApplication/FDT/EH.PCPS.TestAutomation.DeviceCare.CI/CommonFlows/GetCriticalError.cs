// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCriticalError.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class GetCriticalError.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// Class GetCriticalError.
    /// </summary>
    public class GetCriticalError : IGetCriticalError
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks DTM messages for a critical error
        /// </summary>
        /// <returns>List with critical error message or list with empty string.</returns>
        public List<string> Run()
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            bool result;
            List<string> resultStrings;
            result = Functions.Dialogs.Execution.EventLog.OpenEventLog();
            result &= Functions.Dialogs.Validation.EventLog.IsEventLogOpen();

            resultStrings = Functions.Dialogs.Execution.EventLog.GetAllCriticalErrorFromEventLog();
            if (resultStrings.Count == 0)
            {
                Reporting.Debug("No Critical Error found.");
                resultStrings.Add(string.Empty);
            }

            result &= Functions.Dialogs.Execution.EventLog.CloseEventLog();
            result &= Functions.Dialogs.Validation.EventLog.IsEventLogClosed();

            if (!result)
            {
                Reporting.Debug("An error occured while GetCritical Error");
            }

            return resultStrings;
        }

        #endregion
    }
}