// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RestoreWithoutDownload.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of RestoreWithoutDownload.
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
    ///     Description of RestoreWithoutDownload.
    /// </summary>
    public class RestoreWithoutDownload : IRestoreWithoutDownload
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
            string fileName = ReportHelper.ReportPath + "SaveRestoreData1.deh";
            return this.Run(fileName, false);
        }

        /// <summary>
        /// Flow: Perform a Restore without Download.
        /// </summary>
        /// <param name="fileName">
        /// File to restore
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
            return this.Run(fileName, defaultPath, true, DefaultValues.GeneralTimeout);
        }

        ///// <summary>
        ///// Flow: Perform a Restore without Download.
        ///// </summary>
        ///// <param name="fileName">File to restore</param>
        ///// <param name="waitUntilFinished">Waits for process to finish if set to true</param>
        ///// <param name="timeOutInMilliseconds">Time until action must be finished</param>
        ///// <returns><br>True: If call worked fine</br>
        ///// <br>False: If an error occurred</br></returns>
        // public bool Run(string fileName, bool waitUntilFinished, int timeOutInMilliseconds)
        // {
        // try
        // {
        // return (new Restore()).Run(fileName, waitUntilFinished, timeOutInMilliseconds, true, false, true);
        // }
        // catch (Exception exception)
        // {
        // Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
        // return false;
        // }
        // }

        /// <summary>
        /// Flow: Perform a Restore without Download.
        /// </summary>
        /// <param name="fileName">
        /// File to restore
        /// </param>
        /// <param name="defaultPath">
        /// If true, "Program Data" path is used as file location. Else a valid file location path must be provided
        /// </param>
        /// <param name="waitUntilFinished">
        /// Waits for process to finish if set to true
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// Time until action must be finished
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName, bool defaultPath, bool waitUntilFinished, int timeOutInMilliseconds)
        {
            bool result;
            if (new Restore().Run(fileName, defaultPath, waitUntilFinished, timeOutInMilliseconds, true, false, true) == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Restoring without download failed");
            }
            else
            {
                if (Validation.CheckSaveRestoreStatus.WasRestoringSuccessful() == false)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Restoring without download failed");
                }
                else
                {
                    result = true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Restoring without download succeeded");
                }
            }

            return result;
        }

        #endregion
    }
}