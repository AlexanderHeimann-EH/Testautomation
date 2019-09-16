// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuntimeMeasurementData.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The event log.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Model
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Class RuntimeMeasurementData
    /// </summary>
    public class RuntimeMeasurementData : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The data type property
        /// </summary>
        public static readonly DependencyProperty DataTypeProperty = DependencyProperty.Register("DataType", typeof(string), typeof(RuntimeMeasurementData), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The device id property
        /// </summary>
        public static readonly DependencyProperty DeviceIdProperty = DependencyProperty.Register("DeviceId", typeof(string), typeof(RuntimeMeasurementData), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The quality property
        /// </summary>
        public static readonly DependencyProperty QualityProperty = DependencyProperty.Register("Quality", typeof(string), typeof(RuntimeMeasurementData), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The sensor id property
        /// </summary>
        public static readonly DependencyProperty SensorIdProperty = DependencyProperty.Register("SensorId", typeof(string), typeof(RuntimeMeasurementData), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The timestamp property
        /// </summary>
        public static readonly DependencyProperty TimestampProperty = DependencyProperty.Register("Timestamp", typeof(string), typeof(RuntimeMeasurementData), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The unit property
        /// </summary>
        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register("Unit", typeof(string), typeof(RuntimeMeasurementData), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The value property
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(RuntimeMeasurementData), new PropertyMetadata(string.Empty));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeMeasurementData"/> class.
        /// </summary>
        /// <param name="runtimeMeasurement">The runtime measurement.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public RuntimeMeasurementData(RuntimeMeasurement runtimeMeasurement)
        {
            this.DataType = runtimeMeasurement.DataType;
            this.DeviceId = runtimeMeasurement.DeviceId;
            this.Quality = runtimeMeasurement.Quality;
            this.SensorId = runtimeMeasurement.SensorId;
            this.Unit = runtimeMeasurement.Unit;
            this.Timestamp = runtimeMeasurement.Timestamp;
            this.Value = runtimeMeasurement.Value;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>The type of the data.</value>
        public string DataType
        {
            get
            {
                return (string)this.GetValue(DataTypeProperty);
            }

            set
            {
                this.SetValue(DataTypeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the device id.
        /// </summary>
        /// <value>The device id.</value>
        public string DeviceId
        {
            get
            {
                return (string)this.GetValue(DeviceIdProperty);
            }

            set
            {
                this.SetValue(DeviceIdProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the quality.
        /// </summary>
        /// <value>The quality.</value>
        public string Quality
        {
            get
            {
                return (string)this.GetValue(QualityProperty);
            }

            set
            {
                this.SetValue(QualityProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the sensor id.
        /// </summary>
        /// <value>The sensor id.</value>
        public string SensorId
        {
            get
            {
                return (string)this.GetValue(SensorIdProperty);
            }

            set
            {
                this.SetValue(SensorIdProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public string Timestamp
        {
            get
            {
                return (string)this.GetValue(TimestampProperty);
            }

            set
            {
                this.SetValue(TimestampProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public string Unit
        {
            get
            {
                return (string)this.GetValue(UnitProperty);
            }

            set
            {
                this.SetValue(UnitProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value
        {
            get
            {
                return (string)this.GetValue(ValueProperty);
            }

            set
            {
                this.SetValue(ValueProperty, value);
            }
        }

        #endregion
    }
}