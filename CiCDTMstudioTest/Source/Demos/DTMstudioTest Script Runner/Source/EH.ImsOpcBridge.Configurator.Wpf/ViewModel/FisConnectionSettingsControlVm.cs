// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FisConnectionSettingsControlVm.cs" company="Endress+Hauser Process Solutions AG">
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
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.EventArguments;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class FisConnectionSettingsControlVm
    /// </summary>
    public class FisConnectionSettingsControlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The automation id property
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The check box label property
        /// </summary>
        public static readonly DependencyProperty CheckBoxLabelProperty = DependencyProperty.Register("CheckBoxLabel", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The is checked property
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(true, IsCheckedChanged));

        /// <summary>
        /// The login label1 property
        /// </summary>
        public static readonly DependencyProperty LoginLabel1Property = DependencyProperty.Register("LoginLabel1", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The login text property
        /// </summary>
        public static readonly DependencyProperty LoginTextProperty = DependencyProperty.Register("LoginText", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The pass word label2 property
        /// </summary>
        public static readonly DependencyProperty PassWordLabel2Property = DependencyProperty.Register("PassWordLabel2", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The pass word text property
        /// </summary>
        public static readonly DependencyProperty PassWordTextProperty = DependencyProperty.Register("PassWordText", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box1 text property
        /// </summary>
        public static readonly DependencyProperty TextBox1TextProperty = DependencyProperty.Register("TextBox1Text", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box2 text property
        /// </summary>
        public static readonly DependencyProperty TextBox2TextProperty = DependencyProperty.Register("TextBox2Text", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabel1Property = DependencyProperty.Register("TextBoxLabel1", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label2 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabel2Property = DependencyProperty.Register("TextBoxLabel2", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label unit1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelUnit1Property = DependencyProperty.Register("TextBoxLabelUnit1", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label unit2 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelUnit2Property = DependencyProperty.Register("TextBoxLabelUnit2", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The validation error property
        /// </summary>
        public static readonly DependencyProperty ValidationErrorProperty = DependencyProperty.Register("ValidationError", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(string.Empty, OnValidationErrorChanged));

        /// <summary>
        /// The button control label property
        /// </summary>
        public static readonly DependencyProperty ButtonControlLabelProperty = DependencyProperty.Register("ButtonControlLabel", typeof(string), typeof(FisConnectionSettingsControlVm), new PropertyMetadata(default(string)));
  
        #endregion

        #region Fields

        /// <summary>
        /// The main window view model
        /// </summary>
        private readonly MainWindowVm mainWindowViewModel;

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

        /// <summary>
        /// The fis registration
        /// </summary>
        private readonly DelegateCommand fisRegistration;
        
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FisConnectionSettingsControlVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException">@ mainWindowVm</exception>
        public FisConnectionSettingsControlVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.mainWindowViewModel = mainWindowVm;

            this.CheckBoxLabel = Resources.EnableConnection;

            this.TextBoxLabel1 = Resources.URL;
            this.TextBoxLabelUnit1 = string.Empty;

            // emilio temp: it was decided, 2015.01.22, to hide this label and textbox (Port Number).
            // this.TextBoxLabel2 = Resources.Port;
            this.TextBoxLabel2 = string.Empty;
            this.TextBoxLabelUnit2 = string.Empty;

            this.LoginLabel1 = Resources.Login;
            this.PassWordLabel2 = Resources.PassWord;

            this.ButtonControlLabel = Resources.FISRegistration;

            this.setTextBox1Text = new DelegateCommand(this.OnTextBox1Text);
            this.setTextBox2Text = new DelegateCommand(this.OnTextBox2Text);

            this.setPassWordText = new DelegateCommand(this.OnSetPassWordText);
            this.setLoginText = new DelegateCommand(this.OnSetLoginText);

            this.fisRegistration = new DelegateCommand(this.OnFisRegistration);
            
            this.TextBox1Text = string.Empty;
            this.TextBox2Text = string.Empty;
            this.LoginText = string.Empty;
            this.PassWordText = string.Empty;
            this.IsChecked = false;
            
            this.mainWindowViewModel.ServiceDataReceiver.ConfigurationResponse += this.HandleConfigurationResponse;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FisConnectionSettingsControlVm"/> class.
        /// </summary>
        public FisConnectionSettingsControlVm()
        {
            this.CheckBoxLabel = @"CheckBoxLabel";

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
        /// Gets the fis registration command.
        /// </summary>
        /// <value>The fis registration command.</value>
        public ICommand FisRegistrationCommand
        {
            get
            {
                return this.fisRegistration;
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

        #region Methods

        /// <summary>
        /// Determines whether [is checked changed] [the specified sender].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void IsCheckedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var fisConnectionSettingsControlVm = sender as FisConnectionSettingsControlVm;
            if (fisConnectionSettingsControlVm != null)
            {
                fisConnectionSettingsControlVm.mainWindowViewModel.Configuration.FisSettings.Enabled = fisConnectionSettingsControlVm.IsChecked;

                ////var message = string.Format(CultureInfo.CurrentUICulture, "IsCheckedChanged: ") + fisConnectionSettingsControlVm.IsChecked.ToString(CultureInfo.CurrentUICulture);
                ////fisConnectionSettingsControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Called when [validation error changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnValidationErrorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var fisConnectionSettingsControlVm = sender as FisConnectionSettingsControlVm;
            if ((fisConnectionSettingsControlVm != null) && !string.IsNullOrEmpty(fisConnectionSettingsControlVm.ValidationError))
            {
                var message = fisConnectionSettingsControlVm.ValidationError;
                fisConnectionSettingsControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
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
                this.TextBox1Text = e.Configuration.FisSettings.InternetAddress.Url;
                this.TextBox2Text = e.Configuration.FisSettings.InternetAddress.Port.ToString(CultureInfo.InvariantCulture);
                this.LoginText = e.Configuration.FisSettings.Authentication.User;
                this.PassWordText = e.Configuration.FisSettings.Authentication.Password;
                this.IsChecked = e.Configuration.FisSettings.Enabled;
            }
        }

        /// <summary>
        /// Called when [set login text].
        /// </summary>
        private void OnSetLoginText()
        {
            this.mainWindowViewModel.Configuration.FisSettings.Authentication.User = this.LoginText;
            ////var message = string.Format(CultureInfo.CurrentUICulture, "OnSetLoginText: ") + this.LoginText;
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
        }

        /// <summary>
        /// Called when [set pass word text].
        /// </summary>
        private void OnSetPassWordText()
        {
            this.mainWindowViewModel.Configuration.FisSettings.Authentication.Password = this.PassWordText;
            ////var message = string.Format(CultureInfo.CurrentUICulture, "OnSetPassWordText: ") + this.PassWordText;
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
        }
        
        /// <summary>
        /// Called when [fis registration].
        /// </summary>
        private void OnFisRegistration()
        {
            try
            {
                var client = new CommServerClient();
                client.FisRegistrationRequest(MainWindow.ClientUri, Guid.NewGuid());
                client.Close();
            }
            catch (Exception exception)
            {
                this.mainWindowViewModel.Host.UserInterface.DisplayMessage(exception.Message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        /// <summary>
        /// Called when [text box1 text].
        /// </summary>
        private void OnTextBox1Text()
        {
            this.mainWindowViewModel.Configuration.FisSettings.InternetAddress.Url = this.TextBox1Text;

            ////var message = string.Format(CultureInfo.CurrentUICulture, "OnTextBox1Tex: ") + this.TextBox1Text;
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
        }

        /// <summary>
        /// Called when [text box2 text].
        /// </summary>
        private void OnTextBox2Text()
        {
            int port;

            if (int.TryParse(this.TextBox2Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out port))
            {
                this.mainWindowViewModel.Configuration.FisSettings.InternetAddress.Port = port;

                ////var message = string.Format(CultureInfo.CurrentUICulture, "OnTextBox2Text: ") + this.mainWindowViewModel.Configuration.FisSettings.InternetAddress.Port.ToString(CultureInfo.InvariantCulture);
                ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        #endregion
    }
}