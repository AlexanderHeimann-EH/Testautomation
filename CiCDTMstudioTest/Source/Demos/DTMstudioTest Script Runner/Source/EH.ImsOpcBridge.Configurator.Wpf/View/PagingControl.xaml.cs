// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagingControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for PagingControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Interaction logic for PagingControl.xaml
    /// </summary>
    public partial class PagingControl
    {
        #region Static Fields

        /// <summary>
        /// The export configuration command property
        /// </summary>
        public static readonly DependencyProperty ExportConfigurationCommandProperty = DependencyProperty.Register("ExportConfigurationCommand", typeof(DelegateCommand), typeof(PagingControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The import configuration command property
        /// </summary>
        public static readonly DependencyProperty ImportConfigurationCommandProperty = DependencyProperty.Register("ImportConfigurationCommand", typeof(DelegateCommand), typeof(PagingControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The load configuration command property
        /// </summary>
        public static readonly DependencyProperty LoadConfigurationCommandProperty = DependencyProperty.Register("LoadConfigurationCommand", typeof(DelegateCommand), typeof(PagingControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The next page command property
        /// </summary>
        public static readonly DependencyProperty NextPageCommandProperty = DependencyProperty.Register("NextPageCommand", typeof(DelegateCommand), typeof(PagingControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The previous page command property
        /// </summary>
        public static readonly DependencyProperty PreviousPageCommandProperty = DependencyProperty.Register("PreviousPageCommand", typeof(DelegateCommand), typeof(PagingControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The save configuration command property
        /// </summary>
        public static readonly DependencyProperty SaveConfigurationCommandProperty = DependencyProperty.Register("SaveConfigurationCommand", typeof(DelegateCommand), typeof(PagingControl), new PropertyMetadata(default(DelegateCommand)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingControl" /> class.
        /// </summary>
        public PagingControl()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the export configuration command.
        /// </summary>
        /// <value>The export configuration command.</value>
        public DelegateCommand ExportConfigurationCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(ExportConfigurationCommandProperty);
            }

            set
            {
                this.SetValue(ExportConfigurationCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the import configuration command.
        /// </summary>
        /// <value>The import configuration command.</value>
        public DelegateCommand ImportConfigurationCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(ImportConfigurationCommandProperty);
            }

            set
            {
                this.SetValue(ImportConfigurationCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the load configuration command.
        /// </summary>
        /// <value>The load configuration command.</value>
        public DelegateCommand LoadConfigurationCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(LoadConfigurationCommandProperty);
            }

            set
            {
                this.SetValue(LoadConfigurationCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the next page command.
        /// </summary>
        /// <value>The next page command.</value>
        public DelegateCommand NextPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(NextPageCommandProperty);
            }

            set
            {
                this.SetValue(NextPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the previous page command.
        /// </summary>
        /// <value>The previous page command.</value>
        public DelegateCommand PreviousPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(PreviousPageCommandProperty);
            }

            set
            {
                this.SetValue(PreviousPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the save configuration command.
        /// </summary>
        /// <value>The save configuration command.</value>
        public DelegateCommand SaveConfigurationCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(SaveConfigurationCommandProperty);
            }

            set
            {
                this.SetValue(SaveConfigurationCommandProperty, value);
            }
        }

        #endregion
    }
}