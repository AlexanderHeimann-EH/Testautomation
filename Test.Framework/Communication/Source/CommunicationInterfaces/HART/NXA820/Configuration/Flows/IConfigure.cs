// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigure.cs" company="Process Solutions">
//  Endress+Hauser 
// </copyright>
// <summary>
//   Defines the IConfigure type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.Configuration.Flows
{
    /// <summary>
    /// The Configure interface.
    /// </summary>
    public interface IConfigure
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="ip">
        /// The IP.
        /// </param>
        /// <param name="port">
        /// The port.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="tankId">
        /// The tank id.
        /// </param>
        /// <param name="startAddress">
        /// The start address.
        /// </param>
        /// <param name="endAddress">
        /// The end address.
        /// </param>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Run(
            string ip,
            string port,
            string password,
            string tankId,
            string startAddress,
            string endAddress,
            string timeout);
    }
}