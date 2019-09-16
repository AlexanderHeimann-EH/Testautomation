// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectNewEmpty.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 13.07.2011
 * Time: 9:57 
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
    ///     Description of NewEmptyProject.
    /// </summary>
    public class ProjectNewEmpty : MarshalByRefObject, IProjectNewEmpty
    {
        /// <summary>
        /// Start flow
        /// </summary>
        /// <returns><br>True: if call worked fine</br>
        /// <br>False: if an error occurred</br></returns>
        public bool Run()
        {
            if ((new OpenProjectNew()).ViaMenu())
            {
                ListItem listItem = (new ProjectBrowserElements()).EmptyProject;
                if (listItem != null && listItem.Enabled)
                {
                    var center = new Location(
                        listItem.ScreenRectangle.Size.Width / 2,
                        listItem.ScreenRectangle.Size.Height / 2);
                    listItem.Click(center);

                    Button button = (new ProjectBrowserElements()).Open;
                    if (button != null && button.Enabled)
                    {
                        button.Click(DefaultValues.locDefaultLocation);
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Button [ProjectBrowserElements.Open] was not found.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "List item [ProjectBrowserElements.EmptyProject] was not found.");
                return false;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Project browser could not be opened");
            return false;
        }
    }
}