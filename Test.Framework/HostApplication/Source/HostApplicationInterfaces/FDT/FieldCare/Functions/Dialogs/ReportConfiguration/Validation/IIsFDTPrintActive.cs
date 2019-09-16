//------------------------------------------------------------------------------
// <copyright file="IIsFDTPrintActive.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.ReportConfiguration.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIsFDTPrintActive
    {
        /// <summary>
        ///     Check if FDT Print dialog is active
        /// </summary>
        /// <returns>
        ///     <br>True: if validation is true</br>
        ///     <br>False: if validation fails</br>
        /// </returns>
        bool Run();
    }
}