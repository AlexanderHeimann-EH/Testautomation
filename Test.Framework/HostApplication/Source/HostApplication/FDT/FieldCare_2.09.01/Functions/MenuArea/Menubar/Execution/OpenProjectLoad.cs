﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenProjectLoad.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 27.01.2011
 * Time: 1:40 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.MenuArea.Menubar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.MenuArea.MenuBar;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Start [Open Project]-functionality
    /// </summary>
    public class OpenProjectLoad : MarshalByRefObject, IOpenProjectLoad
    {
        /// <summary>
        ///     Start via related menu-entry
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ViaMenu()
        {
            try
            {
                Element element = (new RunFile()).ViaMenu();
                if (element != null && element.Enabled)
                {
                    Button menuEntry = (new Elements()).EntryOpen;
                    if (menuEntry != null && menuEntry.Enabled)
                    {
                        menuEntry.Click(DefaultValues.locDefaultLocation);
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not accessible");
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