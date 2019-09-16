// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SuiteConfiguratorControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The script configurator control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.SuiteConfigurator.Content.SuiteConfiguratorControl
{
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument;
    using EH.DTMstudioTest.Common.Utilities.Logging;
    using EH.DTMstudioTest.SuiteConfigurator.Content.SuiteConfiguratorControl.ViewModel;

    /// <summary>
    /// Class ScriptConfiguratorControl.
    /// </summary>
    public partial class SuiteConfiguratorControl : UserControl
    {
        #region Fields

        /// <summary>
        /// The left ctrl.
        /// </summary>
        private bool ctrlKey;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SuiteConfiguratorControl"/> class.
        /// </summary>
        public SuiteConfiguratorControl()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            this.InitializeComponent();

            this.ctrlKey = false;
            var userControls = new UserControl[2];
            userControls[0] = this.EditParameterControl;
            userControls[1] = this.MessageBoxControl;

            this.DataContext = new SuiteConfiguratorViewModel(this.TestSuiteTreeControl, userControls);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="testConfig">
        /// The test config.
        /// </param>
        public void LoadTestSuiteSelectionTreeControl(TestConfiguration testConfig)
        {
            var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
            if (suiteConfiguratorViewModel != null)
            {
                suiteConfiguratorViewModel.LoadConfigurator(testConfig);
                this.TestSuiteSelectionTreeControl.DataContext = suiteConfiguratorViewModel.TestSuiteModel;
            }
        }

        /// <summary>
        /// The unload test suite selection tree control.
        /// </summary>
        public void UnloadTestSuiteSelectionTreeControl()
        {
            var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
            if (suiteConfiguratorViewModel != null)
            {
                suiteConfiguratorViewModel.UnloadConfigurator();
            }

            this.TestSuiteSelectionTreeControl.DataContext = null;
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
                var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
                if (suiteConfiguratorViewModel != null)
                {
                    suiteConfiguratorViewModel.RemoveTreeItem();

                    e.Handled = true;
                    return;
                }
            }

            if (e.Key == Key.F2)
            {
                var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
                if (suiteConfiguratorViewModel != null)
                {
                    suiteConfiguratorViewModel.RenameTreeItem();

                    e.Handled = true;
                    return;
                }
            }

            if (e.Key == Key.Enter)
            {
                var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
                if (suiteConfiguratorViewModel != null)
                {
                    suiteConfiguratorViewModel.SetDeactivateEditMode();

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
                var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
                if (suiteConfiguratorViewModel != null)
                {
                    suiteConfiguratorViewModel.CopyTreeItem();

                    e.Handled = true;
                    return;
                }
            }

            if (e.Key == Key.V && this.ctrlKey)
            {
                var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
                if (suiteConfiguratorViewModel != null)
                {
                    suiteConfiguratorViewModel.PasteTreeItem();

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

            var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
            if (suiteConfiguratorViewModel != null)
            {
                suiteConfiguratorViewModel.OnTreeListEditItemLostFocus(sender, e);
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

            var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
            if (suiteConfiguratorViewModel != null)
            {
                suiteConfiguratorViewModel.OnTreeViewItemDragOver(sender, e);
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

            var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
            if (suiteConfiguratorViewModel != null)
            {
                suiteConfiguratorViewModel.OnTreeViewItemDrop(sender, e);
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

            var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
            if (suiteConfiguratorViewModel != null)
            {
                suiteConfiguratorViewModel.OnTreeViewItemEnableContextMenuItems(sender, e);
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

            var suiteConfiguratorViewModel = this.DataContext as SuiteConfiguratorViewModel;
            if (suiteConfiguratorViewModel != null)
            {
                suiteConfiguratorViewModel.HandleTreeViewMouseMove(sender, e);
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
        private void SuiteConfiguratorControl_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var size = sender as UserControl;
            if (size != null)
            {
                this.TestSuiteSelectionTreeControl.Height = size.ActualHeight;
            }
        }

        #endregion
    }
}