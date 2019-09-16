// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectionChangedBehavior.cs" company="Endress+Hauser Process Solutions AG">
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
    /// Class SelectionChangedBehavior
    /// </summary>
    public static class SelectionChangedBehavior
    {
        #region Static Fields

        /// <summary>
        /// The selection changed command
        /// </summary>
        public static readonly DependencyProperty SelectionChangedCommand = EventBehaviorFactory.CreateCommandExecutionEventBehavior(Selector.SelectionChangedEvent, "SelectionChangedCommand", typeof(SelectionChangedBehavior));

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the selection changed command.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns> ICommand. xxx </returns>
        public static ICommand GetSelectionChangedCommand(DependencyObject dependencyObject)
        {
            if (dependencyObject != null)
            {
                return dependencyObject.GetValue(SelectionChangedCommand) as ICommand;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the selection changed command.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="value">The value. xxx </param>
        public static void SetSelectionChangedCommand(DependencyObject dependencyObject, ICommand value)
        {
            if (dependencyObject != null)
            {
                dependencyObject.SetValue(SelectionChangedCommand, value);
            }
        }

        #endregion
    }
}
