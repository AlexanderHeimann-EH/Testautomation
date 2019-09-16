// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="RestoreDeviceData.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of RestoreDeviceData.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Description of RestoreDeviceData.
    /// </summary>
    public class RestoreDeviceData : CommonHostApplicationLayerInterfaces.CommonFlows.IRestoreDeviceData
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string fileName)
        {
            /*
             * Function not supported by DC
             * Method reports warning message and returns with false
             */

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare)");

            return false;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string filePath, string fileName)
        {
            // instantiate all necessary modules
            var execFunction = new Functions.Helpers.InterfaceHelpers.DTMFunctions();
            var connectionStatus = new Functions.StatusArea.Statusbar.Statusbar_Functions();
            var devScreen = new Functions.ApplicationArea.Page_DeviceScreen.Page_DeviceScreen_Functions();
            var dialog = new Functions.Helpers.DialogFunctions();

            // set all necessary parameters
            devScreen.IsRestoreRequest = true;

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Restore device data");

            if (connectionStatus.IsDeviceConnected())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is connected. Restoring device data...");

                // click button "program functions"
                devScreen.OpenProgramFunctionsMenu();

                // check if menu is open
                if (devScreen.IsDTMFunctionMenuShown())
                {
                    // select "restore device data" and then "browse"
                    devScreen.RunDTMFunction();

                    // check if browse dialog is open
                    if (dialog.IsBrowseDialogOpen())
                    {
                        // construct the destination path
                        string finalizedPath = filePath + "\\" + fileName + ".dcdtm";

                        // set filepath in the browse dialog
                        dialog.SetFilePath(finalizedPath);

                        // check if path is set
                        if (dialog.IsFilePathSet(finalizedPath))
                        {
                            // select "go" and then "ok"
                            dialog.AckDialog();

                            // check if pop up dialog is open
                            if (dialog.IsPopupOpen())
                            {
                                // select yes in the pop up dialog
                                dialog.AckPopup();

                                // wait for completion and check status area message for success/failure
                                if (devScreen.IsRestoreFinished())
                                {
                                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Restoring DTM data was successful");
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
