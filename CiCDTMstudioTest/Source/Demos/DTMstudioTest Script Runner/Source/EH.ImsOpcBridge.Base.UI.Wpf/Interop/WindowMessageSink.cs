// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowMessageSink.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Interop
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;

    using EH.ImsOpcBridge.UI.Wpf.Properties;

    using log4net;

    /// <summary>
    /// Receives messages from the taskbar icon through window messages of an underlying helper window.
    /// </summary>
    public class WindowMessageSink : IDisposable
    {
        #region Constants and Fields

        /// <summary>
        /// The ID of messages that are received from the the taskbar icon.
        /// </summary>
        public const int CallbackMessageId = 0x400;

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Used to track whether a mouse-up event is just the aftermath of a double-click and therefore needs to be suppressed.
        /// </summary>
        private bool isDoubleClick;

        /// <summary>
        /// A delegate that processes messages of the hidden native window that receives window messages. Storing this reference makes sure we don't loose our reference to the message window.
        /// </summary>
        private WindowProcedureHandler messageHandler;

        /// <summary>
        /// The ID of the message that is being received if the taskbar is (re)started.
        /// </summary>
        private uint taskbarRestartMessageId;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowMessageSink"/> class.
        /// Creates a new message sink that receives message from a given taskbar icon.
        /// </summary>
        /// <param name="version">The version.</param>
        public WindowMessageSink(NotifyIconVersion version)
        {
            this.Version = version;
            this.CreateMessageWindow();
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="WindowMessageSink"/> class from being created.
        /// </summary>
        private WindowMessageSink()
        {
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="WindowMessageSink"/> class.
        /// This destructor will run only if the <see cref="Dispose()"/> method does not get called. This gives this base class the opportunity to finalize.
        /// <para>
        /// Important: Do not provide destructors in types derived from
        /// this class.
        /// </para>
        /// </summary>
        ~WindowMessageSink()
        {
            this.Dispose(false);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Fired if a balloon ToolTip was either displayed or closed (indicated by the boolean flag).
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "Is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Is OK here.")]
        public event Action<object, bool> BalloonToolTipChanged;

        /// <summary>
        /// The custom tooltip should be closed or hidden.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "Is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Is OK here.")]
        public event Action<object, bool> ChangeToolTipStateRequest;

        /// <summary>
        /// Fired in case the user clicked or moved within the taskbar icon area.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "Is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Is OK here.")]
        public event Action<object, MouseEvent> MouseEventReceived;

        /// <summary>
        /// Fired if the taskbar was created or restarted. Requires the taskbar icon to be reset.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "Is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Is OK here.")]
        public event Action<object> TaskbarCreated;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether <see cref="Dispose"/> has been invoked.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Gets or sets the version of the underlying icon. Defines how incoming messages are interpreted.
        /// </summary>
        /// <value>The version.</value>
        public NotifyIconVersion Version { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets MessageWindowHandle.
        /// </summary>
        internal IntPtr MessageWindowHandle { get; private set; }

        /// <summary>
        /// Gets the window class ID.
        /// </summary>
        internal string WindowId { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <remarks>This method is not virtual by design. Derived classes should override <see cref="Dispose(bool)"/> .</remarks>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a dummy instance that provides an empty pointer rather than a real window handler. <br/> Used at design time.
        /// </summary>
        /// <returns>The dummy instance.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here."), SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Is OK here.")]
        internal static WindowMessageSink CreateEmpty()
        {
            return new WindowMessageSink { MessageWindowHandle = IntPtr.Zero, Version = NotifyIconVersion.Vista };
        }

        /// <summary>
        /// Creates the helper message window that is used to receive messages from the taskbar icon.
        /// </summary>
        private void CreateMessageWindow()
        {
            // generate a unique ID for the window
            // ReSharper disable LocalizableElement
            this.WindowId = "WPFTaskbarIcon_" + DateTime.Now.Ticks;

            // ReSharper restore LocalizableElement

            // register window message handler
            this.messageHandler = this.OnWindowMessageReceived;

            // Create a simple window class which is reference through
            // the messageHandler delegate
            var wc = new WindowClass();

            wc.Style = 0;
            wc.LpfnWndProc = this.messageHandler;
            wc.CBClsExtra = 0;
            wc.CBWndExtra = 0;
            wc.HInstance = IntPtr.Zero;
            wc.HIcon = IntPtr.Zero;
            wc.HCursor = IntPtr.Zero;
            wc.HbrBackground = IntPtr.Zero;
            wc.LpszMenuName = string.Empty;
            wc.LpszClassName = this.WindowId;

            // Register the window class
            NativeMethods.RegisterClass(ref wc);

            // Get the message used to indicate the taskbar has been restarted
            // This is used to re-add icons when the taskbar restarts
            // ReSharper disable LocalizableElement
            this.taskbarRestartMessageId = NativeMethods.RegisterWindowMessage("TaskbarCreated");

            // ReSharper restore LocalizableElement

            // Create the message window
            this.MessageWindowHandle = NativeMethods.CreateWindowEx(0, this.WindowId, string.Empty, 0, 0, 0, 1, 1, 0, 0, 0, 0);

            if (this.MessageWindowHandle == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
        }

        /// <summary>
        /// Removes the windows hook that receives window messages and closes the underlying helper window.
        /// </summary>
        /// <param name="disposing">The disposing.</param>
        private void Dispose(bool disposing)
        {
            // don't do anything if the component is already disposed
            if (this.IsDisposed || !disposing)
            {
                return;
            }

            this.IsDisposed = true;

            NativeMethods.DestroyWindow(this.MessageWindowHandle);
            this.messageHandler = null;
        }

        /// <summary>
        /// Callback method that receives messages from the taskbar area.
        /// </summary>
        /// <param name="hwnd">The hwnd.</param>
        /// <param name="messageId">The message Id.</param>
        /// <param name="wparam">The wparam.</param>
        /// <param name="lparam">The lparam.</param>
        /// <returns>The on window message received.</returns>
        private long OnWindowMessageReceived(IntPtr hwnd, uint messageId, uint wparam, uint lparam)
        {
            if (messageId == this.taskbarRestartMessageId)
            {
                // recreate the icon if the taskbar was restarted (e.g. due to Win Explorer shutdown)
                this.TaskbarCreated(this);
            }

            // forward message
            this.ProcessWindowMessage(messageId, wparam, lparam);

            // Pass the message to the default window procedure
            return NativeMethods.DefWindowProc(hwnd, messageId, wparam, lparam);
        }

        /// <summary>
        /// Processes incoming system messages.
        /// </summary>
        /// <param name="msg">Callback ID.</param>
        /// <param name="coordinatesParam">If the version is <see cref="NotifyIconVersion.Vista"/> or higher, this parameter can be used to resolve mouse coordinates. Currently not in use.</param>
        /// <param name="eventParam">Provides information about the event.</param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Is OK here.")]
        // ReSharper disable UnusedParameter.Local
        private void ProcessWindowMessage(uint msg, uint coordinatesParam, uint eventParam)
        {
            // ReSharper restore UnusedParameter.Local
            if (msg != CallbackMessageId)
            {
                return;
            }

            switch (eventParam)
            {
                case 0x200:
                    this.MouseEventReceived(this, MouseEvent.MouseMove);
                    break;

                case 0x201:
                    this.MouseEventReceived(this, MouseEvent.IconLeftMouseDown);
                    break;

                case 0x202:
                    if (!this.isDoubleClick)
                    {
                        this.MouseEventReceived(this, MouseEvent.IconLeftMouseUp);
                    }

                    this.isDoubleClick = false;
                    break;

                case 0x203:
                    this.isDoubleClick = true;
                    this.MouseEventReceived(this, MouseEvent.IconDoubleClick);
                    break;

                case 0x204:
                    this.MouseEventReceived(this, MouseEvent.IconRightMouseDown);
                    break;

                case 0x205:
                    this.MouseEventReceived(this, MouseEvent.IconRightMouseUp);
                    break;

                case 0x206:

                    // double click with right mouse button - do not trigger event
                    break;

                case 0x207:
                    this.MouseEventReceived(this, MouseEvent.IconMiddleMouseDown);
                    break;

                case 520:
                    this.MouseEventReceived(this, MouseEvent.IconMiddleMouseUp);
                    break;

                case 0x209:

                    // double click with middle mouse button - do not trigger event
                    break;

                case 0x402:
                    this.BalloonToolTipChanged(this, true);
                    break;

                case 0x403:
                case 0x404:
                    this.BalloonToolTipChanged(this, false);
                    break;

                case 0x405:
                    this.MouseEventReceived(this, MouseEvent.BalloonToolTipClicked);
                    break;

                case 0x406:
                    this.ChangeToolTipStateRequest(this, true);
                    break;

                case 0x407:
                    this.ChangeToolTipStateRequest(this, false);
                    break;

                default:
                    if (Logger.IsDebugEnabled)
                    {
                        var message = string.Format(CultureInfo.CurrentUICulture, Resources.UnhandledNotifyIconMessageId_, eventParam);
                        Logger.Debug(message);
                    }

                    break;
            }
        }

        #endregion
    }
}
