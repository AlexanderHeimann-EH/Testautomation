// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveWithUpload.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of SaveWithUpload.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.SaveRestore.Functions.ApplicationArea.MainView;

    /// <summary>
    ///     Description of SaveWithUpload.
    /// </summary>
    public class SaveWithUpload : ISaveWithUpload
    {
        #region Public Methods and Operators

        /// <summary>
        /// Performs a save with upload. File is saved with a default file name in the report folder.
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "SaveRestoreData";
            return this.Run(fileName, false);
        }

        /// <summary>
        /// Flow: Perform a save with upload. No file dialog is used.A default filename is used.
        /// </summary>
        /// <param name="fileName">
        /// Name of the file.
        /// </param>
        /// <param name="defaultPath">
        /// If true, "Program Data" path is used as file location. Else a valid file location path must be provided
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName, bool defaultPath)
        {
            return this.Run(fileName, defaultPath, true, DefaultValues.DTMDownloadTimeout);
        }

        /// <summary>
        /// Flow: Perform a save with upload. No file dialog is used.
        /// A default filename is used.
        /// </summary>
        /// <param name="fileName">
        /// Name of the file.
        /// </param>
        /// <param name="defaultPath">
        /// If true, "Program Data" path is used as file location. Else a valid file location path must be provided
        /// </param>
        /// <param name="waitUntilFinished">
        /// if set to <c>true</c> [wait until finished].
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName, bool defaultPath, bool waitUntilFinished)
        {
            return this.Run(fileName, defaultPath, waitUntilFinished, DefaultValues.DTMDownloadTimeout);
        }

        ///// <summary>
        ///// Flow: Perform a save with upload. File dialog is called
        ///// if Filename is not an empty String.
        ///// </summary>
        ///// <param name="fileName">Name of the file.</param>
        ///// <param name="waitUntilFinished">if set to <c>true</c> [wait until finished].</param>
        ///// <param name="timeOutInMilliseconds">The time out in milliseconds.</param>
        ///// <returns><br>True: If call worked fine</br>
        ///// <br>False: If an error occurred</br></returns>
        // public bool Run(string fileName, bool waitUntilFinished, int timeOutInMilliseconds)
        // {
        // try
        // {
        // return (new Save()).Run(fileName, waitUntilFinished, timeOutInMilliseconds, true, true);
        // }
        // catch (Exception exception)
        // {
        // Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
        // return false;
        // }
        // }

        /// <summary>
        /// Flow: Perform a save with upload. File dialog is called
        /// if Filename is not an empty String.
        /// </summary>
        /// <param name="fileName">
        /// Name of the file.
        /// </param>
        /// <param name="defaultPath">
        /// If true, "Program Data" path is used as file location. Else a valid file location path must be provided
        /// </param>
        /// <param name="waitUntilFinished">
        /// if set to <c>true</c> [wait until finished].
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// The time out in milliseconds.
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName, bool defaultPath, bool waitUntilFinished, int timeOutInMilliseconds)
        {
            bool result;

            if (new Save().Run(fileName, defaultPath, waitUntilFinished, timeOutInMilliseconds, true, true) == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save with Upload failed.");
            }
            else
            {
                if (Validation.CheckSaveRestoreStatus.WasSavingSuccessful() == false || Validation.CheckDeviceStatus.WasUploadSuccessful() == false)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save with Upload failed.");
                }
                else
                {
                    result = true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save with Upload succeeded.");
                }
            }

            return result;
        }

        #endregion
    }
}