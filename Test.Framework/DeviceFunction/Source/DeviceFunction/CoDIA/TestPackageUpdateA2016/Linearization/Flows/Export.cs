// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Export.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Flow for exporting Linearization data
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Flows
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.MenuArea.Toolbar;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Usermessages;

    /// <summary>
    /// Flow for exporting Linearization data
    /// </summary>
    public class Export : IExport
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
            string fileName = ReportHelper.ReportPath + "LinearizationDataExport";
            return this.Run(fileName);
        }

        /// <summary>
        /// Exports the a Linearization file.
        /// </summary>
        /// <param name="fileName">
        /// Name and path of the file. E.g. C:\Test\testData 
        /// </param>
        /// <returns>
        /// <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
        public bool Run(string fileName)
        {
            try
            {
                bool result = false;

                string pathForWatcher = Path.GetDirectoryName(fileName);
                var watcher = new FileWatcher(pathForWatcher, "*.csv");
                watcher.StartFileWatcher();

                if (Execution.ClickOnExport.Run() == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opening Export Dialog failed");
                }
                else
                {
                    if (OperatingSystemLoader.Functions.Dialogs.Execution.SaveAsFileBrowser.SaveAs(fileName) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Exporting file failed");
                    }
                    else
                    {
                        if (watcher.WaitUntilEventFired(DefaultValues.GeneralTimeout) == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FileSystemWatcher did not recognize a file operation, saving failed");
                        }
                        else
                        {
                            // Check whether the Linearization user message contains an error or does not show that exporting was successful
                            if (Validation.CheckUserNotificationMessages.ContainsError() || Validation.CheckUserNotificationMessages.ContainsString("Success") == false)
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Exporting failed");
                            }
                            else
                            {
                                result = true;
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), fileName + " exported");
                            }
                        }
                    }
                }

                watcher.StopFileWatcher();
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