// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Import.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Flow for importing Dip table data
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.DipTable.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.DipTable.Functions.MenuArea.Toolbar;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.DipTable.Functions.StatusArea.Usermessages;

    /// <summary>
    /// Flow for importing dip table data
    /// </summary>
    public class Import : IImport
    {
        #region Public Methods and Operators

        /// <summary>
        /// Export Dip table data with default file name to report folder
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "DipTableDataExport.csv";
            return this.Run(fileName);
        }

        /// <summary>
        /// Imports Dip table data via toolbar icon
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
                bool result = false;

                if (Execution.ClickOnImport.Run() == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cannot open Import Dialog");
                }
                else
                {
                    if (OperatingSystemLoader.Functions.Dialogs.Execution.OpenFileBrowser.Load(filename) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cannot load " + filename);
                    }
                    else
                    {
                        // Check whether the Dip table user message contains an error or does not show that importing was successful
                        if (Validation.CheckUserNotificationMessages.ContainsError() || Validation.CheckUserNotificationMessages.ContainsString("Success") == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Importing failed");
                        }
                        else
                        {
                            result = true;
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), filename + " imported");
                        }
                    }
                }

                return result;
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