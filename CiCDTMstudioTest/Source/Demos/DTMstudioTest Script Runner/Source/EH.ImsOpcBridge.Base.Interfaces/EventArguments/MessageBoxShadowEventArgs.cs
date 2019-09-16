// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxShadowEventArgs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The event arguments for the message box shadow event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.EventArguments
{
    using System;

    /// <summary>
    /// The event arguments for the message box shadow event.
    /// </summary>
    public class MessageBoxShadowEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxShadowEventArgs"/> class.
        /// </summary>
        /// <param name="showShadow">if set to <c>true</c> [show shadow].</param>
        public MessageBoxShadowEventArgs(bool showShadow)
        {
            this.ShowShadow = showShadow;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether [show shadow].
        /// </summary>
        /// <value><c>true</c> if [show shadow]; otherwise, <c>false</c> .</value>
        public bool ShowShadow { get; private set; }

        #endregion
    }
}
