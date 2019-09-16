//------------------------------------------------------------------------------
// <copyright file="IsFDTDownloadActive.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.WritingToDevice.Validation
{
    using System;

    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.WritingToDevice.Validation;

    /// <summary>
    ///     WritingToDevice provides functions to use the dialog
    /// </summary>
    public class IsFdtDownloadActive : MarshalByRefObject, IIsFDTDownloadActive
    {
        /// <summary>
        ///     Check if FDT Download dialog is active
        /// </summary>
        /// <returns>
        ///     <br>True: if validation is true</br>
        ///     <br>False: if validation fails</br>
        /// </returns>
        public bool Run()
        {
            if ((new WritingToDeviceElements()).ProgressTop != null)
            {
                return true;
            }

            return false;
        }
    }
}