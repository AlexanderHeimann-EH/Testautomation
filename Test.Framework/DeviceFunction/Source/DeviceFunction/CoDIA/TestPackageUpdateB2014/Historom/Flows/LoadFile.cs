// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadFile.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of LoadFile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Functions.MenuArea.Toolbar.Execution;

    /// <summary>
    ///     Description of LoadFile.
    /// </summary>
    public class LoadFile : ILoadFile
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
            string fileName = ReportHelper.ReportPath + "HistoromData.his";
            return this.Run(fileName);
        }

        /// <summary>
        /// load a file with specified file name, checks whether statistic results and event list contain values after loading
        /// </summary>
        /// <param name="fileName">
        /// User specified filename
        /// </param>
        /// <returns>
        /// true: if loading was successful
        ///     false: if an error occurred
        /// </returns>
        public bool Run(string fileName)
        {
            try
            {
                if (new OpenLoad().ViaIcon() == false)
                {
                    // failed to open file browser dialog
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open file browser dialog");
                    return false;
                }

                if (Execution.OpenFileBrowser.Load(fileName) == false)
                {
                    // loading failed
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Loading file failed");
                    return false;
                }

                if (new CheckGUIAfterReadingOrLoading().Run() == false)
                {
                    // tab statistic and or event list are empty
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Statistic results and or event list are empty, check loaded file");
                    return false;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File " + fileName + " loaded successfully");
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