// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for App.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.ExceptionServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows;
    using System.Windows.Threading;

    using EH.ImsOpcBridge.Configuration;
    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Helpers;
    using EH.ImsOpcBridge.Support;
    using EH.ImsOpcBridge.UI.Wpf.Interop;

    using log4net;

    using NativeMethods = EH.ImsOpcBridge.UI.Wpf.Interop.NativeMethods;
    using Point = EH.ImsOpcBridge.UI.Wpf.Interop.Point;

    /// <summary>
    /// Class App
    /// </summary>
    public partial class App
    {
        #region Static Fields

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            // for formatting number, date, ...
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(ImsOpcBridgeSettings.Singleton.CultureName);

            // frontend language
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(ImsOpcBridgeSettings.Singleton.CultureName);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Currents the domain unhandled exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.ArgumentNullException">@ e</exception>
        protected void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(@"e");
            }

            // ReSharper disable LocalizableElement

            // put your tracing or logging code here (I put a message box as an example)
            var relativePathItems = new[] { @"SupportFiles", @"Crashs" };

            var crashFileInfo = ConfigurationFileSupport.GetConfigurationFileInfo(@"Endress+Hauser", @"ImsOpcBridge", null, false, true, relativePathItems, string.Format(CultureInfo.CurrentUICulture, @"{0:yyyyMMddHHmmss}.crash", DateTime.Now), true);
            var systemInfo = new SystemInfo(crashFileInfo.Directory);

            // ReSharper restore LocalizableElement
            TextWriter textWriter = crashFileInfo.AppendText();
            textWriter.WriteLine(e.ExceptionObject.ToString());
            systemInfo.WriteInTextFile(systemInfo.HardwareInformationList, textWriter);
            systemInfo.WriteInTextFile(systemInfo.SoftwareInformationList, textWriter);
            textWriter.Close();

            this.CleanCrashFiles(crashFileInfo.Directory);
            MessageBox.Show(e.ExceptionObject.ToString());
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        [Localizable(false)]
        [SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFile", Justification = "OK here.")]
        protected override void OnStartup(StartupEventArgs e)
        {
            var exePath = Path.GetDirectoryName(ResourceAssembly.Location);
            var oemAssembly = Assembly.LoadFile(exePath + @"\EH.ImsOpcBridge.Oem.dll");
            SplashScreenHelper.SplashScreen = new SplashScreen(oemAssembly, "ImsOpcBridgeSplashScreen.png");
            try
            {
                SplashScreenHelper.SplashScreen.Show(false, true);
            }
            catch (IOException)
            {
                SplashScreenHelper.SplashScreen = null;
            }

            // hook on error before app really starts
            AppDomain.CurrentDomain.UnhandledException += this.CurrentDomainUnhandledException;
            AppDomain.CurrentDomain.FirstChanceException += this.CurrentDomainFirstChanceException;
            base.OnStartup(e);
        }

        /// <summary>
        /// Moves the mouse.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = @"OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = @"OK here.")]
        private static void MoveMouse()
        {
            try
            {
                var monitor = NativeMethods.MonitorFromPoint(new Point(0, 0), NativeMethods.MonitorDefaultToNearest);

                if (monitor != IntPtr.Zero)
                {
                    var monitorInfo = new MONITORINFO();
                    NativeMethods.GetMonitorInfo(monitor, monitorInfo);

                    var monitorArea = monitorInfo.rcMonitor;

                    var offSetX = (monitorArea.Width - 1680) / 2;

                    var offSetY = (monitorArea.Height - 1050) / 2;

                    NativeMethods.SetCursorPos(520 + offSetX, 737 + offSetY);
                }
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch (Exception)
            {
                // ReSharper restore EmptyGeneralCatchClause
                // Do nothing.
            }
        }

        /// <summary>
        /// Applications the dispatcher unhandled exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DispatcherUnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private void ApplicationDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var comException = e.Exception as COMException;

            // OpenClipboard Failed
            if (comException != null && comException.ErrorCode == -2147221040)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Cleans the crash files.
        /// </summary>
        /// <param name="crashFileFolder">The crash file folder.</param>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "OK here.")]
        private void CleanCrashFiles(DirectoryInfo crashFileFolder)
        {
            while (crashFileFolder.GetFiles().Length > 20)
            {
                var fileInfo = new DirectoryInfo(crashFileFolder.FullName).GetFileSystemInfos().OrderByDescending(fi => fi.CreationTime).Last();
                fileInfo.Delete();
            }
        }

        /// <summary>
        /// Currents the domain first chance exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FirstChanceExceptionEventArgs"/> instance containing the event data.</param>
        private void CurrentDomainFirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            if (Logger.IsWarnEnabled)
            {
                var message = string.Format(CultureInfo.CurrentUICulture, EH.ImsOpcBridge.Configurator.Properties.Resources.ExceptionThrown_, e.Exception.Message);
                Logger.Warn(message, e.Exception);
            }
        }

        #endregion
    }
}