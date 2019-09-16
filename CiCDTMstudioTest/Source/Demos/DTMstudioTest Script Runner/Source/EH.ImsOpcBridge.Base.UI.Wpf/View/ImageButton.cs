// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageButton.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   A button providing interface for handling images.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// A button providing interface for handling images.
    /// </summary>
    public class ImageButton : Button
    {
        #region Static Fields

        /// <summary>
        /// The background image property.
        /// </summary>
        public static readonly DependencyProperty BackgroundImageProperty = DependencyProperty.Register("BackgroundImage", typeof(string), typeof(ImageButton), new PropertyMetadata(default(string)));

        /// <summary>
        /// The normal image property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ButtonImageProperty = DependencyProperty.Register("ButtonImage", typeof(string), typeof(ImageButton), new PropertyMetadata(default(string)));

        /// <summary>
        /// The button text property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register("ButtonText", typeof(string), typeof(ImageButton), new PropertyMetadata(default(string)));

        /// <summary>
        /// The corner radius property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ImageButton), new PropertyMetadata(default(CornerRadius)));

        /// <summary>
        /// The description property.
        /// </summary>
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(ImageButton), new PropertyMetadata(default(string)));

        /// <summary>
        /// The frame background property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FrameBackgroundProperty = DependencyProperty.Register("FrameBackground", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The frame border brush property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FrameBorderBrushProperty = DependencyProperty.Register("FrameBorderBrush", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The frame disabled background property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FrameDisabledBackgroundProperty = DependencyProperty.Register("FrameDisabledBackground", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The frame image property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FrameImageProperty = DependencyProperty.Register("FrameImage", typeof(string), typeof(ImageButton), new PropertyMetadata(default(string)));

        /// <summary>
        /// The frame pressed background property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FramePressedBackgroundProperty = DependencyProperty.Register("FramePressedBackground", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The frame visibility property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FrameVisibilityProperty = DependencyProperty.Register("FrameVisibility", typeof(Visibility), typeof(ImageButton), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The image scale property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ImageScaleProperty = DependencyProperty.Register("ImageScale", typeof(double), typeof(ImageButton), new PropertyMetadata(1.0));

        /// <summary>
        /// The image size property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ImageSizeProperty = DependencyProperty.Register("ImageSize", typeof(double), typeof(ImageButton), new PropertyMetadata(default(double)));

        /// <summary>
        /// The is flow directed property.
        /// </summary>
        public static readonly DependencyProperty IsFlowDirectedProperty = DependencyProperty.Register("IsFlowDirected", typeof(bool), typeof(ImageButton), new PropertyMetadata(default(bool)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="ImageButton" /> class.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = "Ok here.")]
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        public string BackgroundImage
        {
            get
            {
                return (string)this.GetValue(BackgroundImageProperty);
            }

            set
            {
                this.SetValue(BackgroundImageProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets ButtonImage.
        /// </summary>
        /// <value>The button image.</value>
        public string ButtonImage
        {
            get
            {
                return (string)this.GetValue(ButtonImageProperty);
            }

            set
            {
                this.SetValue(ButtonImageProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets button text.
        /// </summary>
        /// <value>The button text.</value>
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

        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        /// <value>The corner radius.</value>
        public CornerRadius CornerRadius
        {
            get
            {
                return (CornerRadius)this.GetValue(CornerRadiusProperty);
            }

            set
            {
                this.SetValue(CornerRadiusProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return (string)this.GetValue(DescriptionProperty);
            }

            set
            {
                this.SetValue(DescriptionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets FrameBackground.
        /// </summary>
        /// <value>The frame background.</value>
        public Brush FrameBackground
        {
            get
            {
                return (Brush)this.GetValue(FrameBackgroundProperty);
            }

            set
            {
                this.SetValue(FrameBackgroundProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets FrameBorderBrush.
        /// </summary>
        /// <value>The frame border brush.</value>
        public Brush FrameBorderBrush
        {
            get
            {
                return (Brush)this.GetValue(FrameBorderBrushProperty);
            }

            set
            {
                this.SetValue(FrameBorderBrushProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets FrameDisabledBackground.
        /// </summary>
        /// <value>The frame disabled background.</value>
        public Brush FrameDisabledBackground
        {
            get
            {
                return (Brush)this.GetValue(FrameDisabledBackgroundProperty);
            }

            set
            {
                this.SetValue(FrameDisabledBackgroundProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets Frame Image.
        /// </summary>
        /// <value>The frame image.</value>
        public string FrameImage
        {
            get
            {
                return (string)this.GetValue(FrameImageProperty);
            }

            set
            {
                this.SetValue(FrameImageProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets FramePressedBackground.
        /// </summary>
        /// <value>The frame pressed background.</value>
        public Brush FramePressedBackground
        {
            get
            {
                return (Brush)this.GetValue(FramePressedBackgroundProperty);
            }

            set
            {
                this.SetValue(FramePressedBackgroundProperty, value);
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
        /// Gets or sets ImageScale.
        /// </summary>
        /// <value>The image scale.</value>
        public double ImageScale
        {
            get
            {
                return (double)this.GetValue(ImageScaleProperty);
            }

            set
            {
                this.SetValue(ImageScaleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets ImageSize.
        /// </summary>
        /// <value>The size of the image.</value>
        public double ImageSize
        {
            get
            {
                return (double)this.GetValue(ImageSizeProperty);
            }

            set
            {
                this.SetValue(ImageSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is flow directed.
        /// </summary>
        /// <value><c>true</c> if this instance is flow directed; otherwise, <c>false</c>.</value>
        public bool IsFlowDirected
        {
            get
            {
                return (bool)this.GetValue(IsFlowDirectedProperty);
            }

            set
            {
                this.SetValue(IsFlowDirectedProperty, value);
            }
        }

        #endregion
    }
}
