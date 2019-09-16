// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpcAddressSpaceControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The opc address space control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    using EH.ImsOpcBridge.Configurator.ViewModel;

    using log4net;

    /// <summary>
    /// Class OpcAddressSpaceControl
    /// </summary>
    public partial class OpcAddressSpaceControl : UserControl
    {
        #region Static Fields

        /// <summary>
        /// The allow drag property
        /// </summary>
        public static readonly DependencyProperty AllowDragProperty = DependencyProperty.Register("AllowDrag", typeof(bool), typeof(OpcAddressSpaceControl), new PropertyMetadata(false));

        /// <summary>
        /// The is drag able property
        /// </summary>
        public static readonly DependencyProperty IsDragAbleProperty = DependencyProperty.Register("IsDragAble", typeof(bool), typeof(OpcAddressSpaceControl), new PropertyMetadata(false));

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        /// <summary>
        /// The start point
        /// </summary>
        private Point startPoint;

        /// <summary>
        /// The tree view item
        /// </summary>
        private TreeViewItem treeViewItem;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpcAddressSpaceControl"/> class.
        /// </summary>
        public OpcAddressSpaceControl()
        {
            this.AllowDrag = true;
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow drag].
        /// </summary>
        /// <value><c>true</c> if [allow drag]; otherwise, <c>false</c>.</value>
        public bool AllowDrag
        {
            get
            {
                return (bool)this.GetValue(AllowDragProperty);
            }

            set
            {
                this.SetValue(AllowDragProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is drag able.
        /// </summary>
        /// <value><c>true</c> if this instance is drag able; otherwise, <c>false</c>.</value>
        public bool IsDragAble
        {
            get
            {
                return (bool)this.GetValue(IsDragAbleProperty);
            }

            set
            {
                this.SetValue(IsDragAbleProperty, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the ancestor.
        /// </summary>
        /// <param name="current">The current.</param>
        /// <returns>Returns TreeViewItem</returns>
        private static TreeViewItem FindAncestor(DependencyObject current)
        {
            do
            {
                if (current is TreeViewItem)
                {
                    return (TreeViewItem)current;
                }

                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        /// <summary>
        /// Determines whether the specified drag start point is dragging.
        /// </summary>
        /// <param name="dragStartPoint">The drag start point.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        /// <returns><c>true</c> if the specified drag start point is dragging; otherwise, <c>false</c>.</returns>
        private bool IsDragging(Point dragStartPoint, MouseEventArgs e)
        {
            var difference = e.GetPosition(null) - dragStartPoint;
            ////this.TextBox.Text = string.Format(@" x: {0}  y: {1}  Min Hor: {2} Min Vert: {3}", difference.X, difference.Y, SystemParameters.MinimumHorizontalDragDistance, SystemParameters.MinimumVerticalDragDistance);

            const double MinimumHorizontalDragDistance = 1; ////SystemParameters.MinimumHorizontalDragDistance;
            const double MinimumVerticalDragDistance = 1; //// SystemParameters.MinimumVerticalDragDistance;

            return (e.LeftButton == MouseButtonState.Pressed) && ((Math.Abs(difference.X) > MinimumHorizontalDragDistance) || (Math.Abs(difference.Y) > MinimumVerticalDragDistance));
        }

        /// <summary>
        /// Trees the mouse move.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void TreeMouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsDragging(this.startPoint, e))
            {
                var treeView = sender as TreeView;

                if (treeView == null || this.treeViewItem == null)
                {
                    return;
                }

                var viewModelTreeChildren = treeView.SelectedItem as OpcItemMappingTreeChildrenVm;

                if (viewModelTreeChildren == null)
                {
                    var viewModelTreeRoot = treeView.SelectedItem as OpcItemMappingTreeRootVm;

                    if (viewModelTreeRoot != null)
                    {
                        if (this.AllowDrag)
                        {
                            var dragData = new DataObject(viewModelTreeRoot);
                            DragDrop.DoDragDrop(this.treeViewItem, dragData, DragDropEffects.Move);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                
                if (viewModelTreeChildren != null)
                {
                    if (viewModelTreeChildren.IsOpcItemDragAble() || this.AllowDrag)
                    {
                        var dragData = new DataObject(viewModelTreeChildren);
                        DragDrop.DoDragDrop(this.treeViewItem, dragData, DragDropEffects.Move);
                    }
                }

                e.Handled = true;
            }
        }
        
        /// <summary>
        /// Trees the preview mouse left button down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void TreePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.startPoint = e.GetPosition(null);
            this.treeViewItem = FindAncestor((DependencyObject)e.OriginalSource);
            ////this.TextBox.Text = e.OriginalSource.ToString();
        }

        #endregion
    }
}