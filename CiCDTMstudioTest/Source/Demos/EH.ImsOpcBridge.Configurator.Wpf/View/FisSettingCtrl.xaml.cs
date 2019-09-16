// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FisSettingCtrl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for FisSettingCtrl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Configurator.ViewModel;

    /// <summary>
    /// Class FisSettingCtrl
    /// </summary>
    public partial class FisSettingCtrl : UserControl
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FisSettingCtrl"/> class.
        /// </summary>
        public FisSettingCtrl()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Scrolls to current item.
        /// </summary>
        private void ScrollToCurrentItem()
        {
            if (!this.IsVisible)
            {
                return;
            }

            double heightBefore = 0;

            foreach (var item in this.ItemsControl.Items)
            {
                var itemContainer = this.ItemsControl.ItemContainerGenerator.ContainerFromItem(item) as ContentPresenter;
                var itemViewModel = item as FisSettingItemVm;

                if ((itemViewModel != null) && (itemContainer != null))
                {
                    if (itemViewModel.IsExpanded)
                    {
                        var viewHeight = this.ActualHeight;
                        var selectedItemHeight = itemContainer.ActualHeight;

                        if (viewHeight >= selectedItemHeight)
                        {
                            this.ScrollViewer.ScrollToVerticalOffset(Math.Max(heightBefore - ((viewHeight - selectedItemHeight) / 2), 0));
                        }
                        else
                        {
                            this.ScrollViewer.ScrollToVerticalOffset(Math.Max(heightBefore, 0));
                        }

                        return;
                    }

                    heightBefore += itemContainer.ActualHeight;
                }
            }
        }

        /// <summary>
        /// UIs the element on layout updated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void UIElementOnLayoutUpdated(object sender, EventArgs e)
        {
            this.ScrollToCurrentItem();
        }

        #endregion
    }
}