//------------------------------------------------------------------------------
// <copyright file="IsSavingActive.cs" company="Endress+Hauser Process Solutions AG">
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

namespace FieldCare_2._09._01.Functions.Dialogs.SaveProjectState.Validation
{
    using System;

    using HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.SaveProjectState.Validation;

    /// <summary>
    ///     ReadingFromDevice provides functions to use the dialog
    /// </summary>
    public class IsSavingActive : IIsSavingActive
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
            throw new NotImplementedException();
        }
    }
}