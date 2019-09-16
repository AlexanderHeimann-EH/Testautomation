// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplyCareWebServerSettingsControlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class BridgeSettingVm
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Net;
    using System.Net.Sockets;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.EventArguments;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class SupplyCareWebServerSettingsControlVm
    /// </summary>
    public class SupplyCareWebServerSettingsControlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The active network connection property
        /// </summary>
        public static readonly DependencyProperty ActiveNetworkConnectionProperty = DependencyProperty.Register("ActiveNetworkConnection", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The automation id property
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The check box label property
        /// </summary>
        public static readonly DependencyProperty CheckBoxLabelProperty = DependencyProperty.Register("CheckBoxLabel", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The combo box label1 property
        /// </summary>
        public static readonly DependencyProperty ComboBoxLabel1Property = DependencyProperty.Register("ComboBoxLabel1", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The is checked property
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(true, IsCheckedChanged));

        /// <summary>
        /// The login label1 property
        /// </summary>
        public static readonly DependencyProperty LoginLabel1Property = DependencyProperty.Register("LoginLabel1", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The login text property
        /// </summary>
        public static readonly DependencyProperty LoginTextProperty = DependencyProperty.Register("LoginText", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The network connections property
        /// </summary>
        public static readonly DependencyProperty NetworkConnectionsProperty = DependencyProperty.Register("NetworkConnections", typeof(ObservableCollection<string>), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(ObservableCollection<string>)));

        /// <summary>
        /// The network properties label property
        /// </summary>
        public static readonly DependencyProperty NetworkPropertiesLabelProperty = DependencyProperty.Register("NetworkPropertiesLabel", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The pass word label2 property
        /// </summary>
        public static readonly DependencyProperty PassWordLabel2Property = DependencyProperty.Register("PassWordLabel2", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The pass word text property
        /// </summary>
        public static readonly DependencyProperty PassWordTextProperty = DependencyProperty.Register("PassWordText", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The properties text property
        /// </summary>
        public static readonly DependencyProperty PropertiesTextProperty = DependencyProperty.Register("PropertiesText", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box1 text property
        /// </summary>
        public static readonly DependencyProperty TextBox1TextProperty = DependencyProperty.Register("TextBox1Text", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box2 text property
        /// </summary>
        public static readonly DependencyProperty TextBox2TextProperty = DependencyProperty.Register("TextBox2Text", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabel1Property = DependencyProperty.Register("TextBoxLabel1", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label2 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabel2Property = DependencyProperty.Register("TextBoxLabel2", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label unit1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelUnit1Property = DependencyProperty.Register("TextBoxLabelUnit1", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label unit2 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelUnit2Property = DependencyProperty.Register("TextBoxLabelUnit2", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The validation error property
        /// </summary>
        public static readonly DependencyProperty ValidationErrorProperty = DependencyProperty.Register("ValidationError", typeof(string), typeof(SupplyCareWebServerSettingsControlVm), new PropertyMetadata(string.Empty, OnValidationErrorChanged));

        #endregion

        #region Fields

        /// <summary>
        /// The main window view model
        /// </summary>
        private readonly MainWindowVm mainWindowViewModel;

        /// <summary>
        /// The network connections changed
        /// </summary>
        private readonly DelegateCommand networkConnectionsChanged;

        /// <summary>
        /// The set login text
        /// </summary>
        private readonly DelegateCommand setLoginText;

        /// <summary>
        /// The set pass word text
        /// </summary>
        private readonly DelegateCommand setPassWordText;

        /// <summary>
        /// The set text box1 text
        /// </summary>
        private readonly DelegateCommand setTextBox1Text;

        /// <summary>
        /// The set text box2 text
        /// </summary>
        private readonly DelegateCommand setTextBox2Text;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplyCareWebServerSettingsControlVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException">@ mainWindowVm</exception>
        public SupplyCareWebServerSettingsControlVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.mainWindowViewModel = mainWindowVm;

            this.CheckBoxLabel = Resources.EnableAuthentication;
            this.ComboBoxLabel1 = Resources.NetworkConnections;

            this.NetworkPropertiesLabel = Resources.Properties;

            this.TextBoxLabel1 = string.Empty;
            this.TextBoxLabelUnit1 = string.Empty;
            this.TextBoxLabel2 = Resources.Port;
            this.TextBoxLabelUnit2 = string.Empty;

            this.LoginLabel1 = Resources.Login;
            this.PassWordLabel2 = Resources.PassWord;

            this.NetworkConnections = new ObservableCollection<string>();
            this.networkConnectionsChanged = new DelegateCommand(this.OnNetworkConnectionChanged);

            this.setTextBox1Text = new DelegateCommand(this.OnTextBox1Text);
            this.setTextBox2Text = new DelegateCommand(this.OnTextBox2Text);

            this.setPassWordText = new DelegateCommand(this.OnSetPassWordText);
            this.setLoginText = new DelegateCommand(this.OnSetLoginText);

            this.TextBox2Text = string.Empty;
            this.LoginText = string.Empty;
            this.PassWordText = string.Empty;
            this.IsChecked = false;

            //////this.InitializeViewControls();

            this.mainWindowViewModel.ServiceDataReceiver.ConfigurationResponse += this.HandleConfigurationResponse;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplyCareWebServerSettingsControlVm"/> class.
        /// </summary>
        public SupplyCareWebServerSettingsControlVm()
        {
            this.TextBoxLabel1 = @"Label1";
            this.TextBoxLabelUnit1 = @"Unit1";
            this.TextBoxLabel2 = @"Label2";
            this.TextBoxLabelUnit2 = @"Unit2";

            this.TextBox1Text = @"1234";
            this.TextBox2Text = @"ABCD";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the active network connection.
        /// </summary>
        /// <value>The active network connection.</value>
        public string ActiveNetworkConnection
        {
            get
            {
                return (string)this.GetValue(ActiveNetworkConnectionProperty);
            }

            set
            {
                this.SetValue(ActiveNetworkConnectionProperty, value);
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
        /// Gets or sets the check box label.
        /// </summary>
        /// <value>The check box label.</value>
        public string CheckBoxLabel
        {
            get
            {
                return (string)this.GetValue(CheckBoxLabelProperty);
            }

            set
            {
                this.SetValue(CheckBoxLabelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the combo box label1.
        /// </summary>
        /// <value>The combo box label1.</value>
        public string ComboBoxLabel1
        {
            get
            {
                return (string)this.GetValue(ComboBoxLabel1Property);
            }

            set
            {
                this.SetValue(ComboBoxLabel1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked.
        /// </summary>
        /// <value><c>true</c> if this instance is checked; otherwise, <c>false</c>.</value>
        public bool IsChecked
        {
            get
            {
                return (bool)this.GetValue(IsCheckedProperty);
            }

            set
            {
                this.SetValue(IsCheckedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the login label1.
        /// </summary>
        /// <value>The login label1.</value>
        public string LoginLabel1
        {
            get
            {
                return (string)this.GetValue(LoginLabel1Property);
            }

            set
            {
                this.SetValue(LoginLabel1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the login text.
        /// </summary>
        /// <value>The login text.</value>
        public string LoginText
        {
            get
            {
                return (string)this.GetValue(LoginTextProperty);
            }

            set
            {
                this.SetValue(LoginTextProperty, value);
            }
        }

        /// <summary>
        /// Gets the login text changed.
        /// </summary>
        /// <value>The login text changed.</value>
        public ICommand LoginTextChanged
        {
            get
            {
                return this.setLoginText;
            }
        }

        /// <summary>
        /// Gets the network connection changed.
        /// </summary>
        /// <value>The network connection changed.</value>
        public ICommand NetworkConnectionChanged
        {
            get
            {
                return this.networkConnectionsChanged;
            }
        }

        /// <summary>
        /// Gets or sets the network connections.
        /// </summary>
        /// <value>The network connections.</value>
        public ObservableCollection<string> NetworkConnections
        {
            get
            {
                return (ObservableCollection<string>)this.GetValue(NetworkConnectionsProperty);
            }

            set
            {
                this.SetValue(NetworkConnectionsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the network properties label.
        /// </summary>
        /// <value>The network properties label.</value>
        public string NetworkPropertiesLabel
        {
            get
            {
                return (string)this.GetValue(NetworkPropertiesLabelProperty);
            }

            set
            {
                this.SetValue(NetworkPropertiesLabelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the pass word label2.
        /// </summary>
        /// <value>The pass word label2.</value>
        public string PassWordLabel2
        {
            get
            {
                return (string)this.GetValue(PassWordLabel2Property);
            }

            set
            {
                this.SetValue(PassWordLabel2Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the pass word text.
        /// </summary>
        /// <value>The pass word text.</value>
        public string PassWordText
        {
            get
            {
                return (string)this.GetValue(PassWordTextProperty);
            }

            set
            {
                this.SetValue(PassWordTextProperty, value);
            }
        }

        /// <summary>
        /// Gets the pass word text changed.
        /// </summary>
        /// <value>The pass word text changed.</value>
        public ICommand PassWordTextChanged
        {
            get
            {
                return this.setPassWordText;
            }
        }

        /// <summary>
        /// Gets or sets the properties text.
        /// </summary>
        /// <value>The properties text.</value>
        public string PropertiesText
        {
            get
            {
                return (string)this.GetValue(PropertiesTextProperty);
            }

            set
            {
                this.SetValue(PropertiesTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box1 text.
        /// </summary>
        /// <value>The text box1 text.</value>
        public string TextBox1Text
        {
            get
            {
                return (string)this.GetValue(TextBox1TextProperty);
            }

            set
            {
                this.SetValue(TextBox1TextProperty, value);
            }
        }

        /// <summary>
        /// Gets the text box1 text changed.
        /// </summary>
        /// <value>The text box1 text changed.</value>
        public ICommand TextBox1TextChanged
        {
            get
            {
                return this.setTextBox1Text;
            }
        }

        /// <summary>
        /// Gets or sets the text box2 text.
        /// </summary>
        /// <value>The text box2 text.</value>
        public string TextBox2Text
        {
            get
            {
                return (string)this.GetValue(TextBox2TextProperty);
            }

            set
            {
                this.SetValue(TextBox2TextProperty, value);
            }
        }

        /// <summary>
        /// Gets the text box2 text changed.
        /// </summary>
        /// <value>The text box2 text changed.</value>
        public ICommand TextBox2TextChanged
        {
            get
            {
                return this.setTextBox2Text;
            }
        }

        /// <summary>
        /// Gets or sets the text box label1.
        /// </summary>
        /// <value>The text box label1.</value>
        public string TextBoxLabel1
        {
            get
            {
                return (string)this.GetValue(TextBoxLabel1Property);
            }

            set
            {
                this.SetValue(TextBoxLabel1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box label2.
        /// </summary>
        /// <value>The text box label2.</value>
        public string TextBoxLabel2
        {
            get
            {
                return (string)this.GetValue(TextBoxLabel2Property);
            }

            set
            {
                this.SetValue(TextBoxLabel2Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box label unit1.
        /// </summary>
        /// <value>The text box label unit1.</value>
        public string TextBoxLabelUnit1
        {
            get
            {
                return (string)this.GetValue(TextBoxLabelUnit1Property);
            }

            set
            {
                this.SetValue(TextBoxLabelUnit1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box label unit2.
        /// </summary>
        /// <value>The text box label unit2.</value>
        public string TextBoxLabelUnit2
        {
            get
            {
                return (string)this.GetValue(TextBoxLabelUnit2Property);
            }

            set
            {
                this.SetValue(TextBoxLabelUnit2Property, value);
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

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Determines whether [is I PV4] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [is I PV4] [the specified value]; otherwise, <c>false</c>.</returns>
        public bool IsIPv4(string value)
        {
            IPAddress address;

            if (IPAddress.TryParse(value, out address))
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether [is checked changed] [the specified sender].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void IsCheckedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var supplyCareWebServerSettingsControlVm = sender as SupplyCareWebServerSettingsControlVm;
            if (supplyCareWebServerSettingsControlVm != null)
            {
                supplyCareWebServerSettingsControlVm.mainWindowViewModel.Configuration.SupplyCareSettings.Authentication.Active = supplyCareWebServerSettingsControlVm.IsChecked;

                // var message = string.Format(CultureInfo.CurrentUICulture, "IsCheckedChanged: ") + supplyCareWebServerSettingsControlVm.IsChecked.ToString(CultureInfo.CurrentUICulture);
                // supplyCareWebServerSettingsControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Called when [validation error changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnValidationErrorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var supplyCareWebServerSettingsControlVm = sender as SupplyCareWebServerSettingsControlVm;
            if ((supplyCareWebServerSettingsControlVm != null) && !string.IsNullOrEmpty(supplyCareWebServerSettingsControlVm.ValidationError))
            {
                var message = supplyCareWebServerSettingsControlVm.ValidationError;
                supplyCareWebServerSettingsControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Gets the ip address.
        /// </summary>
        /// <param name="macAddress">The mac address.</param>
        /// <returns>System String.</returns>
        private string GetIpAddress(string macAddress)
        {
            string networkAddress = string.Empty;

            var p = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

            foreach (var networkInterface in p)
            {
                if (macAddress == networkInterface.GetPhysicalAddress().ToString())
                {
                    foreach (var pp in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        networkAddress = pp.Address.ToString();
                        break;
                    }
                }
            }

            return networkAddress;
        }

        /// <summary>
        /// Gets the mac address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>System String.</returns>
        private string GetMacAddress(string address)
        {
            string macAddress = string.Empty;

            var p = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

            foreach (var networkInterface in p)
            {
                foreach (var pp in networkInterface.GetIPProperties().UnicastAddresses)
                {
                    if (address == pp.Address.ToString())
                    {
                        macAddress = networkInterface.GetPhysicalAddress().ToString();
                        break;
                    }
                }
            }

            return macAddress;
        }

        /// <summary>
        /// Gets the network properties.
        /// </summary>
        /// <param name="macAddress">The mac address.</param>
        /// <returns>System String.</returns>
        private string GetNetworkProperties(string macAddress)
        {
            string properties = string.Empty;

            var p = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

            foreach (var networkInterface in p)
            {
                if (macAddress == networkInterface.GetPhysicalAddress().ToString())
                {
                    // properties = string.Format(CultureInfo.InvariantCulture, @"{0} \r\n MAC Address: {1}", networkInterface.Description, networkInterface.GetPhysicalAddress().ToString());
                    properties = string.Format(CultureInfo.InvariantCulture, @"{0}", networkInterface.Description);
                    break;
                }
            }

            return properties;
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <returns>System String.</returns>
        private string GetUrl()
        {
            return string.Format(CultureInfo.InvariantCulture, @"http://{0}:{1}@{2}:{3}/index.html", this.LoginText, this.PassWordText, this.ActiveNetworkConnection, this.TextBox2Text);
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
                ////this.TextBox1Text = e.Configuration.SupplyCareSettings.InternetAddress.Url;
                this.TextBox2Text = e.Configuration.SupplyCareSettings.Port.ToString(CultureInfo.InvariantCulture);
                this.LoginText = e.Configuration.SupplyCareSettings.Authentication.User;
                this.PassWordText = e.Configuration.SupplyCareSettings.Authentication.Password;
                this.IsChecked = e.Configuration.SupplyCareSettings.Authentication.Active;
                ////this.ActiveNetworkConnection = this.GetIpAddress(e.Configuration.SupplyCareSettings.MacAddress);
                ////this.PropertiesText = this.GetNetworkProperties(e.Configuration.SupplyCareSettings.MacAddress);
            }
        }

        /// <summary>
        /// Initializes the view controls.
        /// </summary>
        private void InitializeViewControls()
        {
            var p = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

            foreach (var networkInterface in p)
            {
                if (!string.IsNullOrEmpty(networkInterface.GetPhysicalAddress().ToString()))
                {
                    foreach (var pp in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (this.IsIPv4(pp.Address.ToString()))
                        {
                            this.NetworkConnections.Add(pp.Address.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called when [network connection changed].
        /// </summary>
        private void OnNetworkConnectionChanged()
        {
            if (!string.IsNullOrEmpty(this.ActiveNetworkConnection))
            {
                ////this.mainWindowViewModel.Configuration.SupplyCareSettings.MacAddress = this.GetMacAddress(this.ActiveNetworkConnection);
                ////this.PropertiesText = this.GetNetworkProperties(this.mainWindowViewModel.Configuration.SupplyCareSettings.MacAddress);
                ////this.TextBox1Text = this.GetUrl();
            }
        }

        /// <summary>
        /// Called when [set login text].
        /// </summary>
        private void OnSetLoginText()
        {
            this.mainWindowViewModel.Configuration.SupplyCareSettings.Authentication.User = this.LoginText;
            ////this.TextBox1Text = this.GetUrl();

            ////var message = string.Format(CultureInfo.CurrentUICulture, "OnSetLoginText: ") + this.LoginText;
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
        }

        /// <summary>
        /// Called when [set pass word text].
        /// </summary>
        private void OnSetPassWordText()
        {
            this.mainWindowViewModel.Configuration.SupplyCareSettings.Authentication.Password = this.PassWordText;
            ////this.TextBox1Text = this.GetUrl();

            ////var message = string.Format(CultureInfo.CurrentUICulture, "OnSetPassWordText: ") + this.PassWordText;
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
        }

        /// <summary>
        /// Called when [text box1 text].
        /// </summary>
        private void OnTextBox1Text()
        {
            //////this.mainWindowViewModel.Configuration.SupplyCareSettings.InternetAddress.Url = this.TextBox1Text;

            ////var message = string.Format(CultureInfo.CurrentUICulture, "OnTextBox1Text: ") + this.mainWindowViewModel.Configuration.SupplyCareSettings.InternetAddress.Url;
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
        }

        ////private static void TestIpAddresses()
        ////{
        ////    System.Diagnostics.Debug.WriteLine("***********************************");
        ////    var localIPs = Dns.GetHostAddresses(Dns.GetHostName());
        ////    foreach (IPAddress addr in localIPs)
        ////    {
        ////        System.Diagnostics.Debug.WriteLine(addr);
        ////    }
        ////    System.Diagnostics.Debug.WriteLine("***********************************");
        ////    System.Diagnostics.Debug.WriteLine("***********************************");
        ////    var p = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
        ////    foreach (var networkInterface in p)
        ////    {
        ////        System.Diagnostics.Debug.WriteLine("***********************************");
        ////        System.Diagnostics.Debug.WriteLine(networkInterface.Name);
        ////        System.Diagnostics.Debug.WriteLine(networkInterface.Description);
        ////        System.Diagnostics.Debug.WriteLine(networkInterface.NetworkInterfaceType);
        ////        System.Diagnostics.Debug.WriteLine(networkInterface.GetPhysicalAddress().ToString());
        ////        System.Diagnostics.Debug.WriteLine("  UnicastAddresses");
        ////        foreach (var pp in networkInterface.GetIPProperties().UnicastAddresses)
        ////        {
        ////            System.Diagnostics.Debug.WriteLine("    " + pp.Address.ToString());
        ////        }
        ////    }
        ////}

        /// <summary>
        /// Called when [text box2 text].
        /// </summary>
        private void OnTextBox2Text()
        {
            int port;

            if (int.TryParse(this.TextBox2Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out port))
            {
                this.mainWindowViewModel.Configuration.SupplyCareSettings.Port = port;
                ////this.TextBox1Text = this.GetUrl();

                ////var message = string.Format(CultureInfo.CurrentUICulture, "OnTextBox2Text: ") + this.mainWindowViewModel.Configuration.SupplyCareSettings.Port.ToString(CultureInfo.InvariantCulture);
                ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        #endregion
    }
}