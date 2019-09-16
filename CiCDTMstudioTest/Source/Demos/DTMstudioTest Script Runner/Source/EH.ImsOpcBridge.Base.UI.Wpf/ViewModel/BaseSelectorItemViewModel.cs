// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseSelectorItemViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   View model for the base selector control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System.ComponentModel;
    using System.Windows;

    using EH.ImsOpcBridge.UI.Wpf.Interfaces;

    /// <summary>
    /// View model for the base selector control.
    /// </summary>
    public class BaseSelectorItemViewModel : DependencyObject, IBaseSelectorItem
    {
        #region Static Fields

        /// <summary>
        /// The automation id property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(BaseSelectorItemViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The description property.
        /// </summary>
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(BaseSelectorItemViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The execute command property.
        /// </summary>
        public static readonly DependencyProperty ExecuteCommandProperty = DependencyProperty.Register("ExecuteCommand", typeof(DelegateCommand), typeof(BaseSelectorItemViewModel), new PropertyMetadata(default(DelegateCommand)));

        /// <summary>
        /// The image source property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(string), typeof(BaseSelectorItemViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The name property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(BaseSelectorItemViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The selected image source property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty SelectedImageSourceProperty = DependencyProperty.Register("SelectedImageSource", typeof(string), typeof(BaseSelectorItemViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The text property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(BaseSelectorItemViewModel), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSelectorItemViewModel" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="text">The text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="selectedImageSource">The selected image source.</param>
        /// <param name="automationId">The automation id.</param>
        /// <param name="value">The value.</param>
        /// <param name="description">The description.</param>
        /// <param name="executeCommand">The execute command.</param>
        /// <param name="sortOrder">The sort order.</param>
        public BaseSelectorItemViewModel([Localizable(false)] string name, [Localizable(true)] string text, string imageSource, string selectedImageSource, [Localizable(false)] string automationId, object value, string description, DelegateCommand executeCommand, int sortOrder)
        {
            this.Name = name;
            this.Text = text;
            this.ImageSource = imageSource;
            this.SelectedImageSource = selectedImageSource;
            this.AutomationId = automationId;
            this.Value = value;
            this.Description = description;
            this.ExecuteCommand = executeCommand;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSelectorItemViewModel" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="selectedImageSource">The selected image source.</param>
        /// <param name="automationId">The automation id.</param>
        /// <param name="value">The value.</param>
        /// <param name="sortOrder">The sort order.</param>
        public BaseSelectorItemViewModel([Localizable(true)] string text, string imageSource, string selectedImageSource, [Localizable(false)] string automationId, object value, int sortOrder)
        {
            this.Name = text;
            this.Text = text;
            this.ImageSource = imageSource;
            this.SelectedImageSource = selectedImageSource;
            this.AutomationId = automationId;
            this.Value = value;
            this.SortOrder = sortOrder;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets AutomationId.
        /// </summary>
        /// <value>The automation id.</value>
        public string AutomationId
        {
            get
            {
                return (string)this.GetValue(AutomationIdProperty);
            }

            private set
            {
                this.SetValue(AutomationIdProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return (string)this.GetValue(DescriptionProperty);
            }

            set
            {
                this.SetValue(DescriptionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the execute command.
        /// </summary>
        /// <value>The execute command.</value>
        public DelegateCommand ExecuteCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(ExecuteCommandProperty);
            }

            set
            {
                this.SetValue(ExecuteCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets ImageSource.
        /// </summary>
        /// <value>The image source.</value>
        public string ImageSource
        {
            get
            {
                return (string)this.GetValue(ImageSourceProperty);
            }

            private set
            {
                this.SetValue(ImageSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets Name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return (string)this.GetValue(NameProperty);
            }

            private set
            {
                this.SetValue(NameProperty, value);
            }
        }

        /// <summary>
        /// Gets SelectedImageSource.
        /// </summary>
        /// <value>The selected image source.</value>
        public string SelectedImageSource
        {
            get
            {
                return (string)this.GetValue(SelectedImageSourceProperty);
            }

            private set
            {
                this.SetValue(SelectedImageSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets SortOrder.
        /// </summary>
        /// <value>The sort order.</value>
        public int SortOrder { get; private set; }

        /// <summary>
        /// Gets Text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return (string)this.GetValue(TextProperty);
            }

            private set
            {
                this.SetValue(TextProperty, value);
            }
        }

        /// <summary>
        /// Gets Value.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; private set; }

        #endregion
    }
}
