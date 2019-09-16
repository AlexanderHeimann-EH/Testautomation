// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCriticalError.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class GetCriticalError.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21000.CommonFlows
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.FieldCare.V21000.Functions.Dialogs.DtmMessages.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21000.Functions.Dialogs.DtmMessages.Validation;

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
            List<string> result = new List<string>();
            string message = new DtmMessages().strGetNewestUserMessage;

            if (message == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element 'Dtm messages' is null.");
                result.Add(string.Empty);
            }
            else if (new ScanDtmMessages().ContainsCriticalError())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Critical error found.");
                result.Add(message);
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There is no critical error present.");
                result.Add(string.Empty);
            }

            return result;
        }

        #endregion
    }
}