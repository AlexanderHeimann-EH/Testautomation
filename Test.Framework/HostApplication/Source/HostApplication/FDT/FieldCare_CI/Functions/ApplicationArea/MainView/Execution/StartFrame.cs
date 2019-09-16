// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StartFrame.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains methods to start frame applications
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.CI.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.CI.Functions.Dialogs.UpdateDtmCatalogMessageOnStartup.Execution;
    using EH.PCPS.TestAutomation.FieldCare.CI.Functions.Dialogs.UpdateDtmCatalogMessageOnStartup.Validation;
    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.Dialogs;
    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.MenuArea.MenuBar;
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

                bool evaluationMessageDone = false;
                bool updateDtmCatalogDialogDone = false;
                bool fileBrowserDialogDone = false;
                Button evaluationOk = null;
                Button updateCatalogButtonIgnore = null;
                Button fileBrowserButtonCancel = null;

                //const int UpdateCatalogDialogHeight = 281;
                //const int UpdateCatalogDialogWidth = 331;

                const int FileBrowserDialogHeight = 500;
                const int FileBrowserDialogWidth = 500;

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
                        // Prüfe auf Evaluation Message (1)
                        // Prüfe auf DTM update catalog (2)
                        // Prüfe auf File browser dialog (3)

                        // Ist einer von dreien da
                        // Wenn da, versuche (1) zu bedienen
                        // Nach Bedienung setze (1) auf "Bedient"
                        // Wenn da, versuche (2) zu bedienen
                        // Nach Bedienung setze (1)+(2) auf "Bedient"
                        // Wenn da, versuche (3) zu bedienen
                        // Nach Bedienung setze (1)+(2)+(3) auf "Bedient"

                        if (evaluationMessageDone == false)
                        {
                            evaluationOk = (new EvaluationInfoElements()).Ok;    
                        }
                        
                        if (updateDtmCatalogDialogDone == false)
                        {
                            updateCatalogButtonIgnore = (new UpdateDtmCatalogMessageElements()).Ignore;    
                        }

                        if (fileBrowserDialogDone == false)
                        {
                            fileBrowserButtonCancel = (new ProjectBrowserElements()).Cancel;    
                        }

                        if (evaluationOk != null || updateCatalogButtonIgnore != null || fileBrowserButtonCancel != null)
                        {
                            if (evaluationOk != null && evaluationOk.Enabled && !evaluationMessageDone)
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame runs with evaluation license");
                                evaluationOk.Click(DefaultValues.locDefaultLocation);
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Evaluation Information confirmed");
                                evaluationMessageDone = true;
                            }

                            if ((updateCatalogButtonIgnore != null && updateCatalogButtonIgnore.Enabled) ||
                                (fileBrowserButtonCancel != null && fileBrowserButtonCancel.Enabled))
                            {
                                // if update dtm catalog
                                if (updateCatalogButtonIgnore != null && !updateDtmCatalogDialogDone)
                                {
                                    if (updateCatalogButtonIgnore.Element.Parent.ScreenRectangle.Width < FileBrowserDialogWidth &&
                                        updateCatalogButtonIgnore.Element.Parent.ScreenRectangle.Height < FileBrowserDialogHeight)
                                    {
                                        new IgnoreUpdate().Run();
                                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Update Catalog Dialog found");
                                        evaluationMessageDone = true;
                                        updateDtmCatalogDialogDone = true;
                                    }
                                }
                                

                                // if update file browser
                                if (fileBrowserButtonCancel != null && !fileBrowserDialogDone)
                                {
                                    if (fileBrowserButtonCancel.Element.Parent.ScreenRectangle.Width > FileBrowserDialogWidth && 
                                        fileBrowserButtonCancel.Element.Parent.ScreenRectangle.Height > FileBrowserDialogHeight)
                                    {
                                        fileBrowserButtonCancel.Click();
                                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File Browser Dialog found");
                                        evaluationMessageDone = true;
                                        updateDtmCatalogDialogDone = true;
                                        fileBrowserDialogDone = true;
                                    }
                                }
                            }
                        }
                        
                        //Button evaluationInfo = (new EvaluationInfoElements()).Ok;
                        //if (evaluationInfo != null && evaluationInfo.Enabled)
                        //{
                        //    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame runs with evaluation license");
                        //    evaluationInfo.Click(DefaultValues.locDefaultLocation);
                        //    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Evaluation Information confirmed");
                        //}

                        //Button button = (new ProjectBrowserElements()).Cancel;
                        //// button.Element.Parent.ScreenRectangle.Width
                        //// button.Element.Parent.ScreenRectangle.Height 

                        //if (button != null && button.Enabled && button.Visible)
                        //{
                        //    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame opened");
                        //    isSearching = false;
                        //    isFound = true;
                        //    button.Click(DefaultValues.locDefaultLocation);
                        //    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dialog closed");    
                        //}
                        //else
                        //{
                        //    if (new ValidationMethods().WaitForCatalogUpdateDialog(DefaultValues.iTimeoutDefault))
                        //    {
                        //        new IgnoreUpdate().Run();
                        //    }

                        //    button = (new ProjectBrowserElements()).Cancel;
                        //    if (button != null && button.Enabled && button.Visible)
                        //    {
                        //        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame opened");
                        //        isSearching = false;
                        //        isFound = true;
                        //        button.Click(DefaultValues.locDefaultLocation);
                        //        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dialog closed");
                        //    }
                        //}                        

                        MenuItem menuItem = (new Elements()).MenuFile;
                        if (menuItem != null && menuItem.Enabled && menuItem.Visible && fileBrowserDialogDone)
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