// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Available command control alignment
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.Configurator.View;
    using EH.ImsOpcBridge.UI.Wpf.EventArguments;
    using EH.ImsOpcBridge.UI.Wpf.ViewModel;

    using log4net;

    /// <summary>
    /// Enum CommandAlignment
    /// </summary>
    public enum CommandAlignment
    {
        /// <summary>
        /// The left
        /// </summary>
        Left,

        /// <summary>
        /// The right
        /// </summary>
        Right,

        /// <summary>
        /// The both
        /// </summary>
        Both
    }

    /// <summary>
    /// Enum SettingsSection
    /// </summary>
    public enum SettingsSection
    {
        /// <summary>
        /// The bridge
        /// </summary>
        Bridge,

        /// <summary>
        /// The supply care enterprise
        /// </summary>
        SupplyCareEnterprise,

        /// <summary>
        /// The field information server
        /// </summary>
        FieldInformationServer,

        /// <summary>
        /// The user login password
        /// </summary>
        UserLoginPassword,

        /// <summary>
        /// The language
        /// </summary>
        Language,

        /// <summary>
        /// The default
        /// </summary>
        Default
    }

    /// <summary>
    /// Class SettingsVm
    /// </summary>
    public class SettingsVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The allow execution on machine property
        /// </summary>
        public static readonly DependencyProperty AllowExecutionOnMachineProperty = DependencyProperty.Register("AllowExecutionOnMachine", typeof(string), typeof(SettingsVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The choice property
        /// </summary>
        public static readonly DependencyProperty ChoiceProperty = DependencyProperty.Register("Choice", typeof(BaseSelectorControlViewModel), typeof(SettingsVm), new PropertyMetadata(default(BaseSelectorControlViewModel)));

        /// <summary>
        /// The command alignment property
        /// </summary>
        public static readonly DependencyProperty CommandAlignmentProperty = DependencyProperty.Register("CommandAlignment", typeof(CommandAlignment), typeof(SettingsVm), new PropertyMetadata(default(CommandAlignment)));

        /// <summary>
        /// The command alignments property
        /// </summary>
        public static readonly DependencyProperty CommandAlignmentsProperty = DependencyProperty.Register("CommandAlignments", typeof(BaseSelectorControlViewModel), typeof(SettingsVm), new PropertyMetadata(default(BaseSelectorControlViewModel)));

        /// <summary>
        /// The command items property
        /// </summary>
        public static readonly DependencyProperty CommandItemsProperty = DependencyProperty.Register("CommandItems", typeof(ObservableCollection<CommandItemVm>), typeof(SettingsVm), new PropertyMetadata(default(ObservableCollection<CommandItemVm>)));

        /// <summary>
        /// The current section property
        /// </summary>
        public static readonly DependencyProperty CurrentSectionProperty = DependencyProperty.Register("CurrentSection", typeof(SettingsSection), typeof(SettingsVm), new PropertyMetadata(default(SettingsSection)));

        /// <summary>
        /// The do logging commands property
        /// </summary>
        public static readonly DependencyProperty DoLoggingCommandsProperty = DependencyProperty.Register("DoLoggingCommands", typeof(bool?), typeof(SettingsVm), new FrameworkPropertyMetadata(true, OnDoLoggingCommandsChanged));

        /// <summary>
        /// The do show device commands property
        /// </summary>
        public static readonly DependencyProperty DoShowDeviceCommandsProperty = DependencyProperty.Register("DoShowDeviceCommands", typeof(bool?), typeof(SettingsVm), new FrameworkPropertyMetadata(true, OnDoShowDeviceCommandsChanged));

        /// <summary>
        /// The manufacturer property
        /// </summary>
        public static readonly DependencyProperty ManufacturerProperty = DependencyProperty.Register("Manufacturer", typeof(string), typeof(SettingsVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The own configuration property
        /// </summary>
        public static readonly DependencyProperty OwnConfigurationProperty = DependencyProperty.Register("OwnConfiguration", typeof(OwnConfigurationControlVm), typeof(SettingsVm), new PropertyMetadata(default(OwnConfigurationControlVm)));

        /// <summary>
        /// The windows pos height property
        /// </summary>
        public static readonly DependencyProperty WindowsPosHeightProperty = DependencyProperty.Register("WindowsPosHeight", typeof(double), typeof(SettingsVm), new PropertyMetadata(0.0));

        /// <summary>
        /// The windows pos left property
        /// </summary>
        public static readonly DependencyProperty WindowsPosLeftProperty = DependencyProperty.Register("WindowsPosLeft", typeof(double), typeof(SettingsVm), new PropertyMetadata(0.0));

        /// <summary>
        /// The windows pos top property
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "PosTop", Justification = @"OK here.")]
        public static readonly DependencyProperty WindowsPosTopProperty = DependencyProperty.Register("WindowsPosTop", typeof(double), typeof(SettingsVm), new PropertyMetadata(0.0));

        /// <summary>
        /// The windows pos width property
        /// </summary>
        public static readonly DependencyProperty WindowsPosWidthProperty = DependencyProperty.Register("WindowsPosWidth", typeof(double), typeof(SettingsVm), new PropertyMetadata(0.0));

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        /// <summary>
        /// The bridge setting control vm
        /// </summary>
        private readonly BridgeSettingCtrlVm bridgeSettingControlVm;

        /// <summary>
        /// The bridge setting control
        /// </summary>
        private readonly BridgeSettingControl bridgeSettingControl;
        
        /// <summary>
        /// The language control
        /// </summary>
        private readonly LanguageControl languageControl;

        /// <summary>
        /// The supply care setting control
        /// </summary>
        private readonly SupplyCareSettingControl supplyCareSettingControl;

        /// <summary>
        /// The supply care setting control
        /// </summary>
        private readonly FisSettingControl fisSettingControl;
        
        /// <summary>
        /// The fis setting control vm
        /// </summary>
        private readonly FisSettingCtrlVm fisSettingControlVm;

        /// <summary>
        /// The language control vm
        /// </summary>
        private readonly LanguageControlVm languageControlVm;

        /// <summary>
        /// The supply care setting CTRL vm
        /// </summary>
        private readonly SupplyCareSettingCtrlVm supplyCareSettingCtrlVm;

        /// <summary>
        /// The settings
        /// </summary>
        private ImsOpcBridgeSettings settings;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException">@ mainWindowVm</exception>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here.")]
        public SettingsVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.MainWindowVm = mainWindowVm;

            this.InitializeSettings();

            this.bridgeSettingControlVm = new BridgeSettingCtrlVm(mainWindowVm);
            this.bridgeSettingControl = new BridgeSettingControl();

            this.supplyCareSettingCtrlVm = new SupplyCareSettingCtrlVm(mainWindowVm);
            this.supplyCareSettingControl = new SupplyCareSettingControl();
            
            this.fisSettingControlVm = new FisSettingCtrlVm(mainWindowVm);
            this.fisSettingControl = new FisSettingControl();

            this.languageControlVm = new LanguageControlVm(this.settings, mainWindowVm.Host);
            this.languageControl = new LanguageControl();
            
            this.OwnConfiguration = new OwnConfigurationControlVm();

            this.CurrentSection = SettingsSection.Bridge;

            this.Choice = new BaseSelectorControlViewModel();
            this.Choice.SelectedItemChanged += this.ChoiceSelectedItemChangedHandler;
            this.Choice.Items.Add(new BaseSelectorItemViewModel(Resources.ImsOpcBridge, string.Empty, string.Empty, "automId_ImsOpcBridge", SettingsSection.Bridge, 1));
            this.Choice.Items.Add(new BaseSelectorItemViewModel(Resources.SupplyCareEnterprise, string.Empty, string.Empty, "automId_SupplyCareEnterprise", SettingsSection.SupplyCareEnterprise, 2));

            // emilio temp FIS disabled for the first release. Only this line must be commented / uncommented.
            // this.Choice.Items.Add(new BaseSelectorItemViewModel(Resources.FieldInformationServer, string.Empty, string.Empty, "automId_FieldInformationServer", SettingsSection.FieldInformationServer, 3));

            //// this.Choice.Items.Add(new BaseSelectorItemViewModel(Resources.UserLoginPassword, string.Empty, string.Empty, "automId_UserLoginPassword", SettingsSection.UserLoginPassword, 4));
            if (ImsOpcBridgeSettings.Singleton.AllowCultureChange)
            {
                this.Choice.Items.Add(new BaseSelectorItemViewModel(Resources.LanguageCommandName, string.Empty, string.Empty, "automId_Language", SettingsSection.Language, 4));
            }

            ////this.Choice.Items.Add(new BaseSelectorItemViewModel(string.Empty, string.Empty, string.Empty, "automId_Empty1", SettingsSection.Default, 5));
            
            this.Choice.SelectItem(this.CurrentSection);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the allow execution on machine.
        /// </summary>
        /// <value>The allow execution on machine.</value>
        public string AllowExecutionOnMachine
        {
            get
            {
                return (string)this.GetValue(AllowExecutionOnMachineProperty);
            }

            set
            {
                this.SetValue(AllowExecutionOnMachineProperty, value);
                this.settings.AllowExecutionOnMachine = value;
            }
        }

        /// <summary>
        /// Gets the choice.
        /// </summary>
        /// <value>The choice.</value>
        public BaseSelectorControlViewModel Choice
        {
            get
            {
                return (BaseSelectorControlViewModel)this.GetValue(ChoiceProperty);
            }

            private set
            {
                this.SetValue(ChoiceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the command alignment.
        /// </summary>
        /// <value>The command alignment.</value>
        public CommandAlignment CommandAlignment
        {
            get
            {
                return (CommandAlignment)this.GetValue(CommandAlignmentProperty);
            }

            set
            {
                this.SetValue(CommandAlignmentProperty, value);
                this.settings.CommandAlignment = value;
            }
        }

        /// <summary>
        /// Gets the command alignments.
        /// </summary>
        /// <value>The command alignments.</value>
        public BaseSelectorControlViewModel CommandAlignments
        {
            get
            {
                return (BaseSelectorControlViewModel)this.GetValue(CommandAlignmentsProperty);
            }
        }

        /// <summary>
        /// Gets or sets the current section.
        /// </summary>
        /// <value>The current section.</value>
        public SettingsSection CurrentSection
        {
            get
            {
                return (SettingsSection)this.GetValue(CurrentSectionProperty);
            }

            set
            {
                this.SetValue(CurrentSectionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [do logging commands].
        /// </summary>
        /// <value><c>null</c> if [do logging commands] contains no value, <c>true</c> if [do logging commands]; otherwise, <c>false</c>.</value>
        public bool? DoLoggingCommands
        {
            get
            {
                return (bool?)this.GetValue(DoLoggingCommandsProperty);
            }

            set
            {
                this.SetValue(DoLoggingCommandsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [do show device commands].
        /// </summary>
        /// <value><c>null</c> if [do show device commands] contains no value, <c>true</c> if [do show device commands]; otherwise, <c>false</c>.</value>
        public bool? DoShowDeviceCommands
        {
            get
            {
                return (bool?)this.GetValue(DoShowDeviceCommandsProperty);
            }

            set
            {
                this.SetValue(DoShowDeviceCommandsProperty, value);
            }
        }

        /// <summary>
        /// Gets the language control vm.
        /// </summary>
        /// <value>The language control vm.</value>
        public LanguageControlVm LanguageControlVm
        {
            get
            {
                return this.languageControlVm;
            }
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer
        {
            get
            {
                return (string)this.GetValue(ManufacturerProperty);
            }

            private set
            {
                this.SetValue(ManufacturerProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the own configuration.
        /// </summary>
        /// <value>The own configuration.</value>
        public OwnConfigurationControlVm OwnConfiguration
        {
            get
            {
                return (OwnConfigurationControlVm)this.GetValue(OwnConfigurationProperty);
            }

            set
            {
                this.SetValue(OwnConfigurationProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the windows pos.
        /// </summary>
        /// <value>The height of the windows pos.</value>
        public double WindowsPosHeight
        {
            get
            {
                return (double)this.GetValue(WindowsPosHeightProperty);
            }

            set
            {
                this.SetValue(WindowsPosHeightProperty, value);
                this.settings.WindowsPosHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the windows pos left.
        /// </summary>
        /// <value>The windows pos left.</value>
        public double WindowsPosLeft
        {
            get
            {
                return (double)this.GetValue(WindowsPosLeftProperty);
            }

            set
            {
                this.SetValue(WindowsPosLeftProperty, value);
                this.settings.WindowsPosLeft = value;
            }
        }

        /// <summary>
        /// Gets or sets the windows pos top.
        /// </summary>
        /// <value>The windows pos top.</value>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "PosTop", Justification = @"OK here.")]
        public double WindowsPosTop
        {
            get
            {
                return (double)this.GetValue(WindowsPosTopProperty);
            }

            set
            {
                this.SetValue(WindowsPosTopProperty, value);
                this.settings.WindowsPosTop = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the windows pos.
        /// </summary>
        /// <value>The width of the windows pos.</value>
        public double WindowsPosWidth
        {
            get
            {
                return (double)this.GetValue(WindowsPosWidthProperty);
            }

            set
            {
                this.SetValue(WindowsPosWidthProperty, value);
                this.settings.WindowsPosWidth = value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the main window vm.
        /// </summary>
        /// <value>The main window vm.</value>
        protected MainWindowVm MainWindowVm { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the state of the do show device commands check.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:CodeAnalysisSuppressionMustHaveJustification", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public bool? GetDoShowDeviceCommandsCheckState()
        {
            return this.DoShowDeviceCommands;
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public void Load()
        {
            this.settings.Load();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            this.settings.Save();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Goes to page.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="viewModel">The view model.</param>
        internal void GoToPage(UserControl view, PageViewModel viewModel)
        {
            this.OwnConfiguration.GoToPage(view, viewModel);
        }

        /// <summary>
        /// Toggles the show device pressed.
        /// </summary>
        protected void ToggleShowDevicePressed()
        {
            this.Save();
        }

        /// <summary>
        /// Called when [do logging commands changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnDoLoggingCommandsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var settingsVm = sender as SettingsVm;
            if (settingsVm != null)
            {
                settingsVm.settings.LoggingCommands = settingsVm.DoLoggingCommands == true;
            }
        }

        /// <summary>
        /// Called when [do show device commands changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnDoShowDeviceCommandsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var settingsVm = sender as SettingsVm;
            if (settingsVm != null)
            {
                settingsVm.settings.ShowDeviceCommands = settingsVm.DoShowDeviceCommands == true;
            }
        }

        /// <summary>
        /// Choices the selected item changed handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="BaseSelectorSelectionChangedEventArgs"/> instance containing the event data.</param>
        private void ChoiceSelectedItemChangedHandler(object sender, BaseSelectorSelectionChangedEventArgs e)
        {
            if (e != null)
            {
                if (e.SelectedItem != null)
                {
                    string message = string.Format(CultureInfo.CurrentUICulture, @"Executing '{0}'.", e.SelectedItem.Text);
                    Logger.Info(message);

                    SettingsSection section;

                    if (Enum.TryParse(e.SelectedItem.Value.ToString(), out section))
                    {
                        this.OpenOwnConfiguration(section);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes the settings.
        /// </summary>
        private void InitializeSettings()
        {
            this.settings = ImsOpcBridgeSettings.Singleton as ImsOpcBridgeSettings;

            if (this.settings != null)
            {
                this.AllowExecutionOnMachine = this.settings.AllowExecutionOnMachine;
                this.CommandAlignment = this.settings.CommandAlignment;
                this.DoShowDeviceCommands = this.settings.ShowDeviceCommands;
                this.DoLoggingCommands = this.settings.LoggingCommands;
                this.Manufacturer = this.settings.Manufacturer;
                this.WindowsPosHeight = this.settings.WindowsPosHeight;
                this.WindowsPosLeft = this.settings.WindowsPosLeft;
                this.WindowsPosTop = this.settings.WindowsPosTop;
                this.WindowsPosWidth = this.settings.WindowsPosWidth;
            }
        }

        /// <summary>
        /// Opens the own configuration.
        /// </summary>
        /// <param name="section">The section.</param>
        private void OpenOwnConfiguration(SettingsSection section)
        {
            this.OwnConfiguration.IsOwnConfigurationControlVisible = true;

            switch (section)
            {
                case SettingsSection.Language:
                    {
                        var page = this.languageControl;
                        var viewModel = this.LanguageControlVm;
                        this.GoToPage(page, viewModel);
                    }

                    break;

                case SettingsSection.Bridge:
                    {
                        var page = this.bridgeSettingControl;
                        var viewModel = this.bridgeSettingControlVm;
                        this.GoToPage(page, viewModel);
                    }

                    break;

                case SettingsSection.SupplyCareEnterprise:
                    {
                        var page = this.supplyCareSettingControl;
                        var viewModel = this.supplyCareSettingCtrlVm;
                        this.GoToPage(page, viewModel);
                    }

                    break;

                case SettingsSection.FieldInformationServer:
                    {
                        var page = this.fisSettingControl;
                        var viewModel = this.fisSettingControlVm;

                        this.GoToPage(page, viewModel);
                    }

                    break;

                case SettingsSection.Default:
                    {
                    }

                    break;

                default:
                    {
                        this.OwnConfiguration.IsOwnConfigurationControlVisible = true;
                        var page = new OwnConfigurationInformationControl();
                        var viewModel = this;
                        this.GoToPage(page, viewModel);
                    }

                    break;
            }
        }

        #endregion
    }
}