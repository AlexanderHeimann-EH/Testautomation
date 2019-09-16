// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkButton.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for LinkButton.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    // ReSharper disable RedundantExtendsListEntry

    /// <summary>
    /// Interaction logic for LinkButton.xaml
    /// </summary>
    public partial class LinkButton : Button
    {
        // ReSharper restore RedundantExtendsListEntry
        #region Constants and Fields

        /// <summary>
        /// The button text property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register("ButtonText", typeof(string), typeof(LinkButton), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkButton"/> class.
        /// </summary>
        public LinkButton()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets button text.
        /// </summary>
        public string ButtonText
        {
            get
            {
                return (string)this.GetValue(ButtonTextProperty);
            }

            set
            {
                this.SetValue(ButtonTextProperty, value);
            }
        }

        #endregion
    }
}
