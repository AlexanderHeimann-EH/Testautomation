//------------------------------------------------------------------------------
// <copyright file="IRunCreateNetwork.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01.07.2011
 * Time: 3:31 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Toolbar.Execution
{
    /// <summary>
    ///     Interface for function Run Create Network
    /// </summary>
    public interface IRunCreateNetwork
    {
        /// <summary>
        ///     Run via icon
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ViaIcon();
    }
}