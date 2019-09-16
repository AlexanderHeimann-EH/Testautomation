//------------------------------------------------------------------------------
// <copyright file="RunCreateNetwork.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 11.11.2010
 * Time: 9:03 
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
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.MenuArea.Toolbar;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Go online with focused device
    /// </summary>
    public class RunCreateNetwork : IRunCreateNetwork
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
                Element element = (new RunScanningTools()).ViaMenu();
                if (element != null && element.Enabled)
                {
                    // Select entry Configuration
                    Button menuEntry = (new Elements()).EntryCreateNetwork;
                    if (menuEntry != null && menuEntry.Enabled)
                    {
                        menuEntry.Click(DefaultValues.locDefaultLocation);
                        return menuEntry.Text;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible");
                    return string.Empty;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Submenu is not accessible");
                return string.Empty;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
        public bool ViaContext()
        {
            try
            {
                // TODO: implement context-menu-call 
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}