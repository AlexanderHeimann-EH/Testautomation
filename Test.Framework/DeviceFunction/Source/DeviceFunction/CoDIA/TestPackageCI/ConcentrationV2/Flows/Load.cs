// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Load.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The load.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.MenuArea.Toolbar;

    using Validation = EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.StatusArea.Statusbar.Validation;

    /// <summary>
    /// The load.
    /// </summary>
    public class Load : ILoad
    {
        #region Public Methods and Operators

        /// <summary>
        /// Exports Concentration data with default name to report folder
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "ConcentrationData.conc";
            return this.Run(fileName);
        }

        /// <summary>
        /// load a file with specified file name, check whether user notification message in status bar contains "Data loaded successfully"
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
                if (Execution.OpenLoad.ViaIcon() == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open file browser dialog");
                    return false;
                }

                if (OperatingSystemLoader.Functions.Dialogs.Execution.OpenFileBrowser.Load(fileName) == false)
                {
                    // loading failed
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Loading file failed");
                    return false;
                }

                if (Validation.CheckUserNotificationMessages.Run("load successful"))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File " + fileName + " loaded successfully");
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Loading failed");
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