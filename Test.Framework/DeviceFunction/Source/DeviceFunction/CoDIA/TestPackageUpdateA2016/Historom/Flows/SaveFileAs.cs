// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveFileAs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to save HISTROM files
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.Flows
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.Functions.MenuArea.Toolbar.Execution;

    /// <summary>
    /// Provides function to save HISTROM files
    /// </summary>
    public class SaveFileAs : ISaveFileAs
    {
        #region Public Methods and Operators

        /// <summary>
        /// Save curve(s) with default file name in report folder
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "HistoromData";
            return this.Run(fileName);
        }

        /// <summary>
        /// Saves file under given filename, replaces already existing files with same filename
        ///     FILE WATCHER will check if file has been created or modified
        /// </summary>
        /// <param name="fileName">
        /// Filename and path under which file is saved, e.g. C:\Test\test
        /// </param>
        /// <returns>
        /// true: if file was saved successful
        ///     false: if an error occurred
        /// </returns>
        public bool Run(string fileName)
        {
            try
            {
                string pathForWatcher = Path.GetDirectoryName(fileName);
                var watcher = new FileWatcher(pathForWatcher, "*.his");

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