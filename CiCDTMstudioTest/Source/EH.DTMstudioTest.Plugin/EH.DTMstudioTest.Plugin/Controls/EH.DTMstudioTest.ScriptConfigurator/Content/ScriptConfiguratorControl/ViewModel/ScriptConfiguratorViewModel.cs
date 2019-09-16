// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptConfiguratorViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The script configurator view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.ScriptConfigurator.Content.ScriptConfiguratorControl.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument;
    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.DTMstudioTest.ScriptConfigurator.Content.ScriptConfiguratorControl.Content.EditParameterControl;
    using EH.DTMstudioTest.ScriptConfigurator.Content.ScriptConfiguratorControl.Content.MessageBoxControl;
    using EH.PCPS.ScriptConfiguratorTree.Model;
    using EH.PCPS.SelectionTree.Controls;
    using EH.PCPS.SelectionTree.Controls.Model;

    /// <summary>
    /// Class ScriptConfiguratorViewModel.
    /// </summary>
    public class ScriptConfiguratorViewModel : DependencyObject, INotifyPropertyChanged
    {
        #region Constants

        /// <summary>
        /// The context menu rename.
        /// </summary>
        public const string ContextMenuRename = "contextMenuRename";

        /// <summary>
        /// The ContextMenu add folder.
        /// </summary>
        private const string ContextMenuAddFolder = "ContextMenuAddFolder";

        /// <summary>
        /// The ContextMenu copy.
        /// </summary>
        private const string ContextMenuCopy = "ContextMenuCopy";

        /// <summary>
        /// The ContextMenu down.
        /// </summary>
        private const string ContextMenuDown = "ContextMenuDown";

        /// <summary>
        /// The ContextMenu edit parameter.
        /// </summary>
        private const string ContextMenuEditParameter = "ContextMenuEditParameter";

        /// <summary>
        /// The ContextMenu paste.
        /// </summary>
        private const string ContextMenuPaste = "ContextMenuPaste";

        /// <summary>
        /// The ContextMenu remove.
        /// </summary>
        private const string ContextMenuRemove = "ContextMenuRemove";

        /// <summary>
        /// The ContextMenu up.
        /// </summary>
        private const string ContextMenuUp = "ContextMenuUp";

        /// <summary>
        /// The new folder name.
        /// </summary>
        private const string NewFolderName = "New Folder";

        #endregion

        #region Fields

        /// <summary>
        /// The edit parameter control.
        /// </summary>
        private readonly EditParameterControl editParameterControl;

        /// <summary>
        /// The message box control.
        /// </summary>
        private readonly MessageBoxControl messageBoxControl;

        /// <summary>
        /// The control Document Path path list.
        /// </summary>
        private string controlDocumentPath;

        /// <summary>
        /// The dragged test object.
        /// </summary>
        private TestObject draggedTestObject;

        /// <summary>
        /// The test configuration.
        /// </summary>
        private TestConfiguration testConfiguration;

        /// <summary>
        /// The copied feature.
        /// </summary>
        private TestScriptItem testScriptItemCopy;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptConfiguratorViewModel"/> class.
        /// </summary>
        /// <param name="controlParent">
        /// The control Parent.
        /// </param>
        /// <param name="childControls">
        /// The child Controls.
        /// </param>
        public ScriptConfiguratorViewModel(Grid controlParent, UserControl[] childControls)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.editParameterControl = childControls[0] as EditParameterControl;
            if (this.editParameterControl != null)
            {
                this.editParameterControl.SetParent(controlParent);
            }

            this.messageBoxControl = childControls[1] as MessageBoxControl;
            if (this.messageBoxControl != null)
            {
                this.messageBoxControl.SetParent(controlParent);
            }
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
        /// Gets or sets the control document path.
        /// </summary>
        public string ControlDocumentPath
        {
            get
            {
                return this.controlDocumentPath;
            }

            set
            {
                this.controlDocumentPath = value;
                this.RaisePropertyChanged("ControldocumentPath");
            }
        }

        /// <summary>
        /// Gets or sets the test configuration.
        /// </summary>
        /// <value>The test configuration.</value>
        public TestConfiguration TestConfiguration
        {
            get
            {
                return this.testConfiguration;
            }

            set
            {
                if (this.testConfiguration == value)
                {
                    return;
                }

                this.testConfiguration = value;
                this.RaisePropertyChanged("TestConfiguration");
            }
        }

        /// <summary>
        /// Gets or sets the test configuration file.
        /// </summary>
        public string TestConfigurationFile { get; set; }

        /// <summary>
        /// Gets or sets the feature model.
        /// </summary>
        /// <value>The feature model.</value>
        public TestScriptModel TestScriptModel { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The deep copy test object.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <returns>
        /// The <see cref="TestObject"/>.
        /// </returns>
        public static TestObject DeepCopyTestObject(TestObject testObject)
        {
            if (testObject != null)
            {
                if (testObject.GetType() == typeof(TestFolder))
                {
                    var testObjectCopy = testObject as TestFolder;
                    if (testObjectCopy != null)
                    {
                        return testObjectCopy.DeepCopy();
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
                        return testObjectCopy.DeepCopy();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// The copy tree item.
        /// </summary>
        public void CopyTreeItem()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var testScript = GetSelectedTestScript(this.TestScriptModel.TestScriptList);
            if (testScript.IsEditMode == false)
            {
                this.testScriptItemCopy = CopyTestScript(testScript);
            }
        }

        /// <summary>
        /// The handle tree view mouse move.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="routedEventArgs">
        /// The routed event args.
        /// </param>
        public void HandleTreeViewMouseMove(object sender, RoutedEventArgs routedEventArgs)
        {
            MouseEventArgs mouseEventArgs = null;
            TreeListItem treeListItem = null;

            var routedObjects = routedEventArgs.OriginalSource as object[];
            if (routedObjects != null)
            {
                foreach (var routedObject in routedObjects)
                {
                    if (routedObject.GetType() == typeof(MouseEventArgs))
                    {
                        mouseEventArgs = routedObject as MouseEventArgs;
                    }

                    if (routedObject.GetType() == typeof(TreeListItem))
                    {
                        treeListItem = routedObject as TreeListItem;
                    }
                }
            }

            if (mouseEventArgs != null && mouseEventArgs.LeftButton == MouseButtonState.Pressed)
            {
                if (treeListItem != null && treeListItem.Node != null && treeListItem.Node.Tag != null)
                {
                    this.draggedTestObject = (treeListItem.Node.Tag as TestScriptItem).Tag as TestObject;
                    if (this.draggedTestObject != null)
                    {
                        Log.Debug(this, string.Format("HandleTreeViewMouseMove Item: {0}", this.draggedTestObject.Name));
                        var dragTime = DateTime.Now;
                        try
                        {
                            var finalDropEffect = DragDrop.DoDragDrop(treeListItem, this.draggedTestObject, DragDropEffects.Move);

                            var dropTime = DateTime.Now;

                            // nur wenn bewurst verschoben wurde.
                            if (dragTime.AddMilliseconds(250) < dropTime)
                            {
                                // Checking target is not null and item is dragging(moving)
                                if (finalDropEffect == DragDropEffects.Move)
                                {
                                    this.draggedTestObject = null;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.ErrorEx(this, ex, ex.Message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The destroy.
        /// </summary>
        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="testConfig">
        /// The test configuration.
        /// </param>
        public void LoadConfigurator(TestConfiguration testConfig)
        {
            this.TestConfiguration = null;
            this.TestConfiguration = testConfig;

            this.TestScriptModel = new TestScriptModel();

            this.LoadTestScriptModel(this.TestScriptModel, this.TestConfiguration);
        }

        /// <summary>
        /// The move down tree item.
        /// </summary>
        public void MoveDownTreeItem()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var selectedFeature = GetSelectedTestScript(this.TestScriptModel.TestScriptList);

            if (selectedFeature != null && this.CanMoveDown(selectedFeature))
            {
                this.MoveDownTestScript(selectedFeature);
                this.MoveDownTestObject(selectedFeature.Tag as TestObject);
            }
        }

        /// <summary>
        /// The move up tree item.
        /// </summary>
        public void MoveUpTreeItem()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var selectedFeature = GetSelectedTestScript(this.TestScriptModel.TestScriptList);

            if (selectedFeature != null && this.CanMoveUp(selectedFeature))
            {
                this.MoveUpTestScript(selectedFeature);
                this.MoveUpTestObject(selectedFeature.Tag as TestObject);
            }
        }

        /// <summary>
        /// The load test configuration.
        /// </summary>
        /// <summary>
        /// The on on tree view lost focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="routedEventArgs">
        /// The routed event args.
        /// </param>
        public void OnTreeListEditItemLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.SetDeactivateEditMode(this.TestScriptModel.TestScriptList);
        }

        /// <summary>
        /// The on tree view item drag over.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="routedEventArgs">
        /// The routed event args.
        /// </param>
        public void OnTreeViewItemDragOver(object sender, RoutedEventArgs routedEventArgs)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (routedEventArgs.OriginalSource is DragEventArgs)
            {
                var dragEventArgs = routedEventArgs.OriginalSource as DragEventArgs;
                var testObject = this.GetDropData(dragEventArgs.Data);

                var selectedTestScript = GetNearestContainer(dragEventArgs.OriginalSource as UIElement);
                if (testObject != null && selectedTestScript != null && selectedTestScript.Tag is TestCollection)
                {
                    if (this.CanDropTestCollection(selectedTestScript.Tag as TestObject, testObject))
                    {
                        dragEventArgs.Effects = DragDropEffects.Move;

                        dragEventArgs.Handled = true;
                    }
                }
            }
        }

        /// <summary>
        /// The on tree view item drop.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="routedEventArgs">
        /// The routed event args.
        /// </param>
        public void OnTreeViewItemDrop(object sender, RoutedEventArgs routedEventArgs)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            DragEventArgs dragEventArgs = null;

            var routedObjects = routedEventArgs.OriginalSource as object[];
            if (routedObjects != null)
            {
                foreach (var routedObject in routedObjects)
                {
                    if (routedObject is DragEventArgs)
                    {
                        dragEventArgs = routedObject as DragEventArgs;
                    }
                }
            }

            if (dragEventArgs != null)
            {
                var testObject = DeepCopyTestObject(this.GetDropData(dragEventArgs.Data));
                var selectedTestScript = GetNearestContainer(dragEventArgs.OriginalSource as UIElement);

                if (testObject != null && selectedTestScript != null && selectedTestScript.Tag is TestCollection)
                {
                    if (this.CanDropTestCollection(selectedTestScript.Tag as TestObject, testObject))
                    {
                        testObject.Parent = selectedTestScript.Tag as TestObject;

                        // Durch das Event an der ChildCollection wird ein neue Row im Tree hinzugefügt
                        this.AddNewTestScriptItem(selectedTestScript, testObject, false);
                    }
                }

                dragEventArgs.Effects = DragDropEffects.Move;
                dragEventArgs.Handled = true;
            }
        }

        /// <summary>
        /// The on tree view item initialize context menu items.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="routedEventArgs">
        /// The routed event args.
        /// </param>
        public void OnTreeViewItemEnableContextMenuItems(object sender, RoutedEventArgs routedEventArgs)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (routedEventArgs.OriginalSource is TestScriptItem)
            {
                var testScript = routedEventArgs.OriginalSource as TestScriptItem;

                var contextMenu = testScript.ContextMenuItems;

                // Wenn ein Feature kopiert wurde dann Menü freigeben
                var pasteMenuItem = contextMenu.Items.Cast<Control>().FirstOrDefault(item => item.Name == ContextMenuPaste);
                if (pasteMenuItem != null)
                {
                    pasteMenuItem.IsEnabled = this.CanPaste(testScript.Tag as TestObject);
                }

                // Wenn Parameter vorhanden sind dann das Menü freigeben.
                var editParemeterMenuItem = contextMenu.Items.Cast<Control>().FirstOrDefault(item => item.Name == ContextMenuEditParameter);
                if (editParemeterMenuItem != null)
                {
                    editParemeterMenuItem.IsEnabled = CanEditParameter(testScript.Tag as TestObject);
                }

                var upMenuItem = contextMenu.Items.Cast<Control>().FirstOrDefault(item => item.Name == ContextMenuUp);
                if (upMenuItem != null)
                {
                    upMenuItem.IsEnabled = this.CanMoveUp(testScript);
                }

                var downMenuItem = contextMenu.Items.Cast<Control>().FirstOrDefault(item => item.Name == ContextMenuDown);
                if (downMenuItem != null)
                {
                    downMenuItem.IsEnabled = this.CanMoveDown(testScript);
                }

                if (testScript.Parent == null)
                {
                    HandleRootContextMenuItems(contextMenu);
                }
            }
        }

        /// <summary>
        /// The paste tree item.
        /// </summary>
        public void PasteTreeItem()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var selectedFeature = GetSelectedTestScript(this.TestScriptModel.TestScriptList);

            if (selectedFeature != null && selectedFeature.IsEditMode == false && this.CanPaste(selectedFeature.Tag as TestObject))
            {
                var pasteFeature = CopyTestScript(this.testScriptItemCopy);

                selectedFeature.Children.Add(pasteFeature);
                selectedFeature.IsExpanded = true;
            }
        }

        /// <summary>
        /// The remove tree item.
        /// </summary>
        public void RemoveTreeItem()
        {
            var selectedFeature = GetSelectedTestScript(this.TestScriptModel.TestScriptList);
            {
                if (selectedFeature != null && selectedFeature.IsEditMode == false && CanRemove(selectedFeature.Tag as TestObject))
                {
                    if (this.ShowMessageBoxControl(selectedFeature.Tag as TestObject))
                    {
                        var parentFeature = selectedFeature.Parent;

                        if (parentFeature != null)
                        {
                            parentFeature.Children.Remove(selectedFeature);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The rename tree item.
        /// </summary>
        public void RenameTreeItem()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var selectedFeature = GetSelectedTestScript(this.TestScriptModel.TestScriptList);

            if (selectedFeature != null && CanRename(selectedFeature.Tag as TestObject))
            {
                selectedFeature.IsEditMode = true;
            }
        }

        /// <summary>
        /// The set deactivate edit mode.
        /// </summary>
        public void SetDeactivateEditMode()
        {
            this.SetDeactivateEditMode(this.TestScriptModel.TestScriptList);
        }

        /// <summary>
        /// The set deactivate edit mode.
        /// </summary>
        /// <param name="featureList">
        /// The feature list.
        /// </param>
        public void SetDeactivateEditMode(IEnumerable<TestScriptItem> featureList)
        {
            foreach (var featur in featureList)
            {
                if (featur.IsEditMode == true)
                {
                    featur.IsEditMode = false;
                }

                if (featur.Children.Count > 0)
                {
                    this.SetDeactivateEditMode(featur.Children);
                }
            }
        }

        /// <summary>
        /// The destroy configurator.
        /// </summary>
        public void UnloadConfigurator()
        {
            this.TestConfiguration = null;
            this.TestScriptModel = null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The can edit parameter.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool CanEditParameter(TestObject testObject)
        {
            if (testObject is TestMethod)
            {
                var testMethod = testObject as TestMethod;
                if (testMethod.Parameters.Count > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The can remove.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool CanRemove(TestObject testObject)
        {
            if (testObject.Parent == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The can rename.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool CanRename(TestObject testObject)
        {
            if (testObject is TestCollection)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The copy feature.
        /// </summary>
        /// <param name="oldTestScript">
        /// The old feature.
        /// </param>
        /// <returns>
        /// The <see cref="TestScriptItem"/>.
        /// </returns>
        private static TestScriptItem CopyTestScript(TestScriptItem oldTestScript)
        {
            if (oldTestScript.IsEditMode == false)
            {
                var newTestScript = oldTestScript.Copy();

                newTestScript.Parent = null;
                newTestScript.HasFocus = false;
                newTestScript.IsInFocusChain = false;

                return newTestScript;
            }

            return null;
        }

        /// <summary>
        /// The get description.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetDescription(TestObject testObject)
        {
            if (!string.IsNullOrEmpty(testObject.Description))
            {
                return testObject.Description.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ");
            }

            return string.Empty;
        }

        /// <summary>
        /// The get nearest container.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="TestScriptItem"/>.
        /// </returns>
        private static TestScriptItem GetNearestContainer(UIElement element)
        {
            // Walk up the element tree to the nearest tree view item.
            var container = element as StackPanel;
            while ((container == null) && (element != null))
            {
                element = VisualTreeHelper.GetParent(element) as UIElement;
                container = element as StackPanel;
            }

            return container != null ? container.DataContext as TestScriptItem : null;
        }

        /// <summary>
        /// The get selected script.
        /// </summary>
        /// <param name="testScriptList">
        /// The test script list.
        /// </param>
        /// <returns>
        /// The <see cref="TestScriptItem"/>.
        /// </returns>
        private static TestScriptItem GetSelectedTestScript(IEnumerable<TestScriptItem> testScriptList)
        {
            foreach (var testScript in testScriptList)
            {
                if (testScript.HasFocus)
                {
                    return testScript;
                }

                if (testScript.Children.Count > 0)
                {
                    var selectedTestScript = GetSelectedTestScript(testScript.Children);
                    if (selectedTestScript != null)
                    {
                        return selectedTestScript;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// The handle root context menu items.
        /// </summary>
        /// <param name="contextMenu">
        /// The context menu.
        /// </param>
        private static void HandleRootContextMenuItems(ContextMenu contextMenu)
        {
            var removeMenuItem = contextMenu.Items.Cast<Control>().FirstOrDefault(item => item.Name == ContextMenuRemove);
            if (removeMenuItem != null)
            {
                removeMenuItem.Visibility = Visibility.Collapsed;
            }

            var copyMenuItem = contextMenu.Items.Cast<Control>().FirstOrDefault(item => item.Name == ContextMenuCopy);
            if (copyMenuItem != null)
            {
                copyMenuItem.Visibility = Visibility.Collapsed;
            }

            var editParameterMenuItem = contextMenu.Items.Cast<Control>().FirstOrDefault(item => item.Name == ContextMenuEditParameter);
            if (editParameterMenuItem != null)
            {
                editParameterMenuItem.Visibility = Visibility.Collapsed;
            }

            var downMenuItem = contextMenu.Items.Cast<Control>().FirstOrDefault(item => item.Name == ContextMenuDown);
            if (downMenuItem != null)
            {
                downMenuItem.Visibility = Visibility.Collapsed;
            }

            var upMenuItem = contextMenu.Items.Cast<Control>().FirstOrDefault(item => item.Name == ContextMenuUp);
            if (upMenuItem != null)
            {
                upMenuItem.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// The get new feature.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <param name="isChecked">
        /// The is Checked.
        /// </param>
        /// <returns>
        /// The <see cref="TestScriptItem"/>.
        /// </returns>
        private TestScriptItem AddNewTestScriptItem(TestScriptItem parent, TestObject testObject, bool isChecked)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var parameterDescription = this.GetParameterDescription(testObject);
            var testType = this.GetTestType(testObject);
            var isValid = this.IsTestObjectValid(testObject);
            var contextMenu = this.GetContextMenu(testObject);
            var description = GetDescription(testObject);

            var childFeature = new TestScriptItem(testObject.DisplayName, parameterDescription, description, false, testType, isChecked, false, testObject, contextMenu, isValid, testObject.ToolTip);

            if (parent != null)
            {
                parent.IsExpanded = true;
                parent.Children.Add(childFeature);
            }

            // Child Element Hinzufügen
            if (testObject is TestCollection)
            {
                var testFolder = testObject as TestCollection;
                if (testFolder != null)
                {
                    foreach (var child in testFolder.TestObjects)
                    {
                        this.AddNewTestScriptItem(childFeature, child, child.IsActive);
                    }
                }
            }

            return childFeature;
        }

        /// <summary>
        /// The can drop test script.
        /// </summary>
        /// <param name="parentTestObject">
        /// The parent test object.
        /// </param>
        /// <param name="dropTestObject">
        /// The drop Test Object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanDropTestCollection(TestObject parentTestObject, TestObject dropTestObject)
        {
            Log.Info(this, string.Format("Parent Object: {0} - {1}, dropped Object: {2} - {3}", parentTestObject.Guid, parentTestObject.Name, dropTestObject.Guid, dropTestObject.Name));
            if (parentTestObject.Guid == dropTestObject.Guid)
            {
                return false;
            }

            if (parentTestObject.Parent != null)
            {
                if (!this.CanDropTestCollection(parentTestObject.Parent, dropTestObject))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The can move down.
        /// </summary>
        /// <param name="selectedFeature">
        /// The selected feature.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanMoveDown(TestScriptItem selectedFeature)
        {
            if (selectedFeature != null && selectedFeature.Parent != null)
            {
                var parentFeatureList = selectedFeature.Parent.Children;
                var selectedFeatureIndex = parentFeatureList.IndexOf(selectedFeature);

                if (selectedFeatureIndex < parentFeatureList.Count - 1)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The can move up.
        /// </summary>
        /// <param name="selectedFeature">
        /// The selected feature.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanMoveUp(TestScriptItem selectedFeature)
        {
            if (selectedFeature != null && selectedFeature.Parent != null)
            {
                var parentFeatureList = selectedFeature.Parent.Children;
                var selectedFeatureIndex = parentFeatureList.IndexOf(selectedFeature);

                if (selectedFeatureIndex > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The can paste.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanPaste(TestObject testObject)
        {
            if (testObject is TestCollection)
            {
                return this.testScriptItemCopy != null;
            }

            return false;
        }

        /// <summary>
        /// The get context menu.
        /// </summary>
        /// <param name="testObject">
        /// The test Object.
        /// </param>
        /// <returns>
        /// The <see cref="ContextMenu"/>.
        /// </returns>
        private ContextMenu GetContextMenu(TestObject testObject)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var contextMenue = new ContextMenu();

            if (testObject is TestCollection)
            {
                // Add Folder
                var addFolder = new MenuItem { Name = ContextMenuAddFolder, Header = "Add Folder" };
                addFolder.Click += this.OnAddFolderClick;
                contextMenue.Items.Add(addFolder);

                // Separator
                contextMenue.Items.Add(new Separator());
            }

            // Copy
            var copy = new MenuItem { Name = ContextMenuCopy, Header = "Copy" };
            copy.Click += this.OnCopyClick;
            contextMenue.Items.Add(copy);

            // Paste
            if (testObject is TestCollection)
            {
                var paste = new MenuItem { Name = ContextMenuPaste, Header = "Paste" };
                paste.Click += this.OnPasteClick;
                contextMenue.Items.Add(paste);
            }

            // Remove
            var remove = new MenuItem { Name = ContextMenuRemove, Header = "Remove" };
            remove.Click += this.OnRemoveClick;
            contextMenue.Items.Add(remove);

            // Rename
            if (testObject is TestCollection)
            {
                var rename = new MenuItem { Name = ContextMenuAddFolder, Header = "Rename" };
                rename.Click += this.OnRenameClick;
                contextMenue.Items.Add(rename);
            }

            // Separator
            contextMenue.Items.Add(new Separator());

            // Move Up
            var up = new MenuItem { Name = ContextMenuUp, Header = "Move Up" };
            up.Click += this.OnMoveUpClick;
            contextMenue.Items.Add(up);

            // Move Down
            var down = new MenuItem { Name = ContextMenuDown, Header = "Move Down" };
            down.Click += this.OnMoveDownClick;
            contextMenue.Items.Add(down);

            // Edit Parameter
            if ((testObject is TestCollection) == false)
            {
                contextMenue.Items.Add(new Separator());

                var parameter = new MenuItem { Name = ContextMenuEditParameter, Header = "Edit Parameter" };
                parameter.Click += this.OnEditParameterClick;
                contextMenue.Items.Add(parameter);
            }

            return contextMenue;
        }

        /// <summary>
        /// The get drop data.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="TestObject"/>.
        /// </returns>
        private TestObject GetDropData(IDataObject data)
        {
            var dataFormats = data.GetFormats();
            foreach (var dataFormat in dataFormats)
            {
                if ("EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects.TestSuite" == dataFormat)
                {
                    return data.GetData("EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects.TestSuite") as TestSuite;
                }

                if ("EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects.TestCase" == dataFormat)
                {
                    return data.GetData("EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects.TestCase") as TestCase;
                }

                if ("EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects" == dataFormat)
                {
                    return data.GetData("EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects") as TestObject;
                }

                if ("EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects.TestFolder" == dataFormat)
                {
                    return data.GetData("EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects.TestFolder") as TestFolder;
                }
            }

            return null;
        }

        /// <summary>
        /// The get parameter.
        /// </summary>
        /// <param name="testMethod">
        /// The test method.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetParameterDescription(TestObject testMethod)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            var result = string.Empty;

            if (testMethod is TestMethod)
            {
                var parameters = ((TestMethod)testMethod).Parameters;

                foreach (var parameter in parameters)
                {
                    if (result.Length > 0)
                    {
                        result += "; ";
                    }

                    result += string.Format("{0}='{1}' ", parameter.Name, parameter.ParameterValue);
                }
            }

            return result;
        }

        /// <summary>
        /// The get test type.
        /// </summary>
        /// <param name="testMethod">
        /// The test method.
        /// </param>
        /// <returns>
        /// The <see cref="TestType"/>.
        /// </returns>
        private TestType GetTestType(TestObject testMethod)
        {
            if (testMethod.GetType() == typeof(TestCase))
            {
                return TestType.eTestCase;
            }

            if (testMethod.GetType() == typeof(TestModule))
            {
                return TestType.eTestModule;
            }

            if (testMethod.GetType() == typeof(TestSuite))
            {
                return TestType.eTestSuite;
            }

            if (testMethod.GetType() == typeof(TestFolder))
            {
                return TestType.eTestFolder;
            }

            return TestType.eIndeterminate;
        }

        /// <summary>
        /// The is test object valid.
        /// </summary>
        /// <param name="testMethod">
        /// The test method.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsTestObjectValid(TestObject testMethod)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (testMethod is TestMethod)
            {
                var parameters = ((TestMethod)testMethod).Parameters;

                return parameters.All(parameter => parameter.ParameterValueValid);
            }

            return true;
        }

        /// <summary>
        /// The load test script model.
        /// </summary>
        /// <param name="testScriptModel">
        /// The test script model.
        /// </param>
        /// <param name="testConfig">
        /// The test config.
        /// </param>
        private void LoadTestScriptModel(TestScriptModel testScriptModel, TestConfiguration testConfig)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            testScriptModel.TestScriptList.Clear();

            foreach (var testObject in testConfig.AvailableTestObjects)
            {
                var childFeatur = this.AddNewTestScriptItem(null, testObject, testObject.IsActive);

                this.TestScriptModel.TestScriptList.Add(childFeatur);
            }

            // Feature List headers
            testScriptModel.ColumnHeader1 = "Method";
            testScriptModel.ColumnHeader2 = "Parameter";
            testScriptModel.ColumnHeader3 = "Description";

            this.RaisePropertyChanged("FeatureModel");
        }

        /// <summary>
        /// The move down test object.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        private void MoveDownTestObject(TestObject testObject)
        {
            try
            {
                if (testObject != null && testObject.Parent is TestCollection)
                {
                    var testObjectList = (testObject.Parent as TestCollection).TestObjects;
                    var featureIndex = testObjectList.IndexOf(testObject);

                    testObjectList.Move(featureIndex, featureIndex + 1);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorEx(this, ex, ex.Message);
            }
        }

        /// <summary>
        /// The move down feature.
        /// </summary>
        /// <param name="selectedTestScript">
        /// The selected feature.
        /// </param>
        private void MoveDownTestScript(TestScriptItem selectedTestScript)
        {
            try
            {
                if (this.CanMoveDown(selectedTestScript))
                {
                    var selectedIndex = selectedTestScript.Parent.Children.IndexOf(selectedTestScript);
                    selectedTestScript.Parent.Children.Move(selectedIndex, selectedIndex + 1);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorEx(this, ex, ex.Message);
            }
        }

        /// <summary>
        /// The move up test object.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        private void MoveUpTestObject(TestObject testObject)
        {
            try
            {
                if (testObject != null && testObject.Parent is TestCollection)
                {
                    var testObjectList = (testObject.Parent as TestCollection).TestObjects;
                    var featureIndex = testObjectList.IndexOf(testObject);
                    if (featureIndex > 0)
                    {
                        testObjectList.Move(featureIndex, featureIndex - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorEx(this, ex, ex.Message);
            }
        }

        /// <summary>
        /// The feature move up.
        /// </summary>
        /// <param name="selectedTestScript">
        /// The selected feature.
        /// </param>
        private void MoveUpTestScript(TestScriptItem selectedTestScript)
        {
            try
            {
                if (this.CanMoveUp(selectedTestScript))
                {
                    var selectedIndex = selectedTestScript.Parent.Children.IndexOf(selectedTestScript);
                    selectedTestScript.Parent.Children.Move(selectedIndex, selectedIndex - 1);
//                    selectedTestScript.SetFocus();
                    selectedTestScript.HasFocus = true;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorEx(this, ex, ex.Message);
            }
        }

        /// <summary>
        /// The on add folder click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="routedEventArgs">
        /// The routed event args.
        /// </param>
        private void OnAddFolderClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var selectedFeature = GetSelectedTestScript(this.TestScriptModel.TestScriptList);

            var testObject = new TestFolder { Name = NewFolderName };

            // Durch das Event an der ChildCollection wird ein neue Row im Tree hinzugefügt
            this.AddNewTestScriptItem(selectedFeature, testObject, false);

            selectedFeature.IsExpanded = true;
        }

        /// <summary>
        /// The copy on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="routedEventArgs">
        /// The routed event args.
        /// </param>
        private void OnCopyClick(object sender, RoutedEventArgs routedEventArgs)
        {
            this.CopyTreeItem();
        }

        /// <summary>
        /// The edit parameter on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnEditParameterClick(object sender, RoutedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var selectedFeature = GetSelectedTestScript(this.TestScriptModel.TestScriptList);

            var testMethod = selectedFeature.Tag as TestMethod;
            if (testMethod != null)
            {
                this.ShowParameterControl(testMethod, selectedFeature);
            }
        }

        /// <summary>
        /// Downs the on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs"/> instance containing the event data.
        /// </param>
        private void OnMoveDownClick(object sender, RoutedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var selectedFeature = GetSelectedTestScript(this.TestScriptModel.TestScriptList);

            if (selectedFeature != null)
            {
                this.MoveDownTestScript(selectedFeature);
                this.MoveDownTestObject(selectedFeature.Tag as TestObject);
                selectedFeature.HasFocus = true;
            }
        }

        /// <summary>
        /// Ups the on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs"/> instance containing the event data.
        /// </param>
        private void OnMoveUpClick(object sender, RoutedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var selectedFeature = GetSelectedTestScript(this.TestScriptModel.TestScriptList);

            if (selectedFeature != null)
            {
                this.MoveUpTestScript(selectedFeature);
                this.MoveUpTestObject(selectedFeature.Tag as TestObject);
                selectedFeature.HasFocus = true;
            }
        }

        /// <summary>
        /// Pastes the on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs"/> instance containing the event data.
        /// </param>
        private void OnPasteClick(object sender, RoutedEventArgs e)
        {
            this.PasteTreeItem();
        }

        /// <summary>
        /// The on remove click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnRemoveClick(object sender, RoutedEventArgs e)
        {
            this.RemoveTreeItem();
        }

        /// <summary>
        /// The on rename click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnRenameClick(object sender, RoutedEventArgs e)
        {
            this.RenameTreeItem();
        }

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property.
        /// </param>
        private void RaisePropertyChanged(string propertyName)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (this.PropertyChanged != null)
            {
                Log.Enter(this, string.Format("{0} {1}", MethodBase.GetCurrentMethod().Name, propertyName));

                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The show message box control.
        /// </summary>
        /// <param name="testObject">
        /// The test object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ShowMessageBoxControl(TestObject testObject)
        {
            if (testObject is TestFolder)
            {
                this.messageBoxControl.ShowHandlerDialog("Delete Folder", "Are you sure you want to delete this Folder?", testObject.DisplayName);
                return this.messageBoxControl.Result;
            }

            this.messageBoxControl.ShowHandlerDialog("Delete TestScript", "Are you sure you want to delete this TestScript?", testObject.DisplayName);
            return this.messageBoxControl.Result;
        }

        /// <summary>
        /// The show parameter control.
        /// </summary>
        /// <param name="testMethod">
        /// The test method.
        /// </param>
        /// <param name="selectedFeature">
        /// The selected feature.
        /// </param>
        private void ShowParameterControl(TestMethod testMethod, TestScriptItem selectedFeature)
        {
            this.editParameterControl.ShowHandlerDialog(testMethod.Parameters);

            selectedFeature.ParameterDescription = this.GetParameterDescription(testMethod);
            selectedFeature.IsValid = this.IsTestObjectValid(testMethod);
        }

        #endregion
    }
}