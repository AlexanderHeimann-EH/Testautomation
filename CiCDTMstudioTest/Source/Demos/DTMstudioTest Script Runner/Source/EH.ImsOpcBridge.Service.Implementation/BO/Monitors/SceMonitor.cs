// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SceMonitor.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the OPC monitor class for the SupplyCare Enterprise requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Service.Implementation.BO.Monitors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using EH.ImsOpcBridge.DataContracts;

    using OpcLabs.EasyOpc.DataAccess;

    using References = System.Collections.Generic.List<Data.MonitoredItemReference>;

    /// <summary>
    /// Implements the OPC monitor class for the SupplyCare Enterprise requests.
    /// </summary>
    internal class SceMonitor : OpcMonitor
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SceMonitor"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        /// <param name="configuredMeasurements">The configured measurements.</param>
        /// <param name="opcRefreshRate">The OPC refresh rate in milliseconds.</param>
        public SceMonitor(Configuration configuration, ConfiguredMeasurements configuredMeasurements, int opcRefreshRate)
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
            // The configured measurements for SupplyCare Enterprise must be cloned from the official collection.
            // Only active measurements must be considered here.
            var configuredMeasurements = new ConfiguredMeasurements();
            configuredMeasurements.AddRange(from configuredMeasurement in this.ConfiguredMeasurements where configuredMeasurement.Active select new ConfiguredMeasurement(configuredMeasurement));

            // The member variable must contain only the supported measurements.
            this.ConfiguredMeasurements = configuredMeasurements;
        }

        /// <summary>
        /// Formats the opc value.
        /// </summary>
        /// <param name="opcValue">The opc value.</param>
        /// <returns>The formatted value.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public override string FormatOpcValue(DAVtq opcValue)
        {
            return this.DisplayValue(opcValue);
        }

        /// <summary>
        /// Formats the opc quality.
        /// </summary>
        /// <param name="opcValue">The opc value.</param>
        /// <returns>The formatted quality.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public override string FormatOpcQuality(DAVtq opcValue)
        {
            if (opcValue != null)
            {
                return opcValue.Quality.ToString();
            }

            return InvalidValue;
        }

        /// <summary>
        /// Formats the opc timestamp.
        /// </summary>
        /// <param name="opcValue">The opc value.</param>
        /// <returns>The formatted timestamp.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public override string FormatOpcTimestamp(DAVtq opcValue)
        {
            if (opcValue != null)
            {
                return this.FormatTimestamp(opcValue.Timestamp);
            }

            return InvalidValue;
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
                // Items to SupplyCare Enterprise require additional checks.
                var runtimeMeasurement = this.RuntimeMeasurements[index];
                good = !string.IsNullOrEmpty(runtimeMeasurement.Value)
                       && !string.IsNullOrEmpty(runtimeMeasurement.Timestamp);
            }

            // The reference list for SupplyCare Enterprise is not incremental like the monitor view list.
            // Therefore an item must be added or removed depending on its validity.
            if (good)
            {
                // Adds the reference to the collection of items ready to send.
                this.RuntimeMeasurementToSendReferences.Add(index);
            }
            else
            {
                // Removes the reference to the collection of items ready to send.
                this.RuntimeMeasurementToSendReferences.Remove(index);
            }
        }

        /// <summary>
        /// Checks whether references after a send operation must be cleared.
        /// </summary>
        /// <returns><c>true</c> if references must be cleared, <c>false</c> otherwise.</returns>
        public override bool MustClearReferences()
        {
            return false;
        }

        #endregion
    }
}