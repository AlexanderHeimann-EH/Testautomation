// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerHotkeyControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for ServerHotkeyControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class ServerHotkeyControl
    /// </summary>
    public partial class ServerHotkeyControl
    {
        #region Static Fields

        /// <summary>
        /// The connect server command property
        /// </summary>
        public static readonly DependencyProperty ConnectServerCommandProperty = DependencyProperty.Register("ConnectServerCommand", typeof(DelegateCommand), typeof(ServerHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The tool tip connect server property
        /// </summary>
        public static readonly DependencyProperty ToolTipConnectServerProperty = DependencyProperty.Register("ToolTipConnectServer", typeof(string), typeof(ServerHotkeyControl), new PropertyMetadata(default(string)));
        
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerHotkeyControl"/> class.
        /// </summary>
        public ServerHotkeyControl()
        {
            this.ToolTipConnectServer = Properties.Resources.BrowseServerAddressSpace;
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties
        
        /// <summary>
        /// Gets or sets the connect server command.
        /// </summary>
        /// <value>The connect server command.</value>
        public DelegateCommand ConnectServerCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(ConnectServerCommandProperty);
            }

            set
            {
                this.SetValue(ConnectServerCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip connect server.
        /// </summary>
        /// <value>The tool tip connect server.</value>
        public string ToolTipConnectServer
        {
            get
            {
                return (string)this.GetValue(ToolTipConnectServerProperty);
            }

            set
            {
                this.SetValue(ToolTipConnectServerProperty, value);
            }
        }
        
        #endregion
    }
}