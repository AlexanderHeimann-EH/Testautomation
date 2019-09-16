// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseSelectorControlViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   View model for the base selector control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf.EventArguments;
    using EH.ImsOpcBridge.UI.Wpf.Interfaces;

    /// <summary>
    /// View model for the base selector control.
    /// </summary>
    public class BaseSelectorControlViewModel : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The items property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(ObservableCollection<IBaseSelectorItem>), typeof(BaseSelectorControlViewModel), new PropertyMetadata(default(ObservableCollection<IBaseSelectorItem>)));

        /// <summary>
        /// The selected item property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(IBaseSelectorItem), typeof(BaseSelectorControlViewModel), new FrameworkPropertyMetadata(default(IBaseSelectorItem), OnSelectedItemPropertyChanged, OnCoerceSelectedItemProperty));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSelectorControlViewModel" /> class.
        /// </summary>
        public BaseSelectorControlViewModel()
        {
            this.Items = new ObservableCollection<IBaseSelectorItem>();
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The selected item changed.
        /// </summary>
        public event EventHandler<BaseSelectorSelectionChangedEventArgs> SelectedItemChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets Items.
        /// </summary>
        /// <value>The items.</value>
        public ObservableCollection<IBaseSelectorItem> Items
        {
            get
            {
                return (ObservableCollection<IBaseSelectorItem>)this.GetValue(ItemsProperty);
            }

            private set
            {
                this.SetValue(ItemsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets SelectedItem.
        /// </summary>
        /// <value>The selected item.</value>
        public IBaseSelectorItem SelectedItem
        {
            get
            {
                return (IBaseSelectorItem)this.GetValue(SelectedItemProperty);
            }

            set
            {
                this.SetValue(SelectedItemProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The select the item with the given value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SelectItem(object value)
        {
            foreach (var item in this.Items)
            {
                if (item.Value.Equals(value))
                {
                    this.SelectedItem = item;
                    break;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on coerce selected item property.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="basevalue">The base value.</param>
        /// <returns>The <see cref="object" /> selected item.</returns>
        private static object OnCoerceSelectedItemProperty(DependencyObject d, object basevalue)
        {
            var viewModel = d as BaseSelectorControlViewModel;

            if (viewModel != null)
            {
                // Keep old value in case of old and new values are of different types.
                // This can happen, if the data context of the selector control has been changed.
                // Then then the selected item would be written into the wrong data context.
                var oldValue = viewModel.SelectedItem;
                var newValue = basevalue as BaseSelectorItemViewModel;
                if (newValue == null || (oldValue != null && oldValue.Value != null && newValue.Value != null && oldValue.Value.GetType() != newValue.Value.GetType()))
                {
                    return oldValue;
                }
            }

            return basevalue;
        }

        /// <summary>
        /// The on selected item property changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private static void OnSelectedItemPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = sender as BaseSelectorControlViewModel;
            if (viewModel != null)
            {
                if (viewModel.SelectedItemChanged != null)
                {
                    var args = new BaseSelectorSelectionChangedEventArgs { SelectedItem = viewModel.SelectedItem };
                    viewModel.SelectedItemChanged(viewModel, args);
                }
            }
        }

        #endregion
    }
}
