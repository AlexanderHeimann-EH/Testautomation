// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrayInfo.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
    /// <summary>
    /// Resolves the current tray position.
    /// </summary>
    public static class TrayInfo
    {
        #region Public Properties

        /// <summary>
        /// Gets the position of the system tray.
        /// </summary>
        public static Point TrayLocation
        {
            get
            {
                var info = new AppBarInfo();
                info.GetSystemTaskbarPosition();

                var workArea = AppBarInfo.WorkArea;

                int x = 0, y = 0;
                if (info.Edge == ScreenEdge.Left)
                {
                    x = workArea.Left + 2;
                    y = workArea.Bottom;
                }
                else if (info.Edge == ScreenEdge.Bottom)
                {
                    x = workArea.Right;
                    y = workArea.Bottom;
                }
                else if (info.Edge == ScreenEdge.Top)
                {
                    x = workArea.Right;
                    y = workArea.Top;
                }
                else if (info.Edge == ScreenEdge.Right)
                {
                    x = workArea.Right;
                    y = workArea.Bottom;
                }

                return new Point { X = x, Y = y };
            }
        }

        #endregion
    }
}
