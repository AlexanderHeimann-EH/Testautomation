// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="OpenAdditionalModule.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of OpenAdditionalModule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.MenuArea.Menu_DeviceScreen.Execution
{
    using EH.PCPS.TestAutomation.DeviceCare.V10300.GUI;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Description of OpenAdditionalModule.
    /// </summary>
    public class OpenAdditionalModule
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="moduleToOpen">
        /// The module to open.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string moduleToOpen)
        {
            DeviceCareApplication deviceCareApplication = DeviceCareApplication.Instance;
            RepoItemInfo repo = deviceCareApplication.MenuArea.MainMenu.AdditionalFunctionMenuItems.MenuItemInfo;
            string modifiedPath = repo.AbsolutePath.ToString().Replace("MODULENAME", moduleToOpen);
            
            MenuItem menuItem; 
            Host.Local.TryFindSingle((RxPath)modifiedPath, 5000, out menuItem);
            if (menuItem != null && menuItem.Visible)
            {
                menuItem.Click();
                return true;
            }
            
            return false;
        }
    }
}
