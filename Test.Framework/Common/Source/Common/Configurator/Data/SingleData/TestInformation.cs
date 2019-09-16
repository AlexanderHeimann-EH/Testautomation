// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.Data.SingleData
{
    using System;

    using EH.PCPS.TestAutomation.Common.Annotations;

    /// <summary>
    /// The test information.
    /// </summary>
    public class TestInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestInformation"/> class.
        /// </summary>
        public TestInformation()
        {
            this.DateOfTest      = new DateTime();
            this.NameOfTester    = string.Empty;
            this.Company         = string.Empty;
            this.DeviceType      = string.Empty;
            this.DeviceId        = string.Empty;
            this.DeviceSerialNumber    = string.Empty;
            this.DeviceTypeProjectPath = string.Empty;
        }

        /// <summary>
        /// Gets or sets the date of test.
        /// </summary>
        public DateTime DateOfTest { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the name of tester.
        /// </summary>
        public string NameOfTester { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the device type.
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// Gets or sets the device id.
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the device serial number.
        /// </summary>
        public string DeviceSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the path to device type project.
        /// </summary>
        public string DeviceTypeProjectPath { [UsedImplicitly] get; set; }
    }
}
