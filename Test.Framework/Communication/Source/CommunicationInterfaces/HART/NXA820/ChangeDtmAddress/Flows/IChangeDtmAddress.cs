// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IChangeDtmAddress.cs" company="Endress+Hauser">
//   Endress+Hauser
// </copyright>
// <summary>
//   Defines the IChangeDtmAddress type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDtmAddress.Flows
{
    /// <summary>
    /// The ChangeDtmAddress interface.
    /// </summary>
    public interface IChangeDtmAddress
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