// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonitorDataGridCtrl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for MonitorDataGridCtrl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.ViewModel;

    // ReSharper disable RedundantExtendsListEntry

    /// <summary>
    /// Class MonitorDataGridCtrl
    /// </summary>
    public partial class MonitorDataGridCtrl : UserControl
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MonitorDataGridCtrl"/> class.
        /// </summary>
        public MonitorDataGridCtrl()
        {
            this.InitializeComponent();
            this.MonitorDataGrid.Loaded += this.CallLoaded;
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate DgDoubleClick
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "OK here.")]
        public delegate void DgDoubleClick();

        #endregion

        #region Public Events

        /// <summary>
        /// Occurs when [item double clicked].
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "OK here.")]
        public event DgDoubleClick ItemDoubleClicked;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the content as CSV.
        /// </summary>
        /// <param name="includeHidden">if set to <c>true</c> [include hidden].</param>
        /// <param name="includeHeader">if set to <c>true</c> [include header].</param>
        /// <returns>System String.</returns>
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
        /// Items the double click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        protected void ItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.ItemDoubleClicked != null)
            {
                this.ItemDoubleClicked();
            }
        }

        /// <summary>
        /// Expanders the Column1 collapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ExpanderColumn1Collapsed(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;

            // Block Collapsing if filter string in not empty
            if (expander != null)
            {
                if (!string.IsNullOrEmpty(this.MonitorDataGrid.FilterStringColumn1))
                {
                    expander.IsExpanded = true;
                }
            }
        }

        /// <summary>
        /// Expanders the Column2 collapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ExpanderColumn2Collapsed(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;

            // Block Collapsing if filter string in not empty
            if (expander != null)
            {
                if (!string.IsNullOrEmpty(this.MonitorDataGrid.FilterStringColumn2))
                {
                    expander.IsExpanded = true;
                }
            }
        }

        /// <summary>
        /// Expanders the Column3 collapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ExpanderColumn3Collapsed(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;

            // Block Collapsing if filter string in not empty
            if (expander != null)
            {
                if (!string.IsNullOrEmpty(this.MonitorDataGrid.FilterStringColumn3))
                {
                    expander.IsExpanded = true;
                }
            }
        }

        /// <summary>
        /// Expanders the Column4 collapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ExpanderColumn4Collapsed(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;

            // Block Collapsing if filter string in not empty
            if (expander != null)
            {
                if (!string.IsNullOrEmpty(this.MonitorDataGrid.FilterStringColumn4))
                {
                    expander.IsExpanded = true;
                }
            }
        }

        /// <summary>
        /// Expanders the Column5 collapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ExpanderColumn5Collapsed(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;

            // Block Collapsing if filter string in not empty
            if (expander != null)
            {
                if (!string.IsNullOrEmpty(this.MonitorDataGrid.FilterStringColumn5))
                {
                    expander.IsExpanded = true;
                }
            }
        }

        /// <summary>
        /// Expanders the Column6 collapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ExpanderColumn6Collapsed(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;

            // Block Collapsing if filter string in not empty
            if (expander != null)
            {
                if (!string.IsNullOrEmpty(this.MonitorDataGrid.FilterStringColumn6))
                {
                    expander.IsExpanded = true;
                }
            }
        }

        /// <summary>
        /// Calls the loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void CallLoaded(object sender, RoutedEventArgs e)
        {
            var monitorDataControlVm = this.MonitorDataGrid.DataContext as MonitorDataControlVm;
            if (monitorDataControlVm != null)
            {
                monitorDataControlVm.MonitorGridLoaded();
            }
        }

        /// <summary>
        /// Monitors the data grid data context changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private
        void MonitorDataGridDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = e.NewValue as DependencyObject;
            if (viewModel != null)
            {
                viewModel.SetValue(MonitorDataControlVm.NextPageCommandProperty, this.MonitorDataGrid.NextPageCommand);
                viewModel.SetValue(MonitorDataControlVm.PreviousPageCommandProperty, this.MonitorDataGrid.PreviousPageCommand);
                viewModel.SetValue(MonitorDataControlVm.BeginPageCommandProperty, this.MonitorDataGrid.BeginPageCommand);
                viewModel.SetValue(MonitorDataControlVm.EndPageCommandProperty, this.MonitorDataGrid.EndPageCommand);
            }
        }

        #endregion
    }
}