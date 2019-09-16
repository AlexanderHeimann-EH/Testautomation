// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppBarData.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The app bar data class.
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "Not needed for structs.")]
    [StructLayout(LayoutKind.Sequential)]
    public struct AppBarData
    {
        /// <summary>
        /// The size.
        /// </summary>
        private uint size;

        /// <summary>
        /// The Window handle.
        /// </summary>
        private IntPtr window;

        /// <summary>
        /// The callback message.
        /// </summary>
        private uint callbackMessage;

        /// <summary>
        /// The edge.
        /// </summary>
        private uint edge;

        /// <summary>
        /// The rectangle.
        /// </summary>
        private Rect rect;

        /// <summary>
        /// The lparam.
        /// </summary>
        private int param;

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        // ReSharper disable ConvertToAutoProperty
        public uint Size
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }

        /// <summary>
        /// Gets or sets the Wnd.
        /// </summary>
        /// <value>The WND.</value>
        // ReSharper disable ConvertToAutoProperty
        public IntPtr Window
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.window;
            }

            set
            {
                this.window = value;
            }
        }

        /// <summary>
        /// Gets or sets the callback message.
        /// </summary>
        /// <value>The callback message.</value>
        // ReSharper disable ConvertToAutoProperty
        public uint CallbackMessage
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.callbackMessage;
            }

            set
            {
                this.callbackMessage = value;
            }
        }

        /// <summary>
        /// Gets or sets the edge.
        /// </summary>
        /// <value>The edge.</value>
        // ReSharper disable ConvertToAutoProperty
        public uint Edge
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.edge;
            }

            set
            {
                this.edge = value;
            }
        }

        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        /// <value>The rectangle.</value>
        // ReSharper disable ConvertToAutoProperty
        public Rect Rect
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.rect;
            }

            set
            {
                this.rect = value;
            }
        }

        /// <summary>
        /// Gets or sets the param.
        /// </summary>
        /// <value>The param.</value>
        // ReSharper disable ConvertToAutoProperty
        public int Param
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.param;
            }

            set
            {
                this.param = value;
            }
        }
    }
}
