// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IChangeDeviceAddress.cs" company="Endress+Hauser">
//   Endress+Hauser
// </copyright>
// <summary>
//   Defines the IChangeDeviceAddress type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDeviceAddress.Flows
{
    /// <summary>
    /// The ChangeDeviceAddress interface.
    /// </summary>
    public interface IChangeDeviceAddress
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="deviceTag">
        /// The device tag.
        /// </param>
        /// <param name="deviceAddress">
        /// The device address.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Run(string deviceTag, string deviceAddress);
    }
}