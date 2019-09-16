// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerViewControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for ServerViewControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Agent.Wpf.View
{
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Agent.Wpf.ViewModel;

    // ReSharper disable RedundantExtendsListEntry

    /// <summary>
    /// Class ServerViewControl
    /// </summary>
    public partial class ServerViewControl : UserControl
    {
        // ReSharper restore RedundantExtendsListEntry
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerViewControl"/> class.
        /// </summary>
        public ServerViewControl()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>The model.</value>
        public ServerViewControlViewModel Model
        {
            get
            {
                return (ServerViewControlViewModel)this.DataContext;
            }
        }

        #endregion
    }
}