// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IService.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface to control the service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;

    /// <summary>
    /// Interface to control the service.
    /// </summary>
    public interface IService
    {
        #region Public Properties

        /// <summary>
        /// Gets the service handle.
        /// </summary>
        IntPtr ServiceHandle { get; }

        /// <summary>
        /// Gets the name of the service.
        /// </summary>
        string ServiceName { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Shuts the service down.
        /// </summary>
        void Shutdown();

        #endregion
    }
}
