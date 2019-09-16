// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRegistryMonitor.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface of the registry monitor
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.IO;

    /// <summary>
    /// Interface of the registry monitor
    /// </summary>
    public interface IRegistryMonitor : IDisposable
    {
        #region Public Events

        /// <summary>
        /// Occurs when the access to the registry fails.
        /// </summary>
        event ErrorEventHandler ReportError;

        /// <summary>
        /// Occurs when the specified registry key has changed.
        /// </summary>
        event EventHandler RegChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether IsMonitoring.
        /// </summary>
        bool IsMonitoring { get; }

        /// <summary>
        /// Gets or sets the <see cref="RegChangeNotifyFilter"/>.
        /// </summary>
        /// <value>The registry change notify filter.</value>
        RegChangeNotifyFilter RegChangeNotifyFilter { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Starts monitoring.
        /// </summary>
        void StartMonitoring();

        /// <summary>
        /// Stops the monitoring thread.
        /// </summary>
        void StopMonitoring();

        #endregion
    }
}
