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
    public interface IConfiguration
    {
        /// <summary>
        ///     Press [Ok]-button to confirm settings and close dialog.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        bool Confirm();

        /// <summary>
        /// Use [Apply]-button
        /// </summary>
        /// <returns></returns>
        bool Apply();

        /// <summary>
        /// Use [Cancel]-button
        /// </summary>
        /// <returns></returns>
        bool Cancel();

        /// <summary>
        /// Set properties of Communication DTM
        /// </summary>
        /// <param name="strCommInterface">Communication Interface</param>
        /// <param name="strBaudrate">Baudrate</param>
        /// <param name="strRTSControl">RTSControl</param>
        /// <param name="strSerialInterface">Serial Interface</param>
        /// <param name="strMaster">Master</param>
        /// <param name="strPreamble">Preamble</param>
        /// <param name="strRetries">Retries</param>
        /// <param name="strStartAddress">Start Address</param>
        /// <param name="strEndAddress">End Address</param>
        /// <returns></returns>
        bool SetProperties( string strCommInterface,
                            string strBaudrate,
                            string strRTSControl,
                            string strSerialInterface,
                            string strMaster,
                            string strPreamble,
                            string strRetries,
                            string strStartAddress,
                            string strEndAddress);
    }
}