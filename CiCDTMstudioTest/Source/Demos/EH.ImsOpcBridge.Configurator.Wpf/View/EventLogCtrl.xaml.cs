// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventLogCtrl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for EventLogCtrl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.ViewModel;

    /// <summary>
    /// Interaction logic for EventLogCtrl.xaml
    /// </summary>
    public partial class EventLogCtrl
    {
        // ReSharper restore RedundantExtendsListEntry
        #region Static Fields

        /// <summary>
        /// The filter expression visibility property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FilterExpressionVisibilityProperty = DependencyProperty.Register("FilterExpressionVisibility", typeof(Visibility), typeof(EventLogControlVm), new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// The info bar visibility property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty InfoBarVisibilityProperty = DependencyProperty.Register("InfoBarVisibility", typeof(Visibility), typeof(EventLogControlVm), new PropertyMetadata(Visibility.Hidden));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventLogCtrl" /> class.
        /// </summary>
        public EventLogCtrl()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Delegates

        /// <summary>
        /// double click event delegate
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "OK here.")]
        public delegate void DgDoubleClick();

        #endregion

        #region Public Events

        /// <summary>
        /// event signaling an item double click
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "OK here.")]
        public event DgDoubleClick ItemDoubleClicked;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the filter expression visibility.
        /// </summary>
        /// <value>The filter expression visibility.</value>
        public Visibility FilterExpressionVisibility
        {
            get
            {
                return (Visibility)this.GetValue(FilterExpressionVisibilityProperty);
            }

            set
            {
                this.SetValue(FilterExpressionVisibilityProperty, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the info bar visibility.
        /// </summary>
        /// <value>The info bar visibility.</value>
        public Visibility InfoBarVisibility
        {
            get
            {
                return (Visibility)this.GetValue(InfoBarVisibilityProperty);
            }

            set
            {
                this.SetValue(InfoBarVisibilityProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the content as CSV.
        /// </summary>
        /// <param name="includeHidden">if set to <c>true</c> [include hidden].</param>
        /// <param name="includeHeader">if set to <c>true</c> [include header].</param>
        /// <returns>content as csv string</returns>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "OK here.")]
        public string GetContentAsCsv(bool includeHidden, bool includeHeader)
        {
            var contentCsv = new StringBuilder();

            return contentCsv.ToString();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the double click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs" /> instance containing the event data.</param>
        protected void ItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.ItemDoubleClicked != null)
            {
                this.ItemDoubleClicked();
            }
        }

        /// <summary>
        /// The event log grid data context changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void EventLogGridDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = e.NewValue as DependencyObject;
            if (viewModel != null)
            {
               viewModel.SetValue(EventLogControlVm.NextPageCommandProperty, this.EventLogGrid.NextPageCommand);
               viewModel.SetValue(EventLogControlVm.PreviousPageCommandProperty, this.EventLogGrid.PreviousPageCommand);
               viewModel.SetValue(EventLogControlVm.BeginPageCommandProperty, this.EventLogGrid.BeginPageCommand);
               viewModel.SetValue(EventLogControlVm.EndPageCommandProperty, this.EventLogGrid.EndPageCommand);
            }
        }

        #endregion

        /////// <summary>
        /////// Sort click handler.
        /////// </summary>
        /////// <param name="sender">The sender.</param>
        /////// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        ////private void SortClick(object sender, RoutedEventArgs e)
        ////{
        ////    var column = sender as GridViewColumnHeader;
        ////    if (column == null)
        ////    {
        ////        return;
        ////    }

        ////    var field = column.Tag as string;

        ////    if (this.curSortCol != null)
        ////    {
        ////        AdornerLayer.GetAdornerLayer(this.curSortCol).Remove(this.curAdorner);
        ////        this._deviceTypeItemsDataGrid.Items.SortDescriptions.Clear();
        ////    }

        ////    var newDir = ListSortDirection.Ascending;
        ////    if (this.curSortCol == column && this.curAdorner.Direction == newDir)
        ////    {
        ////        newDir = ListSortDirection.Descending;
        ////    }

        ////    this.curSortCol = column;
        ////    this.curAdorner = new SortAdorner(this.curSortCol, newDir);
        ////    AdornerLayer.GetAdornerLayer(this.curSortCol).Add(this.curAdorner);
        ////    this._deviceTypeItemsDataGrid.Items.SortDescriptions.Add(new SortDescription(field, newDir));
        ////}
    }
}