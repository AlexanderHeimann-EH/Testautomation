using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

using MenuButton.Controls;


namespace SelectionTree
{
    /// <summary>
    /// Class Feature.
    /// </summary>
    public class Feature : DependencyObject
    {
        #region Properties

        /// <summary>
        /// InstallAction (installer engine's LaunchAction)
        /// </summary>
        public static readonly DependencyProperty InstallActionProperty = DependencyProperty.Register("InstallAction",
                                                typeof(InstallType), 
                                                typeof(Feature), 
                                                new UIPropertyMetadata(InstallType.eIndeterminate,
                                                                       new PropertyChangedCallback(OnInstallActionChanged)));
        public InstallType InstallAction
        {
            get { return (InstallType)GetValue(InstallActionProperty); }
            set { SetValue(InstallActionProperty, value); }
        }

        /// <summary>
        /// HasFocus (indicates the feature that is selected)
        /// </summary>
        public static readonly DependencyProperty HasFocusProperty = DependencyProperty.Register("HasFocus",
                                                typeof(bool),
                                                typeof(Feature),
                                                new UIPropertyMetadata(false,
                                                                       new PropertyChangedCallback(OnFocusChanged)));
        public bool HasFocus
        {
            get { return (bool)GetValue(HasFocusProperty); }
            set { SetValue(HasFocusProperty, value); }
        }

        /// <summary>
        /// IsInFocusChain (determines the color of expander and menu button)
        /// </summary>
        public static readonly DependencyProperty IsInFocusChainProperty = DependencyProperty.Register("IsInFocusChain",
                                                typeof(bool),
                                                typeof(Feature),
                                                new UIPropertyMetadata(false,
                                                                       new PropertyChangedCallback(OnFocusChainChanged)));
        public bool IsInFocusChain
        {
            get { return (bool)GetValue(IsInFocusChainProperty); }
            set { SetValue(IsInFocusChainProperty, value); }
        }

        /// <summary>
        /// Previously set InstallAction that indicates that sth. was changed
        /// </summary>
        public InstallType PreviousAction;

        /// <summary>
        /// Indicates that feature is a group (e.g. protocol, measuring method, ...)
        /// </summary>
        public bool IsGroup { get; set; }

        /// <summary>
        /// Flag that reflects tree modifications in the top level group
        /// </summary>
        public bool IsInstallActionModified { get; set; }

        /// <summary>
        /// Indicates that migration is enabled in the whole tree
        /// </summary>
        public bool IsMigration { get; set; }

        /// <summary>
        /// Index to the feature in the BO container's feature collection
        /// </summary>
        public int BoListIndex { get; set; }

        /// <summary>
        /// Product name displayed in the selection tree
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Version of the feature with a BO container state "activated"
        /// </summary>
        public string InstalledVersion { get; set; }

        /// <summary>
        /// Version of the feature with the highest BO container version and BO container state "available"
        /// </summary>
        public string AvailableVersion { get; set; }

        /// <summary>
        /// Feature size excl. all dependencies
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// Collection of children
        /// </summary>
        public FeatureCollection Children { get; set; }

        /// <summary>
        /// Parent feature
        /// </summary>
        public Feature Parent;

        /// <summary>
        /// Flag to disable the OnInstallActionChanged callback to avoid propagation endless loops.
        /// true means callback is disabled
        /// false means callback does it's job
        /// </summary>
        public bool IsPropagated { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Feature" />class.
        /// Missing parameters a set to default values
        /// </summary>
        /// <param name="name">The name of the feature.</param>
        public Feature(string name)
            : this(name, "", "", true, -1, InstallType.eSkip, 0, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Feature" />class.
        /// Missing parameters a set to default values
        /// </summary>
        /// <param name="name">The name of the feature.</param>
        /// <param name="instAction">The install action to be performed on the feature.</param>
        public Feature(string name,
                       InstallType instAction)
            : this(name, "", "", true, -1, instAction, 0, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Feature" />class.
        /// Missing parameters a set to default values
        /// </summary>
        /// <param name="name">The name of the feature.</param>
        /// <param name="instVersion">The installed version of the feature.</param>
        /// <param name="availVersion">The available version of the feature.</param>
        /// <param name="isGroup">Inidcate whether the feature is a node or a leafe.</param>
        /// <param name="index">The index in the container feature collection.</param>
        /// <param name="instAction">The install action to be performed on the feature.</param>
        public Feature(string name,
                       string instVersion,
                       string availVersion,
                       bool isGroup,
                       int index,
                       InstallType instAction)
            : this(name, instVersion, availVersion, isGroup, index, instAction, 0, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Feature" />class.
        /// Missing parameters a set to default values
        /// </summary>
        /// <param name="name">The name of the feature.</param>
        /// <param name="instVersion">The installed version of the feature.</param>
        /// <param name="availVersion">The available version of the feature.</param>
        /// <param name="isGroup">Inidcate whether the feature is a node or a leafe.</param>
        /// <param name="index">The index in the container feature collection.</param>
        /// <param name="instAction">The install action to be performed on the feature.</param>
        /// <param name="size">The size of the feature.</param>
        public Feature(string name,
                       string instVersion,
                       string availVersion,
                       bool isGroup,
                       int index,
                       InstallType instAction,
                       double size)
            : this(name, instVersion, availVersion, isGroup, index, instAction, size, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Feature" />class.
        /// </summary>
        /// <param name="name">The name of the feature.</param>
        /// <param name="instVersion">The installed version of the feature.</param>
        /// <param name="availVersion">The available version of the feature.</param>
        /// <param name="isGroup">Inidcate whether the feature is a node or a leafe.</param>
        /// <param name="index">The index in the container feature collection.</param>
        /// <param name="instAction">The install action to be performed on the feature.</param>
        /// <param name="size">The size of the feature.</param>
        /// <param name="isMigration">Indicates whether the feature is to be migratetd.</param>
        public Feature(string name, 
                       string instVersion, 
                       string availVersion, 
                       bool isGroup, 
                       int index,
                       InstallType instAction,
                       double size,
                       bool isMigration)
        {
            this.ProductName = name;
            this.InstalledVersion = instVersion;
            this.AvailableVersion = availVersion;
            this.IsGroup = isGroup;
            this.IsInstallActionModified = false;
            this.BoListIndex = index;
            this.IsPropagated = false;
            // PreviousAction MUST be set before InstallAction in order to make OnInstallActionChanged callback work correctly
            this.PreviousAction = instAction;
            this.InstallAction = instAction;
            this.IsMigration = isMigration;
            this.Size = size;
            this.Children = new FeatureCollection();
        }

        #endregion Constructors

        #region Callbacks

        /// <summary>
        /// Called when the InstallAction property of the feature has changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="DependencyPropertyChangedEventArgs">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnInstallActionChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Feature changedFeature = (Feature)sender;

            if (changedFeature.IsPropagated)
                return;

            //InstallType oldAction = (InstallType)e.OldValue;
            InstallType newAction = (InstallType)e.NewValue;

            changedFeature.IsPropagated = true;
            changedFeature.InstallAction = newAction;
            changedFeature.IsInstallActionModified = changedFeature.IsGroup ? true : (changedFeature.InstallAction != changedFeature.PreviousAction);
            changedFeature.IsPropagated = false;
            // Propagate new action to children and parent
            changedFeature.PropagateDown(newAction);
            changedFeature.PropagateUp(newAction);
        }

        /// <summary>
        /// Called when the IsInFocusChain property of the feature has changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="DependencyPropertyChangedEventArgs">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnFocusChainChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Feature changedFeature = (Feature)sender;

            //bool oldFocus = (bool)e.OldValue;
            bool newFocus = (bool)e.NewValue;

            changedFeature.IsInFocusChain = newFocus;
            // Propagate new focus to parent
            changedFeature.PropagateUp(newFocus);
        }

        /// <summary>
        /// Called when the HasFocus property of the feature has changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="DependencyPropertyChangedEventArgs">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnFocusChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Feature changedFeature = (Feature)sender;

            //bool oldFocus = (bool)e.OldValue;
            bool isSelected = (bool)e.NewValue;

            changedFeature.HasFocus = isSelected;
            changedFeature.IsInFocusChain = isSelected;
        }

        #endregion Callbacks

        #region Helpers

        /// <summary>
        /// Create all relations
        /// </summary>
        public void Initialize()
        {
            if (this.Children != null)
            {
                foreach (Feature child in this.Children)
                {
                    child.Parent = this;
                    child.Initialize();
                }
            }
            // When parent is known, base level children have to reasign their parents' InstallActions
            if (!this.IsGroup)
                this.PropagateUp(this.InstallAction);
        }

        /// <summary>
        /// Convert to string
        /// </summary>
        public override string ToString()
        {
            return this.ProductName;
        }

        /// <summary>
        /// Propagate current feature's IsInFocusChain to it's parents so they can set the color of expander and menu button
        /// </summary>
        /// <param name="IsInFocusChain">Indicates whether the feature belongs to the focus chain.</param>
        public void PropagateUp(bool isInFocusChain)
        {
            Feature parent = this.Parent;
            if (parent != null)
            {
                if (parent.Children != null)
                {
                    parent.IsInFocusChain = isInFocusChain;
                    parent.PropagateUp(isInFocusChain);
                }
            }
        }

        /// <summary>
        /// Propagate current feature's InstallAction to it's parents so they can set their InstallAction icon
        /// </summary>
        /// <param name="action">The InstallAction to be propageated to all parents.</param>
        public void PropagateUp(InstallType action)
        {
            Feature parent = this.Parent;
            if (parent != null)
            {
                if (parent.Children != null)
                {
                    bool different = HasChildrenWithDifferentAction(parent, action);
                    parent.IsInstallActionModified = HasChildrenWithModifiedAction(parent);
                    parent.IsPropagated = true;
                    parent.InstallAction = different ? InstallType.eIndeterminate : action;
                    parent.IsPropagated = false;
                    parent.PropagateUp(action);
                }
            }
        }

        /// <summary>
        /// Propagate current feature's InstallAction to it's children so they can set their InstallAction
        /// </summary>
        /// <param name="action">The InstallAction to be propageated to all children.</param>
        public void PropagateDown(InstallType action)
        {
            if (this.Children != null)
            {
                foreach (Feature child in this.Children)
                {
                    child.IsPropagated = true;
                    child.InstallAction = action;
                    child.IsInstallActionModified = child.IsGroup ? true : (child.InstallAction != child.PreviousAction);
                    child.IsPropagated = false;
                    child.PropagateDown(action);
                }
            }
        }

        /// <summary>
        /// Check whether a feature has children having InstallAction different from "action"
        /// </summary>
        /// <param name="feature">The feature to be checked.</param>
        /// <param name="action">The InstallAction to be checked.</param>
        /// <returns>True if the children have different InstallAction, otherwise false.</returns>
        private bool HasChildrenWithDifferentAction(Feature feature, InstallType action)
        {
            bool different = false;

            foreach (Feature child in feature.Children)
            {
                if (child.InstallAction != action)
                {
                    different = true;
                    break;
                }
            }

            return different;
        }

        /// <summary>
        /// Check whether a feature has children having IsInstallActionModified flag set
        /// </summary>
        /// <param name="feature">The feature to be checked.</param>
        /// <returns>True if a child has a modified InstallAction, otherwise false.</returns>
        private bool HasChildrenWithModifiedAction(Feature feature)
        {
            bool modified = false;

            foreach (Feature child in feature.Children)
            {
                if (child.IsInstallActionModified)
                {
                    modified = true;
                    break;
                }
            }

            return modified;
        }

        #endregion
    }


    /// <summary>
    /// Class FeatureCollection.
    /// Is derived from ObservableCollection and extended by a method to add feature in ascending order
    /// </summary>
    public class FeatureCollection : ObservableCollection<Feature>
    {
        /// <summary>
        /// Adding features in ascending order
        /// </summary>
        /// <param name="feature">The feature to be added.</param>
        public void AddAscending(Feature feature)
        {
            //Comparison<string> comparison = new Comparison<string>((s1, s2) => { return String.Compare(s1, s2); });

            if (this.Count == 0)
                // If collection is empty, just add
                this.Add(feature);
            else
            {
                bool inserted = false;
                for (int i = 0; i < this.Count; i++)
                {
                    //int result = comparison.Invoke(this[i].ToString(), feature.ToString());
                    int result = string.Compare(this[i].ToString(), feature.ToString());
                    if (result >= 1)
                    {
                        this.Insert(i, feature);
                        inserted = true;
                        break;
                    }
                }
                if (!inserted)
                    // If no position was found, add at the end
                    this.Add(feature);
            }
        }
    }


    /// <summary>
    /// Class FeatureModel.
    /// </summary>
    public class FeatureModel
    {
        #region Properties

        /// <summary>
        /// The <see cref="FeatureCollection" />FeatureCollection.
        /// </summary>
        private FeatureCollection _featureList = new FeatureCollection();
        public FeatureCollection FeatureList
        {
            get { return _featureList; }
            set { _featureList = value; }
        }

        /// <summary>
        /// The localised <see cref="MenuLabelCollection" />menu labels.
        /// </summary>
        private MenuLabelCollection _contextMenuEntries = new MenuLabelCollection();
        public MenuLabelCollection ContextMenuEntries
        {
            get { return _contextMenuEntries; }
            set { _contextMenuEntries = value; }
        }

        /// <summary>
        /// The localised column headers.
        /// The headers are used by different pages with different content.
        /// </summary>
        public string ColumnHeader1 { get; set; }
        public string ColumnHeader2 { get; set; }
        public string ColumnHeader3 { get; set; }
        public string ColumnHeader4 { get; set; }
        public string ColumnHeader5 { get; set; }

        #endregion Properties
    }
}