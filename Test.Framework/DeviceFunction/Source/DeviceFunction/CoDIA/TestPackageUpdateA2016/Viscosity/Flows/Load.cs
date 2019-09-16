// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Load.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for Loading Viscosity files
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.Flows
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Viscosity.Functions.MenuArea.Toolbar;

    using Validation = EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Viscosity.Functions.StatusArea.Usermessages.Validation;

    /// <summary>
    /// Provides methods for Loading Viscosity files
    /// </summary>
    public class Load : ILoad
    {
        #region Public Methods and Operators

        /// <summary>
        /// Loads the Viscosity data from a file in the report folder.
        /// </summary>        
        /// <returns>
        /// true: if file is saved; false: if an error occurred
        /// </returns>
        public bool Run()
        {
            string fileName = ReportHelper.ReportPath + "ViscosityData.visc";
            return this.Run(fileName);
        }

        /// <summary>
        /// load a file with specified file name, check whether user notification message in status bar contains "Data loaded successfully"
        /// </summary>
        /// <param name="fileName">
        /// User specified filename and path of file to load. E.g. C:\test\testFile.visc
        /// </param>
        /// <returns>
        /// true: if loading was successful
        ///     false: if an error occurred
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(string fileName)
        {
            try
            {
                if (Execution.OpenLoad.ViaIcon() == false)
                {
                    // failed to open file browser dialog
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open file browser dialog");
                    return false;
                }

                if (OperatingSystemLoader.Functions.Dialogs.Execution.OpenFileBrowser.Load(fileName) == false)
                {
                    // loading failed
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Loading file failed");
                    return false;
                }

                if (Validation.CheckUserNotificationMessages.ContainsString("Load successful"))
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