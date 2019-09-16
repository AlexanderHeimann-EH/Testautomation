//------------------------------------------------------------------------------
// <copyright file="WriteDataToDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 25.02.2014
 * Time: 14:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21000.CommonFlows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    
    using Ranorex;

    /// <summary>
    /// Provides methods for performing a download (writing to device) by HostApplication
    /// </summary>
    public class WriteDataToDevice : MarshalByRefObject, IWriteDataToDevice
    {
        /// <summary>
        /// Writes information to the device (download)
        /// </summary>
        /// <returns>True in case of success, false in case of an error</returns>
        public bool Run()
        {
            // get download-functionality activated => workaround for FieldCare-defect
            new Functions.MenuArea.Menubar.Execution.RunDeviceFunction().ViaMenu();

            // If download-functionality called successfully
            if ((new Functions.MenuArea.Menubar.Execution.RunFdtWriteToDevice()).ViaMenu())
            {
                Button button = (new GUI.Dialogs.WriteToDeviceInfoMessageElements()).Yes;
                if (button != null && button.Enabled)
                {
                    button.Click(DefaultValues.locDefaultLocation);

                    button = (new GUI.Dialogs.WriteToDeviceWarningMessageElements()).Yes;
                    if (button != null && button.Enabled)
                    {
                        button.Click(DefaultValues.locDefaultLocation);
                        
                        // Wait for progress bar
                        if (this.WaitUntilProgressBarAppears() == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download did not start.");

                            // Confirm error message if available
                            button = (new GUI.Dialogs.WriteToDeviceSuccessMessageElements()).Ok;
                            if (button != null && button.Enabled)
                            {
                                button.Click(DefaultValues.locDefaultLocation);
                            }

                            return false;
                        }

                        // Wait until progress bar disappeared
                        if (this.WaitUntilProgressBarDisappears() == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download took to much time or is frozen.");
                            return false;
                        }

                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download finished.");
                        button = (new GUI.Dialogs.WriteToDeviceSuccessMessageElements()).Ok;
                        if (button != null && button.Enabled)
                        {
                            button.Click(DefaultValues.locDefaultLocation);

                            // TODO: localize strings
                            if ((new Functions.Dialogs.DtmMessages.Execution.DtmMessages()).strGetNewestUserMessage.Contains("Writing of the device parameter succeeded"))
                            {
                                return true;
                            }

                            return false;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download success message box is not available.");
                        return false;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download warning message box is not available.");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download confirmation message box is not available.");
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download could not be started.");
            return false;
        }

        /// <summary>
        ///     Performs a FDT Download when no "offline device data" is available and a file has to be selected (e.g. DeviceCare)
        /// </summary>
        /// <param name="filename">File used for download</param>
        /// <returns>true: if FDT-download finished; false: if an error occurred</returns>
        public bool Run(string filename)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Wait until progress bar appears
        /// </summary>
        /// <returns>true: if progress bar appeared; false: if an error occurred</returns>
        private bool WaitUntilProgressBarAppears()
        {
            var watch = new Stopwatch();
            watch.Start();
            ProgressBar progress = (new GUI.Dialogs.ReadingFromDeviceElements()).ProgressBottom;
            while (progress == null)
            {
                if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                {
                    watch.Stop();
                    return false;
                }

                progress = (new GUI.Dialogs.ReadingFromDeviceElements()).ProgressBottom;
            }

            watch.Stop();
            return true;
        }

        /// <summary>
        ///     Wait until progress bar disappears
        /// </summary>
        /// <returns>true: if progress bar disappeared; false: if an error occurred</returns>
        private bool WaitUntilProgressBarDisappears()
        {
            var watch = new Stopwatch();
            ProgressBar progress = (new GUI.Dialogs.ReadingFromDeviceElements()).ProgressBottom;
            watch.Start();
            while (progress != null)
            {
                if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                {
                    watch.Stop();
                    return false;
                }

                progress = (new GUI.Dialogs.ReadingFromDeviceElements()).ProgressBottom;
            }

            watch.Stop();
            return true;
        }
    }
}