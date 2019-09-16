// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaskedTextBoxBehavior.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.View
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Class MaskedTextBoxBehavior
    /// </summary>
    public class MaskedTextBoxBehavior : TextBox
    {
        #region Fields

        /// <summary>
        /// The ignore space
        /// </summary>
        private bool ignoreSpace = true;

        /// <summary>
        /// The insert is on
        /// </summary>
        private bool insertIsOn = false;

        /// <summary>
        /// The masked provider
        /// </summary>
        private MaskedTextProvider maskedProvider = null;

        /// <summary>
        /// The new text is ok
        /// </summary>
        private bool newTextIsOk = false;

        /// <summary>
        /// The previous insert state
        /// </summary>
        private bool previousInsertState = false;

        /// <summary>
        /// The stay in focus until valid
        /// </summary>
        private bool stayInFocusUntilValid = true;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [ignore space].
        /// </summary>
        /// <value><c>true</c> if [ignore space]; otherwise, <c>false</c>.</value>
        public bool IgnoreSpace
        {
            get
            {
                return this.ignoreSpace;
            }

            set
            {
                this.ignoreSpace = value;
            }
        }

        /// <summary>
        /// Gets or sets the mask.
        /// </summary>
        /// <value>The mask.</value>
        public string Mask
        {
            get
            {
                if (this.maskedProvider != null)
                {
                    return this.maskedProvider.Mask;
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                this.maskedProvider = new MaskedTextProvider(value, CultureInfo.InvariantCulture);
                
                // this.Text = this.maskedProvider.ToDisplayString();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [new text is ok].
        /// </summary>
        /// <value><c>true</c> if [new text is ok]; otherwise, <c>false</c>.</value>
        public bool NewTextIsOk
        {
            get
            {
                return this.newTextIsOk;
            }

            set
            {
                this.newTextIsOk = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [stay in focus until valid].
        /// </summary>
        /// <value><c>true</c> if [stay in focus until valid]; otherwise, <c>false</c>.</value>
        public bool StayInFocusUntilValid
        {
            get
            {
                return this.stayInFocusUntilValid;
            }

            set
            {
                this.stayInFocusUntilValid = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Determines whether the address is IP V4.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the address is IP V4; otherwise, <c>false</c>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pv", Justification = @"OK here.")]
        public static bool IsIPv4(string value)
        {
            IPAddress address;

            if (IPAddress.TryParse(value, out address))
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked whenever an unhandled <see cref="E:System.Windows.UIElement.GotFocus" /> event reaches this element in its route.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.RoutedEventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            if (!this.insertIsOn)
            {
                PressKey(Key.Insert);
                this.insertIsOn = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.UIElement.LostFocus" /> event (using the provided arguments).
        /// </summary>
        /// <param name="e">Provides data about the event.</param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            if (this.previousInsertState != Keyboard.PrimaryDevice.IsKeyToggled(Key.Insert))
            {
                PressKey(Key.Insert);
            }
        }

        /// <summary>
        /// Called when the <see cref="E:System.Windows.UIElement.KeyDown" /> occurs.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(@"e");
            }

            if (this.SelectionLength > 1)
            {
                this.SelectionLength = 0;
                e.Handled = true;
            }

            if (e.Key == Key.Insert || e.Key == Key.Delete || e.Key == Key.Back || (e.Key == Key.Space && this.ignoreSpace))
            {
                e.Handled = true;
            }

            base.OnPreviewKeyDown(e);
        }

        /// <summary>
        /// Invoked when an unhandled <see cref="E:System.Windows.Input.Keyboard.PreviewKeyDown" /> attached event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.KeyboardFocusChangedEventArgs" /> that contains the event data.</param>
        protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(@"e");
            }

            if (this.StayInFocusUntilValid)
            {
                if (this.maskedProvider != null)
                {
                    this.maskedProvider.Clear();
                    this.maskedProvider.Add(this.Text);
                    if (!this.maskedProvider.MaskFull)
                    {
                        e.Handled = true;
                    }
                }
            }

            base.OnPreviewLostKeyboardFocus(e);
        }

        /// <summary>
        /// Invoked when an unhandled <see cref="E:System.Windows.Input.TextCompositionManager.PreviewTextInput" /> attached event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.TextCompositionEventArgs" /> that contains the event data.</param>
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(@"e");
            }

            MaskedTextResultHint hint;

            if (e.Text.Length == 1)
            {
                if (this.maskedProvider != null)
                {
                    if (e.Text[0].ToString(CultureInfo.InvariantCulture) == this.maskedProvider.PromptChar.ToString(CultureInfo.InvariantCulture))
                    {
                        this.newTextIsOk = false;
                    }
                    else
                    {
                        this.newTextIsOk = this.maskedProvider.VerifyChar(e.Text[0], this.CaretIndex, out hint);
                    }
                 }
            }
            else
            {
                int testPosition;
                this.newTextIsOk = this.maskedProvider.VerifyString(e.Text, out testPosition, out hint);
            }

            base.OnPreviewTextInput(e);
        }

        /// <summary>
        /// Invoked whenever an unhandled <see cref="E:System.Windows.Input.TextCompositionManager.TextInput" /> attached routed event reaches an element derived from this class in its route. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">Provides data about the event.</param>
        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(@"e");
            }

            string previousText = this.Text;

            if (this.NewTextIsOk)
            {
                base.OnTextInput(e);

                if (string.IsNullOrEmpty(this.Text))
                {
                    this.Text = previousText;
                    return;
                }

                if (this.maskedProvider != null)
                {
                    if (this.maskedProvider.VerifyString(this.Text) == false)
                    {
                        this.Text = previousText;
                    }

                    while (!this.maskedProvider.IsEditPosition(this.CaretIndex) && this.maskedProvider.Length > this.CaretIndex)
                    {
                        this.CaretIndex++;
                    }

                    this.Text = CheckSetMaxValues(this.Text);
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Checks the set max values.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>System.String. xxx</returns>
        private static string CheckSetMaxValues(string address)
        {
            var sb = new StringBuilder();
            var list = address.Split('.').ToList();
            var count = 0;
            
            foreach (var x in list)
            {
                if (!string.IsNullOrEmpty(x))
                {
                    int i = Convert.ToInt32(x.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                    count++;

                    if (i > 255)
                    {
                        i = 255;
                    }

                    sb.Append(i.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0'));
                    
                    if (count != list.Count())
                    {
                         sb.Append('.');
                    }                  
                }    
            }

            return sb.ToString();
        }

        /// <summary>
        /// Presses the key.
        /// </summary>
        /// <param name="key">The key.</param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private static void PressKey(Key key)
        {
            if (Keyboard.PrimaryDevice.ActiveSource != null)
            {
                var eventInsertBack = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key);
                eventInsertBack.RoutedEvent = KeyDownEvent;
                InputManager.Current.ProcessInput(eventInsertBack);
            }
        }

        #endregion
    }
}
