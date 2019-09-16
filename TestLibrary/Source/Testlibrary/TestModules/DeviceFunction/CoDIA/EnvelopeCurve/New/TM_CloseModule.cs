//------------------------------------------------------------------------------
// <copyright file="- TM_CloseModule.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 25.08.2011
 * Time: 14:56 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Reflection;
using Common;
using Common.Tools;
using DeviceFunction.CoDIA.Modules.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation;
using DeviceFunction.CoDIA.Modules.EnvelopeCurve.GUI.Dialogs;
using Ranorex;

namespace Testlibrary.TestModules.DeviceDTM.EnvelopeCurve
{
	/// <summary>
	/// Description of DiscardMAPEditing.
	/// </summary>
    public class TM_CloseModule
    {
        /// <summary>
        /// Close module via frame menu within a default time
        /// </summary>
        /// <returns>
        /// <br>True: If call worked fine</br>
        /// <br>False: If an error occured</br>
        /// </returns>
        public bool Run()
        {
            return Run(true, DefaultValues.GeneralTimeout, (new ModuleName()).moduleName);
        }

        /// <summary>
        /// Close module via frame menu within a specific time
        /// </summary>
        /// <param name="timeOutInMiliseconds">Time until action must be finished</param>
        /// <returns>
        /// <br>True: if everything worked fine</br>
        /// <br>False: if an error occured</br>
        /// </returns>
        public bool Run(int timeOutInMiliseconds)
        {
            return Run(true, timeOutInMiliseconds, (new ModuleName()).moduleName);
        }

        /// <summary>
        /// Close module via frame menu within a specific time and regulates if unsaved curves should be saved or not
        /// </summary>
        /// <param name="discardUnsaved">True to discard curves, false to cancel action</param>
        /// <param name="timeOutInMiliseconds">Time until action must be finished</param>
        /// <param name="moduleToClose">Module name</param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        /// <br>False: If an error occured</br>
        /// </returns>
        public bool Run(bool discardUnsaved, int timeOutInMiliseconds, string moduleToClose)
        {
            bool closeExpected = true;

            // if curves should NOT be saved
            if (discardUnsaved)
            {
                closeExpected = false;
            }

            // if module is not already closed
            if (HostApplicationLoader.FDT.FieldCare.Validations.Application.IsModuleAlreadyOpened(moduleToClose) == true)
            {
                // get number of currently opened modules
                int numberOfOpenedModules = HostApplicationLoader.FDT.FieldCare.Validations.Application.GetNumberOfOpenedModules();
                // if number is valid
                if (numberOfOpenedModules != -1)
                {
                    // if function was Executiond successfully
                    if ((new Functions.CloseModule()).ViaWindow(moduleToClose, closeExpected))
                    {
                        // if unsaved data should be discarded
                        if (discardUnsaved)
                        {
                            Button button = (new SaveFileElements()).btnNo;
                            if (button != null && button.Enabled == true)
                            {
                                button.Click(DefaultValues.locDefaultLocation);
                                Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Curves are not saved.");
                            }
                        }
                        else
                        {
                            Button button = (new SaveFileElements()).btnYes;
                            if (button != null && button.Enabled == true)
                            {
                                button.Click(DefaultValues.locDefaultLocation);
                                if (OperatingSystemLoader.Functions.Dialogs.Validation.IsSaveAsDialogOpen.Run())
                                {
                                    OperatingSystemLoader.Functions.Dialogs.Execution.SaveAsFileBrowser.Save();
                                    Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Curves are saved with default filename.");
                                }
                                else
                                {
                                    Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occured while saving with default filename.");
                                }
                            }
                        }
                        // if module is closed within time
                        if (new ModuleOpeningAndClosing().WaitUntilModuleIsClosed(numberOfOpenedModules, timeOutInMiliseconds))
                        {
                            // ######################################### //
                            // TODO: berücksichtigen der Timeout-message
                            // ######################################### //

                            Report.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is closed.");
                            return true;
                        }
                        else
                        {
                            Report.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is not closed.");
                            return false;
                        }
                    }
                    else
                    {
                        Report.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DeviceFunction.Modules.EnvelopeCurve.Functions.CloseModule.ViaWindow() Executiond with errors.");
                        return false;
                    }
                }
                else
                {
                    Report.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Loader.Frame.Validation.Application.GetNumberOfOpenedModules() Executiond with errors.");
                    return false;
                }
            }
            else
            {
                Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is already closed");
                return true;
            }
        }
    }	
}
