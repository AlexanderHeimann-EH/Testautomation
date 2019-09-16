// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HostApplication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Execution
{
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools.Logging;
    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Ranorex;

    /// <summary>
    /// The host application.
    /// </summary>
    public static class HostApplication
    {
        /// <summary>
        /// The open program functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool CloseHostApplication()
        {
            Log.Enter(typeof(HostApplication), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            Button button;
            Host.Local.TryFindSingle(repo.MenuArea.MainMenu.MainMenuItems.ButtonExitInfo.AbsolutePath, out button);
            if (button != null && button.Visible)
            {
                button.Click();
                Common.Tools.Log.Debug("Button found and clicked.");
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Runs an application with a specified path
        /// </summary>
        /// <param name="path">The path of the program to start</param>
        /// <returns>The process id of the started process</returns>
        public static int StartHostApplication(string path)
        {
            Log.Enter(typeof(HostApplication), MethodBase.GetCurrentMethod().Name);
            int processId = -1;
            if (File.Exists(path))
            {
                processId = Host.Local.RunApplication(path, string.Empty, string.Empty, true);
                if (processId > 0)
                {
                    Common.Tools.Log.Debug("Process Id is available. Device Care started. ");
                }
                else
                {
                    Common.Tools.Log.Error("Process Id is not available. Device Care is not started. ");
                }
            }
            else
            {
                Common.Tools.Log.Error("Path to DeviceCare [" + path + "] is not valid.");    
            }
            
            return processId;
        }
    }
}
