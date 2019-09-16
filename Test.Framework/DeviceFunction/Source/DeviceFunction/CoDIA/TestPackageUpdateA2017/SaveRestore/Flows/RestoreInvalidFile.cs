
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.GUI.ApplicationArea.MainView;

    using Navigation = EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Execution.Navigation;
    using Selection = EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Execution.Selection;

    /// <summary>
    /// Class RestoreInvalidFile.
    /// </summary>
    public class RestoreInvalidFile : IRestoreInvalidFile
    {
        #region Public Methods and Operators

        /// <summary>
        /// Tries to restore an invalid file and validates whether the modules behavior is correct and its not possible to restore.
        /// </summary>
        /// <param name="fileName">
        /// Filename of an invalid file to restore
        /// </param>
        /// <param name="defaultPath">
        /// If true, "Program Data" path is used as file location. Else a valid file location path must be provided
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string fileName, bool defaultPath)
        {
            bool result = true;

            if (new Navigation().Restore() == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to press Restore button.");
                result = false;
            }
            else
            {
                // Use file dialog to create file with specified filename
                if (fileName == string.Empty)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File name must not be empty.");
                    result = false;
                }
                else
                {
                    if (defaultPath)
                    {
                        // set default path
                        fileName = SystemInformation.GetApplicationDataPath + @"\" + fileName;
                    }

                    if ((new LoadFile()).Run(fileName) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Loading file \"" + fileName + "\" failed.");
                        result = false;
                    }
                    else
                    {                        
                        new Navigation().Start();
                        string message = new CheckSaveRestoreStatus().GetCurrentStatus().ToLower();
                        Ranorex.Button restore = new NavigationElements().BtnRestore;
                        bool isRestoreEnabled = false;
                        if (restore != null)
                        {
                            isRestoreEnabled = restore.Enabled;
                        }

                        if (message.Contains("please select another file") == false || isRestoreEnabled)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tried to restore an invalid file. Module did not recognize this and would have allowed to restore the file.");
                            result = false;
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tried to restore an invalid file. Module recognized this and refused to restore the file as expected.");
                        }
                    }
                }   
            }           

            return result;
        }

        #endregion
    }
}