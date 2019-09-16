// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="Statusbar_Functions.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of Statusbar_Functions.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Tina Bertos
 * Date: 09/09/2015
 * Time: 16:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.StatusArea.Statusbar
{
    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Description of Status bar Functions.
    /// </summary>
    public class Statusbar_Functions
    {
        // Validate the text's name attribute of all elements within the UsbCommunicationUnitList -> UsbCommunicationUnitElement is used therefore
        // If the desired USB communication unit has been detected -> return true; -> else return false;

        /// <summary>
        /// The communication unit.
        /// </summary>
        private string communicationUnit;

        /// <summary>
        /// Initializes a new instance of the <see cref="Statusbar_Functions"/> class.
        /// </summary>
        public Statusbar_Functions()
        {
            this.CommunicationUnit = this.communicationUnit;
        }

        /// <summary>
        /// Gets or sets the communication unit.
        /// </summary>
        public string CommunicationUnit
        {
            get { return this.communicationUnit; }
            set { this.communicationUnit = value; }
        }

        /// <summary>
        /// Checks if the desired device is connected by comparing its communication unit within the statusbar's communication unit list.
        /// Returns true if the expected communication unit has been found.
        /// After initializing the Statusbar_Functions class the 'CommunicationUnit' parameter must be set before executing
        /// the 'IsCommunicationUnitRecognized()' method as its value is passed into this method by its constructor.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsCommunicationUnitRecognized()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            bool isRecognized = false;

            repo.StatusArea.UsbCommunicationUnitList.Click();

            for (int i = 0; i <= repo.StatusArea.UsbCommunicationUnitList.Children.Count - 1; i++)
            {
                string repoElementText = repo.StatusArea.UsbCommunicationUnitListElement.Element.GetAttributeValueText("Name");
                if (repoElementText.Contains(this.communicationUnit))
                {
                    isRecognized = true;
                    Report.Info("Communication unit has been found.");
                    break;
                }

                Report.Info("No suitable device has been found.");
            }

            return isRecognized;
        }

        /// <summary>
        /// Validates if the device is connected
        /// </summary>
        /// <returns>True if connected</returns>
        public bool IsDeviceConnected()
        {
            

            var repo = GUI.DeviceCareApplication.Instance;
            string helpText = repo.StatusArea.ConnectionIndicator.Element.GetAttributeValueText("Tooltip");

            if (helpText.Contains("Online"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Validates if the device is disconnected
        /// </summary>
        /// <returns>True if disconnected</returns>
        public bool IsDeviceDisconnected()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            string helpText = repo.StatusArea.ConnectionIndicator.Element.GetAttributeValueText("HelpText");

            if (helpText.Contains("Not connected"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The get status message.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetStatusMessage()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            return repo.StatusArea.EventMessage_Text.Element.GetAttributeValueText("Text");
        }

        /// <summary>
        /// Waits until circular progress indicator is invisible
        /// for a maximum time period of 5min
        /// </summary>
        /// <returns>True if the action is finished</returns>
        public bool IsActionFinished()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            bool isVisible = Convert.ToBoolean(repo.StatusArea.ProgressIndicator.Element.GetAttributeValue("Visible"));

            Stopwatch timer = new Stopwatch();
            TimeSpan timeOut = TimeSpan.FromMinutes(5);

            Report.Info("Waiting until process is finished...");
            timer.Start();
            while (isVisible)
            {
                isVisible = Convert.ToBoolean(repo.StatusArea.ProgressIndicator.Element.GetAttributeValue("Visible"));
                Delay.Milliseconds(200);
                if (timer.Elapsed == timeOut)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the number of all connected USB modems
        /// </summary>
        /// <returns>The number of all connected USB modems</returns>
        public int GetUSBModemCount()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            return repo.StatusArea.UsbCommunicationUnitList.Children.Count;
        }

        /// <summary>
        /// Gets the name of the attached communication unit if only one is attached
        /// (case automatic scan)
        /// </summary>
        /// <returns>The name of the attached communication unit</returns>
        public string GetCommUnitName()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            repo.StatusArea.UsbCommunicationUnitList.Click();
            Element element = repo.StatusArea.UsbCommunicationUnitListElementText.Element;
            string modemName = element.GetAttributeValueText("Name");
            repo.StatusArea.UsbCommunicationUnitList.Click();
            return modemName;
        }

        /// <summary>
        /// Waits for the scanning action to finish
        /// </summary>
        /// <param name="commDriverName">The name of the communication DTM</param>
        /// <returns>True if scanning was successful</returns>
        public bool WaitForScanning(string commDriverName)
        {
            var repo = GUI.DeviceCareApplication.Instance;

            bool isOnline = false;

            Stopwatch preventDeadlock = new Stopwatch();
            TimeSpan timeOut = TimeSpan.FromMinutes(5);
            preventDeadlock.Start();

            Report.Info("Waiting until device is found...");
            while (isOnline == false)
            {
                Delay.Milliseconds(2000);
                string indicator = repo.StatusArea.ConnectionIndicator.Element.GetAttributeValueText("HelpText");
                if (indicator.Contains("Connected (Online)") & indicator.Contains(commDriverName) == false)
                {
                    isOnline = true;
                }

                if (preventDeadlock.Elapsed > timeOut)
                {
                    Report.Failure("Device was not online after 5 minutes. Terminating the request");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Extracts a file path between ' from a string
        /// </summary>
        /// <param name="input">The string to extract from</param>
        /// <returns>The extracted path or null if no match was found</returns>
        public string GetFileLocationFromStatusMessage(string input)
        {
            // gets everything between '...'
            // look behind character ', exclude character ', every character, lookahead character '
            Regex rgx = new Regex("(?<=')[^']*(?=')");

            Match match = rgx.Match(input);

            if (match.Success)
            {
                return match.ToString();
            }

            return null;
        }

        /// <summary>
        /// Extracts the base path from a string without the file name and extension
        /// </summary>
        /// <param name="input">The path to extract from</param>
        /// <returns>The extracted base path</returns>
        public string GetBasePath(string input)
        {
            // lookbehind character ', exclude character ', every character until (lookahead) last occurence of \ (\ included)
            // Regex rgx = new Regex("(?<=')[^']*(?=\\\\)");

            // matches everything until last occurence of \ (\ included)
            Regex rgx = new Regex("(.*)[\\\\]");

            Match match = rgx.Match(input);

            if (match.Success)
            {
                return match.ToString();
            }

            return null;
        }

        /// <summary>
        /// Opens the event log page regardless which page is shown at the moment
        /// </summary>
        public void OpenEventLog()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            if (repo.DeviceCare.ApplicationArea.EventLogPage.Visible == false)
            {
                repo.StatusArea.EventLog.DoubleClick(Location.Center);
            }
        }

        /// <summary>
        /// Closes the event log page by returning to the previously shown page
        /// </summary>
        public void CloseEventLog()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            if (repo.DeviceCare.ApplicationArea.EventLogPage.Visible)
            {
                repo.StatusArea.EventLog.DoubleClick(Location.Center);
            }
        }
    }
}
