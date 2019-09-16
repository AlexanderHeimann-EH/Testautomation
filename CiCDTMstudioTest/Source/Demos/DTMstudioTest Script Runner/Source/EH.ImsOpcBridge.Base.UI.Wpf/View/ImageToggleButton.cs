// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageToggleButton.cs" company="Endress+Hauser Process Solutions AG">
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
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;

    /// <summary>
    /// A button providing interface for handling images.
    /// </summary>
    public class ImageToggleButton : ToggleButton
    {
        #region Static Fields

        /// <summary>
        /// The background image property.
        /// </summary>
        public static readonly DependencyProperty BackgroundImageProperty = DependencyProperty.Register("BackgroundImage", typeof(string), typeof(ImageToggleButton), new PropertyMetadata(default(string)));

        /// <summary>
        /// The normal image property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ButtonImageProperty = DependencyProperty.Register("ButtonImage", typeof(string), typeof(ImageToggleButton), new PropertyMetadata(default(string)));

        /// <summary>
        /// The button text property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register("ButtonText", typeof(string), typeof(ImageToggleButton), new PropertyMetadata(default(string)));

        /// <summary>
        /// The frame background property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FrameBackgroundProperty = DependencyProperty.Register("FrameBackground", typeof(Brush), typeof(ImageToggleButton), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The frame border brush property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FrameBorderBrushProperty = DependencyProperty.Register("FrameBorderBrush", typeof(Brush), typeof(ImageToggleButton), new PropertyMetadata(default(Brush)));

        ///// <summary>
        ///// The frame disabled background property.
        ///// </summary>
        // [Localizable(false)]
        // public static readonly DependencyProperty FrameDisabledBackgroundProperty = DependencyProperty.Register("FrameDisabledBackground", typeof(Brush), typeof(ImageToggleButton), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The frame image property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FrameImageProperty = DependencyProperty.Register("FrameImage", typeof(string), typeof(ImageToggleButton), new PropertyMetadata(default(string)));

        /// <summary>
        /// The frame marker brush property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FrameMarkerBrushProperty = DependencyProperty.Register("FrameMarkerBrush", typeof(Brush), typeof(ImageToggleButton), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The frame pressed background property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FramePressedBackgroundProperty = DependencyProperty.Register("FramePressedBackground", typeof(Brush), typeof(ImageToggleButton), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The frame visibility property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty FrameVisibilityProperty = DependencyProperty.Register("FrameVisibility", typeof(Visibility), typeof(ImageToggleButton), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The image scale property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ImageScaleProperty = DependencyProperty.Register("ImageScale", typeof(double), typeof(ImageToggleButton), new PropertyMetadata(1.0));

        /// <summary>
        /// The image size property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ImageSizeProperty = DependencyProperty.Register("ImageSize", typeof(double), typeof(ImageToggleButton), new PropertyMetadata(default(double)));

        /// <summary>
        /// The marker color property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty MarkerColorProperty = DependencyProperty.Register("MarkerColor", typeof(Color), typeof(ImageToggleButton), new PropertyMetadata(default(Color)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="ImageToggleButton" /> class.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = "Ok here.")]
        static ImageToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageToggleButton), new FrameworkPropertyMetadata(typeof(ImageToggleButton)));
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
        /// Gets or sets FrameMarkerBrush.
        /// </summary>
        /// <value>The frame marker brush.</value>
        public Brush FrameMarkerBrush
        {
            get
            {
                return (Brush)this.GetValue(FrameMarkerBrushProperty);
            }

            set
            {
                this.SetValue(FrameMarkerBrushProperty, value);
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
        /// Gets or sets MarkerColor.
        /// </summary>
        /// <value>The marker color.</value>
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
