// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="CreateProject.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of CreateProject.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Execution;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// Description of CreateProject.
    /// </summary>
    public class CreateProject : CommonHostApplicationLayerInterfaces.CommonFlows.ICreateProject
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string projectName)
        {
            Logging.Enter(typeof(CreateProject), MethodBase.GetCurrentMethod().Name);
            bool result = Project.CreateAutomatically();
            result &= Functions.StatusArea.StatusBar.Validation.ProgressIndicator.WaitUntilProgressIndicatorBecomesAvailable();
            result &= Functions.StatusArea.StatusBar.Validation.ProgressIndicator.WaitUntilProgressIndicatorBecomesNotAvailable();
            result &= Functions.ApplicationArea.MainView.Validation.Project.IsProjectCreated();
            return result;
        }
    }
}
