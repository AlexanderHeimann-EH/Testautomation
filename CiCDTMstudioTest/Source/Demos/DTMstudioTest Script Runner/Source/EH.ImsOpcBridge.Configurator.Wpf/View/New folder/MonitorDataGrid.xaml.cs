// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceTypeInfoGrid.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for DeviceTypeInfoListVw.xaml
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
    /// Interaction logic for DeviceTypeInfoListVw.xaml
    /// </summary>
    public partial class DeviceTypeInfoGrid : UserControl
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceTypeInfoGrid" /> class.
        /// </summary>
        public DeviceTypeInfoGrid()
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
        /// The device type items data grid data context changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void DeviceTypeItemsDataGridDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = e.NewValue as DependencyObject;
            if (viewModel != null)
            {
                viewModel.SetValue(DeviceTypeInfoListViewModel.NextPageCommandProperty, this.DeviceTypeItemsDataGrid.NextPageCommand);
                viewModel.SetValue(DeviceTypeInfoListViewModel.PreviousPageCommandProperty, this.DeviceTypeItemsDataGrid.PreviousPageCommand);
            }
        }

        #endregion
    }
}
