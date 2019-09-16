// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandVm.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   View model for a command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.ViewModel
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// View model for a command.
    /// </summary>
    public class CommandVm : DependencyObject
    {
        #region Constants and Fields

        /// <summary>
        /// The automation id property.
        /// </summary>
        public static readonly DependencyProperty AutomationIdProperty = DependencyProperty.Register("AutomationId", typeof(string), typeof(CommandControlVm), new PropertyMetadata(default(string)));

        /// <summary>
        /// The command property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandControlVm), new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// The is checked property.
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(CommandVm), new PropertyMetadata(default(bool)));

        /// <summary>
        /// The text property.
        /// </summary>
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CommandControlVm), new PropertyMetadata(default(string)));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandVm"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="automationId">The automation id.</param>
        /// <param name="text">The text.</param>
        public CommandVm(ICommand command, string automationId, [Localizable(true)] string text)
        {
            this.Command = command;
            this.AutomationId = automationId;
            this.Text = text;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets AutomationId.
        /// </summary>
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
        /// Gets Command.
        /// </summary>
        public ICommand Command
        {
            get
            {
                return (ICommand)this.GetValue(CommandProperty);
            }

            private set
            {
                this.SetValue(CommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsChecked.
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

        /// <summary>
        /// Gets Text.
        /// </summary>
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
