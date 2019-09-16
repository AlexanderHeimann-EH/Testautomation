// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 12.02.2014
 * Time: 16:
 * Last: 2015-01-17
 * Reason: Implementation of non implemented
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Ranorex;

    /// <summary>
    /// Provides methods for connecting a device
    /// </summary>
    public class ConnectDevice : IConnectDevice
    {
        /// <summary>
        /// Connect currently selected device with HostApplication
        /// </summary>
        /// <returns>true in case of success, false in case of an error</returns>
        public bool Run()
        {
            // Check whether connection is already established
            if (HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Toolbar.Validation.IsConnected.Run())
            {
                Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is already connected.");
                return true;
            }
            else
            {
                if (HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Toolbar.Execution.RunConnect.ViaIcon())
                {
                    Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Icon [Connect] pressed.");
                    if (HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Toolbar.Validation.IsConnected.Run())
                    {
                        Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is online");
                        return true;
                    }
                }
            }

            Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not connect device");
            return false;
        }
    }
}
