// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Helpers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Native methods
    /// </summary>
    public static class NativeMethods
    {
        // ReSharper disable LocalizableElement

        /// <summary>
        /// The show window.
        /// </summary>
        /// <param name="hWnd">The h wnd.</param>
        /// <param name="nCmdShow">The show command.</param>
        /// <returns>The <see cref="int" />.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "OK here.")]
        [DllImport("user32.dll")]
        internal static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// The set foreground window.
        /// </summary>
        /// <param name="hWnd">The h wnd.</param>
        /// <returns>The <see cref="int" />.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "OK here.")]
        [DllImport("user32.dll")]
        internal static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The is iconic.
        /// </summary>
        /// <param name="hWnd">The h wnd.</param>
        /// <returns>The <see cref="int" />.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "OK here.")]
        [DllImport("user32.dll")]
        internal static extern int IsIconic(IntPtr hWnd);

        // ReSharper restore LocalizableElement
    }
}
