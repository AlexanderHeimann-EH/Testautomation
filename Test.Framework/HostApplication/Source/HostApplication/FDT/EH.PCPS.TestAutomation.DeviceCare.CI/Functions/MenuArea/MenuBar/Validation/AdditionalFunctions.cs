// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdditionalFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The program functions.
    /// </summary>
    public static class AdditionalFunctions
    {
        /// <summary>
        /// The open program functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsMenuAvailable()
        {
            Logging.Enter(typeof(AdditionalFunctions), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            repo.MenuArea.MainMenu.AdditionalFunctionsInfo.WaitForExists(Common.DefaultValues.GeneralTimeout);
            if (repo.MenuArea.MainMenu.AdditionalFunctionsInfo.Exists())
            {
                if (repo.MenuArea.MainMenu.AdditionalFunctions != null && repo.MenuArea.MainMenu.AdditionalFunctions.Visible)
                {
                    Reporting.Debug("Menu item Additional Functions is available.");
                    return true;
                }
            }

            Reporting.Error("Menu item Additional Functions is not available.");
            return false;
        }
    }
}
