// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowClass.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Callback delegate which is used by the Windows API to submit window messages.
    /// </summary>
    /// <param name="hwnd">The HWND.</param>
    /// <param name="uMsg">The u MSG.</param>
    /// <param name="wparam">The wparam.</param>
    /// <param name="lparam">The lparam.</param>
    /// <returns>The window procedure handler.</returns>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "OK here. Delegate represents a Win32 API.")]
    public delegate long WindowProcedureHandler(IntPtr hwnd, uint uMsg, uint wparam, uint lparam);

    /// <summary>
    /// Win API WNDCLASS struct - represents a single window. Used to receive window messages.
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "Not needed for structs.")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowClass
    {
        /// <summary>
        /// The style.
        /// </summary>
        private uint style;

        /// <summary>
        /// The lpfn wnd proc.
        /// </summary>
        private WindowProcedureHandler lpfnWndProc;

        /// <summary>
        /// The cb cls clsExtra.
        /// </summary>
        private int clsExtra;

        /// <summary>
        /// The cb wnd clsExtra.
        /// </summary>
        private int wndExtra;

        /// <summary>
        /// The h instance.
        /// </summary>
        private IntPtr instance;

        /// <summary>
        /// The h icon.
        /// </summary>
        private IntPtr icon;

        /// <summary>
        /// The h cursor.
        /// </summary>
        private IntPtr cursor;

        /// <summary>
        /// The hbr background.
        /// </summary>
        private IntPtr hbrBackground;

        /// <summary>
        /// The lpsz menu name.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [MarshalAs(UnmanagedType.LPWStr)]
        private string lpszMenuName;

        /// <summary>
        /// The lpsz class name.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [MarshalAs(UnmanagedType.LPWStr)]
        private string lpszClassName;

        /// <summary>
        /// Gets or sets Style.
        /// </summary>
        /// <value>The style.</value>
        // ReSharper disable ConvertToAutoProperty
        public uint Style
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.style;
            }

            set
            {
                this.style = value;
            }
        }

        /// <summary>
        /// Gets or sets LpfnWndProc.
        /// </summary>
        /// <value>The LPFN WND proc.</value>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Is OK here.")]
        // ReSharper disable ConvertToAutoProperty
            public WindowProcedureHandler LpfnWndProc
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.lpfnWndProc;
            }

            set
            {
                this.lpfnWndProc = value;
            }
        }

        /// <summary>
        /// Gets or sets clsExtra.
        /// </summary>
        /// <value>The cb CLS clsExtra.</value>
        // ReSharper disable ConvertToAutoProperty
        public int CBClsExtra
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.clsExtra;
            }

            set
            {
                this.clsExtra = value;
            }
        }

        /// <summary>
        /// Gets or sets wndExtra.
        /// </summary>
        /// <value>The cb WND clsExtra.</value>
        // ReSharper disable ConvertToAutoProperty
        public int CBWndExtra
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.wndExtra;
            }

            set
            {
                this.wndExtra = value;
            }
        }

        /// <summary>
        /// Gets or sets instance.
        /// </summary>
        /// <value>The H instance.</value>
        // ReSharper disable ConvertToAutoProperty
        public IntPtr HInstance
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.instance;
            }

            set
            {
                this.instance = value;
            }
        }

        /// <summary>
        /// Gets or sets icon.
        /// </summary>
        /// <value>The H icon.</value>
        // ReSharper disable ConvertToAutoProperty
        public IntPtr HIcon
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.icon;
            }

            set
            {
                this.icon = value;
            }
        }

        /// <summary>
        /// Gets or sets cursor.
        /// </summary>
        /// <value>The H cursor.</value>
        // ReSharper disable ConvertToAutoProperty
        public IntPtr HCursor
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.cursor;
            }

            set
            {
                this.cursor = value;
            }
        }

        /// <summary>
        /// Gets or sets HbrBackground.
        /// </summary>
        /// <value>The HBR background.</value>
        // ReSharper disable ConvertToAutoProperty
        public IntPtr HbrBackground
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.hbrBackground;
            }

            set
            {
                this.hbrBackground = value;
            }
        }

        /// <summary>
        /// Gets or sets LpszMenuName.
        /// </summary>
        /// <value>The name of the LPSZ menu.</value>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Is OK here.")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string LpszMenuName
        {
            get
            {
                return this.lpszMenuName;
            }

            set
            {
                this.lpszMenuName = value;
            }
        }

        /// <summary>
        /// Gets or sets LpszClassName.
        /// </summary>
        /// <value>The name of the LPSZ class.</value>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Is OK here.")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string LpszClassName
        {
            get
            {
                return this.lpszClassName;
            }

            set
            {
                this.lpszClassName = value;
            }
        }
    }
}
