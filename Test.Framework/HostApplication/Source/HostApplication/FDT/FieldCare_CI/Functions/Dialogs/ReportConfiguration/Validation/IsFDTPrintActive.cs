//------------------------------------------------------------------------------
// <copyright file="IsFDTPrintActive.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 17.04.2012
 * Time: 9:47  
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.Functions.Dialogs.ReportConfiguration.Validation
{
    using System;

    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.ReportConfiguration.Validation;

    /// <summary>
    ///     This class describes dialog [Report Configuration] in an abstract way.
    ///     Elements could be accessed for reading or using.
    /// </summary>
    public class IsFdtPrintActive : MarshalByRefObject, IIsFDTPrintActive
    {
        /// <summary>
        ///     Check if FDT Print dialog is active
        /// </summary>
        /// <returns>
        ///     <br>True: if validation is true</br>
        ///     <br>False: if validation fails</br>
        /// </returns>
        public bool Run()
        {
            if ((new ReportConfigurationElements()).ReportType != null)
            {
                return true;
            }

            return false;
        }
    }
}