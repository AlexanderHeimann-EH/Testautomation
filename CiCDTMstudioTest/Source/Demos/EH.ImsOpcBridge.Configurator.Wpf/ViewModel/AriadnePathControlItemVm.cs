// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AriadnePathControlItemVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The ariadnepath control item vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.ComponentModel;
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// The ariadnepath control item vm.
    /// </summary>
    public class AriadnePathControlItemVm : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The automation id property.
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(AriadnePathControlItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The button name property.
        /// </summary>
        public static readonly DependencyProperty ButtonNameProperty = DependencyProperty.Register("ButtonName", typeof(string), typeof(AriadnePathControlItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The button name tool tip property.
        /// </summary>
        public static readonly DependencyProperty ButtonNameToolTipProperty = DependencyProperty.Register("ButtonNameToolTip", typeof(string), typeof(AriadnePathControlItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The is first step visible property.
        /// </summary>
        public static readonly DependencyProperty IsFirstStepVisibleProperty = DependencyProperty.Register("IsFirstStepVisible", typeof(bool), typeof(AriadnePathControlItemVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The is item detail text block visible property.
        /// </summary>
        public static readonly DependencyProperty IsItemDetailTextBlockVisibleProperty = DependencyProperty.Register("IsItemDetailTextBlockVisible", typeof(bool), typeof(AriadnePathControlItemVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The is ticked property.
        /// </summary>
        public static readonly DependencyProperty IsTickedProperty = DependencyProperty.Register("IsTicked", typeof(bool), typeof(AriadnePathControlItemVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The item detail text property.
        /// </summary>
        public static readonly DependencyProperty ItemDetailTextProperty = DependencyProperty.Register("ItemDetailText", typeof(string), typeof(AriadnePathControlItemVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The item detail tool tip property.
        /// </summary>
        public static readonly DependencyProperty ItemDetailToolTipProperty = DependencyProperty.Register("ItemDetailToolTip", typeof(string), typeof(AriadnePathControlItemVm), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AriadnePathControlItemVm" /> class.
        /// </summary>
        public AriadnePathControlItemVm()
        {
            this.IsItemDetailTextBlockVisible = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the automation id.
        /// </summary>
        /// <value>The automation id.</value>
        [Localizable(false)]
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
        /// Gets or sets the button name.
        /// </summary>
        /// <value>The name of the button.</value>
        public string ButtonName
        {
            get
            {
                return (string)this.GetValue(ButtonNameProperty);
            }

            set
            {
                this.SetValue(ButtonNameProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the button name tool tip.
        /// </summary>
        /// <value>The button name tool tip.</value>
        public string ButtonNameToolTip
        {
            get
            {
                return (string)this.GetValue(ButtonNameToolTipProperty);
            }

            set
            {
                this.SetValue(ButtonNameToolTipProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public object Context { get; set; }

        /// <summary>
        /// Gets or sets the execute action command.
        /// </summary>
        /// <value>The execute action command.</value>
        public DelegateCommand ExecuteActionCommand { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is first step visible.
        /// </summary>
        /// <value><c>true</c> if this instance is first step visible; otherwise, <c>false</c>.</value>
        public bool IsFirstStepVisible
        {
            get
            {
                return (bool)this.GetValue(IsFirstStepVisibleProperty);
            }

            set
            {
                this.SetValue(IsFirstStepVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is item detail text block visible.
        /// </summary>
        /// <value>The is item detail text block visible.</value>
        public bool IsItemDetailTextBlockVisible
        {
            get
            {
                return (bool)this.GetValue(IsItemDetailTextBlockVisibleProperty);
            }

            set
            {
                this.SetValue(IsItemDetailTextBlockVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is ticked.
        /// </summary>
        /// <value><c>true</c> if this instance is ticked; otherwise, <c>false</c>.</value>
        public bool IsTicked
        {
            get
            {
                return (bool)this.GetValue(IsTickedProperty);
            }

            set
            {
                this.SetValue(IsTickedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the item detail text.
        /// </summary>
        /// <value>The item detail text.</value>
        public string ItemDetailText
        {
            get
            {
                return (string)this.GetValue(ItemDetailTextProperty);
            }

            set
            {
                this.IsItemDetailTextBlockVisible = !string.IsNullOrEmpty(value);

                this.SetValue(ItemDetailTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the item detail tool tip.
        /// </summary>
        /// <value>The item detail tool tip.</value>
        public string ItemDetailToolTip
        {
            get
            {
                return (string)this.GetValue(ItemDetailToolTipProperty);
            }

            set
            {
                this.SetValue(ItemDetailToolTipProperty, value);
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
