// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureUserSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ConfigureUserSettings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Linearization.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class ConfigureUserSettings.
    /// </summary>
    public class ConfigureUserSettings : IConfigureUserSettings
    {
        #region Public Methods and Operators

        /// <summary>
        /// Opens the tab Settings and configures the User Settings parameter.
        /// </summary>
        /// <param name="unitAfterLinearization">The unit after linearization.</param>
        /// <returns><c>true</c> if configuration successful, <c>false</c> otherwise.</returns>
        public bool Run(string unitAfterLinearization)
        {
            bool result = Execution.SelectTab.Run(2);

            if (this.IsValid(unitAfterLinearization))
            {
                result &= Execution.ConfigureSettingsTab.SetUserSettingsUnitAfterLinearization(unitAfterLinearization);
                result &= AssertFunctions.AreEqual(unitAfterLinearization, Execution.ConfigureSettingsTab.GetUserSettingsUnitAfterLinearization(), "Checking whether the unitAfterLinearization has been set correctly.");
            }

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring user settings finished successfully.");
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occurred. Configuration was not successful.");
            }

            return result;
        }

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsValid(string value)
        {
            if (value.Length > 0 && !value.Equals(" "))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}