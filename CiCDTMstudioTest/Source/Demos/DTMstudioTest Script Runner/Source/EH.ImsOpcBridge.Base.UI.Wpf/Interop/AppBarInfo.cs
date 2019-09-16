// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppBarInfo.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    using EH.ImsOpcBridge.Exceptions;
    using EH.ImsOpcBridge.UI.Wpf.Properties;

    /// <summary>
    /// The AppBar info.
    /// </summary>
    public class AppBarInfo
    {
        #region Constants and Fields

        /// <summary>
        /// The BOTTOM constant.
        /// </summary>
        public const int AbeBottom = 3;

        /// <summary>
        /// The LEFT constant.
        /// </summary>
        public const int AbeLeft = 0;

        /// <summary>
        /// The RIGHT constant.
        /// </summary>
        public const int AbeRight = 2;

        /// <summary>
        /// The TOP constant.
        /// </summary>
        public const int AbeTop = 1;

        /// <summary>
        /// The GETTASKBARPOS constant.
        /// </summary>
        private const int AbmGettaskbarpos = 0x00000005;

        /// <summary>
        /// The GETWORKAREA constant.
        /// </summary>
        private const uint SpiGetworkarea = 0x0030;

        /// <summary>
        /// The APPBARDATA.
        /// </summary>
        private AppBarData data;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the WorkArea.
        /// </summary>
        public static Rectangle WorkArea
        {
            get
            {
                var rc = new Rect();
                var rawRect = Marshal.AllocHGlobal(Marshal.SizeOf(rc));
                var result = NativeMethods.SystemParametersInfo(SpiGetworkarea, 0, rawRect, 0);
                rc = (Rect)Marshal.PtrToStructure(rawRect, rc.GetType());

                if (result == 1)
                {
                    Marshal.FreeHGlobal(rawRect);
                    return new Rectangle(rc.Left, rc.Top, rc.Right - rc.Left, rc.Bottom - rc.Top);
                }

                return new Rectangle(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Gets the screen edge.
        /// </summary>
        public ScreenEdge Edge
        {
            get
            {
                return (ScreenEdge)this.data.Edge;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get position.
        /// </summary>
        /// <param name="className">The class name.</param>
        /// <param name="windowName">The window name.</param>
        public void GetPosition(string className, string windowName)
        {
            this.data = new AppBarData();
            this.data.Size = (uint)Marshal.SizeOf(this.data.GetType());

            var wnd = NativeMethods.FindWindow(className, windowName);

            if (wnd != IntPtr.Zero)
            {
                var result = NativeMethods.SHAppBarMessage(AbmGettaskbarpos, ref this.data);

                if (result.ToUInt64() != 1)
                {
                    throw new BaseException(Resources.FailedToCommunicateWithTheGivenAppBar);
                }
            }
            else
            {
                throw new BaseException(Resources.FailedToFindAnAppBarThatMatchedTheGivenCriteria);
            }
        }

        /// <summary>
        /// The get system task bar position.
        /// </summary>
        public void GetSystemTaskbarPosition()
        {
            // ReSharper disable LocalizableElement
            this.GetPosition("Shell_TrayWnd", null);

            // ReSharper restore LocalizableElement
        }

        #endregion
    }
}
