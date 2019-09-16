//------------------------------------------------------------------------------
// <copyright file="IWriteToDeviceError.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Scherzinger, Matthias
 * Date: 20.04.2012
 * Time: 9:25 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.WriteToDeviceErrorMessage.Execution
{
    /// <summary>
    ///     Description of IWriteToDeviceError.
    /// </summary>
    public interface IWriteToDeviceError
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool Ok();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string ErrorMessage();
    }
}