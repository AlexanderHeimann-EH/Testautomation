//------------------------------------------------------------------------------
// <copyright file="IFindDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 04.07.2011
 * Time: 9:25 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.FindDevice.Execution
{
    /// <summary>
    ///     Interface for dialog Find Device
    /// </summary>
    public interface IFindDevice
    {
        /// <summary>
        ///     Enter specified device
        /// </summary>
        /// <param name="deviceName">Device name</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool EnterDevice(string deviceName);

        /// <summary>
        ///     Find Next device
        /// </summary>
        /// <param name="deviceName">Device name</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool FindNext(string deviceName);

        /// <summary>
        ///     Find device
        /// </summary>
        /// <param name="deviceName">Device name</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Find(string deviceName);

        /// <summary>
        ///     Cancel dialog
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Cancel();

        /// <summary>
        ///     Open help
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool OpenHelp();
    }
}