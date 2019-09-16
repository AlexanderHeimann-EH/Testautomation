//------------------------------------------------------------------------------
// <copyright file="IIsModuleAlreadyOpened.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 13.02.2014
 * Time: 16:00 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIsModuleAlreadyOpened
    {
        /// <summary>
        ///     Checks if a specified module is already open
        /// </summary>
        /// <param name="moduleName">Name of module </param>
        /// <returns>
        ///     <br>True: if module is already open</br>
        ///     <br>False: if module is not already opened</br>
        /// </returns>
        bool Run(string moduleName);
    }
}