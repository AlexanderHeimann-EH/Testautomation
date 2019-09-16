//------------------------------------------------------------------------------
// <copyright file="IOpenConfiguration.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 05.07.2011
 * Time: 7:05 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.HartComm.Functions.ApplicationArea.MainView.Execution
{
    /// <summary>
    ///     Interface for function Open Communication
    /// </summary>
    public interface IOpenConfiguration
    {
        /// <summary>
        ///     Run via menu
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ViaMenu();

        /// <summary>
        ///     Run via context
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ViaContext();
    }
}