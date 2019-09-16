// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonitorDataControlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class MonitorDataCtrlVm
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Threading;

    using EH.ImsOpcBridge.Configurator.EventArguments;
    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class MonitorDataControlVm
    /// </summary>
    public class MonitorDataControlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The automation id property
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The begin page command property
        /// </summary>
        public static readonly DependencyProperty BeginPageCommandProperty = DependencyProperty.Register("BeginPageCommand", typeof(DelegateCommand), typeof(MonitorDataControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The current page property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(int), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(1, OnCurrentPageChanged));

        /// <summary>
        /// The data type header property
        /// </summary>
        public static readonly DependencyProperty DataTypeHeaderProperty = DependencyProperty.Register("DataTypeHeader", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The device id header property
        /// </summary>
        public static readonly DependencyProperty DeviceIdHeaderProperty = DependencyProperty.Register("DeviceIdHeader", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The end page command property
        /// </summary>
        public static readonly DependencyProperty EndPageCommandProperty = DependencyProperty.Register("EndPageCommand", typeof(DelegateCommand), typeof(MonitorDataControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The enter filter term property
        /// </summary>
        public static readonly DependencyProperty EnterFilterTermProperty = DependencyProperty.Register("EnterFilterTerm", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The filter data type active property
        /// </summary>
        public static readonly DependencyProperty FilterDataTypeActiveProperty = DependencyProperty.Register("FilterDataTypeActive", typeof(bool), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(false, OnFilterDataTypeExpanderChanged));

        /// <summary>
        /// The filter device id active property
        /// </summary>
        public static readonly DependencyProperty FilterDeviceIdActiveProperty = DependencyProperty.Register("FilterDeviceIdActive", typeof(bool), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(false, OnFilterDeviceIdExpanderChanged));

        /// <summary>
        /// The filter header property
        /// </summary>
        public static readonly DependencyProperty FilterHeaderProperty = DependencyProperty.Register("FilterHeader", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The filter quality active property
        /// </summary>
        public static readonly DependencyProperty FilterQualityActiveProperty = DependencyProperty.Register("FilterQualityActive", typeof(bool), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(false, OnFilterQualityExpanderChanged));

        /// <summary>
        /// The filter sensor id active property
        /// </summary>
        public static readonly DependencyProperty FilterSensorIdActiveProperty = DependencyProperty.Register("FilterSensorIdActive", typeof(bool), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(false, OnFilterSensorIdExpanderChanged));

        /// <summary>
        /// The filter unit active property
        /// </summary>
        public static readonly DependencyProperty FilterUnitActiveProperty = DependencyProperty.Register("FilterUnitActive", typeof(bool), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(false, OnFilterUnitExpanderChanged));

        /// <summary>
        /// The name header property
        /// </summary>
        public static readonly DependencyProperty NameHeaderProperty = DependencyProperty.Register("NameHeader", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The next page command property
        /// </summary>
        public static readonly DependencyProperty NextPageCommandProperty = DependencyProperty.Register("NextPageCommand", typeof(DelegateCommand), typeof(MonitorDataControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The number of pages property
        /// </summary>
        public static readonly DependencyProperty NumberOfPagesProperty = DependencyProperty.Register("NumberOfPages", typeof(int), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(1, OnNumberOfPagesChanged));

        /// <summary>
        /// The pages property
        /// </summary>
        public static readonly DependencyProperty PagesProperty = DependencyProperty.Register("Pages", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The previous page command property
        /// </summary>
        public static readonly DependencyProperty PreviousPageCommandProperty = DependencyProperty.Register("PreviousPageCommand", typeof(DelegateCommand), typeof(MonitorDataControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The quality header property
        /// </summary>
        public static readonly DependencyProperty QualityHeaderProperty = DependencyProperty.Register("QualityHeader", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The runtime measurements property
        /// </summary>
        public static readonly DependencyProperty RuntimeMeasurementsProperty = DependencyProperty.Register("RuntimeMeasurements", typeof(ObservableCollection<RuntimeMeasurementData>), typeof(MonitorDataControlVm), new PropertyMetadata(default(ObservableCollection<RuntimeMeasurementData>)));

        /// <summary>
        /// The sensor id header property
        /// </summary>
        public static readonly DependencyProperty SensorIdHeaderProperty = DependencyProperty.Register("SensorIdHeader", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text filter data type property
        /// </summary>
        public static readonly DependencyProperty TextFilterDataTypeProperty = DependencyProperty.Register("TextFilterDataType", typeof(string), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(null, OnTextChanged));

        /// <summary>
        /// The text filter device id property
        /// </summary>
        public static readonly DependencyProperty TextFilterDeviceIdProperty = DependencyProperty.Register("TextFilterDeviceId", typeof(string), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(null, OnTextChanged));

        /// <summary>
        /// The text filter quality property
        /// </summary>
        public static readonly DependencyProperty TextFilterQualityProperty = DependencyProperty.Register("TextFilterQuality", typeof(string), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(null, OnTextChanged));

        /// <summary>
        /// The text filter sensor id property
        /// </summary>
        public static readonly DependencyProperty TextFilterSensorIdProperty = DependencyProperty.Register("TextFilterSensorId", typeof(string), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(null, OnTextChanged));

        /// <summary>
        /// The text filter unit property
        /// </summary>
        public static readonly DependencyProperty TextFilterUnitProperty = DependencyProperty.Register("TextFilterUnit", typeof(string), typeof(MonitorDataControlVm), new FrameworkPropertyMetadata(null, OnTextChanged));

        /// <summary>
        /// The time stamp header property
        /// </summary>
        public static readonly DependencyProperty TimeStampHeaderProperty = DependencyProperty.Register("TimeStampHeader", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The unit header property
        /// </summary>
        public static readonly DependencyProperty UnitHeaderProperty = DependencyProperty.Register("UnitHeader", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The value header property
        /// </summary>
        public static readonly DependencyProperty ValueHeaderProperty = DependencyProperty.Register("ValueHeader", typeof(string), typeof(MonitorDataControlVm), new PropertyMetadata(default(string)));

        #endregion

        #region Fields

        /// <summary>
        /// The main window view model
        /// </summary>
        private readonly MainWindowVm mainWindowViewModel;

        /// <summary>
        /// The monitor timer
        /// </summary>
        private readonly DispatcherTimer monitorTimer;

        /// <summary>
        /// The measurements monitor started
        /// </summary>
        private bool measurementsMonitorStarted;

        #endregion

        //// <summary>
        //// The set button pressed
        //// </summary>
        ////private readonly DelegateCommand setButtonPressed;
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MonitorDataControlVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException">@ mainWindowVm</exception>
        public MonitorDataControlVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.mainWindowViewModel = mainWindowVm;

            this.SensorIdHeader = Resources.SenorUidHeader;
            this.DeviceIdHeader = Resources.DeviceUidHeader;

            this.UnitHeader = Resources.UnitHeader;
            this.DataTypeHeader = Resources.DataTypeHeader;
            this.TimeStampHeader = Resources.TimeStampHeader;
            this.QualityHeader = Resources.QualityHeader;
            this.ValueHeader = Resources.ValueHeader;

            this.FilterHeader = Resources.Filter;
            this.EnterFilterTerm = Resources.EnterFilterTerm;

            this.RuntimeMeasurements = new ObservableCollection<RuntimeMeasurementData>();

            var view = (CollectionView)CollectionViewSource.GetDefaultView(this.RuntimeMeasurements);
            view.Filter = this.UserFilter;

            this.measurementsMonitorStarted = false;
            this.mainWindowViewModel.ServiceDataReceiver.RuntimeMeasurementsResponse += this.HandleRuntimeMeasurements;

            this.UpdateNumberOfItems();

            this.monitorTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.0) };
            this.monitorTimer.Tick += this.TimerTickEventHandlerMonitor;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the automation id.
        /// </summary>
        /// <value>The automation id.</value>
        public string AutomationId
        {
            get
            {
                return (string)this.GetValue(AutomationIdProperty);
            }

            private set
            {
                this.SetValue(AutomationIdProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the begin page command.
        /// </summary>
        /// <value>The begin page command.</value>
        public DelegateCommand BeginPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(BeginPageCommandProperty);
            }

            set
            {
                this.SetValue(BeginPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        public int CurrentPage
        {
            get
            {
                return (int)this.GetValue(CurrentPageProperty);
            }

            set
            {
                this.SetValue(CurrentPageProperty, value);
            }
        }

        /// <summary>
        /// Gets the data type header.
        /// </summary>
        /// <value>The data type header.</value>
        public string DataTypeHeader
        {
            get
            {
                return (string)this.GetValue(DataTypeHeaderProperty);
            }

            private set
            {
                this.SetValue(DataTypeHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets the device id header.
        /// </summary>
        /// <value>The device id header.</value>
        public string DeviceIdHeader
        {
            get
            {
                return (string)this.GetValue(DeviceIdHeaderProperty);
            }

            private set
            {
                this.SetValue(DeviceIdHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the end page command.
        /// </summary>
        /// <value>The end page command.</value>
        public DelegateCommand EndPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(EndPageCommandProperty);
            }

            set
            {
                this.SetValue(EndPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets the enter filter term.
        /// </summary>
        /// <value>The enter filter term.</value>
        public string EnterFilterTerm
        {
            get
            {
                return (string)this.GetValue(EnterFilterTermProperty);
            }

            private set
            {
                this.SetValue(EnterFilterTermProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [filter data type active].
        /// </summary>
        /// <value><c>true</c> if [filter data type active]; otherwise, <c>false</c>.</value>
        public bool FilterDataTypeActive
        {
            get
            {
                return (bool)this.GetValue(FilterDataTypeActiveProperty);
            }

            set
            {
                this.SetValue(FilterDataTypeActiveProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [filter device id active].
        /// </summary>
        /// <value><c>true</c> if [filter device id active]; otherwise, <c>false</c>.</value>
        public bool FilterDeviceIdActive
        {
            get
            {
                return (bool)this.GetValue(FilterDeviceIdActiveProperty);
            }

            set
            {
                this.SetValue(FilterDeviceIdActiveProperty, value);
            }
        }

        /// <summary>
        /// Gets the filter header.
        /// </summary>
        /// <value>The filter header.</value>
        public string FilterHeader
        {
            get
            {
                return (string)this.GetValue(FilterHeaderProperty);
            }

            private set
            {
                this.SetValue(FilterHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [filter quality active].
        /// </summary>
        /// <value><c>true</c> if [filter quality active]; otherwise, <c>false</c>.</value>
        public bool FilterQualityActive
        {
            get
            {
                return (bool)this.GetValue(FilterQualityActiveProperty);
            }

            set
            {
                this.SetValue(FilterQualityActiveProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [filter sensor id active].
        /// </summary>
        /// <value><c>true</c> if [filter sensor id active]; otherwise, <c>false</c>.</value>
        public bool FilterSensorIdActive
        {
            get
            {
                return (bool)this.GetValue(FilterSensorIdActiveProperty);
            }

            set
            {
                this.SetValue(FilterSensorIdActiveProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [filter unit active].
        /// </summary>
        /// <value><c>true</c> if [filter unit active]; otherwise, <c>false</c>.</value>
        public bool FilterUnitActive
        {
            get
            {
                return (bool)this.GetValue(FilterUnitActiveProperty);
            }

            set
            {
                this.SetValue(FilterUnitActiveProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the next page command.
        /// </summary>
        /// <value>The next page command.</value>
        public DelegateCommand NextPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(NextPageCommandProperty);
            }

            set
            {
                this.SetValue(NextPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>The number of pages.</value>
        public int NumberOfPages
        {
            get
            {
                return (int)this.GetValue(NumberOfPagesProperty);
            }

            set
            {
                this.SetValue(NumberOfPagesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>The pages.</value>
        public string Pages
        {
            get
            {
                return (string)this.GetValue(PagesProperty);
            }

            set
            {
                this.SetValue(PagesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the previous page command.
        /// </summary>
        /// <value>The previous page command.</value>
        public DelegateCommand PreviousPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(PreviousPageCommandProperty);
            }

            set
            {
                this.SetValue(PreviousPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets the quality header.
        /// </summary>
        /// <value>The quality header.</value>
        public string QualityHeader
        {
            get
            {
                return (string)this.GetValue(QualityHeaderProperty);
            }

            private set
            {
                this.SetValue(QualityHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the runtime measurements.
        /// </summary>
        /// <value>The runtime measurements.</value>
        public ObservableCollection<RuntimeMeasurementData> RuntimeMeasurements
        {
            get
            {
                return (ObservableCollection<RuntimeMeasurementData>)this.GetValue(RuntimeMeasurementsProperty);
            }

            set
            {
                this.SetValue(RuntimeMeasurementsProperty, value);
            }
        }

        /// <summary>
        /// Gets the sensor id header.
        /// </summary>
        /// <value>The sensor id header.</value>
        public string SensorIdHeader
        {
            get
            {
                return (string)this.GetValue(SensorIdHeaderProperty);
            }

            private set
            {
                this.SetValue(SensorIdHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets the type of the text filter data.
        /// </summary>
        /// <value>The type of the text filter data.</value>
        public string TextFilterDataType
        {
            get
            {
                return (string)this.GetValue(TextFilterDataTypeProperty);
            }

            private set
            {
                this.SetValue(TextFilterDataTypeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text filter device id.
        /// </summary>
        /// <value>The text filter device id.</value>
        public string TextFilterDeviceId
        {
            get
            {
                return (string)this.GetValue(TextFilterDeviceIdProperty);
            }

            set
            {
                this.SetValue(TextFilterDeviceIdProperty, value);
            }
        }

        /// <summary>
        /// Gets the text filter quality.
        /// </summary>
        /// <value>The text filter quality.</value>
        public string TextFilterQuality
        {
            get
            {
                return (string)this.GetValue(TextFilterQualityProperty);
            }

            private set
            {
                this.SetValue(TextFilterQualityProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text filter sensor id.
        /// </summary>
        /// <value>The text filter sensor id.</value>
        public string TextFilterSensorId
        {
            get
            {
                return (string)this.GetValue(TextFilterSensorIdProperty);
            }

            set
            {
                this.SetValue(TextFilterSensorIdProperty, value);
            }
        }

        /// <summary>
        /// Gets the text filter unit.
        /// </summary>
        /// <value>The text filter unit.</value>
        public string TextFilterUnit
        {
            get
            {
                return (string)this.GetValue(TextFilterUnitProperty);
            }

            private set
            {
                this.SetValue(TextFilterUnitProperty, value);
            }
        }

        /// <summary>
        /// Gets the time stamp header.
        /// </summary>
        /// <value>The time stamp header.</value>
        public string TimeStampHeader
        {
            get
            {
                return (string)this.GetValue(TimeStampHeaderProperty);
            }

            private set
            {
                this.SetValue(TimeStampHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets the unit header.
        /// </summary>
        /// <value>The unit header.</value>
        public string UnitHeader
        {
            get
            {
                return (string)this.GetValue(UnitHeaderProperty);
            }

            private set
            {
                this.SetValue(UnitHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets the value header.
        /// </summary>
        /// <value>The value header.</value>
        public string ValueHeader
        {
            get
            {
                return (string)this.GetValue(ValueHeaderProperty);
            }

            private set
            {
                this.SetValue(ValueHeaderProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Handles the measurements monitor.
        /// </summary>
        public void HandleMeasurementsMonitor()
        {
            if (this.mainWindowViewModel.CurrentSection == HomeSection.Monitor)
            {
                this.RuntimeMeasurements.Clear();               
            }
            
            if (this.measurementsMonitorStarted)
            {
                this.StopMonitor();
            }
        }

        /// <summary>
        /// Monitors the grid loaded.
        /// </summary>
        public void MonitorGridLoaded()
        {
            this.monitorTimer.Start();
        }

        /// <summary>
        /// Starts the monitor.
        /// </summary>
        public void StartMonitor()
        {
            try
            {
                var client = new CommServerClient();

                ////var measurements = new ConfiguredMeasurements();

                ////for (int i = 0; i < 50; i++)
                ////{
                ////    var measurement = new ConfiguredMeasurement(true);
                ////    measurement.DeviceId = new ConfiguredMeasurementItem(true) { Value = "Some_Device_Id" + i.ToString(CultureInfo.InvariantCulture), MappingType = MappingTypes.StaticType };
                ////    measurement.SensorId = new ConfiguredMeasurementItem(true) { Value = "Some_Sensor_Id" + i.ToString(CultureInfo.InvariantCulture), MappingType = MappingTypes.StaticType };
                ////    measurement.Unit = new ConfiguredMeasurementItem(true) { Value = "m3", MappingType = MappingTypes.StaticType };
                ////    measurement.DataType = CommonFormatDataTypes.FloatType;
                ////    measurement.Timestamp = new ConfiguredMeasurementItem(true) { Value = "Some_Opc_ItemId", MappingType = MappingTypes.OpcTimestampType };
                ////    measurement.Quality = new ConfiguredMeasurementItem(true) { Value = "Some_Opc_ItemId", MappingType = MappingTypes.OpcQualityType };
                ////    measurement.Value = new ConfiguredMeasurementItem(true) { Value = "Some_Opc_ItemId", MappingType = MappingTypes.OpcValueType };
                ////    measurement.Active = true;
                ////    measurements.Add(measurement);
                ////}
                client.StartMonitorRequest(MainWindow.ClientUri, Guid.NewGuid(), this.mainWindowViewModel.Configuration.ConfiguredMeasurements);
                client.Close();

                this.measurementsMonitorStarted = true;
            }
            catch (Exception exception)
            {
                this.mainWindowViewModel.Host.UserInterface.DisplayMessage(exception.Message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Stops the monitor.
        /// </summary>
        public void StopMonitor()
        {
            try
            {
                var client = new CommServerClient();
                client.StopMonitorRequest(MainWindow.ClientUri, Guid.NewGuid());
                client.Close();

                this.measurementsMonitorStarted = false;
            }
            catch (Exception exception)
            {
                this.mainWindowViewModel.Host.UserInterface.DisplayMessage(exception.Message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Updates the number of items.
        /// </summary>
        public void UpdateNumberOfItems()
        {
            var currentPage = string.Format(CultureInfo.CurrentUICulture, @"{0}", this.CurrentPage);
            var numberOfPages = string.Format(CultureInfo.CurrentUICulture, @"{0}", this.NumberOfPages);
            this.Pages = Resources.Page + @" " + currentPage + @"/" + numberOfPages;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when [current page changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCurrentPageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var monitorDataControlVm = sender as MonitorDataControlVm;
            if (monitorDataControlVm != null)
            {
                monitorDataControlVm.UpdateNumberOfItems();
            }
        }

        /// <summary>
        /// Called when [filter data type expander changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnFilterDataTypeExpanderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var monitorDataControlVm = sender as MonitorDataControlVm;
            if (monitorDataControlVm != null)
            {
                if (!string.IsNullOrEmpty(monitorDataControlVm.TextFilterDataType))
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.FilterNotEmpty);
                    monitorDataControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
                }
            }
        }

        /// <summary>
        /// Called when [filter device id expander changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnFilterDeviceIdExpanderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var monitorDataControlVm = sender as MonitorDataControlVm;
            if (monitorDataControlVm != null)
            {
                if (!string.IsNullOrEmpty(monitorDataControlVm.TextFilterDeviceId))
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.FilterNotEmpty);
                    monitorDataControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
                }
            }
        }

        /// <summary>
        /// Called when [filter quality expander changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnFilterQualityExpanderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var monitorDataControlVm = sender as MonitorDataControlVm;
            if (monitorDataControlVm != null)
            {
                if (!string.IsNullOrEmpty(monitorDataControlVm.TextFilterQuality))
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.FilterNotEmpty);
                    monitorDataControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
                }
            }
        }

        /// <summary>
        /// Called when [filter sensor id expander changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnFilterSensorIdExpanderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var monitorDataControlVm = sender as MonitorDataControlVm;
            if (monitorDataControlVm != null)
            {
                if (!string.IsNullOrEmpty(monitorDataControlVm.TextFilterSensorId))
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.FilterNotEmpty);
                    monitorDataControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
                }
            }
        }

        /// <summary>
        /// Called when [filter unit expander changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnFilterUnitExpanderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var monitorDataControlVm = sender as MonitorDataControlVm;
            if (monitorDataControlVm != null)
            {
                if (!string.IsNullOrEmpty(monitorDataControlVm.TextFilterUnit))
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.FilterNotEmpty);
                    monitorDataControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
                }
            }
        }

        /// <summary>
        /// Called when [number of pages changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnNumberOfPagesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var monitorDataControlVm = sender as MonitorDataControlVm;
            if (monitorDataControlVm != null)
            {
                monitorDataControlVm.UpdateNumberOfItems();
            }
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var monitorDataControlVm = sender as MonitorDataControlVm;
            if (monitorDataControlVm != null)
            {
                CollectionViewSource.GetDefaultView(monitorDataControlVm.RuntimeMeasurements).Refresh();

                var view = (CollectionView)CollectionViewSource.GetDefaultView(monitorDataControlVm.RuntimeMeasurements);
                view.Filter = monitorDataControlVm.UserFilter;
            }
        }

        /// <summary>
        /// Checks the type of the text filter data.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool CheckTextFilterDataType(object item)
        {
            var result = false;
            var runtimeMeasurementData = item as RuntimeMeasurementData;

            if (string.IsNullOrEmpty(this.TextFilterDataType))
            {
                result = true;
            }
            else
            {
                result = runtimeMeasurementData != null && runtimeMeasurementData.DataType.IndexOf(this.TextFilterDataType, StringComparison.OrdinalIgnoreCase) >= 0;
            }

            return result;
        }

        /// <summary>
        /// Checks the text filter device id.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool CheckTextFilterDeviceId(object item)
        {
            var result = false;
            var runtimeMeasurementData = item as RuntimeMeasurementData;

            if (string.IsNullOrEmpty(this.TextFilterDeviceId))
            {
                result = true;
            }
            else
            {
                result = runtimeMeasurementData != null && runtimeMeasurementData.DeviceId.IndexOf(this.TextFilterDeviceId, StringComparison.OrdinalIgnoreCase) >= 0;
            }

            return result;
        }

        /// <summary>
        /// Checks the text filter quality.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool CheckTextFilterQuality(object item)
        {
            var result = false;
            var runtimeMeasurementData = item as RuntimeMeasurementData;

            if (string.IsNullOrEmpty(this.TextFilterQuality))
            {
                result = true;
            }
            else
            {
                result = runtimeMeasurementData != null && runtimeMeasurementData.Quality.IndexOf(this.TextFilterQuality, StringComparison.OrdinalIgnoreCase) >= 0;
            }

            return result;
        }

        /// <summary>
        /// Checks the text filter sensor id.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool CheckTextFilterSensorId(object item)
        {
            var result = false;
            var runtimeMeasurementData = item as RuntimeMeasurementData;

            if (string.IsNullOrEmpty(this.TextFilterSensorId))
            {
                result = true;
            }
            else
            {
                result = runtimeMeasurementData != null && runtimeMeasurementData.SensorId.IndexOf(this.TextFilterSensorId, StringComparison.OrdinalIgnoreCase) >= 0;
            }

            return result;
        }

        /// <summary>
        /// Checks the text filter unit.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool CheckTextFilterUnit(object item)
        {
            var result = false;
            var runtimeMeasurementData = item as RuntimeMeasurementData;

            if (string.IsNullOrEmpty(this.TextFilterUnit))
            {
                result = true;
            }
            else
            {
                result = runtimeMeasurementData != null && runtimeMeasurementData.Unit.IndexOf(this.TextFilterUnit, StringComparison.OrdinalIgnoreCase) >= 0;
            }

            return result;
        }

        /// <summary>
        /// Handles the runtime measurements.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RuntimeMeasurementsDataEventArgs"/> instance containing the event data.</param>
        private void HandleRuntimeMeasurements(object sender, RuntimeMeasurementsDataEventArgs e)
        {
            if (e.RuntimeMeasurements != null)
            {
                foreach (var runtimeMeasurement in e.RuntimeMeasurements)
                {
                    if (!this.InsertMeasurementLinq(runtimeMeasurement))
                    {
                        this.RuntimeMeasurements.Add(new RuntimeMeasurementData(runtimeMeasurement));
                    }
                }
            }
        }

        /// <summary>
        /// Inserts the measurement.
        /// </summary>
        /// <param name="runtimeMeasurement">The runtime measurement.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool InsertMeasurement(RuntimeMeasurement runtimeMeasurement)
        {
            var retVal = false;

            foreach (var measurement in this.RuntimeMeasurements)
            {
                if (runtimeMeasurement.DeviceId == measurement.DeviceId && runtimeMeasurement.SensorId == measurement.SensorId)
                {
                    var index = this.RuntimeMeasurements.IndexOf(measurement);

                    if (index != -1)
                    {
                        this.RuntimeMeasurements.RemoveAt(index);
                        this.RuntimeMeasurements.Insert(index, new RuntimeMeasurementData(runtimeMeasurement));
                        retVal = true;
                        break;
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Inserts the measurement linq.
        /// </summary>
        /// <param name="runtimeMeasurement">The runtime measurement.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool InsertMeasurementLinq(RuntimeMeasurement runtimeMeasurement)
        {
            var retVal = false;

            var measurementQuery = from measurementItem in this.RuntimeMeasurements where (runtimeMeasurement.DeviceId == measurementItem.DeviceId) && (runtimeMeasurement.SensorId == measurementItem.SensorId) select measurementItem;
            var measurement = measurementQuery.FirstOrDefault();

            if (measurement != null)
            {
                var index = this.RuntimeMeasurements.IndexOf(measurement);

                if (index != -1)
                {
                    this.RuntimeMeasurements.RemoveAt(index);
                    this.RuntimeMeasurements.Insert(index, new RuntimeMeasurementData(runtimeMeasurement));
                    retVal = true;
                }
            }

            return retVal;
        }

        /// <summary>
        /// Timers the tick event handler monitor.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TimerTickEventHandlerMonitor(object sender, EventArgs e)
        {
            this.monitorTimer.Stop();
            this.StartMonitor();
        }

        /// <summary>
        /// Users the filter.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(this.TextFilterDeviceId) && string.IsNullOrEmpty(this.TextFilterSensorId) && string.IsNullOrEmpty(this.TextFilterDataType) && string.IsNullOrEmpty(this.TextFilterQuality) && string.IsNullOrEmpty(this.TextFilterUnit))
            {
                return true;
            }

            return this.CheckTextFilterSensorId(item) && this.CheckTextFilterDeviceId(item) && this.CheckTextFilterDataType(item) && this.CheckTextFilterQuality(item) && this.CheckTextFilterUnit(item);
        }

        #endregion
    }
}