// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpcMonitor.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the OPC monitor class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Service.Implementation.BO
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using EH.ImsOpcBridge.Common.Queue;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.Data;
    using EH.ImsOpcBridge.Service.Implementation.Documents;
    using EH.ImsOpcBridge.Service.Implementation.Enumerations;
    using EH.ImsOpcBridge.Service.Implementation.Logging;

    using OpcLabs.EasyOpc.DataAccess;

    using References = System.Collections.Generic.List<Data.MonitoredItemReference>;

    /// <summary>
    /// Implements the OPC monitor class.
    /// </summary>
    internal class OpcMonitor
    {
        #region Constants

        /// <summary>
        /// The initial invalid OPC value. This value shall not be sent to client.
        /// It gives semantics about the validity of a value.
        /// </summary>
        protected const string InvalidValue = "{23E980DC-5000-42E3-9E07-AF32CF3BFF63}";

        /// <summary>
        /// The timestamp format.
        /// </summary>
        private const string TimestampFormat = "yyyyMMdd-HHmmss";

        /// <summary>
        /// The invalid value description to send to the client if OPC goes wrong.
        /// </summary>
        private const string DisplayInvalidValue = "Invalid value";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpcMonitor"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        /// <param name="configuredMeasurements">The configured measurements.</param>
        /// <param name="opcRefreshRate">The OPC refresh rate in milliseconds.</param>
        protected OpcMonitor(Configuration configuration, ConfiguredMeasurements configuredMeasurements, int opcRefreshRate)
        {
            this.Configuration = configuration;
            this.ConfiguredMeasurements = configuredMeasurements;
            this.OpcRefreshRate = opcRefreshRate;
            this.CultureInfo = new CultureInfo("en-US");
        }

        #endregion

        #region Protected Properties

        /// <summary>
        /// Gets or sets the current configuration.
        /// </summary>
        /// <value>The current configuration.</value>
        protected Configuration Configuration { get; set; }

        /// <summary>
        /// Gets or sets the configured measurements.
        /// </summary>
        /// <value>The configured measurements.</value>
        protected ConfiguredMeasurements ConfiguredMeasurements { get; set; }

        /// <summary>
        /// Gets or sets the runtime measurements.
        /// </summary>
        /// <value>The runtime measurements.</value>
        protected RuntimeMeasurements RuntimeMeasurements { get; set; }

        /// <summary>
        /// Gets or sets the runtime measurement to send references.
        /// </summary>
        /// <value>The runtime measurement to send references.</value>
        protected HashSet<int> RuntimeMeasurementToSendReferences { get; set; }

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets or sets the culture info.
        /// </summary>
        private CultureInfo CultureInfo { get; set; }

        /// <summary>
        /// Gets or sets the opc client.
        /// </summary>
        private EasyDAClient OpcClient { get; set; }

        /// <summary>
        /// Gets or sets the handles.
        /// </summary>
        private int[] Handles { get; set; }

        /// <summary>
        /// Gets or sets the monitored items.
        /// </summary>
        private MonitoredItems MonitoredItems { get; set; }

        /// <summary>
        /// Gets or sets the OPC refresh rate for the subscription.
        /// </summary>
        private int OpcRefreshRate { get; set; }

        #endregion

        #region Static Methods

        /// <summary>
        /// Determines whether the gateway is valid.
        /// </summary>
        /// <param name="gateway">The gateway.</param>
        /// <returns><c>true</c> if the gateway is valid; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// This method is marked static because it is called from another class. For this reason the gateway comes as parameter,
        /// although the current configuration is already aggregated in this instance.
        /// </remarks>
        public static bool IsGatewayValid(Gateway gateway)
        {
            var invalid = true;

            if (gateway != null)
            {
                // Check at least that model and serial number are not empty.
                invalid = string.IsNullOrEmpty(gateway.Model);
                invalid |= string.IsNullOrWhiteSpace(gateway.Model);
                invalid |= string.IsNullOrEmpty(gateway.SerialNumber);
                invalid |= string.IsNullOrWhiteSpace(gateway.SerialNumber);
            }

            if (invalid)
            {
                Logger.Error(typeof(OpcMonitor).Name, "Invalid gateway. Model or serial number missing.");
            }

            return !invalid;
        }

        /// <summary>
        /// Creates the opc client.
        /// </summary>
        /// <returns>An instance of the EasyDAClient class.</returns>
        public static EasyDAClient CreateOpcClient()
        {
            // Changed isolated flag to false to prevent problems while restarting OPC monitor after save configuration.
            var opcClient = new EasyDAClient { Isolated = false };

            // Bigger timeouts to allow the user browsing again in case of dynamic OPC items coming later.
            opcClient.InstanceParameters.HoldPeriods.ItemDetach = 60000;
            opcClient.InstanceParameters.HoldPeriods.ServerDetach = 60000;
            return opcClient;
        }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Creates the configured measurements.
        /// </summary>
        public virtual void CreateConfiguredMeasurements()
        {
        }

        /// <summary>
        /// Formats the opc value.
        /// </summary>
        /// <param name="opcValue">The opc value.</param>
        /// <returns>The formatted value.</returns>
        public virtual string FormatOpcValue(DAVtq opcValue)
        {
            return null;
        }

        /// <summary>
        /// Formats the opc quality.
        /// </summary>
        /// <param name="opcValue">The opc value.</param>
        /// <returns>The formatted quality.</returns>
        public virtual string FormatOpcQuality(DAVtq opcValue)
        {
            return null;
        }

        /// <summary>
        /// Formats the opc timestamp.
        /// </summary>
        /// <param name="opcValue">The opc value.</param>
        /// <returns>The formatted timestamp.</returns>
        public virtual string FormatOpcTimestamp(DAVtq opcValue)
        {
            return null;
        }

        /// <summary>
        /// Processes a value change in a record.
        /// </summary>
        /// <param name="index">The monitored item index.</param>
        public virtual void ProcessValueChange(int index)
        {
        }

        /// <summary>
        /// Checks whether references after a send operation must be cleared.
        /// </summary>
        /// <returns><c>true</c> if references must be cleared, <c>false</c> otherwise.</returns>
        public virtual bool MustClearReferences()
        {
            return true;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            // Creates the configured measurements.
            this.CreateConfiguredMeasurements();

            // Creates the references to the measurements to send.
            this.RuntimeMeasurementToSendReferences = new HashSet<int>();

            // Creates the runtime measurements, based on the configured.
            this.RuntimeMeasurements = new RuntimeMeasurements();

            // Initializes the runtime measurements.
            this.InitializeRuntimeMeasurements();

            // Creates the list of records that have only static configurations.
            // These records are always valid.
            this.InitialProcessValueChange();
        }

        /// <summary>
        /// Creates the runtime measurements to send.
        /// </summary>
        /// <param name="runtimeMeasurements">The runtime measurements.</param>
        /// <returns><c>true</c> if at least one measurement has been found, <c>false</c> otherwise.</returns>
        /// <remarks>
        /// This method is called either for the runtime view monitor or when a request from SupplyCare Enterprise comes.
        /// The method returns the list of current items to be sent to the calling client.
        /// </remarks>
        public bool CreateRuntimeMeasurementsToSend(out RuntimeMeasurements runtimeMeasurements)
        {
            runtimeMeasurements = null;
            var result = false;

            if (this.RuntimeMeasurementToSendReferences.Count > 0)
            {
                // Clone a list with the measurements that are ready to send.
                runtimeMeasurements = new RuntimeMeasurements();
                runtimeMeasurements.AddRange(
                    this.RuntimeMeasurementToSendReferences.Select(
                        index => new RuntimeMeasurement(this.RuntimeMeasurements[index])));

                if (this.MustClearReferences())
                {
                    this.RuntimeMeasurementToSendReferences.Clear();
                }

                // The measurements here have the real value, as it was received from some communication.
                // There are limitations concerning maximal size of strings.
                // These limitations are implemented here to get same results in the online view and SCE / FIS sent data.
                TrimRuntimeMeasurementsToSend(runtimeMeasurements);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Starts the monitor.
        /// </summary>
        public void StartMonitor()
        {
            // Starts the OPC monitor.
            if (this.OpcClient == null)
            {
                this.OpcClient = CreateOpcClient();
                this.MonitoredItems = new MonitoredItemCreator().Create(this.ConfiguredMeasurements, this.OpcRefreshRate);
                this.Handles = this.OpcClient.SubscribeMultipleItems(
                    this.MonitoredItems.ItemGroupArguments, this.OnMonitoredItemChanged);
            }
        }

        /// <summary>
        /// Stops the monitor.
        /// </summary>
        public void StopMonitor()
        {
            // Stops the OPC monitor.
            if (this.OpcClient != null)
            {
                this.MonitoredItems = null;
                this.OpcClient.UnsubscribeMultipleItems(this.Handles);
                this.OpcClient.Dispose();
                this.OpcClient = null;
            }

            // Clean resources.
            this.RuntimeMeasurements = null;
            this.ConfiguredMeasurements = null;
        }

        /// <summary>
        /// Occurs when a monitored item has changed.
        /// </summary>
        /// <param name="e">The event argument.</param>
        public void OnMonitoredItemChanged(EasyDAItemChangedEventArgs e)
        {
            // This event might come immediately after monitor has been stopped.
            // This must be checked before continuing.
            if (this.RuntimeMeasurements != null)
            {
                // Checks gateway validity.
                if (IsGatewayValid(this.Configuration.Gateway))
                {
                    var references = e.State as References;
                    if (references != null)
                    {
                        foreach (var reference in
                            references.Where(
                                reference => 0 <= reference.Index && reference.Index < this.RuntimeMeasurements.Count))
                        {
                            // Sets the value first.
                            this.SetOpcValue(reference, e.Vtq);

                            // Checks value validity and possibly sets reference to the values to be sent to clients.
                            this.ProcessValueChange(reference.Index);
                        }
                    }
                }
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Formats the opc value for the display. SupplyCare enterprise and FIS can deal only with English numbers, that's why
        /// the English culture is hardcoded here.
        /// </summary>
        /// <param name="opcValue">The opc value.</param>
        /// <returns>The formatted value.</returns>
        protected string DisplayValue(DAVtq opcValue)
        {
            if (opcValue != null && opcValue.Value != null)
            {
                return string.Format(this.CultureInfo, "{0}", opcValue.Value);
            }

            return InvalidValue;
        }

        /// <summary>
        /// Formats the timestamp.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System String.</returns>
        protected string FormatTimestamp(DateTime date)
        {
            return date.ToString(TimestampFormat);
        }

        /// <summary>
        /// Checks record validity.
        /// </summary>
        /// <param name="index">The monitored item index.</param>
        /// <returns><c>true</c> if the record is valid, <c>false</c> otherwise.</returns>
        protected bool OpcValid(int index)
        {
            var configuredMeasurement = this.ConfiguredMeasurements[index];
            var runtimeMeasurement = this.RuntimeMeasurements[index];

            if (IsOpcMappingType(configuredMeasurement.Quality.MappingType) && !OpcValid(runtimeMeasurement.Quality))
            {
                return false;
            }

            if (IsOpcMappingType(configuredMeasurement.Timestamp.MappingType) && !OpcValid(runtimeMeasurement.Timestamp))
            {
                return false;
            }

            if (IsOpcMappingType(configuredMeasurement.Unit.MappingType) && !OpcValid(runtimeMeasurement.Unit))
            {
                return false;
            }

            if (IsOpcMappingType(configuredMeasurement.Value.MappingType) && !OpcValid(runtimeMeasurement.Value))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Trims the runtime measurements to send. This method trims possibly some value according to the limitations specified in the Common Format Specification document.
        /// </summary>
        /// <param name="runtimeMeasurements">The runtime measurements.</param>
        private static void TrimRuntimeMeasurementsToSend(RuntimeMeasurements runtimeMeasurements)
        {
            if (runtimeMeasurements != null)
            {
                foreach (var runtimeMeasurement in runtimeMeasurements)
                {
                    // A method that takes a reference to a string would work, but ONLY if the argument is the string itself, NOT a member of a class!!! Unfortunately.
                    if (runtimeMeasurement.DataType != null && runtimeMeasurement.DataType.Length > CommonFormat.MaxCommonDataLength)
                    {
                        runtimeMeasurement.DataType = runtimeMeasurement.DataType.Substring(0, CommonFormat.MaxCommonDataLength);
                    }

                    if (runtimeMeasurement.DeviceId != null && runtimeMeasurement.DeviceId.Length > CommonFormat.MaxCommonDataLength)
                    {
                        runtimeMeasurement.DeviceId = runtimeMeasurement.DeviceId.Substring(0, CommonFormat.MaxCommonDataLength);
                    }

                    if (runtimeMeasurement.Quality != null && runtimeMeasurement.Quality.Length > CommonFormat.MaxCommonDataLength)
                    {
                        runtimeMeasurement.Quality = runtimeMeasurement.Quality.Substring(0, CommonFormat.MaxCommonDataLength);
                    }

                    if (runtimeMeasurement.SensorId != null && runtimeMeasurement.SensorId.Length > CommonFormat.MaxCommonDataLength)
                    {
                        runtimeMeasurement.SensorId = runtimeMeasurement.SensorId.Substring(0, CommonFormat.MaxCommonDataLength);
                    }

                    if (runtimeMeasurement.Timestamp != null && runtimeMeasurement.Timestamp.Length > CommonFormat.MaxCommonDataLength)
                    {
                        runtimeMeasurement.Timestamp = runtimeMeasurement.Timestamp.Substring(0, CommonFormat.MaxCommonDataLength);
                    }

                    if (runtimeMeasurement.Unit != null && runtimeMeasurement.Unit.Length > CommonFormat.MaxCommonDataLength)
                    {
                        runtimeMeasurement.Unit = runtimeMeasurement.Unit.Substring(0, CommonFormat.MaxCommonDataLength);
                    }

                    if (runtimeMeasurement.Value != null && runtimeMeasurement.Value.Length > CommonFormat.MaxValueDataLength)
                    {
                        runtimeMeasurement.Value = runtimeMeasurement.Value.Substring(0, CommonFormat.MaxValueDataLength);
                    }
                }
            }
        }

        /// <summary>
        /// Checks whether an OPC value is valid.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns><c>true</c> if the value is valid, <c>false</c> otherwise.</returns>
        private static bool OpcValid(string value)
        {
            return !InvalidValue.Equals(value);
        }

        /// <summary>
        /// Checks whether the argument represents a good value.
        /// </summary>
        /// <param name="e">The event argument.</param>
        /// <returns><c>true</c> if the value contained in the argument is good; otherwise, <c>false</c>.</returns>
        private static bool IsGood(EasyDAItemChangedEventArgs e)
        {
            return e.ErrorCode == 0 && e.Exception == null && e.Vtq != null;
        }

        /// <summary>
        /// Initializes the value. If the value comes from OPC then its initial value is invalid.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System String.</returns>
        private static string InitializeValue(ConfiguredMeasurementItem item)
        {
            return IsOpcMappingType(item.MappingType) ? InvalidValue : item.Value;
        }

        /// <summary>
        /// Initializes runtime measurement.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        /// <param name="measurement">The measurement.</param>
        private static void InitializeRuntimeMeasurement(long index, ConfiguredMeasurement item, RuntimeMeasurement measurement)
        {
            // Initializes the request index.
            measurement.RequestIndex = index;

            // Initializes the fields.
            // The device id is always a static value, the mapping is ignored here.
            measurement.DeviceId = item.DeviceId.Value;

            // The sensor id is always a static value, the mapping is ignored here.
            measurement.SensorId = item.SensorId.Value;

            // Sets the unit.
            measurement.Unit = InitializeValue(item.Unit);

            // The data type of the configured item is an enumerated value.
            measurement.DataType = new DataTypeDisplayNames()[(int)item.DataType];

            // Sets the timestamp.
            measurement.Timestamp = InitializeValue(item.Timestamp);

            // Sets the quality.
            measurement.Quality = InitializeValue(item.Quality);

            // Sets the value.
            measurement.Value = InitializeValue(item.Value);
        }

        /// <summary>
        /// Determines whether the mapping type is an OPC mapping type.
        /// </summary>
        /// <param name="mappingType">Type of the mapping.</param>
        /// <returns><c>true</c> if the mapping type is an OPC mapping type; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// This is the only point where this check is performed.
        /// If one modifies the enumeration, then he should also modify this method.
        /// </remarks>
        private static bool IsOpcMappingType(MappingTypes mappingType)
        {
            return mappingType > MappingTypes.StaticType;
        }

        /// <summary>
        /// Formats the complete value structure from OPC.
        /// </summary>
        /// <param name="mappingType">The mapping type.</param>
        /// <param name="opcValue">The opc value.</param>
        /// <returns>The formatted value</returns>
        private string FormatOpcVtq(MappingTypes mappingType, DAVtq opcValue)
        {
            // This should never happen at this point.
            var formattedValue = DisplayInvalidValue;

            // The mapping type at this point is an OPC mapping type.
            switch (mappingType)
            {
                case MappingTypes.OpcValueType:
                    formattedValue = this.FormatOpcValue(opcValue);
                    break;
                case MappingTypes.OpcTimestampType:
                    formattedValue = this.FormatOpcTimestamp(opcValue);
                    break;
                case MappingTypes.OpcQualityType:
                    formattedValue = this.FormatOpcQuality(opcValue);
                    break;
            }

            return formattedValue;
        }

        /// <summary>
        /// Sets the opc value.
        /// </summary>
        /// <param name="reference">The monitored item reference.</param>
        /// <param name="opcValue">The OPC value structure.</param>
        private void SetOpcValue(MonitoredItemReference reference, DAVtq opcValue)
        {
            switch (reference.FieldType)
            {
                case FieldTypes.Quality:
                    this.RuntimeMeasurements[reference.Index].Quality = this.FormatOpcVtq(reference.MappingType, opcValue);
                    break;
                case FieldTypes.Timestamp:
                    this.RuntimeMeasurements[reference.Index].Timestamp = this.FormatOpcVtq(reference.MappingType, opcValue);
                    break;
                case FieldTypes.Unit:
                    this.RuntimeMeasurements[reference.Index].Unit = this.FormatOpcVtq(reference.MappingType, opcValue);
                    break;
                case FieldTypes.Value:
                    this.RuntimeMeasurements[reference.Index].Value = this.FormatOpcVtq(reference.MappingType, opcValue);
                    break;
            }
        }

        /// <summary>
        /// Processes value change in all record after initialization.
        /// Records with only static configurations are sent once only at the beginning.
        /// </summary>
        private void InitialProcessValueChange()
        {
            for (int i = 0; i < this.RuntimeMeasurements.Count; i++)
            {
                this.ProcessValueChange(i);
            }
        }

        /// <summary>
        /// Initializes the runtime measurements.
        /// </summary>
        private void InitializeRuntimeMeasurements()
        {
            long index = 0;
            foreach (var item in this.ConfiguredMeasurements)
            {
                var measurement = new RuntimeMeasurement(true);

                // Sets the fields initially according to their mapping.
                InitializeRuntimeMeasurement(index, item, measurement);
                index++;

                // Adds to the list.
                this.RuntimeMeasurements.Add(measurement);
            }
        }

        #endregion

        #region Private Callbacks

        /// <summary>
        /// Occurs when a monitored item has changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        private void OnMonitoredItemChanged(object sender, EasyDAItemChangedEventArgs e)
        {
            // Sets only good values.
            if (IsGood(e))
            {
                // Create message.
                var message = new Message(null, Guid.Empty, MessageTypes.OnMonitoredItemChangedIndication, this);
                message.AddParameter(ParameterTypes.OpcDaItemChangedEventArgs, e);

                // Enqueue message.
                MessageQueue.Instance.Enqueue(message);
            }
        }

        #endregion
    }
}