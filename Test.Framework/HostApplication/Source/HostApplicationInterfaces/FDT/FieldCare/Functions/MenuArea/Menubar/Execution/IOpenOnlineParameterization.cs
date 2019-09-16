// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpenOnlineParameterization.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01.07.2011
 * Time: 10:57 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    /// <summary>
    ///     Interface for function Open Online Parameterization.
    /// </summary>
    public interface IOpenOnlineParameterization
    {
        /// <summary>
        /// The via menu.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string ViaMenu();

        /// <summary>
        /// The via context.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string ViaContext();
    }
}