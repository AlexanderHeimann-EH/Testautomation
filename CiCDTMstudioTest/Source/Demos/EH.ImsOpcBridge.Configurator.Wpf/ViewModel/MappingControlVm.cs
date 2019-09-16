// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappingControlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class MappingControlVm
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.EventArguments;
    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class MappingControlVm
    /// </summary>
    public class MappingControlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The active header property
        /// </summary>
        public static readonly DependencyProperty ActiveHeaderProperty = DependencyProperty.Register("ActiveHeader", typeof(string), typeof(MappingControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The automation id property
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(MappingControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The begin page command property
        /// </summary>
        public static readonly DependencyProperty BeginPageCommandProperty = DependencyProperty.Register("BeginPageCommand", typeof(DelegateCommand), typeof(MappingControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The configured measurement items property
        /// </summary>
        public static readonly DependencyProperty ConfiguredMeasurementItemsProperty = DependencyProperty.Register("ConfiguredMeasurementItems", typeof(ObservableCollection<ConfiguredMeasurementItemData>), typeof(MappingControlVm), new PropertyMetadata(default(ObservableCollection<ConfiguredMeasurementItemData>)));

        /// <summary>
        /// The configured measurements property
        /// </summary>
        public static readonly DependencyProperty ConfiguredMeasurementsProperty = DependencyProperty.Register("ConfiguredMeasurements", typeof(ObservableCollection<ConfiguredMeasurementData>), typeof(MappingControlVm), new PropertyMetadata(default(ObservableCollection<ConfiguredMeasurementData>)));

        /// <summary>
        /// The current item property
        /// </summary>
        public static readonly DependencyProperty CurrentItemProperty = DependencyProperty.Register("CurrentItem", typeof(object), typeof(MappingControlVm), new FrameworkPropertyMetadata(null, OnCurrentItemChanged));

        /// <summary>
        /// The current page property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(int), typeof(MappingControlVm), new FrameworkPropertyMetadata(1, OnCurrentPageChanged));
        
        /// <summary>
        /// The current page property
        /// </summary>
        public static readonly DependencyProperty ScrollPageProperty = DependencyProperty.Register("ScrollPage", typeof(int), typeof(MappingControlVm), new FrameworkPropertyMetadata(1, OnScrollPageChanged));
        
        /// <summary>
        /// The device uid header property
        /// </summary>
        public static readonly DependencyProperty DeviceUidHeaderProperty = DependencyProperty.Register("DeviceUidHeader", typeof(string), typeof(MappingControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The end page command property
        /// </summary>
        public static readonly DependencyProperty EndPageCommandProperty = DependencyProperty.Register("EndPageCommand", typeof(DelegateCommand), typeof(MappingControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The enter filter term property
        /// </summary>
        public static readonly DependencyProperty EnterFilterTermProperty = DependencyProperty.Register("EnterFilterTerm", typeof(string), typeof(MappingControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The field header property
        /// </summary>
        public static readonly DependencyProperty FieldHeaderProperty = DependencyProperty.Register("FieldHeader", typeof(string), typeof(MappingControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The filter device id active property
        /// </summary>
        public static readonly DependencyProperty FilterDeviceIdActiveProperty = DependencyProperty.Register("FilterDeviceIdActive", typeof(bool), typeof(MappingControlVm), new FrameworkPropertyMetadata(false, OnFilterDeviceIdExpanderChanged));

        /// <summary>
        /// The filter header property
        /// </summary>
        public static readonly DependencyProperty FilterHeaderProperty = DependencyProperty.Register("FilterHeader", typeof(string), typeof(MappingControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The filter sensor id active property
        /// </summary>
        public static readonly DependencyProperty FilterSensorIdActiveProperty = DependencyProperty.Register("FilterSensorIdActive", typeof(bool), typeof(MappingControlVm), new FrameworkPropertyMetadata(false, OnFilterSensorIdExpanderChanged));

        /// <summary>
        /// The has selection property
        /// </summary>
        public static readonly DependencyProperty HasSelectionProperty = DependencyProperty.Register("HasSelection", typeof(bool), typeof(MappingControlVm), new PropertyMetadata(false, SelectionChanged));

        /// <summary>
        /// The is mapping data grid visible property
        /// </summary>
        public static readonly DependencyProperty IsMappingDataGridVisibleProperty = DependencyProperty.Register("IsMappingDataGridVisible", typeof(bool), typeof(MappingControlVm), new PropertyMetadata(true));

        /// <summary>
        /// The is mapping details data grid visible property
        /// </summary>
        public static readonly DependencyProperty IsMappingDetailsDataGridVisibleProperty = DependencyProperty.Register("IsMappingDetailsDataGridVisible", typeof(bool), typeof(MappingControlVm), new PropertyMetadata(false));

        /// <summary>
        /// The mapping mode header property
        /// </summary>
        public static readonly DependencyProperty MappingModeHeaderProperty = DependencyProperty.Register("MappingModeHeader", typeof(string), typeof(MappingControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The next page command property
        /// </summary>
        public static readonly DependencyProperty NextPageCommandProperty = DependencyProperty.Register("NextPageCommand", typeof(DelegateCommand), typeof(MappingControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The number of pages property
        /// </summary>
        public static readonly DependencyProperty NumberOfPagesProperty = DependencyProperty.Register("NumberOfPages", typeof(int), typeof(MappingControlVm), new FrameworkPropertyMetadata(1, OnNumberOfPagesChanged));

        /// <summary>
        /// The opc item mapping tree parent vm property
        /// </summary>
        public static readonly DependencyProperty OpcItemMappingTreeParentVmProperty = DependencyProperty.Register("OpcItemMappingTreeParentVm", typeof(OpcItemMappingTreeParentVm), typeof(MappingControlVm), new PropertyMetadata(default(OpcItemMappingTreeParentVm)));

        /// <summary>
        /// The pages property
        /// </summary>
        public static readonly DependencyProperty PagesProperty = DependencyProperty.Register("Pages", typeof(string), typeof(MappingControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The previous page command property
        /// </summary>
        public static readonly DependencyProperty PreviousPageCommandProperty = DependencyProperty.Register("PreviousPageCommand", typeof(DelegateCommand), typeof(MappingControlVm), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The selected cells list property
        /// </summary>
        public static readonly DependencyProperty SelectedCellsListProperty = DependencyProperty.Register("SelectedCellsList", typeof(IList<DataGridCellInfo>), typeof(MappingControlVm), new PropertyMetadata(null));

        /// <summary>
        /// The sensor uid header property
        /// </summary>
        public static readonly DependencyProperty SensorUidHeaderProperty = DependencyProperty.Register("SensorUidHeader", typeof(string), typeof(MappingControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text filter device id property
        /// </summary>
        public static readonly DependencyProperty TextFilterDeviceIdProperty = DependencyProperty.Register("TextFilterDeviceId", typeof(string), typeof(MappingControlVm), new FrameworkPropertyMetadata(null, OnTextChanged));

        /// <summary>
        /// The text filter sensor id property
        /// </summary>
        public static readonly DependencyProperty TextFilterSensorIdProperty = DependencyProperty.Register("TextFilterSensorId", typeof(string), typeof(MappingControlVm), new FrameworkPropertyMetadata(null, OnTextChanged));

        /// <summary>
        /// The tool tip edit measurement property
        /// </summary>
        public static readonly DependencyProperty ToolTipEditMeasurementProperty = DependencyProperty.Register("ToolTipEditMeasurement", typeof(string), typeof(MappingControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The validation error property
        /// </summary>
        public static readonly DependencyProperty ValidationErrorProperty = DependencyProperty.Register("ValidationError", typeof(string), typeof(MappingControlVm), new PropertyMetadata(string.Empty, OnValidationErrorChanged));

        /// <summary>
        /// The value header property
        /// </summary>
        public static readonly DependencyProperty ValueHeaderProperty = DependencyProperty.Register("ValueHeader", typeof(string), typeof(MappingControlVm), new PropertyMetadata(default(string)));

        #endregion

        #region Fields

        /// <summary>
        /// The delete row command
        /// </summary>
        private readonly DelegateCommand deleteRowCommand;

        /// <summary>
        /// The details command
        /// </summary>
        private readonly DelegateCommand detailsCommand;

        /// <summary>
        /// The export configuration command
        /// </summary>
        private readonly DelegateCommand exportConfigurationCommand;

        /// <summary>
        /// The import configuration command
        /// </summary>
        private readonly DelegateCommand importConfigurationCommand;

        /// <summary>
        /// The insert row command
        /// </summary>
        private readonly DelegateCommand insertRowCommand;

        /// <summary>
        /// The load configuration command
        /// </summary>
        private readonly DelegateCommand loadConfigurationCommand;

        /// <summary>
        /// The main window view model
        /// </summary>
        private readonly MainWindowVm mainWindowViewModel;

        /// <summary>
        /// The save configuration command
        /// </summary>
        private readonly DelegateCommand saveConfigurationCommand;

        /// <summary>
        /// The selected row
        /// </summary>
        private int selectedRow;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingControlVm"/> class.
        /// </summary>
        public MappingControlVm()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingControlVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException">@ mainWindowVm</exception>
        public MappingControlVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.mainWindowViewModel = mainWindowVm;

            this.ActiveHeader = Resources.ActiveHeader;
            this.SensorUidHeader = Resources.SenorUidHeader;
            this.DeviceUidHeader = Resources.DeviceUidHeader;

            this.FilterHeader = Resources.Filter;
            this.EnterFilterTerm = Resources.EnterFilterTerm;

            this.FieldHeader = Resources.FieldHeader;
            this.MappingModeHeader = Resources.MappingModeHeader;
            this.ValueHeader = Resources.ValueHeader;
            this.ToolTipEditMeasurement = Resources.EditMeasurementDetails;

            this.detailsCommand = new DelegateCommand(this.GoToDetailsPage);
            this.insertRowCommand = new DelegateCommand(this.InsertRow);
            this.deleteRowCommand = new DelegateCommand(this.DeleteRow);
            this.saveConfigurationCommand = new DelegateCommand(this.SaveConfiguration);
            this.loadConfigurationCommand = new DelegateCommand(this.LoadConfiguration);
            this.importConfigurationCommand = new DelegateCommand(this.ImportConfiguration);
            this.exportConfigurationCommand = new DelegateCommand(this.ExportConfiguration);

            var opcItems = new[] { new OpcItem(true) };
            this.OpcItemMappingTreeParentVm = new OpcItemMappingTreeParentVm(opcItems, this.mainWindowViewModel);
            this.OpcItemMappingTreeParentVm.OpcItems.Clear();

            this.ConfiguredMeasurements = new ObservableCollection<ConfiguredMeasurementData>();
            this.ConfiguredMeasurements.Clear();
            this.ConfiguredMeasurements = new ObservableCollection<ConfiguredMeasurementData>((from child in this.mainWindowViewModel.ConfiguredMeasurements select new ConfiguredMeasurementData(ref child)).ToList<ConfiguredMeasurementData>());

            var view = (CollectionView)CollectionViewSource.GetDefaultView(this.ConfiguredMeasurements);
            view.Filter = this.UserFilter;

            this.ConfiguredMeasurementItems = new ObservableCollection<ConfiguredMeasurementItemData>();
            this.ConfiguredMeasurementItems.Clear();

            this.mainWindowViewModel.ServiceDataReceiver.ReadOpcAddressSpaceResponse += this.HandleReadOpcAddressSpaceResponse;
            this.mainWindowViewModel.ServiceDataReceiver.ConfigurationResponse += this.HandleConfigurationResponse;
            this.mainWindowViewModel.ServiceDataReceiver.ConfigurationResponse += this.HandleConfigurationResponse;

            this.EnableHotkeysButton(false);
            this.IsMappingDetailsDataGridVisible = false;
            this.IsMappingDataGridVisible = true;
            this.OpcItemMappingTreeParentVm.AllowDrag = true;

            this.selectedRow = -1;

            this.EnableHotkeysButton(false);

            this.InitializeParameters();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the active header.
        /// </summary>
        /// <value>The active header.</value>
        public string ActiveHeader
        {
            get
            {
                return (string)this.GetValue(ActiveHeaderProperty);
            }

            private set
            {
                this.SetValue(ActiveHeaderProperty, value);
            }
        }

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
        /// Gets or sets the configured measurement items.
        /// </summary>
        /// <value>The configured measurement items.</value>
        public ObservableCollection<ConfiguredMeasurementItemData> ConfiguredMeasurementItems
        {
            get
            {
                return (ObservableCollection<ConfiguredMeasurementItemData>)this.GetValue(ConfiguredMeasurementItemsProperty);
            }

            set
            {
                this.SetValue(ConfiguredMeasurementItemsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the configured measurements.
        /// </summary>
        /// <value>The configured measurements.</value>
        public ObservableCollection<ConfiguredMeasurementData> ConfiguredMeasurements
        {
            get
            {
                return (ObservableCollection<ConfiguredMeasurementData>)this.GetValue(ConfiguredMeasurementsProperty);
            }

            set
            {
                this.SetValue(ConfiguredMeasurementsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current item.
        /// </summary>
        /// <value>The current item.</value>
        public object CurrentItem
        {
            get
            {
                return (object)this.GetValue(CurrentItemProperty);
            }

            set
            {
                this.SetValue(CurrentItemProperty, value);
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
        /// Gets or sets the scroll page.
        /// </summary>
        /// <value>The scroll page.</value>
        public int ScrollPage
        {
            get
            {
                return (int)this.GetValue(ScrollPageProperty);
            }

            set
            {
                this.SetValue(ScrollPageProperty, value);
            }
        }

        /// <summary>
        /// Gets the delete row command.
        /// </summary>
        /// <value>The delete row command.</value>
        public ICommand DeleteRowCommand
        {
            get
            {
                return this.deleteRowCommand;
            }
        }

        /// <summary>
        /// Gets the details command.
        /// </summary>
        /// <value>The details command.</value>
        public ICommand DetailsCommand
        {
            get
            {
                return this.detailsCommand;
            }
        }

        /// <summary>
        /// Gets the device uid header.
        /// </summary>
        /// <value>The device uid header.</value>
        public string DeviceUidHeader
        {
            get
            {
                return (string)this.GetValue(DeviceUidHeaderProperty);
            }

            private set
            {
                this.SetValue(DeviceUidHeaderProperty, value);
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
        /// Gets the export configuration command.
        /// </summary>
        /// <value>The export configuration command.</value>
        public ICommand ExportConfigurationCommand
        {
            get
            {
                return this.exportConfigurationCommand;
            }
        }

        /// <summary>
        /// Gets the field header.
        /// </summary>
        /// <value>The field header.</value>
        public string FieldHeader
        {
            get
            {
                return (string)this.GetValue(FieldHeaderProperty);
            }

            private set
            {
                this.SetValue(FieldHeaderProperty, value);
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
        /// Gets or sets a value indicating whether this instance has selection.
        /// </summary>
        /// <value><c>true</c> if this instance has selection; otherwise, <c>false</c>.</value>
        public bool HasSelection
        {
            get
            {
                return (bool)this.GetValue(HasSelectionProperty);
            }

            set
            {
                this.SetValue(HasSelectionProperty, value);
            }
        }

        /// <summary>
        /// Gets the import configuration command.
        /// </summary>
        /// <value>The import configuration command.</value>
        public ICommand ImportConfigurationCommand
        {
            get
            {
                return this.importConfigurationCommand;
            }
        }

        /// <summary>
        /// Gets the insert row command.
        /// </summary>
        /// <value>The insert row command.</value>
        public ICommand InsertRowCommand
        {
            get
            {
                return this.insertRowCommand;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is mapping data grid visible.
        /// </summary>
        /// <value><c>true</c> if this instance is mapping data grid visible; otherwise, <c>false</c>.</value>
        public bool IsMappingDataGridVisible
        {
            get
            {
                return (bool)this.GetValue(IsMappingDataGridVisibleProperty);
            }

            private set
            {
                this.SetValue(IsMappingDataGridVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is mapping details data grid visible.
        /// </summary>
        /// <value><c>true</c> if this instance is mapping details data grid visible; otherwise, <c>false</c>.</value>
        public bool IsMappingDetailsDataGridVisible
        {
            get
            {
                return (bool)this.GetValue(IsMappingDetailsDataGridVisibleProperty);
            }

            private set
            {
                this.SetValue(IsMappingDetailsDataGridVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets the load configuration command.
        /// </summary>
        /// <value>The load configuration command.</value>
        public ICommand LoadConfigurationCommand
        {
            get
            {
                return this.loadConfigurationCommand;
            }
        }

        /// <summary>
        /// Gets the mapping mode header.
        /// </summary>
        /// <value>The mapping mode header.</value>
        public string MappingModeHeader
        {
            get
            {
                return (string)this.GetValue(MappingModeHeaderProperty);
            }

            private set
            {
                this.SetValue(MappingModeHeaderProperty, value);
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
        /// Gets or sets the opc item mapping tree parent vm.
        /// </summary>
        /// <value>The opc item mapping tree parent vm.</value>
        public OpcItemMappingTreeParentVm OpcItemMappingTreeParentVm
        {
            get
            {
                return (OpcItemMappingTreeParentVm)this.GetValue(OpcItemMappingTreeParentVmProperty);
            }

            set
            {
                this.SetValue(OpcItemMappingTreeParentVmProperty, value);
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
        /// Gets the save configuration command.
        /// </summary>
        /// <value>The save configuration command.</value>
        public ICommand SaveConfigurationCommand
        {
            get
            {
                return this.saveConfigurationCommand;
            }
        }

        /// <summary>
        /// Gets or sets the selected cells list.
        /// </summary>
        /// <value>The selected cells list.</value>
        public IList<DataGridCellInfo> SelectedCellsList
        {
            get
            {
                return (IList<DataGridCellInfo>)this.GetValue(SelectedCellsListProperty);
            }

            set
            {
                this.SetValue(SelectedCellsListProperty, value);
            }
        }

        /// <summary>
        /// Gets the sensor uid header.
        /// </summary>
        /// <value>The sensor uid header.</value>
        public string SensorUidHeader
        {
            get
            {
                return (string)this.GetValue(SensorUidHeaderProperty);
            }

            private set
            {
                this.SetValue(SensorUidHeaderProperty, value);
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
        /// Gets or sets the tool tip edit measurement.
        /// </summary>
        /// <value>The tool tip edit measurement.</value>
        public string ToolTipEditMeasurement
        {
            get
            {
                return (string)this.GetValue(ToolTipEditMeasurementProperty);
            }

            set
            {
                this.SetValue(ToolTipEditMeasurementProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the validation error.
        /// </summary>
        /// <value>The validation error.</value>
        public string ValidationError
        {
            get
            {
                return (string)this.GetValue(ValidationErrorProperty);
            }

            set
            {
                this.SetValue(ValidationErrorProperty, value);
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
        /// Clears the opc item mapping tree opc items.
        /// </summary>
        internal void ClearOpcItemMappingTreeOpcItems()
        {
            this.OpcItemMappingTreeParentVm.OpcItems.Clear();
        }

        /// <summary>
        /// Deletes the row.
        /// </summary>
        protected void DeleteRow()
        {
            if ((this.mainWindowViewModel.ConfiguredMeasurements.Count > this.selectedRow) && (this.selectedRow >= 0))
            {
                this.mainWindowViewModel.ConfiguredMeasurements.RemoveAt(this.selectedRow);

                // Update ViewModel with complete DataBase
                this.ConfiguredMeasurements.Clear();
                this.ConfiguredMeasurements = new ObservableCollection<ConfiguredMeasurementData>((from child in this.mainWindowViewModel.ConfiguredMeasurements select new ConfiguredMeasurementData(ref child)).ToList<ConfiguredMeasurementData>());

                var view = (CollectionView)CollectionViewSource.GetDefaultView(this.ConfiguredMeasurements);
                view.Filter = this.UserFilter;
            }

            this.SetCurrentItem(this.selectedRow);
        }

        /// <summary>
        /// Exports the configuration.
        /// </summary>
        protected void ExportConfiguration()
        {
            ////var message = string.Format(CultureInfo.CurrentUICulture, "ExportConfiguration");
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);

            this.mainWindowViewModel.ExportConfiguration();
        }

        /// <summary>
        /// Gets the current selected configured measurement.
        /// </summary>
        /// <returns>Returns ConfiguredMeasurement.</returns>
        protected ConfiguredMeasurement GetCurrentSelectedConfiguredMeasurement()
        {
            ConfiguredMeasurement configuredMeasurement = null;

            if ((this.mainWindowViewModel.ConfiguredMeasurements.Count > this.selectedRow) && (this.selectedRow >= 0))
            {
                configuredMeasurement = this.mainWindowViewModel.ConfiguredMeasurements.ElementAt(this.selectedRow);
            }

            return configuredMeasurement;
        }

        /// <summary>
        /// Gets the current selected measurement item.
        /// </summary>
        /// <param name="configuredMeasurementData">The configured measurement data.</param>
        /// <returns>ObservableCollection {ConfiguredMeasurementItemData}.</returns>
        protected ObservableCollection<ConfiguredMeasurementItemData> GetCurrentSelectedMeasurementItem(ConfiguredMeasurementData configuredMeasurementData)
        {
            var configuredMeasurementItems = new ObservableCollection<ConfiguredMeasurementItemData>();
            configuredMeasurementItems.Clear();

            if (configuredMeasurementData != null)
            {
                var configuredMeasurement = configuredMeasurementData.ConfiguredMeasurement; // database Reference

                var value = configuredMeasurement.DeviceId.Value;
                var mappingType = configuredMeasurement.DeviceId.MappingType.ToString();
                var measurementItemType = MeasurementItemTypes.DeviceId;

                var configuredMeasurementItemData = new ConfiguredMeasurementItemData(ref configuredMeasurement, value, mappingType, measurementItemType);
                configuredMeasurementItems.Add(configuredMeasurementItemData);

                value = configuredMeasurement.SensorId.Value;
                mappingType = configuredMeasurement.SensorId.MappingType.ToString();
                measurementItemType = MeasurementItemTypes.SensorId;

                configuredMeasurementItemData = new ConfiguredMeasurementItemData(ref configuredMeasurement, value, mappingType, measurementItemType);
                configuredMeasurementItems.Add(configuredMeasurementItemData);

                value = configuredMeasurement.Unit.Value;
                mappingType = configuredMeasurement.Unit.MappingType.ToString();
                measurementItemType = MeasurementItemTypes.Unit;

                configuredMeasurementItemData = new ConfiguredMeasurementItemData(ref configuredMeasurement, value, mappingType, measurementItemType);
                configuredMeasurementItems.Add(configuredMeasurementItemData);

                value = configuredMeasurement.DataType.ToString();
                mappingType = string.Empty;
                measurementItemType = MeasurementItemTypes.DataType;

                configuredMeasurementItemData = new ConfiguredMeasurementItemData(ref configuredMeasurement, value, mappingType, measurementItemType);
                configuredMeasurementItems.Add(configuredMeasurementItemData);

                value = configuredMeasurement.Timestamp.Value;
                mappingType = configuredMeasurement.Timestamp.MappingType.ToString();
                measurementItemType = MeasurementItemTypes.TimeStamp;

                configuredMeasurementItemData = new ConfiguredMeasurementItemData(ref configuredMeasurement, value, mappingType, measurementItemType);
                configuredMeasurementItems.Add(configuredMeasurementItemData);

                value = configuredMeasurement.Quality.Value;
                mappingType = configuredMeasurement.Quality.MappingType.ToString();
                measurementItemType = MeasurementItemTypes.Quality;

                configuredMeasurementItemData = new ConfiguredMeasurementItemData(ref configuredMeasurement, value, mappingType, measurementItemType);
                configuredMeasurementItems.Add(configuredMeasurementItemData);

                value = configuredMeasurement.Value.Value;
                mappingType = configuredMeasurement.Value.MappingType.ToString();
                measurementItemType = MeasurementItemTypes.Value;

                configuredMeasurementItemData = new ConfiguredMeasurementItemData(ref configuredMeasurement, value, mappingType, measurementItemType);
                configuredMeasurementItems.Add(configuredMeasurementItemData);

                value = configuredMeasurement.Active ? Resources.Active : Resources.NotActive;
                
                mappingType = string.Empty;
                measurementItemType = MeasurementItemTypes.Active;

                configuredMeasurementItemData = new ConfiguredMeasurementItemData(ref configuredMeasurement, value, mappingType, measurementItemType);
                configuredMeasurementItems.Add(configuredMeasurementItemData);
            }

            return configuredMeasurementItems;
        }

        /// <summary>
        /// Gets the default configured measurement data.
        /// </summary>
        /// <returns>Returns ConfiguredMeasurement.</returns>
        protected ConfiguredMeasurement GetDefaultConfiguredMeasurementData()
        {
            var measurement = new ConfiguredMeasurement(true);
            measurement.DeviceId = new ConfiguredMeasurementItem(true) { Value = "---", MappingType = MappingTypes.StaticType };
            measurement.SensorId = new ConfiguredMeasurementItem(true) { Value = "---", MappingType = MappingTypes.StaticType };
            measurement.Unit = new ConfiguredMeasurementItem(true) { Value = "---", MappingType = MappingTypes.StaticType };
            measurement.DataType = CommonFormatDataTypes.FloatType;
            measurement.Timestamp = new ConfiguredMeasurementItem(true) { Value = "---", MappingType = MappingTypes.OpcTimestampType };
            measurement.Quality = new ConfiguredMeasurementItem(true) { Value = "---", MappingType = MappingTypes.OpcQualityType };
            measurement.Value = new ConfiguredMeasurementItem(true) { Value = "---", MappingType = MappingTypes.OpcValueType };
            measurement.Active = false;

            return measurement;
        }

        /// <summary>
        /// Goes to details page.
        /// </summary>
        protected void GoToDetailsPage()
        {
            this.IsMappingDetailsDataGridVisible = !this.IsMappingDetailsDataGridVisible;
            this.IsMappingDataGridVisible = !this.IsMappingDataGridVisible;

            // Update Mapping Details Grid
            if (this.IsMappingDetailsDataGridVisible)
            {
                this.OpcItemMappingTreeParentVm.AllowDrag = false;
                this.insertRowCommand.IsExecutable = false;
                this.ToolTipEditMeasurement = Resources.EditMeasurement;
                this.ResetSelection();

                var cellInfo = this.SelectedCellsList.FirstOrDefault();
                var selectedConfiguredMeasurementData = cellInfo.Item as ConfiguredMeasurementData;

                if (selectedConfiguredMeasurementData == null)
                {
                    var message = Resources.PleaseSelectMeasurementItem;
                    this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
                }

                this.ConfiguredMeasurementItems = this.GetCurrentSelectedMeasurementItem(selectedConfiguredMeasurementData);
            }
            else
            {
                this.OpcItemMappingTreeParentVm.AllowDrag = true;
                this.insertRowCommand.IsExecutable = true;
                this.ToolTipEditMeasurement = Resources.EditMeasurementDetails;
                this.SetFocusSelectedItem();
            }
        }

        /// <summary>
        /// Imports the configuration.
        /// </summary>
        protected void ImportConfiguration()
        {
            ////var message = string.Format(CultureInfo.CurrentUICulture, "ImportConfiguration");
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);

            this.mainWindowViewModel.ImportConfiguration();
        }

        /// <summary>
        /// Inserts the row.
        /// </summary>
        protected void InsertRow()
        {
            var measurement = this.GetDefaultConfiguredMeasurementData();

            if (measurement != null)
            {
                if (this.selectedRow != -1)
                {
                    // Update DataBase
                    this.mainWindowViewModel.ConfiguredMeasurements.Insert(this.selectedRow, measurement);

                    // Update ViewModel with complete DataBase
                    this.ConfiguredMeasurements.Clear();
                    this.ConfiguredMeasurements = new ObservableCollection<ConfiguredMeasurementData>((from child in this.mainWindowViewModel.ConfiguredMeasurements select new ConfiguredMeasurementData(ref child)).ToList<ConfiguredMeasurementData>());

                    var view = (CollectionView)CollectionViewSource.GetDefaultView(this.ConfiguredMeasurements);
                    view.Filter = this.UserFilter;

                    this.SetCurrentItem(this.selectedRow + 1);
                }
                else
                {
                    //////// TestCode to generate Measurements
                    ////for (int i = 0; i < 1000; i++)
                    ////{
                    ////    measurement = this.GetDefaultConfiguredMeasurementData();
                    ////    measurement.DeviceId.Value = i.ToString();

                    ////    int mod = i % 2; //mod is 2

                    ////    if (mod == 1)
                    ////    {
                    ////        measurement.Active = true;

                    ////    }

                    ////    // Update DataBase
                    ////    this.mainWindowViewModel.ConfiguredMeasurements.Add(measurement);
                    ////}

                    ////// // Update ViewModel with complete DataBase
                    ////this.ConfiguredMeasurements.Clear();
                    ////this.ConfiguredMeasurements = new ObservableCollection<ConfiguredMeasurementData>((from child in this.mainWindowViewModel.ConfiguredMeasurements select new ConfiguredMeasurementData(ref child)).ToList<ConfiguredMeasurementData>());

                    // Update DataBase
                    this.mainWindowViewModel.ConfiguredMeasurements.Add(measurement);

                    // Update ViewModel with complete DataBase
                    this.ConfiguredMeasurements.Clear();
                    this.ConfiguredMeasurements = new ObservableCollection<ConfiguredMeasurementData>((from child in this.mainWindowViewModel.ConfiguredMeasurements select new ConfiguredMeasurementData(ref child)).ToList<ConfiguredMeasurementData>());
                  
                    var view = (CollectionView)CollectionViewSource.GetDefaultView(this.ConfiguredMeasurements);
                    view.Filter = this.UserFilter;

                    this.SetCurrentItem(this.ConfiguredMeasurements.Count);
                }      
            }
        }

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        protected void LoadConfiguration()
        {
            ////var message = string.Format(CultureInfo.CurrentUICulture, "LoadConfiguration");
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);

            this.mainWindowViewModel.LoadConfiguration();
        }

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        protected void SaveConfiguration()
        {
            ////var message = string.Format(CultureInfo.CurrentUICulture, "SaveConfiguration");
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);

            this.mainWindowViewModel.SaveConfiguration();
        }

        /// <summary>
        /// Sets the current item.
        /// </summary>
        /// <param name="row">The row.</param>
        protected void SetCurrentItem(int row)
        {
            // Select next Item
            if (this.ConfiguredMeasurements.Count > row)
            {
                var nextConfiguredMeasurementData = this.ConfiguredMeasurements[row];
                if (nextConfiguredMeasurementData != null)
                {
                    this.CurrentItem = nextConfiguredMeasurementData;
                }
            }
            else if (this.ConfiguredMeasurements.Count == row)
            {
                if ((row - 1) > -1)
                {
                    var nextConfiguredMeasurementData = this.ConfiguredMeasurements[row - 1];

                    if (nextConfiguredMeasurementData != null)
                    {
                        this.CurrentItem = nextConfiguredMeasurementData;
                    }
                }
                else
                {
                    this.CurrentItem = null;
                }
            }
        }

        /// <summary>
        /// Sets the focus selected item.
        /// </summary>
        protected void SetFocusSelectedItem()
        {
            var cellInfo = this.SelectedCellsList.FirstOrDefault();
            var selectedConfiguredMeasurementData = cellInfo.Item as ConfiguredMeasurementData;

            if (selectedConfiguredMeasurementData != null)
            {
                var currentColumnIndex = cellInfo.Column.DisplayIndex;

                var currentRowIndex = this.ConfiguredMeasurements.IndexOf(selectedConfiguredMeasurementData);

                if (currentRowIndex != -1 && currentColumnIndex != -1)
                {
                    // Trigger changes
                    this.CurrentItem = null;
                    this.CurrentItem = selectedConfiguredMeasurementData;
                }
            }
        }

        /// <summary>
        /// Called when [current item changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCurrentItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mappingControlVm = sender as MappingControlVm;
            if (mappingControlVm != null)
            {
                var selectedConfiguredMeasurementData = e.NewValue as ConfiguredMeasurementData;

                if (selectedConfiguredMeasurementData != null)
                {
                    var data = selectedConfiguredMeasurementData.ConfiguredMeasurement;

                    mappingControlVm.selectedRow = mappingControlVm.mainWindowViewModel.Configuration.ConfiguredMeasurements.IndexOf(data);

                    if (mappingControlVm.selectedRow != -1)
                    {
                        mappingControlVm.HasSelection = true;
                    }
                }
            }
        }

        /// <summary>
        /// Called when [current page changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCurrentPageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mappingControlVm = sender as MappingControlVm;
            if (mappingControlVm != null)
            {
                // To update comboBox 
                ////// PageableDataGrid: EnableRowVirtualization="True"

                // Update ViewModel with complete DataBase
                mappingControlVm.ConfiguredMeasurements.Clear();
                mappingControlVm.ConfiguredMeasurements = new ObservableCollection<ConfiguredMeasurementData>((from child in mappingControlVm.mainWindowViewModel.ConfiguredMeasurements select new ConfiguredMeasurementData(ref child)).ToList<ConfiguredMeasurementData>());
                mappingControlVm.UpdateNumberOfItems();

                var view = (CollectionView)CollectionViewSource.GetDefaultView(mappingControlVm.ConfiguredMeasurements);
                view.Filter = mappingControlVm.UserFilter;
            }
        }

        /// <summary>
        /// Called when [current page changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnScrollPageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mappingControlVm = sender as MappingControlVm;
            if (mappingControlVm != null)
            {
                //// To update comboBox 
                //// PageableDataGrid: EnableRowVirtualization="True"

                // Update ViewModel with complete DataBase
                mappingControlVm.ConfiguredMeasurements.Clear();
                mappingControlVm.ConfiguredMeasurements = new ObservableCollection<ConfiguredMeasurementData>((from child in mappingControlVm.mainWindowViewModel.ConfiguredMeasurements select new ConfiguredMeasurementData(ref child)).ToList<ConfiguredMeasurementData>());
                mappingControlVm.UpdateNumberOfItems();

                var view = (CollectionView)CollectionViewSource.GetDefaultView(mappingControlVm.ConfiguredMeasurements);
                view.Filter = mappingControlVm.UserFilter;
            }
        }
        
        /// <summary>
        /// Called when [filter device id expander changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnFilterDeviceIdExpanderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mappingControlVm = sender as MappingControlVm;
            if (mappingControlVm != null)
            {
                if (!string.IsNullOrEmpty(mappingControlVm.TextFilterDeviceId))
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.FilterNotEmpty);
                    mappingControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
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
            var mappingControlVm = sender as MappingControlVm;
            if (mappingControlVm != null)
            {
                if (!string.IsNullOrEmpty(mappingControlVm.TextFilterSensorId))
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.FilterNotEmpty);
                    mappingControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
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
            var mappingControlVm = sender as MappingControlVm;
            if (mappingControlVm != null)
            {
                mappingControlVm.UpdateNumberOfItems();
            }
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mappingControlVm = sender as MappingControlVm;
            if (mappingControlVm != null)
            {
                CollectionViewSource.GetDefaultView(mappingControlVm.ConfiguredMeasurements).Refresh();

                var view = (CollectionView)CollectionViewSource.GetDefaultView(mappingControlVm.ConfiguredMeasurements);
                view.Filter = mappingControlVm.UserFilter;
            }
        }

        /// <summary>
        /// Called when [validation error changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnValidationErrorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mappingControlVm = sender as MappingControlVm;
            if ((mappingControlVm != null) && !string.IsNullOrEmpty(mappingControlVm.ValidationError))
            {
                var message = mappingControlVm.ValidationError;
                mappingControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Selections the changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void SelectionChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mappingControlVm = sender as MappingControlVm;
            if (mappingControlVm != null)
            {
                mappingControlVm.EnableHotkeysButton(mappingControlVm.HasSelection);
            }
        }

        /// <summary>
        /// Checks the text filter device id.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool CheckTextFilterDeviceId(object item)
        {
            var result = false;
            var configuredMeasurementData = item as ConfiguredMeasurementData;

            if (string.IsNullOrEmpty(this.TextFilterDeviceId))
            {
                result = true;
            }
            else
            {
                result = configuredMeasurementData != null && configuredMeasurementData.DeviceId.IndexOf(this.TextFilterDeviceId, StringComparison.OrdinalIgnoreCase) >= 0;
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
            var configuredMeasurementData = item as ConfiguredMeasurementData;

            if (string.IsNullOrEmpty(this.TextFilterSensorId))
            {
                result = true;
            }
            else
            {
                result = configuredMeasurementData != null && configuredMeasurementData.SensorId.IndexOf(this.TextFilterSensorId, StringComparison.OrdinalIgnoreCase) >= 0;
            }

            return result;
        }

        /// <summary>
        /// Enables the hotkeys button.
        /// </summary>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        private void EnableHotkeysButton(bool enable)
        {
            if (this.ConfiguredMeasurements.Count == 0)
            {
                this.deleteRowCommand.IsExecutable = true;

                //// this.insertRowCommand.IsExecutable = true;
            }
            else
            {
                this.deleteRowCommand.IsExecutable = enable;

                //// this.insertRowCommand.IsExecutable = enable;
            }
        }

        /// <summary>
        /// Handles the configuration response.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ConfigurationDataEventArgs"/> instance containing the event data.</param>
        private void HandleConfigurationResponse(object sender, ConfigurationDataEventArgs e)
        {
            if (e.Configuration != null)
            {
                this.ConfiguredMeasurements.Clear();

                this.ConfiguredMeasurements = new ObservableCollection<ConfiguredMeasurementData>((from child in e.Configuration.ConfiguredMeasurements select new ConfiguredMeasurementData(ref child)).ToList<ConfiguredMeasurementData>());

                var view = (CollectionView)CollectionViewSource.GetDefaultView(this.ConfiguredMeasurements);
                view.Filter = this.UserFilter;
            }
        }

        /// <summary>
        /// Handles the read opc address space response.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AddressSpaceDataEventArgs"/> instance containing the event data.</param>
        private void HandleReadOpcAddressSpaceResponse(object sender, AddressSpaceDataEventArgs e)
        {
            if (e.AddressSpace != null)
            {
                var opcItems = new[] { e.AddressSpace };
                this.OpcItemMappingTreeParentVm.OpcItems = new ObservableCollection<OpcItemMappingTreeRootVm>((from opcItem in opcItems select new OpcItemMappingTreeRootVm(opcItem, this.mainWindowViewModel)).ToList());
            }
        }

        /// <summary>
        /// Initializes the parameters.
        /// </summary>
        private void InitializeParameters()
        {
            this.UpdateNumberOfItems();
        }

        /// <summary>
        /// Resets the selection.
        /// </summary>
        private void ResetSelection()
        {
            this.selectedRow = -1;

            this.HasSelection = false;
        }

        /// <summary>
        /// Users the filter.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(this.TextFilterDeviceId) && string.IsNullOrEmpty(this.TextFilterSensorId))
            {
                return true;
            }

            return this.CheckTextFilterSensorId(item) && this.CheckTextFilterDeviceId(item);
        }

        #endregion
    }
}