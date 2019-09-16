// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveFile.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of SaveFile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.SaveRestore.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Flows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;
    using EH.PCPS.TestAutomation.TestPackageCI.SaveRestore.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Description of SaveFile.
    /// </summary>
    public class SaveFile : MarshalByRefObject, ISaveFile
    {
        #region Public Methods and Operators

        /// <summary>
        /// Flow: Save file via filebrowser
        /// </summary>
        /// <param name="fileName">
        /// Filename to save file as
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName)
        {
            try
            {
                if (new Selection().Save())
                {
                    if (Validation.IsSaveAsDialogOpen.Run())
                    {
                        if (Execution.SaveAsFileBrowser.SaveAs(fileName))
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving file: [" + fileName + "]");
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File could not be saved.");
                        return false;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save dialog is not available.");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save dialog could not be opened.");
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