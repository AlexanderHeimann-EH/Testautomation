// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StartFrame.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains methods to start frame applications
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.UpdateDtmCatalogMessageOnStartup.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.UpdateDtmCatalogMessageOnStartup.Validation;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.MenuArea.MenuBar;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    /// <summary>
    ///     Contains methods to start frame applications
    /// </summary>
    public class StartFrame : MarshalByRefObject, IStartFrame
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Start Frame application with default path(determine whether it runs on 32bit or 64bit OS) and time
        /// </summary>
        /// <returns><c>true</c> if version is 64 bit, <c>false</c> otherwise.</returns>
        public bool FieldCare()
        {
            if (SystemInformation.Is64Bit)
            {
                return this.FieldCare(DefaultValues.strApplicationPath64Bit, DefaultValues.GeneralTimeout);
            }

            return this.FieldCare(DefaultValues.strApplicationPath, DefaultValues.GeneralTimeout);
        }

        /// <summary>
        /// Start Frame application with default time
        /// </summary>
        /// <param name="strApplicationPath">
        /// The string application path.
        /// </param>
        /// <returns>
        /// <c>true</c> if true is returned, <c>false</c> otherwise.
        /// </returns>
        public bool FieldCare(string strApplicationPath)
        {
            return this.FieldCare(strApplicationPath, DefaultValues.GeneralTimeout);
        }

        /// <summary>
        /// Start Frame application with user specified path and time
        /// </summary>
        /// <param name="strApplicationPath">
        /// FieldCare installation path
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// Time until Frame could be opened, before an error message appears
        /// </param>
        /// <returns>
        /// Returns process ID in case of success or -1 in case of failure
        /// </returns>
        public bool FieldCare(string strApplicationPath, int timeOutInMilliseconds)
        {            
            try
            {
                int openFrameProcessId = this.IsProcessOpen(strApplicationPath);
                if (openFrameProcessId != 0)
                {
                    Process process = Process.GetProcessById(openFrameProcessId);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Running instance available.");
                    process.Kill();
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Running instance closed.");
                }

                Process prcsFrame = Process.Start(strApplicationPath);
                bool isSearching = true;
                bool isFound = false;
                var watch = new Stopwatch();
                watch.Start();
                while (isSearching)
                {
                    if (prcsFrame == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FieldCare Process does not exist.");
                        return false;
                    }

                    if (watch.ElapsedMilliseconds > timeOutInMilliseconds)
                    {
                        isSearching = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame was not ready after " + timeOutInMilliseconds + " Milliseconds");
                    }
                    else
                    {
                        Button evaluationInfo = (new EvaluationInfoElements()).Ok;
                        if (evaluationInfo != null && evaluationInfo.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame runs with evaluation license");
                            evaluationInfo.Click(DefaultValues.locDefaultLocation);
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Evaluation Information confirmed");
                        }

                        Button button = (new ProjectBrowserElements()).Cancel;
                        if (button != null && button.Enabled && button.Visible)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame opened");
                            isSearching = false;
                            isFound = true;
                            button.Click(DefaultValues.locDefaultLocation);
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dialog closed");
                        }
                        else
                        {
                            if (new ValidationMethods().WaitForCatalogUpdateDialog(DefaultValues.iTimeoutDefault))
                            {
                                new IgnoreUpdate().Run();
                            }

                            button = (new ProjectBrowserElements()).Cancel;
                            if (button != null && button.Enabled && button.Visible)
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame opened");
                                isSearching = false;
                                isFound = true;
                                button.Click(DefaultValues.locDefaultLocation);
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dialog closed");
                            }
                        }                        

                        MenuItem menuItem = (new Elements()).MenuFile;
                        if (menuItem != null && menuItem.Enabled && menuItem.Visible)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame opened");
                            isSearching = false;
                            isFound = true;
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dialog closed");
                        }
                    }
                }

                watch.Stop();
                if (isFound)
                {
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check if process is already running
        /// </summary>
        /// <param name="path">
        /// Path for application
        /// </param>
        /// <returns>
        /// current process id.
        /// </returns>
        private int IsProcessOpen(string path)
        {
            string[] pathSplit = path.Split(new[] { "\\" }, StringSplitOptions.None);
            string processName = pathSplit[pathSplit.Length - 1].Split('.')[0];

            // here we're going to get a list of all running processes on the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(processName))
                {
                    return clsProcess.Id;
                }
            }

            // otherwise we return a 0
            return 0;
        }

        #endregion
    }
}