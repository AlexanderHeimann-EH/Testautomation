//------------------------------------------------------------------------------
// <copyright file="IRunDTMCatalogue.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 31.08.2011
 * Time: 07:35 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    using Ranorex.Core;

    /// <summary>
    ///     Interface for function Run DTM Catalogue
    /// </summary>
    public interface IRunDtmCatalogue
    {
        /// <summary>
        ///     Run via menu
        /// </summary>
        /// <returns>
        ///     <br>Element: if call worked fine</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        Element ViaMenu();
    }
}