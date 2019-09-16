// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Balloon.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for Balloon.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Agent.Wpf
{
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// Class Balloon
    /// </summary>
    public partial class Balloon
    {
        #region Static Fields

        /// <summary>
        /// The balloon text property
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty BalloonTextProperty = DependencyProperty.Register("BalloonText", typeof(string), typeof(Balloon), new FrameworkPropertyMetadata(string.Empty));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Balloon"/> class.
        /// </summary>
        public Balloon()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the balloon text.
        /// </summary>
        /// <value>The balloon text.</value>
        public string BalloonText
        {
            get
            {
                return (string)this.GetValue(BalloonTextProperty);
            }

            set
            {
                this.SetValue(BalloonTextProperty, value);
            }
        }

        #endregion
    }
}