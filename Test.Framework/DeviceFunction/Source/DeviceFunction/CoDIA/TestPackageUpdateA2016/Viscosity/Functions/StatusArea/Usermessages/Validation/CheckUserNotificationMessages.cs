﻿//------------------------------------------------------------------------------
// <copyright file="CheckUserNotificationMessages.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.Functions.StatusArea.Usermessages.Validation
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.StatusArea.Usermessages.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.GUI.StatusArea.Usermessages;

    using Ranorex;

    /// <summary>
    /// The check user notification messages.
    /// </summary>
    public class CheckUserNotificationMessages : MarshalByRefObject, ICheckUserNotificationMessages
    {
        /// <summary>
        /// Scans the user notification messages in the status area for error messages
        /// </summary>
        /// <returns>
        /// true:  if the text contains any of the keywords
        /// false:  if the text does not contain any of the keywords
        /// </returns>
        public bool ContainsError()
        {
            string actualInfo = new UserMessagesElements().UserNotificationMessage;
            string actualInfoLowerCase = actualInfo.ToLower();
            if (actualInfoLowerCase.Contains("error") || actualInfoLowerCase.Contains("fail") ||
                actualInfoLowerCase.Contains("warning") || actualInfoLowerCase.Contains("not successful"))
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Viscosity module reports: \"" + actualInfo + "\"");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks whether the user message contains a particular string
        /// </summary>
        /// <param name="value">String to look for</param>
        /// <returns>
        /// true: if the user message contains the string
        /// false: if string is not found
        /// </returns>
        public bool ContainsString(string value)
        {
            string actualInfo = new UserMessagesElements().UserNotificationMessage;
            string actualInfoLowerCase = actualInfo.ToLower();
            string valueToLower = value.ToLower();
            if (actualInfoLowerCase.Contains(valueToLower))
            {
                return true;
            } 

            return false;
        }
    }
}
