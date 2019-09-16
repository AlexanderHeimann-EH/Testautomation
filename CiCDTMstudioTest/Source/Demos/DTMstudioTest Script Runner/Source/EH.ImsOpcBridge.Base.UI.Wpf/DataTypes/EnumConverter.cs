// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base.UI.Wpf
// Author           : i02423401
// Created          : 05-29-2013
//
// Last Modified By : i02423401
// Last Modified On : 09-25-2013
// ***********************************************************************
// <copyright file="EnumConverter.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EH.ImsOpcBridge.UI.Wpf.DataTypes
{
    using System;
    using System.Windows;

    /// <summary>
    /// Contains the converters for UI enumerations.
    /// </summary>
    public static class EnumConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts <see cref="DefaultMessageButton" /> to <see cref="MessageBoxResult" />.
        /// </summary>
        /// <param name="defaultResult">The default result.</param>
        /// <returns>The message box result.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// defaultResult
        /// or
        /// defaultResult
        /// or
        /// defaultResult
        /// or
        /// defaultResult
        /// </exception>
        public static MessageBoxResult DefaultMessageButtonToMessageBoxResult(DefaultMessageButton defaultResult)
        {
            MessageBoxResult messageBoxDefaultResult;
            switch (defaultResult)
            {
                case DefaultMessageButton.ButtonAbort:
                    throw new ArgumentOutOfRangeException("defaultResult");
                case DefaultMessageButton.ButtonRetry:
                    throw new ArgumentOutOfRangeException("defaultResult");
                case DefaultMessageButton.ButtonIgnore:
                    throw new ArgumentOutOfRangeException("defaultResult");
                case DefaultMessageButton.ButtonOk:
                    messageBoxDefaultResult = MessageBoxResult.OK;
                    break;
                case DefaultMessageButton.ButtonCancel:
                    messageBoxDefaultResult = MessageBoxResult.Cancel;
                    break;
                case DefaultMessageButton.ButtonYes:
                    messageBoxDefaultResult = MessageBoxResult.Yes;
                    break;
                case DefaultMessageButton.ButtonNo:
                    messageBoxDefaultResult = MessageBoxResult.No;
                    break;
                case DefaultMessageButton.ButtonNone:
                    messageBoxDefaultResult = MessageBoxResult.None;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("defaultResult");
            }

            return messageBoxDefaultResult;
        }

        /// <summary>
        /// Converts <see cref="DefaultMessageButton" /> to <see cref="ResultMessage" />.
        /// </summary>
        /// <param name="defaultResult">The default result.</param>
        /// <returns>The result message.</returns>
        public static ResultMessage DefaultMessageButtonToResultMessage(DefaultMessageButton defaultResult)
        {
            ResultMessage result;
            switch (defaultResult)
            {
                case DefaultMessageButton.ButtonAbort:
                    result = ResultMessage.ButtonAbort;
                    break;
                case DefaultMessageButton.ButtonRetry:
                    result = ResultMessage.ButtonRetry;
                    break;
                case DefaultMessageButton.ButtonIgnore:
                    result = ResultMessage.ButtonIgnore;
                    break;
                case DefaultMessageButton.ButtonOk:
                    result = ResultMessage.ButtonOk;
                    break;
                case DefaultMessageButton.ButtonCancel:
                    result = ResultMessage.ButtonCancel;
                    break;
                case DefaultMessageButton.ButtonYes:
                    result = ResultMessage.ButtonYes;
                    break;
                case DefaultMessageButton.ButtonNo:
                    result = ResultMessage.ButtonNo;
                    break;
                case DefaultMessageButton.ButtonNone:
                    result = ResultMessage.NoButton;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("defaultResult");
            }

            return result;
        }

        /// <summary>
        /// Converts <see cref="MessageBoxResult" /> to <see cref="ResultMessage" />.
        /// </summary>
        /// <param name="messageBoxResult">The message box result.</param>
        /// <returns>The result message enumeration.</returns>
        public static ResultMessage MessageBoxResultToResultMessage(MessageBoxResult messageBoxResult)
        {
            ResultMessage result;
            switch (messageBoxResult)
            {
                case MessageBoxResult.None:
                    result = ResultMessage.NoButton;
                    break;
                case MessageBoxResult.OK:
                    result = ResultMessage.ButtonOk;
                    break;
                case MessageBoxResult.Cancel:
                    result = ResultMessage.ButtonCancel;
                    break;
                case MessageBoxResult.Yes:
                    result = ResultMessage.ButtonYes;
                    break;
                case MessageBoxResult.No:
                    result = ResultMessage.ButtonNo;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("messageBoxResult");
            }

            return result;
        }

        /// <summary>
        /// The message button to default result message.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <returns>The <see cref="ResultMessage" />.</returns>
        public static ResultMessage MessageButtonToDefaultResultMessage(MessageButton button)
        {
            switch (button)
            {
                case MessageButton.ButtonsOk:
                    return ResultMessage.ButtonOk;
                case MessageButton.ButtonsOkCancel:
                    return ResultMessage.ButtonOk;
                case MessageButton.ButtonsRetryCancel:
                    return ResultMessage.ButtonCancel;
                case MessageButton.ButtonsAbortRetryIgnore:
                    return ResultMessage.ButtonIgnore;
                case MessageButton.ButtonsYesNo:
                    return ResultMessage.ButtonYes;
                case MessageButton.ButtonsYesNoCancel:
                    return ResultMessage.ButtonYes;
                default:
                    throw new ArgumentOutOfRangeException("button");
            }
        }

        /// <summary>
        /// Converts <see cref="MessageButton" /> to <see cref="MessageBoxButton" />.
        /// </summary>
        /// <param name="button">The button enumeration.</param>
        /// <returns>The message button enumeration.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// button
        /// or
        /// button
        /// or
        /// button
        /// </exception>
        public static MessageBoxButton MessageButtonToMessageBoxButton(MessageButton button)
        {
            MessageBoxButton messageBoxButton;
            switch (button)
            {
                case MessageButton.ButtonsOk:
                    messageBoxButton = MessageBoxButton.OK;
                    break;
                case MessageButton.ButtonsOkCancel:
                    messageBoxButton = MessageBoxButton.OKCancel;
                    break;
                case MessageButton.ButtonsRetryCancel:
                    throw new ArgumentOutOfRangeException("button");
                case MessageButton.ButtonsAbortRetryIgnore:
                    throw new ArgumentOutOfRangeException("button");
                case MessageButton.ButtonsYesNo:
                    messageBoxButton = MessageBoxButton.YesNo;
                    break;
                case MessageButton.ButtonsYesNoCancel:
                    messageBoxButton = MessageBoxButton.YesNoCancel;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("button");
            }

            return messageBoxButton;
        }

        /// <summary>
        /// Converts <see cref="MessageType" /> to <see cref="MessageBoxImage" />.
        /// </summary>
        /// <param name="messageType">Type of the message.</param>
        /// <returns>The message box image.</returns>
        public static MessageBoxImage MessageTypeToMessageBoxImage(MessageType messageType)
        {
            MessageBoxImage messageBoxImage;
            switch (messageType)
            {
                case MessageType.MessageExclamation:
                    messageBoxImage = MessageBoxImage.Exclamation;
                    break;
                case MessageType.MessageInformation:
                    messageBoxImage = MessageBoxImage.Information;
                    break;
                case MessageType.MessageQuestion:
                    messageBoxImage = MessageBoxImage.Question;
                    break;
                case MessageType.MessageStop:
                    messageBoxImage = MessageBoxImage.Stop;
                    break;
                case MessageType.MessageAsterix:
                    messageBoxImage = MessageBoxImage.Asterisk;
                    break;
                case MessageType.MessageError:
                    messageBoxImage = MessageBoxImage.Error;
                    break;
                case MessageType.MessageHand:
                    messageBoxImage = MessageBoxImage.Hand;
                    break;
                case MessageType.MessageNone:
                    messageBoxImage = MessageBoxImage.None;
                    break;
                case MessageType.MessageWarning:
                    messageBoxImage = MessageBoxImage.Warning;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("messageType");
            }

            return messageBoxImage;
        }

        #endregion
    }
}
