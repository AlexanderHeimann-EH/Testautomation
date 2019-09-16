//------------------------------------------------------------------------------
// <copyright file="IGetModuleAreaControl.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01.12.2010
 * Time: 10:55 
 * Modified: 08.03.2012
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation
{
    using Ranorex.Core;

    /// <summary>
    /// 
    /// </summary>
    public interface IGetModuleAreaControl
    {
        /// <summary>
        /// Get module area control
        /// </summary>
        /// <returns>
        ///     <br>Element: if call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        Element Run();
    }
}