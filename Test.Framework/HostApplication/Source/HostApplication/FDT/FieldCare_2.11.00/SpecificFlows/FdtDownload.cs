//------------------------------------------------------------------------------
// <copyright file="FdtDownload.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 20.04.2012
 * Time: 1:16 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.SpecificFlows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.DtmMessages.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.MenuArea.Toolbar;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;

    using Ranorex;

    /// <summary>
    ///     Interface for flow FDT Download
    /// </summary>
    public class FdtDownload : MarshalByRefObject, IFdtDownload
    {
        /// <summary>
        ///     Run workflow
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run()
        {
            // get download-functionality activated => workaround for fieldcare-defect
            (new IconElements()).DeviceFunctionColored.Click(DefaultValues.durDurationShort);

            // If download-functionality called successfully
            if ((new RunFdtWriteToDevice()).ViaMenu())
            {
                Button button = (new WriteToDeviceInfoMessageElements()).Yes;
                if (button != null && button.Enabled)
                {
                    button.Click(DefaultValues.locDefaultLocation);

                    button = (new WriteToDeviceWarningMessageElements()).Yes;
                    if (button != null && button.Enabled)
                    {
                        button.Click(DefaultValues.locDefaultLocation);
                        var watch = new Stopwatch();

                        // auf progressbar warten
                        watch.Start();
                        ProgressBar progress = (new WritingToDeviceElements()).ProgressBottom;
                        while (progress == null)
                        {
                            if (watch.ElapsedMilliseconds > DefaultValues.GeneralTimeout)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download did not start.");
                                watch.Stop();

                                // fehlermeldung bestätigen wenn vorhanden
                                button = (new WriteToDeviceSuccessMessageElements()).Ok;
                                if (button != null && button.Enabled)
                                {
                                    button.Click(DefaultValues.locDefaultLocation);
                                }

                                return false;
                            }

                            progress = (new WritingToDeviceElements()).ProgressBottom;
                        }

                        watch.Stop();

                        // warten bis progressbar verschwunden
                        watch.Start();
                        progress = (new WritingToDeviceElements()).ProgressBottom;
                        while (progress != null)
                        {
                            if (watch.ElapsedMilliseconds > DefaultValues.DTMDownloadTimeout)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                    "FDT download took to much time or freezed.");
                                watch.Stop();
                                return false;
                            }

                            progress = (new WritingToDeviceElements()).ProgressBottom;
                        }

                        watch.Stop();
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download finished.");

                        button = (new WriteToDeviceSuccessMessageElements()).Ok;
                        if (button != null && button.Enabled)
                        {
                            button.Click(DefaultValues.locDefaultLocation);

                            // TODO: localize strings
                            if ((new DtmMessages()).strGetNewestUserMessage.Contains(
                                    "Writing of the device parameter succeeded"))
                            {
                                return true;
                            }

                            return false;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "FDT download success message box is not available.");
                        return false;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "FDT download warning message box is not available.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "FDT download confirmation message box is not available.");
                return false;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download could not be started.");
            return false;
        }

        /// <summary>
        ///     Return from the download after a specific percent value is reached
        /// </summary>
        /// <param name="percent">progress bar percent</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ReturnAfterPercent(int percent)
        {
            // get download-functionality activated => workaround for fieldcare-bug
            (new IconElements()).DeviceFunctionColored.Click(DefaultValues.durDurationShort);

            // If save-functionality called successfully
            if ((new RunFdtWriteToDevice()).ViaMenu())
            {
                Button button = (new WriteToDeviceInfoMessageElements()).Yes;
                if (button != null && button.Enabled)
                {
                    button.Click(DefaultValues.locDefaultLocation);

                    button = (new WriteToDeviceWarningMessageElements()).Yes;
                    var watch = new Stopwatch();
                    if (button != null && button.Enabled)
                    {
                        button.Click(DefaultValues.locDefaultLocation);

                        // auf progressbar warten
                        watch.Start();
                        ProgressBar progress = (new WritingToDeviceElements()).ProgressBottom;
                        while (progress == null)
                        {
                            if (watch.ElapsedMilliseconds > DefaultValues.DTMDownloadTimeout)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                    "FDT download did not start.");
                                watch.Stop();
                                return false;
                            }

                            progress = (new WritingToDeviceElements()).ProgressBottom;
                        }

                        watch.Stop();

                        // warten bis progressbar Prozent erreicht hat
                        watch.Start();
                        progress = (new WritingToDeviceElements()).ProgressBottom;

                        while (100 * progress.Value / (progress.MinValue - progress.MaxValue) < percent)
                        {
                            if (watch.ElapsedMilliseconds > DefaultValues.DTMDownloadTimeout)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                    "FDT download took to much time or is frozen.");
                                watch.Stop();
                                return false;
                            }

                            progress = (new WritingToDeviceElements()).ProgressBottom;
                        }

                        watch.Stop();
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "FDT download hit " + percent + "% .");

                        // TODO: Strings lokalisieren.
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "FDT download warning message box is not available.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "FDT download confirmation message box is not available.");
                return false;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download could not be started.");
            return false;
        }

        /// <summary>
        ///     Return after the progress bar is invisible
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool WaitForProgressBarInvisible()
        {
            var watch = new Stopwatch();
            watch.Start();
            ProgressBar progressBar = (new WritingToDeviceElements()).ProgressBottom;
            while (progressBar != null)
            {
                if (watch.ElapsedMilliseconds > DefaultValues.DTMDownloadTimeout)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "FDT download took to much time or is frozen.");
                    watch.Stop();
                    return false;
                }

                progressBar = (new WritingToDeviceElements()).ProgressBottom;
            }

            watch.Stop();
            watch.Reset();
            Button button = (new WriteToDeviceWarningMessageElements()).No;
            watch.Start();
            while (button != null)
            {
                button = (new WriteToDeviceWarningMessageElements()).No;
                if (watch.ElapsedMilliseconds > 2000)
                {
                    return true;
                }

                button.Click();
            }

            watch.Stop();
            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT Message Writing to Device appears");
            return false;
        }

        /// <summary>
        ///     Measure Download time and Report them in the Report
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ReportMeasureTime()
        {
            // get download-functionality activated => workaround for FieldCare-defect
            (new IconElements()).DeviceFunctionColored.Click(DefaultValues.durDurationShort);

            var measure = new Stopwatch();
            var watch = new Stopwatch();

            // If download-functionality called successfully
            if ((new RunFdtWriteToDevice()).ViaMenu())
            {
                Button button = (new WriteToDeviceInfoMessageElements()).Yes;
                if (button != null && button.Enabled)
                {
                    button.Click(DefaultValues.locDefaultLocation);

                    button = (new WriteToDeviceWarningMessageElements()).Yes;
                    if (button != null && button.Enabled)
                    {
                        button.Click(DefaultValues.locDefaultLocation);

                        measure.Start();

                        // auf progressbar warten
                        watch.Start();
                        ProgressBar progress = (new WritingToDeviceElements()).ProgressBottom;
                        while (progress == null)
                        {
                            if (watch.ElapsedMilliseconds > DefaultValues.DTMDownloadTimeout)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                    "FDT download did not start.");
                                watch.Stop();
                                return false;
                            }
                            
                            progress = (new WritingToDeviceElements()).ProgressBottom;
                        }

                        watch.Stop();

                        // Read number of DTM Message entys in log
                        int number = (new DtmMessagesElements()).RowMessages.Count;
                        int numberNew = (new DtmMessagesElements()).RowMessages.Count;
                        
                        // Check for new entries in Message Log 
                        watch.Start();
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Wait for Message Log Entry");
                        while (numberNew <= number)
                        {
                            if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                    "FDT upload took to much time or is frozen.");
                                watch.Stop();
                                return false;
                            }

                            numberNew = (new DtmMessagesElements()).RowMessages.Count;

                            // EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Number Start = " + number.ToString() + " Number actuel = " + numberNew.ToString());
                        }

                        measure.Stop();

                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Stop measuring at " + (measure.ElapsedMilliseconds / 1000) + "s.");

                        // Wait until progress bar disappeared
                        watch.Start();
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Wait for Progessbar inviseble");
                        progress = (new WritingToDeviceElements()).ProgressBottom;
                        while (progress != null)
                        {
                            if (watch.ElapsedMilliseconds > DefaultValues.DTMDownloadTimeout)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()), 
                                    "FDT download took to much time or is frozen.");
                                watch.Stop();
                                return false;
                            }

                            progress = (new WritingToDeviceElements()).ProgressBottom;
                        }

                        watch.Stop();
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download finished.");
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), 
                            "Time is " + (measure.ElapsedMilliseconds / 1000) + "s.");

                        button = (new WriteToDeviceSuccessMessageElements()).Ok;
                        if (button != null && button.Enabled)
                        {
                            button.Click(DefaultValues.locDefaultLocation);

                            // TODO: Strings lokalisieren.
                            if (
                                (new DtmMessages()).strGetNewestUserMessage.Contains(
                                    "Writing of the device parameter succeeded"))
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                    "Time is " + (measure.ElapsedMilliseconds / 1000) + "s.");
                                return true;
                            }

                            return false;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "FDT download success message box is not available.");
                        button = (new WriteToDeviceSuccessMessageElements()).Ok;
                        if (button != null && button.Enabled)
                        {
                            button.Click(DefaultValues.locDefaultLocation);

                            // TODO: localize strings
                            if (
                                (new DtmMessages()).strGetNewestUserMessage.Contains(
                                    "Writing of the device parameter succeeded"))
                            {
                                return true;
                            }

                            return false;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "FDT download success message box is not available.");
                        return false;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "FDT download warning message box is not available.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "FDT download confirmation message box is not available.");
                return false;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT download could not be started.");
            return false;
        }
    }
}