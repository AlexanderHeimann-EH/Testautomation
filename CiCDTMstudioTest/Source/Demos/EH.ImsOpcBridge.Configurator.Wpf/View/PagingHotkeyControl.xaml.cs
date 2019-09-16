// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagingHotkeyControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for PagingHotkeyControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class PagingHotkeyControl
    /// </summary>
    public partial class PagingHotkeyControl
    {
        #region Static Fields

        /// <summary>
        /// The begin page command property
        /// </summary>
        public static readonly DependencyProperty BeginPageCommandProperty = DependencyProperty.Register("BeginPageCommand", typeof(DelegateCommand), typeof(PagingHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The end page command property
        /// </summary>
        public static readonly DependencyProperty EndPageCommandProperty = DependencyProperty.Register("EndPageCommand", typeof(DelegateCommand), typeof(PagingHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The next page command property
        /// </summary>
        public static readonly DependencyProperty NextPageCommandProperty = DependencyProperty.Register("NextPageCommand", typeof(DelegateCommand), typeof(PagingHotkeyControl), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The previous page command property
        /// </summary>
        public static readonly DependencyProperty PreviousPageCommandProperty = DependencyProperty.Register("PreviousPageCommand", typeof(DelegateCommand), typeof(PagingHotkeyControl), new PropertyMetadata(default(DelegateCommand)));
        
        /// <summary>
        /// The tool tip begin page property
        /// </summary>
        public static readonly DependencyProperty ToolTipBeginPageProperty = DependencyProperty.Register("ToolTipBeginPage", typeof(string), typeof(PagingHotkeyControl), new PropertyMetadata(default(string)));

        /// <summary>
        /// The tool tip end page property
        /// </summary>
        public static readonly DependencyProperty ToolTipEndPageProperty = DependencyProperty.Register("ToolTipEndPage", typeof(string), typeof(PagingHotkeyControl), new PropertyMetadata(default(string)));

        /// <summary>
        /// The tool tip next page property
        /// </summary>
        public static readonly DependencyProperty ToolTipNextPageProperty = DependencyProperty.Register("ToolTipNextPage", typeof(string), typeof(PagingHotkeyControl), new PropertyMetadata(default(string)));

        /// <summary>
        /// The tool tip previous page property
        /// </summary>
        public static readonly DependencyProperty ToolTipPreviousPageProperty = DependencyProperty.Register("ToolTipPreviousPage", typeof(string), typeof(PagingHotkeyControl), new PropertyMetadata(default(string)));
        
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingHotkeyControl"/> class.
        /// </summary>
        public PagingHotkeyControl()
        {
            this.ToolTipBeginPage = Properties.Resources.FirstPage;
            this.ToolTipEndPage = Properties.Resources.LastPage;
            this.ToolTipNextPage = Properties.Resources.NextPage;
            this.ToolTipPreviousPage = Properties.Resources.PreviousPage;

            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the begin page command.
        /// </summary>
        /// <value>The begin page command.</value>
        public DelegateCommand BeginPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(BeginPageCommandProperty);
            }

            set
            {
                this.SetValue(BeginPageCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the end page command.
        /// </summary>
        /// <value>The end page command.</value>
        public DelegateCommand EndPageCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(EndPageCommandProperty);
            }

            set
            {
                this.SetValue(EndPageCommandProperty, value);
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
        /// Gets or sets the tool tip begin page.
        /// </summary>
        /// <value>The tool tip begin page.</value>
        public string ToolTipBeginPage
        {
            get
            {
                return (string)this.GetValue(ToolTipBeginPageProperty);
            }

            set
            {
                this.SetValue(ToolTipBeginPageProperty, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the tool tip end page.
        /// </summary>
        /// <value>The tool tip end page.</value>
        public string ToolTipEndPage
        {
            get
            {
                return (string)this.GetValue(ToolTipEndPageProperty);
            }

            set
            {
                this.SetValue(ToolTipEndPageProperty, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the tool tip next page.
        /// </summary>
        /// <value>The tool tip next page.</value>
        public string ToolTipNextPage
        {
            get
            {
                return (string)this.GetValue(ToolTipNextPageProperty);
            }

            set
            {
                this.SetValue(ToolTipNextPageProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tool tip previous page.
        /// </summary>
        /// <value>The tool tip previous page.</value>
        public string ToolTipPreviousPage
        {
            get
            {
                return (string)this.GetValue(ToolTipPreviousPageProperty);
            }

            set
            {
                this.SetValue(ToolTipPreviousPageProperty, value);
            }
        }
        
        #endregion
    }
}