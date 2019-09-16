// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationPageVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The navigation page vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Windows;

    /// <summary>
    /// The navigation page vm.
    /// </summary>
    public class NavigationPageVm : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The button items property.
        /// </summary>
        public static readonly DependencyProperty ButtonItemsProperty = DependencyProperty.Register("ButtonItems", typeof(ObservableCollection<BaseCommandItemViewModel>), typeof(NavigationPageVm), new PropertyMetadata(default(ObservableCollection<BaseCommandItemViewModel>)));

        /// <summary>
        /// The caption property.
        /// </summary>
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(NavigationPageVm), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationPageVm" /> class.
        /// </summary>
        public NavigationPageVm()
        {
            this.ButtonItems = new ObservableCollection<BaseCommandItemViewModel>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationPageVm" /> class.
        /// </summary>
        /// <param name="caption">The caption.</param>
        public NavigationPageVm(string caption)
        {
            this.ButtonItems = new ObservableCollection<BaseCommandItemViewModel>();
            this.Caption = caption;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets ButtonItems.
        /// </summary>
        /// <value>The button items.</value>
        public ObservableCollection<BaseCommandItemViewModel> ButtonItems
        {
            get
            {
                return (ObservableCollection<BaseCommandItemViewModel>)this.GetValue(ButtonItemsProperty);
            }

            private set
            {
                this.SetValue(ButtonItemsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption
        {
            get
            {
                return (string)this.GetValue(CaptionProperty);
            }

            set
            {
                this.SetValue(CaptionProperty, value);
            }
        }

        #endregion
    }
}
