// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveWithoutUpload.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of SaveWithoutUpload.
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
    ///     Description of SaveWithoutUpload.
    /// </summary>
    public class SaveWithoutUpload : ISaveWithoutUpload
    {
        #region Public Methods and Operators

        /// <summary>
        /// Performs a save without download. File is saved to a default file path in the report folder.
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "SaveRestoreData1";
            return this.Run(fileName, false);
        }

        /// <summary>
        /// Flow: Perform a save without upload. No file dialog is used.
        /// A default filename is used.
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
            return this.Run(fileName, defaultPath, true, DefaultValues.GeneralTimeout);
        }

        #endregion

        ///// <summary>
        ///// Flow: Perform a save without upload. File dialog is called
        ///// if Filename is not an empty String.
        ///// </summary>
        ///// <param name="fileName">Name of the file.</param>
        ///// <param name="waitUntilFinished">parameter to configure if should be waited until finished or not</param>
        ///// <param name="timeOutInMilliseconds">time to wait</param>
        ///// <returns><br>True: If call worked fine</br>
        ///// <br>False: If an error occurred</br></returns>
        // private bool Run(string fileName, bool waitUntilFinished, int timeOutInMilliseconds)
        // {
        // try
        // {
        // return (new Save()).Run(fileName, waitUntilFinished, timeOutInMilliseconds, true, false);
        // }
        // catch (Exception exception)
        // {
        // Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
        // return false;
        // }
        // }
        #region Methods

        /// <summary>
        /// Flow: Perform a save without upload. File dialog is called
        /// if Filename is not an empty String.
        /// </summary>
        /// <param name="fileName">
        /// Name of the file.
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
        private bool Run(string fileName, bool defaultPath, bool waitUntilFinished, int timeOutInMilliseconds)
        {
            bool result;

            if (new Save().Run(fileName, defaultPath, waitUntilFinished, timeOutInMilliseconds, true, false) == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save without Upload failed.");
            }
            else
            {
                if (Validation.CheckSaveRestoreStatus.WasSavingSuccessful() == false)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save without Upload failed.");
                }
                else
                {
                    result = true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save without Upload succeeded.");
                }
            }

            return result;
        }

        #endregion
    }
}