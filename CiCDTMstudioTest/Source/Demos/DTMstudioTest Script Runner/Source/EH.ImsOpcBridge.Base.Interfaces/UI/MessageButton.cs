// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageButton.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Message box button enumeration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI
{
    /// <summary>
    /// Message box button enumeration.
    /// </summary>
    public enum MessageButton
    {
        /// <summary>
        /// OK button
        /// </summary>
        ButtonsOk, 

        /// <summary>
        /// OK and Cancel button.
        /// </summary>
        ButtonsOkCancel, 

        /// <summary>
        /// Retry and cancel button.
        /// </summary>
        ButtonsRetryCancel, 

        /// <summary>
        /// Abort, Retry and Ignore button
        /// </summary>
        ButtonsAbortRetryIgnore, 

        /// <summary>
        /// Yes and No button.
        /// </summary>
        ButtonsYesNo, 

        /// <summary>
        /// Ye, No and Cancel button.
        /// </summary>
        ButtonsYesNoCancel
    }
}
