// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportHistorom.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to export a current HISTROM file
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Historom.Flows
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.TestPackageCI.Historom.Functions.MenuArea.Toolbar.Execution;

    /// <summary>
    ///     Provides function to export a current HISTROM file
    /// </summary>
    public class ExportHistorom : IExportHistorom
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
            string fileName = ReportHelper.ReportPath + "HistoromDataExport";
            return this.Run(fileName);
        }

        /// <summary>
        /// Exports file with given filename, replaces already existing file with same filename
        ///     FILE WATCHER will check if file was created or modified
        /// </summary>
        /// <param name="fileName">
        /// Filename and path for export. Use this form: C:\test\testExport
        /// </param>
        /// <returns>
        /// true: if file was exported successful
        ///     false: if an error occurred
        /// </returns>
        public bool Run(string fileName)
        {
            try
            {
                string pathForWatcher = Path.GetDirectoryName(fileName);
                var watcher = new FileWatcher(pathForWatcher, "*.xls");
                watcher.StartFileWatcher();
                if (new OpenExport().ViaIcon() == false)
                {
                    // failed to open export dialog
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open export file browser dialog");
                    return false;
                }

                if (Execution.SaveAsFileBrowser.SaveAs(fileName) == false)
                {
                    // failed to save file
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to export file");
                    return false;
                }

                // HACK: 2013-06-07: replaces uncommented line below
                if (!watcher.WaitUntilEventFired(DefaultValues.GeneralTimeout))
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FileSystemWatcher did not recognize a file operation, saving failed");
                    watcher.StopFileWatcher();
                    return false;
                }

                // saving successful
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Exported file successfully");
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