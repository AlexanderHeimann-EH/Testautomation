//------------------------------------------------------------------------------
// <copyright file="LoadProject.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 26.02.2014
 * Time: 10:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.CommonFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.ProjectBrowser.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V20901.Functions.MenuArea.Menubar.Execution;

    using Ranorex;

    /// <summary>
    ///     Provides methods for loading a project
    /// </summary>
    public class LoadProject : MarshalByRefObject, ILoadProject
    {
        /// <summary>
        ///     Load a specified project
        /// </summary>
        /// <param name="projectName">Project to load</param>
        /// <returns>true: if project is loaded; false: if an error occurred</returns>
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