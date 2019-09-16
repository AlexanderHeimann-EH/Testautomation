// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceErrorDataEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The server data event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.EventArguments
{
    using System;

    /// <summary>
    /// Class ServiceErrorDataEventArgs
    /// </summary>
    public class ServiceErrorDataEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceErrorDataEventArgs"/> class.
        /// </summary>
        /// <param name="serviceErrorData">
        /// The service error data.
        /// </param>
        public ServiceErrorDataEventArgs(string serviceErrorData)
        {
            this.ServiceErrorData = serviceErrorData;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the service error data.
        /// </summary>
        /// <value>The service error data.</value>
        public string ServiceErrorData { get; set; }

        #endregion
    }
}