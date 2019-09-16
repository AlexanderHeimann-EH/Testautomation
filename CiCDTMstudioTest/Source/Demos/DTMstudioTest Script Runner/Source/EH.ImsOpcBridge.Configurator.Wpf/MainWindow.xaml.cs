// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    using EH.ImsOpcBridge.Common.Utils;
    using EH.ImsOpcBridge.Configurator.DefaultHost;
    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.ViewModel;
    using EH.ImsOpcBridge.Helpers;
    using EH.ImsOpcBridge.UI;
    using EH.ImsOpcBridge.UI.Wpf.Interop;
    using EH.ImsOpcBridge.Wcf.Interfaces;

    using NativeMethods = EH.ImsOpcBridge.UI.Wpf.Interop.NativeMethods;
    using Point = EH.ImsOpcBridge.UI.Wpf.Interop.Point;
    using Rect = EH.ImsOpcBridge.UI.Wpf.Interop.Rect;
    using WinInterop = System.Windows.Interop;

    /// <summary>
    /// Class MainWindow
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = @"OK here.")]
    public partial class MainWindow
    {
        #region Constants

        /// <summary>
        /// The client URI
        /// </summary>
        private const string DefaultClientUri = @"http://localhost:8091/ServiceModel/EH/ImsOpcBridge/ServiceCallback";

        /// <summary>
        /// The client URI key
        /// </summary>
        private const string ClientUriKey = @"ClientUri";

        /// <summary>
        /// The min main height
        /// </summary>
        private const int MinMainHeight = 720;

        /// <summary>
        /// The min main width
        /// </summary>
        private const int MinMainWidth = 1276;

        #endregion

        #region Fields

        /// <summary>
        /// The application loaded timer
        /// </summary>
        private Timer applicationLoadedTimer;

        /// <summary>
        /// The normal height
        /// </summary>
        private double normalHeight;

        /// <summary>
        /// The normal left
        /// </summary>
        private double normalLeft;

        /// <summary>
        /// The normal top
        /// </summary>
        private double normalTop;

        /// <summary>
        /// The normal width
        /// </summary>
        private double normalWidth;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            string clientUri;
            Utils.ReadAppSettings(ClientUriKey, DefaultClientUri, out clientUri);
            ClientUri = clientUri;
            this.ServiceHostContainer = new ServiceHostContainer(new Uri(clientUri), typeof(ICommServerCallback), typeof(ConfiguratorHost));

            RenderOptions.SetBitmapScalingMode(this, BitmapScalingMode.Fant);

            ThemeSelector.SetCurrentThemeDictionary(this, new Uri("/EH.ImsOpcBridge.Configurator.Wpf;component/Themes/DesignA2.xaml", UriKind.Relative));

            this.DataContext = new MainWindowVm();

            this.InitializeComponent();

            this.TitleBar.MouseDown += this.TitleBarOnMouseDown;
            this.SourceInitialized += this.WinSourceInitialized;
        }

        #endregion

        #region Static Properties

        /// <summary>
        /// Gets or sets the client uri.
        /// </summary>
        /// <value>The client uri.</value>
        public static string ClientUri { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the service host container.
        /// </summary>
        /// <value>The service host container.</value>
        private ServiceHostContainer ServiceHostContainer { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Drags the hook.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w param.</param>
        /// <param name="lParam">The l param.</param>
        /// <param name="handeled">if set to <c>true</c> [handeled].</param>
        /// <returns>return IntPtr</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private static IntPtr DragHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handeled)
        {
            switch ((WM)msg)
            {
                case WM.WINDOWPOSCHANGING:
                    {
                        var pos = (WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(WINDOWPOS));
                        if ((pos.flags & SWP.NOMOVE) != 0)
                        {
                            return IntPtr.Zero;
                        }

                        var hwndSource = WinInterop.HwndSource.FromHwnd(hwnd);
                        if (hwndSource != null)
                        {
                            var wnd = (Window)hwndSource.RootVisual;
                            if (wnd == null)
                            {
                                return IntPtr.Zero;
                            }
                        }

                        bool changedPos = false;

                        // ***********************
                        // Here you check the values inside the pos structure
                        // if you want to override them just change the pos
                        // structure and set changedPos to true
                        // ***********************

                        // this is a simplified version that doesn't work in high-dpi settings
                        // pos.cx and pos.cy are in "device pixels" and MinWidth and MinHeight 
                        // are in "WPF pixels" (WPF pixels are always 1/96 of an inch - if your
                        // system is configured correctly).
                        var minWidth = MinMainWidth;
                        var minHeight = MinMainHeight;

                        var monitor = NativeMethods.MonitorFromPoint(new Point(0, 0), NativeMethods.MonitorDefaultToNearest);

                        if (monitor != IntPtr.Zero)
                        {
                            var monitorInfo = new MONITORINFO();
                            NativeMethods.GetMonitorInfo(monitor, monitorInfo);

                            var workingArea = monitorInfo.rcWork;

                            if (workingArea.Width < minWidth)
                            {
                                minWidth = workingArea.Width;
                            }

                            if (workingArea.Height < minHeight)
                            {
                                minHeight = workingArea.Height;
                            }
                        }

                        if (pos.cx < minWidth + (SystemParameters.ResizeFrameVerticalBorderWidth * 2))
                        {
                            pos.cx = minWidth + (int)(SystemParameters.ResizeFrameVerticalBorderWidth * 2);
                            changedPos = true;
                        }

                        if (pos.cy < minHeight + (SystemParameters.ResizeFrameHorizontalBorderHeight * 2))
                        {
                            pos.cy = minHeight + (int)(SystemParameters.ResizeFrameHorizontalBorderHeight * 2);
                            changedPos = true;
                        }

                        // ***********************
                        // end of "logic"
                        // ***********************
                        if (!changedPos)
                        {
                            return IntPtr.Zero;
                        }

                        Marshal.StructureToPtr(pos, lParam, true);
                        handeled = true;
                    }

                    break;
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// Windows the proc.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w param.</param>
        /// <param name="lParam">The l param.</param>
        /// <param name="handled">if set to <c>true</c> [handled].</param>
        /// <returns>Return IntPtr.</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        private static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch ((WM)msg)
            {
                case WM.GETMINMAXINFO:

                    // WmGetMinMaxInfo(hwnd, lParam);
                    // handled = true;
                    break;
            }

            return (IntPtr)0;
        }

        /// <summary>
        /// Wms the get min max info.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="lParam">The l param.</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            var mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            IntPtr monitor = NativeMethods.MonitorFromWindow(hwnd, NativeMethods.MonitorDefaultToNearest);

            if (monitor != IntPtr.Zero)
            {
                var monitorInfo = new MONITORINFO();
                NativeMethods.GetMonitorInfo(monitor, monitorInfo);
                Rect rcWorkArea = monitorInfo.rcWork;
                Rect rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.X = Math.Abs(rcWorkArea.Left - rcMonitorArea.left);
                mmi.ptMaxPosition.Y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.X = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.Y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        /// <summary>
        /// Applications the loaded timer elapsed.
        /// </summary>
        /// <param name="state">The state.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Is OK here.")]
        private void ApplicationLoadedTimerElapsed(object state)
        {
            this.applicationLoadedTimer.Dispose();
            this.applicationLoadedTimer = null;

            var mainWindowVm = state as MainWindowVm;
            if (mainWindowVm != null)
            {
                mainWindowVm.ApplicationIsLoaded();
            }
        }

        /// <summary>
        /// Mouse down event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void MouseDownEventHandler(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount >= 2)
            {
                // left mouse button double click
                this.ToggleMainWindowFullScreen();
            }
        }

        /// <summary>
        /// Called when [key down].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = @"OK here.")]
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                ////var settingsViewModel = this.Settings.DataContext as SettingsVm;
                ////if (settingsViewModel != null)
                ////{
                ////    if (settingsViewModel.CurrentSection == SettingsSection.ImsOpcBridge)
                ////    {
                ////        var mainViewModel = this.DataContext as MainWindowVm;
                ////        if (mainViewModel != null)
                ////        {
                ////            // ReSharper restore EmptyGeneralCatchClause
                ////        }
                ////    }
                ////}
            }
        }

        /// <summary>
        /// Titles the bar on mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="mouseButtonEventArgs">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void TitleBarOnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (mouseButtonEventArgs.ChangedButton == MouseButton.Left && mouseButtonEventArgs.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// Toggles the main window full screen.
        /// </summary>
        private void ToggleMainWindowFullScreen()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                // keep normal position and size
                this.normalLeft = this.Left;
                this.normalTop = this.Top;
                this.normalWidth = this.Width;
                this.normalHeight = this.Height;

                this.WindowState = WindowState.Maximized;
            }
        }

        /// <summary>
        /// Wins the source initialized.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void WinSourceInitialized(object sender, EventArgs e)
        {
            IntPtr handle = (new WinInterop.WindowInteropHelper(this)).Handle;
            var hwndSource = WinInterop.HwndSource.FromHwnd(handle);
            if (hwndSource != null)
            {
                hwndSource.AddHook(WindowProc);
            }
        }

        /// <summary>
        /// Windows the closed event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void WindowClosedEventHandler(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Windows the closing event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void WindowClosingEventHandler(object sender, CancelEventArgs e)
        {
            var mainWindowVm = this.DataContext as MainWindowVm;
            if (mainWindowVm != null)
            {
                try
                {
                    this.ServiceHostContainer.Stop();
                }
                catch (Exception exception)
                {
                    var message = @"Exception in client call: " + exception.Message;
                    var caption = @"Exception";
                    mainWindowVm.Host.UserInterface.DisplayMessage(message, caption, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);
                }

                if (this.WindowState == WindowState.Maximized)
                {
                    mainWindowVm.SettingsViewModel.WindowsPosLeft = this.normalLeft;
                    mainWindowVm.SettingsViewModel.WindowsPosTop = this.normalTop;
                    mainWindowVm.SettingsViewModel.WindowsPosWidth = this.normalWidth;
                    mainWindowVm.SettingsViewModel.WindowsPosHeight = this.normalHeight;
                }
                else
                {
                    mainWindowVm.SettingsViewModel.WindowsPosLeft = this.Left;
                    mainWindowVm.SettingsViewModel.WindowsPosTop = this.Top;
                    mainWindowVm.SettingsViewModel.WindowsPosWidth = this.Width;
                    mainWindowVm.SettingsViewModel.WindowsPosHeight = this.Height;
                }

                mainWindowVm.SettingsViewModel.Save();
            }

            Application.Current.Shutdown();
        }

        /// <summary>
        /// Windows the loaded event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void WindowLoadedEventHandler(object sender, RoutedEventArgs e)
        {
            // Check for new DTM catalog when application is loading
            var mainWindowVm = this.DataContext as MainWindowVm;
            if (mainWindowVm != null)
            {
                try
                {
                    this.ServiceHostContainer.Start();
                }
                catch (Exception exception)
                {
                    var message = @"Exception in client call: " + exception.Message;
                    var caption = @"Exception";
                    mainWindowVm.Host.UserInterface.DisplayMessage(message, caption, MessageButton.ButtonsOk, MessageType.MessageInformation, DefaultMessageButton.ButtonOk);               
                }

                // display windows full screen when started first time
                if (((int)mainWindowVm.SettingsViewModel.WindowsPosLeft == 0) && ((int)mainWindowVm.SettingsViewModel.WindowsPosTop == 0) && ((int)mainWindowVm.SettingsViewModel.WindowsPosWidth == 0) && ((int)mainWindowVm.SettingsViewModel.WindowsPosHeight == 0))
                {
                    var monitor = NativeMethods.MonitorFromPoint(new Point(0, 0), NativeMethods.MonitorDefaultToNearest);

                    if (monitor != IntPtr.Zero)
                    {
                        var monitorInfo = new MONITORINFO();
                        NativeMethods.GetMonitorInfo(monitor, monitorInfo);

                        var workingArea = monitorInfo.rcWork;

                        this.Left = workingArea.left;
                        this.Top = workingArea.top;
                        this.Width = workingArea.Width;
                        this.Height = workingArea.Height;
                    }
                }
                else
                {
                    this.Left = mainWindowVm.SettingsViewModel.WindowsPosLeft;
                    this.Top = mainWindowVm.SettingsViewModel.WindowsPosTop;
                    this.Width = mainWindowVm.SettingsViewModel.WindowsPosWidth;
                    this.Height = mainWindowVm.SettingsViewModel.WindowsPosHeight;
                }

                if (SplashScreenHelper.SplashScreen != null)
                {
                    SplashScreenHelper.SplashScreen.Close(TimeSpan.FromMilliseconds(10));
                    SplashScreenHelper.SplashScreen = null;
                }

                this.applicationLoadedTimer = new Timer(this.ApplicationLoadedTimerElapsed, mainWindowVm, 50, 50);
            }
        }

        /// <summary>
        /// Windows the source initialized handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void WindowSourceInitializedHandler(object sender, EventArgs e)
        {
            var hwndSource = PresentationSource.FromVisual((Window)sender) as WinInterop.HwndSource;
            if (hwndSource != null)
            {
                hwndSource.AddHook(DragHook);
            }
        }

        #endregion
    }
}