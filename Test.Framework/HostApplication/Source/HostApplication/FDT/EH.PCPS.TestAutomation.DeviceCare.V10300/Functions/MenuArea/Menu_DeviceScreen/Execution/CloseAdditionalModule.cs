// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseAdditionalModule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Defines the OpenAdditionalModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.MenuArea.Menu_DeviceScreen.Execution
{
    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.DeviceCare.V10300.GUI;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    /// The open additional module.
    /// </summary>
    public class CloseAdditionalModule
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
            RepoItemInfo repo = deviceCareApplication.ApplicationArea.ModuleSelection.TabCloseButtonInfo;
            string modifiedPath = repo.AbsolutePath.ToString().Replace("MODULENAME", moduleToOpen);

            Button button;
            Host.Local.TryFindSingle(modifiedPath, DefaultValues.GeneralTimeout, out button);
            if (button != null)
            {
                button.Focus();
                button.Click();
                return true;
            }

            return false;
        }
    }
}

