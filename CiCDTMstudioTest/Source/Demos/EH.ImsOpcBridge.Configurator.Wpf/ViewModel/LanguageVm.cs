// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   View model for a language
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// View model for a language
    /// </summary>
    public class LanguageVm : DependencyObject
    {
        #region Constants and Fields

        /// <summary>
        /// The flag property.
        /// </summary>
        public static readonly DependencyProperty BannerProperty = DependencyProperty.Register("Banner", typeof(Image), typeof(LanguageVm), new PropertyMetadata(default(Image)));

        /// <summary>
        /// The lcid property.
        /// </summary>
        public static readonly DependencyProperty LcidProperty = DependencyProperty.Register("Lcid", typeof(int), typeof(LanguageVm), new PropertyMetadata(default(int)));

        /// <summary>
        /// The name property.
        /// </summary>
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(LanguageVm), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageVm"/> class.
        /// </summary>
        /// <param name="lcid">The lcid.</param>
        public LanguageVm(int lcid)
        {
            this.Lcid = lcid;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Banner.
        /// </summary>
        /// <value>The flag.</value>
        public Image Banner
        {
            get
            {
                return (Image)this.GetValue(BannerProperty);
            }

            set
            {
                this.SetValue(BannerProperty, value);
            }
        }

        /// <summary>
        /// Gets LCID.
        /// </summary>
        public int Lcid
        {
            get
            {
                return (int)this.GetValue(LcidProperty);
            }

            private set
            {
                this.SetValue(LcidProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return (string)this.GetValue(NameProperty);
            }

            set
            {
                this.SetValue(NameProperty, value);
            }
        }

        #endregion
    }
}
