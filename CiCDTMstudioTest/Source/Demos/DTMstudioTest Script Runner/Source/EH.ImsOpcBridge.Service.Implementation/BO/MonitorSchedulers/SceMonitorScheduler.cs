// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SceMonitorScheduler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the SupplyCare Enterprise monitor scheduler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.BO.MonitorSchedulers
{
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.BO.Monitors;
    using EH.ImsOpcBridge.Service.Implementation.Logging;

    /// <summary>
    /// Implements the SupplyCare Enterprise monitor scheduler.
    /// </summary>
    internal class SceMonitorScheduler : MonitorScheduler
    {
        #region Constants

        /// <summary>
        /// The minimal refresh rate to milliseconds.
        /// </summary>
        private const int MinimalRefreshRate = 60000;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SceMonitorScheduler"/> class.
        /// </summary>
        public SceMonitorScheduler()
            : base()
        {
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Starts the monitor.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        /// <param name="measurements">The measurements.</param>
        /// <param name="refreshRate">The requested OPC refresh rate, in milliseconds.</param>
        public override void Start(Configuration configuration, ConfiguredMeasurements measurements, int refreshRate)
        {
            // Check it again.
            if (!this.IsRunning)
            {
                Logger.Debug(this, "SupplyCare Monitor Scheduler started");

                // Do not accept meaningless refresh rate.
                if (refreshRate < MinimalRefreshRate)
                {
                    refreshRate = MinimalRefreshRate;
                }

                this.OpcMonitor = new SceMonitor(configuration, measurements, refreshRate);
                this.OpcMonitor.Initialize();
                this.OpcMonitor.StartMonitor();
            }
        }

        #endregion
    }
}
