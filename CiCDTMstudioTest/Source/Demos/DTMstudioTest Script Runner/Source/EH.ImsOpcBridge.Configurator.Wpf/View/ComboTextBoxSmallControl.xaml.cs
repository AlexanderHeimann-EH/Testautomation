// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComboTextBoxSmallControl.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ComboTextBoxSmallControl
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.View
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using EH.ImsOpcBridge.UI.Wpf;

    /// <summary>
    /// Class ComboTextBoxSmallControl
    /// </summary>
    public partial class ComboTextBoxSmallControl : UserControl
    {
        #region Static Fields

        /// <summary>
        /// The button pressed command property
        /// </summary>
        public static readonly DependencyProperty ButtonPressedCommandProperty = DependencyProperty.Register("ButtonPressedCommand", typeof(ICommand), typeof(ComboTextBoxSmallControl), new PropertyMetadata(null));

        /// <summary>
        /// The combo box active item property
        /// </summary>
        public static readonly DependencyProperty ComboBoxActiveItemProperty = DependencyProperty.Register("ComboBoxActiveItem", typeof(string), typeof(ComboTextBoxSmallControl), new PropertyMetadata(default(string)));

        /// <summary>
        /// The combo box items source property
        /// </summary>
        public static readonly DependencyProperty ComboBoxItemsSourceProperty = DependencyProperty.Register("ComboBoxItemsSource", typeof(ObservableCollection<string>), typeof(ComboTextBoxSmallControl), new PropertyMetadata(default(ObservableCollection<string>)));

        /// <summary>
        /// The combo box label property
        /// </summary>
        public static readonly DependencyProperty ComboBoxLabelProperty = DependencyProperty.Register("ComboBoxLabel", typeof(string), typeof(ComboTextBoxSmallControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The combo box label unit property
        /// </summary>
        public static readonly DependencyProperty ComboBoxLabelUnitProperty = DependencyProperty.Register("ComboBoxLabelUnit", typeof(string), typeof(ComboTextBoxSmallControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The combo box selection changed command property
        /// </summary>
        public static readonly DependencyProperty ComboBoxSelectionChangedCommandProperty = DependencyProperty.Register("ComboBoxSelectionChangedCommand", typeof(ICommand), typeof(ComboTextBoxSmallControl), new PropertyMetadata(null));

        /// <summary>
        /// The combo box text is editable property
        /// </summary>
        public static readonly DependencyProperty ComboBoxTextIsEditableProperty = DependencyProperty.Register("ComboBoxTextIsEditable", typeof(bool), typeof(ComboTextBoxSmallControl), new PropertyMetadata(true));

        /// <summary>
        /// The combo text box changed property
        /// </summary>
        public static readonly DependencyProperty ComboTextBoxChangedProperty = DependencyProperty.Register("ComboTextBoxChanged", typeof(ICommand), typeof(ComboTextBoxSmallControl), new PropertyMetadata(null));

        /// <summary>
        /// The combo text box value property
        /// </summary>
        public static readonly DependencyProperty ComboTextBoxValueProperty = DependencyProperty.Register("ComboTextBoxValue", typeof(object), typeof(ComboTextBoxSmallControl), new PropertyMetadata(null));

        /// <summary>
        /// The is text box visible property
        /// </summary>
        public static readonly DependencyProperty IsTextBoxVisibleProperty = DependencyProperty.Register("IsTextBoxVisible", typeof(Visibility), typeof(ComboTextBoxSmallControl), new PropertyMetadata(default(Visibility)));

        /// <summary>
        /// The text box changed property
        /// </summary>
        public static readonly DependencyProperty TextBoxChangedProperty = DependencyProperty.Register("TextBoxChanged", typeof(ICommand), typeof(ComboTextBoxSmallControl), new PropertyMetadata(null));

        /// <summary>
        /// The text box label property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelProperty = DependencyProperty.Register("TextBoxLabel", typeof(string), typeof(ComboTextBoxSmallControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The text box label unit property
        /// </summary>
        public static readonly DependencyProperty TextBoxLabelUnitProperty = DependencyProperty.Register("TextBoxLabelUnit", typeof(string), typeof(ComboTextBoxSmallControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The text box value property
        /// </summary>
        public static readonly DependencyProperty TextBoxValueProperty = DependencyProperty.Register("TextBoxValue", typeof(object), typeof(ComboTextBoxSmallControl), new PropertyMetadata(null));

        #endregion

        #region Fields

        /// <summary>
        /// The set button pressed
        /// </summary>
        private readonly DelegateCommand setButtonPressed;

        /// <summary>
        /// The set combo box selection changed
        /// </summary>
        private readonly DelegateCommand setComboBoxSelectionChanged;

        /// <summary>
        /// The set combo text box value
        /// </summary>
        private readonly DelegateCommand setComboTextBoxValue;

        /// <summary>
        /// The set text box value
        /// </summary>
        private readonly DelegateCommand setTextBoxValue;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboTextBoxSmallControl"/> class.
        /// </summary>
        public ComboTextBoxSmallControl()
        {
            this.setTextBoxValue = new DelegateCommand(this.OnSetTextBoxValue);
            this.setComboTextBoxValue = new DelegateCommand(this.OnSetComboTextBoxValue);
            this.setButtonPressed = new DelegateCommand(this.OnButtonPressed);
            this.setComboBoxSelectionChanged = new DelegateCommand(this.OnComboBoxSelectionChanged);

            this.ComboBoxTextIsEditable = false;
            this.ComboTextBoxValue = @"192.168.001.212";
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the button pressed.
        /// </summary>
        /// <value>The button pressed.</value>
        public ICommand ButtonPressed
        {
            get
            {
                return this.setButtonPressed;
            }
        }

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
        /// Gets or sets the combo box active item.
        /// </summary>
        /// <value>The combo box active item.</value>
        public string ComboBoxActiveItem
        {
            get
            {
                return (string)this.GetValue(ComboBoxActiveItemProperty);
            }

            set
            {
                this.SetValue(ComboBoxActiveItemProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the combo box items source.
        /// </summary>
        /// <value>The combo box items source.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Reviewed. Suppression is OK here.")]
        public ObservableCollection<string> ComboBoxItemsSource
        {
            get
            {
                return (ObservableCollection<string>)this.GetValue(ComboBoxItemsSourceProperty);
            }

            set
            {
                this.SetValue(ComboBoxItemsSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the combo box label.
        /// </summary>
        /// <value>The combo box label.</value>
        public string ComboBoxLabel
        {
            get
            {
                return (string)this.GetValue(ComboBoxLabelProperty);
            }

            set
            {
                this.SetValue(ComboBoxLabelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the combo box label unit.
        /// </summary>
        /// <value>The combo box label unit.</value>
        public string ComboBoxLabelUnit
        {
            get
            {
                return (string)this.GetValue(ComboBoxLabelUnitProperty);
            }

            set
            {
                this.SetValue(ComboBoxLabelUnitProperty, value);
            }
        }

        /// <summary>
        /// Gets the combo box selection changed.
        /// </summary>
        /// <value>The combo box selection changed.</value>
        public ICommand ComboBoxSelectionChanged
        {
            get
            {
                return this.setComboBoxSelectionChanged;
            }
        }

        /// <summary>
        /// Gets or sets the combo box selection changed command.
        /// </summary>
        /// <value>The combo box selection changed command.</value>
        public ICommand ComboBoxSelectionChangedCommand
        {
            get
            {
                return (ICommand)this.GetValue(ComboBoxSelectionChangedCommandProperty);
            }

            set
            {
                this.SetValue(ComboBoxSelectionChangedCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [combo box text is editable].
        /// </summary>
        /// <value><c>true</c> if [combo box text is editable]; otherwise, <c>false</c>.</value>
        public bool ComboBoxTextIsEditable
        {
            get
            {
                return (bool)this.GetValue(ComboBoxTextIsEditableProperty);
            }

            set
            {
                this.SetValue(ComboBoxTextIsEditableProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the combo text box changed.
        /// </summary>
        /// <value>The combo text box changed.</value>
        public ICommand ComboTextBoxChanged
        {
            get
            {
                return (ICommand)this.GetValue(ComboTextBoxChangedProperty);
            }

            set
            {
                this.SetValue(ComboTextBoxChangedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the combo text box value.
        /// </summary>
        /// <value>The combo text box value.</value>
        public object ComboTextBoxValue
        {
            get
            {
                return (object)this.GetValue(ComboTextBoxValueProperty);
            }

            set
            {
                this.SetValue(ComboTextBoxValueProperty, value);
            }
        }

        /// <summary>
        /// Gets the combo text box value changed.
        /// </summary>
        /// <value>The combo text box value changed.</value>
        public ICommand ComboTextBoxValueChanged
        {
            get
            {
                return this.setComboTextBoxValue;
            }
        }

        /// <summary>
        /// Gets or sets the is text box visible.
        /// </summary>
        /// <value>The is text box visible.</value>
        public Visibility IsTextBoxVisible
        {
            get
            {
                return (Visibility)this.GetValue(IsTextBoxVisibleProperty);
            }

            set
            {
                this.SetValue(IsTextBoxVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box changed.
        /// </summary>
        /// <value>The text box changed.</value>
        public ICommand TextBoxChanged
        {
            get
            {
                return (ICommand)this.GetValue(TextBoxChangedProperty);
            }

            set
            {
                this.SetValue(TextBoxChangedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box label.
        /// </summary>
        /// <value>The text box label.</value>
        public string TextBoxLabel
        {
            get
            {
                return (string)this.GetValue(TextBoxLabelProperty);
            }

            set
            {
                this.SetValue(TextBoxLabelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box label unit.
        /// </summary>
        /// <value>The text box label unit.</value>
        public string TextBoxLabelUnit
        {
            get
            {
                return (string)this.GetValue(TextBoxLabelUnitProperty);
            }

            set
            {
                this.SetValue(TextBoxLabelUnitProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box value.
        /// </summary>
        /// <value>The text box value.</value>
        public object TextBoxValue
        {
            get
            {
                return (object)this.GetValue(TextBoxValueProperty);
            }

            set
            {
                this.SetValue(TextBoxValueProperty, value);
            }
        }

        /// <summary>
        /// Gets the text box value changed.
        /// </summary>
        /// <value>The text box value changed.</value>
        public ICommand TextBoxValueChanged
        {
            get
            {
                return this.setTextBoxValue;
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

        /// <summary>
        /// Called when [combo box selection changed].
        /// </summary>
        public void OnComboBoxSelectionChanged()
        {
            var comboBoxSelectionChangedCommand = this.ComboBoxSelectionChangedCommand;

            if (comboBoxSelectionChangedCommand != null)
            {
                comboBoxSelectionChangedCommand.Execute(null);
            }
        }

        /// <summary>
        /// Called when [set combo text box value].
        /// </summary>
        public void OnSetComboTextBoxValue()
        {
            var comboTextBoxChanged = this.ComboTextBoxChanged;

            if (comboTextBoxChanged != null)
            {
                comboTextBoxChanged.Execute(null);
            }
        }

        /// <summary>
        /// Called when [set text box value].
        /// </summary>
        public void OnSetTextBoxValue()
        {
            var textBoxChanged = this.TextBoxChanged;

            if (textBoxChanged != null)
            {
                textBoxChanged.Execute(null);
            }
        }

        #endregion
    }
}