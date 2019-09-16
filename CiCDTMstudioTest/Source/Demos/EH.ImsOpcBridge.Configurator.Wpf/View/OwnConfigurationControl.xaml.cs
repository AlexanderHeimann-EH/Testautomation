// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OwnConfigurationControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for OwnConfigurationControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.View
{
    using System;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Configurator.ViewModel;

    /// <summary>
    /// Interaction logic for OwnConfigurationControl.xaml
    /// </summary>
    public partial class OwnConfigurationControl : UserControl
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnConfigurationControl"/> class.
        /// </summary>
        public OwnConfigurationControl()
        {
            this.InitializeComponent();
        }

        #endregion
    }
}
