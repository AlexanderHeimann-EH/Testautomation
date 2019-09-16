// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BridgeGatewaySettingsControlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class BridgeSettingVm
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.EventArguments;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class BridgeGatewaySettingsControlVm
    /// </summary>
    public class BridgeGatewaySettingsControlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The activation key label2 property
        /// </summary>
        public static readonly DependencyProperty ActivationKeyLabel2Property = DependencyProperty.Register("ActivationKeyLabel2", typeof(string), typeof(BridgeGatewaySettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The activation key text property
        /// </summary>
        public static readonly DependencyProperty ActivationKeyTextProperty = DependencyProperty.Register("ActivationKeyText", typeof(string), typeof(BridgeGatewaySettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The automation id property
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(BridgeGatewaySettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The identification label1 property
        /// </summary>
        public static readonly DependencyProperty IdentificationLabel1Property = DependencyProperty.Register("IdentificationLabel1", typeof(string), typeof(BridgeGatewaySettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The button control label property
        /// </summary>
        public static readonly DependencyProperty ButtonControlLabelProperty = DependencyProperty.Register("ButtonControlLabel", typeof(string), typeof(BridgeGatewaySettingsControlVm), new PropertyMetadata(default(string)));
        
        /// <summary>
        /// The identification text property
        /// </summary>
        public static readonly DependencyProperty IdentificationTextProperty = DependencyProperty.Register("IdentificationText", typeof(string), typeof(BridgeGatewaySettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box1 text property
        /// </summary>
        public static readonly DependencyProperty TextBox1TextProperty = DependencyProperty.Register("TextBox1Text", typeof(string), typeof(BridgeGatewaySettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabel1Property = DependencyProperty.Register("TextBoxLabel1", typeof(string), typeof(BridgeGatewaySettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label unit1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelUnit1Property = DependencyProperty.Register("TextBoxLabelUnit1", typeof(string), typeof(BridgeGatewaySettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The validation error property
        /// </summary>
        public static readonly DependencyProperty ValidationErrorProperty = DependencyProperty.Register("ValidationError", typeof(string), typeof(BridgeGatewaySettingsControlVm), new PropertyMetadata(string.Empty, OnValidationErrorChanged));

        /// <summary>
        /// The validation rule text box1 property
        /// </summary>
        public static readonly DependencyProperty ValidationRuleTextBox1Property = DependencyProperty.Register("ValidationRuleTextBox1", typeof(string), typeof(BridgeGatewaySettingsControlVm), new PropertyMetadata(default(string)));

        #endregion

        #region Fields

        /// <summary>
        /// The main window view model
        /// </summary>
        private readonly MainWindowVm mainWindowViewModel;

        /// <summary>
        /// The set activation key text
        /// </summary>
        private readonly DelegateCommand setActivationKeyText;

        /// <summary>
        /// The set identification text
        /// </summary>
        private readonly DelegateCommand setIdentificationText;
        
        /// <summary>
        /// The generate activation key
        /// </summary>
        private readonly DelegateCommand generateActivationKey;

        /// <summary>
        /// The set text box1 text
        /// </summary>
        private readonly DelegateCommand setTextBox1Text;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BridgeGatewaySettingsControlVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException">@ mainWindowVm</exception>
        public BridgeGatewaySettingsControlVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.mainWindowViewModel = mainWindowVm;

            this.TextBoxLabel1 = Resources.Model;
            this.TextBoxLabelUnit1 = string.Empty;

            this.IdentificationLabel1 = Resources.UniqueIdentifier;
            this.ActivationKeyLabel2 = Resources.ActivationKey;
            this.ButtonControlLabel = Resources.GenerateActivationKey;

            this.setTextBox1Text = new DelegateCommand(this.OnTextBox1Text);

            this.setActivationKeyText = new DelegateCommand(this.OnSetActivationKeyText);
            this.setIdentificationText = new DelegateCommand(this.OnSetIdentificationText);
            this.generateActivationKey = new DelegateCommand(this.GenerateActivationKey);

            this.ActivationKeyText = string.Empty;
            this.IdentificationText = string.Empty;
            this.TextBox1Text = string.Empty;

            this.mainWindowViewModel.ServiceDataReceiver.ConfigurationResponse += this.HandleConfigurationResponse;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BridgeGatewaySettingsControlVm"/> class.
        /// </summary>
        public BridgeGatewaySettingsControlVm()
        {
            this.TextBoxLabel1 = @"Label1";
            this.TextBoxLabelUnit1 = @"Unit1";

            this.TextBox1Text = @"1234";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the activation key label2.
        /// </summary>
        /// <value>The activation key label2.</value>
        public string ActivationKeyLabel2
        {
            get
            {
                return (string)this.GetValue(ActivationKeyLabel2Property);
            }

            set
            {
                this.SetValue(ActivationKeyLabel2Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the activation key text.
        /// </summary>
        /// <value>The activation key text.</value>
        public string ActivationKeyText
        {
            get
            {
                return (string)this.GetValue(ActivationKeyTextProperty);
            }

            set
            {
                this.SetValue(ActivationKeyTextProperty, value);
            }
        }

        /// <summary>
        /// Gets the activation key text changed.
        /// </summary>
        /// <value>The activation key text changed.</value>
        public ICommand ActivationKeyTextChanged
        {
            get
            {
                return this.setActivationKeyText;
            }
        }

        /// <summary>
        /// Gets the generate activation key command.
        /// </summary>
        /// <value>The generate activation key command.</value>
        public ICommand GenerateActivationKeyCommand
        {
            get
            {
                return this.generateActivationKey;
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
        /// Gets or sets the identification label1.
        /// </summary>
        /// <value>The identification label1.</value>
        public string IdentificationLabel1
        {
            get
            {
                return (string)this.GetValue(IdentificationLabel1Property);
            }

            set
            {
                this.SetValue(IdentificationLabel1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the button control label.
        /// </summary>
        /// <value>The button control label.</value>
        public string ButtonControlLabel
        {
            get
            {
                return (string)this.GetValue(ButtonControlLabelProperty);
            }

            set
            {
                this.SetValue(ButtonControlLabelProperty, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the identification text.
        /// </summary>
        /// <value>The identification text.</value>
        public string IdentificationText
        {
            get
            {
                return (string)this.GetValue(IdentificationTextProperty);
            }

            set
            {
                this.SetValue(IdentificationTextProperty, value);
            }
        }

        /// <summary>
        /// Gets the identification text changed.
        /// </summary>
        /// <value>The identification text changed.</value>
        public ICommand IdentificationTextChanged
        {
            get
            {
                return this.setIdentificationText;
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
        /// Gets or sets the validation rule text box1.
        /// </summary>
        /// <value>The validation rule text box1.</value>
        public string ValidationRuleTextBox1
        {
            get
            {
                return (string)this.GetValue(ValidationRuleTextBox1Property);
            }

            set
            {
                this.SetValue(ValidationRuleTextBox1Property, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when [validation error changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnValidationErrorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var bridgeGatewaySettingsControlVm = sender as BridgeGatewaySettingsControlVm;
            if ((bridgeGatewaySettingsControlVm != null) && !string.IsNullOrEmpty(bridgeGatewaySettingsControlVm.ValidationError))
            {
                var message = bridgeGatewaySettingsControlVm.ValidationError;
                bridgeGatewaySettingsControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
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
                this.TextBox1Text = e.Configuration.Gateway.Model;
                this.IdentificationText = e.Configuration.Gateway.SerialNumber;
                this.ActivationKeyText = e.Configuration.Gateway.ActivationKey;
            }
        }

        /// <summary>
        /// Gets the M d5 hash.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System String.</returns>
        private string GetMd5Hash(string value)
        {
            using (var md5 = MD5.Create())
            {
                // ANSI (var char)
                var valueBytes = Encoding.Default.GetBytes(value);
                var md5HashBytes = md5.ComputeHash(valueBytes);
                var builder = new StringBuilder(md5HashBytes.Length * 2);
             
                foreach (var md5Byte in md5HashBytes)
                {
                    builder.Append(md5Byte.ToString("X2"));
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Called when [set activation key text].
        /// </summary>
        private void OnSetActivationKeyText()
        {
            //// this.mainWindowViewModel.Configuration.Gateway.ActivationKey = this.ActivationKeyText;
            //// var message = string.Format(CultureInfo.CurrentUICulture, "OnSetActivationKeyText: ") + this.ActivationKeyText;
            //// this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
        }

        /// <summary>
        /// Called when [set identification text].
        /// </summary>
        private void OnSetIdentificationText()
        {
            this.mainWindowViewModel.Configuration.Gateway.SerialNumber = this.IdentificationText;
            ////var message = string.Format(CultureInfo.CurrentUICulture, "OnSetIdentificationText: ") + this.IdentificationText;
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
        }
        
        /// <summary>
        /// Generates the activation key.
        /// </summary>
        private void GenerateActivationKey()
        {
            var activationKey = this.GetActivationKey(this.IdentificationText);
            
            this.ActivationKeyText = activationKey;
            this.mainWindowViewModel.Configuration.Gateway.ActivationKey = activationKey;
        }

        /// <summary>
        /// Gets the activation key.
        /// </summary>
        /// <param name="identification">The identification.</param>
        /// <returns>System .String.</returns>
        private string GetActivationKey(string identification)
        {
            // return this.ScrambleIdentification(identification);
            return this.FormatActivationKey(this.GetMd5Hash(this.ScrambleIdentification(identification)));
        }

        /// <summary>
        /// Formats the activation key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System String.</returns>
        private string FormatActivationKey(string key)
        {
            key = key.Substring(0, key.Length / 2);
            var activationKey = key;

            for (int i = 0; i < key.Length; i++)
            {
                var insert = (i + 1) % 5;

                if (insert == 0)
                {
                    activationKey = activationKey.Insert(i, @"-");
                }
            }

            return activationKey;       
        }

        /// <summary>
        /// Scrambles the identification.
        /// </summary>
        /// <param name="identification">The identification.</param>
        /// <returns>System String.</returns>
        private string ScrambleIdentification(string identification)
        {
            var scramble = string.Empty;

            if (identification.Length < 11)
            {
                return scramble; // or ErrorMessage?
            }

            var scrambleArray = identification.ToCharArray();

            scrambleArray[0] = identification[10];
            scrambleArray[1] = identification[9];
            scrambleArray[2] = identification[0];
            scrambleArray[3] = identification[1];
            scrambleArray[4] = identification[8];

            scrambleArray[5] = identification[7];
            scrambleArray[6] = identification[2];
            scrambleArray[7] = identification[3];

            scrambleArray[8] = identification[6];
            scrambleArray[9] = identification[5];
            scrambleArray[10] = identification[4];

            var scrambleSub = new string(scrambleArray);

            scramble = scrambleSub + identification[10] + @"/EH@";
            return scramble;
        }

        /// <summary>
        /// Called when [text box1 text].
        /// </summary>
        private void OnTextBox1Text()
        {
            this.mainWindowViewModel.Configuration.Gateway.Model = this.TextBox1Text;

            ////var message = string.Format(CultureInfo.CurrentUICulture, "OnTextBox1Tex: ") + this.TextBox1Text;
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
        }

        #endregion
    }
}