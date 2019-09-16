// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 09.03.2011
 * Time: 8:56 
 * Last: -
 * Reason: -
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
    ///     ConfigurationUse provides methods to use the dialog via GUI elements.
    /// </summary>
    public class Configuration : MarshalByRefObject, IConfiguration
    {
        /// <summary>
        ///     Press [Ok]-button to confirm settings and close dialog.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Confirm()
        {
            try
            {
                ConfigurationElements.btnOk.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
        
        /// <summary>
        ///     Press [Apply]-button to confirm settings only. Dialog remains open.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Apply()
        {
            try
            {
                ConfigurationElements.btnApply.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
        
        /// <summary>
        ///     Press [Cancel]-button to close dialog without changed settings.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Cancel()
        {
            try
            {
                ConfigurationElements.btnCancel.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Sets HART Communication configuration by checking string parameters for content.
        /// If parameter is not empty, configuration is done with parameters.
        /// If parameter is empty, no configuration is done. Default is used.
        /// </summary>
        /// <param name="communicationInterface">
        ///     Communication Interface:
        ///     <br>HART modem</br>
        ///     <br>HART multiplexer</br>
        /// </param>
        /// <param name="baudrate">
        ///     Serial Interface
        ///     <br>1200</br>
        ///     <br>2400</br>
        ///     <br>9600</br>
        ///     <br>19200</br>
        ///     <br>38400</br>
        ///     <br>57600</br>
        /// </param>
        /// <param name="rtsControl">
        ///     <br>Disable</br>
        ///     <br>Enable</br>
        ///     <br>Handshake</br>
        ///     <br>Toggle</br>
        /// </param>
        /// <param name="serialInterface">
        ///     <br>COM1</br>
        ///     <br>COM2</br>
        ///     <br>...</br>
        /// </param>
        /// <param name="master">
        ///     <br>Primary Master</br>
        ///     <br>Secondary Master</br>
        /// </param>
        /// <param name="preamble">
        ///     <br>5 ... 20</br>
        /// </param>
        /// <param name="retries">
        ///     <br>1 ... 10</br>
        /// </param>
        /// <param name="startAddress">
        ///     <br>Start address range: 0 ... 63</br>
        /// </param>
        /// <param name="endAddress">
        ///     <br>End address range: 0 ... 63</br>
        /// </param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SetProperties(
            string communicationInterface,
            string baudrate,
            string rtsControl,
            string serialInterface,
            string master,
            string preamble,
            string retries,
            string startAddress,
            string endAddress)
        {
            bool result = false;

            if (communicationInterface.Length > 0)
            {
                try
                {
                    ConfigurationElements.cobCommunicationInterface.Click(DefaultValues.locDefaultLocation);
                    ConfigurationElements.liComboboxList(communicationInterface).Click(DefaultValues.locDefaultLocation);
                    result = true;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    result = false;
                }
            }

            if (baudrate.Length > 0)
            {
                try
                {
                    ConfigurationElements.cobBaudrate.Click(DefaultValues.locDefaultLocation);
                    ConfigurationElements.liComboboxList(baudrate).Click(DefaultValues.locDefaultLocation);
                    result = true;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    result = false;
                }
            }

            if (rtsControl.Length > 0)
            {
                try
                {
                    ConfigurationElements.cobRTSControl.Click(DefaultValues.locDefaultLocation);
                    ConfigurationElements.liComboboxList(rtsControl).Click(DefaultValues.locDefaultLocation);
                    result = true;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    result = false;
                }
            }

            if (serialInterface.Length > 0)
            {
                try
                {
                    ConfigurationElements.cobSerial.Click(DefaultValues.locDefaultLocation);
                    ConfigurationElements.liComboboxList(serialInterface).Click(DefaultValues.locDefaultLocation);
                    result = true;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    result = false;
                }
            }

            if (master.Length > 0)
            {
                try
                {
                    ConfigurationElements.cobMaster.Click(DefaultValues.locDefaultLocation);
                    ConfigurationElements.liComboboxList(master).Click(DefaultValues.locDefaultLocation);
                    result = true;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    result = false;
                }
            }

            if (preamble.Length > 0)
            {
                try
                {
                    ConfigurationElements.cobPreamble.Click(DefaultValues.locDefaultLocation);
                    ConfigurationElements.liComboboxList(preamble).Click(DefaultValues.locDefaultLocation);
                    result = true;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    result = false;
                }
            }

            if (retries.Length > 0)
            {
                try
                {
                    ConfigurationElements.cobRetries.Click(DefaultValues.locDefaultLocation);
                    ConfigurationElements.liComboboxList(retries).Click(DefaultValues.locDefaultLocation);
                    result = true;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    result = false;
                }
            }

            if (startAddress.Length > 0)
            {
                try
                {
                    ConfigurationElements.cobStartAddress.Click(DefaultValues.locDefaultLocation);
                    ConfigurationElements.liComboboxList(startAddress).Click(DefaultValues.locDefaultLocation);
                    result = true;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    result = false;
                }
            }

            if (endAddress.Length > 0)
            {
                try
                {
                    ConfigurationElements.cobEndAddress.Click(DefaultValues.locDefaultLocation);
                    ConfigurationElements.liComboboxList(endAddress).Click(DefaultValues.locDefaultLocation);
                    result = true;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    result = false;
                }
            }

            return result;
        }
    }
}