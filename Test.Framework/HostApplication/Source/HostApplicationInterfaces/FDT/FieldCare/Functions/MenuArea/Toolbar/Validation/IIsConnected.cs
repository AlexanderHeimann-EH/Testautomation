//------------------------------------------------------------------------------
// <copyright file="IIsConnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 13.02.2014
 * Time: 17:00 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Toolbar.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIsConnected
    {
        /// <summary>
        ///     Check if frame-device-connection is active
        /// </summary>
        /// <returns>True if connection is established, False if not</returns>
        bool Run();
    }
}