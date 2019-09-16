//------------------------------------------------------------------------------
// <copyright file="FDTUpload.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V21000.SpecificFlows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.FieldCare.V21000.Functions.Dialogs.DtmMessages.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21000.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21000.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Workflow Close.
    /// </summary>
    public class FdtUpload : MarshalByRefObject, IFdtUpload
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
            // If save-functionality called successfully
            if ((new RunFdtReadFromDevice()).ViaMenu())
            {
                Button button = (new ReadFromDeviceMessageElements()).Yes;
                if (button != null && button.Enabled)
                {
                    button.Click(DefaultValues.locDefaultLocation);
                    var watch = new Stopwatch();

                    // auf progressbar warten
                    watch.Start();
                    ProgressBar progress = (new ReadingFromDeviceElements()).ProgressBottom;
                    while (progress == null)
                    {
                        if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT upload did not start.");
                            watch.Stop();
                            return false;
                        }
                        progress = (new ReadingFromDeviceElements()).ProgressBottom;
                    }
                    watch.Stop();

                    // warten bis progressbar verschwunden
                    watch.Start();
                    progress = (new ReadingFromDeviceElements()).ProgressBottom;
                    while (progress != null)
                    {
                        if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                           "FDT upload took to much time or freezed.");
                            watch.Stop();
                            return false;
                        }
                        progress = (new ReadingFromDeviceElements()).ProgressBottom;
                    }
                    watch.Stop();
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT upload finished.");

                    // TODO: Strings lokalisieren.
                    if ((new DtmMessages()).strGetNewestUserMessage.Contains("Reading of the device parameter succeeded"))
                    {
                        return true;
                    }
                    return false;
                }
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                               "FDT Upload message box is not available.");
                return false;
            }
            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT Upload could not be started.");
            return false;
        }

        /// <summary>
        ///     Return from the upload after a specific percent value is reached
        /// </summary>
        /// <param name="percent"></param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ReturnAfterPercent(int percent)
        {
            // If save-functionality called successfully
            if ((new RunFdtReadFromDevice()).ViaMenu())
            {
                Button button = (new ReadFromDeviceMessageElements()).Yes;
                if (button != null && button.Enabled)
                {
                    button.Click(DefaultValues.locDefaultLocation);
                    var watch = new Stopwatch();

                    // auf progressbar warten
                    watch.Start();
                    ProgressBar progress = (new ReadingFromDeviceElements()).ProgressBottom;
                    while (progress == null)
                    {
                        if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT upload did not start.");
                            watch.Stop();
                            return false;
                        }
                        progress = (new ReadingFromDeviceElements()).ProgressBottom;
                    }
                    watch.Stop();

                    // warten bis progressbar Prozent erreicht hat
                    watch.Start();
                    progress = (new ReadingFromDeviceElements()).ProgressBottom;
                    while (100*progress.Value/(progress.MinValue - progress.MaxValue) < percent)
                    {
                        if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                           "FDT upload took to much time or freezed.");
                            watch.Stop();
                            return false;
                        }
                        progress = (new ReadingFromDeviceElements()).ProgressBottom;
                    }
                    watch.Stop();
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                "FDT upload reached" + percent.ToString() + "% .");

                    // TODO: Strings lokalisieren.
                    return true;
                }
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                               "FDT Upload message box is not available.");
                return false;
            }
            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT Upload could not be started.");
            return false;
        }

        /// <summary>
        ///     Return after the Progessbar is inviseble
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool WaitForProgresbarInviseble()
        {
            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module Start");
            var watch = new Stopwatch();
            ProgressBar progress = (new ReadingFromDeviceElements()).ProgressBottom;
            watch.Start();
            progress = (new ReadingFromDeviceElements()).ProgressBottom;
            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module Schleife start");
            while (progress != null)
            {
                if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                   "FDT upload took to much time or freezed.");
                    watch.Stop();
                    return false;
                }
                progress = (new ReadingFromDeviceElements()).ProgressBottom;
            }
            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Schleife und Module ende");
            watch.Stop();
            return true;
        }


        /// <summary>
        ///     Messure Upload time and Report them in the Ranorex Report
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ReportMessureTime()
        {
            var messure = new Stopwatch();
            var watch = new Stopwatch();

            int number = (new DtmMessagesElements()).RowMessages.Count;
            //EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Message Number" + number.ToString());

            // If save-functionality called successfully
            if ((new RunFdtReadFromDevice()).ViaMenu())
            {
                Button button = (new ReadFromDeviceMessageElements()).Yes;
                if (button != null && button.Enabled)
                {
                    button.Click(DefaultValues.locDefaultLocation);
                    messure.Start();
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Start Time messurment");

                    // auf progressbar warten
                    watch.Start();
                    ProgressBar progress = (new ReadingFromDeviceElements()).ProgressBottom;
                    while (progress == null)
                    {
                        if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT upload did not start.");
                            watch.Stop();
                            return false;
                        }
                        progress = (new ReadingFromDeviceElements()).ProgressBottom;
                    }
                    watch.Stop();

                    //Read number of DTM Message entys in log

                    int numberNew = (new DtmMessagesElements()).RowMessages.Count;

                    //Prüfen auf neue einträge in Message Log

                    watch.Start();
                    while (numberNew <= number)
                    {
                        if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                           "FDT upload took to much time or freezed.");
                            watch.Stop();
                            return false;
                        }
                        //EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Number Start = " + number.ToString() + " Number actuel = " + numberNew.ToString());
                        //EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), messure.ElapsedMilliseconds / 1000 + "s.");
                        numberNew = (new DtmMessagesElements()).RowMessages.Count;
                    }
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                "Stop messuring at " + messure.ElapsedMilliseconds/1000 + "s.");
                    messure.Stop();

                    // warten bis progressbar verschwunden
                    watch.Start();
                    ProgressBar progressbar = (new ReadingFromDeviceElements()).ProgressBottom;
                    while (progressbar != null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                       progressbar.ToString() + messure.ElapsedMilliseconds/1000);
                        if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                           "FDT upload took to much time or freezed.");
                            watch.Stop();
                            return false;
                        }
                        progressbar = (new ReadingFromDeviceElements()).ProgressBottom;
                    }
                    watch.Stop();
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT upload finished.");
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                   "Time is " + messure.ElapsedMilliseconds/1000 + "s.");
                    // TODO: Strings lokalisieren.
                    if ((new DtmMessages()).strGetNewestUserMessage.Contains("Reading of the device parameter succeeded"))
                    {
                        return true;
                    }
                    return false;
                }
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                               "FDT Upload message box is not available.");
                return false;
            }
            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT Upload could not be started.");
            return false;
        }
    }
}