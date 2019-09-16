// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressBarVw.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    // ReSharper disable RedundantExtendsListEntry

    /// <summary>
    /// Interaction logic for ProgressBarVw.xaml
    /// </summary>
    public partial class ProgressBarVw : UserControl
    {
        // ReSharper restore RedundantExtendsListEntry
        #region Constants and Fields

        /// <summary>
        /// The subtitle visibility property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty SubtitleVisibilityProperty = DependencyProperty.Register("Subtitle", typeof(Visibility), typeof(ProgressBarVw), new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// The title visibility property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TitleVisibilityProperty = DependencyProperty.Register("TitleVisibility", typeof(Visibility), typeof(ProgressBarVw), new PropertyMetadata(Visibility.Visible));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBarVw"/> class.
        /// </summary>
        public ProgressBarVw()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Subtitle.
        /// </summary>
        /// <value>The subtitle visibility.</value>
        public Visibility SubtitleVisibility
        {
            get
            {
                return (Visibility)this.GetValue(SubtitleVisibilityProperty);
            }

            set
            {
                this.SetValue(SubtitleVisibilityProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets TitleVisibility.
        /// </summary>
        /// <value>The title visibility.</value>
        public Visibility TitleVisibility
        {
            get
            {
                return (Visibility)this.GetValue(TitleVisibilityProperty);
            }

            set
            {
                this.SetValue(TitleVisibilityProperty, value);
            }
        }

        #endregion
    }
}
