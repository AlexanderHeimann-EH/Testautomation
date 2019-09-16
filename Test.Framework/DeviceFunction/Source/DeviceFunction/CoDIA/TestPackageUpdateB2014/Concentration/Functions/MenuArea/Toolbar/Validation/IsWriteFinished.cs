// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsWriteFinished.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Concentration.Functions.MenuArea.Toolbar.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.MenuArea.Toolbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Concentration.GUI.MenuArea.Toolbar;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Concentration.GUI.StatusArea.Usermessages;

    using Ranorex;

    /// <summary>
    ///     Description of IsWriteFinished.
    /// </summary>
    public class IsWriteFinished : IIsWriteFinished
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Checks if writing coefficients to the device is finished
        /// </summary>
        /// <returns>
        ///     true: if write button is enabled and user notification message is shown
        ///     false: if either write button is not enabled or message is not shown
        /// </returns>
        public bool Run()
        {
            string actualInfo = new UserMessagesElements().UserNotification;
            string actualInfoLowerCase = actualInfo.ToLower();
            Button buttonWrite = new ToolbarElements().ButtonWrite;

            if (actualInfoLowerCase.Contains("successfully") && actualInfoLowerCase.Contains("written") && buttonWrite.Enabled)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing finished");
                return true;
            }

            return false;
        }

        #endregion
    }
}