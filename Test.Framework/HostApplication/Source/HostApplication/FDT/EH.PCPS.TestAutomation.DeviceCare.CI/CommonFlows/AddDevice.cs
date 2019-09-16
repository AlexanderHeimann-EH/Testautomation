// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="AddDevice.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of AddDevice.
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
    /// Description of AddDevice.
    /// </summary>
    public class AddDevice : IAddDevice
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <param name="device">
        /// The device.
        /// </param>
        /// <param name="configurationSettings">
        /// The configuration Settings.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string parent, string device, List<string> configurationSettings)
        {
            /*
             * Function not supported by DC
             * Method reports warning message and returns with false
             */
            
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);
            Reporting.Info("Function Add Device is not supported by Host Application: DeviceCare");
            return false;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <param name="device">
        /// The device.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string parent, string device)
        {
            /*
             * Function not supported by DC
             * Method reports warning message and returns with false
             */

            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);
            Reporting.Info("Function Add Device is not supported by Host Application: DeviceCare");
            return false;
        }
    }
}
