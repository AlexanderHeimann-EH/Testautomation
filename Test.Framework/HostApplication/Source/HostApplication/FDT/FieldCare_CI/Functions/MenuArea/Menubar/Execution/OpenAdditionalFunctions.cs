//------------------------------------------------------------------------------
// <copyright file="OpenAdditionalFunctions.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 02.12.2010
 * Time: 1:11 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.Functions.MenuArea.Menubar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.MenuArea.MenuBar;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Open [Additional Functions Submenu]
    /// </summary>
    public class OpenAdditionalFunctions : MarshalByRefObject, IOpenAdditionalFunctions
    {
        /// <summary>
        ///     Open submenu in menu bar
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public Element ViaMenu()
        {
            try
            {
                Element element = (new RunDeviceFunction()).ViaMenu();
                if (element != null && element.Enabled)
                {
                    MenuItem menuItem = (new Elements()).EntryAdditionalFunctions;
                    if (menuItem != null && menuItem.Enabled)
                    {
                        menuItem.Click(DefaultValues.locDefaultLocation);

                        // Select container for Additional Functions -> menu entries
                        element = (new Elements()).MenuElement(HandleFunctions.GetHandle(element));
                        Mouse.MoveTo(element, DefaultValues.locDefaultLocation);
                        return element;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu is not accessible");
                    return null;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Submenu is not accessible");
                return null;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        ///     Start via related context-menu
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public Element ViaContext()
        {
            try
            {
                // TODO: Context-Menu-call to be implemented
                // Element element = null;
                // return element;
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