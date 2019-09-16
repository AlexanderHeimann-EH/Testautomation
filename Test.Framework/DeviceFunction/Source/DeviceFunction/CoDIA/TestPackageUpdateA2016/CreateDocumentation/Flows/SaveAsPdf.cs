// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveAsPdf.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of SaveAsPDF.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.CreateDocumentation.Flows
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.CreateDocumentation.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.CreateDocumentation.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.CreateDocumentation.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    ///     Description of SaveAsPDF.
    /// </summary>
    public class SaveAsPdf : ISaveAsPdf
    {
        #region Public Methods and Operators

        /// <summary>
        /// Flow: Save file as PDF via file browser with default timeout
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "CreateDocumentationData";
            return this.Run(fileName);
        }

        /// <summary>
        /// Flow: Save file as PDF via file browser with default timeout
        /// </summary>
        /// <param name="fileName">
        /// Filename to save printout as
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName)
        {
            return this.Run(fileName, true, DefaultValues.TimeoutPrintUpDownload);
        }

        /// <summary>
        /// Flow: Save file as PDF via file browser with specialized timeout
        /// </summary>
        /// <param name="fileName">
        /// Filename to save printout, e.g. C:\Test\test. Use string.empty for a default file name and location.
        /// </param>
        /// <param name="waitUntilFinished">
        /// Control if should be waited until module is opened or not
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// Time until printout has to be generated at last
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName, bool waitUntilFinished, int timeOutInMilliseconds)
        {
            try
            {
                string pathForWatcher = Path.GetDirectoryName(fileName);
                var stopwatch = new Stopwatch();

                // Get default file name with date if no file name is specified
                if (fileName.Length == 0)
                {
                    fileName = SystemInformation.GetApplicationDataPath + @"\" + DateTime.Now.ToString("yyyy_MM_dd") + "_DefaultFileName";
                    pathForWatcher = SystemInformation.GetApplicationDataPath;
                }

                var watcher = new FileWatcher(pathForWatcher, "*.pdf");
                if ((new OpenSaveAs()).ViaButton())
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "method entered");

                    watcher.StartFileWatcher();
                    if (Execution.SaveAsFileBrowser.SaveAs(fileName))
                    {
                        if (waitUntilFinished)
                        {
                            stopwatch.Start();
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Printing file as PDF");
                            if ((new WaitUntilPrintingIsFinished()).Run(timeOutInMilliseconds))
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving is finished.");

                                // Watch if file is created
                                if (!watcher.WaitUntilEventFired(DefaultValues.GeneralTimeout))
                                {
                                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FileSystemWatcher did not recognize a file operation, saving failed");
                                    watcher.StopFileWatcher();
                                    stopwatch.Stop();
                                    return false;
                                }

                                watcher.StopFileWatcher();
                                stopwatch.Stop();
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Printing finished after: '" + stopwatch.ElapsedMilliseconds + "'");
                                return true;
                            }

                            string mainProgressBarText = (new PrinterAndProgress()).GetMainProgressBarState();
                            string subProgressBarText = (new PrinterAndProgress()).GetSubProgressBarState();

                            // CreateDocumentation.MainView.Areas.PrinterAndProgressElements.MainProgress
                            Log.Screenshot();
                            string log = "Saving not finished in time. \n - [MainProgressBarState]: " + mainProgressBarText + "." + "\n - [SubProgressBarState]: " + subProgressBarText + ".";
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), log);
                            watcher.StopFileWatcher();
                            return false;
                        }

                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Printing file as PDF without waiting");
                        watcher.StopFileWatcher();
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Printing could not be saved.");
                    watcher.StopFileWatcher();
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save dialog could not be opened.");
                watcher.StopFileWatcher();
                return false;
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