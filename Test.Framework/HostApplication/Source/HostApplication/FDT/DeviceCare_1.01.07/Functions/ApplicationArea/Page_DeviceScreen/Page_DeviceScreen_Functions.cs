// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Page_DeviceScreen_Functions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of Page_DeviceScreen_Functions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 16.09.2015
 * Time: 14:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_DeviceScreen
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text.RegularExpressions;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    /// Description of Page_DeviceScreen_Functions.
    /// </summary>
    public class Page_DeviceScreen_Functions
    {
        // set from caller;
        // true if function to call is an additional function

        /// <summary>
        /// Gets or sets a value indicating whether is additional function.
        /// </summary>
        public bool IsAdditionalFunction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is restore request.
        /// </summary>
        public bool IsRestoreRequest { get; set; }

        /// <summary>
        /// Gets or sets the device function name.
        /// </summary>
        public string DeviceFunctionName { get; set; }

        /// <summary>
        /// Gets or sets the tab absolute path.
        /// </summary>
        private string TabAbsolutePath { get; set; }

        /// <summary>
        /// Clicks the "Device Report" button in DC
        /// </summary>
        public void ClickFDTPrintButton()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.FDTPrint.Click();
        }

        /// <summary>
        /// Clicks the "Additional functions" or "DTM functions" button depending on input
        /// </summary>
        public void ClickFunctionMenu()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            if (this.IsAdditionalFunction)
            {
                repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctions.Focus();
                repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctions.Click();
            }
            else
            {
                repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctions.Focus();
                repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctions.Click();
            }
        }

        /// <summary>
        /// Clicks on button "ProgramFunctions"
        /// </summary>
        public void OpenProgramFunctionsMenu()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.ProgramFunctions.Click();
        }

        /// <summary>
        /// Clicks the button "save" or "restore" depending on the caller of this method
        /// </summary>
        public void RunDTMFunction()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            switch (this.IsRestoreRequest)
            {
                case true:
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.ProgramFunctionsMember.RestoreDeviceData.Click();
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.ProgramFunctionsMember.RestoreBrowse.Click();
                    break;
                case false:
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.ProgramFunctionsMember.SaveDeviceData.Click();
                    break;
            }
        }

        /// <summary>
        /// Performs an FDT upload and waits until the action is finished
        /// </summary>
        /// <returns>True if upload was successful</returns>
        public bool ReadFromDevice()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            var statusbarFunctions = new StatusArea.Statusbar.Statusbar_Functions();

            repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.ProgramFunctions.Focus();
            repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.ProgramFunctionsMember.DeviceOfflineSupport.ReadFromDevice.Click();

            bool actionFinished = statusbarFunctions.IsActionFinished();

            if (actionFinished)
            {
                string msg = statusbarFunctions.GetStatusMessage();

                if (msg.Contains("unsuccessful"))
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Performs an FDT download and waits until the action is finished
        /// </summary>
        /// <returns>True if upload was successful</returns>
        public bool WriteToDevice()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            var statusbarFunctions = new StatusArea.Statusbar.Statusbar_Functions();

            repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.ProgramFunctions.Focus();
            repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.ProgramFunctionsMember.DeviceOfflineSupport.WriteToDevice.Click();

            bool actionFinished = statusbarFunctions.IsActionFinished();

            if (actionFinished)
            {
                string msg = statusbarFunctions.GetStatusMessage();

                if (msg.Contains("unsuccessful"))
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Executes a DTM or Additional function depending on input
        /// </summary>
        /// <returns>True if the item was found and clicked on</returns>
        public bool ClickDeviceFunction()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            string trimmedName = this.DeviceFunctionName.Trim();

            // Case: DTM function
            if (this.IsAdditionalFunction == false)
            {
                switch (trimmedName)
                {
                    case "Diagnosis":
                        repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.Diagnosis_Text.Click();
                        return true;
                    case "Observe":
                        repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.Observe_Text.Click();
                        return true;
                    case "OnlineParameterization":
                        repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.OnlineParameterization_Text.Click();
                        return true;
                    case "Simulation":
                        repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.Simulation_Text.Click();
                        return true;
                    default:
                        Report.Failure("The desired function \"" + this.DeviceFunctionName + "\" could not be found. Make sure that the item is spelled correctly");
                        return false;
                }
            }
            
            // Case: Additional function
            switch (trimmedName)
            {
                case "Reset":
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.Reset_Text.Click();
                    return true;
                case "Lock/Unlock":
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.Lock_Unlock_Text.Click();
                    return true;
                case "Create Documentation":
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.CreateDcoumentation_Text.Click();
                    return true;
                case "Save / Restore":
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.Save_Restore_Text.Click();
                    return true;
                case "Linearization Table (online)":
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.LinearizationTable_Online_Text.Click();
                    return true;
                case "Linearization Table (offline)":
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.LinearizationTable_Offline_Text.Click();
                    return true;
                case "HistoROM":
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.HistoROM_Text.Click();
                    return true;
                case "Process Trend":
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.ProcessTrend_Text.Click();
                    return true;
                case "About":
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.About_Text.Click();
                    return true;
                case "Refresh Online Data":
                    repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.RefreshOnlineData_Text.Click();
                    return true;
                default:
                    Report.Failure("The desired function \"" + this.DeviceFunctionName + "\" could not be found. Make sure that the item is spelled correctly");
                    return false;
            }
        }

        /// <summary>
        /// Clicks the toggle online button
        /// </summary>
        public void ToggleOnline()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.ProgramFunctions.Focus();
            repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.ProgramFunctionsMember.DeviceOfflineSupport.ToggleOnline.Click();
        }

        /// <summary>
        /// Closes a function tab by creating a new adapter
        /// </summary>
        public void CloseFunctionTab()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            // input path: module variable which is set when IsTabOpen() was executed previously
            string functionTabAbsolutePath = this.TabAbsolutePath;

            // search pattern matching only "/text[...]" NOTE: whitespaces after ] are included
            var functionTabTextSearchPattern = "(\\/text).*";

            // string to replace the /text part of the path
            string closeButtonPathString = @"/button[@automationid='tabButton']";

            Regex rgx = new Regex(functionTabTextSearchPattern);

            string result = rgx.Replace(functionTabAbsolutePath, closeButtonPathString);

            // create adapter from rxpath and click it
            Button buttonClose;
            if (Host.Local.TryFindSingle(result, out buttonClose))
            {
                buttonClose.Click();
            }
        }

        /// <summary>
        /// Waits for the restore action to finish and checks
        /// if the action was successful
        /// </summary>
        /// <returns>True if successful</returns>
        public bool IsRestoreFinished()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            var statusbarFunctions = new StatusArea.Statusbar.Statusbar_Functions();

            // get event message
            string msg = statusbarFunctions.GetStatusMessage();
            Report.Debug("Message: " + msg);

            while (repo.DeviceCare.StatusArea.ProgressIndicator.Visible == false)
            {
                Delay.Milliseconds(200);
            }
            
            // wait for progress to finish
            statusbarFunctions.IsActionFinished();

            // check event log
            string msg2 = statusbarFunctions.GetStatusMessage();
            Report.Debug("Message: " + msg2);

            if (msg2.Contains("unsuccessful"))
            {
                Report.Failure("Restoring DTM data was unsuccessful");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if a device function button is enabled or disabled
        /// </summary>
        /// <returns>'True' if the function button is disabled</returns>
        public bool IsFunctionEnabled()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            Text repoFunctionIdentifier = repo.DeviceCare.TitleArea.TitleText;

            // Case: DTM Function
            if (this.IsAdditionalFunction == false)
            {
                switch (this.DeviceFunctionName)
                {
                    case "Diagnosis":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.Diagnosis_Text;
                        break;
                    case "Observe":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.Observe_Text;
                        break;
                    case "OnlineParameterization":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.OnlineParameterization_Text;
                        break;
                    case "Simulation":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.Simulation_Text;
                        break;
                    case "OfflineParameterization":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.DeviceOfflineSupport.OfflineParameterization_Text;
                        break;
                }
            }
            else
            {
                // Case: Additional function
                switch (this.DeviceFunctionName)
                {
                    case "Reset":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.Reset_Text;
                        break;
                    case "Lock/Unlock":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.Lock_Unlock_Text;
                        break;
                    case "Create Documentation":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.CreateDcoumentation_Text;
                        break;
                    case "Save / Restore":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.Save_Restore_Text;
                        break;
                    case "Linearization Table (online)":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.LinearizationTable_Online_Text;
                        break;
                    case "Linearization Table (offline)":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.LinearizationTable_Offline_Text;
                        break;
                    case "HistoROM":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.HistoROM_Text;
                        break;
                    case "Process Trend":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.ProcessTrend_Text;
                        break;
                    case "About":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.About_Text;
                        break;
                    case "Refresh Online Data":
                        repoFunctionIdentifier = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.AdditionalFunctionMember.RefreshOnlineData_Text;
                        break;
                }
            }

            bool enabled = Convert.ToBoolean(repoFunctionIdentifier.Element.GetAttributeValue("Enabled"));
            if (enabled == false)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Validates if the DTM functions button opens the menuitem list correctly
        /// </summary>
        /// <returns>True if the list is shown</returns>
        public bool IsDTMFunctionMenuShown()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checking if the menu is visible...");

            if (repo.DeviceCare.MenuItemContainer.Visible && repo.DeviceCare.MenuItemContainer.Element != null)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The menu is visible");
                return true;
            }

            Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The menu is not visible");
            return false;
        }

        /// <summary>
        /// Validates if the desired function tab is displayed
        /// </summary>
        /// <returns>True if the tab is shown</returns>
        public bool IsTabOpen()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            repo.TabName = this.DeviceFunctionName;

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checking if the function tab is open...");

            if (repo.DeviceCare.ApplicationArea.FunctionTab.Visible && repo.DeviceCare.ApplicationArea.FunctionTab.Element != null)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The desired function tab is open");
                this.TabAbsolutePath = repo.DeviceCare.ApplicationArea.FunctionTab.GetPath().ToResolvedString();
                return true;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The desired function tab is not open");
            return false;
        }

        /// <summary>
        /// Validates if the desired function tab is closed
        /// </summary>
        /// <returns>True if tab is closed</returns>
        public bool IsTabClosed()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            repo.TabName = this.DeviceFunctionName;

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checking if the function tab was successfully closed...");

            Stopwatch watch = new Stopwatch();
            watch.Start();
            bool isAvailable = true;
            while (watch.ElapsedMilliseconds < 10000 && isAvailable)
            {
                if (watch.ElapsedMilliseconds >= 10000)
                {
                    // return false;
                }

                if (!repo.DeviceCare.ApplicationArea.FunctionTabInfo.Exists())
                {
                    watch.Stop();
                    isAvailable = false;
                    
                    // return true;
                }
            }

            // if (repo.DeviceCare.ApplicationArea.FunctionTabInfo.Exists(10000) == false)
            if (isAvailable == false)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The function tab was successfully closed");
                return true;
            }

            Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The function tab is still open and visible");
            return false;
        }

        /// <summary>
        /// Validates if a device supports offline functionality
        /// </summary>
        /// <returns>True if offline is supported</returns>
        public bool IsOfflineSupported()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            // bool exists = repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.DeviceOfflineSupport.OfflineParameterizationInfo.Exists(5000);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds < 10000)
            {
                if (watch.ElapsedMilliseconds >= 10000)
                {
                    return false;
                }

                if (repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.DeviceOfflineSupport.OfflineParameterizationInfo.Exists())
                {
                    watch.Stop();
                    if (repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.DeviceOfflineSupport.OfflineParameterization.Element.Visible)
                    {
                        return true;
                    }
                }
            }

            // if (exists)
            // {
            //    if (repo.DeviceCare.MenuArea.Menu_DeviceScreen.MainMenu.DTMFunctionMember.DeviceOfflineSupport.OfflineParameterization.Element.Visible)
            //    {
            //        return true;
            //    }
            // }
            return false;
        }
    }
}
