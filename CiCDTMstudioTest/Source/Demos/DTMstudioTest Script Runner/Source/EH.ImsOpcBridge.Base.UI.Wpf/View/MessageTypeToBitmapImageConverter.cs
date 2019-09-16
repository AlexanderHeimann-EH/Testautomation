// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageTypeToBitmapImageConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// A converter to convert a MessageType to an BitmapImage.
    /// </summary>
    public class MessageTypeToBitmapImageConverter : IValueConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value (MessageType) produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value (BitmapImage). If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var messageType = (MessageType)value;
            BitmapImage image;

            switch (messageType)
            {
                case MessageType.MessageExclamation:
                    image = new BitmapImage(new Uri(@"pack://application:,,,/EH.ImsOpcBridge.Base.UI.Wpf;component/Resources/Exclamation.png"));
                    break;
                case MessageType.MessageInformation:
                    image = new BitmapImage(new Uri(@"pack://application:,,,/EH.ImsOpcBridge.Base.UI.Wpf;component/Resources/Information.png"));
                    break;
                case MessageType.MessageQuestion:
                    image = new BitmapImage(new Uri(@"pack://application:,,,/EH.ImsOpcBridge.Base.UI.Wpf;component/Resources/Question.png"));
                    break;
                case MessageType.MessageStop:
                    image = new BitmapImage(new Uri(@"pack://application:,,,/EH.ImsOpcBridge.Base.UI.Wpf;component/Resources/Stop.png"));
                    break;
                case MessageType.MessageAsterix:
                    image = new BitmapImage(new Uri(@"pack://application:,,,/EH.ImsOpcBridge.Base.UI.Wpf;component/Resources/Asterisk.png"));
                    break;
                case MessageType.MessageError:
                    image = new BitmapImage(new Uri(@"pack://application:,,,/EH.ImsOpcBridge.Base.UI.Wpf;component/Resources/Error.png"));
                    break;
                case MessageType.MessageHand:
                    image = new BitmapImage(new Uri(@"pack://application:,,,/EH.ImsOpcBridge.Base.UI.Wpf;component/Resources/Hand.png"));
                    break;
                case MessageType.MessageNone:
                    image = null;
                    break;
                case MessageType.MessageWarning:
                    image = new BitmapImage(new Uri(@"pack://application:,,,/EH.ImsOpcBridge.Base.UI.Wpf;component/Resources/Warning.png"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(@"value");
            }

            return image;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <exception cref="NotImplementedException">Thrown as it is not implemented.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ReSharper disable LocalizableElement
            throw new NotImplementedException("Will never be implemented.");

            // ReSharper restore LocalizableElement
        }

        #endregion
    }
}
