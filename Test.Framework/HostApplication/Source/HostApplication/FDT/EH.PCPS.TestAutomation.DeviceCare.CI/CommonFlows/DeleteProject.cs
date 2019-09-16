// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="DeleteProject.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of CloseProject.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Log = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;

    /// <summary>
    /// Description of CloseProject.
    /// </summary>
    public class DeleteProject : IDeleteProject
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
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            Common.Tools.Log.Info("Function Delete Project is not supported by Host Application: DeviceCare");
            return false;
        }
    }
}
