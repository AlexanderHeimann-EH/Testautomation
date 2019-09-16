// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateProject.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 12.02.2014
 * Time: 16:
 * Last: 2015-01-16
 * Reason: -
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Ranorex;

    /// <summary>
    /// Provides methods for creating a project
    /// </summary>
    public class CreateProject : ICreateProject
    {
        /// <summary>
        /// Creates a project and save it by default
        /// </summary>
        /// <param name="projectName">Name of the project to create.</param>
        /// <returns>true in case of success;false in case of an error</returns>
        public bool Run(string projectName)
        {
            if ((new Functions.MenuArea.Menubar.Execution.OpenProjectNew()).ViaMenu())
            {
                Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry found.");
                if ((new Functions.Dialogs.ProjectBrowser.Execution.ProjectBrowser()).CreateNew())
                {
                    Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Empty project created");
                    return true;
                }

                Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unable to create an new project");
            }
            
            Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unable to open menu bar.");
            return false;
        }
    }
}
