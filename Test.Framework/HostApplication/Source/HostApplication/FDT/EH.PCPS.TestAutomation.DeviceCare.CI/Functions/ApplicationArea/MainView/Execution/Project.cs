// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Project.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools.Logging;
    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    /// <summary>
    /// The project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// The create automatically.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool CreateAutomatically()
        {
            Log.Enter(typeof(Project), MethodBase.GetCurrentMethod().Name);
            DeviceCareApplication repo = DeviceCareApplication.Instance;
            if (repo.ApplicationArea.ConnectionSelection.ButtonConnectionAutomaticInfo.Exists())
            {
                Common.Tools.Log.Debug("Create Project automatically.");
                repo.ApplicationArea.ConnectionSelection.ButtonConnectionAutomatic.Click();
                return true;
            }

            Common.Tools.Log.Debug("Create Project automatically failed.");
            return false;
        }

        /// <summary>
        /// The create by assistant.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool CreateByAssistant()
        {
            Log.Enter(typeof(Project), MethodBase.GetCurrentMethod().Name);
            Common.Tools.Log.Error("CreateByAssistant is not implemented yet.");
            return false;
        }
    }
}
