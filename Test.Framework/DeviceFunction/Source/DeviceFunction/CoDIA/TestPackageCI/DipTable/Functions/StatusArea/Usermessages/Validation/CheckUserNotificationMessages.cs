// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckUserNotificationMessages.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Checks the Dip table user notification messages.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.DipTable.Functions.StatusArea.Usermessages.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.StatusArea.Usermessages.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.DipTable.GUI.StatusArea.UserMessages;

    using Ranorex.Core;

    /// <summary>
    /// Checks the Dip table user notification messages.
    /// </summary>
    public class CheckUserNotificationMessages : ICheckUserNotificationMessages
    {
        #region Public Methods and Operators

        /// <summary>
        /// Scans the user notification messages in the status area for error messages
        /// </summary>
        /// <returns>
        /// true:  if the text contains any of the keywords
        /// false:  if the text does not contain any of the keywords
        /// </returns>
        public bool ContainsError()
        {
            bool result = false;

            Element element = new UserMessagesElements().UserMessage;
            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The user messages element cannot be found");
                result = true;
            }
            else
            {
                string actualInfo = element.GetAttributeValueText("Text");
                string actualInfoLowerCase = actualInfo.ToLower();
                if (actualInfoLowerCase.Contains("error") || actualInfoLowerCase.Contains("fail") || actualInfoLowerCase.Contains("warning") || actualInfoLowerCase.Contains("not successful"))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dip table module reports: \"" + actualInfo + "\"");
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Checks whether the user message contains a particular string
        /// </summary>
        /// <param name="value">
        /// String to look for
        /// </param>
        /// <returns>
        /// true: if the user message contains the string
        /// false: if string is not found
        /// </returns>
        public bool ContainsString(string value)
        {
            bool result = false;

            Element element = new UserMessagesElements().UserMessage;
            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The user messages element cannot be found");
            }
            else
            {
                string actualInfo = element.GetAttributeValueText("Text");
                string actualInfoLowerCase = actualInfo.ToLower();
                if (actualInfoLowerCase.Contains(value.ToLower()))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The user message: \"" + actualInfo + "\" contains \"" + value + "\" .");
                    result = true;
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The user message: \"" + actualInfo + "\" does not contain \"" + value + "\" .");
                }
            }

            return result;
        }

        /// <summary>
        /// The user message.
        /// </summary>
        /// <returns>
        /// The actual user message
        /// </returns>
        public string UserMessage()
        {
            string result;
            Element element = new UserMessagesElements().UserMessage;
            if (element == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The user messages element cannot be found");
                result = string.Empty;
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        #endregion
    }
}