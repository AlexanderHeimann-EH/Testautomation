// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappingDataGridCtrl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for MappingDataGridCtrl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;

    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.Rules;
    using EH.ImsOpcBridge.Configurator.ViewModel;

    /// <summary>
    /// Class MappingDataGridCtrl
    /// </summary>
    public partial class MappingDataGridCtrl : UserControl
    {
        #region Static Fields

        /// <summary>
        /// The configured measurements property
        /// </summary>
        public static readonly DependencyProperty ConfiguredMeasurementsProperty = DependencyProperty.Register("ConfiguredMeasurements", typeof(ObservableCollection<ConfiguredMeasurementData>), typeof(MappingDataGridCtrl), new PropertyMetadata(default(ObservableCollection<ConfiguredMeasurementData>)));

        /// <summary>
        /// The current item set property
        /// </summary>
        public static readonly DependencyProperty CurrentItemSetProperty = DependencyProperty.Register("CurrentItemSet", typeof(object), typeof(MappingDataGridCtrl), new FrameworkPropertyMetadata(null, OnCurrentItemSetChanged));

        /// <summary>
        /// The validation error property
        /// </summary>
        public static readonly DependencyProperty ValidationErrorProperty = DependencyProperty.Register("ValidationError", typeof(string), typeof(MappingDataGridCtrl), new PropertyMetadata(string.Empty));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingDataGridCtrl"/> class.
        /// </summary>
        public MappingDataGridCtrl()
        {
            this.ConfiguredMeasurements = new ObservableCollection<ConfiguredMeasurementData>();
            this.ConfiguredMeasurements.Clear();
            this.InitializeComponent();
            this.MappingDataGrid.GotFocus += this.CallGotFocus;

            ////this.MappingDataGrid.Loaded += this.CallLoaded;
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

        #region Public Properties

        /// <summary>
        /// Gets or sets the configured measurements.
        /// </summary>
        /// <value>The configured measurements.</value>
        public ObservableCollection<ConfiguredMeasurementData> ConfiguredMeasurements
        {
            get
            {
                return (ObservableCollection<ConfiguredMeasurementData>)this.GetValue(ConfiguredMeasurementsProperty);
            }

            set
            {
                this.SetValue(ConfiguredMeasurementsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current item set.
        /// </summary>
        /// <value>The current item set.</value>
        public object CurrentItemSet
        {
            get
            {
                return (object)this.GetValue(CurrentItemSetProperty);
            }

            set
            {
                this.SetValue(CurrentItemSetProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the validation error.
        /// </summary>
        /// <value>The validation error.</value>
        public string ValidationError
        {
            get
            {
                return (string)this.GetValue(ValidationErrorProperty);
            }

            set
            {
                this.SetValue(ValidationErrorProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the visual child.
        /// </summary>
        /// <typeparam name="T">Type param</typeparam>
        /// <param name="parent">The parent.</param>
        /// <returns>Returns Type</returns>
        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;

                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                else
                {
                    break;
                }
            }

            return child;
        }

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
        /// Called when [current item set changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCurrentItemSetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mappingDataGridCtrl = sender as MappingDataGridCtrl;
            if (mappingDataGridCtrl != null)
            {
                mappingDataGridCtrl.MappingDataGrid.UpdateLayout();

                var selectedConfiguredMeasurementData = e.NewValue as ConfiguredMeasurementData;

                if (selectedConfiguredMeasurementData != null && mappingDataGridCtrl.ConfiguredMeasurements != null)
                {
                    var currentRowIndex = mappingDataGridCtrl.ConfiguredMeasurements.IndexOf(selectedConfiguredMeasurementData);

                    if (currentRowIndex == -1)
                    {
                        return;
                    }

                    var rowContainer = (DataGridRow)mappingDataGridCtrl.MappingDataGrid.ItemContainerGenerator.ContainerFromItem(selectedConfiguredMeasurementData);

                    if (rowContainer != null)
                    {
                        var presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

                        var cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(1);

                        if (cell != null)
                        {
                            cell.IsSelected = true;

                            ////TextBox textBox = GetVisualChild<TextBox>(cell);
                            ////if (textBox != null)
                            ////{
                            ////    textBox.Focus();
                            ////}
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calls the got focus.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CallGotFocus(object sender, RoutedEventArgs e)
        {
            // Lookup for the source to be DataGridCell
            if (e.OriginalSource.GetType() == typeof(TextBox))
            {
                var textBox = (TextBox)e.OriginalSource;

                var currentRowIndex = this.MappingDataGrid.Items.IndexOf(this.MappingDataGrid.CurrentItem);

                if (currentRowIndex == -1)
                {
                    return;
                }

                if (this.MappingDataGrid.CurrentColumn == null)
                {
                    return;
                }

                var currentColumnIndex = this.MappingDataGrid.CurrentColumn.DisplayIndex;

                string name = textBox.Name;

                if (name == @"FilterTextBox")
                {
                    return;
                }

                Binding binding = BindingOperations.GetBinding(textBox, TextBox.TextProperty);

                if (binding != null)
                {
                    binding.ValidationRules.Clear();

                    var singleItemRule = new SingleItemRule();

                    singleItemRule.Row = currentRowIndex;
                    singleItemRule.Column = currentColumnIndex;
                    singleItemRule.ConfiguredMeasurements = this.ConfiguredMeasurements;

                    binding.ValidationRules.Add(singleItemRule);
                }
            }
        }

        ////private void CallLoaded(object sender, RoutedEventArgs e)
        ////{
        ////    if (this.MappingDataGrid.CurrentItem == null)
        ////    {
        ////        //if (this.ConfiguredMeasurements != null && (this.ConfiguredMeasurements.Count > 0))
        ////        //{
        ////        //    var currentItem = this.ConfiguredMeasurements[0];
        ////        //    var rowContainer = (DataGridRow)this.MappingDataGrid.ItemContainerGenerator.ContainerFromItem(currentItem);
        ////        //    if (rowContainer != null)
        ////        //    {
        ////        //        var presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
        ////        //        var cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(1);
        ////        //        if (cell != null)
        ////        //        {
        ////        //            cell.IsSelected = true;
        ////        //            ////TextBox textBox = GetVisualChild<TextBox>(cell);
        ////        //            ////if (textBox != null)
        ////        //            ////{
        ////        //            ////    textBox.Focus();
        ////        //            ////}
        ////        //        }
        ////        //    }
        ////        //}
        ////    }
        ////    else
        ////    {
        ////    }
        ////}
        
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

                if (!e.Data.GetDataPresent(typeof(OpcItemMappingTreeRootVm)))
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

                    ((TextBox)sender).Focus();
                    ((TextBox)sender).Text = viewModel.OpcItemName;
                }

                if (e.Data.GetDataPresent(typeof(OpcItemMappingTreeRootVm)))
                {
                    var viewModel = e.Data.GetData(typeof(OpcItemMappingTreeRootVm)) as OpcItemMappingTreeRootVm;

                    if (viewModel == null)
                    {
                        return;
                    }

                    ((TextBox)sender).Focus();
                    ((TextBox)sender).Text = viewModel.RootOpcItemName;
                }
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
                if (!string.IsNullOrEmpty(this.MappingDataGrid.FilterStringColumn1))
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
                if (!string.IsNullOrEmpty(this.MappingDataGrid.FilterStringColumn2))
                {
                    expander.IsExpanded = true;
                }
            }
        }

        /// <summary>
        /// Mappings the data grid data context changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void MappingDataGridDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = e.NewValue as DependencyObject;
            if (viewModel != null)
            {
                viewModel.SetValue(MappingControlVm.NextPageCommandProperty, this.MappingDataGrid.NextPageCommand);
                viewModel.SetValue(MappingControlVm.PreviousPageCommandProperty, this.MappingDataGrid.PreviousPageCommand);
                viewModel.SetValue(MappingControlVm.BeginPageCommandProperty, this.MappingDataGrid.BeginPageCommand);
                viewModel.SetValue(MappingControlVm.EndPageCommandProperty, this.MappingDataGrid.EndPageCommand);
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

        /// <summary>
        /// Texts the box error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ValidationErrorEventArgs"/> instance containing the event data.</param>
        private void TextBoxError(object sender, ValidationErrorEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox != null)
            {
                if (Validation.GetHasError(textBox))
                {
                    ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
                    this.ValidationError = e.Error.ErrorContent.ToString();
                }
                else
                {
                    ((Control)sender).ToolTip = string.Empty;
                    this.ValidationError = string.Empty;
                }
            }

            ////if (e.Action == ValidationErrorEventAction.Added)
            ////{
            ////    ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            ////    this.ValidationError = e.Error.ErrorContent.ToString();
            ////}
            ////else
            ////{
            ////    ((Control)sender).ToolTip = string.Empty;
            ////    this.ValidationError = string.Empty;
            ////}
        }

        #endregion
    }
}