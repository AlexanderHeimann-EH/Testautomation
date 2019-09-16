// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for adding a device
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V20901.CommonFlows
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    /// <summary>
    /// Provides methods for adding a device
    /// </summary>
    public class AddDevice : IAddDevice
    {
        #region Public Methods and Operators

        /// <summary>
        /// Add a device type to network
        /// </summary>
        /// <param name="parent">
        /// node, to add device to
        /// </param>
        /// <param name="device">
        /// unique device name of device to add to parent node
        /// </param>
        /// <returns>
        /// true in case of success, false in case of an error
        /// </returns>
        public bool Run(string parent, string device)
        {
            bool result = true;

            if (parent.Contains("Host") == false)
            {
                // Select parent first
                result &= CommonFlows.SelectDevice.Run(parent);
            }

            result &= new Functions.MenuArea.Menubar.Execution.OpenAddDevice().ViaMenu();
            result &= new Functions.Dialogs.AddDevice.Execution.AddDevice().SelectDevice(device);
            result &= new Functions.Dialogs.AddDevice.Execution.AddDevice().Confirm();
            var watch = new Stopwatch();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Waiting for '" + device + "' to be added to the project.");
            watch.Start();
            while (true)
            {
                if (watch.ElapsedMilliseconds >= DefaultValues.iTimeoutDefault)
                {
                    break;
                }
            }

            watch.Stop();

            return result;
        }

        /// <summary>
        /// Add a device type to network
        /// </summary>
        /// <param name="parent">
        /// node, to add device to
        /// </param>
        /// <param name="device">
        /// unique device name of device to add to parent node
        /// </param>
        /// <param name="configurationSettings">
        /// communication settings for communication devices
        /// </param>
        /// <returns>
        /// true in case of success, false in case of an error
        /// </returns>
        public bool Run(string parent, string device, List<string> configurationSettings)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}