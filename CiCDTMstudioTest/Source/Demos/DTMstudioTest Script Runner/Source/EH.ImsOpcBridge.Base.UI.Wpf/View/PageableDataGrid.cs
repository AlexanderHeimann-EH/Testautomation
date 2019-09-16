// ***********************************************************************
// <copyright file="PageableDataGrid.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.UI.Wpf.Helpers;

    /// <summary>
    /// Class PageableDataGrid
    /// </summary>
    public class PageableDataGrid : DataGrid
    {
        #region Static Fields

        /// <summary>
        /// The begin page command property
        /// </summary>
        public static readonly DependencyProperty BeginPageCommandProperty = DependencyProperty.Register("BeginPageCommand", typeof(DelegateCommand), typeof(PageableDataGrid), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The current page property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(int), typeof(PageableDataGrid), new PropertyMetadata(default(int)));

        /// <summary>
        /// The end page command property
        /// </summary>
        public static readonly DependencyProperty EndPageCommandProperty = DependencyProperty.Register("EndPageCommand", typeof(DelegateCommand), typeof(PageableDataGrid), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The filter string column1 property
        /// </summary>
        public static readonly DependencyProperty FilterStringColumn1Property = DependencyProperty.Register("FilterStringColumn1", typeof(string), typeof(PageableDataGrid), new PropertyMetadata(default(string)));

        /// <summary>
        /// The filter string column2 property
        /// </summary>
        public static readonly DependencyProperty FilterStringColumn2Property = DependencyProperty.Register("FilterStringColumn2", typeof(string), typeof(PageableDataGrid), new PropertyMetadata(default(string)));

        /// <summary>
        /// The filter string column3 property
        /// </summary>
        public static readonly DependencyProperty FilterStringColumn3Property = DependencyProperty.Register("FilterStringColumn3", typeof(string), typeof(PageableDataGrid), new PropertyMetadata(default(string)));

        /// <summary>
        /// The filter string column4 property
        /// </summary>
        public static readonly DependencyProperty FilterStringColumn4Property = DependencyProperty.Register("FilterStringColumn4", typeof(string), typeof(PageableDataGrid), new PropertyMetadata(default(string)));

        /// <summary>
        /// The filter string column5 property
        /// </summary>
        public static readonly DependencyProperty FilterStringColumn5Property = DependencyProperty.Register("FilterStringColumn5", typeof(string), typeof(PageableDataGrid), new PropertyMetadata(default(string)));

        /// <summary>
        /// The filter string column6 property
        /// </summary>
        public static readonly DependencyProperty FilterStringColumn6Property = DependencyProperty.Register("FilterStringColumn6", typeof(string), typeof(PageableDataGrid), new PropertyMetadata(default(string)));

        /// <summary>
        /// The filter string column7 property
        /// </summary>
        public static readonly DependencyProperty FilterStringColumn7Property = DependencyProperty.Register("FilterStringColumn7", typeof(string), typeof(PageableDataGrid), new PropertyMetadata(default(string)));

        /// <summary>
        /// The next page command property
        /// </summary>
        public static readonly DependencyProperty NextPageCommandProperty = DependencyProperty.Register("NextPageCommand", typeof(DelegateCommand), typeof(PageableDataGrid), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The number of pages property
        /// </summary>
        public static readonly DependencyProperty NumberOfPagesProperty = DependencyProperty.Register("NumberOfPages", typeof(int), typeof(PageableDataGrid), new PropertyMetadata(default(int)));

        /// <summary>
        /// The previous page command property
        /// </summary>
        public static readonly DependencyProperty PreviousPageCommandProperty = DependencyProperty.Register("PreviousPageCommand", typeof(DelegateCommand), typeof(PageableDataGrid), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The scroll page property
        /// </summary>
        public static readonly DependencyProperty ScrollPageProperty = DependencyProperty.Register("ScrollPage", typeof(int), typeof(PageableDataGrid), new PropertyMetadata(default(int)));

        /// <summary>
        /// The selected cells list property
        /// </summary>
        public static readonly DependencyProperty SelectedCellsListProperty = DependencyProperty.Register("SelectedCellsList", typeof(IList<DataGridCellInfo>), typeof(PageableDataGrid), new PropertyMetadata(null));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PageableDataGrid" /> class.
        /// </summary>
        public PageableDataGrid()
        {
            this.NextPageCommand = new DelegateCommand(this.GoToNextPage);
            this.PreviousPageCommand = new DelegateCommand(this.GoToPreviousPage);

            this.BeginPageCommand = new DelegateCommand(this.GoToBeginPage);
            this.EndPageCommand = new DelegateCommand(this.GoToEndPage);

            this.NumberOfPages = 1;

            this.Loaded += this.PageableDataGridLoaded;
            this.Unloaded += this.PageableDataGridUnloaded;

            this.SelectionChanged += this.CustomDataGridSelectionChanged;

            this.ScrollPage = 0;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the begin page command.
        /// </summary>
        /// <value>The begin page command.</value>
        public DelegateCommand BeginPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(BeginPageCommandProperty);
            }

            set
            {
                this.SetValue(BeginPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        public int CurrentPage
        {
            get
            {
                return (int)this.GetValue(CurrentPageProperty);
            }

            set
            {
                this.SetValue(CurrentPageProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the end page command.
        /// </summary>
        /// <value>The end page command.</value>
        public DelegateCommand EndPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(EndPageCommandProperty);
            }

            set
            {
                this.SetValue(EndPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the filter string column1.
        /// </summary>
        /// <value>The filter string column1.</value>
        public string FilterStringColumn1
        {
            get
            {
                return (string)this.GetValue(FilterStringColumn1Property);
            }

            set
            {
                this.SetValue(FilterStringColumn1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the filter string column2.
        /// </summary>
        /// <value>The filter string column2.</value>
        public string FilterStringColumn2
        {
            get
            {
                return (string)this.GetValue(FilterStringColumn2Property);
            }

            set
            {
                this.SetValue(FilterStringColumn2Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the filter string column3.
        /// </summary>
        /// <value>The filter string column3.</value>
        public string FilterStringColumn3
        {
            get
            {
                return (string)this.GetValue(FilterStringColumn3Property);
            }

            set
            {
                this.SetValue(FilterStringColumn3Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the filter string column4.
        /// </summary>
        /// <value>The filter string column4.</value>
        public string FilterStringColumn4
        {
            get
            {
                return (string)this.GetValue(FilterStringColumn4Property);
            }

            set
            {
                this.SetValue(FilterStringColumn4Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the filter string column5.
        /// </summary>
        /// <value>The filter string column5.</value>
        public string FilterStringColumn5
        {
            get
            {
                return (string)this.GetValue(FilterStringColumn5Property);
            }

            set
            {
                this.SetValue(FilterStringColumn5Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the filter string column6.
        /// </summary>
        /// <value>The filter string column6.</value>
        public string FilterStringColumn6
        {
            get
            {
                return (string)this.GetValue(FilterStringColumn6Property);
            }

            set
            {
                this.SetValue(FilterStringColumn6Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the filter string column7.
        /// </summary>
        /// <value>The filter string column7.</value>
        public string FilterStringColumn7
        {
            get
            {
                return (string)this.GetValue(FilterStringColumn7Property);
            }

            set
            {
                this.SetValue(FilterStringColumn7Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the next page command.
        /// </summary>
        /// <value>The next page command.</value>
        public DelegateCommand NextPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(NextPageCommandProperty);
            }

            set
            {
                this.SetValue(NextPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>The number of pages.</value>
        public int NumberOfPages
        {
            get
            {
                return (int)this.GetValue(NumberOfPagesProperty);
            }

            set
            {
                this.SetValue(NumberOfPagesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the previous page command.
        /// </summary>
        /// <value>The previous page command.</value>
        public DelegateCommand PreviousPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(PreviousPageCommandProperty);
            }

            set
            {
                this.SetValue(PreviousPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the scroll page.
        /// </summary>
        /// <value>The scroll page.</value>
        public int ScrollPage
        {
            get
            {
                return (int)this.GetValue(ScrollPageProperty);
            }

            set
            {
                this.SetValue(ScrollPageProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected cells list.
        /// </summary>
        /// <value>The selected cells list.</value>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Reviewed. Suppression is OK here.")]
        public IList<DataGridCellInfo> SelectedCellsList
        {
            get
            {
                return (IList<DataGridCellInfo>)this.GetValue(SelectedCellsListProperty);
            }

            set
            {
                this.SetValue(SelectedCellsListProperty, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the pages.
        /// </summary>
        private void CalculatePages()
        {
            var scrollViewer = WpfHelper.FindVisualChild<ScrollViewer>(this);
            var verticalOffset = scrollViewer.VerticalOffset + scrollViewer.ViewportHeight;

            if (scrollViewer.ViewportHeight > 0)
            {
                this.NumberOfPages = (int)Math.Ceiling(scrollViewer.ExtentHeight / scrollViewer.ViewportHeight);
                this.CurrentPage = (int)Math.Ceiling(verticalOffset / scrollViewer.ViewportHeight);
            }
        }

        /// <summary>
        /// Customs the data grid selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void CustomDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedCellsList = this.SelectedCells;
        }

        /// <summary>
        /// Goes to begin page.
        /// </summary>
        private void GoToBeginPage()
        {
            var scrollViewer = WpfHelper.FindVisualChild<ScrollViewer>(this);

            if (scrollViewer != null)
            {
                scrollViewer.ScrollToHome();
                scrollViewer.ScrollChanged += this.ScrollViewerScrollChanged;
            }
        }

        /// <summary>
        /// Goes to end page.
        /// </summary>
        private void GoToEndPage()
        {
            var scrollViewer = WpfHelper.FindVisualChild<ScrollViewer>(this);

            if (scrollViewer != null)
            {
                scrollViewer.ScrollToEnd();
                scrollViewer.ScrollChanged += this.ScrollViewerScrollChanged;
            }
        }

        /// <summary>
        /// Goes to next page.
        /// </summary>
        private void GoToNextPage()
        {
            var scrollViewer = WpfHelper.FindVisualChild<ScrollViewer>(this);

            if (scrollViewer != null)
            {
                scrollViewer.PageDown();
                scrollViewer.ScrollChanged += this.ScrollViewerScrollChanged;
            }
        }

        /// <summary>
        /// Goes to previous page.
        /// </summary>
        private void GoToPreviousPage()
        {
            var scrollViewer = WpfHelper.FindVisualChild<ScrollViewer>(this);

            if (scrollViewer != null)
            {
                scrollViewer.PageUp();
                scrollViewer.ScrollChanged += this.ScrollViewerScrollChanged;
            }
        }

        /// <summary>
        /// Pageable the data grid loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void PageableDataGridLoaded(object sender, RoutedEventArgs e)
        {
            var scrollViewer = WpfHelper.FindVisualChild<ScrollViewer>(this);
            if (scrollViewer != null)
            {
                scrollViewer.ScrollChanged += this.ScrollViewerScrollChanged;

                this.UpdatePageCommands();
                this.CalculatePages();
            }
        }

        /// <summary>
        /// Pageable the data grid unloaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void PageableDataGridUnloaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= this.PageableDataGridLoaded;
            this.Unloaded -= this.PageableDataGridUnloaded;

            var scrollViewer = WpfHelper.FindVisualChild<ScrollViewer>(this);
            if (scrollViewer != null)
            {
                scrollViewer.ScrollChanged -= this.ScrollViewerScrollChanged;
            }
        }

        /// <summary>
        /// Scrolls the viewer scroll changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ScrollChangedEventArgs" /> instance containing the event data.</param>
        private void ScrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;

            // Helper Update View
            if (scrollViewer != null)
            {
                this.ScrollPage = (int)scrollViewer.VerticalOffset;
            }

            this.UpdatePageCommands();
            this.CalculatePages();
        }

        /// <summary>
        /// Updates the page commands.
        /// </summary>
        private void UpdatePageCommands()
        {
            if (this.NextPageCommand != null && this.PreviousPageCommand != null && this.BeginPageCommand != null && this.EndPageCommand != null)
            {
                var scrollViewer = WpfHelper.FindVisualChild<ScrollViewer>(this);
                var canPage = scrollViewer != null && scrollViewer.ViewportHeight < scrollViewer.ExtentHeight;

                this.NextPageCommand.IsExecutable = canPage;
                this.PreviousPageCommand.IsExecutable = canPage;
                this.BeginPageCommand.IsExecutable = canPage;
                this.EndPageCommand.IsExecutable = canPage;
            }
        }

        #endregion
    }
}