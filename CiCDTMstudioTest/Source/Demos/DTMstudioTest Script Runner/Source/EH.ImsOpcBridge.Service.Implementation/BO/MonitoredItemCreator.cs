// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonitoredItemCreator.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the monitored item creator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.BO
{
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.Data;
    using EH.ImsOpcBridge.Service.Implementation.Enumerations;

    /// <summary>
    /// Implements the monitored item creator.
    /// </summary>
    internal class MonitoredItemCreator
    {
        #region Public Methods

        /// <summary>
        /// Creates the monitored item collection.
        /// </summary>
        /// <param name="configuredMeasurements">The configured measurements.</param>
        /// <param name="opcRefreshRate">The OPC refresh rate in milliseconds.</param>
        /// <returns>
        /// The collection of monitored items. <see cref="MonitoredItems"/>.
        /// </returns>
        public MonitoredItems Create(ConfiguredMeasurements configuredMeasurements, int opcRefreshRate)
        {
            var monitoredItems = new MonitoredItems(opcRefreshRate);

            // Loop on the configured measurements.
            for (var i = 0; i < configuredMeasurements.Count; i++)
            {
                var configuredMeasurement = configuredMeasurements[i];

                ProcessProperty(
                    configuredMeasurement.Quality, i, FieldTypes.Quality, monitoredItems);
                ProcessProperty(
                    configuredMeasurement.Timestamp, i, FieldTypes.Timestamp, monitoredItems);
                ProcessProperty(
                    configuredMeasurement.Unit, i, FieldTypes.Unit, monitoredItems);
                ProcessProperty(
                    configuredMeasurement.Value, i, FieldTypes.Value, monitoredItems);
            }

            return monitoredItems;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Processes a property to see whether to add a monitored item.
        /// </summary>
        /// <param name="configuredMeasurementItem">The configured measurement item.</param>
        /// <param name="index">The index.</param>
        /// <param name="fieldType">The field Type.</param>
        /// <param name="monitoredItems">The monitored items.</param>
        private static void ProcessProperty(ConfiguredMeasurementItem configuredMeasurementItem, int index, FieldTypes fieldType, MonitoredItems monitoredItems)
        {
            // Continue only if it is a OPC mapping type.
            if (configuredMeasurementItem.MappingType > 0)
            {
                string serverClass;
                string itemId;

                if (ParseItemDescriptor(configuredMeasurementItem.Value, out serverClass, out itemId))
                {
                    monitoredItems.Add(
                        new MonitoredItemReference(index, fieldType, configuredMeasurementItem.MappingType),
                        serverClass,
                        itemId);
                }
            }
        }

        /// <summary>
        /// Parses the item descriptor to create serverClass and OPC itemId.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        /// <param name="serverClass">The server class.</param>
        /// <param name="itemId">The item id.</param>
        /// <returns><c>true</c> if the item descriptor contains valid information, <c>false</c> otherwise.</returns>
        private static bool ParseItemDescriptor(string descriptor, out string serverClass, out string itemId)
        {
            serverClass = null;
            itemId = null;
            var result = false;

            if (!string.IsNullOrEmpty(descriptor))
            {
                // The first comma is the separator. The ItemId can also contain commas.
                var index = descriptor.IndexOf(',');
                if (index > 0)
                {
                    serverClass = descriptor.Substring(0, index).Trim();
                    itemId = descriptor.Substring(index + 1, descriptor.Length - index - 1).Trim();
                    result = !(string.IsNullOrEmpty(serverClass) || string.IsNullOrEmpty(itemId));
                }
            }

            return result;
        }

        #endregion
    }
}
