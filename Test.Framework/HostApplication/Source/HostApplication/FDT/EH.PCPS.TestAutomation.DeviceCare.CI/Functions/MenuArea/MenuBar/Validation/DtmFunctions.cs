// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtmFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Validation
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The program functions.
    /// </summary>
    public static class DtmFunctions
    {
        /// <summary>
        /// The open program functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsMenuAvailable()
        {
            Logging.Enter(typeof(DtmFunctions), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            repo.MenuArea.MainMenu.DTMFunctionsInfo.WaitForExists(Common.DefaultValues.GeneralTimeout);
            if (repo.MenuArea.MainMenu.DTMFunctionsInfo.Exists())
            {
                if (repo.MenuArea.MainMenu.DTMFunctions != null && repo.MenuArea.MainMenu.DTMFunctions.Visible)
                {
                    Reporting.Debug("Menu item DTM Functions is available.");
                    return true;
                }
            }

            Reporting.Debug("Menu item DTM Functions is not available.");
            return false;
        }

        /// <summary>
        /// The is menu item available.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsMenuItemAvailable()
        {
            Logging.Enter(typeof(DtmFunctions), MethodBase.GetCurrentMethod().Name);
            try
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                repo.MenuArea.MainMenu.DTMFunctionMenuItems.OnlineParameterizationInfo.WaitForExists(Common.DefaultValues.GeneralTimeout);
                Reporting.Debug("Menu Items of menu DTM Function are available.");
                return true;
            }
            catch (Exception exception)
            {
                Reporting.Error("Menu Items of menu DTM Function are not available.");
                Reporting.Error(exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The is online parameterize available.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsOnlineParameterizeAvailable()
        {
            Logging.Enter(typeof(DtmFunctions), MethodBase.GetCurrentMethod().Name);
            DeviceCareApplication repo = DeviceCareApplication.Instance;

            bool result = Execution.DtmFunctions.OpenMenu();

            if (result && repo.MenuArea.MainMenu.DTMFunctionMenuItems.OnlineParameterizationInfo.Exists())
            {
                if (repo.MenuArea.MainMenu.DTMFunctionMenuItems.OnlineParameterization.Enabled)
                {
                    Reporting.Debug("Menu item Online Parameterize is enabled.");
                    return true;
                }

                Reporting.Debug("Menu item Online Parameterize is not enabled.");
                return false;
            }

            Reporting.Error("Menu item Online Parameterize is not available.");
            return false;
        }

        /// <summary>
        /// The is offline parameterize available.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsOfflineParameterizeAvailable()
        {
            Logging.Enter(typeof(DtmFunctions), MethodBase.GetCurrentMethod().Name);
            DeviceCareApplication repo = DeviceCareApplication.Instance;

            bool result = Execution.DtmFunctions.OpenMenu();

            Reporting.Debug(repo.MenuArea.MainMenu.DTMFunctionMenuItems.OfflineParameterizationInfo.AbsolutePath.ToString());
            if (result && repo.MenuArea.MainMenu.DTMFunctionMenuItems.OfflineParameterizationInfo.Exists())
            {
                if (repo.MenuArea.MainMenu.DTMFunctionMenuItems.OfflineParameterization.Enabled)
                {
                    Reporting.Debug("Menu item Offline Parameterize is enabled.");
                    return true;
                }

                Reporting.Debug("Menu item Offline Parameterize is not enabled.");
                return false;
            }

            Reporting.Error("Menu item Offline Parameterize is not available.");
            return false;
        }
    }
}
