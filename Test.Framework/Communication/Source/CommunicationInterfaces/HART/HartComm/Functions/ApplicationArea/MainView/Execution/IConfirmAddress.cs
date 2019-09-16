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
    public interface IConfirmAddress
    {
        /// <summary>
        ///     Press [OK]-button to confirm set address.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        bool Confirm();

        /// <summary>
        ///     Press [Cancel]-button to set no address.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        bool Cancel();

        /// <summary>
        ///     Select a DTM Polling Address via combobox
        /// </summary>
        /// <param name="strAddress">Address to select</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        bool SetDTMPollingAddress(string strAddress);

        /// <summary>
        ///     Write DTM Tag into textfield
        /// </summary>
        /// <param name="strDTMTag">DTM Tag to write</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        bool SetDTMTag(string strDTMTag);
    }
}