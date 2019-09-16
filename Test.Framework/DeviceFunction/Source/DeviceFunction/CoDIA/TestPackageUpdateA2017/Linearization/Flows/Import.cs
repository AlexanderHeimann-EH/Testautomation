// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Import.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Flow for importing Linearization data
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Linearization.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.MenuArea.Toolbar;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Usermessages;

    /// <summary>
    /// Flow for importing Linearization data
    /// </summary>
    public class Import : IImport
    {
        #region Public Methods and Operators

        /// <summary>
        /// Export Linearization data with default file name to report folder
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "LinearizationDataExport.csv";
            return this.Run(fileName);
        }

        /// <summary>
        /// Imports Linearization data via toolbar icon
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
                        // Check whether the Linearization user message contains an error or does not show that importing was successful
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