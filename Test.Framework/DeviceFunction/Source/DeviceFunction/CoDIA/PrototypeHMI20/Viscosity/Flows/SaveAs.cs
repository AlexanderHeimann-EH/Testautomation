﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveAs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The save as.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Viscosity.Flows
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Viscosity.Functions.MenuArea.Toolbar.Execution;

    /// <summary>
    /// The save as.
    /// </summary>
    public class SaveAs : ISaveAs
    {
        #region Public Methods and Operators

        /// <summary>
        /// Saves the Viscosity data to a file in the report folder.
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "ViscosityData";
            return this.Run(fileName);
        }

        /// <summary>
        /// Saves file under given filename, replaces already existing files with same filename
        ///     FILE WATCHER will check if file has been created or modified
        ///     Default on drive C:
        /// </summary>
        /// <param name="fileName">
        /// Filename under which file is saved
        /// </param>
        /// <returns>
        /// true: if file was saved successful
        ///     false: if an error occurred
        /// </returns>
        public bool Run(string fileName)
        {
            try
            {
                // FILE WATCHER
                // Common.Tools
                string pathForWatcher = Path.GetDirectoryName(fileName);
                var watcher = new FileWatcher(pathForWatcher, "*.visc");

                watcher.StartFileWatcher();

                if (new OpenSaveAs().ViaIcon() == false)
                {
                    // failed to open save as dialog
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open save as file browser dialog");
                    watcher.StopFileWatcher();
                    return false;
                }

                if (Execution.SaveAsFileBrowser.SaveAs(fileName) == false)
                {
                    // failed to save file
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to save file or overwrite = false");
                    watcher.StopFileWatcher();
                    return false;
                }

                if (!watcher.WaitUntilEventFired(DefaultValues.GeneralTimeout))
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FileSystemWatcher did not recognize a file operation, saving failed");
                    watcher.StopFileWatcher();
                    return false;
                }

                // saving successful
                watcher.StopFileWatcher();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saved file " + fileName + " successfully");
                watcher.StopFileWatcher();
                return true;
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