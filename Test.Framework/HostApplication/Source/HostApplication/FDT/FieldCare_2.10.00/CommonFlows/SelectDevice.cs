// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Zander, Jan 
 * Date: 12.02.2014
 * Time: 16:00
 * Last: -
 * Reason: -
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.FieldCare.V21000.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.FieldCare.V21000.Functions.Dialogs.FindDevice.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V21000.Functions.MenuArea.Menubar.Execution;

    using Ranorex;

    /// <summary>
    /// Provides methods for selecting a device
    /// </summary>
    public class SelectDevice : ISelectDevice
    {
        #region Public Methods and Operators

        /// <summary>
        /// Select a specific device
        /// </summary>
        /// <param name="device">
        /// Device to select
        /// </param>
        /// <returns>
        /// true in case of success, false in case of an error
        /// </returns>
        public bool Run(string device)
        {
            if ((new OpenFindDevice()).ViaMenu())
            {
                Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opened dialog [Find Device].");
                if ((new FindDevice()).Find(device))
                {
                    Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device [" + device + "] found and selected.");
                    return true;
                }
            }

            Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unable select device.");
            return false;
        }

        #endregion
    }
}