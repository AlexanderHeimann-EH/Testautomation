// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceReport.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The device report.
    /// </summary>
    public class DeviceReport
    {
        /// <summary>
        /// The open program functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsMenuAvailable()
        {
            Logging.Enter(typeof(DeviceReport), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            repo.MenuArea.MainMenu.DeviceReportInfo.WaitForExists(Common.DefaultValues.GeneralTimeout);
            if (repo.MenuArea.MainMenu.DeviceReportInfo.Exists())
            {
                if (repo.MenuArea.MainMenu.DeviceReport != null && repo.MenuArea.MainMenu.DeviceReport.Visible)
                {
                    Reporting.Debug("Menu item Device Report is available.");
                    return true;
                }
            }

            Reporting.Debug("Menu item Device Report is not available.");
            return false;
        }
    }
}
