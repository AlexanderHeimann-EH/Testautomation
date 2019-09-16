// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfiguredMeasurementItemData.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The event log.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Model
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;

    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.Configurator.ViewModel;
    using EH.ImsOpcBridge.DataContracts;

    /// <summary>
    /// Enum MeasurementItemTypes
    /// </summary>
    public enum MeasurementItemTypes : int
    {
        /// <summary>
        /// The device id
        /// </summary>
        DeviceId = 0,

        /// <summary>
        /// The sensor id
        /// </summary>
        SensorId = 1,

        /// <summary>
        /// The unit
        /// </summary>
        Unit = 2,

        /// <summary>
        /// The data type
        /// </summary>
        DataType = 3,

        /// <summary>
        /// The time stamp
        /// </summary>
        TimeStamp = 4,

        /// <summary>
        /// The quality
        /// </summary>
        Quality = 5,

        /// <summary>
        /// The value
        /// </summary>
        Value = 6,

        /// <summary>
        /// The active
        /// </summary>
        Active = 7, 
    }

    /// <summary>
    /// Class ConfiguredMeasurementItemData
    /// </summary>
    public class ConfiguredMeasurementItemData : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The data types property
        /// </summary>
        public static readonly DependencyProperty DataTypesProperty = DependencyProperty.Register("DataTypes", typeof(ObservableCollection<string>), typeof(MappingControlVm), new PropertyMetadata(default(ObservableCollection<string>)));

        /// <summary>
        /// The field property
        /// </summary>
        public static readonly DependencyProperty FieldProperty = DependencyProperty.Register("Field", typeof(string), typeof(ConfiguredMeasurementItemData), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The is mapping mode combo box visible property
        /// </summary>
        public static readonly DependencyProperty IsMappingModeComboBoxVisibleProperty = DependencyProperty.Register("IsMappingModeComboBoxVisible", typeof(Visibility), typeof(ConfiguredMeasurementItemData), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The is mapping mode text box visible property
        /// </summary>
        public static readonly DependencyProperty IsMappingModeTextBoxVisibleProperty = DependencyProperty.Register("IsMappingModeTextBoxVisible", typeof(Visibility), typeof(ConfiguredMeasurementItemData), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The is read only property
        /// </summary>
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(ConfiguredMeasurementItemData), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The is read only property
        /// </summary>
        public static readonly DependencyProperty AllowDropProperty = DependencyProperty.Register("AllowDrop", typeof(bool), typeof(ConfiguredMeasurementItemData), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The is value combo box visible property
        /// </summary>
        public static readonly DependencyProperty IsValueComboBoxVisibleProperty = DependencyProperty.Register("IsValueComboBoxVisible", typeof(Visibility), typeof(ConfiguredMeasurementItemData), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The is value text box visible property
        /// </summary>
        public static readonly DependencyProperty IsValueTextBoxVisibleProperty = DependencyProperty.Register("IsValueTextBoxVisible", typeof(Visibility), typeof(ConfiguredMeasurementItemData), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The is value text block visible property
        /// </summary>
        public static readonly DependencyProperty IsValueTextBlockVisibleProperty = DependencyProperty.Register("IsValueTextBlockVisible", typeof(Visibility), typeof(ConfiguredMeasurementItemData), new PropertyMetadata(default(Visibility)));
        
        /// <summary>
        /// The mapping mode property
        /// </summary>
        public static readonly DependencyProperty MappingModeProperty = DependencyProperty.Register("MappingMode", typeof(string), typeof(ConfiguredMeasurementItemData), new PropertyMetadata(string.Empty, OnMappingModeChanged));

        /// <summary>
        /// The mapping mode types property
        /// </summary>
        public static readonly DependencyProperty MappingModeTypesProperty = DependencyProperty.Register("MappingModeTypes", typeof(ObservableCollection<string>), typeof(MappingControlVm), new PropertyMetadata(default(ObservableCollection<string>)));

        /// <summary>
        /// The value property
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(ConfiguredMeasurementItemData), new PropertyMetadata(string.Empty, OnValueChanged));

        /// <summary>
        /// The measurement item type property
        /// </summary>
        public static readonly DependencyProperty ValueTextBoxNameProperty = DependencyProperty.Register("ValueTextBoxName", typeof(string), typeof(ConfiguredMeasurementItemData), new PropertyMetadata(default(string)));
        
        #endregion

        #region Fields

        /// <summary>
        /// The configured measurement
        /// </summary>
        private ConfiguredMeasurement configuredMeasurement;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfiguredMeasurementItemData"/> class.
        /// </summary>
        /// <param name="configuredMeasurement">The configured measurement.</param>
        /// <param name="measurementItemValue">The measurement item value.</param>
        /// <param name="measurementItemMappingMode">The measurement item mapping mode.</param>
        /// <param name="measurementItemType">Type of the measurement item.</param>
        public ConfiguredMeasurementItemData(ref ConfiguredMeasurement configuredMeasurement, string measurementItemValue, string measurementItemMappingMode, MeasurementItemTypes measurementItemType)
        {
            this.MeasurementItemType = measurementItemType;

            this.configuredMeasurement = configuredMeasurement;

            this.Value = this.MeasurementItemType == MeasurementItemTypes.DataType ? measurementItemValue.Replace(@"Type", string.Empty) : measurementItemValue;
            this.MappingMode = measurementItemMappingMode.Replace(@"Type", string.Empty);

            this.MappingModeTypes = new ObservableCollection<string>();
            this.MappingModeTypes.Clear();

            this.DataTypes = new ObservableCollection<string>();
            this.DataTypes.Clear();

            this.InitializeViewControls();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfiguredMeasurementItemData"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public ConfiguredMeasurementItemData(bool initialize)
        {
            if (initialize)
            {
                var configuredMeasurementItem = new ConfiguredMeasurementItem(true);
                this.Field = string.Empty;
                this.Value = configuredMeasurementItem.Value;
                this.MappingMode = configuredMeasurementItem.MappingType.ToString();

                this.MappingModeTypes = new ObservableCollection<string>();
                this.MappingModeTypes.Clear();

                this.DataTypes = new ObservableCollection<string>();
                this.DataTypes.Clear();
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the data types.
        /// </summary>
        /// <value>The data types.</value>
        public ObservableCollection<string> DataTypes
        {
            get
            {
                return (ObservableCollection<string>)this.GetValue(DataTypesProperty);
            }

            set
            {
                this.SetValue(DataTypesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the measurement item.
        /// </summary>
        /// <value>The type of the measurement item.</value>
        public string ValueTextBoxName
        {
            get
            {
                return (string)this.GetValue(ValueTextBoxNameProperty);
            }

            set
            {
                this.SetValue(ValueTextBoxNameProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>The field.</value>
        public string Field
        {
            get
            {
                return (string)this.GetValue(FieldProperty);
            }

            set
            {
                this.SetValue(FieldProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the is mapping mode combo box visible.
        /// </summary>
        /// <value>The is mapping mode combo box visible.</value>
        public Visibility IsMappingModeComboBoxVisible
        {
            get
            {
                return (Visibility)this.GetValue(IsMappingModeComboBoxVisibleProperty);
            }

            set
            {
                this.SetValue(IsMappingModeComboBoxVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the is mapping mode text box visible.
        /// </summary>
        /// <value>The is mapping mode text box visible.</value>
        public Visibility IsMappingModeTextBoxVisible
        {
            get
            {
                return (Visibility)this.GetValue(IsMappingModeTextBoxVisibleProperty);
            }

            set
            {
                this.SetValue(IsMappingModeTextBoxVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is read only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly
        {
            get
            {
                return (bool)this.GetValue(IsReadOnlyProperty);
            }

            set
            {
                this.SetValue(IsReadOnlyProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether allow drop.
        /// </summary>
        public bool AllowDrop
        {
            get
            {
                return (bool)this.GetValue(AllowDropProperty);
            }

            set
            {
                this.SetValue(AllowDropProperty, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the is value combo box visible.
        /// </summary>
        /// <value>The is value combo box visible.</value>
        public Visibility IsValueComboBoxVisible
        {
            get
            {
                return (Visibility)this.GetValue(IsValueComboBoxVisibleProperty);
            }

            set
            {
                this.SetValue(IsValueComboBoxVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the is value text box visible.
        /// </summary>
        /// <value>The is value text box visible.</value>
        public Visibility IsValueTextBoxVisible
        {
            get
            {
                return (Visibility)this.GetValue(IsValueTextBoxVisibleProperty);
            }

            set
            {
                this.SetValue(IsValueTextBoxVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the is value text block visible.
        /// </summary>
        /// <value>The is value text block visible.</value>
        public Visibility IsValueTextBlockVisible
        {
            get
            {
                return (Visibility)this.GetValue(IsValueTextBlockVisibleProperty);
            }

            set
            {
                this.SetValue(IsValueTextBlockVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the mapping mode.
        /// </summary>
        /// <value>The mapping mode.</value>
        public string MappingMode
        {
            get
            {
                return (string)this.GetValue(MappingModeProperty);
            }

            set
            {
                this.SetValue(MappingModeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the mapping mode types.
        /// </summary>
        /// <value>The mapping mode types.</value>
        public ObservableCollection<string> MappingModeTypes
        {
            get
            {
                return (ObservableCollection<string>)this.GetValue(MappingModeTypesProperty);
            }

            set
            {
                this.SetValue(MappingModeTypesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the measurement item.
        /// </summary>
        /// <value>The type of the measurement item.</value>
        public MeasurementItemTypes MeasurementItemType { get; set; }

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

        #region Methods

        /// <summary>
        /// Called when [mapping mode changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnMappingModeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var configuredMeasurementItemData = sender as ConfiguredMeasurementItemData;
            if (configuredMeasurementItemData != null && configuredMeasurementItemData.configuredMeasurement != null)
            {
                switch (configuredMeasurementItemData.MeasurementItemType)
                {
                    case MeasurementItemTypes.Unit:
                        configuredMeasurementItemData.configuredMeasurement.Unit.MappingType = configuredMeasurementItemData.GetMappingMode(configuredMeasurementItemData.MappingMode + @"Type");
                        break;
                    case MeasurementItemTypes.TimeStamp:
                        configuredMeasurementItemData.configuredMeasurement.Timestamp.MappingType = configuredMeasurementItemData.GetMappingMode(configuredMeasurementItemData.MappingMode + @"Type");
                        break;
                    case MeasurementItemTypes.Quality:
                        configuredMeasurementItemData.configuredMeasurement.Quality.MappingType = configuredMeasurementItemData.GetMappingMode(configuredMeasurementItemData.MappingMode + @"Type");
                        break;
                    case MeasurementItemTypes.Value:
                        configuredMeasurementItemData.configuredMeasurement.Value.MappingType = configuredMeasurementItemData.GetMappingMode(configuredMeasurementItemData.MappingMode + @"Type");
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Called when [value changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var configuredMeasurementItemData = sender as ConfiguredMeasurementItemData;
            if (configuredMeasurementItemData != null && configuredMeasurementItemData.configuredMeasurement != null)
            {
                switch (configuredMeasurementItemData.MeasurementItemType)
                {
                    case MeasurementItemTypes.SensorId:
                        configuredMeasurementItemData.configuredMeasurement.SensorId.Value = configuredMeasurementItemData.Value;
                        break;
                    case MeasurementItemTypes.DeviceId:
                        configuredMeasurementItemData.configuredMeasurement.DeviceId.Value = configuredMeasurementItemData.Value;
                        break;
                    case MeasurementItemTypes.Unit:
                        configuredMeasurementItemData.configuredMeasurement.Unit.Value = configuredMeasurementItemData.Value;
                        break;
                    case MeasurementItemTypes.DataType:
                        configuredMeasurementItemData.configuredMeasurement.DataType = configuredMeasurementItemData.GetDataType(configuredMeasurementItemData.Value + @"Type");
                        break;
                    case MeasurementItemTypes.TimeStamp:
                        configuredMeasurementItemData.configuredMeasurement.Timestamp.Value = configuredMeasurementItemData.Value;
                        break;
                    case MeasurementItemTypes.Quality:
                        configuredMeasurementItemData.configuredMeasurement.Quality.Value = configuredMeasurementItemData.Value;
                        break;
                    case MeasurementItemTypes.Value:
                        configuredMeasurementItemData.configuredMeasurement.Value.Value = configuredMeasurementItemData.Value;
                        break;
                    case MeasurementItemTypes.Active:
                        configuredMeasurementItemData.configuredMeasurement.Active = configuredMeasurementItemData.Value == Resources.Active;
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Gets the type of the data.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <returns>Returns CommonFormatDataTypes.</returns>
        private CommonFormatDataTypes GetDataType(string dataType)
        {
            var dataTypeRetVal = CommonFormatDataTypes.FloatType;
            Enum.TryParse(dataType, out dataTypeRetVal);
            return dataTypeRetVal;
        }

        /// <summary>
        /// Gets the mapping mode.
        /// </summary>
        /// <param name="mappingMode">The mapping mode.</param>
        /// <returns>Returns MappingTypes.</returns>
        private MappingTypes GetMappingMode(string mappingMode)
        {
            var mappingModeRetVal = MappingTypes.StaticType;
            Enum.TryParse(mappingMode, out mappingModeRetVal);
            return mappingModeRetVal;
        }

        /// <summary>
        /// Initializes the combo text boxes.
        /// </summary>
        private void InitializeComboTextBoxes()
        {
            if (this.MeasurementItemType == MeasurementItemTypes.DataType || this.MeasurementItemType == MeasurementItemTypes.Active || this.MeasurementItemType == MeasurementItemTypes.DeviceId || this.MeasurementItemType == MeasurementItemTypes.SensorId)
            {
                this.IsMappingModeComboBoxVisible = Visibility.Hidden;
                this.IsMappingModeTextBoxVisible = Visibility.Visible;
            }
            else
            {
                var names = Enum.GetNames(typeof(MappingTypes));

                foreach (var enumName in names)
                {
                    var dataType = enumName.Replace(@"Type", string.Empty);
                    this.MappingModeTypes.Add(dataType);
                }

                this.IsMappingModeComboBoxVisible = Visibility.Visible;
                this.IsMappingModeTextBoxVisible = Visibility.Hidden;
            }

            if (this.MeasurementItemType == MeasurementItemTypes.DataType)
            {
                var names = Enum.GetNames(typeof(CommonFormatDataTypes));

                foreach (var enumName in names)
                {
                    var dataType = enumName.Replace(@"Type", string.Empty);
                    this.DataTypes.Add(dataType);
                }

                this.IsValueTextBoxVisible = Visibility.Hidden;
                this.IsValueComboBoxVisible = Visibility.Visible;
            }
            else
            {
                // Item with TextBox
                this.IsValueTextBoxVisible = Visibility.Visible;
                this.IsValueComboBoxVisible = Visibility.Hidden;
            }

            if (this.MeasurementItemType == MeasurementItemTypes.DeviceId || this.MeasurementItemType == MeasurementItemTypes.SensorId || this.MeasurementItemType == MeasurementItemTypes.Active || this.MeasurementItemType == MeasurementItemTypes.DataType)
            {
                this.IsValueTextBlockVisible = Visibility.Visible;
                this.IsValueTextBoxVisible = Visibility.Hidden;
                this.IsReadOnly = true;
            }
            else
            {
                this.IsValueTextBlockVisible = Visibility.Hidden;
                this.IsValueTextBoxVisible = Visibility.Visible;
                this.IsReadOnly = false;
            }

            if (this.MeasurementItemType == MeasurementItemTypes.Unit || this.MeasurementItemType == MeasurementItemTypes.Quality || this.MeasurementItemType == MeasurementItemTypes.TimeStamp || this.MeasurementItemType == MeasurementItemTypes.Value)
            {
                this.AllowDrop = true;
            }
            else
            {
                this.AllowDrop = false;
            }

            this.ValueTextBoxName = this.MeasurementItemType.ToString();
        }

        /// <summary>
        /// Initializes the view controls.
        /// </summary>
        private void InitializeViewControls()
        {
            this.SetMeasurementItemsLabel();
            this.InitializeComboTextBoxes();
        }

        /// <summary>
        /// Sets the measurement items label.
        /// </summary>
        private void SetMeasurementItemsLabel()
        {
            switch (this.MeasurementItemType)
            {
                case MeasurementItemTypes.SensorId:
                    this.Field = Resources.SensorId;
                    break;
                case MeasurementItemTypes.DeviceId:
                    this.Field = Resources.DeviceId;
                    break;
                case MeasurementItemTypes.Unit:
                    this.Field = Resources.Unit;
                    break;
                case MeasurementItemTypes.DataType:
                    this.Field = Resources.DataType;
                    break;
                case MeasurementItemTypes.TimeStamp:
                    this.Field = Resources.TimeStamp;
                    break;
                case MeasurementItemTypes.Quality:
                    this.Field = Resources.Quality;
                    break;
                case MeasurementItemTypes.Value:
                    this.Field = Resources.Value;
                    break;
                case MeasurementItemTypes.Active:
                    this.Field = Resources.Activation;
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}