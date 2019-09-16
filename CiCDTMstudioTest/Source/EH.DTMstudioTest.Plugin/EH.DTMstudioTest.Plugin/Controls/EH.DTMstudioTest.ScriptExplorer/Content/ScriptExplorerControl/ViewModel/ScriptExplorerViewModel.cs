// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptExplorerViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The Suite configurator view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.ScriptExplorer.Content.ScriptExplorerControl.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument;
    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.DTMstudioTest.ScriptExplorer.Content.ScriptExplorerControl.Content.EditParameterControl;
    using EH.DTMstudioTest.ScriptExplorer.Content.ScriptExplorerControl.Content.MessageBoxControl;
    using EH.PCPS.ScriptExplorerTree.Model;
    using EH.PCPS.SelectionTree.Controls;
    using EH.PCPS.SelectionTree.Controls.Model;

    /// <summary>
    /// Class SuiteConfiguratorViewModel.
    /// </summary>
    public class ScriptExplorerViewModel : DependencyObject, INotifyPropertyChanged
    {
        #region Constants

        /// <summary>
        /// The ContextMenu copy.
        /// </summary>
        private const string ContextMenuCopy = "ContextMenuCopy";

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
        private TestConfiguration testConfig;

        /// <summary>
        /// The copied feature.
        /// </summary>
        private ScriptExplorerItem testSuiteItemCopy;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptExplorerViewModel"/> class.
        /// </summary>
        /// <param name="controlParent">
        /// The control Parent.
        /// </param>
        /// <param name="childControls">
        /// The child Controls.
        /// </param>
        public ScriptExplorerViewModel(Grid controlParent, UserControl[] childControls)
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
        public TestConfiguration TestConfig
        {
            get
            {
                return this.testConfig;
            }

            set
            {
                if (this.testConfig == value)
                {
                    return;
                }

                this.testConfig = value;
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
        public ScriptExplorerModel ScriptExplorerModel { get; set; }

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

            var testScript = GetSelectedTestSuite(this.ScriptExplorerModel.ScriptExplorerList);
            this.testSuiteItemCopy = CopyTestSuite(testScript);
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
                    this.draggedTestObject = (treeListItem.Node.Tag as ScriptExplorerItem).Tag as TestObject;
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
        /// <param name="testConfiguration">
        /// The test configuration.
        /// </param>
        public void LoadExplorer(TestConfiguration testConfiguration)
        {
            this.TestConfig = null;
            this.TestConfig = testConfiguration;

            this.ScriptExplorerModel = new ScriptExplorerModel();

            this.LoadScriptExplorerModel(this.ScriptExplorerModel, this.TestConfig);
        }

        /// <summary>
        /// The destroy configurator.
        /// </summary>
        public void UnloadExplorer()
        {
            this.TestConfig = null;
            this.ScriptExplorerModel = null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The copy feature.
        /// </summary>
        /// <param name="oldTestSuite">
        /// The old Test Suite.
        /// </param>
        /// <returns>
        /// The <see cref="TestSuite"/>.
        /// </returns>
        private static ScriptExplorerItem CopyTestSuite(ScriptExplorerItem oldTestSuite)
        {
            var newTestSuite = oldTestSuite.Copy();

            newTestSuite.Parent = null;
            newTestSuite.HasFocus = false;
            newTestSuite.IsInFocusChain = false;

            return newTestSuite;
        }

        /// <summary>
        /// The get selected feature.
        /// </summary>
        /// <param name="testSuiteList">
        /// The feature list.
        /// </param>
        /// <returns>
        /// The <see cref="ScriptExplorerItem"/>.
        /// </returns>
        private static ScriptExplorerItem GetSelectedTestSuite(IEnumerable<ScriptExplorerItem> testSuiteList)
        {
            foreach (var testSuite in testSuiteList)
            {
                if (testSuite.HasFocus)
                {
                    return testSuite;
                }

                if (testSuite.Children.Count > 0)
                {
                    var selectedTestSuite = GetSelectedTestSuite(testSuite.Children);
                    if (selectedTestSuite != null)
                    {
                        return selectedTestSuite;
                    }
                }
            }

            return null;
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
        /// The <see cref="ScriptExplorerItem"/>.
        /// </returns>
        private ScriptExplorerItem AddNewScriptExplorerItem(ScriptExplorerItem parent, TestObject testObject, bool isChecked)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var parameterDescription = this.GetParameterDescription(testObject);
            var testType = this.GetTestType(testObject);
            var contextMenu = this.GetContextMenu();
            var description = !string.IsNullOrEmpty(testObject.Description) ? testObject.Description.Replace("\r\n", " ") : string.Empty;

            var childFeature = new ScriptExplorerItem(testObject.Name, parameterDescription, description, false, testType, isChecked, false, testObject, contextMenu, true, testObject.ToolTip);

            if (parent != null)
            {
                parent.Children.Add(childFeature);
                parent.IsExpanded = true;
            }

            if (testObject is TestCollection)
            {
                var testFolder = testObject as TestCollection;
                foreach (var child in testFolder.TestObjects)
                {
                    this.AddNewScriptExplorerItem(childFeature, child, false);
                }
            }
            
            return childFeature;
        }

        /// <summary>
        /// The get context menu.
        /// </summary>
        /// <returns>
        /// The <see cref="ContextMenu"/>.
        /// </returns>
        private ContextMenu GetContextMenu()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var contextMenue = new ContextMenu();

            // Copy
            var copy = new MenuItem { Name = ContextMenuCopy, Header = "Copy" };
            copy.Click += this.OnCopyClick;
            contextMenue.Items.Add(copy);

            return contextMenue;
        }

        /// <summary>
        /// The get parameter.
        /// </summary>
        /// <param name="tesObject">
        /// The test method.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetParameterDescription(TestObject tesObject)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            var result = string.Empty;

            if (tesObject is TestMethod)
            {
                var parameters = ((TestMethod)tesObject).Parameters;

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
        /// <param name="tesObject">
        /// The test method.
        /// </param>
        /// <returns>
        /// The <see cref="TestType"/>.
        /// </returns>
        private TestType GetTestType(TestObject tesObject)
        {
            if (tesObject.GetType() == typeof(TestCase))
            {
                return TestType.eTestCase;
            }

            if (tesObject.GetType() == typeof(TestModule))
            {
                return TestType.eTestModule;
            }

            if (tesObject.GetType() == typeof(TestSuite))
            {
                return TestType.eTestSuite;
            }

            if (tesObject.GetType() == typeof(TestFolder))
            {
                return TestType.eTestFolder;
            }

            return TestType.eIndeterminate;
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
        /// The load test suite model.
        /// </summary>
        /// <param name="scriptExplorerModel">
        /// The test suite model.
        /// </param>
        /// <param name="testConfiguration">
        /// The test config.
        /// </param>
        private void LoadScriptExplorerModel(ScriptExplorerModel scriptExplorerModel, TestConfiguration testConfiguration)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            scriptExplorerModel.ScriptExplorerList.Clear();

            foreach (var testObject in testConfiguration.AvailableTestObjects)
            {
                var childFeatur = this.AddNewScriptExplorerItem(null, testObject, testObject.IsActive);

                this.ScriptExplorerModel.ScriptExplorerList.Add(childFeatur);
            }

            // Feature List headers
            scriptExplorerModel.ColumnHeader1 = "Method";
            scriptExplorerModel.ColumnHeader2 = "Parameter";
            scriptExplorerModel.ColumnHeader3 = "Description";

            this.RaisePropertyChanged("FeatureModel");
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

        #endregion
    }
}