//------------------------------------------------------------------------------
// <copyright file="ICloseAdditionalModule.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 02.11.2012
 * Time: 3:01 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution
{
    /// <summary>
    ///     Description of ICloseAdditionalModule
    /// </summary>
    public interface ICloseAdditionalModule
    {
        /// <summary>
        ///     Close module via window (MDI client)
        /// </summary>
        /// <param name="moduleToClose">Name of module to close</param>
        /// <returns>
        ///     <br>String: if call worked fine</br>
        ///     <br>Empty String: if an error occurred</br>
        /// </returns>
        bool ViaWindow(string moduleToClose);

        /// <summary>
        ///     Close module via window (MDI client)
        /// </summary>
        /// <param name="moduleToClose">Name of module to close</param>
        /// <param name="closeExpected">Boolean if close expected or not</param>
        /// <returns>
        ///     <br>String: if call worked fine</br>
        ///     <br>Empty String: if an error occurred</br>
        /// </returns>
        bool ViaWindow(string moduleToClose, bool closeExpected);
    }
}