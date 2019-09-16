// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Connection.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.StatusArea.StatusBar.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The connection.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// The is device connected.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsDeviceConnected()
        {
            Logging.Enter(typeof(Connection), MethodBase.GetCurrentMethod().Name);
            DeviceCareApplication repo = DeviceCareApplication.Instance;

            if (!repo.StatusArea.ConnectionIndicatorInfo.Exists())
            {
                Reporting.Debug("There is no device connected.");
                return false;
            }

            Reporting.Debug("A device is connected.");
            return true;
        }
    }
}
