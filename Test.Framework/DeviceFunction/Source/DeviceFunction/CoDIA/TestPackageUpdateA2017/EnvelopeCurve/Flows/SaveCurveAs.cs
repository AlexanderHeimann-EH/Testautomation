// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveCurveAs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Flow: Save Curve As via menu
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.Flows
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.GUI.Dialogs;

    using Ranorex;

    /// <summary>
    ///     Flow: Save Curve As via menu
    /// </summary>
    public class SaveCurveAs : ISaveCurveAs
    {
        #region Public Methods and Operators

        /// <summary>
        /// Save curve(s) with default file name in report folder
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "EnvelopeCurveData";
            return this.RunViaMenu(fileName);
        }

        /// <summary>
        ///     Save curve(s) with system proposed filename, if file was never saved before.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaMenu()
        {
            return this.RunViaMenu(string.Empty);
        }

        /// <summary>
        /// Save curve(s) with given filename if file was never saved before.
        ///     File overwriting is allowed. Appending curve data is not allowed.
        /// </summary>
        /// <param name="filename">
        /// Filename to save file as
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaMenu(string filename)
        {
            return this.RunViaMenu(filename, true, false);
        }

        /// <summary>
        /// Save curve(s) with given filename.
        /// </summary>
        /// <param name="fileName">
        /// Filename to save file as
        /// </param>
        /// <param name="overwriteData">
        /// True allows file overwriting
        /// </param>
        /// <param name="appendData">
        /// True allows appending data to existing file
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaMenu(string fileName, bool overwriteData, bool appendData)
        {
            try
            {
                string pathForWatcher = Path.GetDirectoryName(fileName);

                // if save as dialog was not opened
                if ((new OpenSaveCurveAs()).ViaMenu() == false)
                {
                    // failed to open save as dialog
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open save as file browser dialog");
                    return false;
                }

                // if no user specific fileName exists
                if (fileName == string.Empty)
                {
                    // get system-proposed filename
                    fileName = Execution.SaveAsFileBrowser.ProposedFileName;

                    // set default path
                    fileName = SystemInformation.GetApplicationDataPath + @"\" + fileName;
                    pathForWatcher = Path.GetDirectoryName(fileName);
                }

                var watcher = new FileWatcher(pathForWatcher, "*.curves");
                watcher.StartFileWatcher();

                if (Execution.SaveAsFileBrowser.SaveAs(fileName) == false)
                {
                    // failed to save file
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to save file or overwrite = false");
                    watcher.StopFileWatcher();
                    return false;
                }

                Button confirmOverwrite = (new ReplaceFileElements()).BtnNo;

                // if no overwrite message box came up
                if (confirmOverwrite == null)
                {
                    return true;
                }

                // if file is already available
                // if file should be overwritten
                if (overwriteData)
                {
                    confirmOverwrite.Click(DefaultValues.locDefaultLocation);
                }
                else if (appendData)
                {
                    Button confirmAppend = (new ReplaceFileElements()).BtnYes;
                    if (confirmAppend != null && confirmAppend.Enabled)
                    {
                        confirmAppend.Click(DefaultValues.locDefaultLocation);
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Data were appended to existing file: " + fileName);
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button to confirm append is not accessible.");
                        return false;
                    }
                }
                else
                {
                    // cancel overwrite and append message
                    Button cancelAction = (new ReplaceFileElements()).BtnCancel;
                    if (cancelAction != null && cancelAction.Enabled)
                    {
                        cancelAction.Click(DefaultValues.locDefaultLocation);
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving has been canceled. Data remain available.");
                        watcher.StopFileWatcher();
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button to cancel saving is not accessable.");
                    watcher.StopFileWatcher();
                    return false;
                }

                // Check for changed or created file
                if (!watcher.WaitUntilEventFired(DefaultValues.GeneralTimeout))
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FileSystemWatcher did not recognize a file operation, saving failed");
                    watcher.StopFileWatcher();
                    return false;
                }

                // saving was succesfull
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saved file successfully");
                watcher.StopFileWatcher();
                return true;
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