// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AriadnepathControlVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The ariadnepath control vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// The ariadnepath control vm.
    /// </summary>
    public class AriadnePathControlVm : DependencyObject
    {
        #region Static Fields

        /// <summary>
        /// The ariadnepath dynamic end property.
        /// </summary>
        public static readonly DependencyProperty AriadnePathDynamicEndPolyProperty = DependencyProperty.Register("AriadnePathDynamicEndPoly", typeof(PointCollection), typeof(AriadnePathControlVm), new PropertyMetadata(default(PointCollection)));

        /// <summary>
        /// The ariadnepath dynamic end property.
        /// </summary>
        public static readonly DependencyProperty AriadnePathDynamicEndProperty = DependencyProperty.Register("AriadnePathDynamicEnd", typeof(int), typeof(AriadnePathControlVm), new PropertyMetadata(default(int)));

        /// <summary>
        /// The is enabled property.
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.Register("IsEnabled", typeof(bool), typeof(AriadnePathControlVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The is visible property.
        /// </summary>
        public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.Register("IsVisible", typeof(bool), typeof(AriadnePathControlVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The path items property.
        /// </summary>
        public static readonly DependencyProperty PathItemsProperty = DependencyProperty.Register("PathItems", typeof(ObservableCollection<AriadnePathControlItemVm>), typeof(AriadnePathControlVm), new PropertyMetadata(default(ObservableCollection<AriadnePathControlItemVm>)));

       //// <summary>
       //// The selected item property.
       //// </summary>
       //// public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(AriadnePathControlItemVm), typeof(AriadnePathControlVm), new FrameworkPropertyMetadata(default(NetworkItem), OnSelectedItemChanged));

        #endregion

        #region Fields

        /// <summary>
        /// The main window vm.
        /// </summary>
        private readonly MainWindowVm mainWindowVm;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AriadnePathControlVm" /> class.
        /// </summary>
        public AriadnePathControlVm()
        {
            this.IsVisible = true;
            this.IsEnabled = true;
            this.PathItems = new ObservableCollection<AriadnePathControlItemVm>();

            var item = new AriadnePathControlItemVm();
            item.ButtonName = "Home";
            item.ButtonNameToolTip = "shows the homescreen";
            item.ItemDetailText = "DetailText: shows the homescreen";
            item.ItemDetailToolTip = "ToolTip: shows the homescreen";
            item.IsFirstStepVisible = true;
            this.PathItems.Add(item);

            item = new AriadnePathControlItemVm();
            item.ButtonName = "Test2";
            item.ButtonNameToolTip = "ToolTip: shows Test2";
            item.IsFirstStepVisible = false;
            this.PathItems.Add(item);

            item = new AriadnePathControlItemVm();
            item.ButtonName = "Test3";
            item.ButtonNameToolTip = "ToolTip: shows Test3";
            item.IsFirstStepVisible = false;
            this.PathItems.Add(item);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AriadnePathControlVm" /> class.
        /// </summary>
        /// <param name="mainWindowVm">The main window vm.</param>
        public AriadnePathControlVm(MainWindowVm mainWindowVm)
        {
            this.IsVisible = true;
            this.IsEnabled = false;

            this.mainWindowVm = mainWindowVm;
            this.PathItems = new ObservableCollection<AriadnePathControlItemVm>();
            this.ClearPath();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the ariadnepath dynamic end.
        /// </summary>
        /// <value>The ariadne path dynamic end.</value>
        public int AriadnePathDynamicEnd
        {
            get
            {
                return (int)this.GetValue(AriadnePathDynamicEndProperty);
            }

            set
            {
                this.SetValue(AriadnePathDynamicEndProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the ariadnepath dynamic end.
        /// </summary>
        /// <value>The ariadne path dynamic end poly.</value>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = @"OK here.")]
        public PointCollection AriadnePathDynamicEndPoly
        {
            get
            {
                return (PointCollection)this.GetValue(AriadnePathDynamicEndPolyProperty);
            }

            set
            {
                this.SetValue(AriadnePathDynamicEndPolyProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
        public bool IsEnabled
        {
            get
            {
                return (bool)this.GetValue(IsEnabledProperty);
            }

            set
            {
                this.SetValue(IsEnabledProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is visible.
        /// </summary>
        /// <value><c>true</c> if this instance is visible; otherwise, <c>false</c>.</value>
        public bool IsVisible
        {
            get
            {
                return (bool)this.GetValue(IsVisibleProperty);
            }

            set
            {
                this.SetValue(IsVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets the main window vm.
        /// </summary>
        /// <value>The main window vm.</value>
        public MainWindowVm MainWindowVm
        {
            get
            {
                return this.mainWindowVm;
            }
        }

        /// <summary>
        /// Gets the path items.
        /// </summary>
        /// <value>The path items.</value>
        public ObservableCollection<AriadnePathControlItemVm> PathItems
        {
            get
            {
                return (ObservableCollection<AriadnePathControlItemVm>)this.GetValue(PathItemsProperty);
            }

            private set
            {
                this.SetValue(PathItemsProperty, value);
            }
        }

        /////// <summary>
        /////// Gets or sets the selected item.
        /////// </summary>
        /////// <value>The selected item.</value>
        ////public AriadnePathControlItemVm SelectedItem
        ////{
        ////    get
        ////    {
        ////        return (AriadnePathControlItemVm)this.GetValue(SelectedItemProperty);
        ////    }

        ////    set
        ////    {
        ////        this.SetValue(SelectedItemProperty, value);
        ////    }
        ////}

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The clear path.
        /// </summary>
        public void ClearPath()
        {
            this.PathItems.Clear();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on selected item changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selectedItem = e.NewValue as AriadnePathControlItemVm;
            if (selectedItem != null)
            {
                if (selectedItem.ExecuteActionCommand != null && selectedItem.ExecuteActionCommand.IsExecutable)
                {
                    selectedItem.ExecuteActionCommand.Execute(selectedItem);
                }
            }
        }

        #endregion
    }
}
