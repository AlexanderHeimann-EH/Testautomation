//------------------------------------------------------------------------------
// <copyright file="ProjectLoad.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 23.02.2012
 * Time: 9:57 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.SpecificFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.ProjectBrowser.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;

    using Ranorex;

    /// <summary>
    ///     Description of ProjectLoad.
    /// </summary>
    public class ProjectLoad : MarshalByRefObject, IProjectLoad
    {
        /// <summary>
        /// Start flow
        /// </summary>
        /// <param name="projectName">Project name</param>
        /// <returns><br>True: if call worked fine</br>
        /// <br>False: if an error occurred</br></returns>
        public bool Run(string projectName)
        {
            if ((new OpenProjectLoad()).ViaMenu())
            {
                return (new ProjectBrowser()).LoadProjectViaTextField(projectName);
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Project browser could not be opened");
            return false;
        }
    }
}