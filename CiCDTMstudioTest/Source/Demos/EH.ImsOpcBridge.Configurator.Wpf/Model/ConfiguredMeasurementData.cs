// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfiguredMeasurementData.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The event log.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Model
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class ConfiguredMeasurementData
    /// </summary>
    public class ConfiguredMeasurementData : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The active property
        /// </summary>
        public static readonly DependencyProperty ActiveProperty = DependencyProperty.Register("Active", typeof(string), typeof(ConfiguredMeasurementData), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The active states property
        /// </summary>
        public static readonly DependencyProperty ActiveStatesProperty = DependencyProperty.Register("ActiveStates", typeof(ObservableCollection<string>), typeof(ConfiguredMeasurementData), new PropertyMetadata(default(ObservableCollection<string>)));

        /// <summary>
        /// The device id property
        /// </summary>
        public static readonly DependencyProperty DeviceIdProperty = DependencyProperty.Register("DeviceId", typeof(string), typeof(ConfiguredMeasurementData), new PropertyMetadata(string.Empty, OnDeviceIdChanged));

        /// <summary>
        /// The sensor id property
        /// </summary>
        public static readonly DependencyProperty SensorIdProperty = DependencyProperty.Register("SensorId", typeof(string), typeof(ConfiguredMeasurementData), new PropertyMetadata(string.Empty, OnSensorIdChanged));

        #endregion

        #region Fields

        /// <summary>
        /// The set combo box selection changed
        /// </summary>
        private readonly DelegateCommand setComboBoxSelectionChanged;

        /// <summary>
        /// The configured measurement
        /// </summary>
        private ConfiguredMeasurement configuredMeasurement;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfiguredMeasurementData"/> class.
        /// </summary>
        /// <param name="configuredMeasurement">The configured measurement.</param>
        public ConfiguredMeasurementData(ref ConfiguredMeasurement configuredMeasurement)
        {
            this.configuredMeasurement = configuredMeasurement;

            this.setComboBoxSelectionChanged = new DelegateCommand(this.OnComboBoxSelectionChanged);

            this.DeviceId = configuredMeasurement.DeviceId.Value;
            this.SensorId = configuredMeasurement.SensorId.Value;

            if (configuredMeasurement.Active)
            {
                this.Active = Resources.Active;
            }
            else
            {
                this.Active = Resources.NotActive;
            }

            this.ActiveStates = new ObservableCollection<string>();
            this.ActiveStates.Clear();
            this.ActiveStates.Add(Resources.Active);
            this.ActiveStates.Add(Resources.NotActive);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>The active.</value>
        public string Active
        {
            get
            {
                return (string)this.GetValue(ActiveProperty);
            }

            set
            {
                this.SetValue(ActiveProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the active states.
        /// </summary>
        /// <value>The active states.</value>
        public ObservableCollection<string> ActiveStates
        {
            get
            {
                return (ObservableCollection<string>)this.GetValue(ActiveStatesProperty);
            }

            set
            {
                this.SetValue(ActiveStatesProperty, value);
            }
        }

        /// <summary>
        /// Gets the combo box selection changed.
        /// </summary>
        /// <value>The combo box selection changed.</value>
        public ICommand ComboBoxSelectionChanged
        {
            get
            {
                return this.setComboBoxSelectionChanged;
            }
        }

        /// <summary>
        /// Gets or sets the configured measurement.
        /// </summary>
        /// <value>The configured measurement.</value>
        public ConfiguredMeasurement ConfiguredMeasurement
        {
            get
            {
                return this.configuredMeasurement;
            }

            set
            {
                this.configuredMeasurement = value;
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

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when [combo box selection changed].
        /// </summary>
        public void OnComboBoxSelectionChanged()
        {
            if (this.Active == Resources.Active)
            {
                this.configuredMeasurement.Active = true;
            }
            else
            {
                this.configuredMeasurement.Active = false;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when [device id changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnDeviceIdChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var configuredMeasurementData = sender as ConfiguredMeasurementData;
            if (configuredMeasurementData != null && configuredMeasurementData.configuredMeasurement != null)
            {
                configuredMeasurementData.configuredMeasurement.DeviceId.Value = configuredMeasurementData.DeviceId;
            }
        }

        /// <summary>
        /// Called when [sensor id changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSensorIdChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var configuredMeasurementData = sender as ConfiguredMeasurementData;
            if (configuredMeasurementData != null && configuredMeasurementData.configuredMeasurement != null)
            {
                configuredMeasurementData.configuredMeasurement.SensorId.Value = configuredMeasurementData.SensorId;
            }
        }

        #endregion
    }
}