// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   This class will contain all methods that we need to import.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// This class will contain all methods that we need to import.
    /// </summary>
    internal class NativeMethods
    {
        /// <summary>
        /// The w m_ lbuttondown.
        /// </summary>
        public const int WM_LBUTTONDOWN = 0x0201;

        /// <summary>
        /// The w m_ lbuttondblclk.
        /// </summary>
        public const int WM_LBUTTONDBLCLK = 0x0203;

        /// <summary>
        /// The w m_ rbuttondown.
        /// </summary>
        public const int WM_RBUTTONDOWN = 0x0204;

        /// <summary>
        /// The w m_ mbuttondown.
        /// </summary>
        public const int WM_MBUTTONDOWN = 0x0207;

        // Including a private constructor to prevent a compiler-generated default constructor
        /// <summary>
        /// Prevents a default instance of the <see cref="NativeMethods"/> class from being created.
        /// </summary>
        private NativeMethods()
        {
        }

        // Import the SendMessage function from user32.dll
        /// <summary>
        /// The send message.
        /// </summary>
        /// <param name="hwnd">
        /// The hwnd.
        /// </param>
        /// <param name="Msg">
        /// The msg.
        /// </param>
        /// <param name="wParam">
        /// The w param.
        /// </param>
        /// <param name="lParam">
        /// The l param.
        /// </param>
        /// <returns>
        /// The <see cref="IntPtr"/>.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int Msg, IntPtr wParam, [MarshalAs(UnmanagedType.IUnknown)] out object lParam);
    }
}