// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseSelectorControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for BaseSelectorControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    // ReSharper disable RedundantExtendsListEntry

    /// <summary>
    /// Interaction logic for BaseSelectorControl.xaml
    /// </summary>
    public partial class BaseSelectorControl : UserControl
    {
        // ReSharper restore RedundantExtendsListEntry
        #region Static Fields

        /// <summary>
        /// The button style property.
        /// </summary>
        public static readonly DependencyProperty ButtonStyleProperty = DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(BaseSelectorControl), new PropertyMetadata(default(Style)));

        /// <summary>
        /// The ctrl orientation property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty CtrlOrientationProperty = DependencyProperty.Register("CtrlOrientation", typeof(Orientation), typeof(BaseSelectorControl), new PropertyMetadata(default(Orientation)));

        /// <summary>
        /// The frame visibility property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FrameVisibilityProperty = DependencyProperty.Register("FrameVisibility", typeof(Visibility), typeof(BaseSelectorControl), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The marker color property.
        /// </summary>
        public static readonly DependencyProperty MarkerColorProperty = DependencyProperty.Register("MarkerColor", typeof(Color), typeof(BaseSelectorControl), new PropertyMetadata(default(Color)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSelectorControl" /> class.
        /// </summary>
        public BaseSelectorControl()
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

        /// <summary>
        /// Gets or sets CtrlOrientation.
        /// </summary>
        /// <value>The CTRL orientation.</value>
        public Orientation CtrlOrientation
        {
            get
            {
                return (Orientation)this.GetValue(CtrlOrientationProperty);
            }

            set
            {
                this.SetValue(CtrlOrientationProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets FrameVisibility.
        /// </summary>
        /// <value>The frame visibility.</value>
        public Visibility FrameVisibility
        {
            get
            {
                return (Visibility)this.GetValue(FrameVisibilityProperty);
            }

            set
            {
                this.SetValue(FrameVisibilityProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets MarkerColor.
        /// </summary>
        /// <value>The color of the marker.</value>
        public Color MarkerColor
        {
            get
            {
                return (Color)this.GetValue(MarkerColorProperty);
            }

            set
            {
                this.SetValue(MarkerColorProperty, value);
            }
        }

        #endregion
    }
}
