// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckBoxSmallControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class CheckBoxSmallControl
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Class CheckBoxSmallControl
    /// </summary>
    public partial class CheckBoxSmallControl : UserControl
    {
        #region Static Fields

        /// <summary>
        /// The check box label property
        /// </summary>
        public static readonly DependencyProperty CheckBoxLabelProperty = DependencyProperty.Register("CheckBoxLabel", typeof(string), typeof(CheckBoxSmallControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The is checked property
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(CheckBoxSmallControl), new PropertyMetadata(true));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxSmallControl"/> class.
        /// </summary>
        public CheckBoxSmallControl()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the check box label.
        /// </summary>
        /// <value>The check box label.</value>
        public string CheckBoxLabel
        {
            get
            {
                return (string)this.GetValue(CheckBoxLabelProperty);
            }

            set
            {
                this.SetValue(CheckBoxLabelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked.
        /// </summary>
        /// <value><c>true</c> if this instance is checked; otherwise, <c>false</c>.</value>
        public bool IsChecked
        {
            get
            {
                return (bool)this.GetValue(IsCheckedProperty);
            }

            set
            {
                this.SetValue(IsCheckedProperty, value);
            }
        }

        #endregion
    }
}