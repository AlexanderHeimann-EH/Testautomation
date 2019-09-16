﻿//------------------------------------------------------------------------------
// <copyright file="IIsModuleEnabledAtMenu.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIsModuleEnabledAtMenu
    {
        /// <summary>
        ///     Checks if a specified modules is enabled at menu
        /// </summary>
        /// <param name="moduleName">Name of module</param>
        /// <returns>
        ///     <br>True: if module is available</br>
        ///     <br>False: if module is not available</br>
        /// </returns>
        bool Run(string moduleName);
    }
}