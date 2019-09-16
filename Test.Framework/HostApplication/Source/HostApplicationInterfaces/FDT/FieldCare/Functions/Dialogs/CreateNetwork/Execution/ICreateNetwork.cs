//------------------------------------------------------------------------------
// <copyright file="ICreateNetwork.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Scherzinger, Matthias 
 * Date: 04.07.2011
 * Time: 9:25 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.CreateNetwork.Execution
{
    /// <summary>
    ///     Provides methods for dialog ICreateNetwork
    /// </summary>
    public interface ICreateNetwork
    {
        /// <summary>
        ///     Methods to select channel
        /// </summary>
        /// <param name="strChannelName">Channel to select</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool SelectChannel(string strChannelName);

        /// <summary>
        ///     Methods to confirm dialog
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Confirm();

        /// <summary>
        ///     Methods to cancel dialog
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Cancel();

        /// <summary>
        ///     Methods to open help
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool OpenHelp();

        /// <summary>
        ///     Methods to get number of channels
        /// </summary>
        /// <returns>
        ///     <br>String: if call worked fine</br>
        ///     <br>Empty String: if an error occurred</br>
        /// </returns>
        string GetNumberOfChannels();
    }
}