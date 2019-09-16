// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The edit parameter control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.SuiteConfigurator.Content.SuiteConfiguratorControl.Content.MessageBoxControl
{
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    /// <summary>
    /// The edit parameter control.
    /// </summary>
    public partial class MessageBoxControl : UserControl, INotifyPropertyChanged
    {
        #region Static Fields

        /// <summary>
        /// The message property.
        /// </summary>
        public static readonly DependencyProperty MessageHeaderProperty = DependencyProperty.Register("MessageHeader", typeof(string), typeof(MessageBoxControl), new UIPropertyMetadata(string.Empty));

        /// <summary>
        /// The customers property.
        /// </summary>
        public static readonly DependencyProperty MessageLine1Property = DependencyProperty.Register("MessageLine1", typeof(string), typeof(MessageBoxControl), new UIPropertyMetadata(string.Empty));

        /// <summary>
        /// The message line 2 property.
        /// </summary>
        public static readonly DependencyProperty MessageLine2Property = DependencyProperty.Register("MessageLine2", typeof(string), typeof(MessageBoxControl), new UIPropertyMetadata(string.Empty));

        #endregion

        #region Fields

        /// <summary>
        /// The _hide request.
        /// </summary>
        private bool hideRequest;

        /// <summary>
        /// The _parent.
        /// </summary>
        private UIElement parent;

        /// <summary>
        /// The _result.
        /// </summary>
        private bool result;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxControl"/> class. 
        /// </summary>
        public MessageBoxControl()
        {
            this.InitializeComponent();
            this.Result = false;
            this.Visibility = Visibility.Hidden;

        }

        #endregion

        #region Public Events

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string MessageHeader
        {
            get
            {
                return (string)this.GetValue(MessageHeaderProperty);
            }

            set
            {
                this.SetValue(MessageHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public string MessageLine1
        {
            get
            {
                return (string)this.GetValue(MessageLine1Property);
            }

            set
            {
                this.SetValue(MessageLine1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string MessageLine2
        {
            get
            {
                return (string)this.GetValue(MessageLine2Property);
            }

            set
            {
                this.SetValue(MessageLine2Property, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether result.
        /// </summary>
        public bool Result
        {
            get
            {
                return this.result;
            }

            private set
            {
                this.result = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The set parent.
        /// </summary>
        /// <param name="elementParent">
        /// The parent.
        /// </param>
        public void SetParent(UIElement elementParent)
        {
            this.parent = elementParent;
        }

        /// <summary>
        /// The show handler dialog.
        /// </summary>
        /// <param name="header">
        /// The header.
        /// </param>
        /// <param name="line1">
        /// The line 1.
        /// </param>
        /// <param name="line2">
        /// The line 2.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ShowHandlerDialog(string header, string line1, string line2)
        {
            this.MessageHeader = header;
            this.MessageLine1 = line1;
            this.MessageLine2 = line2;

            this.Visibility = Visibility.Visible;
            this.parent.IsEnabled = false;
            this.hideRequest = false;

            while (!this.hideRequest)
            {
                // HACK: Stop the thread if the application is about to close
                if (this.Dispatcher.HasShutdownStarted || this.Dispatcher.HasShutdownFinished)
                {
                    break;
                }

                // HACK: Simulate "DoEvents"
                this.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
                Thread.Sleep(20);
            }

            return this.result;
        }

        #endregion

        // Using a DependencyProperty as the backing store for Message.
        // This enables animation, styling, binding, etc...
        #region Methods

        /// <summary>
        /// The hide handler dialog.
        /// </summary>
        private void HideHandlerDialog()
        {
            this.hideRequest = true;
            this.Visibility = Visibility.Hidden;
            this.parent.IsEnabled = true;
        }

        /// <summary>
        /// The cancel button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NoButtonClick(object sender, RoutedEventArgs e)
        {
            this.Result = false;

            this.HideHandlerDialog();
        }

        /// <summary>
        /// The ok button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void YesButtonClick(object sender, RoutedEventArgs e)
        {
            this.Result = true;

            this.HideHandlerDialog();
        }

        #endregion
    }
}