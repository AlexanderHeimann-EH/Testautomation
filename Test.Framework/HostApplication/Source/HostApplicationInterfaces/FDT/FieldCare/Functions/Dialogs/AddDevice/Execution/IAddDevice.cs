//------------------------------------------------------------------------------
// <copyright file="IAddDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 25.11.2010
 * Time: 6:27 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.AddDevice.Execution
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAddDevice
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool Cancel();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool Confirm();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool OpenHelp();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strDeviceName"></param>
        /// <returns></returns>
        bool SelectDevice(string strDeviceName);
    }
}