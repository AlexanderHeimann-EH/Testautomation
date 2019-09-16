// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DpiIndependentSizeConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The dpi independent size converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.Converter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    using EH.ImsOpcBridge.UI.Wpf.Interop;

    using Point = EH.ImsOpcBridge.UI.Wpf.Interop.Point;

    /// <summary>
    /// The dpi independent size converter.
    /// </summary>
    public class DpiIndependentSizeConverter : IValueConverter
    {
        #region Constants

        /// <summary>
        /// The min supported width.
        /// </summary>
        private const double MinSupportedWidth = 1366;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var orgSize = (double)value;

            var factor = 1.0;

            var mainWindow = Application.Current.MainWindow;
            if (mainWindow == null)
            {
                return value;
            }

            var mainWindowPresentationSource = PresentationSource.FromVisual(mainWindow);
            if (mainWindowPresentationSource != null && mainWindowPresentationSource.CompositionTarget != null)
            {
                var m = mainWindowPresentationSource.CompositionTarget.TransformToDevice;
                factor = m.M11;
            }

            var monitor = NativeMethods.MonitorFromPoint(new Point(0, 0), NativeMethods.MonitorDefaultToNearest);

            if (monitor != IntPtr.Zero)
            {
                var monitorInfo = new MONITORINFO();
                NativeMethods.GetMonitorInfo(monitor, monitorInfo);

                var workAreaWidth = monitorInfo.rcWork.Width;

                if (workAreaWidth < MinSupportedWidth)
                {
                    factor = factor * (MinSupportedWidth / workAreaWidth);
                }
            }

            var newSize = orgSize * factor;

            var retval = (object)newSize;

            return retval;
        }

        /// <summary>
        /// The convert back.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
