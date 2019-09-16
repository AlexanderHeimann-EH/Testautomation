// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextBoxBehavior.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class TextBoxBehavior
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.EventArguments
{
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;

    /// <summary>
    /// Class TextBoxBehavior
    /// </summary>
    public static class TextBoxBehavior
    {
        #region Static Fields

        /// <summary>
        /// The lost focus command
        /// </summary>
        public static readonly DependencyProperty LostFocusCommand = EventBehaviorFactory.CreateCommandExecutionEventBehavior(UIElement.LostFocusEvent, "LostFocusCommand", typeof(TextBoxBehavior));

        /// <summary>
        /// The text changed command
        /// </summary>
        public static readonly DependencyProperty TextChangedCommand = EventBehaviorFactory.CreateCommandExecutionEventBehavior(TextBoxBase.TextChangedEvent, "TextChangedCommand", typeof(TextBoxBehavior));

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the lost focus command.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>ICommand xxx</returns>
        public static ICommand GetLostFocusCommand(DependencyObject dependencyObject)
        {
            if (dependencyObject != null)
            {
                return dependencyObject.GetValue(LostFocusCommand) as ICommand;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the text changed command.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>ICommand xxx</returns>
        public static ICommand GetTextChangedCommand(DependencyObject dependencyObject)
        {
            if (dependencyObject != null)
            {
                return dependencyObject.GetValue(TextChangedCommand) as ICommand;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the lost focus command.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="value">The value.</param>
        public static void SetLostFocusCommand(DependencyObject dependencyObject, ICommand value)
        {
            if (dependencyObject != null)
            {
                dependencyObject.SetValue(LostFocusCommand, value);
            }
        }

        /// <summary>
        /// Sets the text changed command.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="value">The value.</param>
        public static void SetTextChangedCommand(DependencyObject dependencyObject, ICommand value)
        {
            if (dependencyObject != null)
            {
                dependencyObject.SetValue(TextChangedCommand, value);
            }
        }

        #endregion
    }
}
