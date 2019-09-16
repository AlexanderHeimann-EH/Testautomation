﻿
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.Functions.MenuArea.Toolbar.Execution;

    /// <summary>
    /// The import.
    /// </summary>
    public class Import : IImport
    {
        #region Public Methods and Operators

        /// <summary>
        /// Imports Concentration data with default name from report folder
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "ConcentrationDataExport.xls";
            return this.Run(fileName);
        }

        /// <summary>
        /// Imports Concentration data via toolbar icon
        /// </summary>
        /// <param name="filename">
        /// filename of dataset which should be imported
        /// </param>
        /// <returns>
        /// true, if file was imported successfully; false, if an error occurred
        /// </returns>
        public bool Run(string filename)
        {
            if ((new OpenImport()).ViaIcon() == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cannot open Import Dialog");
                return false;
            }

            if (Execution.OpenFileBrowser.Load(filename) == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cannot load " + filename);
                return false;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), filename + " has been imported");
            return true;
        }

        #endregion
    }
}