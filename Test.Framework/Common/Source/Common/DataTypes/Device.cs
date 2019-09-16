// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Device.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Device can hold information about a DeviceDTM
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.DataTypes
{
    /// <summary>
    /// Device can hold information about a DeviceDTM
    /// </summary>
    public class Device
    {
        #region Members

        /// <summary>
        /// The protocol parameter
        /// </summary>
        private string protocol = string.Empty;

        /// <summary>
        /// The deviceDriverName parameter
        /// </summary>
        private string deviceDriverName = string.Empty;

        /// <summary>
        /// The deviceHardwareName parameter
        /// </summary>
        private string deviceHardwareName = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        /// <param name="protocolName">The name of the protocol</param>
        /// <param name="deviceDriverName">The name of the device driver</param>
        /// <param name="deviceHardwareName">The name of the device hardware (modem)</param>
        public Device(string protocolName, string deviceDriverName, string deviceHardwareName)
        {
            this.Protocol = protocolName;
            this.DeviceDriverName = deviceDriverName;
            this.DeviceHardwareName = deviceHardwareName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the protocol parameter
        /// </summary>
        public string Protocol
        {
            get { return this.protocol; }
            set { this.protocol = value; }
        }

        /// <summary>
        /// Gets or sets the deviceDriverName parameter
        /// </summary>
        public string DeviceDriverName
        {
            get { return this.deviceDriverName; }
            set { this.deviceDriverName = value; }
        }

        /// <summary>
        /// Gets or sets the deviceHardwareName parameter
        /// </summary>
        public string DeviceHardwareName
        {
            get { return this.deviceHardwareName; }
            set { this.deviceHardwareName = value; }
        }

        #endregion
    }
}
