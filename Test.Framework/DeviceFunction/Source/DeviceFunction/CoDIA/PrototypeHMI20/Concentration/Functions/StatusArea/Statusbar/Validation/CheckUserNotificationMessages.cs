// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckUserNotificationMessages.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.Functions.StatusArea.Statusbar.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.GUI.StatusArea.Usermessages;

    /// <summary>
    ///     Description of CheckUserNotificationMessages.
    /// </summary>
    public class CheckUserNotificationMessages : ICheckUserNotificationMessages
    {
        #region Public Methods and Operators

        /// <summary>
        /// Analysis the user notification messages in the status area
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            string actualInfo = new UserMessagesElements().UserNotification;
            string actualInfoLowerCase = actualInfo.ToLower();
            if (actualInfoLowerCase.Contains("error") || actualInfoLowerCase.Contains("fail") || actualInfoLowerCase.Contains("warning"))
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Concentration module reports: \"" + actualInfo + "\"");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Analysis the user notification messages in the status area
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string message)
        {
            string actualInfo = new UserMessagesElements().UserNotification;
            string actualInfoLowerCase = actualInfo.ToLower();
            if (actualInfoLowerCase.Contains(message.ToLower()))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}