// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FisTimeScheduleSettingsControlVm.cs" company="Endress+Hauser Process Solutions AG">
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
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.EventArguments;
    using EH.ImsOpcBridge.Configurator.Properties;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class FisTimeScheduleSettingsControlVm
    /// </summary>
    public class FisTimeScheduleSettingsControlVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The active sampling rate property
        /// </summary>
        public static readonly DependencyProperty ActiveSamplingRateProperty = DependencyProperty.Register("ActiveSamplingRate", typeof(string), typeof(FisTimeScheduleSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The automation id property
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(FisTimeScheduleSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The combo box label property
        /// </summary>
        public static readonly DependencyProperty ComboBoxLabelProperty = DependencyProperty.Register("ComboBoxLabel", typeof(string), typeof(FisTimeScheduleSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The combo box label unit property
        /// </summary>
        public static readonly DependencyProperty ComboBoxLabelUnitProperty = DependencyProperty.Register("ComboBoxLabelUnit", typeof(string), typeof(FisTimeScheduleSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The sampling rates property
        /// </summary>
        public static readonly DependencyProperty SamplingRatesProperty = DependencyProperty.Register("SamplingRates", typeof(ObservableCollection<string>), typeof(FisTimeScheduleSettingsControlVm), new PropertyMetadata(default(ObservableCollection<string>)));

        /// <summary>
        /// The text box label property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelProperty = DependencyProperty.Register("TextBoxLabel", typeof(string), typeof(FisTimeScheduleSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box label unit property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelUnitProperty = DependencyProperty.Register("TextBoxLabelUnit", typeof(string), typeof(FisTimeScheduleSettingsControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text box text property
        /// </summary>
        public static readonly DependencyProperty TextBoxTextProperty = DependencyProperty.Register("TextBoxText", typeof(string), typeof(FisTimeScheduleSettingsControlVm), new PropertyMetadata(default(string)));

        #endregion

        #region Fields

        /// <summary>
        /// The main window view model
        /// </summary>
        private readonly MainWindowVm mainWindowViewModel;

        /// <summary>
        /// The sampling rates selection changed
        /// </summary>
        private readonly DelegateCommand samplingRatesSelectionChanged;

        /// <summary>
        /// The set text box text
        /// </summary>
        private readonly DelegateCommand setTextBoxText;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FisTimeScheduleSettingsControlVm"/> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        /// <exception cref="System.ArgumentNullException"> @ mainWindowVm</exception>
        public FisTimeScheduleSettingsControlVm(MainWindowVm mainWindowVm)
        {
            if (mainWindowVm == null)
            {
                throw new ArgumentNullException(@"mainWindowVm");
            }

            this.mainWindowViewModel = mainWindowVm;
            this.SamplingRates = new ObservableCollection<string>();

            this.ComboBoxLabel = Resources.Interval;
            this.ComboBoxLabelUnit = string.Empty;

            this.TextBoxLabel = string.Empty;
            this.TextBoxLabelUnit = string.Empty;

            this.setTextBoxText = new DelegateCommand(this.OnSetTextBoxText);
            this.samplingRatesSelectionChanged = new DelegateCommand(this.OnSamplingRatesSelectionChanged);

            this.ActiveSamplingRate = string.Empty;

            this.mainWindowViewModel.ServiceDataReceiver.ConfigurationResponse += this.HandleConfigurationResponse;

            this.InitializeViewControls();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FisTimeScheduleSettingsControlVm"/> class.
        /// </summary>
        public FisTimeScheduleSettingsControlVm()
        {
            this.ComboBoxLabel = @"ComboBoxLabel";
            this.ComboBoxLabelUnit = @"ComboBoxUnit";

            this.TextBoxLabel = @"TextBoxLabel";
            this.TextBoxLabelUnit = @"TextBoxUnit";

            this.TextBoxText = @"XYZ";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the active sampling rate.
        /// </summary>
        /// <value>The active sampling rate.</value>
        public string ActiveSamplingRate
        {
            get
            {
                return (string)this.GetValue(ActiveSamplingRateProperty);
            }

            set
            {
                this.SetValue(ActiveSamplingRateProperty, value);
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
        /// Gets or sets the combo box label.
        /// </summary>
        /// <value>The combo box label.</value>
        public string ComboBoxLabel
        {
            get
            {
                return (string)this.GetValue(ComboBoxLabelProperty);
            }

            set
            {
                this.SetValue(ComboBoxLabelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the combo box label unit.
        /// </summary>
        /// <value>The combo box label unit.</value>
        public string ComboBoxLabelUnit
        {
            get
            {
                return (string)this.GetValue(ComboBoxLabelUnitProperty);
            }

            set
            {
                this.SetValue(ComboBoxLabelUnitProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the sampling rates.
        /// </summary>
        /// <value>The sampling rates.</value>
        public ObservableCollection<string> SamplingRates
        {
            get
            {
                return (ObservableCollection<string>)this.GetValue(SamplingRatesProperty);
            }

            set
            {
                this.SetValue(SamplingRatesProperty, value);
            }
        }

        /// <summary>
        /// Gets the sampling rates selection changed.
        /// </summary>
        /// <value>The sampling rates selection changed.</value>
        public ICommand SamplingRatesSelectionChanged
        {
            get
            {
                return this.samplingRatesSelectionChanged;
            }
        }

        /// <summary>
        /// Gets or sets the text box label.
        /// </summary>
        /// <value>The text box label.</value>
        public string TextBoxLabel
        {
            get
            {
                return (string)this.GetValue(TextBoxLabelProperty);
            }

            set
            {
                this.SetValue(TextBoxLabelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box label unit.
        /// </summary>
        /// <value>The text box label unit.</value>
        public string TextBoxLabelUnit
        {
            get
            {
                return (string)this.GetValue(TextBoxLabelUnitProperty);
            }

            set
            {
                this.SetValue(TextBoxLabelUnitProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box text.
        /// </summary>
        /// <value>The text box text.</value>
        public string TextBoxText
        {
            get
            {
                return (string)this.GetValue(TextBoxTextProperty);
            }

            set
            {
                this.SetValue(TextBoxTextProperty, value);
            }
        }

        /// <summary>
        /// Gets the text box text changed.
        /// </summary>
        /// <value>The text box text changed.</value>
        public ICommand TextBoxTextChanged
        {
            get
            {
                return this.setTextBoxText;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the fis time schedule.
        /// </summary>
        /// <param name="timeSchedule">The time schedule.</param>
        /// <returns>Returns FisTimeSchedules.</returns>
        private FisTimeSchedules GetFisTimeSchedule(string timeSchedule)
        {
            var timeScheduleRetVal = FisTimeSchedules.TimeSchedule10min;
            Enum.TryParse(timeSchedule, out timeScheduleRetVal);
            return timeScheduleRetVal;
        }

        /// <summary>
        /// Gets the time schedule combo string.
        /// </summary>
        /// <param name="fisTimeScheduleType">Type of the fis time schedule.</param>
        /// <returns>Returns System.String.</returns>
        private string GetTimeScheduleComboString(string fisTimeScheduleType)
        {
            var timeScheduleComboString = fisTimeScheduleType.Replace(@"TimeSchedule", string.Empty);
            timeScheduleComboString = timeScheduleComboString.Replace(@"min", @" min");
            timeScheduleComboString = timeScheduleComboString.Replace(@"h", @" h");

            return timeScheduleComboString;
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
                this.ActiveSamplingRate = this.GetTimeScheduleComboString(e.Configuration.FisSettings.TimeSchedule.ToString());
            }
        }

        /// <summary>
        /// Initializes the view controls.
        /// </summary>
        private void InitializeViewControls()
        {
            var names = Enum.GetNames(typeof(FisTimeSchedules));

            foreach (var enumName in names)
            {
                this.SamplingRates.Add(this.GetTimeScheduleComboString(enumName));
            }
        }

        /// <summary>
        /// Called when [sampling rates selection changed].
        /// </summary>
        private void OnSamplingRatesSelectionChanged()
        {
            if (!string.IsNullOrEmpty(this.ActiveSamplingRate))
            {
                var samplingRate = @"TimeSchedule" + this.ActiveSamplingRate;
                samplingRate = samplingRate.Replace(@" ", string.Empty);

                this.mainWindowViewModel.Configuration.FisSettings.TimeSchedule = this.GetFisTimeSchedule(samplingRate);
            }
        }

        /// <summary>
        /// Called when [set text box text].
        /// </summary>
        private void OnSetTextBoxText()
        {
            ////var message = string.Format(CultureInfo.CurrentUICulture, "OnSetTextBoxText: ") + this.TextBoxText.ToString(CultureInfo.InvariantCulture);
            ////this.mainWindowViewModel.Host.UserInterface.DisplayMessage(message, Resources.Language_Selection, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
        }

        #endregion
    }
}