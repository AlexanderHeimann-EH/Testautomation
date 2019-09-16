// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Export.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Flow for exporting Viscosity data
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.Flows
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Viscosity.Functions.MenuArea.Toolbar;

    /// <summary>
    /// Flow for exporting Viscosity data
    /// </summary>
    public class Export : IExport
    {
        #region Public Methods and Operators

        /// <summary>
        /// Exports the Viscosity data to a file in the report folder.
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "ViscosityDataExport.deh";
            return this.Run(fileName);
        }

        /// <summary>
        /// Exports Viscosity data with user given filename
        /// </summary>
        /// <param name="filename">
        /// Filename and path for viscosity export. E.g. C:\test\exportFile
        /// </param>
        /// <returns>
        /// true: if file is exported; false: if an error occurred
        /// </returns>
        public bool Run(string filename)
        {
            try
            {
                string pathForWatcher = Path.GetDirectoryName(filename);
                var watcher = new FileWatcher(pathForWatcher, "*.xls");
                watcher.StartFileWatcher();

                if (Execution.OpenExport.ViaIcon() == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opening Export Dialog failed");
                    return false;
                }

                if (OperatingSystemLoader.Functions.Dialogs.Execution.SaveAsFileBrowser.SaveAs(filename) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Exporting file failed");
                    return false;
                }

                if (watcher.WaitUntilEventFired(DefaultValues.GeneralTimeout) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FileSystemWatcher did not recognize a file operation, exporting failed");
                    return false;
                }

                watcher.StopFileWatcher();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), filename + " exported");
                return true;
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