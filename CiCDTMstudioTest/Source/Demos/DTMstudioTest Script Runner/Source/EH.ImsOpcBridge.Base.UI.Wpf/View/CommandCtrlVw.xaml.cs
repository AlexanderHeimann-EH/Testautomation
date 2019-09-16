// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandCtrlVw.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for CommandCtrlVw.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    // ReSharper disable RedundantExtendsListEntry

    /// <summary>
    /// Interaction logic for CommandCtrlVw.xaml
    /// </summary>
    public partial class CommandCtrlVw : UserControl
    {
        // ReSharper restore RedundantExtendsListEntry
        #region Constants and Fields

        /// <summary>
        ///   The ctrl orientation property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty CtrlOrientationProperty = DependencyProperty.Register("CtrlOrientation", typeof(Orientation), typeof(CommandCtrlVw), new PropertyMetadata(default(Orientation)));

        /// <summary>
        /// The horizontal scroll bar visibility property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty = DependencyProperty.Register("HorizontalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(CommandCtrlVw), new PropertyMetadata(default(ScrollBarVisibility)));

        /// <summary>
        /// The vertical scroll bar visibility property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarVisibilityProperty = DependencyProperty.Register("VerticalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(CommandCtrlVw), new PropertyMetadata(default(ScrollBarVisibility)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "CommandCtrlVw" /> class.
        /// </summary>
        public CommandCtrlVw()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets or sets CtrlOrientation.
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
        /// Gets or sets HorizontalScrollBarVisibility.
        /// </summary>
        public ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get
            {
                return (ScrollBarVisibility)this.GetValue(HorizontalScrollBarVisibilityProperty);
            }

            set
            {
                this.SetValue(HorizontalScrollBarVisibilityProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets VerticalScrollBarVisibility.
        /// </summary>
        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get
            {
                return (ScrollBarVisibility)this.GetValue(VerticalScrollBarVisibilityProperty);
            }

            set
            {
                this.SetValue(VerticalScrollBarVisibilityProperty, value);
            }
        }

        #endregion
    }
}
