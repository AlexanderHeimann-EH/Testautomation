// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuntimeMeasurementsDataEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The server data event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.EventArguments
{
    using System;
    using System.Collections.Generic;

    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Class RuntimeMeasurementsDataEventArgs
    /// </summary>
    public class RuntimeMeasurementsDataEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeMeasurementsDataEventArgs"/> class.
        /// </summary>
        /// <param name="runtimeMeasurements">The runtime measurements.</param>
        public RuntimeMeasurementsDataEventArgs(List<RuntimeMeasurement> runtimeMeasurements)
        {
            this.RuntimeMeasurements = runtimeMeasurements;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the runtime measurements.
        /// </summary>
        /// <value>The runtime measurements.</value>
        public List<RuntimeMeasurement> RuntimeMeasurements { get; set; }

        #endregion
    }
}