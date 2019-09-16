//------------------------------------------------------------------------------
// <copyright file="IsFDTUploadActive.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.ReadingFromDevice.Validation
{
    using System;

    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.ReadingFromDevice.Validation;

    /// <summary>
    ///     ReadingFromDevice provides functions to use the dialog
    /// </summary>
    public class IsFdtUploadActive : MarshalByRefObject, IIsFDTUploadActive
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