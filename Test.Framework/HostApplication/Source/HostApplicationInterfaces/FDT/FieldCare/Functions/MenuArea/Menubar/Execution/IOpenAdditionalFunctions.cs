//------------------------------------------------------------------------------
// <copyright file="IOpenAdditionalFunctions.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01.07.2011
 * Time: 3:01 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    using Ranorex.Core;

    /// <summary>
    ///     Interface for function Open Additional Functions
    /// </summary>
    public interface IOpenAdditionalFunctions
    {
        /// <summary>
        ///     Open via menu
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        Element ViaMenu();

        /// <summary>
        ///     Open via context menu
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        Element ViaContext();
    }
}