// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsReadFinished.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of IsReadFinished.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.MenuArea.Toolbar.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.MenuArea.Toolbar.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.MenuArea.Toolbar;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.StatusArea.Usermessages;

    using Ranorex;

    /// <summary>
    ///     Description of IsReadFinished.
    /// </summary>
    public class IsReadFinished : IIsReadFinished
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Checks if reading coefficients from the device is finished
        /// </summary>
        /// <returns>
        ///     true: if read button is enabled and user notification message is shown
        ///     false: if either read button is not enabled or message is not shown
        /// </returns>
        public bool Run()
        {
            string actualInfo = new UserMessagesElements().UserNotification;
            string actualInfoLowerCase = actualInfo.ToLower();
            Button buttonRead = new ToolbarElements().ButtonRead;

            if (actualInfoLowerCase.Contains("success") && buttonRead.Enabled)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading finished");
                return true;
            }

            return false;
        }

        #endregion
    }
}