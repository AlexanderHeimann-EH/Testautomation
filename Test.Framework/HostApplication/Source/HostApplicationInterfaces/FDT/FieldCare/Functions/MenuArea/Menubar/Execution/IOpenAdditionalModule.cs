//------------------------------------------------------------------------------
// <copyright file="IOpenAdditionalModule.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 02.11.2012
 * Time: 3:01 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    /// <summary>
    ///     Interface for function Open Addition Module
    /// </summary>
    public interface IOpenAdditionalModule
    {
        /// <summary>
        ///     Run via menu
        /// </summary>
        /// <param name="moduleToOpen">Module name</param>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ViaMenu(string moduleToOpen);
    }
}