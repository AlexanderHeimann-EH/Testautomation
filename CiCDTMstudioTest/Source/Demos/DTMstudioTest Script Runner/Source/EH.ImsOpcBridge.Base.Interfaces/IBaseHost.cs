// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseHost.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;

    using EH.ImsOpcBridge.UI;

    using Microsoft.Win32;

    /// <summary>
    /// Interface for callbacks from FDT container to the hosting application.
    /// </summary>
    public interface IBaseHost : IDisposable
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the application, which is hosting the ImsOpcBridge.
        /// </summary>
        /// <value>The name of the application.</value>
        string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the host is a service.
        /// </summary>
        /// <value><c>true</c> if this instance is service; otherwise, <c>false</c>.</value>
        bool IsService { get; set; }

        /// <summary>
        /// Gets or sets the name of the manufacturer of the application, which is hosting
        /// the ImsOpcBridge FDT module.
        /// </summary>
        /// <value>The manufacturer.</value>
        string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the progress handler.
        /// </summary>
        /// <value>The progress handler.</value>
        IProgressHandler ProgressHandler { get; set; }

        /// <summary>
        /// Gets or sets the service reference. Set this reference, when the host is a windows service.
        /// </summary>
        /// <value>The service reference.</value>
        IService Service { get; set; }

        /// <summary>
        /// Gets or sets the task handler.
        /// </summary>
        /// <value>The task handler.</value>
        ITaskHandler TaskHandler { get; set; }

        /// <summary>
        /// Gets or sets the handler for user interface callbacks to the hosting application.
        /// </summary>
        /// <value>The handler for user interface callbacks to the hosting application.</value>
        IUIHost UserInterface { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates a registry monitor.
        /// </summary>
        /// <param name="registryHive">The registry Hive.</param>
        /// <param name="subkey">The sub key.</param>
        /// <returns>The registry monitor.</returns>
        IRegistryMonitor CreateRegistryMonitor(RegistryHive registryHive, string subkey);

        #endregion
    }
}
