// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FisSettingCtrlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class FisSettingCtrlVm
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
    /// Class FisSettingCtrlVm
    /// </summary>
    public class FisSettingCtrlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The fis setting items property
        /// </summary>
        public static readonly DependencyProperty FisSettingItemsProperty = DependencyProperty.Register("FisSettingItems", typeof(ObservableCollection<FisSettingItemVm>), typeof(FisSettingCtrlVm), new PropertyMetadata(default(ObservableCollection<FisSettingItemVm>)));

        #endregion

        #region Fields
        
        /// <summary>
        /// The export configuration command
        /// </summary>
        private readonly DelegateCommand exportConfigurationCommand;

        /// <summary>
        /// The fis connection settings control vm
        /// </summary>
        private readonly FisConnectionSettingsControlVm fisConnectionSettingsControlVm;

        /// <summary>
        /// The fis time schedule settings control vm
        /// </summary>
        private readonly FisTimeScheduleSettingsControlVm fisTimeScheduleSettingsControlVm;

        /// <summary>
        /// The fis proxy settings control vm
        /// </summary>
        private readonly FisProxySettingsControlVm fisProxySettingsControlVm;
        
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
        /// Initializes a new instance of the <see cref="FisSettingCtrlVm"/> class.
        /// </summary>
        public FisSettingCtrlVm()
        {
            this.FisSettingItems = new ObservableCollection<FisSettingItemVm>();

            var fisTimeScheduleSettingsCtrl = new FisTimeScheduleSettingsCtrl();
            var fisSettingItem = new FisSettingItemVm(this, fisTimeScheduleSettingsCtrl, this.fisTimeScheduleSettingsControlVm, Resources.FISTimeSchedule, true, @"FIS time schedule");
            fisSettingItem.IsExpanded = false;
            this.FisSettingItems.Add(fisSettingItem);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FisSettingCtrlVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        public FisSettingCtrlVm(MainWindowVm mainWindowVm)
        {
            this.FisSettingItems = new ObservableCollection<FisSettingItemVm>();

            this.mainWindowViewModel = mainWindowVm;

            this.saveConfigurationCommand = new DelegateCommand(this.SaveConfiguration);
            this.loadConfigurationCommand = new DelegateCommand(this.LoadConfiguration);

            this.exportConfigurationCommand = new DelegateCommand(this.ExportConfiguration);
            this.importConfigurationCommand = new DelegateCommand(this.ImportConfiguration);
            
            var fisConnectionSettingsCtrl = new FisConnectionSettingsCtrl();
            this.fisConnectionSettingsControlVm = new FisConnectionSettingsControlVm(mainWindowVm);

            var fisTimeScheduleSettingsCtrl = new FisTimeScheduleSettingsCtrl();
            this.fisTimeScheduleSettingsControlVm = new FisTimeScheduleSettingsControlVm(mainWindowVm);

            var fisProxySettingsCtrl = new FisProxySettingsCtrl();
            this.fisProxySettingsControlVm = new FisProxySettingsControlVm(mainWindowVm);

            var fisSettingItem = new FisSettingItemVm(this, fisConnectionSettingsCtrl, this.fisConnectionSettingsControlVm, Resources.ServerConfiguration, true, @"Server configuration");
            fisSettingItem.IsExpanded = false;
            this.FisSettingItems.Add(fisSettingItem);
            
            fisSettingItem = new FisSettingItemVm(this, fisProxySettingsCtrl, this.fisProxySettingsControlVm, Resources.ProxyConfiguration, true, @"Proxy configuration");
            fisSettingItem.IsExpanded = false;
            this.FisSettingItems.Add(fisSettingItem);

            fisSettingItem = new FisSettingItemVm(this, fisTimeScheduleSettingsCtrl, this.fisTimeScheduleSettingsControlVm, Resources.FISTimeSchedule, true, @"FIS time schedule");
            fisSettingItem.IsExpanded = false;
            this.FisSettingItems.Add(fisSettingItem);
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
        public ObservableCollection<FisSettingItemVm> FisSettingItems
        {
            get
            {
                return (ObservableCollection<FisSettingItemVm>)this.GetValue(FisSettingItemsProperty);
            }

            set
            {
                this.SetValue(FisSettingItemsProperty, value);
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
        public void SelectFisSettingItem(FisSettingItemVm itemToSelect)
        {
            foreach (var item in this.FisSettingItems)
            {
                if (item.ExpandButtonVisibility == Visibility.Visible)
                {
                    item.IsExpanded = false;
                }
            }

            foreach (var item in this.FisSettingItems)
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