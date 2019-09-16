// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceFunctionMapping.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The device function mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.DeviceFunctionMapping
{
    using System;

    /// <summary>
    /// The device function mapping.
    /// </summary>
    [Serializable]
    public class DeviceFunctionMapping
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceFunctionMapping"/> class.
        /// </summary>
        public DeviceFunctionMapping()
        {
            this.DisplayName = string.Empty;
            this.TestFrameworkDeviceFunctionName = string.Empty;
            this.CoDIADeviceFunctionName = string.Empty;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the CoDIA device function.
        /// </summary>
        public string CoDIADeviceFunctionName { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the device function mapper.
        /// </summary>
        public string TestFrameworkDeviceFunctionName { get; set; }

        #endregion
    }
}