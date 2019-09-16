//------------------------------------------------------------------------------
// <copyright file="ProjectSave.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 13.05.2011
 * Time: 10:18 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.SpecificFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;

    using Ranorex;

    /// <summary>
    ///     Workflow Save.
    /// </summary>
    public class ProjectSave : MarshalByRefObject, IProjectSave
    {
        /// <summary>
        ///     Run workflow
        /// </summary>
        /// <param name="projectName">Name to save project, if never saved before</param>
        /// <param name="replaceProject">Option to replace an already available project</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string projectName, bool replaceProject)
        {
            // If save-functionality called successfully
            if ((new RunProjectSave()).ViaMenu())
            {
                // If project was never saved before and a projectName is available
                Text text = (new ProjectBrowserElements()).ProjectName;
                if (text != null && projectName != string.Empty)
                {
                    // Save project with projectName
                    text.TextValue = projectName;
                    (new ProjectBrowserElements()).Save.Click(DefaultValues.locDefaultLocation);

                    // If an project with equal projectName already exists
                    Button button = (new ReplaceProjectMessageElements()).Yes;
                    if (button != null && replaceProject)
                    {
                        // Confirm replace message
                        (new ReplaceProjectMessageElements()).Yes.Click(DefaultValues.locDefaultLocation);
                    }
                    else
                    {
                        // Cancel replace
                        (new ReplaceProjectMessageElements()).Cancel.Click(DefaultValues.locDefaultLocation);
                    }
                }

                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Project could not be saved");
            return false;
        }
    }
}