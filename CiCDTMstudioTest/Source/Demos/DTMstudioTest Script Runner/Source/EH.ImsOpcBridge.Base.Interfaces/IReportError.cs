// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReportError.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interface which is used to report an error.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;

    /// <summary>
    /// Interface which is used to report an error.
    /// </summary>
    public interface IReportError
    {
        #region Public Methods

        /// <summary>
        /// Reports a new scan identification error
        /// </summary>
        /// <param name="description">Description of the error occurred during scanning of the device.</param>
        /// <param name="ex">Exception occurred.</param>
        void ReportError(string description, Exception ex);

        /// <summary>
        /// Reports a new scan identification error
        /// </summary>
        /// <param name="description">Description of the error occurred during scanning of the device.</param>
        void ReportError(string description);

        #endregion
    }
}
