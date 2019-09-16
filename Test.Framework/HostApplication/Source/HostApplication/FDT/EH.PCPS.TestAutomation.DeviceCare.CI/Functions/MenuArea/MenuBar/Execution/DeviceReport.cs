// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceReport.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Ranorex;

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
        public static bool OpenMenu()
        {
            Logging.Enter(typeof(DeviceReport), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            MenuItem menuItem;

            bool result;
            Host.Local.TryFindSingle(repo.MenuArea.MainMenu.DeviceReportInfo.AbsolutePath, out menuItem);
            if (menuItem != null && menuItem.Visible)
            {
                menuItem.Click();
                Reporting.Debug("Menu item Device Report found and clicked.");
                result = true;
            }
            else
            {
                Reporting.Error("Could not access menu Device Report.");
                result = false;
            }

            return result;
        }

        /// <summary>
        /// The open dtm function.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool SaveDeviceReport()
        {
            Logging.Enter(typeof(DeviceReport), MethodBase.GetCurrentMethod().Name);

            if (OpenMenu())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                MenuItem menuItem;
                Host.Local.TryFindSingle(repo.MenuArea.MainMenu.DeviceReportMenuItems.SaveDeviceReportInfo.AbsolutePath, out menuItem);
                if (menuItem != null && menuItem.Visible)
                {
                    menuItem.Click();
                    Reporting.Debug("Menu item Save Device Report found and clicked.");
                    return true;
                }    
            }

            Reporting.Error("Could not access menu item Save Device Report.");
            return false;
        }

        /// <summary>
        /// The open dtm function.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool PrintDeviceReport()
        {
            Logging.Enter(typeof(DeviceReport), MethodBase.GetCurrentMethod().Name);
            Reporting.Error("Not implemented yet");
            return false;
        }
    }
}
