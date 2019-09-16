// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeViewItemVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Base class for all ViewModel classes displayed by TreeViewItems.
//   This acts as an adapter between a raw data object and a TreeViewItem.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    /// <summary>
    /// Class TreeViewItemVm
    /// </summary>
    public class TreeViewItemVm : INotifyPropertyChanged
    {
        #region Static Fields

        /// <summary>
        /// The dummy child
        /// </summary>
        private static readonly TreeViewItemVm DummyChild = new TreeViewItemVm();

        #endregion

        #region Fields

        /// <summary>
        /// The children
        /// </summary>
        private readonly ObservableCollection<TreeViewItemVm> children;

        /// <summary>
        /// The parent
        /// </summary>
        private readonly TreeViewItemVm parent;

        /// <summary>
        /// The is expanded
        /// </summary>
        private bool isExpanded;

        /// <summary>
        /// The is selected
        /// </summary>
        private bool isSelected;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewItemVm"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="lazyLoadChildren">if set to <c>true</c> [lazy load children].</param>
        protected TreeViewItemVm(TreeViewItemVm parent, bool lazyLoadChildren)
        {
            this.parent = parent;

            this.children = new ObservableCollection<TreeViewItemVm>();

            if (lazyLoadChildren)
            {
                this.children.Add(DummyChild);
            }
        }
        
        /// <summary>
        /// Prevents a default instance of the <see cref="TreeViewItemVm"/> class from being created.
        /// This is used to create the DummyChild instance.
        /// </summary>
        private TreeViewItemVm()
        {
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>The children.</value>
        public ObservableCollection<TreeViewItemVm> Children
        {
            get
            {
                return this.children;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has dummy child.
        /// </summary>
        /// <value><c>true</c> if this instance has dummy child; otherwise, <c>false</c>.</value>
        public bool HasDummyChild
        {
            get
            {
                return this.Children.Count == 1 && this.Children[0] == DummyChild;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is expanded.
        /// </summary>
        /// <value><c>true</c> if this instance is expanded; otherwise, <c>false</c>.</value>
        public bool IsExpanded
        {
            get
            {
                return this.isExpanded;
            }

            set
            {
                if (value != this.isExpanded)
                {
                    this.isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (this.isExpanded && this.parent != null)
                {
                    this.parent.IsExpanded = true;
                }

                // Lazy load the child items, if necessary.
                if (this.HasDummyChild)
                {
                    this.Children.Remove(DummyChild);
                    this.LoadChildren();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                if (value != this.isSelected)
                {
                    this.isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public TreeViewItemVm Parent
        {
            get
            {
                return this.parent;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the children.
        /// </summary>
        protected virtual void LoadChildren()
        {
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}