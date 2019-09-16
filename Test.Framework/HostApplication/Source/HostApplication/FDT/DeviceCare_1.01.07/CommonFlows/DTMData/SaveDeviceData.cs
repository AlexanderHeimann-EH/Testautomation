// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="SaveDeviceData.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The save device data.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// The save device data.
    /// </summary>
    public class SaveDeviceData : CommonHostApplicationLayerInterfaces.CommonFlows.ISaveDeviceData
    {
        /* TODO: The whole class needs to be reworked
         * But it can only be done if the Interface is rewritten and rebuilt from the TestFramework
         * 
         */

        /* TODO: DC only supports Run(string filename) natively
         * - to save device data in another location, the file needs to be moved with file.move
         * - to save the file with another format, the filename needs to be edited to match the desired file extension
         * 
         * Farewell, you beautiful piece of code
         */

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string filePath)
        {
            // instantiate all necessary modules
            var connectionStatus = new Functions.StatusArea.Statusbar.Statusbar_Functions();
            var execFunction = new Functions.Helpers.InterfaceHelpers.DTMFunctions();
            var devScreen = new Functions.ApplicationArea.Page_DeviceScreen.Page_DeviceScreen_Functions();

            string fileLocation;
            string basePath;

            // set all necessary parameters
            devScreen.IsRestoreRequest = false;

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Save device data");

            // check if device is online
            if (connectionStatus.IsDeviceConnected())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is connected. Saving device data...");

                // click button "program functions"
                devScreen.OpenProgramFunctionsMenu();

                // check if menu is open
                if (devScreen.IsDTMFunctionMenuShown())
                {
                    // select "save device data"
                    devScreen.RunDTMFunction();

                    // wait until process is finished
                    if (connectionStatus.IsActionFinished())
                    {
                        // get event message text
                        string msg = connectionStatus.GetStatusMessage();

                        // check if saving was successful
                        if (msg.Contains("set has been saved"))
                        {
                            // get file path and extract basepath (path without name of file itself)
                            fileLocation = connectionStatus.GetFileLocationFromStatusMessage(msg);
                            basePath = connectionStatus.GetBasePath(fileLocation);

                            // construct the destination path
                            string finalizedPath = basePath + "\\" + filePath + ".dcdtm";

                            // rename the file                        
                            execFunction.MoveFile(fileLocation, finalizedPath);

                            // check if renaming was successful
                            if (File.Exists(finalizedPath))
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The file was successfully created");
                                return true;
                            }
                        }
                    }
                }
            }

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
            var connectionStatus = new Functions.StatusArea.Statusbar.Statusbar_Functions();
            var execFunction = new Functions.Helpers.InterfaceHelpers.DTMFunctions();
            var devScreen = new Functions.ApplicationArea.Page_DeviceScreen.Page_DeviceScreen_Functions();

            string fileLocation;
            string basePath;

            // set all necessary parameters
            devScreen.IsRestoreRequest = false;

            // check if device is online
            if (connectionStatus.IsDeviceConnected())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is connected. Saving device data...");

                // click button "program functions"
                devScreen.OpenProgramFunctionsMenu();

                // check if menu is open
                if (devScreen.IsDTMFunctionMenuShown())
                {
                    // select "save device data"
                    devScreen.RunDTMFunction();

                    // wait until process is finished
                    if (connectionStatus.IsActionFinished())
                    {
                        // get event message text
                        string msg = connectionStatus.GetStatusMessage();

                        // check if saving was successful
                        if (msg.Contains("set has been saved"))
                        {
                            // get file path and extract basepath
                            fileLocation = connectionStatus.GetFileLocationFromStatusMessage(msg);
                            basePath = connectionStatus.GetBasePath(fileLocation);

                            // construct the destination path
                            string finalizedPath = filePath + "\\" + fileName + ".dcdtm";

                            // rename the file
                            execFunction.MoveFile(fileLocation, finalizedPath);

                            // check if renaming was successful
                            if (File.Exists(finalizedPath))
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The file was successfully created. File location: " + finalizedPath);
                                return true;
                            }
                        }
                    }
                }
            }

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
        /// <param name="fileFormat">
        /// The file format.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string filePath, string fileName, string fileFormat)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare");

            return false;
        }
    }
}
