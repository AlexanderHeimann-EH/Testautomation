// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="RegisterDeviceType.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of RegisterDeviceType.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The register device type.
    /// </summary>
    public class RegisterDeviceType : IRegisterDeviceType
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
            Reporting.Info("Function Register Device Type is not implemented by Host Application: DeviceCare");
            return false;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="devices">
        /// The devices.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(List<string> devices)
        {
            /*
             * Function not supported by DC
             * Method reports warning message and returns with false
             */

            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);
            Reporting.Info("Function Register Device Type is not supported by Host Application: DeviceCare");
            return false;
        }
    }
}
