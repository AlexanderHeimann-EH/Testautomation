// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationPage.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for NavigationPage.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage
    {
        #region Static Fields

        /// <summary>
        /// The button style property.
        /// </summary>
        public static readonly DependencyProperty ButtonStyleProperty = DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(NavigationPage), new PropertyMetadata(default(Style)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationPage" /> class.
        /// </summary>
        public NavigationPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the button style.
        /// </summary>
        /// <value>The button style.</value>
        public Style ButtonStyle
        {
            get
            {
                return (Style)this.GetValue(ButtonStyleProperty);
            }

            set
            {
                this.SetValue(ButtonStyleProperty, value);
            }
        }

        #endregion
    }
}
