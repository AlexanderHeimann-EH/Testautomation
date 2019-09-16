// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Save.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of Save
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Flows
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.GUI.ApplicationArea.MainView;

    using Navigation = EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Execution.Navigation;

    /// <summary>
    ///     Description of Save
    /// </summary>
    public class Save : ISave
    {
        #region Public Methods and Operators

        /// <summary>
        /// Runs Save with or without an upload, depending on set parameters
        /// </summary>
        /// <param name="fileName">
        /// Filename to save file as
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
        /// <param name="save">
        /// Boolean to save or not
        /// </param>
        /// <param name="upload">
        /// Boolean to upload or not
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName, bool defaultPath, bool waitUntilFinished, int timeOutInMilliseconds, bool save, bool upload)
        {
            try
            {
                if (new Navigation().Save() == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to press Save button.");
                    return false;
                }

                string pathForWatcher;
                if (defaultPath)
                {
                    pathForWatcher = SystemInformation.GetApplicationDataPath;
                }
                else
                {
                    pathForWatcher = Path.GetDirectoryName(fileName);
                }

                var watcher = new FileWatcher(pathForWatcher, "*.deh");
                watcher.StartFileWatcher();

                // Use file dialog to create file with specified filename
                if (fileName != string.Empty)
                {
                    if (defaultPath)
                    {
                        // set default path
                        fileName = SystemInformation.GetApplicationDataPath + @"\" + fileName;
                    }

                    if ((new SaveFile()).Run(fileName))
                    {
                        if (upload)
                        {
                            if (new SelectionElements().CbUpload != null && new SelectionElements().CbUpload.Checked == false)
                            {
                                new SelectionElements().CbUpload.Click();
                            }
                        }
                        else
                        {
                            if (new SelectionElements().CbUpload != null && new SelectionElements().CbUpload.Checked)
                            {
                                new SelectionElements().CbUpload.Click();
                            }
                        }

                        new Navigation().Start();
                        if (waitUntilFinished)
                        {
                            if (new WaitUntilProcessFinished().Run(timeOutInMilliseconds))
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving is finished.");

                                // Watch if file is created
                                if (!watcher.WaitUntilEventFired(DefaultValues.GeneralTimeout))
                                {
                                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FileSystemWatcher did not recognize a file operation, saving failed");
                                    watcher.StopFileWatcher();
                                    return false;
                                }

                                watcher.StopFileWatcher();
                                return true;
                            }

                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Process not finished in time.");
                            watcher.StopFileWatcher();
                            return false;
                        }

                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Perform process without waiting");
                        watcher.StopFileWatcher();
                        return true;
                    }

                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occurred while using Save Dialog");
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