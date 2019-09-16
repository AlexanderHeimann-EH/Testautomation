// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FcDtmFileSelectionDialog.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Dialog to select fcDtm-Files to restore DTM
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using EH.ImsOpcBridge.UI.Wpf.ViewModel;

    /// <summary>
    /// Interaction logic for FcDtmFileBrowserDialog.xaml
    /// </summary>
    public partial class FcDtmFileBrowserDialog
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FcDtmFileBrowserDialog"/> class.
        /// </summary>
        public FcDtmFileBrowserDialog()
        {
            this.BrowserVm = new BrowserViewModel();
            this.DataContext = this.BrowserVm;
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets BrowserVm.
        /// </summary>
        /// <value>The browser vm.</value>
        public BrowserViewModel BrowserVm { get; set; }

        /// <summary>
        /// Gets or sets SelectedFilePath.
        /// </summary>
        /// <value>The selected file path.</value>
        public string SelectedFilePath { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="defaultPath">
        /// The default path.
        /// </param>
        /// <returns>
        /// true, if ok was pressed. false on cancel
        /// </returns>
        public bool ShowDialog(string defaultPath)
        {
            if (!string.IsNullOrEmpty(defaultPath))
            {
                // save path for Dtm Folder Button use.
                this.BrowserVm.DtmFolderPath = defaultPath;

                // navigate to path
                this.SelectedFilePath = defaultPath;
                this.BrowserVm.GoToPath(this.SelectedFilePath);
            }

            var showDialog = this.ShowDialog();
            return showDialog != null && (bool)showDialog;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The list auto generating column.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ListAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var pd = e.PropertyDescriptor as PropertyDescriptor;

            if (null != pd)
            {
                var displayNameAttribute = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
                if (null != displayNameAttribute && displayNameAttribute != DisplayNameAttribute.Default)
                {
                    e.Column.Header = displayNameAttribute.DisplayName;
                }
            }
        }

        /// <summary>
        /// The OkClick.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OkClick(object sender, RoutedEventArgs e)
        {
            this.SelectedFilePath = this.BrowserVm.SelectedFilePath;
            this.DialogResult = true;
        }

        /// <summary>
        /// The on selected item changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var treeView = sender as TreeView;
            if (treeView != null)
            {
                var treeViewItem = treeView.SelectedItem as TreeViewItem;
                if (treeViewItem != null)
                {
                    treeViewItem.BringIntoView(new Rect(50, 50, 50, 50));
                }
            }
        }

        /// <summary>
        /// Trees the view mouse up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.
        /// </param>
        private void TreeViewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var treeView = sender as TreeView;
            if (treeView != null)
            {
                var selectedFolder = treeView.SelectedItem as FolderViewModel;
                if (selectedFolder != null)
                {
                    selectedFolder.IsSelected = true;
                }
            }
        }

        #endregion
    }
}
