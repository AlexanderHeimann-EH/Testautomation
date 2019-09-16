// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="OpenHostApplication.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of OpenHostApplication.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Description of OpenHostApplication.
    /// </summary>
    public class OpenHostApplication : CommonHostApplicationLayerInterfaces.CommonFlows.IOpenHostApplication
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            var module = new Functions.Helpers.DeviceCareProcessFunctions();
            
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Open HostApplication (DeviceCare)");
            
            return module.Run();
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
            var module = new Functions.Helpers.DeviceCareProcessFunctions();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Open HostApplication (DeviceCare)");
            int processId = module.Run(path);
            return module.IsHostApplicationRunning(processId);   
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
            var module = new Functions.Helpers.DeviceCareProcessFunctions();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Open HostApplication (DeviceCare)");
            int processId = module.Run(path, timeOutInMilliseconds);
            return module.IsHostApplicationRunning(processId);
        }
    }
}
