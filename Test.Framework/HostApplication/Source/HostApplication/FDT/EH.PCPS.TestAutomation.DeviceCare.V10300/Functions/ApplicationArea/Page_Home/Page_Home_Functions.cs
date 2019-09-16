// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="Page_Home_Functions.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of Page_Home_Functions.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 27.08.2015
 * Time: 15:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_Home
{
    using System;
    using System.Diagnostics;

    using EH.PCPS.TestAutomation.Common;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Description of Page_Home_Functions.
    /// </summary>
    public class Page_Home_Functions
    {
        /// <summary>
        /// The repo.
        /// </summary>
        private GUI.DeviceCareApplication repo = GUI.DeviceCareApplication.Instance;

        /// <summary>
        /// Clicks the home button
        /// </summary>
        public void OpenHome()
        {
            Button btnButton;
            RepoItemInfo elementInfo = this.repo.MenuArea.MainMenu.MainMenuItems.ButtonHomeInfo;
            Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
            btnButton.Click();
        }
        
        /// <summary>
        /// Validates if the home screen is visible
        /// </summary>
        /// <returns>True if home screen is shown</returns>
        public bool IsHomePageShown()
        {
        	Button button;
        	RepoItemInfo elementInfo = this.repo.ApplicationArea.ConnectionSelection.ButtonConnectionAutomaticInfo;
        	Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button);
        	if(button != null && button.Visible == true)
        	{
        		return true;
        	}
        	return false;
        }

        /// <summary>
        /// Closes the frame
        /// </summary>
        public void CloseFrame()
        {
            Button btnButton;
            RepoItemInfo elementInfo = this.repo.MenuArea.MainMenu.MainMenuItems.ButtonExitInfo;
            Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
            btnButton.Click();
        }

        /// <summary>
        /// Waits for the frame to not exist
        /// This method does not check if the process is not running anymore
        /// Only the GUI representation of the frame is observed
        /// </summary>
        /// <param name="timeOutInMilliseconds">The time which the method should wait for the process to close
        /// If parameter is 0 or -1, a default timeout will be used</param>
        /// <returns>True if the frame no longer exists</returns>
        public bool IsFrameClosed(int timeOutInMilliseconds)
        {
            Duration timeout;
            double convertedTimeout = Convert.ToDouble(timeOutInMilliseconds);

            if (timeOutInMilliseconds == 0 || timeOutInMilliseconds == -1)
            {
                timeout = TimeSpan.FromMilliseconds(30000);
            }
            else
            {
                timeout = TimeSpan.FromMilliseconds(convertedTimeout);
            }

            try
            {
                this.repo.DeviceCare.SelfInfo.WaitForNotExists(timeout);
                Report.Success("The frame was successfully closed");
                return true;
            }
            catch (RanorexException)
            {
                return false;
            }
        }

        /// <summary>
        /// Validates if the DeviceCare process is not running anymore
        /// </summary>
        /// <returns>True if the process is terminated</returns>
        public bool IsDCProcessTerminated()
        {
            Process[] processList = Process.GetProcesses();

            foreach (Process process in processList)
            {
                if (process.ProcessName == "DeviceCare")
                {
                    Report.Failure("The DC process is still running");
                    return false;
                }
            }

            Report.Success("The DC process was successfully terminated");
            return true;
        }

        /// <summary>
        /// Clicks the assistant scan button on the home screen
        /// </summary>
        public void ClickAssistant()
        {
            this.repo.ApplicationArea.ConnectionSelection.ButtonConnectionWizard.Click();
        }

        /// <summary>
        /// Clicks the 'Automatic' button and waits until the action is finished
        /// </summary>
        /// <returns>True if scanning was successful and Device DTM is online</returns>
        public bool PerformAutomaticScan()
        {
            var statusbarFunction = new StatusArea.Statusbar.Statusbar_Functions();
            if (statusbarFunction.GetUSBModemCount() > 1)
            {
                Report.Failure("More than one communication unit connected. Automatic connect disabled");
                return false;
            }

            string modem = Protocol.AutoScan_ModemRelations.GetCommDriverName(statusbarFunction.GetCommUnitName());
            Report.Info("Starting automatic scanning process...");
            this.ClickAutomatic();

            // problem: es soll gewartet werden, dass das device dtm online ist und das comm dtm soll missachtet werden. es muss also einen möglichkeit geben, von einem
            //            modem auf ein commDTM zu schließen
            // lösung: GetCommDriverName(string modemName) löst von commUnit auf commDTM auf (das sind fest definierte beziehungen, welches modem für welches commDTM
            // automatisch scannt
            statusbarFunction.WaitForScanning(modem);
            Report.Success("Device was found and is online");
            return true;
        }

        /// <summary>
        /// Clicks the automatic scan button on the home screen
        /// </summary>
        private void ClickAutomatic()
        {
            Console.WriteLine("Wait for 5 seconds to ensure accessability");
            this.repo.ApplicationArea.ConnectionSelection.ButtonConnectionAutomatic.Click();
        }
    }
}
