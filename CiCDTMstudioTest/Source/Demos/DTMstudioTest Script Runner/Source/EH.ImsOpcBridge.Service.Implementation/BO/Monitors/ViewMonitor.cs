// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewMonitor.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the OPC monitor class for the runtime view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Service.Implementation.BO.Monitors
{
    using EH.ImsOpcBridge.DataContracts;

    using OpcLabs.EasyOpc.DataAccess;

    using References = System.Collections.Generic.List<Data.MonitoredItemReference>;

    /// <summary>
    /// Implements the OPC monitor class for the runtime view.
    /// </summary>
    internal class ViewMonitor : OpcMonitor
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewMonitor"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        /// <param name="configuredMeasurements">The configured measurements.</param>
        /// <param name="opcRefreshRate">The OPC refresh rate in milliseconds.</param>
        public ViewMonitor(Configuration configuration, ConfiguredMeasurements configuredMeasurements, int opcRefreshRate)
            : base(configuration, configuredMeasurements, opcRefreshRate)
        {
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Creates the configured measurements.
        /// </summary>
        public override void CreateConfiguredMeasurements()
        {
            // The configured measurements for this use case are already a copy and must be all considered.
            // For this reason there is nothing to do here.
            // Comments left for explanatory purposes only.

            // Modification 29.08.2014: it has been decided that also for view monitor only active items must be considered...
            for (var i = 0; i < this.ConfiguredMeasurements.Count; i++)
            {
                if (!this.ConfiguredMeasurements[i].Active)
                {
                    this.ConfiguredMeasurements.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// Formats the opc value.
        /// </summary>
        /// <param name="opcValue">The opc value.</param>
        /// <returns>The formatted value.</returns>
        public override string FormatOpcValue(DAVtq opcValue)
        {
            return this.DisplayValue(opcValue);
        }

        /// <summary>
        /// Formats the opc quality.
        /// </summary>
        /// <param name="opcValue">The opc value.</param>
        /// <returns>The formatted quality.</returns>
        public override string FormatOpcQuality(DAVtq opcValue)
        {
            return opcValue.Quality.ToString();
        }

        /// <summary>
        /// Formats the opc timestamp.
        /// </summary>
        /// <param name="opcValue">The opc value.</param>
        /// <returns>The formatted timestamp.</returns>
        public override string FormatOpcTimestamp(DAVtq opcValue)
        {
            return this.FormatTimestamp(opcValue.Timestamp);
        }

        /// <summary>
        /// Processes a value change in a record.
        /// </summary>
        /// <param name="index">The monitored item index.</param>
        public override void ProcessValueChange(int index)
        {
            var good = false;

            // Checks record validity.
            if (this.OpcValid(index))
            {
                // Items to View Monitor require the same validation like items to SupplyCare Enterprise.
                // This has been decided after a CCB on the 28.08.2014.
                var runtimeMeasurement = this.RuntimeMeasurements[index];
                good = !string.IsNullOrEmpty(runtimeMeasurement.Value)
                       && !string.IsNullOrEmpty(runtimeMeasurement.Timestamp);
            }

            if (good)
            {
                // Adds the reference to the collection of items ready to send.
                this.RuntimeMeasurementToSendReferences.Add(index);
            }
        }

        /// <summary>
        /// Checks whether references after a send operation must be cleared.
        /// </summary>
        /// <returns><c>true</c> if references must be cleared, <c>false</c> otherwise.</returns>
        public override bool MustClearReferences()
        {
            return true;
        }

        #endregion
    }
}