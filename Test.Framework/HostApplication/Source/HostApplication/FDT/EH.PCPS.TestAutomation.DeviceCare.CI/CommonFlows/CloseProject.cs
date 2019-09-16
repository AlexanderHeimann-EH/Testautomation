// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="CloseProject.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of CloseProject.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The close project.
    /// </summary>
    public class CloseProject : ICloseProject
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

            try
            {
                var repo = DeviceCareApplication.Instance;
                if (repo.MenuArea.MainMenu.MainMenuItems.ButtonHomeInfo.Exists())
                {
                    Reporting.Debug("Close Project by pressing home button.");
                    repo.MenuArea.MainMenu.MainMenuItems.ButtonHome.Click();

                    repo.ApplicationArea.ConnectionSelection.ButtonConnectionAutomaticInfo.WaitForExists(Common.DefaultValues.GeneralTimeout);
                    if (repo.ApplicationArea.ConnectionSelection.ButtonConnectionAutomaticInfo.Exists())
                    {
                        Reporting.Debug("Project closed. ");
                        return true;       
                    }

                    Reporting.Error("Button Connect automatically is not available.");
                    return false;
                }

                Reporting.Error("Button Home is not available");
                return false;
            }
            catch (Exception exception)
            {
                Reporting.Error("Button Connect automatically did not become available.");
                Reporting.Error(exception.Message);
                return false;
            }
        }
    }
}
