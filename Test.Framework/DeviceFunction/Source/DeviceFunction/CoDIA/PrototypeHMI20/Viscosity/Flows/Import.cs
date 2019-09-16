// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Import.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2017
// </copyright>
// <summary>
//   Flow for importing Viscosity data
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Viscosity.Flows
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
            string fileName = ReportHelper.ReportPath + "ViscosityDataExport.xls";
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
                
                string userNotification = new GUI.StatusArea.Usermessages.UserMessagesElements().UserNotificationMessage;

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
            catch (Exception e)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), e.Message);
                return false;
            }
        }

        #endregion
    }
}