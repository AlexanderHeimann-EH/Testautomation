// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEnvironment.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData
{
    /// <summary>
    /// The test environment.
    /// </summary>
    public class TestEnvironment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestEnvironment"/> class.
        /// </summary>
        public TestEnvironment()
        {
            this.Communication = new Element();
            this.HostApplication = new Element();
            this.OperatingSystem = new Element();
            this.DeviceFunction = new Element();

            this.Communication.Folder = "Communication";
            this.HostApplication.Folder = "HostApplication";
            this.OperatingSystem.Folder = "OperatingSystem";
            this.DeviceFunction.Folder = "DeviceFunction";
        }

        /// <summary>
        /// Gets or sets the communication.
        /// </summary>
        public Element Communication { get; set; }

        /// <summary>
        /// Gets or sets the host application.
        /// </summary>
        public Element HostApplication { get; set; }

        /// <summary>
        /// Gets or sets the operating system.
        /// </summary>
        public Element OperatingSystem { get; set; }

        /// <summary>
        /// Gets or sets the device functions.
        /// </summary>
        public Element DeviceFunction { get; set; }
    }
}
