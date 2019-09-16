// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfirmAddress.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 10.11.2010
 * Time: 8:50 
 * Last: 25.11.2010
 * Reason: Code documentation
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HARTCommunication.V1037.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.HartComm.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.HARTCommunication.V1037.GUI.ApplicationArea.MainView;

    /// <summary>
    ///     ConfirmAddressUse provides methods to use the dialog via GUI elements.
    /// </summary>
    public class ConfirmAddress : MarshalByRefObject, IConfirmAddress
    {
        /// <summary>
        ///     Press [OK]-button to confirm set address.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Confirm()
        {
            try
            {
                ConfirmAddressElements.BtnOk.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }


        /// <summary>
        ///     Press [Cancel]-button to set no address.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Cancel()
        {
            try
            {
                ConfirmAddressElements.BtnCancel.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }


        /// <summary>
        ///     Select a DTM Polling Address via combobox
        /// </summary>
        /// <param name="strAddress">Address to select</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SetDTMPollingAddress(string strAddress)
        {
            try
            {
                // TODO: implementieren SetDTMPollingAddress 
                // - select iAddress-related entry in combobox with .Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }


        /// <summary>
        ///     Write DTM Tag into textfield
        /// </summary>
        /// <param name="strDTMTag">DTM Tag to write</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SetDTMTag(string strDTMTag)
        {
            try
            {
                // TODO: implementieren SetDTMTag
                // - enter DTM Tag into related textfield
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}