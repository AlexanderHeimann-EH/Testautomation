//------------------------------------------------------------------------------
// <copyright file="ProjectClose.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 13.05.2011
 * Time: 1:16 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.SpecificFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.CI.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;

    using Ranorex;

    /// <summary>
    ///     Workflow Close.
    /// </summary>
    public class ProjectClose : MarshalByRefObject, IProjectClose
    {
        /// <summary>
        /// Start flow
        /// </summary>
        /// <param name="projectName">Project Name</param>
        /// <param name="replaceProject">Boolean to replace project or not</param>
        /// <returns><br>True: if call worked fine</br>
        /// <br>False: if an error occurred</br></returns>
        public bool Run(string projectName, bool replaceProject)
        {
            // If save-functionality called successfully
            if ((new RunProjectClose()).ViaMenu())
            {
                // If save-message box appears
                Button saveYes = (new SaveProjectMessageElements()).Yes;
                if (saveYes != null && projectName != string.Empty)
                {
                    saveYes.Click(DefaultValues.locDefaultLocation);

                    Text text = (new ProjectBrowserElements()).ProjectName;
                    if (text != null)
                    {
                        text.TextValue = projectName;
                        (new ProjectBrowserElements()).Save.Click(DefaultValues.locDefaultLocation);

                        // If an project with equal projectName already exists
                        Button replaceYes = (new ReplaceProjectMessageElements()).Yes;
                        if (replaceYes != null && replaceProject)
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
                }

                (new SaveProjectMessageElements()).No.Click(DefaultValues.locDefaultLocation);
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Project could not be closed");
            return false;
        }
    }
}