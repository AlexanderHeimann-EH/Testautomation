// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationControlManual.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.View
{
    using System;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Configurator.ViewModel;

    /// <summary>
    /// Interaction logic for DocumentationControlManual.xaml
    /// </summary>
    public partial class DocumentationControlManual : UserControl
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationControlManual" /> class.
        /// </summary>
        public DocumentationControlManual()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Scrolls the automatic current item.
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
                var itemViewModel = item as DocumentationItemVm;

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
        /// Unique identifiers the element configuration layout updated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void UIElementOnLayoutUpdated(object sender, EventArgs e)
        {
            this.ScrollToCurrentItem();
        }

        #endregion
    }
}
