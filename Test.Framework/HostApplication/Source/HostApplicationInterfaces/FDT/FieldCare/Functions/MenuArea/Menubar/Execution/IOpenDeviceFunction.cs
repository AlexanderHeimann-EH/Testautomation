//------------------------------------------------------------------------------
// <copyright file="IRunDeviceFunction.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Interface for function Run Device Function
    /// </summary>
    public interface IRunDeviceFunction
    {
        /// <summary>
        ///     Run via menu
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        Element ViaMenu();

        /// <summary>
        ///     Run via context
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        Element ViaContext();
    }
}