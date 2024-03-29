﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Save.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Viscosity.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.TestPackageCI.Viscosity.Functions.MenuArea.Toolbar.Execution;

    /// <summary>
    /// The save.
    /// </summary>
    public class Save : MarshalByRefObject, ISave
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Saves current Viscosity data via Save button, uses proposed file name and a default path.
        /// </summary>
        /// <returns>
        ///     true: if call worked fine
        ///     false: if an error occurred
        /// </returns>
        public bool Run()
        {
            var watcher = new FileWatcher(SystemInformation.GetApplicationDataPath, "*.visc");
            watcher.StartFileWatcher();

            if (new OpenSave().ViaIcon() == false)
            {
                // failed to open save as dialog
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open save as file browser dialog");
                watcher.StopFileWatcher();
                return false;
            }

            // Check if save as dialog is visible, this happens when you save the first time
            if (Validation.IsSaveAsDialogOpen.Run() == false)
            {
                // save as dialog is not visible, file saved
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saved file successfully");
                watcher.StopFileWatcher();
                return true;
            }

            // set default path
            string proposedFileName = Execution.SaveAsFileBrowser.ProposedFileName;
            Execution.SaveAsFileBrowser.ProposedFileName = SystemInformation.GetApplicationDataPath + @"\" + proposedFileName;

            if (Execution.SaveAsFileBrowser.Save() == false)
            {
                // failed to save file
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to save file");
                watcher.StopFileWatcher();
                return false;
            }

            // HACK: 2013-06-07
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

        #endregion
    }
}