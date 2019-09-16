//------------------------------------------------------------------------------
// <copyright file="ProjectBrowser.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 11.03.2011
 * Time: 6:44 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.ProjectBrowser.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.ProjectBrowser.Execution;

    using Ranorex;

    /// <summary>
    ///     ProjectBrowserElements provides functions to use the dialog
    /// </summary>
    public class ProjectBrowser : MarshalByRefObject, IProjectBrowser
    {
        /// <summary>
        ///     In project browser, select empty project and confirm
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool CreateNew()
        {
            try
            {
                (new ProjectBrowserElements()).EmptyProject.Click(DefaultValues.locDefaultLocation);
                (new ProjectBrowserElements()).Open.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Cancel project browser
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Cancel()
        {
            try
            {
                Button button = (new ProjectBrowserElements()).Cancel;
                if (button != null)
                {
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not available");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Select and open available project via text field
        /// </summary>
        /// <param name="projectName">Name of project to load</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool LoadProjectViaTextField(string projectName)
        {
            try
            {
                Text textField = (new ProjectBrowserElements()).ProjectName;
                if (textField != null && textField.Enabled)
                {
                    textField.Click(DefaultValues.locDefaultLocation);
                    textField.TextValue = projectName;

                    Button openProject = (new ProjectBrowserElements()).Open;
                    if (openProject != null && openProject.Enabled)
                    {
                        openProject.Click(DefaultValues.locDefaultLocation);

                        Button confirmError = (new OpenUnavailableProjectMessageElements()).Ok;
                        if (confirmError == null)
                        {
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "Project [" + projectName + "]" + " does not exist.");
                        return false;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Button Open Project is not accessible.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Field to enter project name is not accessible");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}