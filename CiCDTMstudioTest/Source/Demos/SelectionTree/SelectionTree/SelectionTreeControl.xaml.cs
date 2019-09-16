using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Globalization;

using MenuButton.Controls;
using SelectionTree.Controls.Tree;


namespace SelectionTree
{
    /// <summary>
    /// Interaction logic for SelectionTreeControl.xaml
    /// </summary>
    public partial class SelectionTreeControl : UserControl
    {
        #region Properties

        /// <summary>
        /// The items of the Context Menu entry list hosted by the MenuButton
        /// </summary>
        private MenuLabelCollection _menuLabelList = new MenuLabelCollection();
        public MenuLabelCollection MenuLabelList
        {
            get { return _menuLabelList; }
            set { _menuLabelList = value; }
        }

        /// <summary>
        /// MenuButton background colour without focus
        /// </summary>
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor",
                                                                                                        typeof(Brush),
                                                                                                        typeof(SelectionTreeControl));
        /// <summary>
        /// The background colour value
        /// </summary>
        public Brush BackgroundColor
        {
            get { return (Brush)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        /// <summary>
        /// MenuButton background colour with focus
        /// </summary>
        public static readonly DependencyProperty BackgroundFocusColorProperty = DependencyProperty.Register("BackgroundFocusColor",
                                                                                                             typeof(Brush),
                                                                                                             typeof(SelectionTreeControl));
        /// <summary>
        /// The background colour value
        /// </summary>
        public Brush BackgroundFocusColor
        {
            get { return (Brush)GetValue(BackgroundFocusColorProperty); }
            set { SetValue(BackgroundFocusColorProperty, value); }
        }

        /// <summary>
        /// MenuButton foreground colour
        /// </summary>
        public static readonly DependencyProperty ForegroundColorProperty = DependencyProperty.Register("ForegroundColor",
                                                                                                        typeof(Brush),
                                                                                                        typeof(SelectionTreeControl));
        /// <summary>
        /// The foreground colour value
        /// </summary>
        public Brush ForegroundColor
        {
            get { return (Brush)GetValue(ForegroundColorProperty); }
            set { SetValue(ForegroundColorProperty, value); }
        }

        #endregion Properties

        public SelectionTreeControl()
        {
            InitializeComponent();
        }

        public void Expand(int index = 0)
        {
            TreeNode node = ColumnTree.Nodes[index];
            if (node.IsExpandable)
                node.IsExpanded = true;
        }


        #region Events

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            FeatureModel fm = this.DataContext as FeatureModel;
            TreeModel model = new TreeModel();
            model.Features = fm.FeatureList;

            ColumnTree.Model = model;

            // Move the localised menu item entries
            foreach (MenuLabel item in fm.ContextMenuEntries)
            {
                MenuLabelList.Add(new MenuLabel { Text = item.Text });
            }

            this.DataContextChanged += new DependencyPropertyChangedEventHandler(SelectionTreeDataContextChanged);
        }

        void SelectionTreeDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FeatureModel nfm = (FeatureModel)e.NewValue;
            if (nfm != null)
            {
                TreeModel tm = new TreeModel();
                tm.Features = nfm.FeatureList;
                ColumnTree.Model = tm;
            }
        }

        private void OnTreeListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
            {
                TreeNode unselectedNode = (TreeNode)e.RemovedItems[0];
                Feature unselectedFeature = (Feature)(unselectedNode.Tag);
                unselectedFeature.HasFocus = false;
            }
            if (e.AddedItems.Count > 0)
            {
                TreeNode selectedNode = (TreeNode)e.AddedItems[0];
                Feature selectedFeature = (Feature)(selectedNode.Tag);
                selectedFeature.HasFocus = true;
            }
        }

        private void OnDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeListItem clickedItem = sender as TreeListItem;
            if (clickedItem != null)
            {
                TreeNode clickedNode = clickedItem.Node;
                if (clickedNode.HasChildren)
                {
                    clickedNode.IsExpanded = !clickedNode.IsExpanded;
                    e.Handled = true;
                }
            }
        }


        #endregion Events

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ColumnTree.SelectedNode != null)
            {
                var p = new Feature("New Feature");
                (ColumnTree.SelectedNode.Tag as Feature).Children.Add(p);
                ColumnTree.SelectedNode.IsExpanded = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ColumnTree.SelectedNode != null)
            {
                var parent = ColumnTree.SelectedNode.Parent.Tag as Feature;
                var child = ColumnTree.SelectedNode.Tag as Feature;
                parent.Children.Remove(child);
            }
        }
    }


    ///// <summary>
    ///// This converter does nothing except breaking the
    ///// debugger into the convert method
    ///// </summary>
    //internal class DatabindingDebugConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (Debugger.IsAttached)
    //            Debugger.Break();
    //        return value;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (Debugger.IsAttached)
    //            Debugger.Break();
    //        return value;
    //    }
    //}

    /// <summary>
    /// Convertes InInFocusChain to appropriate color
    /// </summary>
    internal class ColorConverter : IMultiValueConverter
    {
        public object Convert(object[] o, Type type, object parameter, CultureInfo culture)
        {
            Brush color = o[0] as Brush;
            Brush focusColor = o[1] as Brush;
            bool isInFocusChain = (bool)o[2];
            if (isInFocusChain)
                return focusColor;
            else
                return color;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Convertes headers to metrostyle upper case
    /// </summary>
    internal class ToUpperConverter : IValueConverter
    {
        public object Convert(object o, Type type, object parameter, CultureInfo culture)
        {
            return o != null ? ((string)o).ToUpper() : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
