// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Restore.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of Save
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.GUI.ApplicationArea.MainView;

    using Navigation = EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Execution.Navigation;
    using Selection = EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Execution.Selection;

    /// <summary>
    ///     Description of Save
    /// </summary>
    public class Restore : IRestore
    {
        #region Public Methods and Operators

        /// <summary>
        /// Runs Restore with or without an download, depending on set parameters
        /// </summary>
        /// <param name="fileName">
        /// Filename of file to restore
        /// </param>
        /// <param name="defaultPath">
        /// If true, "Program Data" path is used as file location. Else a valid file location path must be provided
        /// </param>
        /// <param name="waitUntilFinished">
        /// Boolean for waiting or not, until process is finished
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// Time until action must be done
        /// </param>
        /// <param name="restore">
        /// Boolean to restore or not
        /// </param>
        /// <param name="download">
        /// Boolean to download or not
        /// </param>
        /// <param name="duplicate">
        /// Download mode = duplicate if true, else download mode = all parameters
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName, bool defaultPath, bool waitUntilFinished, int timeOutInMilliseconds, bool restore, bool download, bool duplicate)
        {
            try
            {
                if (new Navigation().Restore() == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicking Restore button failed.");
                    return false;
                }

                if (new SelectionElements().CbDownload.Checked != download)
                {
                    // Uncheck checkbox
                    new Selection().SelectDownload();
                }

                // Use file dialog to create file with specified filename
                if (fileName != string.Empty)
                {
                    if (defaultPath)
                    {
                        // set default path
                        fileName = SystemInformation.GetApplicationDataPath + @"\" + fileName;
                    }

                    if ((new LoadFile()).Run(fileName))
                    {
                        if (download)
                        {
                            if (new SelectionElements().DownloadModeAllParameter == null || new SelectionElements().DownloadModeDuplicate == null)
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "A download mode selection element is null. This is ok for devices which do not have a download mode.");
                            }
                            else
                            {
                                if (duplicate)
                                {
                                    if (new SelectionElements().DownloadModeDuplicate.Checked == false)
                                    {
                                        new Selection().SelectDownloadModeDuplicate();
                                    }
                                }
                                else
                                {
                                    if (new SelectionElements().DownloadModeAllParameter.Checked == false)
                                    {
                                        new Selection().SelectDownloadModeAllParameters();
                                    }
                                }
                            }
                        }

                        new Navigation().Start();

                        if (waitUntilFinished)
                        {
                            if (new WaitUntilProcessFinished().Run(timeOutInMilliseconds))
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Loading is finished.");
                                return true;
                            }

                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Process not finished in time.");
                            return false;
                        }

                        return true;
                    }

                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No filename available to restore from");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion
    }
}