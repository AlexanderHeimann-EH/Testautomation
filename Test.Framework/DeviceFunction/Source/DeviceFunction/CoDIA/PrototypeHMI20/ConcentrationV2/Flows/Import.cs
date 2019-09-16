// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Import.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The import.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.MenuArea.Toolbar.Execution;

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
        /// Last edit by EC on 2017-10-05
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

            // Last Edit by EC on 2017-10-05
            // Workaround für Import Message Box
            // Kann gelöscht werden sobald die Message Box aus Concentration verschwindet
            Execution.OpenFileBrowser.Cancel();
            Log.Warn(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Close Message Box with information for import.");

            if (Execution.OpenFileBrowser.Load(filename) == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cannot load " + filename);
                return false;
            }

            string userNotification = new GUI.StatusArea.Usermessages.UserMessagesElements().UserNotification;
            
            const string SuccessNotification = "Success";
            const string InfoNotification = "Info";
            
            if (userNotification.StartsWith(SuccessNotification) || userNotification.StartsWith(InfoNotification))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), filename + " has been imported");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Importing {0} results in user notification: {1}", filename, userNotification));
            return false;
        }

        #endregion
    }
}