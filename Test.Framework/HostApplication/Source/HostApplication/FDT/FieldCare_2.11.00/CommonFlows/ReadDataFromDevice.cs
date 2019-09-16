//------------------------------------------------------------------------------
// <copyright file="ReadDataFromDevice.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V21100.CommonFlows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.DtmMessages.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs;

    using Ranorex;

    /// <summary>
    /// Provides methods for executing an upload (reading from device) by HostApplication
    /// </summary>
    public class ReadDataFromDevice : MarshalByRefObject, IReadDataFromDevice
    {
        /// <summary>
        /// Performs an FDT Upload
        /// </summary>
        /// <returns>true: if upload was successful; false: if an error occurred</returns>
        public bool Run()
        {
            // If save-functionality called successfully
            if ((new RunFdtReadFromDevice()).ViaMenu())
            {
                Button button = (new ReadFromDeviceMessageElements()).Yes;
                if (button != null && button.Enabled)
                {
                    button.Click(DefaultValues.locDefaultLocation);

                    if (this.WaitUntilProgressBarAppears() == false)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT upload did not start.");
                        return false;
                    }

                    if (this.WaitUntilProgressBarDisappears() == false)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT upload took to much time or is frozen.");
                        return false;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT upload finished.");

                    // TODO: localize strings
                    if ((new DtmMessages()).strGetNewestUserMessage.Contains("Reading of the device parameter succeeded"))
                    {
                        return true;
                    }

                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT Upload message box is not available.");
                return false;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FDT Upload could not be started.");
            return false;
        }

        /// <summary>
        ///     Wait until progress bar appears
        /// </summary>
        /// <returns>true: if progress bar appeared; false: if an error occurred</returns>
        private bool WaitUntilProgressBarAppears()
        {
            var watch = new Stopwatch();
            watch.Start();
            ProgressBar progress = (new ReadingFromDeviceElements()).ProgressBottom;
            while (progress == null)
            {
                if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                {
                    watch.Stop();
                    return false;
                }

                progress = (new ReadingFromDeviceElements()).ProgressBottom;
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
            ProgressBar progress = (new ReadingFromDeviceElements()).ProgressBottom;
            watch.Start();
            while (progress != null)
            {
                if (watch.ElapsedMilliseconds > DefaultValues.DTMUploadTimeout)
                {
                    watch.Stop();
                    return false;
                }

                progress = (new ReadingFromDeviceElements()).ProgressBottom;
            }

            watch.Stop();
            return true;
        }
    }
}