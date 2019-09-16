// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextBoxesControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class TextBoxesControl
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class TextBoxesControl
    /// </summary>
    public partial class TextBoxesControl : UserControl
    {
        #region Static Fields

        /// <summary>
        /// The caption property
        /// </summary>
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(TextBoxesControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The extend button visible property
        /// </summary>
        public static readonly DependencyProperty ExtendButtonVisibleProperty = DependencyProperty.Register("ExtendButtonVisible", typeof(bool), typeof(TextBoxesControl), new PropertyMetadata(true));

        /// <summary>
        /// The text box1 changed property
        /// </summary>
        public static readonly DependencyProperty TextBox1ChangedProperty = DependencyProperty.Register("TextBox1Changed", typeof(ICommand), typeof(TextBoxesControl), new PropertyMetadata(null));

        /// <summary>
        /// The text box2 changed property
        /// </summary>
        public static readonly DependencyProperty TextBox2ChangedProperty = DependencyProperty.Register("TextBox2Changed", typeof(ICommand), typeof(TextBoxesControl), new PropertyMetadata(null));

        /// <summary>
        /// The text box label1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabel1Property = DependencyProperty.Register("TextBoxLabel1", typeof(string), typeof(TextBoxesControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The text box label2 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabel2Property = DependencyProperty.Register("TextBoxLabel2", typeof(string), typeof(TextBoxesControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The text box value1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxValue1Property = DependencyProperty.Register("TextBoxValue1", typeof(object), typeof(TextBoxesControl), new PropertyMetadata(null));

        /// <summary>
        /// The text box value2 property
        /// </summary>
        public static readonly DependencyProperty TextBoxValue2Property = DependencyProperty.Register("TextBoxValue2", typeof(object), typeof(TextBoxesControl), new PropertyMetadata(null));

        /// <summary>
        /// The text box visible property
        /// </summary>
        public static readonly DependencyProperty TextBoxVisibleProperty = DependencyProperty.Register("TextBoxVisible", typeof(bool), typeof(TextBoxesControl), new PropertyMetadata(true));

        #endregion

        #region Fields

        /// <summary>
        /// The set text box1 value
        /// </summary>
        private readonly DelegateCommand setTextBox1Value;

        /// <summary>
        /// The set text box2 value
        /// </summary>
        private readonly DelegateCommand setTextBox2Value;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxesControl"/> class.
        /// </summary>
        public TextBoxesControl()
        {
            this.setTextBox1Value = new DelegateCommand(this.OnSetTextBox1Value);
            this.setTextBox2Value = new DelegateCommand(this.OnSetTextBox2Value);

            this.TextBoxVisible = false;

            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption
        {
            get
            {
                return (string)this.GetValue(CaptionProperty);
            }

            set
            {
                this.SetValue(CaptionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [extend button visible].
        /// </summary>
        /// <value><c>true</c> if [extend button visible]; otherwise, <c>false</c>.</value>
        public bool ExtendButtonVisible
        {
            get
            {
                return (bool)this.GetValue(ExtendButtonVisibleProperty);
            }

            set
            {
                this.SetValue(ExtendButtonVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [text box visible].
        /// </summary>
        /// <value><c>true</c> if [text box visible]; otherwise, <c>false</c>.</value>
        public bool TextBoxVisible
        {
            get
            {
                return (bool)this.GetValue(TextBoxVisibleProperty);
            }

            set
            {
                this.SetValue(TextBoxVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box1 changed.
        /// </summary>
        /// <value>The text box1 changed.</value>
        public ICommand TextBox1Changed
        {
            get
            {
                return (ICommand)this.GetValue(TextBox1ChangedProperty);
            }

            set
            {
                this.SetValue(TextBox1ChangedProperty, value);
            }
        }

        /// <summary>
        /// Gets the text box1 value changed.
        /// </summary>
        /// <value>The text box1 value changed.</value>
        public ICommand TextBox1ValueChanged
        {
            get
            {
                return this.setTextBox1Value;
            }
        }

        /// <summary>
        /// Gets or sets the text box2 changed.
        /// </summary>
        /// <value>The text box2 changed.</value>
        public ICommand TextBox2Changed
        {
            get
            {
                return (ICommand)this.GetValue(TextBox2ChangedProperty);
            }

            set
            {
                this.SetValue(TextBox2ChangedProperty, value);
            }
        }

        /// <summary>
        /// Gets the text box2 value changed.
        /// </summary>
        /// <value>The text box2 value changed.</value>
        public ICommand TextBox2ValueChanged
        {
            get
            {
                return this.setTextBox2Value;
            }
        }

        /// <summary>
        /// Gets or sets the text box label1.
        /// </summary>
        /// <value>The text box label1.</value>
        public string TextBoxLabel1
        {
            get
            {
                return (string)this.GetValue(TextBoxLabel1Property);
            }

            set
            {
                this.SetValue(TextBoxLabel1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box label2.
        /// </summary>
        /// <value>The text box label2.</value>
        public string TextBoxLabel2
        {
            get
            {
                return (string)this.GetValue(TextBoxLabel2Property);
            }

            set
            {
                this.SetValue(TextBoxLabel2Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box value1.
        /// </summary>
        /// <value>The text box value1.</value>
        public object TextBoxValue1
        {
            get
            {
                return (object)this.GetValue(TextBoxValue1Property);
            }

            set
            {
                this.SetValue(TextBoxValue1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box value2.
        /// </summary>
        /// <value>The text box value2.</value>
        public object TextBoxValue2
        {
            get
            {
                return (object)this.GetValue(TextBoxValue2Property);
            }

            set
            {
                this.SetValue(TextBoxValue2Property, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when [set text box1 value].
        /// </summary>
        public void OnSetTextBox1Value()
        {
            var textBox1Changed = this.TextBox1Changed;

            if (textBox1Changed != null)
            {
                textBox1Changed.Execute(null);
            }
        }

        /// <summary>
        /// Called when [set text box2 value].
        /// </summary>
        public void OnSetTextBox2Value()
        {
            var textBox2Changed = this.TextBox2Changed;

            if (textBox2Changed != null)
            {
                textBox2Changed.Execute(null);
            }
        }

        #endregion
    }
}
