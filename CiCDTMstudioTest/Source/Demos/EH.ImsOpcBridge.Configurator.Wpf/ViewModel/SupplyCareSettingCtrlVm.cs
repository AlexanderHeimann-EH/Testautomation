// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplyCareSettingCtrlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class SupplyCareSettingCtrlVm
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.Configurator.View;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class SupplyCareSettingCtrlVm
    /// </summary>
    public class SupplyCareSettingCtrlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The fis setting items property
        /// </summary>
        public static readonly DependencyProperty SupplyCareSettingItemsProperty = DependencyProperty.Register("SupplyCareSettingItems", typeof(ObservableCollection<SupplyCareSettingItemVm>), typeof(SupplyCareSettingCtrlVm), new PropertyMetadata(default(ObservableCollection<SupplyCareSettingItemVm>)));

        #endregion

        #region Fields
        
        /// <summary>
        /// The export configuration command
        /// </summary>
        private readonly DelegateCommand exportConfigurationCommand;

        /// <summary>
        /// The supply care web server settings control vm
        /// </summary>
        private readonly SupplyCareWebServerSettingsControlVm supplyCareWebServerSettingsControlVm;

        /// <summary>
        /// The sampling rate settings control vm
        /// </summary>
        private readonly SupplyCareSamplingRateSettingsControlVm supplyCareSamplingRateSettingsControlVm;
        
        /// <summary>
        /// The import configuration command
        /// </summary>
        private readonly DelegateCommand importConfigurationCommand;

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

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplyCareSettingCtrlVm"/> class.
        /// </summary>
        public SupplyCareSettingCtrlVm()
        {
            this.SupplyCareSettingItems = new ObservableCollection<SupplyCareSettingItemVm>();

            var supplyCareSamplingRateSettingsCtrl = new SupplyCareSamplingRateSettingsCtrl();
            var supplyCareSettingItemVm = new SupplyCareSettingItemVm(this, supplyCareSamplingRateSettingsCtrl, this.supplyCareSamplingRateSettingsControlVm, Resources.OPCTimeSchedule, true, @"OPC time schedule");
            supplyCareSettingItemVm.IsExpanded = false;
            this.SupplyCareSettingItems.Add(supplyCareSettingItemVm);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplyCareSettingCtrlVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        public SupplyCareSettingCtrlVm(MainWindowVm mainWindowVm)
        {
            this.SupplyCareSettingItems = new ObservableCollection<SupplyCareSettingItemVm>();

            this.mainWindowViewModel = mainWindowVm;

            this.saveConfigurationCommand = new DelegateCommand(this.SaveConfiguration);
            this.loadConfigurationCommand = new DelegateCommand(this.LoadConfiguration);

            this.exportConfigurationCommand = new DelegateCommand(this.ExportConfiguration);
            this.importConfigurationCommand = new DelegateCommand(this.ImportConfiguration);

            var supplyCareWebServerSettingsCtrl = new SupplyCareWebServerSettingsCtrl();
            this.supplyCareWebServerSettingsControlVm = new SupplyCareWebServerSettingsControlVm(mainWindowVm);

            var supplyCareSamplingRateSettingsCtrl = new SupplyCareSamplingRateSettingsCtrl();
            this.supplyCareSamplingRateSettingsControlVm = new SupplyCareSamplingRateSettingsControlVm(mainWindowVm);

            var supplyCareSettingItemVm = new SupplyCareSettingItemVm(this, supplyCareWebServerSettingsCtrl, this.supplyCareWebServerSettingsControlVm, Resources.WebServer, true, @"SupplyCare WebServer Configuration");
            supplyCareSettingItemVm.IsExpanded = false;
            this.SupplyCareSettingItems.Add(supplyCareSettingItemVm);

            supplyCareSettingItemVm = new SupplyCareSettingItemVm(this, supplyCareSamplingRateSettingsCtrl, this.supplyCareSamplingRateSettingsControlVm, Resources.OPCTimeSchedule, true, @"OPC time schedule");
            supplyCareSettingItemVm.IsExpanded = false;
            this.SupplyCareSettingItems.Add(supplyCareSettingItemVm);
        }

        #endregion

        #region Public Properties

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
        /// Gets or sets the fis setting items.
        /// </summary>
        /// <value>The fis setting items.</value>
        public ObservableCollection<SupplyCareSettingItemVm> SupplyCareSettingItems
        {
            get
            {
                return (ObservableCollection<SupplyCareSettingItemVm>)this.GetValue(SupplyCareSettingItemsProperty);
            }

            set
            {
                this.SetValue(SupplyCareSettingItemsProperty, value);
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

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Selects the fis setting item.
        /// </summary>
        /// <param name="itemToSelect">The item to select.</param>
        public void SelectSupplyCareSettingItem(SupplyCareSettingItemVm itemToSelect)
        {
            foreach (var item in this.SupplyCareSettingItems)
            {
                if (item.ExpandButtonVisibility == Visibility.Visible)
                {
                    item.IsExpanded = false;
                }
            }

            foreach (var item in this.SupplyCareSettingItems)
            {
                if (object.Equals(item, itemToSelect))
                {
                    item.IsExpanded = true;
                    return;
                }
            }
        }

        #endregion

        #region Methods

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
        /// Imports the configuration.
        /// </summary>
        protected void ImportConfiguration()
        {
            ////var message = string.Format(CultureInfo.CurrentUICulture, "ImportConfiguration");
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);

            this.mainWindowViewModel.ImportConfiguration();
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

        #endregion
    }
}