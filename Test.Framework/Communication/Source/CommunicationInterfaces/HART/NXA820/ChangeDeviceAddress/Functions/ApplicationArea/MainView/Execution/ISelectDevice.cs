//------------------------------------------------------------------------------
// <copyright file="ISelectDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDeviceAddress.Functions.ApplicationArea.MainView.Execution
{
    /// <summary>
    /// The SelectDevice interface.
    /// </summary>
    public interface ISelectDevice
    {
        /// <summary>
        /// Selects a device from the list according to its tag
        /// </summary>
        /// <param name="deviceTag">
        /// Tag of the device which will be selected
        /// </param>
        /// <returns>
        /// True: if the device is found and selected
        /// False: if an error occurred or the device is not found
        /// </returns>
        bool Run(string deviceTag);
    }
}