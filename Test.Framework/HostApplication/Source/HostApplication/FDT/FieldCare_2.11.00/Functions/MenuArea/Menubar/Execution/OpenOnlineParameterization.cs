//------------------------------------------------------------------------------
// <copyright file="OpenOnlineParameterization.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 05.07.2011
 * Time: 8:42 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.MenuArea.MenuBar;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Start [Configuration]-functionality
    /// </summary>
    public class OpenOnlineParameterization : MarshalByRefObject, IOpenOnlineParameterization
    {
        /// <summary>
        ///     Start via related menu-entry
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public string ViaMenu()
        {
            try
            {
                // Select submenu Device Functions
                Element element = (new RunDeviceFunction()).ViaMenu();
                if (element != null && element.Enabled)
                {
                    // Select entry Configuration
                    Button menuEntry = (new Elements()).EntryOnlineParameterize;
                    if (menuEntry != null && menuEntry.Enabled)
                    {
                        menuEntry.Click(DefaultValues.locDefaultLocation);
                        return menuEntry.Text;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible");
                    return string.Empty;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Submenu is not accessible");
                return string.Empty;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }

        /// <summary>
        ///     Start via related context-menu
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public string ViaContext()
        {
            try
            {
                // TODO: Context-Menu-call to be implemented
                return string.Empty;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }
    }
}