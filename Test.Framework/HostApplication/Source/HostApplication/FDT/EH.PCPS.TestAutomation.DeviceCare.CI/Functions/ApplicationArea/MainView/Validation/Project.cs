// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Project.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools.Logging;
    using EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Validation;

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
        public static bool IsProjectCreated()
        {
            Log.Enter(typeof(Project), MethodBase.GetCurrentMethod().Name);

            bool result = ProgramFunctions.IsMenuAvailable();
            result &= DtmFunctions.IsMenuAvailable();
            result &= AdditionalFunctions.IsMenuAvailable();
            result &= DeviceReport.IsMenuAvailable();
            System.Threading.Thread.Sleep(10000);
            return result;
        }
    }
}
