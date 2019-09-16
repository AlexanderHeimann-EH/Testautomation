//------------------------------------------------------------------------------
// <copyright file="RunDeviceOperation.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 31.08.2011
 * Time: 7:20 
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
    ///     Description of RunDeviceOperation.
    /// </summary>
    public class RunDeviceOperation : MarshalByRefObject, IRunDeviceOperation
    {
        /// <summary>
        ///     Start via related menu-entry
        /// </summary>
        /// <returns>
        ///     <br>Element: If call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        public Element ViaMenu()
        {
            try
            {
                MenuItem menuItem = (new Elements()).MenuDeviceOperation;
                if (menuItem != null && menuItem.Enabled)
                {
                    menuItem.Click(DefaultValues.locDefaultLocation);

                    // select container for Frame -> Device Operation menu entries
                    Element element = (new Elements()).MenuElement(HandleFunctions.GetZeroHandle());
                    Mouse.MoveTo(element, DefaultValues.locDefaultLocation);
                    return element;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu is not accessible");
                return null;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}