// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageControlItemVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The language control item vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Information;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// The language control item vm.
    /// </summary>
    public class LanguageControlItemVm : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The automation id property.
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(LanguageControlItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The is selected property.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(LanguageControlItemVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The name property.
        /// </summary>
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(LanguageControlItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The tool tip property.
        /// </summary>
        public static readonly DependencyProperty ToolTipProperty = DependencyProperty.Register("ToolTip", typeof(string), typeof(LanguageControlItemVm), new PropertyMetadata(default(string)));

        #endregion

        #region Fields

        /// <summary>
        /// The culture information
        /// </summary>
        private readonly CultureInfo cultureInfo;

        /// <summary>
        /// Command for executing the action
        /// </summary>
        private readonly DelegateCommand executeActionCommand;

        /// <summary>
        /// The language control vm
        /// </summary>
        private readonly LanguageControlVm languageControlVm;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageControlItemVm" /> class.
        /// </summary>
        public LanguageControlItemVm()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageControlItemVm" /> class.
        /// </summary>
        /// <param name="cultureInfo">The culture info.</param>
        /// <param name="languageControlVm">The language control vm.</param>
        public LanguageControlItemVm(CultureInfo cultureInfo, LanguageControlVm languageControlVm)
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException(@"cultureInfo");
            }

            this.cultureInfo = cultureInfo;

            var baseCultureInfo = cultureInfo;
            while (!string.IsNullOrEmpty(baseCultureInfo.Parent.Name))
            {
                baseCultureInfo = baseCultureInfo.Parent;
            }

            this.Name = baseCultureInfo.NativeName;
            this.ToolTip = LanguageTranslation.GetLanguageDisplayName(baseCultureInfo);
            this.AutomationId = cultureInfo.Name;
            this.languageControlVm = languageControlVm;
            this.executeActionCommand = new DelegateCommand(this.ExecuteAction);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the automation id.
        /// </summary>
        /// <value>The automation unique identifier.</value>
        public string AutomationId
        {
            get
            {
                return (string)this.GetValue(AutomationIdProperty);
            }

            set
            {
                this.SetValue(AutomationIdProperty, value);
            }
        }

        /// <summary>
        /// Gets the culture information.
        /// </summary>
        /// <value>The culture information.</value>
        public CultureInfo CultureInfo
        {
            get
            {
                return this.cultureInfo;
            }
        }

        /// <summary>
        /// Gets the auto setup command.
        /// </summary>
        /// <value>The auto setup command.</value>
        public ICommand ExecuteActionCommand
        {
            get
            {
                return this.executeActionCommand;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is selected.
        /// </summary>
        /// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        public bool IsSelected
        {
            get
            {
                return (bool)this.GetValue(IsSelectedProperty);
            }

            set
            {
                this.SetValue(IsSelectedProperty, value);
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return (string)this.GetValue(NameProperty);
            }

            set
            {
                this.SetValue(NameProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip.
        /// </summary>
        /// <value>The tool tip.</value>
        public string ToolTip
        {
            get
            {
                return (string)this.GetValue(ToolTipProperty);
            }

            set
            {
                this.SetValue(ToolTipProperty, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the action.
        /// </summary>
        private void ExecuteAction()
        {
            this.languageControlVm.SelectLanguage(this);
        }

        #endregion
    }
}
