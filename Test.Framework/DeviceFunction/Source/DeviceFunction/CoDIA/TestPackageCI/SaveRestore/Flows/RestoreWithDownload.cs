// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RestoreWithDownload.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of RestoreWithDownload.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.SaveRestore.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.SaveRestore.Functions.ApplicationArea.MainView;

    /// <summary>
    ///     Description of RestoreWithDownload.
    /// </summary>
    public class RestoreWithDownload : IRestoreWithDownload
    {
        #region Public Methods and Operators

        /// <summary>
        /// Performs a restore with download. File is loaded from a default file path in the report folder.
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "SaveRestoreData.deh";
            return this.Run(fileName, false);
        }

        /// <summary>
        /// Runs the specified file name.
        /// </summary>
        /// <param name="fileName">
        /// Name of the file.
        /// </param>
        /// <param name="defaultPath">
        /// If true, "Program Data" path is used as file location. Else a valid file location path must be provided
        /// </param>
        /// <returns>
        /// <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
        public bool Run(string fileName, bool defaultPath)
        {
            return this.Run(fileName, defaultPath, true, DefaultValues.DTMDownloadTimeout);
        }

        ///// <summary>
        ///// Flow: Perform a Restore with Download.
        ///// </summary>
        ///// <param name="fileName">Filename for restoring</param>
        ///// <param name="waitUntilFinished">parameter to configure if should be waited until finished or not</param>
        ///// <param name="timeOutInMilliseconds">time to wait</param>
        ///// <returns><br>True: If call worked fine</br>
        ///// <br>False: If an error occurred</br></returns>
        // public bool Run(string fileName, bool waitUntilFinished, int timeOutInMilliseconds)
        // {
        // try
        // {
        // return (new Restore()).Run(fileName, waitUntilFinished, timeOutInMilliseconds, true, true, true);
        // }
        // catch (Exception exception)
        // {
        // Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
        // return false;
        // }
        // }

        /// <summary>
        /// Flow: Perform a Restore with Download.
        /// </summary>
        /// <param name="fileName">
        /// Filename for restoring
        /// </param>
        /// <param name="defaultPath">
        /// If true, "Program Data" path is used as file location. Else a valid file location path must be provided
        /// </param>
        /// <param name="waitUntilFinished">
        /// parameter to configure if should be waited until finished or not
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// time to wait
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName, bool defaultPath, bool waitUntilFinished, int timeOutInMilliseconds)
        {
            bool result;
            if (new Restore().Run(fileName, defaultPath, waitUntilFinished, timeOutInMilliseconds, true, true, true) == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Restoring with download failed");
            }
            else
            {
                if (Validation.CheckSaveRestoreStatus.WasRestoringSuccessful() == false || Validation.CheckDeviceStatus.WasDownloadSuccessful() == false)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Restoring with download failed");
                }
                else
                {
                    result = true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Restoring with download succeeded");
                }
            }

            return result;
        }

        #endregion
    }
}