// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsWriteFinished.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Viscosity.Functions.MenuArea.Toolbar.Validation
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.MenuArea.Toolbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.Viscosity.GUI.MenuArea.Toolbar;
    using EH.PCPS.TestAutomation.TestPackageCI.Viscosity.GUI.StatusArea.Usermessages;

    using Ranorex;

    /// <summary>
    /// The is write finished.
    /// </summary>
    public class IsWriteFinished : MarshalByRefObject, IIsWriteFinished
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Checks if writing to device is finished
        /// </summary>
        /// <returns>
        ///     true: if write button is enabled and user notification message is shown
        ///     false: if either write button is not enabled or message is not shown
        /// </returns>
        public bool Run()
        {
            string actualInfo = new UserMessagesElements().UserNotificationMessage;
            string actualInfoLowerCase = actualInfo.ToLower();
            Button buttonWrite = new ToolbarElements().WriteButton;

            if ((actualInfoLowerCase.Contains("succ") || actualInfoLowerCase.Contains("info")) && buttonWrite.Enabled)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing finished");
                return true;
            }

            return false;
        }

        #endregion
    }
}