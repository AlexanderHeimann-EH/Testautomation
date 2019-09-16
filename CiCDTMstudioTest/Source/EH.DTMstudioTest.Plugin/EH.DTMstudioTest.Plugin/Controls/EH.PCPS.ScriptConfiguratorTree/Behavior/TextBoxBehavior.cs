// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextBoxBehavior.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The text box behavior.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.ScriptConfiguratorTree.Behavior
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// The text box behavior.
    /// </summary>
    public class TextBoxBehavior
    {
        #region Static Fields

        /// <summary>
        /// The select all text on focus property.
        /// </summary>
        public static readonly DependencyProperty SelectAllTextOnFocusProperty = DependencyProperty.RegisterAttached("SelectAllTextOnFocus", typeof(bool), typeof(TextBoxBehavior), new UIPropertyMetadata(false, OnSelectAllTextOnFocusChanged));

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get select all text on focus.
        /// </summary>
        /// <param name="textBox">
        /// The text box.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool GetSelectAllTextOnFocus(TextBox textBox)
        {
            return (bool)textBox.GetValue(SelectAllTextOnFocusProperty);
        }

        /// <summary>
        /// The set select all text on focus.
        /// </summary>
        /// <param name="textBox">
        /// The text box.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public static void SetSelectAllTextOnFocus(TextBox textBox, bool value)
        {
            textBox.SetValue(SelectAllTextOnFocusProperty, value);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The ignore mouse button.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void IgnoreMouseButton(object sender, MouseButtonEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null || textBox.IsKeyboardFocusWithin)
            {
                return;
            }

            e.Handled = true;
            textBox.Focus();
        }

        /// <summary>
        /// The on select all text on focus changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnSelectAllTextOnFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;
            if (textBox == null)
            {
                return;
            }

            if (e.NewValue is bool == false)
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                textBox.GotFocus += SelectAll;
                textBox.PreviewMouseDown += IgnoreMouseButton;
            }
            else
            {
                textBox.GotFocus -= SelectAll;
                textBox.PreviewMouseDown -= IgnoreMouseButton;
            }
        }

        /// <summary>
        /// The select all.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void SelectAll(object sender, RoutedEventArgs e)
        {
            var textBox = e.OriginalSource as TextBox;
            if (textBox == null)
            {
                return;
            }

            textBox.SelectAll();
        }

        #endregion
    }
}