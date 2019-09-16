// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="CreateTopologyOffline.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of ConnectDevice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The create topology offline.
    /// </summary>
    public class CreateTopologyOffline : ICreateTopologyOffline
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);
            Reporting.Info("Function Create Topology Offline is not supported by Host Application: DeviceCare");
            return false;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="communication">
        /// The communication.
        /// </param>
        /// <param name="devices">
        /// The devices.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public bool Run(List<string /*communications*/> communication, List<string /*device*/> devices)
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);
            Reporting.Info("Function Select Device is not supported by Host Application: DeviceCare");
            return false;
        }
    }
}
