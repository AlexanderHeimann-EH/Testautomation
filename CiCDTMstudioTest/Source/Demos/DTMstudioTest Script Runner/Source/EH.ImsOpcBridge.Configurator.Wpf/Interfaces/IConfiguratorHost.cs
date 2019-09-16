// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfiguratorHost.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface for callbacks from FDT container to the hosting application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Interfaces
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Interface IConfiguratorHost
    /// </summary>
    [CLSCompliant(false)]
    public interface IConfiguratorHost : IBaseHost
    {
        #region Public Properties

        /// <summary>
        /// Gets all command line keys.
        /// </summary>
        /// <value>All command line keys.</value>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = @"OK here.")]
        string[] AllCommandLineKeys { get; }

        /// <summary>
        /// Gets or sets the communication retries.
        /// </summary>
        /// <value>The communication retries.</value>
        int CommunicationRetries { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        Version Version { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the command line value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System String.</returns>
        string GetCommandLineValue(string key);

        /// <summary>
        /// Sets the command line value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void SetCommandLineValue(string key, string value);

        #endregion
    }
}