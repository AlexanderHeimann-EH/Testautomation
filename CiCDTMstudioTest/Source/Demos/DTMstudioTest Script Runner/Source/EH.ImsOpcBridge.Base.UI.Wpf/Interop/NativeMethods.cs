// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Win32 API imports.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Win32 API imports.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public static class NativeMethods
    {
        /// <summary>
        /// The monitor default to nearest.
        /// </summary>
        public const int MonitorDefaultToNearest = 0x00000002;

        #region Public Methods and Operators

        /// <summary>
        /// Creates the helper window that receives messages from the taskar icon.
        /// </summary>
        /// <param name="dwExStyle">The dw Ex Style.</param>
        /// <param name="lpClassName">The lp Class Name.</param>
        /// <param name="lpWindowName">The lp Window Name.</param>
        /// <param name="dwStyle">The dw Style.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="nWidth">The n Width.</param>
        /// <param name="nHeight">The n Height.</param>
        /// <param name="hWndParent">The h Window Parent.</param>
        /// <param name="hMenu">The h Menu.</param>
        /// <param name="hInstance">The h Instance.</param>
        /// <param name="lpParam">The lp Param.</param>
        /// <returns>The window Ex.</returns>
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("USER32.DLL", EntryPoint = "CreateWindowExW", SetLastError = true)]
        public static extern IntPtr CreateWindowEx(int dwExStyle, [MarshalAs(UnmanagedType.LPWStr)] string lpClassName, [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, uint hWndParent, int hMenu, int hInstance, int lpParam);

        /// <summary>
        /// Processes a default windows procedure.
        /// </summary>
        /// <param name="hWnd">The h Window.</param>
        /// <param name="msg">The msg.</param>
        /// <param name="wparam">The wparam.</param>
        /// <param name="lparam">The lparam.</param>
        /// <returns>The def window proc.</returns>
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("USER32.DLL")]
        public static extern long DefWindowProc(IntPtr hWnd, uint msg, uint wparam, uint lparam);

        /// <summary>
        /// Used to destroy the hidden helper window that receives messages from the taskbar icon.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>The destroy window.</returns>
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("USER32.DLL", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        /// <summary>
        /// Gets the screen coordinates of the current mouse position.
        /// </summary>
        /// <param name="lpPoint">The lp point.</param>
        /// <returns>The get cursor pos.</returns>
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("USER32.DLL", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(ref Point lpPoint);

        /// <summary>
        /// Gets the maximum number of milliseconds that can elapse between a first click and a second click for the OS to consider the mouse action a double-click.
        /// </summary>
        /// <returns>The maximum amount of time, in milliseconds, that can elapse between a first click and a second click for the OS to consider the mouse action a double-click.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetDoubleClickTime();

        /// <summary>
        /// Registers the helper window class.
        /// </summary>
        /// <param name="lpWndClass">The lp Window Class.</param>
        /// <returns>The register class.</returns>
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("USER32.DLL", EntryPoint = "RegisterClassW", SetLastError = true)]
        public static extern short RegisterClass(ref WindowClass lpWndClass);

        /// <summary>
        /// Registers a listener for a window message.
        /// </summary>
        /// <param name="lpString">The lp string.</param>
        /// <returns>The register window message.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "string", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("User32.Dll", EntryPoint = "RegisterWindowMessageW", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern uint RegisterWindowMessage(string lpString);

        /// <summary>
        /// Gives focus to a given window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>The set foreground window.</returns>
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("USER32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Creates, updates or deletes the taskbar icon.
        /// </summary>
        /// <param name="cmd">The cmd.</param>
        /// <param name="data">The data.</param>
        /// <returns>The shell_ notify icon.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("shell32.Dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Shell_NotifyIcon(NotifyCommand cmd, [In] ref NotifyIconData data);

        /// <summary>
        /// Returns the top-level CWnd whose window class is given by lpszClassName and whose window name, or title, is given by lpszWindowName.
        /// </summary>
        /// <param name="lpClassName">Points to a null-terminated string that specifies the window's class name (a WNDCLASS structure). If lpClassName is NULL, all class names match.</param>
        /// <param name="lpWindowName">Points to a null-terminated string that specifies the window name (the window's title). If lpWindowName is NULL, all window names match.</param>
        /// <returns>Identifies the window that has the specified class name and window name. It is NULL if no such window is found.</returns>
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Interoperability", "CA1414:MarkBooleanPInvokeArgumentsWithMarshalAs", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("user32.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// The sh app bar message.
        /// </summary>
        /// <param name="dwMessage">The dw message.</param>
        /// <param name="data">The data.</param>
        /// <returns>The uint sh app bar message.</returns>
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("shell32.dll")]
        public static extern UIntPtr SHAppBarMessage(uint dwMessage, ref AppBarData data);

        /// <summary>
        /// The system parameters info.
        /// </summary>
        /// <param name="uiAction">The ui Action.</param>
        /// <param name="uiParam">The ui Param.</param>
        /// <param name="pvParam">The pv Param.</param>
        /// <param name="fWinIni">The f Win Ini.</param>
        /// <returns>The int system parameters info.</returns>
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1045:Do not pass types by reference", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:Identifiers should be spelled correctly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed. Suppression is OK here.")]
        [DllImport("user32.dll")]
        public static extern int SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        /// <summary>
        /// The set cursor pos.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The <see cref="bool" />.</returns>
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [Localizable(false)]
        [DllImport("User32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int x, int y);

        /// <summary>
        /// The get monitor info.
        /// </summary>
        /// <param name="monitorHandle">The monitor handle.</param>
        /// <param name="monitorInfo">The monitor info.</param>
        /// <returns>true if succeeded.</returns>
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [Localizable(false)]
        [DllImport("User32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMonitorInfo(IntPtr monitorHandle, MONITORINFO monitorInfo);

        /// <summary>
        /// The monitor from window.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>window handle</returns>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [Localizable(false)]
        [DllImport("User32")]
        public static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

        /// <summary>
        /// The monitor from point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>The <see cref="IntPtr" />.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible", Justification = "Reviewed. Suppression is OK here.")]
        [Localizable(false)]
        [DllImport("User32")]
        public static extern IntPtr MonitorFromPoint(Point point, int flags);
    }

    #endregion
}
