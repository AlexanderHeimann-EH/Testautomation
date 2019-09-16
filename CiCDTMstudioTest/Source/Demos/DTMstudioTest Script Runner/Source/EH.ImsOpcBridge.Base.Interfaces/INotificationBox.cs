// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotificationBox.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System.Windows.Controls.Primitives;

    /// <summary>
    /// Interface for the Notification Box
    /// </summary>
    public interface INotificationBox
    {
        /// <summary>
        /// Shows the notification.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="popupAnimation">The popup animation.</param>
        /// <param name="timeout">The timeout.</param>
        void ShowNotification(string text, PopupAnimation popupAnimation, int timeout);
    }
}
