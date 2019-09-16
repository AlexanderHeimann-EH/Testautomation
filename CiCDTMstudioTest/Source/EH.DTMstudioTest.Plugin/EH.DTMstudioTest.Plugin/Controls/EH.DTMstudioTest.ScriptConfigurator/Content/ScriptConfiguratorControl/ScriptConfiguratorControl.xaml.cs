// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptConfiguratorControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The script configurator control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.ScriptConfigurator.Content.ScriptConfiguratorControl
{
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument;
    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.DTMstudioTest.ScriptConfigurator.Content.ScriptConfiguratorControl.ViewModel;

    /// <summary>
    /// Class ScriptConfiguratorControl.
    /// </summary>
    public partial class ScriptConfiguratorControl : UserControl
    {
        #region Fields

        /// <summary>
        /// The left ctrl.
        /// </summary>
        private bool ctrlKey;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptConfiguratorControl"/> class.
        /// </summary>
        public ScriptConfiguratorControl()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.InitializeComponent();

            this.ctrlKey = false;
            var userControls = new UserControl[2];
            userControls[0] = this.EditParameterControl;
            userControls[1] = this.MessageBoxControl;

            this.DataContext = new ScriptConfiguratorViewModel(this.TestScriptTreeControl, userControls);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The load test script selection tree control.
        /// </summary>
        /// <param name="testConfig">
        /// The test config.
        /// </param>
        public void LoadTestScriptSelectionTreeControl(TestConfiguration testConfig)
        {
            var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
            if (scriptConfiguratorViewModel != null)
            {
                scriptConfiguratorViewModel.LoadConfigurator(testConfig);
                this.TestScriptSelectionTreeControl.DataContext = scriptConfiguratorViewModel.TestScriptModel;
            }
        }

        /// <summary>
        /// The unload test script selection tree control.
        /// </summary>
        public void UnloadTestScriptSelectionTreeControl()
        {
            var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
            if (scriptConfiguratorViewModel != null)
            {
                scriptConfiguratorViewModel.UnloadConfigurator();
            }

            this.TestScriptSelectionTreeControl.DataContext = null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
                if (scriptConfiguratorViewModel != null)
                {
                    scriptConfiguratorViewModel.RemoveTreeItem();

                    e.Handled = true;
                    return;
                }
            }

            if (e.Key == Key.F2)
            {
                var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
                if (scriptConfiguratorViewModel != null)
                {
                    scriptConfiguratorViewModel.RenameTreeItem();

                    e.Handled = true;
                    return;
                }
            }

            if (e.Key == Key.Enter)
            {
                var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
                if (scriptConfiguratorViewModel != null)
                {
                    scriptConfiguratorViewModel.SetDeactivateEditMode();

                    e.Handled = true;
                    return;
                }
            }

            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                this.ctrlKey = true;
            }

            if (e.Key == Key.C && this.ctrlKey)
            {
                var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
                if (scriptConfiguratorViewModel != null)
                {
                    scriptConfiguratorViewModel.CopyTreeItem();

                    e.Handled = true;
                    return;
                }
            }

            if (e.Key == Key.V && this.ctrlKey)
            {
                var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
                if (scriptConfiguratorViewModel != null)
                {
                    scriptConfiguratorViewModel.PasteTreeItem();

                    e.Handled = true;
                    return;
                }
            }

            if (e.Key == Key.Up && this.ctrlKey)
            {
                var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
                if (scriptConfiguratorViewModel != null)
                {
                    scriptConfiguratorViewModel.MoveUpTreeItem();

                    e.Handled = true;
                    return;
                }
            }

            if (e.Key == Key.Down && this.ctrlKey)
            {
                var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
                if (scriptConfiguratorViewModel != null)
                {
                    scriptConfiguratorViewModel.MoveDownTreeItem();

                    e.Handled = true;
                    return;
                }
            }

            e.Handled = false;
        }

        /// <summary>
        /// The on key up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                this.ctrlKey = false;
            }
        }

        /// <summary>
        /// The feature selection tree control_ on tree view item lost focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnTreeViewEditItemLostFocus(object sender, RoutedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
            if (scriptConfiguratorViewModel != null)
            {
                scriptConfiguratorViewModel.OnTreeListEditItemLostFocus(sender, e);
            }
        }

        /// <summary>
        /// The feature select list_ on tree view item drag over.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnTreeViewItemDragOver(object sender, RoutedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
            if (scriptConfiguratorViewModel != null)
            {
                scriptConfiguratorViewModel.OnTreeViewItemDragOver(sender, e);
            }
        }

        /// <summary>
        /// The feature select list_ on tree view item drop.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnTreeViewItemDrop(object sender, RoutedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
            if (scriptConfiguratorViewModel != null)
            {
                scriptConfiguratorViewModel.OnTreeViewItemDrop(sender, e);
            }
        }

        /// <summary>
        /// The feature select list_ on tree view item initialize context menu items.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnTreeViewItemEnableContextMenuItems(object sender, RoutedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
            if (scriptConfiguratorViewModel != null)
            {
                scriptConfiguratorViewModel.OnTreeViewItemEnableContextMenuItems(sender, e);
            }
        }

        /// <summary>
        /// The on tree view item mouse move.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnTreeViewItemMouseMove(object sender, RoutedEventArgs e)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            var scriptConfiguratorViewModel = this.DataContext as ScriptConfiguratorViewModel;
            if (scriptConfiguratorViewModel != null)
            {
                scriptConfiguratorViewModel.HandleTreeViewMouseMove(sender, e);
            }
        }

        /// <summary>
        /// The suite configurator control_ on size changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ScriptConfiguratorControl_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var size = sender as UserControl;
            if (size != null)
            {
                this.TestScriptSelectionTreeControl.Height = size.ActualHeight;
            }
        }

        #endregion
    }
}