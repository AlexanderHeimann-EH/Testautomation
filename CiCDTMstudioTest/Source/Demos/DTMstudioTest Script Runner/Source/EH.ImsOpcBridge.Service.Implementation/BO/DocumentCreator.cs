// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentCreator.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the document creator for SupplyCare Enterprise.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.BO
{
    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Implements the document creator for SupplyCare Enterprise.
    /// </summary>
    internal class DocumentCreator
    {
        #region Fields

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly Configuration configuration;

        /// <summary>
        /// The measurements.
        /// </summary>
        private readonly RuntimeMeasurements measurements;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentCreator"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        /// <param name="measurements">The input measurements.</param>
        public DocumentCreator(Configuration configuration, RuntimeMeasurements measurements)
        {
            this.configuration = configuration;
            this.measurements = measurements;
        }

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        private Configuration Configuration
        {
            get
            {
                return this.configuration;
            }
        }

        /// <summary>
        /// Gets the measurements.
        /// </summary>
        private RuntimeMeasurements Measurements
        {
            get
            {
                return this.measurements;
            }
        }

        #endregion

        #region Public Methods

        #endregion
    }
}
