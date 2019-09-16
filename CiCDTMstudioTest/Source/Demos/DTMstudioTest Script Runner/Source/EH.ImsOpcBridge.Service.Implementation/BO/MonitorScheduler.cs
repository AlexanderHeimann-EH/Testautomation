// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonitorScheduler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the generic monitor scheduler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.BO
{
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.Logging;

    /// <summary>
    /// Implements the generic monitor scheduler.
    /// </summary>
    internal abstract class MonitorScheduler
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MonitorScheduler"/> class.
        /// </summary>
        protected MonitorScheduler()
        {
            // Creates instances.
            this.OpcMonitor = null;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the monitor is running.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return this.OpcMonitor != null;
            }
        }

        #endregion

        #region Protected Properties

        /// <summary>
        /// Gets or sets the opc monitor for the runtime view.
        /// </summary>
        /// <value>The opc monitor.</value>
        protected OpcMonitor OpcMonitor { get; set; }

        #endregion

        #region Public Abstract Methods

        /// <summary>
        /// Starts the monitor.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        /// <param name="measurements">The measurements.</param>
        /// <param name="refreshRate">The requested OPC refresh rate, in milliseconds.</param>
        public abstract void Start(Configuration configuration, ConfiguredMeasurements measurements, int refreshRate);

        #endregion

        #region Public Methods

        /// <summary>
        /// Stops the monitor.
        /// </summary>
        public void Stop()
        {
            // Check it again, because this method is called also when the service stops,
            // independently on the WCF client actions.
            if (this.IsRunning)
            {
                Logger.Debug(this, "Monitor scheduler stopped.");
                this.OpcMonitor.StopMonitor();
                this.OpcMonitor = null;
            }
        }

        /// <summary>
        /// Checks whether there is data to send.
        /// </summary>
        /// <param name="runtimeMeasurements">The runtime measurements.</param>
        /// <returns><c>true</c> if there is data to send, <c>false</c> otherwise.</returns>
        public bool DataToSend(out RuntimeMeasurements runtimeMeasurements)
        {
            runtimeMeasurements = null;
            var result = false;

            // Continue only if monitoring is running.
            if (this.IsRunning)
            {
                    // Checks whether there is data to send.
                if (this.OpcMonitor.CreateRuntimeMeasurementsToSend(out runtimeMeasurements))
                {
                    result = true;
                }
            }

            return result;
        }

        #endregion
    }
}
