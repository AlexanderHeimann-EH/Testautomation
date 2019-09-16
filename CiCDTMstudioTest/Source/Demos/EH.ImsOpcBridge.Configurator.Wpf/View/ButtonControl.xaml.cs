// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ButtonControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ButtonControl
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Class ButtonControl
    /// </summary>
    public partial class ButtonControl : UserControl
    {
        #region Static Fields

        /// <summary>
        /// The button pressed command property
        /// </summary>
        public static readonly DependencyProperty ButtonPressedCommandProperty = DependencyProperty.Register("ButtonPressedCommand", typeof(ICommand), typeof(ButtonControl), new PropertyMetadata(null));

        /// <summary>
        /// The check box label property
        /// </summary>
        public static readonly DependencyProperty ButtonControlLabelProperty = DependencyProperty.Register("ButtonControlLabel", typeof(string), typeof(ButtonControl), new PropertyMetadata(string.Empty));
        
              /// <summary>
        /// The check box label property
        /// </summary>
        public static readonly DependencyProperty ButtonControlBitmapPathProperty = DependencyProperty.Register("ButtonControlBitmapPath", typeof(string), typeof(ButtonControl), new PropertyMetadata(string.Empty));
        
        /// <summary>
        /// The is checked property
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(ButtonControl), new PropertyMetadata(true));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonControl"/> class.
        /// </summary>
        public ButtonControl()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the button pressed command.
        /// </summary>
        /// <value>The button pressed command.</value>
        public ICommand ButtonPressedCommand
        {
            get
            {
                return (ICommand)this.GetValue(ButtonPressedCommandProperty);
            }

            set
            {
                this.SetValue(ButtonPressedCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the check box label.
        /// </summary>
        /// <value>The check box label.</value>
        public string ButtonControlLabel
        {
            get
            {
                return (string)this.GetValue(ButtonControlLabelProperty);
            }

            set
            {
                this.SetValue(ButtonControlLabelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the button control bitmap path.
        /// </summary>
        /// <value>The button control bitmap path.</value>
        public string ButtonControlBitmapPath
        {
            get
            {
                return (string)this.GetValue(ButtonControlBitmapPathProperty);
            }

            set
            {
                this.SetValue(ButtonControlBitmapPathProperty, value);
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

        #region Public Methods and Operators

        /// <summary>
        /// Called when [button pressed].
        /// </summary>
        public void OnButtonPressed()
        {
            var buttonPressedCommand = this.ButtonPressedCommand;

            if (buttonPressedCommand != null)
            {
                buttonPressedCommand.Execute(null);
            }
        }

        #endregion
    }
}