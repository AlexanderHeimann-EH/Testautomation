//------------------------------------------------------------------------------
// <copyright file="SaveCurve.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurveShed.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.GUI.Dialogs;

    using Ranorex;

    /// <summary>
    ///     Flow: Save Curve via menu
    /// </summary>
    public class SaveCurve : ISaveCurve
    {
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
        ///     Save curve(s) with given filename if file was never saved before.
        ///     File overwriting is allowed. Appending curve data is not allowed.
        /// </summary>
        /// <param name="filename">Filename to save file as</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaMenu(string filename)
        {
            return this.RunViaMenu(filename, true, false);
        }

        /// <summary>
        ///     Save curve(s) with given filename if file was never saved before.
        /// </summary>
        /// <param name="fileName">Filename to save file as</param>
        /// <param name="overwriteData">True allows file overwriting</param>
        /// <param name="appendData">True allows appending data to existing file</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaMenu(string fileName, bool overwriteData, bool appendData)
        {
            try
            {
                var watcher = new FileWatcher(SystemInformation.GetApplicationDataPath, "*.curves");
                watcher.StartFileWatcher();

                // if function call was not successful
                if ((new RunSaveCurve()).ViaMenu() == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function [Save] could not be executed");
                    watcher.StopFileWatcher();
                    return false;
                }

                // if save as dialog was not opened
                if (Validation.IsSaveAsDialogOpen.Run() == false)
                {
                    ////// Check for changed or created file
                    ////if (!watcher.WaitUntilEventFired(DefaultValues.GeneralTimeout))
                    ////{
                    ////    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FileSystemWatcher did not recognize a file operation, saving failed");
                    ////    watcher.StopFileWatcher();
                    ////    return false;
                    ////}

                    // file was saved without save as dialog
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saved file successfully");
                    watcher.StopFileWatcher();
                    return true;
                }

                // if no user specific fileName exists
                if (fileName == string.Empty)
                {
                    // get system-proposed filename
                    fileName = Execution.SaveAsFileBrowser.ProposedFileName;
                }

                // set default path with proposed filename
                Execution.SaveAsFileBrowser.ProposedFileName = SystemInformation.GetApplicationDataPath + @"\" + fileName;
                
                // if saving  was not successful
                if (Execution.SaveAsFileBrowser.Save() == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to save file");
                    watcher.StopFileWatcher();
                    return false;
                }

                Button confirmOverwrite = (new ReplaceFileElements()).BtnNo;
                
                // if no overwrite messagebox came up
                if (confirmOverwrite == null)
                {
                    return true;
                } 
                
                // if file is already available
                // if file should be overwritten
                if (overwriteData)
                {
                    // overwrite
                    confirmOverwrite.Click(DefaultValues.locDefaultLocation);
                } 
                else if (appendData)
                {
                    // if data should be appended to existing file
                    Button confirmAppend = (new ReplaceFileElements()).BtnYes;
                    if (confirmAppend != null && confirmAppend.Enabled)
                    {
                        confirmAppend.Click(DefaultValues.locDefaultLocation);
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Data were appended to existing file: " + fileName);
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button to confirm appened is not accessable.");
                        return false;
                    }
                } 
                else
                {   
                    // if no overwrite nor appending should be performed
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
    }
}