// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SceDocument.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the SupplyCare Enterprise document according to the common format.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.Documents
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.BO;
    using EH.ImsOpcBridge.Service.Implementation.Diagnostics;
    using EH.ImsOpcBridge.Service.Implementation.Logging;

    using Devices = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, EH.ImsOpcBridge.DataContracts.RuntimeMeasurement>>;
    using Sensors = System.Collections.Generic.Dictionary<string, EH.ImsOpcBridge.DataContracts.RuntimeMeasurement>;

    /// <summary>
    /// Implements the SupplyCare Enterprise document according to the common format.
    /// </summary>
    internal class SceDocument : XmlDocument
    {
        #region Const

        /// <summary>
        /// The version value
        /// </summary>
        private const string Version = "1.0";

        /// <summary>
        /// The version attribute
        /// </summary>
        private const string Encoding = "UTF-8";

        #endregion

        #region Fields

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly Configuration configuration;

        /// <summary>
        /// The runtime measurements.
        /// </summary>
        private readonly RuntimeMeasurements runtimeMeasurements;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SceDocument" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="runtimeMeasurements">The runtime measurements.</param>
        public SceDocument(Configuration configuration, RuntimeMeasurements runtimeMeasurements)
        {
            this.configuration = configuration;
            this.runtimeMeasurements = runtimeMeasurements;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        private Configuration Configuration
        {
            get
            {
                return this.configuration;
            }
        }

        /// <summary>
        /// Gets the runtime measurements.
        /// </summary>
        /// <value>The runtime measurements.</value>
        private RuntimeMeasurements RuntimeMeasurements
        {
            get
            {
                return this.runtimeMeasurements;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <exception cref="System.Exception">Any exception that comes from XML handling.</exception>
        public void Create()
        {
            try
            {
                var devices = this.CreateDictionary();
                var root = this.CreateRoot();
                this.AppendChild(root);

                var gateway = this.CreateGateway();
                root.AppendChild(gateway);

                foreach (var item in devices)
                {
                    var device = this.CreateDevice(item.Key);
                    gateway.AppendChild(device);

                    foreach (var item2 in item.Value)
                    {
                        var sensor = this.CreateSensor(item2.Key);
                        device.AppendChild(sensor);

                        var measurement2 = this.CreateMeasurement(item2.Value);
                        sensor.AppendChild(measurement2);
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.FatalException(this, "Error creating SupplyCare Enterprise document.", exception);
                DiagnosticsCollection.Instance.AddMessage("Error creating SupplyCare Enterprise document.");
                DiagnosticsCollection.Instance.AddMessage(exception);
                throw;
            }
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            TextWriter writer = new Utf8StringWriter();
            var settings = new XmlWriterSettings { Encoding = new UTF8Encoding(), Indent = true };
            var xmlWriter = XmlWriter.Create(writer, settings);

            this.Save(xmlWriter);
            return writer.ToString();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the dictionary.
        /// </summary>
        /// <returns>The dictionary.</returns>
        private Devices CreateDictionary()
        {
            var devices = new Devices();

            foreach (var measurement in this.RuntimeMeasurements)
            {
                Sensors sensors;
                if (!devices.TryGetValue(measurement.DeviceId, out sensors))
                {
                    sensors = new Sensors();
                    devices.Add(measurement.DeviceId, sensors);
                }

                RuntimeMeasurement runtimeMeasurement;
                if (!sensors.TryGetValue(measurement.SensorId, out runtimeMeasurement))
                {
                    sensors.Add(measurement.SensorId, measurement);
                }
            }

            return devices;
        }

        /// <summary>
        /// Creates the root.
        /// </summary>
        /// <returns>The root element.</returns>
        private XmlElement CreateRoot()
        {
            // Create a new element and add it to the document.
            var elem = this.CreateElement(CommonFormat.FisComElementName);
            this.AddAttribute(ref elem, CommonFormat.VersionAttributeName, CommonFormat.VersionValue);

            var xmldecl = this.CreateXmlDeclaration(Version, Encoding, null);
            this.InsertBefore(xmldecl, this.DocumentElement);

            return elem;
        }

        /// <summary>
        /// Creates the gateway.
        /// </summary>
        /// <returns>The gateway element.</returns>
        /// <exception cref="System.Exception">An exception is thrown if the gateway does not have a model or a serial number.</exception>
        private XmlElement CreateGateway()
        {
            var elem = this.CreateElement(CommonFormat.GatewayElementName);

            if (!OpcMonitor.IsGatewayValid(this.Configuration.Gateway))
            {
                var exception = new Exception("Missing gateway model or serial number!");
                Logger.ErrorException(this, "Create gateway for SCE document error.", exception);
                throw exception;
            }

            this.AddAttribute(ref elem, CommonFormat.ModelAttributeName, this.Configuration.Gateway.Model);
            this.AddAttribute(ref elem, CommonFormat.IdentifierAttributeName, this.Configuration.Gateway.SerialNumber);

            return elem;
        }

        /// <summary>
        /// Creates the device.
        /// </summary>
        /// <param name="uid">The identifier.</param>
        /// <returns>The device element.</returns>
        private XmlElement CreateDevice(string uid)
        {
            var elem = this.CreateElement(CommonFormat.DeviceElementName);
            this.AddAttribute(ref elem, CommonFormat.IdentifierAttributeName, uid);

            return elem;
        }

        /// <summary>
        /// Creates the sensor.
        /// </summary>
        /// <param name="uid">The identifier.</param>
        /// <returns>The sensor element.</returns>
        private XmlElement CreateSensor(string uid)
        {
            var elem = this.CreateElement(CommonFormat.SensorElementName);
            this.AddAttribute(ref elem, CommonFormat.IdentifierAttributeName, uid);

            return elem;
        }

        /// <summary>
        /// Creates the measurement.
        /// </summary>
        /// <param name="measurement">The measurement.</param>
        /// <returns>The measurement element.</returns>
        private XmlElement CreateMeasurement(RuntimeMeasurement measurement)
        {
            var elem = this.CreateElement(CommonFormat.MeasurementElementName);
            this.AddAttribute(ref elem, CommonFormat.UnitAttributeName, measurement.Unit);
            this.AddAttribute(ref elem, CommonFormat.DataTypeAttributeName, measurement.DataType);
            this.AddAttribute(ref elem, CommonFormat.QualityAttributeName, measurement.Quality);
            this.AddAttribute(ref elem, CommonFormat.TimestampAttributeName, measurement.Timestamp);
            elem.InnerText = measurement.Value;

            return elem;
        }

        /// <summary>
        /// Creates and adds an attribute.
        /// </summary>
        /// <param name="element">The parent element.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        private void AddAttribute(ref XmlElement element, string attributeName, string value)
        {
            var attr = this.CreateAttribute(attributeName);
            attr.Value = value;
            element.Attributes.Append(attr);
        }

        #endregion
    }
}
