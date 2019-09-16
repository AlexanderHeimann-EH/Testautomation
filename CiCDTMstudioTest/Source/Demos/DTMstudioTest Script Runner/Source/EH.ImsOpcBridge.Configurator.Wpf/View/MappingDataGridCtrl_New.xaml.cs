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
    using System;
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
        /// The validation error property
        /// </summary>
        public static readonly DependencyProperty ValidationErrorProperty = DependencyProperty.Register("ValidationError", typeof(string), typeof(MappingDataGridCtrl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The validation rule property
        /// </summary>
        public static readonly DependencyProperty ValidationRuleProperty = DependencyProperty.Register("ValidationRule", typeof(string), typeof(MappingDataGridCtrl), new PropertyMetadata(string.Empty, ValidationRuleChanged));



        /// <summary>
        /// The configured measurements property
        /// </summary>
        public static readonly DependencyProperty ConfiguredMeasurementsProperty = DependencyProperty.Register("ConfiguredMeasurements", typeof(ObservableCollection<ConfiguredMeasurementData>), typeof(MappingDataGridCtrl), new PropertyMetadata(default(ObservableCollection<ConfiguredMeasurementData>)));



        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingDataGridCtrl"/> class.
        /// </summary>
        public MappingDataGridCtrl()
        {
            this.InitializeComponent();

            this.ClearValidationRules();

            this.Loaded += this.MappingDataGridLoaded;
            this.Unloaded += this.MappingDataGridUnloaded;

           this.MappingDataGrid.GotFocus += this.GotFocus;
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
        /// Gets or sets the validation rule.
        /// </summary>
        /// <value>The validation rule.</value>
        public string ValidationRule
        {
            get
            {
                return (string)this.GetValue(ValidationRuleProperty);
            }

            set
            {
                this.SetValue(ValidationRuleProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the visual child.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent">The parent.</param>
        /// <returns>``0.</returns>
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
        /// <returns>System.String.</returns>
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
        /// Validations the rule changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void ValidationRuleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mappingDataGridCtrl = sender as MappingDataGridCtrl;
            if (mappingDataGridCtrl != null)
            {
                mappingDataGridCtrl.UpdateValidationRules(mappingDataGridCtrl, null);
            }
        }

        /// <summary>
        /// Clears the validation rules.
        /// </summary>
        private void ClearValidationRules()
        {
            for (int rowindex = 0; rowindex < this.MappingDataGrid.Items.Count; rowindex++)
            {
                DataGridRow rowContainer = (DataGridRow)this.MappingDataGrid.ItemContainerGenerator.ContainerFromIndex(rowindex);
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

                for (int i = 1; i < 3; i++)
                {
                    DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);

                    if (cell != null)
                    {
                        TextBox textBox = GetVisualChild<TextBox>(cell);
                        if (textBox != null)
                        {
                            Binding binding = BindingOperations.GetBinding(textBox, TextBox.TextProperty);

                            if (binding != null)
                            {
                                binding.ValidationRules.Clear();
                            }
                        }
                    }
                }
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

                    ((TextBox)sender).Text = viewModel.OpcItemName;
                }
            }
        }

        /// <summary>
        /// Expanders the collumn1 collapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ExpanderCollumn1Collapsed(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;

            // Block Collapsing if filter string in not empty
            if (expander != null)
            {
                if (!string.IsNullOrEmpty(this.MappingDataGrid.FilterStringCollumn1))
                {
                    expander.IsExpanded = true;
                }
            }
        }

        /// <summary>
        /// Expanders the collumn2 collapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ExpanderCollumn2Collapsed(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;

            // Block Collapsing if filter string in not empty
            if (expander != null)
            {
                if (!string.IsNullOrEmpty(this.MappingDataGrid.FilterStringCollumn2))
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


                var configuredMeasurements = viewModel.GetValue(MappingControlVm.ConfiguredMeasurementsProperty) as ObservableCollection<ConfiguredMeasurementData>;

                if (configuredMeasurements != null)
                {
                    this.UpdateValidationRules(this, configuredMeasurements);
                    
                }

            }
        }



        //private MappingControlVm ViewModel1
        //{
        //  get { return (MappingControlVm)this.v .ViewModel; }   
        //}
  

        /// <summary>
        /// Mappings the data grid loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void MappingDataGridLoaded(object sender, RoutedEventArgs e)
        {
            // we manually fire the bindings so we get the validation initially
            var mappingDataGridCtrl = sender as MappingDataGridCtrl;
         

            if (mappingDataGridCtrl != null)
            {
                mappingDataGridCtrl.ClearValidationRules();

             

             //   var configuredMeasurements = viewModel.GetValue(MappingControlVm.ConfiguredMeasurementsProperty) as ObservableCollection<ConfiguredMeasurementData>;

          
                    this.UpdateValidationRules(this, this.ConfiguredMeasurements);
                    this.UpdateSourceValidation(this, this.ConfiguredMeasurements);
                

              

            }
        }

        /// <summary>
        /// Mappings the data grid unloaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void MappingDataGridUnloaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= this.MappingDataGridLoaded;
            this.Unloaded -= this.MappingDataGridUnloaded;
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
        /// Registers the rule.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="textBox">The text box.</param>
        /// <param name="intRangeMin">The int range min.</param>
        /// <param name="intRangeMax">The int range max.</param>
        /// <param name="configuredMeasurements">The configured measurements.</param>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        private void RegisterRule(string ruleName, TextBox textBox, int intRangeMin, int intRangeMax, ObservableCollection<ConfiguredMeasurementData> configuredMeasurements, int row, int column)
        {
            Binding binding = BindingOperations.GetBinding(textBox, TextBox.TextProperty);

            if (binding == null)
            {
                return;
            }

            switch (ruleName)
            {
                case "ByteArrayRule":
                    {
                        var rule = new ByteArrayRule();
                        binding.ValidationRules.Add(rule);
                        break;
                    }

                case "IntRangeRule":
                    {
                        var rule = new IntRangeRule();
                        rule.Min = intRangeMin;
                        rule.Max = intRangeMax;
                        binding.ValidationRules.Add(rule);
                        break;
                    }

                case "IpAddressRule":
                    {
                        var rule = new IpAddressRule();
                        binding.ValidationRules.Add(rule);
                        break;
                    }

                case "NotNullOrEmptyRule":
                    {
                        var rule = new NotNullOrEmptyRule();
                        binding.ValidationRules.Add(rule);
                        break;
                    }

                case "OpcItemIdRule":
                    {
                        var rule = new OpcItemIdRule();
                        binding.ValidationRules.Add(rule);
                        break;
                    }

                case "SingleItemRule":
                    {
                        var rule = new SingleItemRule(row, column, textBox.Text);
                        rule.Items1 = configuredMeasurements;
                      
                        binding.ValidationRules.Add(rule);
                        break;
                    }
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

        /// <summary>
        /// Updates the validation rules.
        /// </summary>
        /// <param name="mappingDataGridCtrl">The mapping data grid CTRL.</param>
        private void UpdateValidationRules(MappingDataGridCtrl mappingDataGridCtrl, ObservableCollection<ConfiguredMeasurementData> configuredMeasurements)
        {
            // In case multiple rules are bound then it would come like "Required|Numeric
            var validationRules = mappingDataGridCtrl.ValidationRule.Split(new[] { "|", }, StringSplitOptions.RemoveEmptyEntries);

            for (int rowindex = 0; rowindex < mappingDataGridCtrl.MappingDataGrid.Items.Count; rowindex++)
            {
                DataGridRow rowContainer = (DataGridRow)mappingDataGridCtrl.MappingDataGrid.ItemContainerGenerator.ContainerFromIndex(rowindex);
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

                for (int i = 1; i < 3; i++)
                {
                    DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);

                    if (cell != null)
                    {
                        TextBox textBox = GetVisualChild<TextBox>(cell);
                        if (textBox != null)
                        {
                            Binding binding = BindingOperations.GetBinding(textBox, TextBox.TextProperty);

                            if (binding != null)
                            {
                                binding.ValidationRules.Clear();
                            }

                            foreach (var rule in validationRules)
                            {
                                mappingDataGridCtrl.RegisterRule(rule, textBox, 0, 0, configuredMeasurements, rowindex, i );
                            }

                        }
                    }
                }
            }
        }

        
        private void GotFocus(object sender, RoutedEventArgs e)
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

                    var singleItemRule = new SingleItemRule(currentRowIndex, currentColumnIndex, textBox.Text);

                    singleItemRule.Items1 = this.ConfiguredMeasurements;


                    binding.ValidationRules.Add(singleItemRule);
                }

            }
            
        }

        
        private void UpdateSourceValidation(MappingDataGridCtrl mappingDataGridCtrl, ObservableCollection<ConfiguredMeasurementData> configuredMeasurements)
        {
            // In case multiple rules are bound then it would come like "Required|Numeric
            var validationRules = mappingDataGridCtrl.ValidationRule.Split(new[] { "|", }, StringSplitOptions.RemoveEmptyEntries);

            for (int rowindex = 0; rowindex < mappingDataGridCtrl.MappingDataGrid.Items.Count; rowindex++)
            {
                DataGridRow rowContainer = (DataGridRow)mappingDataGridCtrl.MappingDataGrid.ItemContainerGenerator.ContainerFromIndex(rowindex);
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

                for (int i = 1; i < 3; i++)
                {
                    DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);

                    if (cell != null)
                    {
                        TextBox textBox = GetVisualChild<TextBox>(cell);
                        if (textBox != null)
                        {
                           
                            var bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);

                            if (bindingExpression != null)
                            {
                                bindingExpression.UpdateSource();
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
    

}