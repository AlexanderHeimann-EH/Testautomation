﻿/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01.07.2011
 * Time: 3:33 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    /// <summary>
    ///     Interface for function Run Find Device
    /// </summary>
    public interface IRunFindDevice
    {
        /// <summary>
        ///     Run via menu
        /// </summary>
        /// <returns>
        ///     <br>True: if element was found and clicked</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ViaMenu(string deviceName);
    }
}