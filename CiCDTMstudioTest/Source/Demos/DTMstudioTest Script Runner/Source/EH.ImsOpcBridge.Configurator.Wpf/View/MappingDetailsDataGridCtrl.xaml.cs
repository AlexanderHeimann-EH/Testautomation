// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappingDetailsDataGridCtrl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for MappingDetailsDataGridCtrl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.ViewModel;

    // ReSharper disable RedundantExtendsListEntry

    /// <summary>
    /// Interaction logic for MappingDetailsDataGridCtrl.xaml
    /// </summary>
    public partial class MappingDetailsDataGridCtrl : UserControl
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingDetailsDataGridCtrl" /> class.
        /// </summary>
        public MappingDetailsDataGridCtrl()
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
                viewModel.SetValue(MappingControlVm.NextPageCommandProperty, this.MappingDetailsDataGrid.NextPageCommand);
                viewModel.SetValue(MappingControlVm.PreviousPageCommandProperty, this.MappingDetailsDataGrid.PreviousPageCommand);
                viewModel.SetValue(MappingControlVm.BeginPageCommandProperty, this.MappingDetailsDataGrid.BeginPageCommand);
                viewModel.SetValue(MappingControlVm.EndPageCommandProperty, this.MappingDetailsDataGrid.EndPageCommand);
            }
        }
        
        /// <summary>
        /// Drops the tree drag enter.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void DropTreeDragEnter(object sender, DragEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox != null)
            {
                if (!e.Data.GetDataPresent(typeof(OpcItemMappingTreeChildrenVm)))
                {
                    e.Effects = DragDropEffects.None;
                }
            }
        }

        /// <summary>
        /// Drops the tree drop.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void DropTreeDrop(object sender, DragEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                if (e.Data.GetDataPresent(typeof(OpcItemMappingTreeChildrenVm)))
                {
                    var viewModel = e.Data.GetData(typeof(OpcItemMappingTreeChildrenVm)) as OpcItemMappingTreeChildrenVm;

                    if (viewModel == null)
                    {
                        return;
                    }

                    textBox.Text = viewModel.GetOpcItemPath();

                    this.UpdateQualityAndTimeStamp(textBox, viewModel.GetOpcItemPath());           
                }
            }
        }

        /// <summary>
        /// Updates the quality and time stamp.
        /// </summary>
        /// <param name="textBox">The text box.</param>
        /// <param name="text">The text.</param>
        private void UpdateQualityAndTimeStamp(TextBox textBox, string text)
        {
            //// Update Quality and TimeStamp Field also if value textBox is changed
            if (textBox.Tag.ToString() == MeasurementItemTypes.Value.ToString())
            {
                var mappingControlVm = this.DataContext as MappingControlVm;

                if (mappingControlVm != null)
                {
                    foreach (ConfiguredMeasurementItemData configuredMeasurementItemData in mappingControlVm.ConfiguredMeasurementItems)
                    {
                        if ((configuredMeasurementItemData.MeasurementItemType == MeasurementItemTypes.Quality) || (configuredMeasurementItemData.MeasurementItemType == MeasurementItemTypes.TimeStamp))
                        {
                            if ((configuredMeasurementItemData.Value == @"---") || (configuredMeasurementItemData.Value == string.Empty))
                            {
                                configuredMeasurementItemData.Value = text;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called when [preview drag over].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void OnPreviewDragOver(object sender, DragEventArgs e)
        {
            if (e != null)
            {
                e.Handled = true;
            }
        }
        
        #endregion
    }
}
