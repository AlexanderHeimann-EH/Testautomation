//------------------------------------------------------------------------------
// <copyright file="IsModuleAvailableAtMenu.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 13.02.2014
 * Time: 15:54 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.MenuArea.Menubar.Validation
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.MenuArea.MenuBar;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Validation;

    using Ranorex;

    /// <summary>
    /// Class IsModuleAvailableAtMenu.
    /// </summary>
    public class IsModuleAvailableAtMenu : MarshalByRefObject, IIsModuleAvailableAtMenu
    {
        /// <summary>
        ///     Checks if a specified modules is available via menu
        /// </summary>
        /// <param name="moduleName">Name of module</param>
        /// <returns>
        ///     <br>True: if module is available</br>
        ///     <br>False: if module is not available</br>
        /// </returns>
        public bool Run(string moduleName)
        {
            try
            {
                if ((new Elements()).EntryModule(moduleName) != null)
                {
                    return true;
                }

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