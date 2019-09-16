// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseCommandItemViewModel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   View model for a command item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.ViewModel
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.UI.Wpf.Interfaces;

    /// <summary>
    /// View model for a command item.
    /// </summary>
    public class BaseCommandItemViewModel : DependencyObject, IBaseCommandItem
    {
        #region Static Fields

        /// <summary>
        /// The automation id property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(BaseCommandItemViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The column property
        /// </summary>
        public static readonly DependencyProperty ColumnProperty = DependencyProperty.Register("Column", typeof(int), typeof(BaseCommandItemViewModel), new PropertyMetadata(default(int)));

        /// <summary>
        /// The command parameter property.
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(BaseCommandItemViewModel), new PropertyMetadata(default(object)));

        /// <summary>
        /// The command property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(BaseCommandItemViewModel), new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// The description property.
        /// </summary>
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(BaseCommandItemViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The image source property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(string), typeof(BaseCommandItemViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The row property
        /// </summary>
        public static readonly DependencyProperty RowProperty = DependencyProperty.Register("Row", typeof(int), typeof(BaseCommandItemViewModel), new PropertyMetadata(default(int)));

        /// <summary>
        /// The sort index property.
        /// </summary>
        public static readonly DependencyProperty SortIndexProperty = DependencyProperty.Register("SortIndex", typeof(int), typeof(BaseCommandItemViewModel), new PropertyMetadata(default(int)));

        /// <summary>
        /// The text property.
        /// </summary>
        [Localizable(false)]
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(BaseCommandItemViewModel), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCommandItemViewModel" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="automationId">The automation id.</param>
        /// <param name="command">The command.</param>
        /// <param name="sortIndex">Index of the sort.</param>
        public BaseCommandItemViewModel([Localizable(true)] string text, string imageSource, string automationId, ICommand command, int sortIndex)
        {
            this.Text = text;
            this.ImageSource = imageSource;
            this.AutomationId = automationId;
            this.Command = command;
            this.CommandParameter = null;
            this.SortIndex = sortIndex;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCommandItemViewModel" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="automationId">The automation id.</param>
        /// <param name="command">The command.</param>
        /// <param name="commandParameter">The command parameter.</param>
        /// <param name="sortIndex">Index of the sort.</param>
        public BaseCommandItemViewModel([Localizable(true)] string text, string imageSource, string automationId, ICommand command, object commandParameter, int sortIndex)
        {
            this.Text = text;
            this.ImageSource = imageSource;
            this.AutomationId = automationId;
            this.Command = command;
            this.CommandParameter = commandParameter;
            this.SortIndex = sortIndex;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCommandItemViewModel" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="automationId">The automation id.</param>
        /// <param name="command">The command.</param>
        /// <param name="commandParameter">The command parameter.</param>
        /// <param name="description">The description.</param>
        /// <param name="sortIndex">Index of the sort.</param>
        public BaseCommandItemViewModel([Localizable(true)] string text, [Localizable(false)] string imageSource, string automationId, ICommand command, object commandParameter, [Localizable(true)] string description, int sortIndex)
        {
            this.Text = text;
            this.Description = description;
            this.ImageSource = imageSource;
            this.AutomationId = automationId;
            this.Command = command;
            this.CommandParameter = commandParameter;
            this.SortIndex = sortIndex;
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
        /// Gets or sets Command.
        /// </summary>
        /// <value>The command.</value>
        public ICommand Command
        {
            get
            {
                return (ICommand)this.GetValue(CommandProperty);
            }

            set
            {
                this.SetValue(CommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the command parameter.
        /// </summary>
        /// <value>The command parameter.</value>
        public object CommandParameter
        {
            get
            {
                return (object)this.GetValue(CommandParameterProperty);
            }

            set
            {
                this.SetValue(CommandParameterProperty, value);
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
        /// Gets or sets the sort index.
        /// </summary>
        /// <value>The index of the sort.</value>
        public int SortIndex
        {
            get
            {
                return (int)this.GetValue(SortIndexProperty);
            }

            set
            {
                this.SetValue(SortIndexProperty, value);
            }
        }

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

        #endregion
    }
}
