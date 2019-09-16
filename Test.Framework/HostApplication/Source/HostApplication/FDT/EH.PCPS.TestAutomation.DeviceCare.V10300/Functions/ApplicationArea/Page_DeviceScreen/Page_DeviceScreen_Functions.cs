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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_DeviceScreen
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text.RegularExpressions;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceCare.V10300.GUI;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

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
            repo.MenuArea.MainMenu.DeviceReport.Click();
        }

        /// <summary>
        /// Clicks the "Additional functions" or "DTM functions" button depending on input
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool OpenDtmFunctions()
        {
            try
            {
                var repo = GUI.DeviceCareApplication.Instance;
                repo.MenuArea.MainMenu.DTMFunctions.Focus();
                repo.MenuArea.MainMenu.DTMFunctions.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// The open additional functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool OpenAdditionalFunctions()
        {
            try
            {
                var repo = GUI.DeviceCareApplication.Instance;
                repo.MenuArea.MainMenu.AdditionalFunctions.Focus();
                repo.MenuArea.MainMenu.AdditionalFunctions.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Clicks on button "ProgramFunctions"
        /// </summary>
        public void OpenProgramFunctionsMenu()
        {
            var repo = GUI.DeviceCareApplication.Instance;

            repo.MenuArea.MainMenu.ProgramFunctions.Click();
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
                    repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.RestoreDeviceData.Click();
                    repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.RestoreBrowse.Click();
                    break;
                case false:
                    repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.SaveDeviceData.Click();
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

            repo.MenuArea.MainMenu.ProgramFunctions.Focus();
            repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.ReadFromDevice.Click();

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

            repo.MenuArea.MainMenu.ProgramFunctions.Focus();
            repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.WriteToDevice.Click();

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
                        //repo.MenuArea.MainMenu.DTMFunctionMember.Diagnosis_Text.Click();
                        //return true;
                        return false;
                    case "Observe":
                        //repo.MenuArea.MainMenu.DTMFunctionMember.Observe_Text.Click();
                        //return true;
                        return false;
                    case "OnlineParameterization":
                        repo.MenuArea.MainMenu.DTMFunctionMenuItems.OnlineParameterization_Text.Click();
                        return true;
                    case "Simulation":
                        //repo.MenuArea.MainMenu.DTMFunctionMember.Simulation_Text.Click();
                        //return true;
                        return false;
                    default:
                        Report.Failure("The desired function \"" + this.DeviceFunctionName + "\" could not be found. Make sure that the item is spelled correctly");
                        return false;
                }
            }
            
            // Case: Additional function
            switch (trimmedName)
            {
                case "Reset":
                    // repo.MenuArea.MainMenu.AdditionalFunctionMember.Reset_Text.Click();
                    // return true;
                    return false;
                case "Lock/Unlock":
                    // repo.MenuArea.MainMenu.AdditionalFunctionMember.Lock_Unlock_Text.Click();
                    // return true;
                    return false;
                case "Create Documentation":
                    // repo.MenuArea.MainMenu.AdditionalFunctionMember.CreateDcoumentation_Text.Click();
                    // return true;
                    return false;
                case "Save / Restore":
                    // repo.MenuArea.MainMenu.AdditionalFunctionMember.Save_Restore_Text.Click();
                    // return true;
                    return false;
                case "Linearization Table (online)":
                    // repo.MenuArea.MainMenu.AdditionalFunctionMember.LinearizationTable_Online_Text.Click();
                    // return true;
                    return false;
                case "Linearization Table (offline)":
                    // repo.MenuArea.MainMenu.AdditionalFunctionMember.LinearizationTable_Offline_Text.Click();
                    // return true;
                    return false;
                case "HistoROM":
                    // repo.MenuArea.MainMenu.AdditionalFunctionMember.HistoROM_Text.Click();
                    // return true;
                    return false;
                case "Process Trend":
                    // repo.MenuArea.MainMenu.AdditionalFunctionMember.ProcessTrend_Text.Click();
                    // return true;
                    return false;
                case "About":
                    // repo.MenuArea.MainMenu.AdditionalFunctionMember.About_Text.Click();
                    // return true;
                    return false;
                case "Refresh Online Data":
                    // repo.MenuArea.MainMenu.AdditionalFunctionMember.RefreshOnlineData_Text.Click();
                    // return true;
                    return false;
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

            repo.MenuArea.MainMenu.ProgramFunctions.Focus();
            repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.ToggleOnline.Click();
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

            while (repo.StatusArea.ProgressIndicator.Visible == false)
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
            Text repoFunctionIdentifier = null;

            // Case: DTM Function
            if (this.IsAdditionalFunction == false)
            {
                switch (this.DeviceFunctionName)
                {
                    case "Diagnosis":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.DTMFunctionMember.Diagnosis_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "Observe":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.DTMFunctionMember.Observe_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "OnlineParameterization":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.DTMFunctionMember.OnlineParameterization_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "Simulation":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.DTMFunctionMember.Simulation_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "OfflineParameterization":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.DTMFunctionMember.DeviceOfflineSupport.OfflineParameterization_Text;
                        repoFunctionIdentifier = null;
                        break;
                }
            }
            else
            {
                // Case: Additional function
                switch (this.DeviceFunctionName)
                {
                    case "Reset":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.AdditionalFunctionMember.Reset_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "Lock/Unlock":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.AdditionalFunctionMember.Lock_Unlock_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "Create Documentation":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.AdditionalFunctionMember.CreateDcoumentation_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "Save / Restore":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.AdditionalFunctionMember.Save_Restore_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "Linearization Table (online)":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.AdditionalFunctionMember.LinearizationTable_Online_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "Linearization Table (offline)":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.AdditionalFunctionMember.LinearizationTable_Offline_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "HistoROM":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.AdditionalFunctionMember.HistoROM_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "Process Trend":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.AdditionalFunctionMember.ProcessTrend_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "About":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.AdditionalFunctionMember.About_Text;
                        repoFunctionIdentifier = null;
                        break;
                    case "Refresh Online Data":
                        // repoFunctionIdentifier = repo.MenuArea.MainMenu.AdditionalFunctionMember.RefreshOnlineData_Text;
                        repoFunctionIdentifier = null;
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
        /// <param name="moduleName">
        /// The module Name.
        /// </param>
        /// <returns>
        /// True if the tab is shown
        /// </returns>
        public bool IsTabOpen(string moduleName)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checking if the function tab is open...");

            DeviceCareApplication deviceCareApplication = DeviceCareApplication.Instance;
            RepoItemInfo repo = deviceCareApplication.ApplicationArea.ModuleSelection.TabCloseButtonInfo;
            string modifiedPath = repo.AbsolutePath.ToString().Replace("MODULENAME", moduleName);

            Button button;
            Host.Local.TryFindSingle((RxPath)modifiedPath, DefaultValues.GeneralTimeout, out button);
            if (button != null)
            {
                return true;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The desired function tab is not open");
            return false;
        }

        /// <summary>
        /// The get number of open modules.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetNumberOfOpenModules()
        {
            try
            {
                DeviceCareApplication deviceCareApplication = DeviceCareApplication.Instance;
                RepoItemInfo repo = deviceCareApplication.ApplicationArea.ModuleSelection.TabCloseButtonInfo;

                System.Collections.Generic.IList<TabPage> tabPages;
                tabPages = Host.Local.Find<TabPage>(repo.AbsolutePath);

                return tabPages.Count;
            }
            catch (Exception)
            {
                return 0;
            }
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

                if (repo.MenuArea.MainMenu.DTMFunctionMenuItems.OfflineParameterizationInfo.Exists())
                {
                    watch.Stop();
                    if (repo.MenuArea.MainMenu.DTMFunctionMenuItems.OfflineParameterization.Element.Visible)
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
