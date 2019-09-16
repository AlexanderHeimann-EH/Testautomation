// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveProject.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for saving a project
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V20901.CommonFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.SaveProjectInProgress.Validation;
    using EH.PCPS.TestAutomation.FieldCare.V20901.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;

    using Ranorex;

    using DateTime = System.DateTime;

    /// <summary>
    ///     Provides methods for saving a project
    /// </summary>
    public class SaveProject : MarshalByRefObject, ISaveProject
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Saves project with default filename(actual date and time)
        /// </summary>
        /// <returns>
        ///     <br>true: if project is saved</br>
        ///     <br>false: if an error occurred</br>
        /// </returns>
        public bool Run()
        {
            // If save-functionality called successfully
            if ((new RunProjectSave()).ViaMenu())
            {
                // If project was never saved before and a projectName is available
                Text text = (new ProjectBrowserElements()).ProjectName;
                if (text != null)
                {
                    string projectName = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
                    text.TextValue = projectName;
                    (new ProjectBrowserElements()).Save.Click(DefaultValues.locDefaultLocation);
                }

                if (new ValidationMethods().WaitUntilSavingFinished(DefaultValues.GeneralTimeout) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving timed out.");
                    return false;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Project saved.");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Project could not be saved");
            return false;
        }

        /// <summary>
        /// Saves project with specified filename
        /// </summary>
        /// <param name="projectName">
        /// Filename for the project
        /// </param>
        /// <returns>
        /// <br>true: if project is saved</br>
        ///     <br>false: if an error occurred</br>
        /// </returns>
        public bool Run(string projectName)
        {
            // If save as-functionality called successfully
            if ((new OpenProjectSaveAs()).ViaMenu())
            {
                // Save project with projectName
                Text text = (new ProjectBrowserElements()).ProjectName;
                Button save = (new ProjectBrowserElements()).Save;
                if (text == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Project name is not set because it´s empty.");
                    return false;
                }

                text.TextValue = projectName;
                if (save == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button [Save] is not found.");
                    return false;
                }

                save.Click();

                // If an project with equal projectName already exists -> overwrite
                Button button = (new ReplaceProjectMessageElements()).Yes;
                if (button != null)
                {
                    // Confirm replace message
                    button.Click(DefaultValues.locDefaultLocation);
                }

                if (new ValidationMethods().WaitUntilSavingFinished(DefaultValues.GeneralTimeout) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving timed out.");
                    return false;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Project saved.");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Project could not be saved");
            return false;
        }

        #endregion
    }
}