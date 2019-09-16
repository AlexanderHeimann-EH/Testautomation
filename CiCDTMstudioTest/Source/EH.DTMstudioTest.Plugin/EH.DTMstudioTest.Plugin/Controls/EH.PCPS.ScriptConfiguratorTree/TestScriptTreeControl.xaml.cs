// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScriptTreeControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Interaction logic for TestScriptTreeControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.ScriptConfiguratorTree
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    using EH.PCPS.ScriptConfiguratorTree.Model;
    using EH.PCPS.SelectionTree.Controls.Model;

    /// <summary>
    /// Class TestScriptTreeControl.
    /// </summary>
    public partial class TestScriptTreeControl : UserControl
    {
        #region Static Fields

        /// <summary>
        /// The background color property
        /// </summary>
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(TestScriptTreeControl));

        /// <summary>
        /// The background focus color property
        /// </summary>
        public static readonly DependencyProperty BackgroundFocusColorProperty = DependencyProperty.Register("BackgroundFocusColor", typeof(Brush), typeof(TestScriptTreeControl));

        /// <summary>
        /// The background focus color property
        /// </summary>
        public static readonly DependencyProperty BackgroundNotValidColorProperty = DependencyProperty.Register("BackgroundNotValidColor", typeof(Brush), typeof(TestScriptTreeControl));

        /// <summary>
        /// The foreground color property
        /// </summary>
        public static readonly DependencyProperty ForegroundColorProperty = DependencyProperty.Register("ForegroundColor", typeof(Brush), typeof(TestScriptTreeControl));

        /// <summary>
        /// The TreeView item drop event
        /// </summary>
        public static RoutedEvent TreeViewEditItemLostFocusEvent = EventManager.RegisterRoutedEvent("TreeViewEditItemLostFocus", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TestScriptTreeControl));

        /// <summary>
        /// The TreeView item drag over event
        /// </summary>
        public static RoutedEvent TreeViewItemDragOverEvent = EventManager.RegisterRoutedEvent("TreeViewItemDragOver", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TestScriptTreeControl));

        /// <summary>
        /// The TreeView item drop event
        /// </summary>
        public static RoutedEvent TreeViewItemDropEvent = EventManager.RegisterRoutedEvent("TreeViewItemDrop", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TestScriptTreeControl));

        /// <summary>
        /// The tree view item enable context menu items event.
        /// </summary>
        public static RoutedEvent TreeViewItemEnableContextMenuItemsEvent = EventManager.RegisterRoutedEvent("TreeViewItemEnableContextMenuItems", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TestScriptTreeControl));

        /// <summary>
        /// The TreeView item mouse move event
        /// </summary>
        public static RoutedEvent TreeViewItemMouseMoveEvent = EventManager.RegisterRoutedEvent("TreeViewItemMouseMove", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TestScriptTreeControl));

        /// <summary>
        /// The tree view item mouse right button down event.
        /// </summary>
        public static RoutedEvent TreeViewItemMouseRightButtonDownEvent = EventManager.RegisterRoutedEvent("TreeViewItemMouseRightButtonDown", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TestScriptTreeControl));
        
        #endregion

        ///// <summary>
        ///// The tree view item property changed event.
        ///// </summary>
        // public static RoutedEvent TreeViewItemExpandedEvent = EventManager.RegisterRoutedEvent("TreeViewItemExpanded", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SelectionTreeControl));
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestScriptTreeControl"/> class.
        /// </summary>
        public TestScriptTreeControl()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The tree view item lost focus.
        /// </summary>
        public event RoutedEventHandler TreeViewEditItemLostFocus
        {
            add
            {
                this.AddHandler(TreeViewEditItemLostFocusEvent, value);
            }

            remove
            {
                this.RemoveHandler(TreeViewEditItemLostFocusEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [TreeView item drag over].
        /// </summary>
        public event RoutedEventHandler TreeViewItemDragOver
        {
            add
            {
                this.AddHandler(TreeViewItemDragOverEvent, value);
            }

            remove
            {
                this.RemoveHandler(TreeViewItemDragOverEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [TreeView item drop].
        /// </summary>
        public event RoutedEventHandler TreeViewItemDrop
        {
            add
            {
                this.AddHandler(TreeViewItemDropEvent, value);
            }

            remove
            {
                this.RemoveHandler(TreeViewItemDropEvent, value);
            }
        }

        /// <summary>
        /// The tree view item enable context menu items.
        /// </summary>
        public event RoutedEventHandler TreeViewItemEnableContextMenuItems
        {
            add
            {
                this.AddHandler(TreeViewItemEnableContextMenuItemsEvent, value);
            }

            remove
            {
                this.RemoveHandler(TreeViewItemEnableContextMenuItemsEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [TreeView item mouse move].
        /// </summary>
        public event RoutedEventHandler TreeViewItemMouseMove
        {
            add
            {
                this.AddHandler(TreeViewItemMouseMoveEvent, value);
            }

            remove
            {
                this.RemoveHandler(TreeViewItemMouseMoveEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [TreeView item mouse move].
        /// </summary>
        public event RoutedEventHandler TreeViewItemMouseRightButtonDown
        {
            add
            {
                this.AddHandler(TreeViewItemMouseRightButtonDownEvent, value);
            }

            remove
            {
                this.RemoveHandler(TreeViewItemMouseRightButtonDownEvent, value);
            }
        }
        
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Brush BackgroundColor
        {
            get
            {
                return (Brush)this.GetValue(BackgroundColorProperty);
            }

            set
            {
                this.SetValue(BackgroundColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the background focus.
        /// </summary>
        /// <value>The color of the background focus.</value>
        public Brush BackgroundFocusColor
        {
            get
            {
                return (Brush)this.GetValue(BackgroundFocusColorProperty);
            }

            set
            {
                this.SetValue(BackgroundFocusColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the background error color.
        /// </summary>
        public Brush BackgroundNotValidColor
        {
            get
            {
                return (Brush)this.GetValue(BackgroundNotValidColorProperty);
            }

            set
            {
                this.SetValue(BackgroundNotValidColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the foreground.
        /// </summary>
        /// <value>The color of the foreground.</value>
        public Brush ForegroundColor
        {
            get
            {
                return (Brush)this.GetValue(ForegroundColorProperty);
            }

            set
            {
                this.SetValue(ForegroundColorProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Expands the specified index.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        public void Expand(int index = 0)
        {
            var node = this.ColumnTreeList.Nodes[index];
            if (node.IsExpandable)
            {
                node.IsExpanded = true;
            }
        }

        /// <summary>
        /// The delete tree model.
        /// </summary>
        private void DeleteTreeModel()
        {
            this.ColumnTreeList.TreeModel = null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Selections the tree data context changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.
        /// </param>
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var testScriptModel = (TestScriptModel)e.NewValue;
            if (testScriptModel != null)
            {
                this.SetTreeModel(testScriptModel);
            }
            else
            {
                this.DeleteTreeModel();
            }
        }

        /// <summary>
        /// The selection tree item_ on mouse right button down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnItemMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is StackPanel)
            {
                var panel = sender as StackPanel;
                var stackPanel = panel;
                var routedEventArgs = new RoutedEventArgs(TreeViewItemEnableContextMenuItemsEvent) { Source = panel.DataContext };

                this.RaiseEvent(routedEventArgs);

                stackPanel.ContextMenu = ((TestScriptItem)panel.DataContext).ContextMenuItems as ContextMenu;
            }
        }

        /// <summary>
        /// The on tree list edit item lost focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnTreeListEditItemLostFocus(object sender, RoutedEventArgs e)
        {
            var routedEventArgs = new RoutedEventArgs(TreeViewEditItemLostFocusEvent) { Source = e };
            this.RaiseEvent(routedEventArgs);
        }

        /// <summary>
        /// The on double click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnTreeListItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var clickedItem = sender as TreeListItem;
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

        /// <summary>
        /// Trees the view drag over.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="DragEventArgs"/> instance containing the event data.
        /// </param>
        private void OnTreeListItemDragOver(object sender, DragEventArgs e)
        {
            var routedEventArgs = new RoutedEventArgs(TreeViewItemDragOverEvent) { Source = e, };
            this.RaiseEvent(routedEventArgs);
        }

        /// <summary>
        /// Trees the view drop.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="DragEventArgs"/> instance containing the event data.
        /// </param>
        private void OnTreeListItemDrop(object sender, DragEventArgs e)
        {
            var routedEventArgs = new RoutedEventArgs(TreeViewItemDropEvent);
            var source = new[] { e, sender };
            routedEventArgs.Source = source;

            this.RaiseEvent(routedEventArgs);
        }

        /// <summary>
        /// Trees the view mouse move.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="MouseEventArgs"/> instance containing the event data.
        /// </param>
        private void OnTreeListItemMouseMove(object sender, MouseEventArgs e)
        {
            var routedEventArgs = new RoutedEventArgs(TreeViewItemMouseMoveEvent);
            var source = new[] { e, sender };
            routedEventArgs.Source = source;

            this.RaiseEvent(routedEventArgs);
        }

        /// <summary>
        /// The on tree list selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnTreeListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
            {
                var unselectedNode = (TreeNode)e.RemovedItems[0];
                var unselectedFeature = (TestScriptItem)unselectedNode.Tag;
                unselectedFeature.HasFocus = false;
                unselectedFeature.PropagateFocusUp(null, false);
            }

            if (e.AddedItems.Count > 0)
            {
                var selectedNode = (TreeNode)e.AddedItems[0];
                var selectedFeature = (TestScriptItem)selectedNode.Tag;
                selectedFeature.HasFocus = true;
            }
        }

        /// <summary>
        /// Handles the Loaded event of the Control control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs"/> instance containing the event data.
        /// </param>
        private void SelectionTreeControl_OnControlLoaded(object sender, RoutedEventArgs e)
        {
            this.SetTreeModel(this.DataContext as TestScriptModel);
            this.DataContextChanged += this.OnDataContextChanged;
        }

        /// <summary>
        /// The set tree model.
        /// </summary>
        /// <param name="testScriptModel">
        /// The feature model.
        /// </param>
        private void SetTreeModel(TestScriptModel testScriptModel)
        {
            if (testScriptModel != null)
            {
                this.ColumnTreeList.TreeModel = new TreeModel { TestScriptList = testScriptModel.TestScriptList };
            }
        }

        /// <summary>
        /// The test script tree control_ on size changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TestScriptTreeControl_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var size = sender as UserControl;

            if (size != null)
            {
                this.ColumnTreeList.Height = size.ActualHeight;
            }
        }

        /// <summary>
        /// The text box_ on is visible changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TextBox_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var nameTextBox = sender as TextBox;
            if (nameTextBox != null && nameTextBox.IsVisible)
            {
                nameTextBox.Focus();
            }
        }

        #endregion
    }
}