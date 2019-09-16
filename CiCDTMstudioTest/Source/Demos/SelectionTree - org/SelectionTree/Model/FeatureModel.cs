using System;
using System.Windows;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MenuButton.Controls;

namespace SelectionTree
{
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
        /// Flag to diable the OnInstallActionChanged callback to avoid propagation endless loops.
        /// true means callback is disabled
        /// false means callback does it's job
        /// </summary>
        public bool IsPropagated { get; set; }

        #endregion

        #region Constructors

        public Feature(string name)
            : this(name, "", "", true, -1, InstallType.eSkip, 0, false)
        {
        }

        public Feature(string name,
                       InstallType instAction)
            : this(name, "", "", true, -1, instAction, 0, false)
        {
        }

        public Feature(string name,
                       string instVersion,
                       string availVersion,
                       bool isGroup,
                       int index,
                       InstallType instAction)
            : this(name, instVersion, availVersion, isGroup, index, instAction, 0, false)
        {
        }

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

        private static void OnInstallActionChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Feature changedFeature = (Feature)sender;

            if (changedFeature.IsPropagated)
                return;

            //InstallType oldAction = (InstallType)e.OldValue;
            InstallType newAction = (InstallType)e.NewValue;

            changedFeature.IsPropagated = true;
            changedFeature.InstallAction = newAction;
            changedFeature.IsInstallActionModified = changedFeature.InstallAction != changedFeature.PreviousAction;
            changedFeature.IsPropagated = false;
            // Propagate new action to children and parent
            changedFeature.PropagateDown(newAction);
            changedFeature.PropagateUp(newAction);
        }

        private static void OnFocusChainChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Feature changedFeature = (Feature)sender;

            //bool oldFocus = (bool)e.OldValue;
            bool newFocus = (bool)e.NewValue;

            changedFeature.IsInFocusChain = newFocus;
            // Propagate new focus to parent
            changedFeature.PropagateUp(newFocus);
        }

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

        public override string ToString()
        {
            return this.ProductName;
        }

        /// <summary>
        /// Propagate current feature's InstallAction to it's parents so they can set their InstallAction icon
        /// </summary>
        /// <param name="action">The InstallAction to be propageated to all parents.</param>
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
                    child.IsInstallActionModified = child.InstallAction != child.PreviousAction;
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


    public class FeatureModel
    {
        private FeatureCollection _featureList = new FeatureCollection();
        public FeatureCollection FeatureList
        {
            get { return _featureList; }
            set { _featureList = value; }
        }

        private MenuLabelCollection _contextMenuEntries = new MenuLabelCollection();
        public MenuLabelCollection ContextMenuEntries
        {
            get { return _contextMenuEntries; }
            set { _contextMenuEntries = value; }
        }

        public string ColumnHeader1 { get; set; }
        public string ColumnHeader2 { get; set; }
        public string ColumnHeader3 { get; set; }
        public string ColumnHeader4 { get; set; }
        public string ColumnHeader5 { get; set; }
    }
}