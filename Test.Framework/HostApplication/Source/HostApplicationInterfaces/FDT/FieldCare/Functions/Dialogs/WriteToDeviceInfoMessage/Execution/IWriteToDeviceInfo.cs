//------------------------------------------------------------------------------
// <copyright file="IWriteToDeviceInfo.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 20.04.2012
 * Time: 9:25 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.WriteToDeviceInfoMessage.Execution
{
    /// <summary>
    ///     Description of IWriteToDeviceInfo.
    /// </summary>
    public interface IWriteToDeviceInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool Yes();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool No();
    }
}