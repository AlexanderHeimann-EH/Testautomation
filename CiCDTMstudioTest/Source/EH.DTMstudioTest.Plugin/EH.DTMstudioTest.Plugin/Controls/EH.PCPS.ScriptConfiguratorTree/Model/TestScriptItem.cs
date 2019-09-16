// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScriptItem.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class Feature.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.ScriptConfiguratorTree.Model
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.PCPS.SelectionTree.Controls;

    /// <summary>
    /// Class Feature.
    /// </summary>
    [Serializable]
    public class TestScriptItem : DependencyObject, INotifyPropertyChanged
    {
        #region Static Fields

        /// <summary>
        /// The is in focus chain property
        /// </summary>
        public static readonly DependencyProperty ChildrenProperty = DependencyProperty.Register("Children", typeof(TestScriptCollection), typeof(TestScriptItem), new UIPropertyMetadata(null, null));

        /// <summary>
        /// The has focus property
        /// </summary>
        public static readonly DependencyProperty HasFocusProperty = DependencyProperty.Register("HasFocus", typeof(bool), typeof(TestScriptItem), new UIPropertyMetadata(false, OnFocusChanged));

        /// <summary>
        /// The is checked property
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool?), typeof(TestScriptItem), new UIPropertyMetadata(false, OnIsCheckedChanged));

        /// <summary>
        /// The is checked property
        /// </summary>
        public static readonly DependencyProperty IsEditModeProperty = DependencyProperty.Register("IsEditMode", typeof(bool?), typeof(TestScriptItem), new UIPropertyMetadata(false, null));

        /// <summary>
        /// The is expanded property.
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool?), typeof(TestScriptItem), new UIPropertyMetadata(false, OnIsExpandedChanged));

        /// <summary>
        /// The is in focus chain property
        /// </summary>
        public static readonly DependencyProperty IsInFocusChainProperty = DependencyProperty.Register("IsInFocusChain", typeof(bool), typeof(TestScriptItem), new UIPropertyMetadata(false, OnFocusChainChanged));

        /// <summary>
        /// The is valid property.
        /// </summary>
        public static readonly DependencyProperty IsValidProperty = DependencyProperty.Register("IsValid", typeof(bool?), typeof(TestScriptItem), new UIPropertyMetadata(true, OnIsValidChanged));

        #endregion

        #region Fields

        /// <summary>
        /// The description
        /// </summary>
        private string description;

        /// <summary>
        /// The is checked modified
        /// </summary>
        private bool isCheckedModified;

        /// <summary>
        /// The is group
        /// </summary>
        private bool isGroup;

        /// <summary>
        /// The is migration
        /// </summary>
        private bool isMigration;

        /// <summary>
        /// The is propagated
        /// </summary>
        private bool isPropagated;

        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// The parameter
        /// </summary>
        private string parameterDescription;

        /// <summary>
        /// The parent
        /// </summary>
        private TestScriptItem parent;

        /// <summary>
        /// The previous action
        /// </summary>
        private TestType previousAction;

        /// <summary>
        /// The tag
        /// </summary>
        private object tag;

        /// <summary>
        /// The tool tip.
        /// </summary>
        private string toolTip;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestScriptItem"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="isGroup">
        /// The is group.
        /// </param>
        /// <param name="testType">
        /// The test type.
        /// </param>
        /// <param name="isChecked">
        /// The is checked.
        /// </param>
        /// <param name="isEditMode">
        /// The is edit mode.
        /// </param>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <param name="contextMenu">
        /// The context menu.
        /// </param>
        /// <param name="isValid">
        /// The is valid.
        /// </param>
        /// <param name="toolTip">
        /// The tool tip.
        /// </param>
        public TestScriptItem(string name, string parameter, string description, bool isGroup, TestType testType, bool? isChecked, bool? isEditMode, object tag, ContextMenu contextMenu, bool? isValid, string toolTip)
        {
            this.Parent = null;
            this.Name = name;
            this.ParameterDescription = parameter;
            this.Description = description;
            this.IsGroup = isGroup;
            this.IsCheckedModified = false;

            this.IsPropagated = false;
            this.ContextMenuItems = contextMenu;
            this.IsEditMode = isEditMode;

            // PreviousAction MUST be set before InstallAction in order to make OnInstallActionChanged callback work correctly
            this.PreviousAction = testType;
            this.TestType = testType;
            this.IsMigration = false;

            this.IsChecked = isChecked;
            this.Tag = tag;
            this.IsValid = isValid;
            this.ToolTip = toolTip;

            this.Children = new TestScriptCollection();
            this.Children.CollectionChanged += this.OnChildrenCollectionChanged;
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        public TestScriptCollection Children
        {
            get
            {
                return (TestScriptCollection)this.GetValue(ChildrenProperty);
            }

            set
            {
                this.SetValue(ChildrenProperty, value);
                this.RaisePropertyChanged("Children");
            }
        }

        /// <summary>
        /// Gets or sets the context menu items.
        /// </summary>
        public ContextMenu ContextMenuItems { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                if (value == this.description)
                {
                    return;
                }

                this.description = value;
                this.RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has focus.
        /// </summary>
        /// <value><c>true</c> if this instance has focus; otherwise, <c>false</c>.</value>
        public bool HasFocus
        {
            get
            {
                return (bool)this.GetValue(HasFocusProperty);
            }

            set
            {
                this.SetValue(HasFocusProperty, value);
                this.RaisePropertyChanged("HasFocus");
            }
        }

        /// <summary>
        /// Gets the name of the icon.
        /// </summary>
        /// <value>The name of the icon.</value>
        public string IconName
        {
            get
            {
                switch (this.TestType)
                {
                    case TestType.eTestFolder:
                        return @"Resources\Icons\TestFolder.png";
                    case TestType.eTestSuite:
                        return @"Resources\Icons\TestSuite.png";
                    case TestType.eTestModule:
                        return @"Resources\Icons\TestModule.png";
                    case TestType.eTestCase:
                        return @"Resources\Icons\TestCase.png";
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked.
        /// </summary>
        /// <value><c>null</c> if [is checked] contains no value, <c>true</c> if [is checked]; otherwise, <c>false</c>.</value>
        public bool? IsChecked
        {
            get
            {
                return (bool?)this.GetValue(IsCheckedProperty);
            }

            set
            {
                this.SetValue(IsCheckedProperty, value);
                this.RaisePropertyChanged("IsChecked");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked modified.
        /// </summary>
        /// <value><c>true</c> if this instance is checked modified; otherwise, <c>false</c>.</value>
        public bool IsCheckedModified
        {
            get
            {
                return this.isCheckedModified;
            }

            set
            {
                this.isCheckedModified = value;
                this.RaisePropertyChanged("IsCheckedModified");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked.
        /// </summary>
        /// <value><c>null</c> if [is checked] contains no value, <c>true</c> if [is checked]; otherwise, <c>false</c>.</value>
        public bool? IsEditMode
        {
            get
            {
                return (bool?)this.GetValue(IsEditModeProperty);
            }

            set
            {
                this.SetValue(IsEditModeProperty, value);
                this.RaisePropertyChanged("IsEditMode");
            }
        }

        /// <summary>
        /// Gets or sets the is expanded.
        /// </summary>
        public bool? IsExpanded
        {
            get
            {
                return (bool)this.GetValue(IsExpandedProperty);
            }

            set
            {
                this.SetValue(IsExpandedProperty, value);
                this.RaisePropertyChanged("IsExpanded");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is group.
        /// </summary>
        /// <value><c>true</c> if this instance is group; otherwise, <c>false</c>.</value>
        public bool IsGroup
        {
            get
            {
                return this.isGroup;
            }

            set
            {
                this.isGroup = value;
                this.RaisePropertyChanged("IsGroup");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is in focus chain.
        /// </summary>
        /// <value><c>true</c> if this instance is in focus chain; otherwise, <c>false</c>.</value>
        public bool IsInFocusChain
        {
            get
            {
                return (bool)this.GetValue(IsInFocusChainProperty);
            }

            set
            {
                this.SetValue(IsInFocusChainProperty, value);
                this.RaisePropertyChanged("IsInFocusChain");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is migration.
        /// </summary>
        public bool IsMigration
        {
            get
            {
                return this.isMigration;
            }

            set
            {
                this.isMigration = value;
                this.RaisePropertyChanged("IsMigration");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is propagated.
        /// </summary>
        public bool IsPropagated
        {
            get
            {
                return this.isPropagated;
            }

            set
            {
                this.isPropagated = value;
                this.RaisePropertyChanged("IsPropagated");
            }
        }

        /// <summary>
        /// Gets or sets the is valid.
        /// </summary>
        public bool? IsValid
        {
            get
            {
                return (bool?)this.GetValue(IsValidProperty);
            }

            set
            {
                this.SetValue(IsValidProperty, value);
                this.RaisePropertyChanged("IsValid");
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        public string ParameterDescription
        {
            get
            {
                return this.parameterDescription;
            }

            set
            {
                this.parameterDescription = value;
                this.RaisePropertyChanged("ParameterDescription");
            }
        }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public TestScriptItem Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                this.parent = value;
                this.RaisePropertyChanged("Parent");
            }
        }

        /// <summary>
        /// Gets or sets the previous action.
        /// </summary>
        /// <value>The previous action.</value>
        public TestType PreviousAction
        {
            get
            {
                return this.previousAction;
            }

            set
            {
                this.previousAction = value;
                this.RaisePropertyChanged("PreviousAction");
            }
        }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public object Tag
        {
            get
            {
                return this.tag;
            }

            set
            {
                this.tag = value;
                this.RaisePropertyChanged("Tag");
            }
        }

        /// <summary>
        /// Gets or sets the type of the test.
        /// </summary>
        /// <value>The type of the test.</value>
        public TestType TestType { get; set; }

        /// <summary>
        /// Gets or sets the tool tip.
        /// </summary>
        public string ToolTip
        {
            get
            {
                return this.toolTip;
            }

            set
            {
                this.toolTip = value;
                this.RaisePropertyChanged("ToolTip");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy test object.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <returns>
        /// The <see cref="TestObject"/>.
        /// </returns>
        public static TestObject CopyTestObject(TestObject testObject)
        {
            if (testObject != null)
            {
                if (testObject.GetType() == typeof(TestFolder))
                {
                    var testObjectCopy = testObject as TestFolder;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }

                if (testObject.GetType() == typeof(TestCase))
                {
                    var testObjectCopy = testObject as TestCase;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }

                if (testObject.GetType() == typeof(TestMethod))
                {
                    var testObjectCopy = testObject as TestMethod;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }

                if (testObject.GetType() == typeof(TestModule))
                {
                    var testObjectCopy = testObject as TestModule;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }

                if (testObject.GetType() == typeof(TestObject))
                {
                    return testObject.Copy();
                }

                if (testObject.GetType() == typeof(TestSuite))
                {
                    var testObjectCopy = testObject as TestSuite;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.Copy();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="TestScriptItem"/>.
        /// </returns>
        public TestScriptItem Copy()
        {
            var testScriptCopy = new TestScriptItem(this.Name, this.ParameterDescription, this.Description, this.IsGroup, this.TestType, this.IsChecked, this.IsEditMode, CopyTestObject(this.Tag as TestObject), this.ContextMenuItems, this.IsValid, this.ToolTip);

            if (this.Children != null)
            {
                testScriptCopy.Children.Copy(this.Children);
            }

            return testScriptCopy;
        }

        /// <summary>
        /// The deselect children.
        /// </summary>
        /// <param name="testScriptItem">
        /// The test script item.
        /// </param>
        public void DeselectChildren(TestScriptItem testScriptItem)
        {
            foreach (var child in testScriptItem.Children)
            {
                this.DeselectChildren(child);
            }
        }

        /// <summary>
        /// The deselect parent.
        /// </summary>
        /// <param name="testScriptItem">
        /// The test script item.
        /// </param>
        public void DeselectParent(TestScriptItem testScriptItem)
        {
            if (testScriptItem.HasFocus)
            {
                testScriptItem.HasFocus = false;
            }

            if (testScriptItem.Parent != null)
            {
                this.DeselectParent(testScriptItem.Parent);
            }
        }

        /// <summary>
        /// The get property changed.
        /// </summary>
        /// <returns>
        /// The <see cref="PropertyChangedEventHandler"/>.
        /// </returns>
        public PropertyChangedEventHandler GetPropertyChanged()
        {
            return this.PropertyChanged;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            if (this.Children != null)
            {
                foreach (var child in this.Children)
                {
                    child.Parent = this;
                    child.Initialize();
                }
            }

            // When parent is known, base level children have to reasign their parents' InstallActions
            if (!this.IsGroup)
            {
                this.PropagateUp(this.TestType);
            }
        }

        /// <summary>
        /// Propagates the checked down.
        /// </summary>
        /// <param name="isChecked">
        /// if set to <c>true</c> [is checked].
        /// </param>
        public void PropagateCheckedDown(bool? isChecked)
        {
            if (this.Children != null)
            {
                foreach (var child in this.Children)
                {
                    child.IsPropagated = true;
                    child.IsChecked = isChecked;
                    child.IsPropagated = false;
                    child.PropagateCheckedDown(isChecked);
                }
            }
        }

        /// <summary>
        /// Propagates the checked up.
        /// </summary>
        /// <param name="isChecked">
        /// if set to <c>true</c> [is checked].
        /// </param>
        public void PropagateCheckedUp(bool? isChecked)
        {
            var parentTestScript = this.Parent;
            if (parentTestScript != null)
            {
                if (parentTestScript.Children != null)
                {
                    var different = this.HasChildrenWithDifferentIsChecked(parentTestScript, isChecked);
                    parentTestScript.IsCheckedModified = this.HasChildrenWithModifiedIsChecked(parentTestScript);
                    parentTestScript.IsPropagated = true;

                    parentTestScript.IsChecked = different ? null : isChecked;

                    parentTestScript.IsPropagated = false;
                    parentTestScript.PropagateCheckedUp(isChecked);
                }
            }
        }

        /// <summary>
        /// Propagates down.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        public void PropagateDown(TestType action)
        {
            if (this.Children != null)
            {
                foreach (var child in this.Children)
                {
                    child.IsPropagated = true;
                    child.TestType = action;
                    child.IsCheckedModified = child.TestType != child.PreviousAction;
                    child.IsPropagated = false;
                    child.PropagateDown(action);
                }
            }
        }

        /// <summary>
        /// The propagate focus down.
        /// </summary>
        /// <param name="changedTestScript">
        /// The changed test script.
        /// </param>
        /// <param name="hasFocus">
        /// The has focus.
        /// </param>
        public void PropagateFocusDown(TestScriptItem changedTestScript, bool hasFocus)
        {
            if (this.Children != null)
            {
                foreach (var child in this.Children)
                {
                    if (changedTestScript == null || ((changedTestScript.Tag as TestObject).Guid != (child.Tag as TestObject).Guid))
                    {
                        child.IsPropagated = true;
                        child.HasFocus = hasFocus;
                        child.IsPropagated = false;
                        child.PropagateFocusDown(changedTestScript, hasFocus);
                    }
                }
            }
        }

        /// <summary>
        /// The propagate focus up.
        /// </summary>
        /// <param name="changedTestScript">
        /// The changed test script.
        /// </param>
        /// <param name="hasFocus">
        /// The has focus.
        /// </param>
        public void PropagateFocusUp(TestScriptItem changedTestScript, bool hasFocus)
        {
            var parentTestScript = this.Parent;
            if (parentTestScript != null)
            {
                if (parentTestScript.Children != null)
                {
                    parentTestScript.IsPropagated = true;
                    parentTestScript.HasFocus = hasFocus;
                    parentTestScript.IsPropagated = false;
                    parentTestScript.PropagateFocusUp(changedTestScript, hasFocus);
                }
            }
            else
            {
                this.PropagateFocusDown(changedTestScript, hasFocus);
            }
        }

        /// <summary>
        /// Propagates up.
        /// </summary>
        /// <param name="isInFocusChain">
        /// if set to <c>true</c> [is in focus chain].
        /// </param>
        public void PropagateUp(bool isInFocusChain)
        {
            var parentTestScript = this.Parent;
            if (parentTestScript != null)
            {
                if (parentTestScript.Children != null)
                {
                    parentTestScript.IsInFocusChain = isInFocusChain;
                    parentTestScript.PropagateUp(isInFocusChain);
                }
            }
        }

        /// <summary>
        /// Propagates up.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        public void PropagateUp(TestType action)
        {
            var parentTestScript = this.Parent;
            if (parentTestScript != null)
            {
                if (parentTestScript.Children != null)
                {
                    var different = this.HasChildrenWithDifferentAction(parentTestScript, action);
                    parentTestScript.IsCheckedModified = this.HasChildrenWithModifiedIsChecked(parentTestScript);
                    parentTestScript.IsPropagated = true;
                    parentTestScript.TestType = different ? TestType.eIndeterminate : action;
                    parentTestScript.IsPropagated = false;
                    parentTestScript.PropagateUp(action);
                }
            }
        }

        /// <summary>
        /// The propagate valid up.
        /// </summary>
        /// <param name="isValid">
        /// The is valid.
        /// </param>
        public void PropagateValidUp(bool? isValid)
        {
            var parentTestScript = this.Parent;
            if (parentTestScript != null)
            {
                if (parentTestScript.Children != null)
                {
                    var different = this.HasChildrenWithDifferentValid(parentTestScript, isValid);

                    parentTestScript.IsPropagated = true;
                    parentTestScript.IsValid = different ? false : isValid;
                    parentTestScript.IsPropagated = false;
                    parentTestScript.PropagateValidUp(isValid);
                }
            }
        }

        ///// <summary>
        ///// The set focus.
        ///// </summary>
        //public void SetFocus()
        //{
        //    this.DeselectParent(this.Parent);
        //    this.HasFocus = true;
        //}

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.Name;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The add test object.
        /// </summary>
        /// <param name="newTestScript">
        /// The new test script.
        /// </param>
        private static void AddTestObjectToParentTestObjects(TestScriptItem newTestScript)
        {
            var parentTestScriptTag = newTestScript.Parent.Tag;

            if (parentTestScriptTag is TestCollection)
            {
                var newTestObject = newTestScript.Tag as TestObject;
                var parentTestFolder = parentTestScriptTag as TestCollection;

                var vorhanden = parentTestFolder.TestObjects.Any(testMethods => newTestObject != null && testMethods.Guid == newTestObject.Guid);

                if (!vorhanden)
                {
                    parentTestFolder.TestObjects.Add(newTestObject);
                }
            }
        }

        /// <summary>
        /// The on focus chain changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnFocusChainChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var changedTestScript = (TestScriptItem)sender;

            var newFocus = (bool)e.NewValue;

            changedTestScript.IsInFocusChain = newFocus;

            // Propagate new focus to parent
            changedTestScript.PropagateUp(newFocus);
        }

        /// <summary>
        /// The on focus changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnFocusChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var changedTestScript = (TestScriptItem)sender;
            
            if (changedTestScript.IsPropagated)
            {
                return;
            }

            var hasFocus = (bool)e.NewValue;

            changedTestScript.IsPropagated = true;
            changedTestScript.HasFocus = hasFocus;
            changedTestScript.IsPropagated = false;

            changedTestScript.IsInFocusChain = hasFocus;

            changedTestScript.PropagateFocusDown(changedTestScript, false);
            changedTestScript.PropagateFocusUp(changedTestScript, false);
        }

        /// <summary>
        /// The on is checked changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnIsCheckedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var changedTestScript = (TestScriptItem)sender;

            if (changedTestScript.IsPropagated)
            {
                return;
            }

            var oldIsChecked = (bool?)e.OldValue;
            var newIsChecked = (bool?)e.NewValue ?? !oldIsChecked;

            changedTestScript.IsPropagated = true;
            changedTestScript.IsChecked = newIsChecked;
            changedTestScript.IsPropagated = false;

            // Propagate new action to children and parent
            changedTestScript.PropagateCheckedDown(newIsChecked);
            changedTestScript.PropagateCheckedUp(newIsChecked);
        }

        /// <summary>
        /// The on is expanded changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnIsExpandedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var changedTestScript = (TestScriptItem)sender;

            if (changedTestScript.IsPropagated)
            {
                return;
            }

            var oldIsExpanded = (bool?)e.OldValue;
            var newIsExpanded = (bool?)e.NewValue ?? !oldIsExpanded;

            changedTestScript.IsPropagated = true;
            changedTestScript.IsExpanded = newIsExpanded;
            changedTestScript.IsPropagated = false;

            // Propagate new action to children and parent
            // changedTestScript.PropagateExpandedUp(newIsExpanded);
        }

        /// <summary>
        /// The on is valid changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnIsValidChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var changedTestScript = (TestScriptItem)sender;

            if (changedTestScript.IsPropagated)
            {
                return;
            }

            var oldIsValid = (bool?)e.OldValue;
            var newIsValid = (bool?)e.NewValue;

            if (newIsValid == null)
            {
                newIsValid = !oldIsValid;
            }

            changedTestScript.IsPropagated = true;
            changedTestScript.IsValid = newIsValid;
            changedTestScript.IsPropagated = false;

            // Propagate new action to children and parent
            changedTestScript.PropagateValidUp(newIsValid);
        }

        /// <summary>
        /// The remove test object.
        /// </summary>
        /// <param name="oldTestScript">
        /// The old test script.
        /// </param>
        private static void RemoveTestObject(TestScriptItem oldTestScript)
        {
            oldTestScript.IsValid = true;

            var oldTestObject = oldTestScript.Tag as TestObject;
            if (oldTestObject != null)
            {
                if (oldTestObject.Parent is TestCollection)
                {
                    var oldTestFolderParent = oldTestObject.Parent as TestCollection;
                    oldTestFolderParent.TestObjects.Remove(oldTestObject);
                }
            }
        }

        /// <summary>
        /// The get parent check state.
        /// </summary>
        /// <param name="testScriptCollection">
        /// The feature collection.
        /// </param>
        private void GetParentCheckedState(TestScriptCollection testScriptCollection)
        {
            // Check state des übergeordneten Ordners setzten
            if (testScriptCollection != null)
            {
                if (testScriptCollection.Count > 0)
                {
                    foreach (var child in testScriptCollection)
                    {
                        var different = this.HasChildrenWithDifferentIsChecked(child.parent, child.IsChecked);

                        child.PropagateCheckedUp(different ? null : child.IsChecked);
                        break;
                    }
                }
                else
                {
                    // wenn es keine Child Elemente gibt -> deselectieren 
                    this.IsChecked = false;
                }
            }
        }

        /// <summary>
        /// Determines whether [has children with different action] [the specified feature].
        /// </summary>
        /// <param name="testScript">
        /// The feature.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <returns>
        /// <c>true</c> if [has children with different action] [the specified feature]; otherwise, <c>false</c>.
        /// </returns>
        private bool HasChildrenWithDifferentAction(TestScriptItem testScript, TestType action)
        {
            bool different = false;

            foreach (var child in testScript.Children)
            {
                if (child.TestType != action)
                {
                    different = true;
                    break;
                }
            }

            return different;
        }

        /// <summary>
        /// Determines whether [has children with different is checked] [the specified feature].
        /// </summary>
        /// <param name="testScript">
        /// The feature.
        /// </param>
        /// <param name="isChecked">
        /// if set to <c>true</c> [is checked].
        /// </param>
        /// <returns>
        /// <c>true</c> if [has children with different is checked] [the specified feature]; otherwise, <c>false</c>.
        /// </returns>
        private bool HasChildrenWithDifferentIsChecked(TestScriptItem testScript, bool? isChecked)
        {
            bool different = false;

            foreach (var child in testScript.Children)
            {
                if (child.IsChecked != isChecked)
                {
                    different = true;
                    break;
                }
            }

            return different;
        }

        /// <summary>
        /// The has children with different valid.
        /// </summary>
        /// <param name="parentTestScript">
        /// The parent feature.
        /// </param>
        /// <param name="isValid">
        /// The is valid.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool HasChildrenWithDifferentValid(TestScriptItem parentTestScript, bool? isValid)
        {
            return parentTestScript.Children.Any(child => child.IsValid != isValid);
        }

        /// <summary>
        /// The has children with focus.
        /// </summary>
        /// <param name="parentTestScript">
        /// The parent test script.
        /// </param>
        /// <param name="hasFocus">
        /// The has focus.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        private bool HasChildrenWithFocus(TestScriptItem parentTestScript, bool? hasFocus)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether [has children with modified is checked] [the specified feature].
        /// </summary>
        /// <param name="testScript">
        /// The feature.
        /// </param>
        /// <returns>
        /// <c>true</c> if [has children with modified is checked] [the specified feature]; otherwise, <c>false</c>.
        /// </returns>
        private bool HasChildrenWithModifiedIsChecked(TestScriptItem testScript)
        {
            bool modified = false;

            foreach (var child in testScript.Children)
            {
                if (child.IsCheckedModified)
                {
                    modified = true;
                    break;
                }
            }

            return modified;
        }

        /// <summary>
        /// The has property changed.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool HasPropertyChanged()
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The on children collection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnChildrenCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        var newTestScriptList = e.NewItems;

                        foreach (TestScriptItem newTestScript in newTestScriptList)
                        {
                            newTestScript.Parent = this;

                            newTestScript.PropertyChanged += this.OnPropertyChanged;

                            AddTestObjectToParentTestObjects(newTestScript);
                        }

                        break;
                    }

                case NotifyCollectionChangedAction.Remove:
                    {
                        var oldTestScriptList = e.OldItems;

                        foreach (TestScriptItem oldTestScript in oldTestScriptList)
                        {
                            RemoveTestObject(oldTestScript);
                        }

                        break;
                    }

                case NotifyCollectionChangedAction.Move:
                    {
                        var newTestScriptList = e.NewItems;
                        foreach (TestScriptItem newTestScript in newTestScriptList)
                        {
                            newTestScript.HasFocus = true;
                        }

                        break;
                    }

                case NotifyCollectionChangedAction.Replace:
                    {
                        break;
                    }

                case NotifyCollectionChangedAction.Reset:
                    {
                        break;
                    }
            }

            this.GetParentCheckedState(sender as TestScriptCollection);
        }

        /// <summary>
        /// The on feature property changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var testScript = (TestScriptItem)sender;
            if (testScript != null)
            {
                var testObject = (TestObject)testScript.Tag;

                if (e.PropertyName == "IsChecked")
                {
                    if (testScript.IsChecked != null)
                    {
                        testObject.IsActive = (bool)testScript.IsChecked;
                    }
                    else
                    {
                        testObject.IsActive = false;
                    }
                }
                else if (e.PropertyName == "Name")
                {
                    testObject.Name = testScript.Name;
                }
                else if (e.PropertyName == "Description")
                {
                    testObject.Description = testScript.Description;
                }
                else if (e.PropertyName == "HasFocus")
                {
                    //this.DeselectChildren(this);
                    //this.DeselectParent(this);
                }
            }
        }

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property.
        /// </param>
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.HasPropertyChanged())
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}