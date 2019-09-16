//------------------------------------------------------------------------------
// <copyright file="DisconnectDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 12.02.2014
 * Time: 16:
 * Last: 2015-01-17
 * Reason: Implementation of non implmented
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21000.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Ranorex;

    /// <summary>
    /// Provides methods for disconnecting a device
    /// </summary>
    public class DisconnectDevice : IDisconnectDevice
    {
        /// <summary>
        /// Disconnect currently selected device from HostApplication
        /// </summary>
        /// <returns>true in case of success, false in case of an error</returns>
        public bool Run()
        {
            // Check whether already disconnected
            if (HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Toolbar.Validation.IsDisconnected.Run())
            {
                Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is already disconnected.");
                return true;
            }
            else
            {
                if (HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Toolbar.Execution.RunDisconnect.ViaIcon())
                {
                    Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Icon [Disconnect] pressed.");
                    if (HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Toolbar.Validation.IsDisconnected.Run())
                    {
                        Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is offline");
                        return true;
                    }
                }    
            }            

            Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not disconnect device");
            return false;
        }
    }
}
