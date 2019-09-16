// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsHotkeyControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for SettingsHotkeyControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class SettingsHotkeyControl
    /// </summary>
    public partial class SettingsHotkeyControl
    {
        #region Static Fields

        /// <summary>
        /// The export configuration command property
        /// </summary>
        public static readonly DependencyProperty ExportConfigurationCommandProperty = DependencyProperty.Register("ExportConfigurationCommand", typeof(DelegateCommand), typeof(SettingsHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The import configuration command property
        /// </summary>
        public static readonly DependencyProperty ImportConfigurationCommandProperty = DependencyProperty.Register("ImportConfigurationCommand", typeof(DelegateCommand), typeof(SettingsHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The load configuration command property
        /// </summary>
        public static readonly DependencyProperty LoadConfigurationCommandProperty = DependencyProperty.Register("LoadConfigurationCommand", typeof(DelegateCommand), typeof(SettingsHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The next page command property
        /// </summary>
        public static readonly DependencyProperty NextPageCommandProperty = DependencyProperty.Register("NextPageCommand", typeof(DelegateCommand), typeof(SettingsHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The previous page command property
        /// </summary>
        public static readonly DependencyProperty PreviousPageCommandProperty = DependencyProperty.Register("PreviousPageCommand", typeof(DelegateCommand), typeof(SettingsHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The save configuration command property
        /// </summary>
        public static readonly DependencyProperty SaveConfigurationCommandProperty = DependencyProperty.Register("SaveConfigurationCommand", typeof(DelegateCommand), typeof(SettingsHotkeyControl), new PropertyMetadata(default(DelegateCommand)));
        
        /// <summary>
        /// The tool tip insert measurement property
        /// </summary>
        public static readonly DependencyProperty ToolTipExportConfigurationProperty = DependencyProperty.Register("ToolTipExportConfiguration", typeof(string), typeof(SettingsHotkeyControl), new PropertyMetadata(default(string)));

        /// <summary>
        /// The tool tip delete measurement property
        /// </summary>
        public static readonly DependencyProperty ToolTipImportConfigurationProperty = DependencyProperty.Register("ToolTipImportConfiguration", typeof(string), typeof(SettingsHotkeyControl), new PropertyMetadata(default(string)));

        /// <summary>
        /// The tool tip edit measurement property
        /// </summary>
        public static readonly DependencyProperty ToolTipSaveConfigurationProperty = DependencyProperty.Register("ToolTipSaveConfiguration", typeof(string), typeof(SettingsHotkeyControl), new PropertyMetadata(default(string)));

        /// <summary>
        /// The tool tip edit measurement details property
        /// </summary>
        public static readonly DependencyProperty ToolTipUnDoConfigurationProperty = DependencyProperty.Register("ToolTipUnDoConfiguration", typeof(string), typeof(SettingsHotkeyControl), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsHotkeyControl"/> class.
        /// </summary>
        public SettingsHotkeyControl()
        {
            this.ToolTipExportConfiguration = Properties.Resources.ExportConfiguration;
            this.ToolTipImportConfiguration = Properties.Resources.ImportConfiguration;
            this.ToolTipSaveConfiguration = Properties.Resources.SaveConfigurationToolTip;
            this.ToolTipUnDoConfiguration = Properties.Resources.UnDoConfiguration;

            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the export configuration command.
        /// </summary>
        /// <value>The export configuration command.</value>
        public DelegateCommand ExportConfigurationCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(ExportConfigurationCommandProperty);
            }

            set
            {
                this.SetValue(ExportConfigurationCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the import configuration command.
        /// </summary>
        /// <value>The import configuration command.</value>
        public DelegateCommand ImportConfigurationCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(ImportConfigurationCommandProperty);
            }

            set
            {
                this.SetValue(ImportConfigurationCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the load configuration command.
        /// </summary>
        /// <value>The load configuration command.</value>
        public DelegateCommand LoadConfigurationCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(LoadConfigurationCommandProperty);
            }

            set
            {
                this.SetValue(LoadConfigurationCommandProperty, value);
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
        /// Gets or sets the save configuration command.
        /// </summary>
        /// <value>The save configuration command.</value>
        public DelegateCommand SaveConfigurationCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(SaveConfigurationCommandProperty);
            }

            set
            {
                this.SetValue(SaveConfigurationCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip export configuration.
        /// </summary>
        /// <value>The tool tip export configuration.</value>
        public string ToolTipExportConfiguration
        {
            get
            {
                return (string)this.GetValue(ToolTipExportConfigurationProperty);
            }

            set
            {
                this.SetValue(ToolTipExportConfigurationProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip import configuration.
        /// </summary>
        /// <value>The tool tip import configuration.</value>
        public string ToolTipImportConfiguration
        {
            get
            {
                return (string)this.GetValue(ToolTipImportConfigurationProperty);
            }

            set
            {
                this.SetValue(ToolTipImportConfigurationProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip save configuration.
        /// </summary>
        /// <value>The tool tip save configuration.</value>
        public string ToolTipSaveConfiguration
        {
            get
            {
                return (string)this.GetValue(ToolTipSaveConfigurationProperty);
            }

            set
            {
                this.SetValue(ToolTipSaveConfigurationProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip un do configuration.
        /// </summary>
        /// <value>The tool tip un do configuration.</value>
        public string ToolTipUnDoConfiguration
        {
            get
            {
                return (string)this.GetValue(ToolTipUnDoConfigurationProperty);
            }

            set
            {
                this.SetValue(ToolTipUnDoConfigurationProperty, value);
            }
        }

        #endregion
    }
}