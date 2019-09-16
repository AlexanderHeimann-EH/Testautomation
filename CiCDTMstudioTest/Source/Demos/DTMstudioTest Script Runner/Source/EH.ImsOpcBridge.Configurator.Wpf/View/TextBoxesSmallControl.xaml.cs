// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextBoxesSmallControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class TextBoxesSmallControl
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;

    using EH.ImsOpcBridge.Configurator.Rules;
    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class TextBoxesSmallControl
    /// </summary>
    public partial class TextBoxesSmallControl : UserControl
    {
        #region Static Fields

        /// <summary>
        /// The int range rule max value text box1 property
        /// </summary>
        public static readonly DependencyProperty IntRangeRuleMaxValueTextBox1Property = DependencyProperty.Register("IntRangeRuleMaxValueTextBox1", typeof(int), typeof(TextBoxesSmallControl), new PropertyMetadata(default(int), ValidationRuleTextBox1Changed));

        /// <summary>
        /// The int range rule max value text box2 property
        /// </summary>
        public static readonly DependencyProperty IntRangeRuleMaxValueTextBox2Property = DependencyProperty.Register("IntRangeRuleMaxValueTextBox2", typeof(int), typeof(TextBoxesSmallControl), new PropertyMetadata(default(int), ValidationRuleTextBox2Changed));

        /// <summary>
        /// The int range rule min value text box1 property
        /// </summary>
        public static readonly DependencyProperty IntRangeRuleMinValueTextBox1Property = DependencyProperty.Register("IntRangeRuleMinValueTextBox1", typeof(int), typeof(TextBoxesSmallControl), new PropertyMetadata(default(int), ValidationRuleTextBox1Changed));

        /// <summary>
        /// The int range rule min value text box2 property
        /// </summary>
        public static readonly DependencyProperty IntRangeRuleMinValueTextBox2Property = DependencyProperty.Register("IntRangeRuleMinValueTextBox2", typeof(int), typeof(TextBoxesSmallControl), new PropertyMetadata(default(int), ValidationRuleTextBox2Changed));

        /// <summary>
        /// The is read only text box1 property
        /// </summary>
        public static readonly DependencyProperty IsReadOnlyTextBox1Property = DependencyProperty.Register("IsReadOnlyTextBox1", typeof(bool), typeof(TextBoxesSmallControl), new PropertyMetadata(false));

        /// <summary>
        /// The is read only text box2 property
        /// </summary>
        public static readonly DependencyProperty IsReadOnlyTextBox2Property = DependencyProperty.Register("IsReadOnlyTextBox2", typeof(bool), typeof(TextBoxesSmallControl), new PropertyMetadata(false));

        /// <summary>
        /// The is text box1 visible property
        /// </summary>
        public static readonly DependencyProperty IsTextBox1VisibleProperty = DependencyProperty.Register("IsTextBox1Visible", typeof(Visibility), typeof(TextBoxesSmallControl), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The is text box2 visible property
        /// </summary>
        public static readonly DependencyProperty IsTextBox2VisibleProperty = DependencyProperty.Register("IsTextBox2Visible", typeof(Visibility), typeof(TextBoxesSmallControl), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The text box1 changed property
        /// </summary>
        public static readonly DependencyProperty TextBox1ChangedProperty = DependencyProperty.Register("TextBox1Changed", typeof(ICommand), typeof(TextBoxesSmallControl), new PropertyMetadata(null));

        /// <summary>
        /// The text box2 changed property
        /// </summary>
        public static readonly DependencyProperty TextBox2ChangedProperty = DependencyProperty.Register("TextBox2Changed", typeof(ICommand), typeof(TextBoxesSmallControl), new PropertyMetadata(null));

        /// <summary>
        /// The text box label1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabel1Property = DependencyProperty.Register("TextBoxLabel1", typeof(string), typeof(TextBoxesSmallControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The text box label2 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabel2Property = DependencyProperty.Register("TextBoxLabel2", typeof(string), typeof(TextBoxesSmallControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The text box label unit1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelUnit1Property = DependencyProperty.Register("TextBoxLabelUnit1", typeof(string), typeof(TextBoxesSmallControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The text box label unit2 property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelUnit2Property = DependencyProperty.Register("TextBoxLabelUnit2", typeof(string), typeof(TextBoxesSmallControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The text box value1 property
        /// </summary>
        public static readonly DependencyProperty TextBoxValue1Property = DependencyProperty.Register("TextBoxValue1", typeof(object), typeof(TextBoxesSmallControl), new PropertyMetadata(null));

        /// <summary>
        /// The text box value2 property
        /// </summary>
        public static readonly DependencyProperty TextBoxValue2Property = DependencyProperty.Register("TextBoxValue2", typeof(object), typeof(TextBoxesSmallControl), new PropertyMetadata(null));

        /// <summary>
        /// The validation error property
        /// </summary>
        public static readonly DependencyProperty ValidationErrorProperty = DependencyProperty.Register("ValidationError", typeof(string), typeof(TextBoxesSmallControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The validation rule text box1 property
        /// </summary>
        public static readonly DependencyProperty ValidationRuleTextBox1Property = DependencyProperty.Register("ValidationRuleTextBox1", typeof(string), typeof(TextBoxesSmallControl), new PropertyMetadata(string.Empty, ValidationRuleTextBox1Changed));

        /// <summary>
        /// The validation rule text box2 property
        /// </summary>
        public static readonly DependencyProperty ValidationRuleTextBox2Property = DependencyProperty.Register("ValidationRuleTextBox2", typeof(string), typeof(TextBoxesSmallControl), new PropertyMetadata(string.Empty, ValidationRuleTextBox2Changed));

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
        /// Initializes a new instance of the <see cref="TextBoxesSmallControl"/> class.
        /// </summary>
        public TextBoxesSmallControl()
        {
            this.setTextBox1Value = new DelegateCommand(this.OnSetTextBox1Value);
            this.setTextBox2Value = new DelegateCommand(this.OnSetTextBox2Value);

            this.InitializeComponent();

            this.ClearValidationRules();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the int range rule max value text box1.
        /// </summary>
        /// <value>The int range rule max value text box1.</value>
        public int IntRangeRuleMaxValueTextBox1
        {
            get
            {
                return (int)this.GetValue(IntRangeRuleMaxValueTextBox1Property);
            }

            set
            {
                this.SetValue(IntRangeRuleMaxValueTextBox1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the int range rule max value text box2.
        /// </summary>
        /// <value>The int range rule max value text box2.</value>
        public int IntRangeRuleMaxValueTextBox2
        {
            get
            {
                return (int)this.GetValue(IntRangeRuleMaxValueTextBox2Property);
            }

            set
            {
                this.SetValue(IntRangeRuleMaxValueTextBox2Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the int range rule min value text box1.
        /// </summary>
        /// <value>The int range rule min value text box1.</value>
        public int IntRangeRuleMinValueTextBox1
        {
            get
            {
                return (int)this.GetValue(IntRangeRuleMinValueTextBox1Property);
            }

            set
            {
                this.SetValue(IntRangeRuleMinValueTextBox1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the int range rule min value text box2.
        /// </summary>
        /// <value>The int range rule min value text box2.</value>
        public int IntRangeRuleMinValueTextBox2
        {
            get
            {
                return (int)this.GetValue(IntRangeRuleMinValueTextBox2Property);
            }

            set
            {
                this.SetValue(IntRangeRuleMinValueTextBox2Property, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is read only text box1.
        /// </summary>
        /// <value><c>true</c> if this instance is read only text box1; otherwise, <c>false</c>.</value>
        public bool IsReadOnlyTextBox1
        {
            get
            {
                return (bool)this.GetValue(IsReadOnlyTextBox1Property);
            }

            set
            {
                this.SetValue(IsReadOnlyTextBox1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is read only text box2.
        /// </summary>
        /// <value><c>true</c> if this instance is read only text box2; otherwise, <c>false</c>.</value>
        public bool IsReadOnlyTextBox2
        {
            get
            {
                return (bool)this.GetValue(IsReadOnlyTextBox2Property);
            }

            set
            {
                this.SetValue(IsReadOnlyTextBox2Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the is text box1 visible.
        /// </summary>
        /// <value>The is text box1 visible.</value>
        public Visibility IsTextBox1Visible
        {
            get
            {
                return (Visibility)this.GetValue(IsTextBox1VisibleProperty);
            }

            set
            {
                this.SetValue(IsTextBox1VisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the is text box2 visible.
        /// </summary>
        /// <value>The is text box2 visible.</value>
        public Visibility IsTextBox2Visible
        {
            get
            {
                return (Visibility)this.GetValue(IsTextBox2VisibleProperty);
            }

            set
            {
                this.SetValue(IsTextBox2VisibleProperty, value);
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
        /// Gets or sets the text box label unit1.
        /// </summary>
        /// <value>The text box label unit1.</value>
        public string TextBoxLabelUnit1
        {
            get
            {
                return (string)this.GetValue(TextBoxLabelUnit1Property);
            }

            set
            {
                this.SetValue(TextBoxLabelUnit1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box label unit2.
        /// </summary>
        /// <value>The text box label unit2.</value>
        public string TextBoxLabelUnit2
        {
            get
            {
                return (string)this.GetValue(TextBoxLabelUnit2Property);
            }

            set
            {
                this.SetValue(TextBoxLabelUnit2Property, value);
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

        /// <summary>
        /// Gets or sets the validation error.
        /// </summary>
        /// <value>The validation error.</value>
        public string ValidationError
        {
            get
            {
                return (string)this.GetValue(ValidationErrorProperty);
            }

            set
            {
                this.SetValue(ValidationErrorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the validation rule text box1.
        /// </summary>
        /// <value>The validation rule text box1.</value>
        public string ValidationRuleTextBox1
        {
            get
            {
                return (string)this.GetValue(ValidationRuleTextBox1Property);
            }

            set
            {
                this.SetValue(ValidationRuleTextBox1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the validation rule text box2.
        /// </summary>
        /// <value>The validation rule text box2.</value>
        public string ValidationRuleTextBox2
        {
            get
            {
                return (string)this.GetValue(ValidationRuleTextBox2Property);
            }

            set
            {
                this.SetValue(ValidationRuleTextBox2Property, value);
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

        /// <summary>
        /// Windows the loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        public void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // we manually fire the bindings so we get the validation initially
            var textBoxesSmallControl = sender as TextBoxesSmallControl;

            if (textBoxesSmallControl != null)
            {
                var bindingExpression = textBoxesSmallControl.TextBox1.GetBindingExpression(TextBox.TextProperty);

                if (bindingExpression != null)
                {
                    bindingExpression.UpdateSource();
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Texts the box value1 changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void TextBoxValue1Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textBoxesSmallControl = sender as TextBoxesSmallControl;

            if (textBoxesSmallControl != null)
            {
                var bindingExpression = textBoxesSmallControl.TextBox1.GetBindingExpression(TextBox.TextProperty);

                if (bindingExpression != null)
                {
                    bindingExpression.UpdateSource();
                }
            }
        }

        /// <summary>
        /// Validations the rule text box1 changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void ValidationRuleTextBox1Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textBoxesSmallControl = sender as TextBoxesSmallControl;
            if (textBoxesSmallControl != null)
            {
                Binding binding = BindingOperations.GetBinding(textBoxesSmallControl.TextBox1, TextBox.TextProperty);

                if (binding == null)
                {
                    return;
                }

                binding.ValidationRules.Clear();

                // In case multiple rules are bound then it would come like "Required|Numeric
                var validationRules = textBoxesSmallControl.ValidationRuleTextBox1.Split(new[] { "|", }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var rule in validationRules)
                {
                    textBoxesSmallControl.RegisterRule(rule, textBoxesSmallControl.TextBox1, textBoxesSmallControl.IntRangeRuleMinValueTextBox1, textBoxesSmallControl.IntRangeRuleMaxValueTextBox1);
                }
            }
        }

        /// <summary>
        /// Validations the rule text box2 changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void ValidationRuleTextBox2Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textBoxesSmallControl = sender as TextBoxesSmallControl;
            if (textBoxesSmallControl != null)
            {
                Binding binding = BindingOperations.GetBinding(textBoxesSmallControl.TextBox2, TextBox.TextProperty);

                if (binding == null)
                {
                    return;
                }

                binding.ValidationRules.Clear();

                // In case multiple rules are bound then it would come like "Required|Numeric
                var validationRules = textBoxesSmallControl.ValidationRuleTextBox2.Split(new[] { "|", }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var rule in validationRules)
                {
                    textBoxesSmallControl.RegisterRule(rule, textBoxesSmallControl.TextBox2, textBoxesSmallControl.IntRangeRuleMinValueTextBox2, textBoxesSmallControl.IntRangeRuleMaxValueTextBox2);
                }
            }
        }

        /// <summary>
        /// Clears the validation rules.
        /// </summary>
        private void ClearValidationRules()
        {
            Binding binding = BindingOperations.GetBinding(this.TextBox1, TextBox.TextProperty);

            if (binding != null)
            {
                binding.ValidationRules.Clear();
            }

            binding = BindingOperations.GetBinding(this.TextBox2, TextBox.TextProperty);

            if (binding != null)
            {
                binding.ValidationRules.Clear();
            }
        }

        /// <summary>
        /// Registers the rule.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="textBox">The text box.</param>
        /// <param name="intRangeMin">The int range min.</param>
        /// <param name="intRangeMax">The int range max.</param>
        private void RegisterRule(string ruleName, TextBox textBox, int intRangeMin, int intRangeMax)
        {
            Binding binding = BindingOperations.GetBinding(textBox, TextBox.TextProperty);

            if (binding == null)
            {
                return;
            }

            switch (ruleName)
            {
                case "ByteArrayRule":
                    {
                        var rule = new ByteArrayRule();
                        binding.ValidationRules.Add(rule);
                        break;
                    }

                case "IntRangeRule":
                    {
                        var rule = new IntRangeRule();
                        rule.Min = intRangeMin;
                        rule.Max = intRangeMax;
                        binding.ValidationRules.Add(rule);
                        break;
                    }

                case "IpAddressRule":
                    {
                        var rule = new IpAddressRule();
                        binding.ValidationRules.Add(rule);
                        break;
                    }

                case "NotNullOrEmptyRule":
                    {
                        var rule = new NotNullOrEmptyRule();
                        binding.ValidationRules.Add(rule);
                        break;
                    }

                case "OpcItemIdRule":
                    {
                        var rule = new OpcItemIdRule();
                        binding.ValidationRules.Add(rule);
                        break;
                    }

                case "EhSerialNumberRule":
                    {
                        var rule = new EhSerialNumberRule();
                        binding.ValidationRules.Add(rule);
                        break;
                    }                    
            }
        }

        /// <summary>
        /// Texts the box error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ValidationErrorEventArgs"/> instance containing the event data.</param>
        private void TextBoxError(object sender, ValidationErrorEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox != null)
            {
                if (Validation.GetHasError(textBox))
                {
                    ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
                    this.ValidationError = e.Error.ErrorContent.ToString();
                }
                else
                {
                    ((Control)sender).ToolTip = string.Empty;
                    this.ValidationError = string.Empty;
                }
            }

            ////if (e.Action == ValidationErrorEventAction.Added)
            ////{
            ////    ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            ////    this.ValidationError = e.Error.ErrorContent.ToString();
            ////}
            ////else
            ////{
            ////    ((Control)sender).ToolTip = string.Empty;
            ////    this.ValidationError = string.Empty;
            ////}
        }

        #endregion
    }
}