// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditParameterControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The edit parameter control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.ScriptExplorer.Content.ScriptExplorerControl.Content.EditParameterControl
{
    using System.ComponentModel;
    using System.Reflection;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.Common.Utilities.Logging;

    /// <summary>
    /// The edit parameter control.
    /// </summary>
    public partial class EditParameterControl : UserControl, INotifyPropertyChanged
    {
        #region Static Fields

        /// <summary>
        /// The customers property.
        /// </summary>
        public static readonly DependencyProperty EditParametersProperty = DependencyProperty.Register("EditParameters", typeof(TestParameterCollection), typeof(EditParameterControl), new UIPropertyMetadata(null));

        /// <summary>
        /// The message property.
        /// </summary>
        public static readonly DependencyProperty HeaderMessageProperty = DependencyProperty.Register("HeaderMessage", typeof(string), typeof(EditParameterControl), new UIPropertyMetadata(null));

        #endregion

        #region Fields

        /// <summary>
        /// The _hide request.
        /// </summary>
        private bool hideRequest;

        /// <summary>
        /// The is validated.
        /// </summary>
        private bool isValidated;

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
        /// Initializes a new instance of the <see cref="EditParameterControl"/> class.
        /// </summary>
        public EditParameterControl()
        {
            this.InitializeComponent();

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
        /// Gets or sets the customers.
        /// </summary>
        public TestParameterCollection EditParameters
        {
            get
            {
                return (TestParameterCollection)this.GetValue(EditParametersProperty);
            }

            set
            {
                this.SetValue(EditParametersProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string HeaderMessage
        {
            get
            {
                return (string)this.GetValue(HeaderMessageProperty);
            }

            set
            {
                this.SetValue(HeaderMessageProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is validated.
        /// </summary>
        public bool IsValidated
        {
            get
            {
                return this.isValidated;
            }

            set
            {
                if (this.isValidated != value)
                {
                    this.isValidated = value;
                    this.RaisePropertyChanged("IsValidated");
                }
            }
        }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public TestParameterCollection Parameters { get; set; }

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
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ShowHandlerDialog(TestParameterCollection parameters)
        {
            this.Parameters = parameters;
            this.HeaderMessage = "Set Parameter";
            this.Visibility = Visibility.Visible;
            this.parent.IsEnabled = false;
            this.hideRequest = false;

            this.EditParameters = new TestParameterCollection();
            this.EditParameters.Copy(parameters);

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

                this.AreParameterValid();
            }

            return this.result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The are parameter valid.
        /// </summary>
        private void AreParameterValid()
        {
            this.IsValidated = true;

            foreach (var editParameter in this.EditParameters)
            {
                if (!editParameter.ParameterValueValid)
                {
                    this.IsValidated = false;
                    break;
                }
            }
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
        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.result = false;

            this.HideHandlerDialog();
        }

        // Using a DependencyProperty as the backing store for Message.
        // This enables animation, styling, binding, etc...

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
        /// The ok button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            this.result = true;

            for (var i = 0; i < this.EditParameters.Count; i++)
            {
                this.Parameters[i].Description = this.EditParameters[i].Description;
                this.Parameters[i].ParameterValue = this.EditParameters[i].ParameterValue;
                
            }

            this.HideHandlerDialog();
        }

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property.
        /// </param>
        private void RaisePropertyChanged(string propertyName)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (this.PropertyChanged != null)
            {
                Log.Enter(this, string.Format("{0} {1}", MethodBase.GetCurrentMethod().Name, propertyName));

                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}