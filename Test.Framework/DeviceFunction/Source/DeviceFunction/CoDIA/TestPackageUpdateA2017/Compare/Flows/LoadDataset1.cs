// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadDataset1.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of LoadFile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Compare.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Compare.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///  Description of LoadFile.
    /// </summary>
    public class LoadDataset1 : ILoadDataset1
    {
        #region Public Methods and Operators

        /// <summary>
        /// Flow: Load default file from report folder
        /// </summary>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>s>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "SaveRestoreData.deh";
            return this.Run(fileName);
        }

        /// <summary>
        /// Flow: Load file via file browser
        /// </summary>
        /// <param name="fileName">
        /// File name for saving
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName)
        {
            try
            {
                if ((new Selection()).Dataset1())
                {
                    if (Execution.OpenFileBrowser.Load(fileName))
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Loading file");
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File could not be loaded.");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Load dialog could not be opened.");
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