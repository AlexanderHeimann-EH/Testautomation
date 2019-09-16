// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScanDtmMessages.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Provides methods for scanning the latest Dtm message
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.DtmMessages.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.DtmMessages.Execution;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.DtmMessages.Validation;

    /// <summary>
    /// Provides methods for scanning the latest DTM message
    /// </summary>
    public class ScanDtmMessages : IScanDtmMessages
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether the latest DTM message contains the specified text.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// <c>true</c> if the latest DTM message contains the specified text; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(string text)
        {
            bool result = true;

            string message = new DtmMessages().strGetNewestUserMessage;
            if (message == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element 'Dtm messages' is null.");
                result = false;
            }
            else
            {
                message = message.ToLower();
                string textToLower = text.ToLower();

                if (message.Contains(textToLower) == false)
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The latest Dtm message does not contain '" + text + "'.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The latest Dtm message contains '" + text + "'.");
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether the latest DTM message contains a critical error message.
        /// </summary>
        /// <returns><c>true</c> if the latest DTM message contains a critical error message; otherwise, <c>false</c>.</returns>
        public bool ContainsCriticalError()
        {
            bool result = true;

            string messageForLog = new DtmMessages().strGetNewestUserMessage;

            if (messageForLog == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element 'Dtm messages' is null.");
                result = false;
            }
            else
            {
                string message = messageForLog.ToLower();
                const string Text = "critical error";

                if (message.Contains(Text) == false)
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The latest Dtm message does not contain a critical error message");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The latest Dtm message contains the following critical error: " + messageForLog + " .");
                }
            }

            return result;
        }

        #endregion
    }
}