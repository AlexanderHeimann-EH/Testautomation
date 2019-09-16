// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="LoadProject.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of CloseProject.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The load project.
    /// </summary>
    public class LoadProject : ILoadProject
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="projectName">
        /// The project Name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string projectName)
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);
            Reporting.Info("Function Load Project is not supported by Host Application: DeviceCare");
            return false;
        }
    }
}