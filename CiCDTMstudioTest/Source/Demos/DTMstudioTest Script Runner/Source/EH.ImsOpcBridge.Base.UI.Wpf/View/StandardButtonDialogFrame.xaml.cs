// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StandardButtonDialogFrame.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for StandardButtonDialogFrame.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System.Windows;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.UI.Wpf.ViewModel;

    // ReSharper disable RedundantExtendsListEntry

    /// <summary>
    /// Interaction logic for StandardButtonDialogFrame.xaml
    /// </summary>
    public partial class StandardButtonDialogFrame : Window
    {
        // ReSharper restore RedundantExtendsListEntry
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardButtonDialogFrame"/> class.
        /// </summary>
        public StandardButtonDialogFrame()
        {
            this.InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Displays the dialog model with the control embedded.
        /// </summary>
        /// <param name="title">The title to be displayed.</param>
        /// <param name="buttons">The buttons to be displayed.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="content">The content control to be embedded.</param>
        /// <returns>Identifies the dialog button pressed to exit the dialog.</returns>
        public ResultMessage DisplayModal(string title, MessageButton buttons, DefaultMessageButton defaultButton, Control content)
        {
            var viewModel = new StandardButtonDialogFrameVm(title, buttons, defaultButton);

            this.DataContext = viewModel;
            this.controlContainer.Children.Add(content);

            this.ShowDialog();

            return viewModel.Result;
        }

        #region Methods

        /// <summary>
        /// Button command handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        #endregion
    }
}
