// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseHostApplication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.FieldCare.V21000.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.FieldCare.V21000.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21000.GUI.Dialogs;

    using Ranorex;

    /// <summary>
    ///     Provides methods for closing FieldCare
    /// </summary>
    public class CloseHostApplication : MarshalByRefObject, ICloseHostApplication
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Closes HostApplication without saving
        /// </summary>
        /// <returns>true: if HostApplication is closed; false: if an error occurred</returns>
        public bool Run()
        {
            // If save-functionality called successfully
            if ((new RunFrameExit()).ViaMenu())
            {
                this.ConfirmShutdownDTMs();
                this.NoProjectSaving();

                if ((new WaitUntilFrameClosed()).Run(DefaultValues.GeneralTimeout))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame is closed. Waiting for all processes to finish...");
                    this.WaitForFcProcessesToEnd(DefaultValues.iTimeoutMedium);
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame is not closed after: " + DefaultValues.GeneralTimeout + " Milliseconds");
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function RunFrameExit was not successful.");
            return false;
        }

        /// <summary>
        /// Closes the HostApplication
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// Time for action to finish
        /// </param>
        /// <returns>
        /// true in case of success;false in case of an error
        /// </returns>
        /// <exception cref="System.NotImplementedException">
        /// Not implemented
        /// </exception>
        public bool Run(int timeOutInMilliseconds)
        {
            // If save-functionality called successfully
            if ((new RunFrameExit()).ViaMenu())
            {
                this.ConfirmShutdownDTMs();
                this.NoProjectSaving();

                if ((new WaitUntilFrameClosed()).Run(timeOutInMilliseconds))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame is closed. Waiting for all processes to finish...");
                    this.WaitForFcProcessesToEnd(DefaultValues.iTimeoutMedium);
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame is not closed after: " + timeOutInMilliseconds + " Milliseconds");
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function RunFrameExit was not successful.");
            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Confirm shutdown of DTM in case of upcoming related message box
        /// </summary>
        private void ConfirmShutdownDTMs()
        {
            var watch = new Stopwatch();
            watch.Start();
            Button buttonShutdownYes = (new ShutdownDtmMessageElements()).Ok;
            while (buttonShutdownYes == null && watch.ElapsedMilliseconds < 10000)
            {
                buttonShutdownYes = (new ShutdownDtmMessageElements()).Ok;
            }

            watch.Stop();
            if (buttonShutdownYes != null)
            {
                buttonShutdownYes.Click(DefaultValues.locDefaultLocation);
            }
        }

        /// <summary>
        /// Gets the FieldCare processes.
        /// </summary>
        /// <returns>List with active FieldCare processes.</returns>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:FieldNamesMustBeginWithLowerCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        private IList<Process[]> GetFcProcesses()
        {
            try
            {
                IList<Process[]> processList = new List<Process[]>();

                var fmpframe = Process.GetProcessesByName("fmpframe");
                if (fmpframe.Length > 0)
                {
                    processList.Add(fmpframe);
                }

                ////var fmpgu = Process.GetProcessesByName("fmpgu");
                ////if (fmpgu.Length > 0)
                ////{
                ////    processList.Add(fmpgu);
                ////}

                ////var fmpwr = Process.GetProcessesByName("fmpwr");
                ////if (fmpwr.Length > 0)
                ////{
                ////    processList.Add(fmpwr);
                ////}

                ////var fmpcm = Process.GetProcessesByName("fmpcm");
                ////if (fmpcm.Length > 0)
                ////{
                ////    processList.Add(fmpcm);
                ////}

                ////var fmpem = Process.GetProcessesByName("fmpem");
                ////if (fmpem.Length > 0)
                ////{
                ////    processList.Add(fmpem);
                ////}

                ////var fmpon = Process.GetProcessesByName("fmpon");
                ////if (fmpon.Length > 0)
                ////{
                ////    processList.Add(fmpon);
                ////}

                ////var fmpss = Process.GetProcessesByName("fmpss");
                ////if (fmpss.Length > 0)
                ////{
                ////    processList.Add(fmpss);
                ////}

                ////var fmpprogressbar = Process.GetProcessesByName("fmpprogressbar");
                ////if (fmpprogressbar.Length > 0)
                ////{
                ////    processList.Add(fmpprogressbar);
                ////}

                ////var fmpcsprovider = Process.GetProcessesByName("fmpcsprovider");
                ////if (fmpcsprovider.Length > 0)
                ////{
                ////    processList.Add(fmpcsprovider);
                ////}

                ////var fmpsubjectserver = Process.GetProcessesByName("fmpsubjectserver");
                ////if (fmpsubjectserver.Length > 0)
                ////{
                ////    processList.Add(fmpsubjectserver);
                ////}

                ////var fmplogserver = Process.GetProcessesByName("fmplogserver");
                ////if (fmplogserver.Length > 0)
                ////{
                ////    processList.Add(fmplogserver);
                ////}

                ////var fmpdb = Process.GetProcessesByName("fmpdb");
                ////if (fmpdb.Length > 0)
                ////{
                ////    processList.Add(fmpdb);
                ////}

                ////var hartopc = Process.GetProcessesByName("hartopc");
                ////if (hartopc.Length > 0)
                ////{
                ////    processList.Add(hartopc);
                ////}

                ////var frontend = Process.GetProcessesByName("frontend");
                ////if (frontend.Length > 0)
                ////{
                ////    processList.Add(frontend);
                ////}

                ////var dtmcore = Process.GetProcessesByName("dtmcore");
                ////if (dtmcore.Length > 0)
                ////{
                ////    processList.Add(dtmcore);
                ////}

                ////// ReSharper disable InconsistentNaming
                ////var CWFdtHARTPORT = Process.GetProcessesByName("CWFdtHARTPORT");

                ////// ReSharper restore InconsistentNaming
                ////if (CWFdtHARTPORT.Length > 0)
                ////{
                ////    processList.Add(CWFdtHARTPORT);
                ////}

                ////var cwfdtdrvman = Process.GetProcessesByName("fmpfrcwfdtdrvmaname");
                ////if (cwfdtdrvman.Length > 0)
                ////{
                ////    processList.Add(cwfdtdrvman);
                ////}

                ////var fmpcsp1 = Process.GetProcessesByName("fmpcsp~1");
                ////if (fmpcsp1.Length > 0)
                ////{
                ////    processList.Add(fmpcsp1);
                ////}

                ////var cwlicenseserver = Process.GetProcessesByName("cwlicenseserver");
                ////if (cwlicenseserver.Length > 0)
                ////{
                ////    processList.Add(cwlicenseserver);
                ////}

                ////var vbtestclient = Process.GetProcessesByName("vbtestclient");
                ////if (vbtestclient.Length > 0)
                ////{
                ////    processList.Add(vbtestclient);
                ////}

                ////var fmplog1 = Process.GetProcessesByName("fmplog~1");
                ////if (fmplog1.Length > 0)
                ////{
                ////    processList.Add(fmplog1);
                ////}

                ////var fmpsub1 = Process.GetProcessesByName("fmpsub~1");
                ////if (fmpsub1.Length > 0)
                ////{
                ////    processList.Add(fmpsub1);
                ////}

                ////// ReSharper disable InconsistentNaming
                ////var EHEnvelopeCurve = Process.GetProcessesByName("EHEnvelopeCurve.PS");

                ////// ReSharper restore InconsistentNaming
                ////if (EHEnvelopeCurve.Length > 0)
                ////{
                ////    processList.Add(EHEnvelopeCurve);
                ////}

                return processList;
            }
            catch (Exception e)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), e.Message);
                return null;
            }
        }

        /// <summary>
        /// Kills all FieldCare processes
        /// </summary>
// ReSharper disable UnusedMember.Local
        private void KillAllFcProcesses()
// ReSharper restore UnusedMember.Local
        {
            IList<Process[]> processList = this.GetFcProcesses();
            if (processList == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Process list is null");
            }
            else
            {
                try
                {
                    foreach (var processes in processList)
                    {
                        foreach (var process in processes)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Killing process: " + process);
                            process.Kill();
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), e.Message);
                }
            }
        }

        /// <summary>
        ///     Denies saving project in case of upcoming related message box
        /// </summary>
        private void NoProjectSaving()
        {
            var watch = new Stopwatch();
            watch.Start();
            Button buttonSaveProjectNo = (new SaveProjectMessageElements()).No;
            while (buttonSaveProjectNo == null && watch.ElapsedMilliseconds < 10000)
            {
                buttonSaveProjectNo = (new SaveProjectMessageElements()).No;
            }

            watch.Stop();
            if (buttonSaveProjectNo != null)
            {
                buttonSaveProjectNo.Click();
            }
        }

        /// <summary>
        /// Waits for FieldCare processes to end.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// Time to wait for all FieldCare processes to end.
        /// </param>
        /// <returns>
        /// <c>true</c> if all processes ended in time, <c>false</c> otherwise.
        /// </returns>
// ReSharper disable UnusedMethodReturnValue.Local
        private bool WaitForFcProcessesToEnd(int timeoutInMilliseconds)
// ReSharper restore UnusedMethodReturnValue.Local
        {
            try
            {
                bool result;

                IList<Process[]> processList = this.GetFcProcesses();

                Stopwatch watch = new Stopwatch();
                watch.Start();

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Waiting for FieldCare processes to end.");
                while (processList.Count > 0 && watch.ElapsedMilliseconds < timeoutInMilliseconds)
                {
                    processList = this.GetFcProcesses();
                }

                watch.Stop();

                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Some FieldCare processes are still active after: " + timeoutInMilliseconds + " milliseconds.");
                    result = false;
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "All FieldCare processes ended.");
                    result = true;
                }

                return result;
            }
            catch (Exception e)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), e.Message);
                return false;
            }
        }

        #endregion
    }
}