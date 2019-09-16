// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplyCareSamplingRateSettingsControlVm.cs" company="Endress+Hauser Process Solutions AG">
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
    /// Class SupplyCareSamplingRateSettingsControlVm
    /// </summary>
    public class SupplyCareSamplingRateSettingsControlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The automation id property
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(SupplyCareSamplingRateSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box1 text property
        /// </summary>
        public static readonly DependencyProperty TextBox1TextProperty = DependencyProperty.Register("TextBox1Text", typeof(string), typeof(SupplyCareSamplingRateSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabel1Property = DependencyProperty.Register("TextBoxLabel1", typeof(string), typeof(SupplyCareSamplingRateSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label unit1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelUnit1Property = DependencyProperty.Register("TextBoxLabelUnit1", typeof(string), typeof(SupplyCareSamplingRateSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The validation error property
        /// </summary>
        public static readonly DependencyProperty ValidationErrorProperty = DependencyProperty.Register("ValidationError", typeof(string), typeof(SupplyCareSamplingRateSettingsControlVm), new PropertyMetadata(string.Empty, OnValidationErrorChanged));

        #endregion

        #region Fields

        /// <summary>
        /// The main window view model
        /// </summary>
        private readonly MainWindowVm mainWindowViewModel;

        /// <summary>
        /// The set text box1 text
        /// </summary>
        private readonly DelegateCommand setTextBox1Text;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplyCareSamplingRateSettingsControlVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException">@ mainWindowVm</exception>
        public SupplyCareSamplingRateSettingsControlVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.mainWindowViewModel = mainWindowVm;

            this.TextBoxLabel1 = Resources.Interval;
            this.TextBoxLabelUnit1 = Resources.LabelUnitStartTime;
            
            this.setTextBox1Text = new DelegateCommand(this.OnTextBox1Text);
            this.TextBox1Text = string.Empty;

            this.mainWindowViewModel.ServiceDataReceiver.ConfigurationResponse += this.HandleConfigurationResponse;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplyCareSamplingRateSettingsControlVm"/> class.
        /// </summary>
        public SupplyCareSamplingRateSettingsControlVm()
        {
            this.TextBoxLabel1 = @"Label1";
            this.TextBoxLabelUnit1 = @"Unit1";

            this.TextBox1Text = @"1234";
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

        #endregion

        #region Methods

        /// <summary>
        /// Called when [validation error changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnValidationErrorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var supplyCareSamplingRateSettingsControlVm = sender as SupplyCareSamplingRateSettingsControlVm;
            if ((supplyCareSamplingRateSettingsControlVm != null) && !string.IsNullOrEmpty(supplyCareSamplingRateSettingsControlVm.ValidationError))
            {
                var message = supplyCareSamplingRateSettingsControlVm.ValidationError;
                supplyCareSamplingRateSettingsControlVm.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
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
                this.TextBox1Text = e.Configuration.SupplyCareSettings.SamplingRate.ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Called when [text box1 text].
        /// </summary>
        private void OnTextBox1Text()
        {
            int samplingRate;

            if (int.TryParse(this.TextBox1Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out samplingRate))
            {
                this.mainWindowViewModel.Configuration.SupplyCareSettings.SamplingRate = samplingRate;

                ////var message = string.Format(CultureInfo.CurrentUICulture, "OnTextBox1Text: ") + this.mainWindowViewModel.Configuration.SupplyCareSettings.SamplingRate.ToString(CultureInfo.InvariantCulture);
                ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
            }
        }

        #endregion
    }
}