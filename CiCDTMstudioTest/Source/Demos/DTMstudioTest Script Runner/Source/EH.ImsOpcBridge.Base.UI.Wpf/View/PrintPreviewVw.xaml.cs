// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrintPreviewVw.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System;
    using System.Windows;

    using mshtml;

    /// <summary>
    /// Interaction logic for PrintPreviewVw.xaml
    /// </summary>
    [CLSCompliant(false)]
    public partial class PrintPreviewVw
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintPreviewVw"/> class.
        /// </summary>
        public PrintPreviewVw()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The close button click handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// The print button click handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void PrintButtonClick(object sender, RoutedEventArgs e)
        {
            var doc = this.webBrowser.Document as IHTMLDocument2;

            if (doc != null)
            {
                // ReSharper disable LocalizableElement
                doc.execCommand("Print", true, null);
                 // ReSharper restore LocalizableElement
                this.DialogResult = true;
            }
        }

        #endregion
    }
}
