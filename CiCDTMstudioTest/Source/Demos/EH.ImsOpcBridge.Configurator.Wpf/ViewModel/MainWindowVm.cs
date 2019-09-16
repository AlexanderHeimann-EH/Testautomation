// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The wizard step.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;

    using EH.ImsOpcBridge.Configurator.DefaultHost;
    using EH.ImsOpcBridge.Configurator.EventArguments;
    using EH.ImsOpcBridge.Configurator.Interfaces;
    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.Configurator.View;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;
    using EH.ImsOpcBridge.UI.Wpf.EventArguments;
    using EH.ImsOpcBridge.UI.Wpf.ViewModel;

    using log4net;

    using Microsoft.Win32;

    /// <summary>
    /// Enum WizardStep
    /// </summary>
    public enum WizardStep
    {
        /// <summary>
        /// The unknown
        /// </summary>
        Unknown,

        /// <summary>
        /// The home
        /// </summary>
        Home,

        /// <summary>
        /// The how to use
        /// </summary>
        HowToUse,

        /// <summary>
        /// The restriction window
        /// </summary>
        RestrictionWindow,

        /// <summary>
        /// The settings
        /// </summary>
        Settings,

        /// <summary>
        /// The display message
        /// </summary>
        DisplayMessage,

        /// <summary>
        /// The display text box
        /// </summary>
        DisplayTextBox
    }

    /// <summary>
    /// Enum HomeSection
    /// </summary>
    public enum HomeSection
    {
        /// <summary>
        /// The monitor
        /// </summary>
        Monitor,

        /// <summary>
        /// The server
        /// </summary>
        Server,

        /// <summary>
        /// The mapping
        /// </summary>
        Mapping,

        /// <summary>
        /// The event log
        /// </summary>
        EventLog,

        /// <summary>
        /// The default
        /// </summary>
        Default
    }

    /// <summary>
    /// Class MainWindowVm
    /// </summary>
    [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = @"OK here.")]
    [CLSCompliant(false)]
    public class MainWindowVm : PageViewModel, IDisposable
    {
        #region Static Fields

        /// <summary>
        /// The command items property
        /// </summary>
        public static readonly DependencyProperty CommandItemsProperty = DependencyProperty.Register("CommandItems", typeof(ObservableCollection<CommandItemVm>), typeof(MainWindowVm), new PropertyMetadata(default(ObservableCollection<CommandItemVm>)));

        /// <summary>
        /// The current navigation page vm property
        /// </summary>
        public static readonly DependencyProperty CurrentNavigationPageVmProperty = DependencyProperty.Register("CurrentNavigationPageVm", typeof(NavigationPageVm), typeof(MainWindowVm), new PropertyMetadata(default(NavigationPageVm)));

        /// <summary>
        /// The current section property
        /// </summary>
        public static readonly DependencyProperty CurrentSectionProperty = DependencyProperty.Register("CurrentSection", typeof(HomeSection), typeof(MainWindowVm), new PropertyMetadata(default(HomeSection)));

        /// <summary>
        /// The current time property
        /// </summary>
        public static readonly DependencyProperty CurrentTimeProperty = DependencyProperty.Register("CurrentTime", typeof(DateTime), typeof(MainWindowVm), new PropertyMetadata(default(DateTime)));

        /// <summary>
        /// The empty menu choice property
        /// </summary>
        public static readonly DependencyProperty EmptyMenuChoiceProperty = DependencyProperty.Register("EmptyMenuChoice", typeof(BaseSelectorControlViewModel), typeof(MainWindowVm), new PropertyMetadata(default(BaseSelectorControlViewModel)));

        /// <summary>
        /// The home visibility property
        /// </summary>
        public static readonly DependencyProperty HomeVisibilityProperty = DependencyProperty.Register("HomeVisibility", typeof(Visibility), typeof(MainWindowVm), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The how to use view model property
        /// </summary>
        public static readonly DependencyProperty HowToUseViewModelProperty = DependencyProperty.Register("HowToUseViewModel", typeof(HowToUseVm), typeof(MainWindowVm), new PropertyMetadata(default(HowToUseVm)));

        /// <summary>
        /// The is enabled property
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.Register("IsEnabled", typeof(bool), typeof(MainWindowVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The is how to use visible property
        /// </summary>
        public static readonly DependencyProperty IsHowToUseVisibleProperty = DependencyProperty.Register("IsHowToUseVisible", typeof(bool), typeof(MainWindowVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The is progress visible property
        /// </summary>
        public static readonly DependencyProperty IsProgressVisibleProperty = DependencyProperty.Register("IsProgressVisible", typeof(bool), typeof(MainWindowVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The is settings visible property
        /// </summary>
        public static readonly DependencyProperty IsSettingsVisibleProperty = DependencyProperty.Register("IsSettingsVisible", typeof(bool), typeof(MainWindowVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The menu choice property
        /// </summary>
        public static readonly DependencyProperty MenuChoiceProperty = DependencyProperty.Register("MenuChoice", typeof(BaseSelectorControlViewModel), typeof(MainWindowVm), new PropertyMetadata(default(BaseSelectorControlViewModel)));

        /// <summary>
        /// The message agent property
        /// </summary>
        public static readonly DependencyProperty MessageAgentProperty = DependencyProperty.Register("MessageAgentViewModel", typeof(MessageAgentVm), typeof(MainWindowVm), new PropertyMetadata(default(MessageAgentVm)));

        /// <summary>
        /// The own configuration property
        /// </summary>
        public static readonly DependencyProperty OwnConfigurationProperty = DependencyProperty.Register("OwnConfiguration", typeof(OwnConfigurationControlVm), typeof(MainWindowVm), new PropertyMetadata(default(OwnConfigurationControlVm)));

        /// <summary>
        /// The progress view model property
        /// </summary>
        public static readonly DependencyProperty ProgressViewModelProperty = DependencyProperty.Register("ProgressViewModel", typeof(ProgressVm), typeof(MainWindowVm), new PropertyMetadata(default(ProgressVm)));

        /// <summary>
        /// The settings vm property
        /// </summary>
        public static readonly DependencyProperty SettingsVmProperty = DependencyProperty.Register("SettingsViewModel", typeof(SettingsVm), typeof(MainWindowVm), new PropertyMetadata(default(SettingsVm)));

        /// <summary>
        /// The wizard step property
        /// </summary>
        public static readonly DependencyProperty WizardStepProperty = DependencyProperty.Register("WizardStep", typeof(WizardStep), typeof(MainWindowVm), new PropertyMetadata(WizardStep.Unknown));

        /// <summary>
        /// The tool tip delete event log property
        /// </summary>
        public static readonly DependencyProperty ToolTipExitProperty = DependencyProperty.Register("ToolTipExit", typeof(string), typeof(MainWindowVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The tool tip home property
        /// </summary>
        public static readonly DependencyProperty ToolTipHomeProperty = DependencyProperty.Register("ToolTipHome", typeof(string), typeof(MainWindowVm), new PropertyMetadata(default(string)));
        
        /// <summary>
        /// The tool tip settings property
        /// </summary>
        public static readonly DependencyProperty ToolTipSettingsProperty = DependencyProperty.Register("ToolTipSettings", typeof(string), typeof(MainWindowVm), new PropertyMetadata(default(string)));
        
        /// <summary>
        /// The tool tip about property
        /// </summary>
        public static readonly DependencyProperty ToolTipAboutProperty = DependencyProperty.Register("ToolTipAbout", typeof(string), typeof(MainWindowVm), new PropertyMetadata(default(string)));
        
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        /// <summary>
        /// The event log control vm
        /// </summary>
        private readonly EventLogControlVm eventLogControlVm;

        /// <summary>
        /// The exit application
        /// </summary>
        private readonly DelegateCommand exitApplication;

        /// <summary>
        /// The home command
        /// </summary>
        private readonly DelegateCommand homeCommand;

        /// <summary>
        /// The how to use command
        /// </summary>
        private readonly DelegateCommand howToUseCommand;

        /// <summary>
        /// The mapping control vm
        /// </summary>
        private readonly MappingControlVm mappingControlVm;

        /// <summary>
        /// The monitor data CTRL vm
        /// </summary>
        private readonly MonitorDataControlVm monitorDataCtrlVm;

        /// <summary>
        /// The server control vm
        /// </summary>
        private readonly ServerControlVm serverControlVm;

        /// <summary>
        /// The settings command
        /// </summary>
        private readonly DelegateCommand settingsCommand;

        /// <summary>
        /// The timer
        /// </summary>
        private readonly DispatcherTimer timer;

        /// <summary>
        /// The byte array configuration stored
        /// </summary>
        private byte[] byteArrayConfigurationStored;

        /// <summary>
        /// The configuration
        /// </summary>
        private Configuration configuration;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The host
        /// </summary>
        private IConfiguratorHost host;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowVm"/> class.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK.")]
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK here.")]
        public MainWindowVm()
        {
            var mutex = new Mutex(false, @"Local\EH.ImsOpcBridge.Configurator.MainWindowVm");

            try
            {
                mutex.WaitOne();

                this.host = new ConfiguratorHost();

                this.Configuration = new Configuration(true);
                this.ConnectedServer = new OpcServerItem(true);

                // this.ConfiguredMeasurements = new ConfiguredMeasurements();
                this.ConfiguredMeasurements = this.GetDefaultConfiguredMeasurements();
                this.Configuration.ConfiguredMeasurements = this.ConfiguredMeasurements;
                
                this.ServiceDataReceiver = new ServiceDataReceiver();

                this.AllowNavigation = true;
                this.HomeVisibility = Visibility.Visible;
                this.IsEnabled = true;

                string manufacturerName = null;

                var settings = ImsOpcBridgeSettings.Singleton as ImsOpcBridgeSettings;

                if (settings != null)
                {
                    manufacturerName = settings.Manufacturer;
                }

                var applicationName = Resources.MainWindowVm_ApplicationName;
    
                this.ToolTipHome = Resources.Home; 
                this.ToolTipSettings = Resources.Settings;
                this.ToolTipAbout = Resources.HelpAbout;
                this.ToolTipExit = Resources.ExitApplication;

                this.ProgressViewModel = new ProgressVm();
                this.MessageAgentViewModel = new MessageAgentVm(this);

                this.SettingsViewModel = new SettingsVm(this);
                this.HowToUseViewModel = new HowToUseVm(this);

                this.Host.ApplicationName = applicationName;
                this.Host.Manufacturer = manufacturerName;

                this.Host.UserInterface.ToggleMessageAgent += this.MessageAgentViewModel.UserInterfaceOnToggleMessageAgent;

                this.monitorDataCtrlVm = new MonitorDataControlVm(this);
                this.eventLogControlVm = new EventLogControlVm(this);
                this.mappingControlVm = new MappingControlVm(this);
                this.serverControlVm = new ServerControlVm(this);

                this.OwnConfiguration = new OwnConfigurationControlVm();

                this.IsSettingsVisible = this.AllowNavigation;
                this.IsHowToUseVisible = this.AllowNavigation;

                this.OwnConfiguration.IsOwnConfigurationControlVisible = true;

                this.IsGoingHome = false;

                this.howToUseCommand = new DelegateCommand(this.GoToHowToUse);
                this.exitApplication = new DelegateCommand(this.ExitApplication);
                this.settingsCommand = new DelegateCommand(this.EditSettings);
                this.homeCommand = new DelegateCommand(this.Home);

                this.homeCommand.IsExecutable = true;
                this.howToUseCommand.IsExecutable = true;

                this.SettingsViewModel.DoShowDeviceCommands = false;

                this.timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.0) };
                this.timer.Start();
                this.timer.Tick += this.TimerTickEventHandler;

                this.byteArrayConfigurationStored = this.CreateByteArrayConfiguration();

                this.ServiceDataReceiver.ConfigurationResponse += this.HandleConfigurationResponse;
                this.ServiceDataReceiver.ServiceErrorResponse += this.HandleServiceErrorResponse;
                this.ServiceDataReceiver.SaveConfigurationResponse += this.HandleSaveConfigurationResponse;
                this.ServiceDataReceiver.FisRegistrationResponse += this.HandleFisRegistrationResponse;
                this.ServiceDataReceiver.DiagnosticsIndicationResponse += this.HandleDiagnosticsIndicationResponse;
                
                this.EmptyMenuChoice = new BaseSelectorControlViewModel();
                this.EmptyMenuChoice.SelectedItemChanged += this.ChoiceSelectedItemChangedHandler;
                this.EmptyMenuChoice.Items.Add(new BaseSelectorItemViewModel(Resources.Monitor, string.Empty, string.Empty, "automId_Monitor", HomeSection.Monitor, 1));
                this.EmptyMenuChoice.Items.Add(new BaseSelectorItemViewModel(Resources.OpcServer, string.Empty, string.Empty, "automId_OpcServer", HomeSection.Server, 2));
                this.EmptyMenuChoice.Items.Add(new BaseSelectorItemViewModel(Resources.Mapping, string.Empty, string.Empty, "automId_Mapping", HomeSection.Mapping, 3));
                this.EmptyMenuChoice.Items.Add(new BaseSelectorItemViewModel(Resources.EventLog, string.Empty, string.Empty, "automId_EventLog", HomeSection.EventLog, 4));
                ////this.EmptyMenuChoice.Items.Add(new BaseSelectorItemViewModel(string.Empty, string.Empty, string.Empty, "automId_Empty1", HomeSection.Default, 5));
                ////this.EmptyMenuChoice.Items.Add(new BaseSelectorItemViewModel(string.Empty, string.Empty, string.Empty, "automId_Empty2", HomeSection.Default, 6));

                ///// Log4Net
                //// var info = new FileInfo(@"C:\Test\Log4Net.xml");
                //// if (info.Exists)
                //// {
                ////     XmlConfigurator.Configure(info);
                //// }
                this.InitializeLogging();

                this.ClientStart();
                this.LoadConfiguration();

                this.Home();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether [allow navigation].
        /// </summary>
        /// <value><c>true</c> if [allow navigation]; otherwise, <c>false</c>.</value>
        public bool AllowNavigation { get; private set; }

        /// <summary>
        /// Gets the command items.
        /// </summary>
        /// <value>The command items.</value>
        public ObservableCollection<CommandItemVm> CommandItems
        {
            get
            {
                return (ObservableCollection<CommandItemVm>)this.GetValue(CommandItemsProperty);
            }

            private set
            {
                this.SetValue(CommandItemsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip exit.
        /// </summary>
        /// <value>The tool tip exit.</value>
        public string ToolTipExit
        {
            get
            {
                return (string)this.GetValue(ToolTipExitProperty);
            }

            set
            {
                this.SetValue(ToolTipExitProperty, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the tool tip home.
        /// </summary>
        /// <value>The tool tip home.</value>
        public string ToolTipHome
        {
            get
            {
                return (string)this.GetValue(ToolTipHomeProperty);
            }

            set
            {
                this.SetValue(ToolTipHomeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip settings.
        /// </summary>
        /// <value>The tool tip settings.</value>
        public string ToolTipSettings
        {
            get
            {
                return (string)this.GetValue(ToolTipSettingsProperty);
            }

            set
            {
                this.SetValue(ToolTipSettingsProperty, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the tool tip about.
        /// </summary>
        /// <value>The tool tip about.</value>
        public string ToolTipAbout
        {
            get
            {
                return (string)this.GetValue(ToolTipAboutProperty);
            }

            set
            {
                this.SetValue(ToolTipAboutProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public Configuration Configuration
        {
            get
            {
                return this.configuration;
            }

            set
            {
                this.configuration = value;
            }
        }

        /// <summary>
        /// Gets or sets the configured measurements.
        /// </summary>
        /// <value>The configured measurements.</value>
        public ConfiguredMeasurements ConfiguredMeasurements { get; set; }

        /// <summary>
        /// Gets or sets the connected server.
        /// </summary>
        /// <value>The connected server.</value>
        public OpcServerItem ConnectedServer { get; set; }

        /// <summary>
        /// Gets or sets the current navigation page vm.
        /// </summary>
        /// <value>The current navigation page vm.</value>
        public NavigationPageVm CurrentNavigationPageVm
        {
            get
            {
                return (NavigationPageVm)this.GetValue(CurrentNavigationPageVmProperty);
            }

            set
            {
                this.SetValue(CurrentNavigationPageVmProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current section.
        /// </summary>
        /// <value>The current section.</value>
        public HomeSection CurrentSection
        {
            get
            {
                return (HomeSection)this.GetValue(CurrentSectionProperty);
            }

            set
            {
                this.SetValue(CurrentSectionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current time.
        /// </summary>
        /// <value>The current time.</value>
        public DateTime CurrentTime
        {
            get
            {
                return (DateTime)this.GetValue(CurrentTimeProperty);
            }

            set
            {
                this.SetValue(CurrentTimeProperty, value);
            }
        }

        /// <summary>
        /// Gets the empty menu choice.
        /// </summary>
        /// <value>The empty menu choice.</value>
        public BaseSelectorControlViewModel EmptyMenuChoice
        {
            get
            {
                return (BaseSelectorControlViewModel)this.GetValue(EmptyMenuChoiceProperty);
            }

            private set
            {
                this.SetValue(EmptyMenuChoiceProperty, value);
            }
        }

        /// <summary>
        /// Gets the exit application command.
        /// </summary>
        /// <value>The exit application command.</value>
        public ICommand ExitApplicationCommand
        {
            get
            {
                return this.exitApplication;
            }
        }

        /// <summary>
        /// Gets the home command.
        /// </summary>
        /// <value>The home command.</value>
        public ICommand HomeCommand
        {
            get
            {
                return this.homeCommand;
            }
        }

        /// <summary>
        /// Gets or sets the home visibility.
        /// </summary>
        /// <value>The home visibility.</value>
        public Visibility HomeVisibility
        {
            get
            {
                return (Visibility)this.GetValue(HomeVisibilityProperty);
            }

            set
            {
                this.SetValue(HomeVisibilityProperty, value);
            }
        }

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>The host.</value>
        public IConfiguratorHost Host
        {
            get
            {
                return this.host;
            }
        }

        /// <summary>
        /// Gets the how to use command.
        /// </summary>
        /// <value>The how to use command.</value>
        public ICommand HowToUseCommand
        {
            get
            {
                return this.howToUseCommand;
            }
        }

        /// <summary>
        /// Gets or sets the how to use view model.
        /// </summary>
        /// <value>The how to use view model.</value>
        public HowToUseVm HowToUseViewModel
        {
            get
            {
                return (HowToUseVm)this.GetValue(HowToUseViewModelProperty);
            }

            set
            {
                this.SetValue(HowToUseViewModelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
        public bool IsEnabled
        {
            get
            {
                return (bool)this.GetValue(IsEnabledProperty);
            }

            set
            {
                this.SetValue(IsEnabledProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is going home.
        /// </summary>
        /// <value><c>true</c> if this instance is going home; otherwise, <c>false</c>.</value>
        public bool IsGoingHome { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is how to use visible.
        /// </summary>
        /// <value><c>true</c> if this instance is how to use visible; otherwise, <c>false</c>.</value>
        public bool IsHowToUseVisible
        {
            get
            {
                return (bool)this.GetValue(IsHowToUseVisibleProperty);
            }

            set
            {
                this.SetValue(IsHowToUseVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is settings visible.
        /// </summary>
        /// <value><c>true</c> if this instance is settings visible; otherwise, <c>false</c>.</value>
        public bool IsSettingsVisible
        {
            get
            {
                return (bool)this.GetValue(IsSettingsVisibleProperty);
            }

            set
            {
                this.SetValue(IsSettingsVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets the menu choice.
        /// </summary>
        /// <value>The menu choice.</value>
        public BaseSelectorControlViewModel MenuChoice
        {
            get
            {
                return (BaseSelectorControlViewModel)this.GetValue(MenuChoiceProperty);
            }

            private set
            {
                this.SetValue(MenuChoiceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the menu control.
        /// </summary>
        /// <value>The height of the menu control.</value>
        public double MenuControlHeight { get; set; }

        /// <summary>
        /// Gets or sets the width of the menu control.
        /// </summary>
        /// <value>The width of the menu control.</value>
        public double MenuControlWidth { get; set; }

        /// <summary>
        /// Gets or sets the message agent view model.
        /// </summary>
        /// <value>The message agent view model.</value>
        public MessageAgentVm MessageAgentViewModel
        {
            get
            {
                return (MessageAgentVm)this.GetValue(MessageAgentProperty);
            }

            set
            {
                this.SetValue(MessageAgentProperty, value);
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
        /// Gets the progress view model.
        /// </summary>
        /// <value>The progress view model.</value>
        public ProgressVm ProgressViewModel
        {
            get
            {
                return (ProgressVm)this.GetValue(ProgressViewModelProperty);
            }

            private set
            {
                this.SetValue(ProgressViewModelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the service data receiver.
        /// </summary>
        /// <value>The service data receiver.</value>
        public ServiceDataReceiver ServiceDataReceiver { get; set; }

        /// <summary>
        /// Gets the settings command.
        /// </summary>
        /// <value>The settings command.</value>
        public ICommand SettingsCommand
        {
            get
            {
                return this.settingsCommand;
            }
        }

        /// <summary>
        /// Gets the settings view model.
        /// </summary>
        /// <value>The settings view model.</value>
        public SettingsVm SettingsViewModel
        {
            get
            {
                return (SettingsVm)this.GetValue(SettingsVmProperty);
            }

            private set
            {
                this.SetValue(SettingsVmProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the wizard step.
        /// </summary>
        /// <value>The wizard step.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Returns value</exception>
        public WizardStep WizardStep
        {
            get
            {
                return (WizardStep)this.GetValue(WizardStepProperty);
            }

            set
            {
                if (this.WizardStep != value)
                {
                    // restricted must remain restricted
                    if (this.WizardStep == WizardStep.RestrictionWindow)
                    {
                        return;
                    }

                    this.SetValue(WizardStepProperty, value);

                    switch (value)
                    {
                        case WizardStep.Home:
                            break;

                        case WizardStep.HowToUse:

                            this.homeCommand.IsExecutable = true;
                            break;

                        case WizardStep.RestrictionWindow:

                            this.homeCommand.IsExecutable = false;
                            break;

                        case WizardStep.Settings:

                            this.homeCommand.IsExecutable = true;
                            break;

                        case WizardStep.Unknown:
                            break;

                        case WizardStep.DisplayMessage:
                            this.homeCommand.IsExecutable = true;
                            break;

                        case WizardStep.DisplayTextBox:
                            this.homeCommand.IsExecutable = true;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException("value");
                    }

                    this.UpdateMenuItems();
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Applications the is loaded.
        /// </summary>
        public void ApplicationIsLoaded()
        {
            if (this.Dispatcher.CheckAccess())
            {
            }
            else
            {
                this.Dispatcher.BeginInvoke(new Action(this.ApplicationIsLoaded));
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Exports the configuration.
        /// </summary>
        public void ExportConfiguration()
        {
            string path = this.GetExportPath();

            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    var client = new CommServerClient();
                    client.ExportConfigurationRequest(MainWindow.ClientUri, Guid.NewGuid(), this.Configuration, path);
                    client.Close();
                }
                catch (Exception exception)
                {
                    this.Host.UserInterface.DisplayMessage(exception.Message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
                }
            }
        }
        
        /// <summary>
        /// Clients the start.
        /// </summary>
        public void ClientStart()
        {
            try
            {
                var client = new CommServerClient();
                client.OnClientStartIndication(MainWindow.ClientUri);
                client.Close();
            }
            catch (Exception exception)
            {
                this.Host.UserInterface.DisplayMessage(exception.Message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Clients the stop.
        /// </summary>
        public void ClientStop()
        {
            try
            {
                var client = new CommServerClient();
                client.OnClientStopIndication(MainWindow.ClientUri);
                client.Close();
            }
            catch (Exception exception)
            {
                this.Host.UserInterface.DisplayMessage(exception.Message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Goes the home.
        /// </summary>
        public void GoHome()
        {
            if (!this.IsGoingHome)
            {
                this.IsGoingHome = true;
                Mouse.OverrideCursor = null;

                this.IsGoingHome = false;

                // Set Start Page
                this.CurrentSection = HomeSection.Monitor;
                this.EmptyMenuChoice.SelectItem(this.CurrentSection);
                this.monitorDataCtrlVm.HandleMeasurementsMonitor();
                this.OpenOwnConfiguration(this.CurrentSection);
                this.WizardStep = WizardStep.Home;
            }
        }

        /// <summary>
        /// Goes to how to use.
        /// </summary>
        public void GoToHowToUse()
        {
            this.OwnConfiguration.IsOwnConfigurationControlVisible = false;
            this.WizardStep = WizardStep.HowToUse;
        }

        /// <summary>
        /// Imports the configuration.
        /// </summary>
        public void ImportConfiguration()
        {
            string path = this.GetImportPath();

            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    var client = new CommServerClient();
                    client.ImportConfigurationRequest(MainWindow.ClientUri, Guid.NewGuid(), path);
                    client.Close();
                }
                catch (Exception exception)
                {
                    this.Host.UserInterface.DisplayMessage(exception.Message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
                }
            }
        }

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        public void LoadConfiguration()
        {
            try
            {
                var client = new CommServerClient();
                client.LoadConfigurationRequest(MainWindow.ClientUri, Guid.NewGuid());
                client.Close();
            }
            catch (Exception exception)
            {
                this.Host.UserInterface.DisplayMessage(exception.Message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        public void SaveConfiguration()
        {
            try
            {
                var client = new CommServerClient();

                // Update Mapping
                this.Configuration.ConfiguredMeasurements = this.ConfiguredMeasurements;

                client.SaveConfigurationRequest(MainWindow.ClientUri, Guid.NewGuid(), this.Configuration);
                client.Close();
            }
            catch (Exception exception)
            {
                this.Host.UserInterface.DisplayMessage(exception.Message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Clears the opc item mapping tree opc items.
        /// </summary>
        internal void ClearOpcItemMappingTreeOpcItems()
        {
            this.mappingControlVm.ClearOpcItemMappingTreeOpcItems();
        }

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
        /// Edits the settings.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        protected void EditSettings(object parameter)
        {
            SettingsSection section;
            if (Enum.TryParse(parameter as string, out section))
            {
                this.SettingsViewModel.CurrentSection = section;
            }

            this.WizardStep = WizardStep.Settings;

            this.OwnConfiguration.IsOwnConfigurationControlVisible = false;
        }

        /// <summary>
        /// Checks the is dirty configuration.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool CheckIsDirtyConfiguration()
        {
            var retVal = true;
            var byteArrayChanged = this.CreateByteArrayConfiguration();
            
            try
            {
                retVal = !byteArrayChanged.SequenceEqual(this.byteArrayConfigurationStored);
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat(@"CheckIsDirtyConfiguration failed. Reason: {0}.", ex.Message);
            }
           
            return retVal;
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

                    HomeSection section;

                    if (Enum.TryParse(e.SelectedItem.Value.ToString(), out section))
                    {
                        this.CurrentSection = section;
                        this.monitorDataCtrlVm.HandleMeasurementsMonitor();
                        this.OpenOwnConfiguration(section);
                    }
                }
            }
        }

        /// <summary>
        /// The create byte array configuration.
        /// </summary>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        private byte[] CreateByteArrayConfiguration()
        {
            var enc = new ASCIIEncoding();
            var byteArray = enc.GetBytes(string.Empty);

            try
            {
                var serializer = new DataContractSerializer(this.Configuration.GetType());

                using (var ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, this.Configuration);
                    byteArray = ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat(@"CreateByteArrayConfiguration failed. Reason: {0}.", ex.Message);
            }

            return byteArray;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    this.timer.Stop();
                    this.timer.Tick -= this.TimerTickEventHandler;
                    this.host.Dispose();
                    this.host = null;
                }
                
                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }

            this.disposed = true;
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        private void ExitApplication()
        {
            try
            {
                if (this.CheckIsDirtyConfiguration())
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.DoYouWantToSaveChangesYouMadeToTheDocument);

                    if (this.Host.UserInterface.DisplayMessage(message, Resources.SaveConfiguration, MessageButton.ButtonsYesNo, MessageType.MessageQuestion, DefaultMessageButton.ButtonNo) == ResultMessage.ButtonYes)
                    {
                        this.SaveConfiguration();
                    }
                }

                this.monitorDataCtrlVm.HandleMeasurementsMonitor();
                this.ClientStop();
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat(@"Handling 'Exit' click failed. Reason: {0}.", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Gets the default configured measurements.
        /// </summary>
        /// <returns>Returns ConfiguredMeasurements.</returns>
        private ConfiguredMeasurements GetDefaultConfiguredMeasurements()
        {
            var measurements = new ConfiguredMeasurements();

            for (int i = 0; i < 1; i++)
            {
                var measurement = new ConfiguredMeasurement(true);
                measurement.DeviceId = new ConfiguredMeasurementItem(true) { Value = string.Empty };
                measurement.SensorId = new ConfiguredMeasurementItem(true) { Value = string.Empty };
                measurement.Unit = new ConfiguredMeasurementItem(true) { Value = string.Empty, MappingType = MappingTypes.StaticType };
                measurement.DataType = CommonFormatDataTypes.FloatType;
                measurement.Timestamp = new ConfiguredMeasurementItem(true) { Value = string.Empty, MappingType = MappingTypes.OpcTimestampType };
                measurement.Quality = new ConfiguredMeasurementItem(true) { Value = string.Empty, MappingType = MappingTypes.OpcQualityType };
                measurement.Value = new ConfiguredMeasurementItem(true) { Value = string.Empty, MappingType = MappingTypes.OpcValueType };
                measurement.Active = true;
                measurements.Add(measurement);
            }

            return measurements;
        }

        /// <summary>
        /// Gets the export path.
        /// </summary>
        /// <returns>System String.</returns>
        private string GetExportPath()
        {
            var fileName = string.Empty;

            var dlg = new SaveFileDialog { FileName = @"ImsOpcBridgeConfiguration", DefaultExt = ".xml", Filter = "Text documents (.xml)|*.xml" };
            var result = dlg.ShowDialog();

            if (result == true)
            {
                fileName = dlg.FileName;
            }

            return fileName;
        }

        /// <summary>
        /// Gets the import path.
        /// </summary>
        /// <returns>System String.</returns>
        private string GetImportPath()
        {
            var fileName = string.Empty;

            var dlg = new OpenFileDialog { DefaultExt = ".xml", Filter = "XML Files (*.xml)|*.xml" };
            var result = dlg.ShowDialog();

            if (result == true)
            {
                fileName = dlg.FileName;
            }

            return fileName;
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
                this.Configuration = e.Configuration;
                this.Configuration.ConfiguredMeasurements = e.Configuration.ConfiguredMeasurements;
                this.ConfiguredMeasurements = e.Configuration.ConfiguredMeasurements;

                this.byteArrayConfigurationStored = this.CreateByteArrayConfiguration();

                if (HomeSection.Monitor == this.CurrentSection)
                {
                    this.monitorDataCtrlVm.HandleMeasurementsMonitor();
                    this.monitorDataCtrlVm.MonitorGridLoaded();
                }
            }
        }

        /// <summary>
        /// Handles the save configuration response.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EH.ImsOpcBridge.Configurator.EventArguments.ConfigurationDataEventArgs"/> instance containing the event data.</param>
        private void HandleSaveConfigurationResponse(object sender, EventArgs e)
        {
            this.byteArrayConfigurationStored = this.CreateByteArrayConfiguration();    
        }

        /// <summary>
        /// Handles the fis registration response.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void HandleFisRegistrationResponse(object sender, EventArgs e)
        {
            var message = string.Format(CultureInfo.CurrentUICulture, Resources.FISRegistrationSuccessfull);
            this.Host.UserInterface.DisplayMessage(message, Resources.ServiceCommunicationError, MessageButton.ButtonsOk, MessageType.MessageError);
        }

        /// <summary>
        /// Handles the diagnostics indication response.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void HandleDiagnosticsIndicationResponse(object sender, DiagnosticsDataEventArgs e)
        {
            if (e.DiagnosticsMessages != null)
            {
                foreach (var message in e.DiagnosticsMessages)
                {
                    this.Host.UserInterface.DisplayMessage(message, Resources.ServiceCommunicationError, MessageButton.ButtonsOk, MessageType.MessageError);
                }
            }
        }  
        
        /// <summary>
        /// Handles the service error response.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ServiceErrorDataEventArgs"/> instance containing the event data.</param>
        private void HandleServiceErrorResponse(object sender, ServiceErrorDataEventArgs e)
        {
            if (e.ServiceErrorData != null)
            {
                var message = e.ServiceErrorData;
                this.Host.UserInterface.DisplayMessage(message, Resources.ServiceCommunicationError, MessageButton.ButtonsOk, MessageType.MessageError);
            }
        }

        /// <summary>
        /// Homes this instance.
        /// </summary>
        private void Home()
        {
            this.GoHome();
        }

        /// <summary>
        /// Initializes the logging.
        /// </summary>
        private void InitializeLogging()
        {
            if (!Logging.LogManager.IsLoggingConfigured)
            {
                Logging.LogManager.ConfigureLogging(this.Host);
            }
        }

        /// <summary>
        /// Opens the own configuration.
        /// </summary>
        /// <param name="section">The section.</param>
        private void OpenOwnConfiguration(HomeSection section)
        {
            this.OwnConfiguration.IsOwnConfigurationControlVisible = true;

            //////var message = section.ToString() + string.Format(CultureInfo.CurrentUICulture, " selected ...");
            //////this.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            //////if (Logger.IsDebugEnabled)
            //////{
            //////    Logger.Debug(message);
            //////}

            switch (section)
            {
                case HomeSection.Monitor:
                    {
                        var page = new MonitorDataCtrl();
                        var viewModel = this.monitorDataCtrlVm;
                        this.GoToPage(page, viewModel);
                    }

                    break;

                case HomeSection.Server:
                    {
                        var page = new ServerControl();
                        var viewModel = this.serverControlVm;

                        // viewModel.UpdateParameters(this.Host.OpcServerItems);
                        viewModel.GetOpcServer();
                        this.GoToPage(page, viewModel);
                    }

                    break;

                case HomeSection.Mapping:
                    {
                        var page = new MappingControl();
                        var viewModel = this.mappingControlVm;
                        this.GoToPage(page, viewModel);
                    }

                    break;

                case HomeSection.EventLog:
                    {
                        var page = new EventLogControl();
                        var viewModel = this.eventLogControlVm;
                        this.GoToPage(page, viewModel);
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

        /// <summary>
        /// Timers the tick event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TimerTickEventHandler(object sender, EventArgs e)
        {
            this.CurrentTime = DateTime.Now;
        }

        /// <summary>
        /// Updates the menu items.
        /// </summary>
        private void UpdateMenuItems()
        {
            switch (this.WizardStep)
            {
                case WizardStep.Home:
                    this.CommandItems = null;
                    this.MenuChoice = this.EmptyMenuChoice;

                    this.IsSettingsVisible = this.AllowNavigation;
                    this.IsHowToUseVisible = this.AllowNavigation;
                    break;

                case WizardStep.HowToUse:
                    this.CommandItems = null;
                    this.MenuChoice = this.HowToUseViewModel.Choice;

                    this.IsSettingsVisible = false;
                    this.IsHowToUseVisible = false;
                    break;

                case WizardStep.Settings:
                    this.CommandItems = null;
                    this.MenuChoice = this.SettingsViewModel.Choice;

                    this.IsSettingsVisible = false;
                    this.IsHowToUseVisible = this.AllowNavigation;
                    break;

                default:
                    this.MenuChoice = this.EmptyMenuChoice;
                    this.IsSettingsVisible = false;
                    this.IsHowToUseVisible = false;
                    break;
            }
        }

        #endregion
    }
}