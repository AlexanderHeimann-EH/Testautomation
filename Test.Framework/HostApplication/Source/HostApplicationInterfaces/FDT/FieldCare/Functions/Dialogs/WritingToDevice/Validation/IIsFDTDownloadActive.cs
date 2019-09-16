//------------------------------------------------------------------------------
// <copyright file="IIsFDTDownloadActive.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 20.04.2012
 * Time: 6:44 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.WritingToDevice.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIsFDTDownloadActive
    {
        /// <summary>
        ///     Check if FDT Download dialog is active
        /// </summary>
        /// <returns>
        ///     <br>True: if validation is true</br>
        ///     <br>False: if validation fails</br>
        /// </returns>
        bool Run();
    }
}