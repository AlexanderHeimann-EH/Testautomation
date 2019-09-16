// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrintPreviewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.UI.Wpf.Properties;

    /// <summary>
    /// View Model for the print preview
    /// </summary>
    public class PrintPreviewModel : DependencyObject
    {
        #region Constants and Fields

        /// <summary>
        /// The html property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached("Html", typeof(string), typeof(PrintPreviewModel), new FrameworkPropertyMetadata(OnHtmlChanged));

        /// <summary>
        /// The html string property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty HtmlStringProperty = DependencyProperty.Register("HtmlString", typeof(string), typeof(PrintPreviewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The title property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(PrintPreviewModel), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintPreviewModel"/> class.
        /// </summary>
        public PrintPreviewModel()
            : this(Resources.PrintPreview, Resources.PrintPreviewHtmlValue)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintPreviewModel"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="htmlValue">The HTML value.</param>
        public PrintPreviewModel(string title, string htmlValue)
        {
            this.Title = title;
            this.HtmlValue = htmlValue;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the HTML string.
        /// </summary>
        /// <value>The HTML string.</value>
        public string HtmlValue
        {
            get
            {
                return (string)this.GetValue(HtmlStringProperty);
            }

            set
            {
                this.SetValue(HtmlStringProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return (string)this.GetValue(TitleProperty);
            }

            set
            {
                this.SetValue(TitleProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the HTML.
        /// </summary>
        /// <param name="webBrowser">The WebBrowser.</param>
        /// <returns>The html.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed. Suppression is OK here.")]
        [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
        public static string GetHtml(WebBrowser webBrowser)
        {
            if (webBrowser == null)
            {
                throw new ArgumentNullException(@"webBrowser");
            }
            
            return (string)webBrowser.GetValue(HtmlProperty);
        }

        /// <summary>
        /// The set html.
        /// </summary>
        /// <param name="webBrowser">The WebBrowser.</param>
        /// <param name="value">The value.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed. Suppression is OK here.")]
        public static void SetHtml(WebBrowser webBrowser, string value)
        {
            if (webBrowser == null)
            {
                throw new ArgumentNullException(@"webBrowser");
            }

            webBrowser.SetValue(HtmlProperty, value);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on html changed.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="e">The e.</param>
        private static void OnHtmlChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var webBrowser = dependencyObject as WebBrowser;
            if (webBrowser != null)
            {
                var newValue = e.NewValue as string;

                if (!string.IsNullOrEmpty(newValue))
                {
                    webBrowser.NavigateToString(e.NewValue as string);
                }
            }
        }

        #endregion
    }
}
