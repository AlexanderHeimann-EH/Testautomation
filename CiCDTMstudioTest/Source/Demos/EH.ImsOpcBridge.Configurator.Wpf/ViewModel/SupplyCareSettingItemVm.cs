// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplyCareSettingItemVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The documentation item vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class SupplyCareSettingItemVm
    /// </summary>
    public class SupplyCareSettingItemVm : PageViewModel
    {
        #region Static Fields

        /// <summary>
        /// The automation id property
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(SupplyCareSettingItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The expand button image path property
        /// </summary>
        public static readonly DependencyProperty ExpandButtonImagePathProperty = DependencyProperty.Register("ExpandButtonImagePath", typeof(string), typeof(SupplyCareSettingItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The expand button visibility property
        /// </summary>
        public static readonly DependencyProperty ExpandButtonVisibilityProperty = DependencyProperty.Register("ExpandButtonVisibility", typeof(Visibility), typeof(SupplyCareSettingItemVm), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The is expanded property
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(SupplyCareSettingItemVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The own configuration property
        /// </summary>
        public static readonly DependencyProperty OwnConfigurationProperty = DependencyProperty.Register("OwnConfiguration", typeof(OwnConfigurationControlVm), typeof(SupplyCareSettingItemVm), new PropertyMetadata(default(OwnConfigurationControlVm)));

        /// <summary>
        /// The title property
        /// </summary>
        public static readonly DependencyProperty ItemTitleProperty = DependencyProperty.Register("ItemTitle", typeof(string), typeof(SupplyCareSettingItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The visibility property
        /// </summary>
        public static readonly DependencyProperty VisibilityProperty = DependencyProperty.Register("Visibility", typeof(Visibility), typeof(SupplyCareSettingItemVm), new PropertyMetadata(default(Visibility)));

        #endregion

        #region Fields

        /// <summary>
        /// The documentation view model
        /// </summary>
        private readonly SupplyCareSettingCtrlVm supplyCareSettingCtrlVm;

        /// <summary>
        /// The expand command
        /// </summary>
        private readonly DelegateCommand expandCommand;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplyCareSettingItemVm"/> class.
        /// </summary>
        /// <param name="supplyCareSettingCtrlVm">The supply care setting CTRL vm.</param>
        /// <param name="view">The view.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="title">The title.</param>
        /// <param name="isExpandable">The is expandable.</param>
        /// <param name="automationId">The automation id.</param>
        public SupplyCareSettingItemVm(SupplyCareSettingCtrlVm supplyCareSettingCtrlVm, UserControl view, PageViewModel viewModel, string title, bool isExpandable, [Localizable(false)] string automationId)
        {
            this.supplyCareSettingCtrlVm = supplyCareSettingCtrlVm;
            this.ItemTitle = title;

            this.AutomationId = automationId;
            this.expandCommand = new DelegateCommand(this.Expand);

            this.OwnConfiguration = new OwnConfigurationControlVm();

            this.GoToPage(view, viewModel);

            if (isExpandable)
            {
                this.IsExpanded = false;
                this.Visibility = Visibility.Visible;
                this.ExpandButtonVisibility = Visibility.Visible;
            }
            else
            {
                this.IsExpanded = true;
                this.Visibility = Visibility.Visible;
                this.ExpandButtonVisibility = Visibility.Collapsed;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the automation id.
        /// </summary>
        /// <value>The automation id.</value>
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
        /// Gets the supply care setting CTRL vm.
        /// </summary>
        /// <value>The supply care setting CTRL vm.</value>
        public SupplyCareSettingCtrlVm SupplyCareSettingCtrlVm
        {
            get
            {
                return this.supplyCareSettingCtrlVm;
            }
        }

        /// <summary>
        /// Gets or sets the expand button image path.
        /// </summary>
        /// <value>The expand button image path.</value>
        public string ExpandButtonImagePath
        {
            get
            {
                return (string)this.GetValue(ExpandButtonImagePathProperty);
            }

            set
            {
                this.SetValue(ExpandButtonImagePathProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the expand button visibility.
        /// </summary>
        /// <value>The expand button visibility.</value>
        public Visibility ExpandButtonVisibility
        {
            get
            {
                return (Visibility)this.GetValue(ExpandButtonVisibilityProperty);
            }

            set
            {
                this.SetValue(ExpandButtonVisibilityProperty, value);
            }
        }

        /// <summary>
        /// Gets the expand command.
        /// </summary>
        /// <value>The expand command.</value>
        public ICommand ExpandCommand
        {
            get
            {
                return this.expandCommand;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is expanded.
        /// </summary>
        /// <value><c>true</c> if this instance is expanded; otherwise, <c>false</c>.</value>
        public bool IsExpanded
        {
            get
            {
                return (bool)this.GetValue(IsExpandedProperty);
            }

            set
            {
                if (value)
                {
                    // ReSharper disable LocalizableElement
                    this.ExpandButtonImagePath = @"/EH.ImsOpcBridge.Configurator.Wpf;component/Resources/DesignA2/Arrow down.png";

                    // ReSharper restore LocalizableElement
                }
                else
                {
                    // ReSharper disable LocalizableElement
                    this.ExpandButtonImagePath = @"/EH.ImsOpcBridge.Configurator.Wpf;component/Resources/DesignA2/Arrow Right.png";

                    // ReSharper restore LocalizableElement
                }

                this.SetValue(IsExpandedProperty, value);

                this.OwnConfiguration.IsOwnConfigurationControlVisible = value;
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
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string ItemTitle
        {
            get
            {
                return (string)this.GetValue(ItemTitleProperty);
            }

            set
            {
                this.SetValue(ItemTitleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        /// <value>The visibility.</value>
        public Visibility Visibility
        {
            get
            {
                return (Visibility)this.GetValue(VisibilityProperty);
            }

            set
            {
                this.SetValue(VisibilityProperty, value);
            }
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
        /// Expands this instance.
        /// </summary>
        protected void Expand()
        {
            if (!this.IsExpanded)
            {
                this.SupplyCareSettingCtrlVm.SelectSupplyCareSettingItem(this);
            }
            else
            {
                this.IsExpanded = false;
            }
        }

        #endregion
    }
}