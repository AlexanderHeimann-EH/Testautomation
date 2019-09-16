

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Viscosity.Functions.MenuArea.Toolbar;

    /// <summary>
    /// Flow for importing Viscosity data
    /// </summary>
    public class Import : IImport
    {
        #region Public Methods and Operators

        /// <summary>
        /// Imports the Viscosity data from a file in the report folder.
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "ViscosityDataExport";
            return this.Run(fileName);
        }

        /// <summary>
        /// Imports Viscosity data via toolbar icon
        /// </summary>
        /// <param name="filename">
        /// filename (and path)of dataset which should be imported
        /// </param>
        /// <returns>
        /// true, if file was imported successfully; false, if an error occurred
        /// </returns>
        public bool Run(string filename)
        {
            try
            {
                if (Execution.OpenImport.ViaIcon() == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cannot open Import Dialog");
                    return false;
                }

                if (OperatingSystemLoader.Functions.Dialogs.Execution.OpenFileBrowser.Load(filename) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cannot load " + filename);
                    return false;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), filename + " imported");
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