// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotifyIconData.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A struct that is submitted in order to configure the taskbar icon. Provides various members that can be configured partially, according to the values of the <see cref="IconDataMembers"/> that were defined.
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "Not needed for structs.")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NotifyIconData
    {
        /// <summary>
        /// Size of this structure, in bytes.
        /// </summary>
        private uint size;

        /// <summary>
        /// Handle to the window that receives notification messages associated with an icon in the taskbar status area. The Shell uses hWnd and uID to identify which icon to operate on when Shell_NotifyIcon is invoked.
        /// </summary>
        private IntPtr windowHandle;

        /// <summary>
        /// Application-defined identifier of the taskbar icon. The Shell uses hWnd and uID to identify which icon to operate on when Shell_NotifyIcon is invoked. You can have multiple icons associated with a single hWnd by assigning each a different uID. This feature, however is currently not used.
        /// </summary>
        private uint taskbarIconId;

        /// <summary>
        /// Flags that indicate which of the other members contain valid data. This member can be a combination of the NIF_XXX constants.
        /// </summary>
        private IconDataMembers validMembers;

        /// <summary>
        /// Application-defined message identifier. The system uses this identifier to send notifications to the window identified in hWnd.
        /// </summary>
        private uint callbackMessageId;

        /// <summary>
        /// A handle to the icon that should be displayed. Just <see cref="Icon.Handle"/> .
        /// </summary>
        private IntPtr iconHandle;

        /// <summary>
        /// String with the text for a standard ToolTip. It can have a maximum of 64 characters including the terminating NULL. For Version 5.0 and later, szTip can have a maximum of 128 characters, including the terminating NULL.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string toolTipText;

        /// <summary>
        /// State of the icon. Remember to also set the <see cref="StateMask"/> .
        /// </summary>
        private IconState notifyIconState;

        /// <summary>
        /// A value that specifies which bits of the state member are retrieved or modified. For example, setting this member to <see cref="Interop.IconState.Hidden"/> causes only the item's hidden state to be retrieved.
        /// </summary>
        private IconState stateMask;

        /// <summary>
        /// String with the text for a balloon ToolTip. It can have a maximum of 255 characters. To remove the ToolTip, set the NIF_INFO flag in uFlags and set szInfo to an empty string.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        private string balloonText;

        /// <summary>
        /// Mainly used to set the version when <see cref="NativeMethods.Shell_NotifyIcon"/> is invoked with <see cref="NotifyCommand.SetVersion"/> . However, for legacy operations, the same member is also used to set timouts for balloon ToolTips.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private uint versionOrTimeout;

        /// <summary>
        /// String containing a title for a balloon ToolTip. This title appears in boldface above the text. It can have a maximum of 63 characters.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        private string balloonTitle;

        /// <summary>
        /// Adds an icon to a balloon ToolTip, which is placed to the left of the title. If the <see cref="BalloonTitle"/> member is zero-length, the icon is not shown.
        /// </summary>
        private BalloonIconStates balloonIconState;

        /// <summary>
        /// Windows XP (Shell32.dll version 6.0) and later. <br/> - Windows 7 and later: A registered GUID that identifies the icon. This value overrides uID and is the recommended method of identifying the icon. <br/> - Windows XP through Windows Vista: Reserved.
        /// </summary>
        private Guid taskbarIconGuid;

        /// <summary>
        /// Windows Vista (Shell32.dll version 6.0.6) and later. The handle of a customized balloon icon provided by the application that should be used independently of the tray icon. If this member is non-NULL and the <see cref="Interop.BalloonIconStates.User"/> flag is set, this icon is used as the balloon icon. <br/> If this member is NULL, the legacy behavior is carried out.
        /// </summary>
        private IntPtr customBalloonIconHandle;

        /// <summary>
        /// Gets or sets Size.
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
        /// Gets or sets WindowHandle.
        /// </summary>
        /// <value>The window handle.</value>
        // ReSharper disable ConvertToAutoProperty
        public IntPtr WindowHandle
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.windowHandle;
            }

            set
            {
                this.windowHandle = value;
            }
        }

        /// <summary>
        /// Gets or sets TaskbarIconId.
        /// </summary>
        /// <value>The taskbar icon id.</value>
        // ReSharper disable ConvertToAutoProperty
        public uint TaskbarIconId
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.taskbarIconId;
            }

            set
            {
                this.taskbarIconId = value;
            }
        }

        /// <summary>
        /// Gets or sets CustomBalloonIconHandle.
        /// </summary>
        /// <value>The custom balloon icon handle.</value>
        // ReSharper disable ConvertToAutoProperty
        public IntPtr CustomBalloonIconHandle
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.customBalloonIconHandle;
            }

            set
            {
                this.customBalloonIconHandle = value;
            }
        }

        /// <summary>
        /// Gets or sets TaskbarIconGuid.
        /// </summary>
        /// <value>The taskbar icon GUID.</value>
        // ReSharper disable ConvertToAutoProperty
        public Guid TaskbarIconGuid
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.taskbarIconGuid;
            }

            set
            {
                this.taskbarIconGuid = value;
            }
        }

        /// <summary>
        /// Gets or sets BalloonIconState.
        /// </summary>
        /// <value>The balloon flags.</value>
        // ReSharper disable ConvertToAutoProperty
        public BalloonIconStates BalloonIconState
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.balloonIconState;
            }

            set
            {
                this.balloonIconState = value;
            }
        }

        /// <summary>
        /// Gets or sets BalloonTitle.
        /// </summary>
        /// <value>The balloon title.</value>
        public string BalloonTitle
        {
            get
            {
                return this.balloonTitle;
            }

            set
            {
                this.balloonTitle = value;
            }
        }

        /// <summary>
        /// Gets or sets VersionOrTimeout.
        /// </summary>
        /// <value>The version or timeout.</value>
        // ReSharper disable ConvertToAutoProperty
        public uint VersionOrTimeout
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.versionOrTimeout;
            }

            set
            {
                this.versionOrTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets BalloonText.
        /// </summary>
        /// <value>The balloon text.</value>
        public string BalloonText
        {
            get
            {
                return this.balloonText;
            }

            set
            {
                this.balloonText = value;
            }
        }

        /// <summary>
        /// Gets or sets StateMask.
        /// </summary>
        /// <value>The state mask.</value>
        // ReSharper disable ConvertToAutoProperty
        public IconState StateMask
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.stateMask;
            }

            set
            {
                this.stateMask = value;
            }
        }

        /// <summary>
        /// Gets or sets NotifyIconState.
        /// </summary>
        /// <value>The state of the notify icon.</value>
        // ReSharper disable ConvertToAutoProperty
        public IconState NotifyIconState
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.notifyIconState;
            }

            set
            {
                this.notifyIconState = value;
            }
        }

        /// <summary>
        /// Gets or sets ToolTipText.
        /// </summary>
        /// <value>The tool tip text.</value>
        public string ToolTipText
        {
            get
            {
                return this.toolTipText;
            }

            set
            {
                this.toolTipText = value;
            }
        }

        /// <summary>
        /// Gets or sets IconHandle.
        /// </summary>
        /// <value>The icon handle.</value>
        // ReSharper disable ConvertToAutoProperty
        public IntPtr IconHandle
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.iconHandle;
            }

            set
            {
                this.iconHandle = value;
            }
        }

        /// <summary>
        /// Gets or sets CallbackMessageId.
        /// </summary>
        /// <value>The callback message id.</value>
        // ReSharper disable ConvertToAutoProperty
        public uint CallbackMessageId
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.callbackMessageId;
            }

            set
            {
                this.callbackMessageId = value;
            }
        }

        /// <summary>
        /// Gets or sets ValidMembers.
        /// </summary>
        /// <value>The valid members.</value>
        // ReSharper disable ConvertToAutoProperty
        public IconDataMembers ValidMembers
        {
            // ReSharper restore ConvertToAutoProperty
            get
            {
                return this.validMembers;
            }

            set
            {
                this.validMembers = value;
            }
        }

        /// <summary>
        /// Creates a default data structure that provides a hidden taskbar icon without the icon being set.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>The icon data.</returns>
        public static NotifyIconData CreateDefault(IntPtr handle)
        {
            var data = new NotifyIconData();

            if (Environment.OSVersion.Version.Major >= 6)
            {
                // use the current size
                data.Size = (uint)Marshal.SizeOf(data);
            }
            else
            {
                // we need to set another size on xp/2003- otherwise certain
                // features (e.g. balloon tooltips) don't work.
                data.Size = 504;

                // set to fixed timeout
                data.VersionOrTimeout = 10;
            }

            data.WindowHandle = handle;
            data.TaskbarIconId = 0x0;
            data.CallbackMessageId = WindowMessageSink.CallbackMessageId;
            data.VersionOrTimeout = (uint)NotifyIconVersion.Win95;

            data.IconHandle = IntPtr.Zero;

            // hide initially
            data.NotifyIconState = IconState.Hidden;
            data.StateMask = IconState.Hidden;

            // set flags
            data.ValidMembers = IconDataMembers.Message | IconDataMembers.Icon | IconDataMembers.Tip;

            // reset strings
            data.ToolTipText = data.BalloonText = data.BalloonTitle = string.Empty;

            return data;
        }
    }
}
