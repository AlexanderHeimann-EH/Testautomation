// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewMonitorScheduler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the view monitor scheduler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.BO.MonitorSchedulers
{
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.BO.Monitors;
    using EH.ImsOpcBridge.Service.Implementation.Logging;

    /// <summary>
    /// Implements the view monitor scheduler.
    /// </summary>
    internal class ViewMonitorScheduler : MonitorScheduler
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewMonitorScheduler"/> class.
        /// </summary>
        public ViewMonitorScheduler()
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
                Logger.Debug(this, "View Monitor Scheduler started");

                this.OpcMonitor = new ViewMonitor(configuration, measurements, refreshRate);
                this.OpcMonitor.Initialize();
                this.OpcMonitor.StartMonitor();
            }
        }

        #endregion
    }
}
