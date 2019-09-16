// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for MenuControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.View
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media.Animation;

    /// <summary>
    /// Interaction logic for MenuControl.xaml
    /// </summary>
    public partial class MenuControl : UserControl
    {
        #region Constants and Fields

        /// <summary>
        /// The menu orientation property.
        /// </summary>
        public static readonly DependencyProperty MenuOrientationProperty = DependencyProperty.Register("MenuOrientation", typeof(Orientation), typeof(MenuControl), new PropertyMetadata(Orientation.Vertical));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuControl"/> class.
        /// </summary>
        public MenuControl()
        {
            this.InitializeComponent();
        }

        #endregion
    }
}
