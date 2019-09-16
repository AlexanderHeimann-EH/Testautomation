// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenHostApplication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Helpers;
    using EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Validation;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The open host application.
    /// </summary>
    public class OpenHostApplication : IOpenHostApplication
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

            var deviceCareProcessFunctions = new DeviceCareProcessFunctions();
            Reporting.Debug("Open DeviceCare");
            return deviceCareProcessFunctions.Run();
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string path)
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            var deviceCareProcessFunctions = new DeviceCareProcessFunctions();
            Reporting.Debug("Open DeviceCare");
            int processId = deviceCareProcessFunctions.Run(path);
            return HostApplication.IsHostApplicationOpen(processId);
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// The time out in milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string path, int timeOutInMilliseconds)
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            var deviceCareProcessFunctions = new DeviceCareProcessFunctions();
            Reporting.Debug("Open DeviceCare");
            int processId = deviceCareProcessFunctions.Run(path, timeOutInMilliseconds);
            return HostApplication.IsHostApplicationOpen(processId);
        }
    }
}
