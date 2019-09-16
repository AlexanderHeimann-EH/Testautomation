// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Export.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The export.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Concentration.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Concentration.Functions.MenuArea.Toolbar;

    /// <summary>
    /// The export.
    /// </summary>
    public class Export : IExport
    {
        #region Public Methods and Operators

        /// <summary>
        /// Exports Concentration data with default name to report folder
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "ConcentrationDataExport";
            return this.Run(fileName);
        }

        /// <summary>
        /// Exports Concentration data with user given filename
        /// </summary>
        /// <param name="filename">
        /// Filename for Concentration Data
        /// </param>
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run(string filename)
        {
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

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), filename + " exported");
            return true;
        }

        #endregion
    }
}